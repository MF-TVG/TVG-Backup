using System;
using System.Collections.Generic;
using System.Linq;

namespace USAACE.Common.Database
{
    /// <summary>
    /// A representation of a column in a SQL database table.
    /// </summary>
    public class Column
    {
        private Table _table;
        private String _name;
        private String _dataType;
        private Nullable<Int32> _maxLength;
        private Nullable<Int32> _numericPrecision;
        private Nullable<Int32> _numericScale;
        private SearchOperation _searchOperation;

        /// <summary>
        /// A constructor for a Column class based on column data.
        /// </summary>
        /// <param name="table">The table the column belongs to.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="dataType">The data type of the column.</param>
        /// <param name="maxLength">The max length of the column (if applicable).</param>
        /// <param name="numericPrecision">The numeric precision of the column (if applicable).</param>
        /// <param name="numericScale">The numeric scale of the column (if applicable).</param>
        public Column(Table table, String name, String dataType, Nullable<Int32> maxLength, Nullable<Int32> numericPrecision, Nullable<Int32> numericScale, SearchOperation searchOperation)
        {
            _table = table;
            _name = name;
            _dataType = dataType;
            _maxLength = maxLength;
            _numericPrecision = numericPrecision;
            _numericScale = numericScale;
            _searchOperation = searchOperation;
        }

        /// <summary>
        /// The table the column belongs to.
        /// </summary>
        public Table Table
        {
            get
            {
                return _table;
            }
        }

        /// <summary>
        /// The name of the column.
        /// </summary>
        public String Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// The data type of the column.
        /// </summary>
        public String DataType
        {
            get
            {
                return _dataType;
            }
        }

        /// <summary>
        /// The max length of the column, returns null if not applicable, -1 if no max length.
        /// </summary>
        public Nullable<Int32> MaxLength
        {
            get
            {
                return _maxLength;
            }
        }

        /// <summary>
        /// The numeric precision of the column, returns null if not applicable.
        /// </summary>
        public Nullable<Int32> NumericPrecision
        {
            get
            {
                return _numericPrecision;
            }
        }

        /// <summary>
        /// The numeric scale of the column, returns null if not applicable.
        /// </summary>
        public Nullable<Int32> NumericScale
        {
            get
            {
                return _numericScale;
            }
        }

        /// <summary>
        /// The type of search this column performs.
        /// </summary>
        public SearchOperation SearchOperation
        {
            get
            {
                return _searchOperation;
            }
        }

        /// <summary>
        /// Returns if one of the table's constraints is this column is a primary key.
        /// </summary>
        public Boolean IsPrimaryKey
        {
            get
            {
                return !Table.IsView && Table.Constraints.Any(x => x.Type == ConstraintType.PrimaryKey && x.Column == this);
            }
        }

        /// <summary>
        /// Returns if one of the table's constraints is this column is a foreign key.
        /// </summary>
        public Boolean IsForeignKey
        {
            get
            {
                return !Table.IsView && Table.Constraints.Any(x => x.Type == ConstraintType.ForeignKey && x.Column == this);
            }
        }

        /// <summary>
        /// Gets a list of search fields
        /// </summary>
        /// <returns></returns>
        public IList<Column> GetSearchColumns()
        {
            IList<Column> searchColumns = new List<Column>();

            if (this.IsPrimaryKey == false)
            {
                switch (this.DataType)
                {
                    case "nvarchar":
                    case "varchar":
                    case "char":
                        searchColumns.Add(new Column(this.Table, String.Format("{0}Contains", this.Name), this.DataType, this.MaxLength, this.NumericPrecision, this.NumericScale, SearchOperation.Contains));
                        searchColumns.Add(new Column(this.Table, String.Format("{0}IsIn", this.Name), this.DataType, this.MaxLength, this.NumericPrecision, this.NumericScale, SearchOperation.IsIn));
                        break;
                    case "numeric":
                    case "decimal":
                    case "tinyint":
                    case "smallint":
                    case "int":
                    case "bigint":
                    case "datetime":
                        searchColumns.Add(new Column(this.Table, String.Format("{0}MinRange", this.Name), this.DataType, this.MaxLength, this.NumericPrecision, this.NumericScale, SearchOperation.MinRange));
                        searchColumns.Add(new Column(this.Table, String.Format("{0}MaxRange", this.Name), this.DataType, this.MaxLength, this.NumericPrecision, this.NumericScale, SearchOperation.MaxRange));
                        searchColumns.Add(new Column(this.Table, String.Format("{0}IsIn", this.Name), this.DataType, this.MaxLength, this.NumericPrecision, this.NumericScale, SearchOperation.IsIn));
                        break;
                    default:
                        break;
                }
            }

            return searchColumns;
        }

        /// <summary>
        /// Overrides the ToString method to return the name of the column.
        /// </summary>
        /// <returns>The name of the column.</returns>
        public override String ToString()
        {
            return Name;
        }
    }
}
