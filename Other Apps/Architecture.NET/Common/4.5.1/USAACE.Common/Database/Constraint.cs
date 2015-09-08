using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace USAACE.Common.Database
{
    /// <summary>
    /// A representation of a SQL database table and column constraint
    /// </summary>
    public class Constraint
    {
        private const String PRIMARY_KEY_STRING = "PRIMARY KEY";
        private const String FOREIGN_KEY_STRING = "FOREIGN KEY";

        private Table _table;
        private String _name;
        private ConstraintType _type;
        private Column _column;

        /// <summary>
        /// Creates a Constraint object based on a table, the constraint name, and the type
        /// </summary>
        /// <param name="table">The Table object this constraint belongs to</param>
        /// <param name="name">The name of the constraint</param>
        /// <param name="type">The type of the constraint</param>
        public Constraint(Table table, String name, String type)
        {
            _table = table;
            _name = name;

            switch (type)
            {
                case PRIMARY_KEY_STRING: _type = ConstraintType.PrimaryKey; break;
                case FOREIGN_KEY_STRING: _type = ConstraintType.ForeignKey; break;
                default: break;
            }

            LoadConstraintDetails();
        }

        /// <summary>
        /// The Table this constraint belongs to
        /// </summary>
        public Table Table
        {
            get
            {
                return _table;
            }
        }

        /// <summary>
        /// The name of the constraint
        /// </summary>
        public String Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// The type of the constraint
        /// </summary>
        public ConstraintType Type
        {
            get
            {
                return _type;
            }
        }

        /// <summary>
        /// The Column this constraint belongs to
        /// </summary>
        public Column Column
        {
            get
            {
                return _column;
            }
        }

        /// <summary>
        /// Loads the details of the constraint
        /// </summary>
        public void LoadConstraintDetails()
        {
            SqlConnection connection = new SqlConnection(Table.Database.ConnectionString);

            connection.Open();

            String constraintQuery = String.Format("SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE WHERE TABLE_CATALOG = '{0}' AND TABLE_SCHEMA = '{1}' AND TABLE_NAME = '{2}' AND CONSTRAINT_NAME = '{3}'", this.Table.Database.Name, this.Table.Schema, this.Table.Name, this.Name);
            SqlDataAdapter constraintAdapter = new SqlDataAdapter(constraintQuery, connection);

            DataSet constraintDataSet = new DataSet();
            constraintAdapter.Fill(constraintDataSet);

            if (constraintDataSet.Tables[0].Rows.Count == 1)
            {
                this._column = Table.Columns.FirstOrDefault(x => x.Name == constraintDataSet.Tables[0].Rows[0]["COLUMN_NAME"].ToStringSafe());
            }

            connection.Close();
        }
    }
}
