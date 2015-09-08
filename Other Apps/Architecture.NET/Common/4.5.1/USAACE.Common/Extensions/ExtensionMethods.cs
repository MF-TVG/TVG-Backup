using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Web;
using System.Globalization;

namespace USAACE.Common
{
    /// <summary>
    /// A class for extension methods
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Utilizes null-safe ToString method output for input object.
        /// </summary>
        /// <param name="input">Input object to convert to string.</param>
        /// <returns>Object.ToString() if not null, returns null otherwise.</returns>
        public static String ToStringSafe(this object input)
        {
            return input.ToStringSafe(null);
        }

        /// <summary>
        /// Utilizes null-safe ToString method output for input object.
        /// </summary>
        /// <param name="input">Input object to convert to string.</param>
        /// <param name="valueIfNull">Value to return if input is null.</param>
        /// <returns>Object.ToString() if not null, returns valueIfNull value otherwise.</returns>
        public static String ToStringSafe(this object input, String valueIfNull)
        {
            if (input != null)
            {
                return input.ToString();
            }
            else
            {
                return valueIfNull;
            }
        }

        /// <summary>
        /// Utilizes null-safe ToShortDateString method output for input DateTime object.
        /// </summary>
        /// <param name="input">Input DateTime to convert to string.</param>
        /// <returns>DateTime.ToShortDateString() if not null, returns null otherwise.</returns>
        public static String ToShortDateStringSafe(this Nullable<DateTime> input)
        {
            if (input != null)
            {
                return input.Value.ToShortDateString();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Utilizes null-safe ToShortTimeString method output for input DateTime object.
        /// </summary>
        /// <param name="input">Input DateTime to convert to string.</param>
        /// <returns>DateTime.ToShortTimeString() if not null, returns null otherwise.</returns>
        public static String ToShortTimeStringSafe(this Nullable<DateTime> input)
        {
            if (input != null)
            {
                return input.Value.ToShortTimeString();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Utilizes null-safe ToString method output with format for input DateTime object.
        /// </summary>
        /// <param name="input">Input DateTime to convert to string.</param>
        /// <param name="format">Input format for converted string.</param>
        /// <returns>DateTime.ToString(format) with the specified format if not null, returns null otherwise.</returns>
        public static String ToDateStringSafe(this Nullable<DateTime> input, String format)
        {
            if (input != null)
            {
                return input.Value.ToString(format);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Attempts to convert an object value to the specified nullable type, returns null if conversion fails.
        /// </summary>
        /// <typeparam name="T">A struct that can be parsed (i.e. Int32, Double, DateTime, etc)</typeparam>
        /// <param name="value">Object value to parse.</param>
        /// <returns>Converted value, null if it cannot be parsed or if the input value is null.</returns>
        public static Nullable<T> ToNullable<T>(this Object value) where T : struct
        {
            if (String.IsNullOrEmpty(value.ToStringSafe()))
            {
                return null;
            }
            else
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

                if (converter != null)
                {
                    if (converter.CanConvertFrom(value.GetType()))
                    {
                        try
                        {
                            return converter.ConvertFrom(value) as Nullable<T>;
                        }
                        catch (Exception)
                        {
                            return null;
                        }
                    }
                    else
                    {
                        try
                        {
                            return converter.ConvertFromString(value.ToStringSafe()) as Nullable<T>;
                        }
                        catch (Exception)
                        {
                            return null;
                        }
                    }
                }
                else
                {
                    throw new Exception("This datatype does not support direct parsing.");
                }
            }
        }

        /// <summary>
        /// Tries to parse the date from a string based on a specified format
        /// </summary>
        /// <param name="value">The string value to parse</param>
        /// <param name="format">The format of the string</param>
        /// <returns>The DateTime if the string could be parsed, Null otherwise</returns>
        public static Nullable<DateTime> TryParseDateExact(this String value, String format)
        {
            DateTime result;

            if (DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Checks the string to see if it is one of the strings in the compare string.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="compareValues">The list of values to check against.</param>
        /// <returns>True if value is in the list of compareValues, False if not.</returns>
        public static Boolean IsIn(this String value, String compareValues)
        {
            return compareValues.Split(',').Contains(value);
        }

        /// <summary>
        /// Appends the items of another list to this list
        /// </summary>
        /// <typeparam name="T">The type of the items in this list</typeparam>
        /// <param name="list">The list to append the items to</param>
        /// <param name="appendList">The list of items to append</param>
        public static void AppendList<T>(this IList<T> list, IEnumerable<T> appendList)
        {
            foreach (T item in appendList)
            {
                list.Add(item);
            }
        }

        public static U GetValueOrDefault<T, U>(this IDictionary<T, U> dictionary, T key)
        {
            return dictionary.GetValueOrDefault(key, default(U));
        }

        public static U GetValueOrDefault<T, U>(this IDictionary<T, U> dictionary, T key, U defaultValue)
        {
            if (key != null && dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            else
            {
                return defaultValue;
            }
        }
    }
}
