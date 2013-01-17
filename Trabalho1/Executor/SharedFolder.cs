using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Executor
{
    /// <summary>
    /// Custom configuration section to hold the shared folder path.
    /// </summary>
    public class SharedFolder : ConfigurationSection
    {
        private static readonly SharedFolder _config =
            ConfigurationManager.GetSection("SharedFolder") as SharedFolder;

        /// <summary>
        /// Gets the shared folder settings from the configuration file.
        /// </summary>
        public static SharedFolder Settings
        {
            get { return _config; }
        }

        /// <summary>
        /// Gets or sets the shared folder path.
        /// </summary>
        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get { return (string)this["path"]; }
            set { this["path"] = value; }
        }
    }
}
