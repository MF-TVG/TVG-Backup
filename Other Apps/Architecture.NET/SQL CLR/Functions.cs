using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Data.SqlTypes;

namespace USAACE.SQLCLR
{
    public static class Functions
    {
        [SqlFunction(DataAccess = DataAccessKind.Read, FillRowMethodName = "GetSplitStringRow", TableDefinition = "StringValue varchar(MAX)")]
        public static IEnumerable SplitString(String input, String delimiter)
        {
            return !String.IsNullOrEmpty(input) ? input.Split(new String[] { delimiter }, StringSplitOptions.RemoveEmptyEntries)
                : new String[] { String.Empty };
        }

        private static void GetSplitStringRow(Object rowObject, out SqlString value)
        {
            String row = (String)rowObject;
            value = new SqlString(row);
        }
    }
}
