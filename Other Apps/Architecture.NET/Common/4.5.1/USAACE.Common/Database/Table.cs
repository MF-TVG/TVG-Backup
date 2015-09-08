using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace USAACE.Common.Database
{
    /// <summary>
    /// A representation of a SQL database table
    /// </summary>
    public class Table
    {
        private Database _database;
        private String _name;
        private String _schema;
        private IList<Column> _columns;
        private IList<Constraint> _constraints;
        private Boolean _isView;

        /// <summary>
        /// Creates a table object based on a SQL database, the name of the table, and the schema of the table
        /// </summary>
        /// <param name="database">The Database object this table belongs to</param>
        /// <param name="name">The name of the table</param>
        /// <param name="schema">The schema of the table</param>
        public Table(Database database, String name, String schema, Boolean isView)
        {
            _database = database;
            _name = name;
            _schema = schema;
            _isView = isView;
        }

        /// <summary>
        /// The Database this table belongs to
        /// </summary>
        public Database Database
        {
            get
            {
                return _database;
            }
        }

        /// <summary>
        /// The name of the table
        /// </summary>
        public String Name
        {
            get
            {
                return _name;
            }
        }
        
        /// <summary>
        /// The schema of the table
        /// </summary>
        public String Schema
        {
            get
            {
                return _schema;
            }
        }

        /// <summary>
        /// Whether the table is a view
        /// </summary>
        public Boolean IsView
        {
            get
            {
                return _isView;
            }
        }

        /// <summary>
        /// The list of columns for this table
        /// </summary>
        public IList<Column> Columns
        {
            get
            {
                if (_columns == null)
                {
                    _columns = new List<Column>();

                    this.LoadColumns();
                }

                return _columns;
            }
        }

        /// <summary>
        /// The list of constraints for this table
        /// </summary>
        public IList<Constraint> Constraints
        {
            get
            {
                if (_constraints == null)
                {
                    _constraints = new List<Constraint>();

                    this.LoadConstraints();
                }

                return _constraints;
            }
        }

        /// <summary>
        /// The list of primary keys for this table
        /// </summary>
        public IList<Column> PrimaryKeys
        {
            get
            {
                return Columns.Where(x => x.IsPrimaryKey).ToList();
            }
        }

        /// <summary>
        /// The list of foreign keys for this table
        /// </summary>
        public IList<Column> ForeignKeys
        {
            get
            {
                return Columns.Where(x => x.IsForeignKey).ToList();
            }
        }

        /// <summary>
        /// Loads the columns for this table
        /// </summary>
        private void LoadColumns()
        {
            SqlConnection connection = new SqlConnection(Database.ConnectionString);

            connection.Open();

            String columnQuery = String.Format(SchemaConstants.LOAD_TABLE_COLUMNS, Database.Name, this.Schema, this.Name);
            SqlDataAdapter columnAdapter = new SqlDataAdapter(columnQuery, connection);

            DataSet columnDataSet = new DataSet();
            columnAdapter.Fill(columnDataSet);

            foreach (DataRow row in columnDataSet.Tables[0].Rows)
            {
                this._columns.Add(new Column(this, row["COLUMN_NAME"].ToStringSafe(), row["DATA_TYPE"].ToStringSafe(), row["CHARACTER_MAXIMUM_LENGTH"].ToNullable<Int32>(), row["NUMERIC_PRECISION"].ToNullable<Int32>(), row["NUMERIC_SCALE"].ToNullable<Int32>(), SearchOperation.None));
            }

            connection.Close();
        }

        /// <summary>
        /// Loads the constraints for this table
        /// </summary>
        private void LoadConstraints()
        {
            if (this.IsView)
            {
                return;
            }

            SqlConnection connection = new SqlConnection(Database.ConnectionString);

            connection.Open();

            String constraintQuery = String.Format(SchemaConstants.LOAD_TABLE_CONSTRAINTS, this.Database.Name, this.Schema, this.Name);
            SqlDataAdapter constraintAdapter = new SqlDataAdapter(constraintQuery, connection);

            DataSet constraintDataSet = new DataSet();
            constraintAdapter.Fill(constraintDataSet);

            foreach (DataRow row in constraintDataSet.Tables[0].Rows)
            {
                this._constraints.Add(new Constraint(this, row["CONSTRAINT_NAME"] as String, row["CONSTRAINT_TYPE"] as String));
            }

            connection.Close();
        }

        /// <summary>
        /// Overrides the ToString method to return the schema and name of the table
        /// </summary>
        /// <returns>The schema and name of the database separated by a period</returns>
        public override String ToString()
        {
            return String.Format("{0}.{1}", this.Schema, this.Name);
        }
    }
}
