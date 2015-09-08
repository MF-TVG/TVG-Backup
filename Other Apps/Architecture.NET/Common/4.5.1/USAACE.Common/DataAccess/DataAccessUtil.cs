using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.Common.DataAccess
{
    /// <summary>
    /// Provides utility methods for data access purposes.
    /// </summary>
    public static class DataAccessUtil
    {
        /// <summary>
        /// Translates a CLR type into a SQL data type.
        /// </summary>
        /// <param name="type">The CLR type to translate.</param>
        /// <returns>The translated SQL data type.</returns>
        public static SqlDbType GetSqlType(Type type)
        {
            if (type == typeof(Nullable<Boolean>))
            {
                return SqlDbType.Bit;
            }
            else if (type == typeof(Nullable<Byte>))
            {
                return SqlDbType.TinyInt;
            }
            else if (type == typeof(Nullable<Int16>))
            {
                return SqlDbType.SmallInt;
            }
            else if (type == typeof(Nullable<Int32>))
            {
                return SqlDbType.Int;
            }
            else if (type == typeof(Nullable<Int64>))
            {
                return SqlDbType.BigInt;
            }
            else if (type == typeof(String))
            {
                return SqlDbType.VarChar;
            }
            else if (type == typeof(Nullable<DateTime>))
            {
                return SqlDbType.DateTime;
            }
            else if (type == typeof(Nullable<Decimal>))
            {
                return SqlDbType.Decimal;
            }
            else if (type == typeof(Byte[]))
            {
                return SqlDbType.VarBinary;
            }
            else if (type == typeof(IList<Nullable<Byte>>) || type == typeof(IList<Nullable<Int16>>) || type == typeof(IList<Nullable<Int32>>) ||
                type == typeof(IList<String>) || type == typeof(IList<Nullable<DateTime>>) || type == typeof(IList<Nullable<Decimal>>))
            {
                return SqlDbType.NVarChar;
            }
            else
            {
                throw new Exception("This type cannot be converted to a SQL Database Type");
            }
        }

        /// <summary>
        /// Gets the SQL parameter name for a given property name.
        /// </summary>
        /// <param name="propertyName">The property name to get the SQL parameter name for.</param>
        /// <returns>The SQL parameter name.</returns>
        public static String GetParameterName(String propertyName)
        {
            return String.Format("@{0}", propertyName);
        }

        /// <summary>
        /// Gets the stored procedure name based for the given entity and data operation.
        /// </summary>
        /// <param name="entity">The entity to get the stored procedure for.</param>
        /// <param name="operation">The desired data operation of the stored procedure.</param>
        /// <returns>The proper stored procedure name.</returns>
        public static String GetStoredProcedureName(EntityBase entity, DataOperation operation)
        {
            EntityTable table = entity.GetType().GetCustomAttributes(typeof(EntityTable), false).FirstOrDefault() as EntityTable;

            if (table != null)
            {
                switch (operation)
                {
                    case DataOperation.Load:
                    case DataOperation.Search:
                        return String.Format("{0}.Search{1}", table.Schema, entity.GetType().Name);
                    case DataOperation.Insert:
                        return String.Format("{0}.Insert{1}", table.Schema, entity.GetType().Name);
                    case DataOperation.Delete:
                        return String.Format("{0}.Delete{1}", table.Schema, entity.GetType().Name);
                    case DataOperation.Update:
                        return String.Format("{0}.Update{1}", table.Schema, entity.GetType().Name);
                    default:
                        throw new Exception("Invalid Data Operation specified");
                }
            }
            else
            {
                throw new Exception("Entity has an invalid or missing EntityTable attribute");
            }
        }
    }
}
