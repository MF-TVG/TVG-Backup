using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace USAACE.Common.Database
{
    /// <summary>
    /// A representation of a SQL database
    /// </summary>
    public class Database
    {
        private String _connectionString;
        private String _name;
        private IList<Table> _tables;

        /// <summary>
        /// Creates a Database object based on a connection string
        /// </summary>
        /// <param name="connectionString">The SQL connection string for the database</param>
        public Database(String connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// The SQL connection string for the database
        /// </summary>
        public String ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        /// <summary>
        /// The name of the database
        /// </summary>
        public String Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// The list of database tables
        /// </summary>
        public IList<Table> Tables
        {
            get
            {
                if (_tables == null)
                {
                    _tables = new List<Table>();

                    this.LoadTables();
                }

                return _tables;
            }
        }

        /// <summary>
        /// Loads the list of tables for the database
        /// </summary>
        public void LoadTables()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            _name = connection.Database;

            connection.Open();

            String tableQuery = SchemaConstants.LOAD_TABLES;
            SqlDataAdapter tableAdapter = new SqlDataAdapter(tableQuery, connection);

            DataSet tableDataSet = new DataSet();
            tableAdapter.Fill(tableDataSet);

            foreach (DataRow row in tableDataSet.Tables[0].Rows)
            {
                this._tables.Add(new Table(this, row["TABLE_NAME"] as String, row["TABLE_SCHEMA"] as String, row["TABLE_TYPE"] as String == "VIEW"));
            }

            connection.Close();
        }

        /// <summary>
        /// Overrides the ToString method to return the name of the database
        /// </summary>
        /// <returns>The name of the database</returns>
        public override String ToString()
        {
            return this.Name;
        }
    }
}
