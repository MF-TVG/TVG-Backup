using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.Program data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class Program : EntityBase
    {
        private ProgramSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public ProgramSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new ProgramSearch();
                }

                return _searchProperties;
            }
        }

        private ProgramExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public ProgramExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new ProgramExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _programID;

        /// <summary>
        /// A property representation of the ProgramID field for a record in the dbo.Program data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> ProgramID
        {
            get { return _programID; }
            set { _programID = value; }
        }

        private String _programName;

        /// <summary>
        /// A property representation of the ProgramName field for a record in the dbo.Program data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String ProgramName
        {
            get { return _programName; }
            set { _programName = value; }
        }

        private String _programDescription;

        /// <summary>
        /// A property representation of the ProgramDescription field for a record in the dbo.Program data table. 
        /// </summary>
        [EntityProperty()]
        public String ProgramDescription
        {
            get { return _programDescription; }
            set { _programDescription = value; }
        }

        private Nullable<Int16> _fiscalYear;

        /// <summary>
        /// A property representation of the FiscalYear field for a record in the dbo.Program data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> FiscalYear
        {
            get { return _fiscalYear; }
            set { _fiscalYear = value; }
        }

        private Nullable<Boolean> _locked;

        /// <summary>
        /// A property representation of the Locked field for a record in the dbo.Program data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> Locked
        {
            get { return _locked; }
            set { _locked = value; }
        }

    }

    [Serializable]
    public class ProgramSearch : EntitySearchBase
    {
        internal ProgramSearch() { }

        private String _programNameContains;

        /// <summary>
        /// A search property representation of the ProgramNameContains field for a record in the dbo.Program data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String ProgramNameContains
        {
            get { return _programNameContains; }
            set { _programNameContains = value; }
        }

        private IList<String> _programNameIsIn;

        /// <summary>
        /// A search property representation of the ProgramNameIsIn field for a record in the dbo.Program data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> ProgramNameIsIn
        {
            get
            {
                if (_programNameIsIn == null)
                {
                    _programNameIsIn = new List<String>();
                }
                return _programNameIsIn;
            }
            set { _programNameIsIn = value; }
        }

        private String _programDescriptionContains;

        /// <summary>
        /// A search property representation of the ProgramDescriptionContains field for a record in the dbo.Program data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public String ProgramDescriptionContains
        {
            get { return _programDescriptionContains; }
            set { _programDescriptionContains = value; }
        }

        private IList<String> _programDescriptionIsIn;

        /// <summary>
        /// A search property representation of the ProgramDescriptionIsIn field for a record in the dbo.Program data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<String> ProgramDescriptionIsIn
        {
            get
            {
                if (_programDescriptionIsIn == null)
                {
                    _programDescriptionIsIn = new List<String>();
                }
                return _programDescriptionIsIn;
            }
            set { _programDescriptionIsIn = value; }
        }

        private Nullable<Int16> _fiscalYearMinRange;

        /// <summary>
        /// A search property representation of the FiscalYearMinRange field for a record in the dbo.Program data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> FiscalYearMinRange
        {
            get { return _fiscalYearMinRange; }
            set { _fiscalYearMinRange = value; }
        }

        private Nullable<Int16> _fiscalYearMaxRange;

        /// <summary>
        /// A search property representation of the FiscalYearMaxRange field for a record in the dbo.Program data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> FiscalYearMaxRange
        {
            get { return _fiscalYearMaxRange; }
            set { _fiscalYearMaxRange = value; }
        }

        private IList<Nullable<Int16>> _fiscalYearIsIn;

        /// <summary>
        /// A search property representation of the FiscalYearIsIn field for a record in the dbo.Program data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> FiscalYearIsIn
        {
            get
            {
                if (_fiscalYearIsIn == null)
                {
                    _fiscalYearIsIn = new List<Nullable<Int16>>();
                }
                return _fiscalYearIsIn;
            }
            set { _fiscalYearIsIn = value; }
        }

    }

    [Serializable]
    public partial class ProgramExtended : EntityExtendedBase
    {
        internal ProgramExtended() { }
    }
}