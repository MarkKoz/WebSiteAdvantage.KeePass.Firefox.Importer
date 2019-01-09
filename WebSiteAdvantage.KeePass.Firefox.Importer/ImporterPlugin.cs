/*
 * WebSiteAdvantage KeePass to Firefox
 *
 * Copyright (C) 2019 Mark Kozlov
 * Copyright (C) 2008 - 2012 Anthony James McCreath
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 */

using KeePass;
using KeePass.Plugins;

namespace WebSiteAdvantage.KeePass.Firefox.Importer
{
    /// <summary>
    /// Registers the plugin with KeePass.
    /// </summary>
    public sealed class ImporterPlugin : Plugin
    {
        private IPluginHost host = null;

        public override bool Initialize(IPluginHost host)
        {
            if (host == null)
                return false;

            this.host = host;
            Program.FileFormatPool.Add(FirefoxFormatImporter.Instance);

            return true; // Initialisation successful.
        }

        public override void Terminate()
        {
            Program.FileFormatPool.Remove(FirefoxFormatImporter.Instance);
        }
    }
}
