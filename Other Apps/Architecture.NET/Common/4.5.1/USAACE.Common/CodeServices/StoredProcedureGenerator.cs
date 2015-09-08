using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Database;

namespace USAACE.Common.CodeServices
{
    /// <summary>
    /// Used for generating stored procedures based on database table information.
    /// </summary>
    public class StoredProcedureGenerator
    {
        /// <summary>
        /// Used for generating an insert stored procedure for a table.
        /// </summary>
        /// <param name="table">The data table to generate the insert stored procedure for.</param>
        /// <returns>The generated insert stored procedure text.</returns>
        public static String GenerateInsertProcedure(Table table)
        {
            IList<String> parameterDeclares = new List<String>();
            IList<String> columnNames = new List<String>();
            IList<String> parameterNames = new List<String>();

            foreach (Column column in table.Columns)
            {
                if (!column.IsPrimaryKey)
                {
                    parameterDeclares.Add(GenerationUtil.GetParameterFormat(column));
                    columnNames.Add(GenerationUtil.GetColumnName(column));
                    parameterNames.Add(GenerationUtil.GetParameterName(column));
                }
            }

            return String.Format(INSERT_PROCEDURE_TEMPLATE, table.Database.Name, table.Schema, table.Name, String.Join(",\r\n", parameterDeclares.ToArray()), String.Join(", ", columnNames.ToArray()), String.Join(", ", parameterNames.ToArray()));
        }

        private const String INSERT_PROCEDURE_TEMPLATE =
@"USE [{0}];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{1}].[Insert{2}]') AND type in (N'P', N'PC'))
DROP PROCEDURE [{1}].[Insert{2}]
GO

CREATE PROCEDURE [{1}].[Insert{2}]
(
{3}
)
AS

/* This stored procedure is used for inserting a record into the {1}.{2} table. */
SET NOCOUNT OFF;
INSERT INTO [{1}].[{2}] ({4})
VALUES ({5})
SELECT SCOPE_IDENTITY() AS ID
GO
";
        /// <summary>
        /// Used for generating an update stored procedure for a table.
        /// </summary>
        /// <param name="table">The data table to generate the update stored procedure for.</param>
        /// <returns>The generated update stored procedure text.</returns>
        public static String GenerateUpdateProcedure(Table table)
        {
            IList<String> parameterDeclares = new List<String>();
            IList<String> columnSets = new List<String>();

            Column primaryKeyColumn = null;

            foreach (Column column in table.Columns)
            {
                parameterDeclares.Add(GenerationUtil.GetParameterFormat(column));

                if (!column.IsPrimaryKey)
                {
                    columnSets.Add(GenerationUtil.GetColumnSetFormat(column));
                }
                else
                {
                    primaryKeyColumn = column;
                }
            }

            return String.Format(UPDATE_PROCEDURE_TEMPLATE, table.Database.Name, table.Schema, table.Name, String.Join(",\r\n", parameterDeclares.ToArray()), String.Join(",\r\n", columnSets.ToArray()), GenerationUtil.GetColumnName(primaryKeyColumn), GenerationUtil.GetParameterName(primaryKeyColumn));
        }

        private const String UPDATE_PROCEDURE_TEMPLATE =
@"USE [{0}];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{1}].[Update{2}]') AND type in (N'P', N'PC'))
DROP PROCEDURE [{1}].[Update{2}]
GO

CREATE PROCEDURE [{1}].[Update{2}]
(
{3}
)
AS

/* This stored procedure is used for updating a record in the {1}.{2} table. */
SET NOCOUNT OFF;
UPDATE [{1}].[{2}]
SET
{4}
WHERE {5} = {6}
GO
";
        /// <summary>
        /// Used for generating a delete stored procedure for a table.
        /// </summary>
        /// <param name="table">The data table to generate the delete stored procedure for.</param>
        /// <returns>The generated delete stored procedure text.</returns>
        public static String GenerateDeleteProcedure(Table table)
        {
            IList<String> parameterDeclares = new List<String>();

            Column primaryKeyColumn = null;

            foreach (Column column in table.Columns)
            {
                if (column.IsPrimaryKey)
                {
                    parameterDeclares.Add(GenerationUtil.GetParameterFormat(column));
                    primaryKeyColumn = column;
                }
            }

            return String.Format(DELETE_PROCEDURE_TEMPLATE, table.Database.Name, table.Schema, table.Name, String.Join(",\r\n", parameterDeclares.ToArray()), GenerationUtil.GetColumnName(primaryKeyColumn), GenerationUtil.GetParameterName(primaryKeyColumn));
        }

        private const String DELETE_PROCEDURE_TEMPLATE =
@"USE [{0}];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{1}].[Delete{2}]') AND type in (N'P', N'PC'))
DROP PROCEDURE [{1}].[Delete{2}]
GO

CREATE PROCEDURE [{1}].[Delete{2}]
(
{3}
)
AS

/* This stored procedure is used for deleting a record in the {1}.{2} table. */
SET NOCOUNT OFF;
DELETE FROM [{1}].[{2}]
WHERE {4} = {5}
GO
";
        /// <summary>
        /// Used for generating a search stored procedure for a table.
        /// </summary>
        /// <param name="table">The data table to generate the search stored procedure for.</param>
        /// <returns>The generated search stored procedure text.</returns>
        public static String GenerateSearchProcedure(Table table)
        {
            IList<String> parameterDeclares = new List<String>();
            IList<String> columnNames = new List<String>();
            IList<String> searchValues = new List<String>();

            foreach (Column column in table.Columns)
            {
                parameterDeclares.Add(GenerationUtil.GetParameterFormat(column));
                columnNames.Add(GenerationUtil.GetColumnName(column));
                searchValues.Add(GenerationUtil.GetColumnSearchFormat(column));

                foreach (Column searchColumn in column.GetSearchColumns())
                {
                    parameterDeclares.Add(GenerationUtil.GetParameterFormat(searchColumn));
                    searchValues.Add(GenerationUtil.GetColumnSearchFormat(searchColumn));
                }
            }

            return String.Format(SEARCH_PROCEDURE_TEMPLATE, table.Database.Name, table.Schema, table.Name, String.Join(",\r\n", parameterDeclares.ToArray()), String.Join(", ", columnNames.ToArray()), String.Join(" AND\r\n", searchValues.ToArray()));
        }

        private const String SEARCH_PROCEDURE_TEMPLATE =
@"USE [{0}];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{1}].[Search{2}]') AND type in (N'P', N'PC'))
DROP PROCEDURE [{1}].[Search{2}]
GO

CREATE PROCEDURE [{1}].[Search{2}]
(
{3}
)
AS

/* This stored procedure is used for searching records in the {1}.{2} table. */
SET NOCOUNT OFF;
SELECT {4} FROM [{1}].[{2}]
WHERE
{5}
GO
";
    }
}

        