using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace USAACE.Common.Util
{
    /// <summary>
    /// Contains utility functions for assistance with web configuration
    /// </summary>
    public static class ConfigUtil
    {
        /// <summary>
        /// Gets a configuration value in the AppSettings section by key
        /// </summary>
        /// <param name="key">The key of the setting to retrieve</param>
        /// <returns>The value of the setting for the specified key</returns>
        public static String GetConfigurationValue(String key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
