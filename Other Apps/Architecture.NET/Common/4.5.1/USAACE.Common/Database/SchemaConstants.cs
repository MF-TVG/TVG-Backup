using System;

namespace USAACE.Common.Database
{
    internal static class SchemaConstants
    {
        internal const String LOAD_TABLES = "SELECT * FROM INFORMATION_SCHEMA.TABLES";
        internal const String LOAD_TABLE_COLUMNS = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_CATALOG = '{0}' AND TABLE_SCHEMA = '{1}' AND TABLE_NAME = '{2}'";
        internal const String LOAD_TABLE_CONSTRAINTS = "SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_CATALOG = '{0}' AND TABLE_SCHEMA = '{1}' AND TABLE_NAME = '{2}'";
    }
}
