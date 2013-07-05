/*	WebSiteAdvantage KeePass to Firefox 
 *	Copyright (C) 2008 - 2012  Anthony James McCreath
 *
 *	This library is free software; you can redistribute it and/or
 *	modify it under the terms of the GNU Lesser General Public
 *	License as published by the Free Software Foundation; either
 *	version 2.1 of the License, or (at your option) any later version.
 *
 *	This library is distributed in the hope that it will be useful,
 *	but WITHOUT ANY WARRANTY; without even the implied warranty of
 *	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 *	Lesser General Public License for more details.
 *
 *	You should have received a copy of the GNU Lesser General Public
 *	License along with this library; if not, write to the Free Software
 *	Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using WebSiteAdvantage.KeePass.Firefox.Gecko;
using System.Diagnostics;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace WebSiteAdvantage.KeePass.Firefox
{
	/// <summary>
	/// represents the content of a firefox signon file
	/// </summary>
	public class FirefoxSignonsFile
	{
		#region Construction and Loading
		/// <summary>
		/// Quick way to load a new file
		/// </summary>
		/// <param name="profile">Profile with the signon file</param>
		public static FirefoxSignonsFile Create(FirefoxProfile profile, string password)
		{
			FirefoxSignonsFile file = new FirefoxSignonsFile();
			file.Load(profile, password);

			return file;
		}
		private Assembly _SQLite = null;
		/// <summary>
		/// load this object with signon data related to the supplied profile
		/// </summary>
		/// <param name="profile"></param>
		public void Load(FirefoxProfile profile,string password)
		{
			Profile = profile;

			if (Profile.ProfilePath == null)
				throw new Exception("Failed to determine the location of the default Firefox Profile");

			SECStatus result1 = NSS3.NSS_Init(Profile.ProfilePath); // init for profile


            if (result1 != SECStatus.Success)
            {
                Int32 error = NSPR4.PR_GetError();
                string errorName = NSPR4.PR_ErrorToName(error);
                throw new Exception("Failed to initialise profile for load at " + Profile.ProfilePath + " reason " + errorName);
            }

			try
			{

				IntPtr slot = NSS3.PK11_GetInternalKeySlot(); // get a slot to work with

				if (slot == IntPtr.Zero)
					throw new Exception("Failed to GetInternalKeySlot");

				try
				{
					SECStatus result2 = NSS3.PK11_CheckUserPassword(slot, password);

                    if (result2 != SECStatus.Success)
                    {
                        Int32 error = NSPR4.PR_GetError();
                        string errorName = NSPR4.PR_ErrorToName(error);
                        throw new Exception("Failed to Validate Password: " + errorName);
                    }

					string header = null;
					string signonFile = null;

					string signonSqlLitePath = Path.Combine(Profile.ProfilePath, "signons.sqlite");

					if (File.Exists(signonSqlLitePath))
					{
						if (_SQLite==null)
						{
							if (KeePassUtilities.Is64Bit)
                                _SQLite = Assembly.LoadFrom(Application.StartupPath + @"\WebSiteAdvantageKeePassFirefox-SQLite\4x64\System.Data.SQLite.dll");
							else
                                _SQLite = Assembly.LoadFrom(Application.StartupPath + @"\WebSiteAdvantageKeePassFirefox-SQLite\4x32\System.Data.SQLite.DLL");
						}

						IDbConnection connection = (IDbConnection)_SQLite.CreateInstance("System.Data.SQLite.SQLiteConnection");

						connection.ConnectionString = "Data Source=" + signonSqlLitePath + ";Version=3;New=False;Compress=True;";

				//		SQLiteConnection connection = new SQLiteConnection("Data Source=" + signonSqlLitePath + ";Version=3;New=False;Compress=True;");

						try
						{
							connection.Open();

							//		SQLiteCommand command = new SQLiteCommand("select id, desc from mains", connection);

							Type adapterType = _SQLite.GetType("System.Data.SQLite.SQLiteDataAdapter");

							IDataAdapter adapter = (IDataAdapter)Activator.CreateInstance(adapterType, new object[] {"SELECT "+
								"id, hostname, httpRealm, formSubmitURL, usernameField, passwordField, encryptedUsername, encryptedPassword, guid, encType "+
								"FROM moz_logins ORDER BY hostname", connection});

							//SQLiteDataAdapter adapter = new SQLiteDataAdapter(
							//    "SELECT "+
							//    "id, hostname, httpRealm, formSubmitURL, usernameField, passwordField, encryptedUsername, encryptedPassword, guid, encType "+
							//    "FROM moz_logins ORDER BY hostname", connection);

							DataSet dataSet = new DataSet();

							adapter.Fill(dataSet);

							foreach (DataRow row in dataSet.Tables[0].Rows)
							{

								FirefoxSignonSite signonSite = null;

								foreach (DataColumn column in dataSet.Tables[0].Columns)
								{
									Debug.WriteLine(column.ColumnName + "=" + (row.IsNull(column) ? "NULL" : row[column].ToString()));


								}

								string hostname = row["hostname"].ToString();

								if (signonSite == null || signonSite.Site != hostname)
								{
									signonSite = new FirefoxSignonSite();
									signonSite.Site = hostname;
									this.SignonSites.Add(signonSite);
								};

								FirefoxSignon signon = new FirefoxSignon();
								signonSite.Signons.Add(signon);
								string u = NSS3.DecodeAndDecrypt(row["encryptedUsername"].ToString());
								Debug.WriteLine("U=" + u);
								signon.UserName = u;
								signon.UserNameField = row.IsNull("usernameField") ? String.Empty : row["usernameField"].ToString();
								string p = NSS3.DecodeAndDecrypt(row["encryptedPassword"].ToString());
								Debug.WriteLine("P=" + p);
								signon.Password = p;
								signon.PasswordField = row.IsNull("passwordField") ? String.Empty : row["passwordField"].ToString();
								signon.LoginFormDomain = row.IsNull("formSubmitURL") ? String.Empty : row["formSubmitURL"].ToString();
							}

						}
						finally
						{
							connection.Close();
						}

					}
					else
					{
						int version = 3;

						while (signonFile == null && version > 0)
						{
							string signonPath = Path.Combine(Profile.ProfilePath, SignonFileNames[version]);
							if (File.Exists(signonPath))
							{
								signonFile = signonPath;
								header = SignonHeaderValues[version];
							}
							else
								version--;
						}

						Version = version;

						if (version == 0)
							throw new Exception("Cound not find a signon file to process");

						StreamReader reader = File.OpenText(signonFile);

						try
						{
							// first line is header
							string line = reader.ReadLine();

							if (line == null)
								throw new Exception("signon file is empty");

							if (line != header)
								throw new Exception("signon file contains an invalid header");

							// lines till the first dot are host excludes

							while ((line = reader.ReadLine()) != null && line != ".")
							{
								Debug.WriteLine("# " + line);

								Debug.WriteLine("ExcludeHost: " + line);

								this.ExcludeHosts.Add(line);
							}
							FirefoxSignonSite signonSite = null;
							// read each entry

							while (line != null)
							{
								Debug.WriteLine("## " + line);

								// here after any dot (.) therefore new site
								// all new lines pass through if they contain a dot (.)

								signonSite = null;


								while ((line = reader.ReadLine()) != null && line != ".")
								{
									Debug.WriteLine("# " + line);
									// first line is host
									// subsequent lines are pairs of name value
									// if name starts with * then its a password
									// values are encrypted

									if (signonSite == null) // site is reset to null after each dot (.)
									{
										signonSite = new FirefoxSignonSite();
										signonSite.Site = line;

										this.SignonSites.Add(signonSite);

										Debug.WriteLine("Site: " + line);

										line = reader.ReadLine(); // move to the next line
										Debug.WriteLine("# " + line);
									}
									// else stick to the same line for the next parser, second site entries dont have a dot (.) nor site line



									if (line != null && line != ".")
									{
										FirefoxSignon signon = new FirefoxSignon();
										signonSite.Signons.Add(signon);
										// User field
										signon.UserNameField = line;
										Debug.WriteLine("UserNameField: " + signon.UserNameField);

										if ((line = reader.ReadLine()) != null && line != ".")
										{
											Debug.WriteLine("# " + line);
											// User Value
											string u = NSS3.DecodeAndDecrypt(line);
											signon.UserName = u;
											Debug.WriteLine("UserName: " + signon.UserName);

											if ((line = reader.ReadLine()) != null && line != ".")
											{
												Debug.WriteLine("# " + line);
												// Password field
												signon.PasswordField = line.TrimStart(new char[] { '*' });
												Debug.WriteLine("PasswordField: " + signon.PasswordField);

												if ((line = reader.ReadLine()) != null && line != ".")
												{
													Debug.WriteLine("# " + line);
													// Password Value
													string p = NSS3.DecodeAndDecrypt(line);
													signon.Password = p;
													Debug.WriteLine("Password: " + signon.Password);

													if ((line = reader.ReadLine()) != null && line != ".")
													{
														Debug.WriteLine("# " + line);
														// Domain
														signon.LoginFormDomain = line;
														Debug.WriteLine("LoginFormDomain: " + signon.LoginFormDomain);

														if ((line = reader.ReadLine()) != null && line != ".")
														{
															Debug.WriteLine("# " + line);
															// Filler
															Debug.WriteLine("Filler: " + line);
														}
														// note: if there is not a dot (.) after this then its a subsequent entry for the same site
													}
												}
											}
										}
									}
								}
							}
						}
						finally
						{
							reader.Close();
						}
					}
				}
				finally
				{
					NSS3.PK11_FreeSlot(slot);
				}
			}
			finally
			{
				NSS3.NSS_Shutdown();
			}
		}
		#endregion

		#region Related Profile
		private FirefoxProfile _Profile;
		/// <summary>
		/// profile related to the signon file
		/// </summary>
		public FirefoxProfile Profile
		{
			get { return _Profile; }
			set { _Profile = value; }
		}
		#endregion

		#region File Data
		private int _Version = 0;
		/// <summary>
		/// The version of the file
		/// </summary>
		public int Version
		{
			get { return _Version; }
			set { _Version = value; }
		}

		private List<FirefoxSignonSite> _SignonSites = new List<FirefoxSignonSite>();
		/// <summary>
		/// Collection of singons that were stored in the file
		/// </summary>
		public List<FirefoxSignonSite> SignonSites
		{
			get { return _SignonSites; }
		}

		private List<String> _ExcludeHosts = new List<string>();
		/// <summary>
		/// hosts that have been excluded 
		/// </summary>
		public List<String> ExcludeHosts
		{
			get { return _ExcludeHosts; }
		}
		#endregion

		#region Information on Versions
		private static string[] _SignonFileNames = null;
		/// <summary>
		/// the file name used for each version of firefox
		/// </summary>
		public static string[] SignonFileNames
		{
			get
			{
				if (_SignonFileNames == null)
				{
					_SignonFileNames = new string[4];
					_SignonFileNames[0] = null;
					_SignonFileNames[1] = "signons.txt";
					_SignonFileNames[2] = "signons2.txt";
					_SignonFileNames[3] = "signons3.txt";
				}

				return _SignonFileNames;
			}
		}

		private static string[] _SignonHeaderValues = null;
		/// <summary>
		/// the headers used for each version of firefox
		/// </summary>
		public static string[] SignonHeaderValues
		{
			get
			{
				if (_SignonHeaderValues == null)
				{
					_SignonHeaderValues = new string[4];
					_SignonHeaderValues[0] = null;
					_SignonHeaderValues[1] = "#2c";
					_SignonHeaderValues[2] = "#2d";
					_SignonHeaderValues[3] = "#2e";
				}

				return _SignonHeaderValues;
			}
		}
		#endregion

	}
}
