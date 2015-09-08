using System;
using System.Runtime.Caching;

namespace USAACE.Common.Util
{
    /// <summary>
    /// A class containing several utility functions for dealing with caching
    /// </summary>
    public static class CacheUtil
    {
        /// <summary>
        /// Sets a cache object's value based on a key
        /// </summary>
        /// <param name="key">The key of the cached object</param>
        /// <param name="value">The value of the cached object</param>
        public static void SetCache(String key, Object value)
        {
            MemoryCache cache = MemoryCache.Default;

            if (value != null)
            {
                cache[key] = value;
            }
            else
            {
                cache.Remove(key);
            }
        }

        /// <summary>
        /// Gets a cache object's value based on a key
        /// </summary>
        /// <param name="key">The key of the cached object</param>
        /// <returns>The value of the cached object, null if it does not exist</returns>
        public static Object GetCache(String key)
        {
            MemoryCache cache = MemoryCache.Default;

            return cache.Get(key);
        }

        /// <summary>
        /// Removes a cache object based on a key
        /// </summary>
        /// <param name="key">The key of the cached object</param>
        public static void RemoveCache(String key)
        {
            SetCache(key, null);
        }
    }
}
