using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Database;

namespace USAACE.Common.CodeServices
{
    /// <summary>
    /// Provides utility methods for code generation purposes.
    /// </summary>
    public static class GenerationUtil
    {
        /// <summary>
        /// Gets a format for a parameter in a stored procedure based on column data.
        /// </summary>
        /// <param name="column">The column to get the parameter for.</param>
        /// <returns>The formatted parameter for the column specified.</returns>
        public static String GetParameterFormat(Column column)
        {
            String dataTypeString = null;

            if (column.SearchOperation != SearchOperation.IsIn)
            {
                switch (column.DataType)
                {
                    case "nvarchar":
                    case "varchar":
                    case "char":
                    case "varbinary":
                        dataTypeString = String.Format("{0}({1})", column.DataType, column.MaxLength != -1 ? column.MaxLength.ToString() : "MAX"); break;
                    case "numeric":
                    case "decimal":
                        dataTypeString = String.Format("{0}({1},{2})", column.DataType, column.NumericPrecision, column.NumericScale); break;
                    default:
                        dataTypeString = column.DataType; break;
                }
            }
            else
            {
                dataTypeString = "nvarchar(MAX)";
            }

            return String.Format("\t@{0} {1} = null", column.Name, dataTypeString);
        }

        /// <summary>
        /// Gets the CLR type for a column.
        /// </summary>
        /// <param name="column">The column to get the CLR type for.</param>
        /// <returns>The CLR type for the column specified.</returns>
        public static String GetClrType(Column column)
        {
            switch (column.DataType)
            {
                case "nvarchar":
                case "varchar":
                case "char":
                    return "String";
                case "numeric":
                case "decimal":
                    return "Nullable<Decimal>";
                case "bit":
                    return "Nullable<Boolean>";
                case "tinyint":
                    return "Nullable<Byte>";
                case "smallint":
                    return "Nullable<Int16>";
                case "int":
                    return "Nullable<Int32>";
                case "bigint":
                    return "Nullable<Int64>";
                case "datetime":
                    return "Nullable<DateTime>";
                case "varbinary":
                    return "Byte[]";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Gets property attribute settings for a column based on column information.
        /// </summary>
        /// <param name="column">The column to get the property attribute settings for.</param>
        /// <returns>The property attribute settings for the column specified.</returns>
        public static String GetPropertyAttributeSettings(Column column)
        {
            IList<String> attributeSettings = new List<String>();

            if (column.IsPrimaryKey)
            {
                attributeSettings.Add("IdentityField = true");
            }

            if (column.NumericPrecision.HasValue && column.NumericPrecision.Value >= 0)
            {
                attributeSettings.Add(String.Format("Precision = {0}", column.NumericPrecision.Value.ToString()));
            }

            if (column.NumericScale.HasValue && column.NumericScale.Value >= 0)
            {
                attributeSettings.Add(String.Format("Scale = {0}", column.NumericScale.Value.ToString()));
            }

            if (column.MaxLength.HasValue && column.MaxLength.Value >= 0)
            {
                attributeSettings.Add(String.Format("Size = {0}", column.MaxLength.Value.ToString()));
            }

            if (column.SearchOperation != SearchOperation.None)
            {
                attributeSettings.Add("SearchOnly = true");
            }

            return String.Join(", ", attributeSettings.ToArray());
        }

        /// <summary>
        /// Gets the member name for a column.
        /// </summary>
        /// <param name="column">The column to get the member name for.</param>
        /// <returns>The member name for the column specified.</returns>
        public static String GetMemberName(Column column)
        {
            return String.Format("_{0}{1}", column.Name.Substring(0, 1).ToLower(), column.Name.Substring(1));
        }

        /// <summary>
        /// Gets the SQL parameter name for a column.
        /// </summary>
        /// <param name="column">The column to get the SQL parameter name for.</param>
        /// <returns>The SQL parameter name for the column specified.</returns>
        public static String GetParameterName(Column column)
        {
            return String.Format("@{0}", column.Name);
        }

        /// <summary>
        /// Gets the column name for a column.
        /// </summary>
        /// <param name="column">The column to get the column name for.</param>
        /// <returns>The column name for the column specified.</returns>
        public static String GetColumnName(Column column)
        {
            return String.Format("[{0}]", column.SearchOperation == SearchOperation.None ? column.Name : column.Name.Replace(column.SearchOperation.ToString("G"), String.Empty));
        }

        /// <summary>
        /// Gets the column set format for a column.
        /// </summary>
        /// <param name="column">The column to get the column set format for.</param>
        /// <returns>The column set format for the column specified.</returns>
        public static String GetColumnSetFormat(Column column)
        {
            return String.Format("\t{0} = {1}", GenerationUtil.GetColumnName(column), GenerationUtil.GetParameterName(column));
        }

        /// <summary>
        /// Gets the column search format for a column.
        /// </summary>
        /// <param name="column">The column to get the column search format for.</param>
        /// <returns>The column search format for the column specified.</returns>
        public static String GetColumnSearchFormat(Column column)
        {
            switch (column.SearchOperation)
            {
                case SearchOperation.None:
                    return String.Format("\t({1} IS NULL OR {0} = {1})", GenerationUtil.GetColumnName(column), GenerationUtil.GetParameterName(column));
                case SearchOperation.MinRange:
                    return String.Format("\t({1} IS NULL OR {0} >= {1})", GenerationUtil.GetColumnName(column), GenerationUtil.GetParameterName(column));
                case SearchOperation.MaxRange:
                    return String.Format("\t({1} IS NULL OR {0} <= {1})", GenerationUtil.GetColumnName(column), GenerationUtil.GetParameterName(column));
                case SearchOperation.Contains:
                    return String.Format("\t({1} IS NULL OR {0} LIKE '%' + {1} + '%')", GenerationUtil.GetColumnName(column), GenerationUtil.GetParameterName(column));
                case SearchOperation.IsIn:
                    return String.Format("\t({1} IS NULL OR {0} IN (SELECT * FROM dbo.SplitString({1}, '||')))", GenerationUtil.GetColumnName(column), GenerationUtil.GetParameterName(column));

                default:
                    return null;
            }
        }
    }
}
