using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.HistoricalPercent data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class HistoricalPercent : EntityBase
    {
        private HistoricalPercentSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public HistoricalPercentSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new HistoricalPercentSearch();
                }

                return _searchProperties;
            }
        }

        private HistoricalPercentExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public HistoricalPercentExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new HistoricalPercentExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _historicalPercentID;

        /// <summary>
        /// A property representation of the HistoricalPercentID field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> HistoricalPercentID
        {
            get { return _historicalPercentID; }
            set { _historicalPercentID = value; }
        }

        private Nullable<Int32> _courseID;

        /// <summary>
        /// A property representation of the CourseID field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> CourseID
        {
            get { return _courseID; }
            set { _courseID = value; }
        }

        private Nullable<Int16> _january;

        /// <summary>
        /// A property representation of the January field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> January
        {
            get { return _january; }
            set { _january = value; }
        }

        private Nullable<Int16> _february;

        /// <summary>
        /// A property representation of the February field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> February
        {
            get { return _february; }
            set { _february = value; }
        }

        private Nullable<Int16> _march;

        /// <summary>
        /// A property representation of the March field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> March
        {
            get { return _march; }
            set { _march = value; }
        }

        private Nullable<Int16> _april;

        /// <summary>
        /// A property representation of the April field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> April
        {
            get { return _april; }
            set { _april = value; }
        }

        private Nullable<Int16> _may;

        /// <summary>
        /// A property representation of the May field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> May
        {
            get { return _may; }
            set { _may = value; }
        }

        private Nullable<Int16> _june;

        /// <summary>
        /// A property representation of the June field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> June
        {
            get { return _june; }
            set { _june = value; }
        }

        private Nullable<Int16> _july;

        /// <summary>
        /// A property representation of the July field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> July
        {
            get { return _july; }
            set { _july = value; }
        }

        private Nullable<Int16> _august;

        /// <summary>
        /// A property representation of the August field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> August
        {
            get { return _august; }
            set { _august = value; }
        }

        private Nullable<Int16> _september;

        /// <summary>
        /// A property representation of the September field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> September
        {
            get { return _september; }
            set { _september = value; }
        }

        private Nullable<Int16> _october;

        /// <summary>
        /// A property representation of the October field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> October
        {
            get { return _october; }
            set { _october = value; }
        }

        private Nullable<Int16> _november;

        /// <summary>
        /// A property representation of the November field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> November
        {
            get { return _november; }
            set { _november = value; }
        }

        private Nullable<Int16> _december;

        /// <summary>
        /// A property representation of the December field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> December
        {
            get { return _december; }
            set { _december = value; }
        }

        private Nullable<Int16> _support;

        /// <summary>
        /// A property representation of the Support field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> Support
        {
            get { return _support; }
            set { _support = value; }
        }

        private Nullable<Int16> _setback;

        /// <summary>
        /// A property representation of the Setback field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> Setback
        {
            get { return _setback; }
            set { _setback = value; }
        }

        private Nullable<Int16> _test;

        /// <summary>
        /// A property representation of the Test field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> Test
        {
            get { return _test; }
            set { _test = value; }
        }

    }

    [Serializable]
    public class HistoricalPercentSearch : EntitySearchBase
    {
        internal HistoricalPercentSearch() { }

        private Nullable<Int32> _courseIDMinRange;

        /// <summary>
        /// A search property representation of the CourseIDMinRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> CourseIDMinRange
        {
            get { return _courseIDMinRange; }
            set { _courseIDMinRange = value; }
        }

        private Nullable<Int32> _courseIDMaxRange;

        /// <summary>
        /// A search property representation of the CourseIDMaxRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> CourseIDMaxRange
        {
            get { return _courseIDMaxRange; }
            set { _courseIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _courseIDIsIn;

        /// <summary>
        /// A search property representation of the CourseIDIsIn field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> CourseIDIsIn
        {
            get
            {
                if (_courseIDIsIn == null)
                {
                    _courseIDIsIn = new List<Nullable<Int32>>();
                }
                return _courseIDIsIn;
            }
            set { _courseIDIsIn = value; }
        }

        private Nullable<Int16> _januaryMinRange;

        /// <summary>
        /// A search property representation of the JanuaryMinRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> JanuaryMinRange
        {
            get { return _januaryMinRange; }
            set { _januaryMinRange = value; }
        }

        private Nullable<Int16> _januaryMaxRange;

        /// <summary>
        /// A search property representation of the JanuaryMaxRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> JanuaryMaxRange
        {
            get { return _januaryMaxRange; }
            set { _januaryMaxRange = value; }
        }

        private IList<Nullable<Int16>> _januaryIsIn;

        /// <summary>
        /// A search property representation of the JanuaryIsIn field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> JanuaryIsIn
        {
            get
            {
                if (_januaryIsIn == null)
                {
                    _januaryIsIn = new List<Nullable<Int16>>();
                }
                return _januaryIsIn;
            }
            set { _januaryIsIn = value; }
        }

        private Nullable<Int16> _februaryMinRange;

        /// <summary>
        /// A search property representation of the FebruaryMinRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> FebruaryMinRange
        {
            get { return _februaryMinRange; }
            set { _februaryMinRange = value; }
        }

        private Nullable<Int16> _februaryMaxRange;

        /// <summary>
        /// A search property representation of the FebruaryMaxRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> FebruaryMaxRange
        {
            get { return _februaryMaxRange; }
            set { _februaryMaxRange = value; }
        }

        private IList<Nullable<Int16>> _februaryIsIn;

        /// <summary>
        /// A search property representation of the FebruaryIsIn field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> FebruaryIsIn
        {
            get
            {
                if (_februaryIsIn == null)
                {
                    _februaryIsIn = new List<Nullable<Int16>>();
                }
                return _februaryIsIn;
            }
            set { _februaryIsIn = value; }
        }

        private Nullable<Int16> _marchMinRange;

        /// <summary>
        /// A search property representation of the MarchMinRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> MarchMinRange
        {
            get { return _marchMinRange; }
            set { _marchMinRange = value; }
        }

        private Nullable<Int16> _marchMaxRange;

        /// <summary>
        /// A search property representation of the MarchMaxRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> MarchMaxRange
        {
            get { return _marchMaxRange; }
            set { _marchMaxRange = value; }
        }

        private IList<Nullable<Int16>> _marchIsIn;

        /// <summary>
        /// A search property representation of the MarchIsIn field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> MarchIsIn
        {
            get
            {
                if (_marchIsIn == null)
                {
                    _marchIsIn = new List<Nullable<Int16>>();
                }
                return _marchIsIn;
            }
            set { _marchIsIn = value; }
        }

        private Nullable<Int16> _aprilMinRange;

        /// <summary>
        /// A search property representation of the AprilMinRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> AprilMinRange
        {
            get { return _aprilMinRange; }
            set { _aprilMinRange = value; }
        }

        private Nullable<Int16> _aprilMaxRange;

        /// <summary>
        /// A search property representation of the AprilMaxRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> AprilMaxRange
        {
            get { return _aprilMaxRange; }
            set { _aprilMaxRange = value; }
        }

        private IList<Nullable<Int16>> _aprilIsIn;

        /// <summary>
        /// A search property representation of the AprilIsIn field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> AprilIsIn
        {
            get
            {
                if (_aprilIsIn == null)
                {
                    _aprilIsIn = new List<Nullable<Int16>>();
                }
                return _aprilIsIn;
            }
            set { _aprilIsIn = value; }
        }

        private Nullable<Int16> _mayMinRange;

        /// <summary>
        /// A search property representation of the MayMinRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> MayMinRange
        {
            get { return _mayMinRange; }
            set { _mayMinRange = value; }
        }

        private Nullable<Int16> _mayMaxRange;

        /// <summary>
        /// A search property representation of the MayMaxRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> MayMaxRange
        {
            get { return _mayMaxRange; }
            set { _mayMaxRange = value; }
        }

        private IList<Nullable<Int16>> _mayIsIn;

        /// <summary>
        /// A search property representation of the MayIsIn field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> MayIsIn
        {
            get
            {
                if (_mayIsIn == null)
                {
                    _mayIsIn = new List<Nullable<Int16>>();
                }
                return _mayIsIn;
            }
            set { _mayIsIn = value; }
        }

        private Nullable<Int16> _juneMinRange;

        /// <summary>
        /// A search property representation of the JuneMinRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> JuneMinRange
        {
            get { return _juneMinRange; }
            set { _juneMinRange = value; }
        }

        private Nullable<Int16> _juneMaxRange;

        /// <summary>
        /// A search property representation of the JuneMaxRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> JuneMaxRange
        {
            get { return _juneMaxRange; }
            set { _juneMaxRange = value; }
        }

        private IList<Nullable<Int16>> _juneIsIn;

        /// <summary>
        /// A search property representation of the JuneIsIn field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> JuneIsIn
        {
            get
            {
                if (_juneIsIn == null)
                {
                    _juneIsIn = new List<Nullable<Int16>>();
                }
                return _juneIsIn;
            }
            set { _juneIsIn = value; }
        }

        private Nullable<Int16> _julyMinRange;

        /// <summary>
        /// A search property representation of the JulyMinRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> JulyMinRange
        {
            get { return _julyMinRange; }
            set { _julyMinRange = value; }
        }

        private Nullable<Int16> _julyMaxRange;

        /// <summary>
        /// A search property representation of the JulyMaxRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> JulyMaxRange
        {
            get { return _julyMaxRange; }
            set { _julyMaxRange = value; }
        }

        private IList<Nullable<Int16>> _julyIsIn;

        /// <summary>
        /// A search property representation of the JulyIsIn field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> JulyIsIn
        {
            get
            {
                if (_julyIsIn == null)
                {
                    _julyIsIn = new List<Nullable<Int16>>();
                }
                return _julyIsIn;
            }
            set { _julyIsIn = value; }
        }

        private Nullable<Int16> _augustMinRange;

        /// <summary>
        /// A search property representation of the AugustMinRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> AugustMinRange
        {
            get { return _augustMinRange; }
            set { _augustMinRange = value; }
        }

        private Nullable<Int16> _augustMaxRange;

        /// <summary>
        /// A search property representation of the AugustMaxRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> AugustMaxRange
        {
            get { return _augustMaxRange; }
            set { _augustMaxRange = value; }
        }

        private IList<Nullable<Int16>> _augustIsIn;

        /// <summary>
        /// A search property representation of the AugustIsIn field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> AugustIsIn
        {
            get
            {
                if (_augustIsIn == null)
                {
                    _augustIsIn = new List<Nullable<Int16>>();
                }
                return _augustIsIn;
            }
            set { _augustIsIn = value; }
        }

        private Nullable<Int16> _septemberMinRange;

        /// <summary>
        /// A search property representation of the SeptemberMinRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> SeptemberMinRange
        {
            get { return _septemberMinRange; }
            set { _septemberMinRange = value; }
        }

        private Nullable<Int16> _septemberMaxRange;

        /// <summary>
        /// A search property representation of the SeptemberMaxRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> SeptemberMaxRange
        {
            get { return _septemberMaxRange; }
            set { _septemberMaxRange = value; }
        }

        private IList<Nullable<Int16>> _septemberIsIn;

        /// <summary>
        /// A search property representation of the SeptemberIsIn field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> SeptemberIsIn
        {
            get
            {
                if (_septemberIsIn == null)
                {
                    _septemberIsIn = new List<Nullable<Int16>>();
                }
                return _septemberIsIn;
            }
            set { _septemberIsIn = value; }
        }

        private Nullable<Int16> _octoberMinRange;

        /// <summary>
        /// A search property representation of the OctoberMinRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> OctoberMinRange
        {
            get { return _octoberMinRange; }
            set { _octoberMinRange = value; }
        }

        private Nullable<Int16> _octoberMaxRange;

        /// <summary>
        /// A search property representation of the OctoberMaxRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> OctoberMaxRange
        {
            get { return _octoberMaxRange; }
            set { _octoberMaxRange = value; }
        }

        private IList<Nullable<Int16>> _octoberIsIn;

        /// <summary>
        /// A search property representation of the OctoberIsIn field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> OctoberIsIn
        {
            get
            {
                if (_octoberIsIn == null)
                {
                    _octoberIsIn = new List<Nullable<Int16>>();
                }
                return _octoberIsIn;
            }
            set { _octoberIsIn = value; }
        }

        private Nullable<Int16> _novemberMinRange;

        /// <summary>
        /// A search property representation of the NovemberMinRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> NovemberMinRange
        {
            get { return _novemberMinRange; }
            set { _novemberMinRange = value; }
        }

        private Nullable<Int16> _novemberMaxRange;

        /// <summary>
        /// A search property representation of the NovemberMaxRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> NovemberMaxRange
        {
            get { return _novemberMaxRange; }
            set { _novemberMaxRange = value; }
        }

        private IList<Nullable<Int16>> _novemberIsIn;

        /// <summary>
        /// A search property representation of the NovemberIsIn field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> NovemberIsIn
        {
            get
            {
                if (_novemberIsIn == null)
                {
                    _novemberIsIn = new List<Nullable<Int16>>();
                }
                return _novemberIsIn;
            }
            set { _novemberIsIn = value; }
        }

        private Nullable<Int16> _decemberMinRange;

        /// <summary>
        /// A search property representation of the DecemberMinRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> DecemberMinRange
        {
            get { return _decemberMinRange; }
            set { _decemberMinRange = value; }
        }

        private Nullable<Int16> _decemberMaxRange;

        /// <summary>
        /// A search property representation of the DecemberMaxRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> DecemberMaxRange
        {
            get { return _decemberMaxRange; }
            set { _decemberMaxRange = value; }
        }

        private IList<Nullable<Int16>> _decemberIsIn;

        /// <summary>
        /// A search property representation of the DecemberIsIn field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> DecemberIsIn
        {
            get
            {
                if (_decemberIsIn == null)
                {
                    _decemberIsIn = new List<Nullable<Int16>>();
                }
                return _decemberIsIn;
            }
            set { _decemberIsIn = value; }
        }

        private Nullable<Int16> _supportMinRange;

        /// <summary>
        /// A search property representation of the SupportMinRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> SupportMinRange
        {
            get { return _supportMinRange; }
            set { _supportMinRange = value; }
        }

        private Nullable<Int16> _supportMaxRange;

        /// <summary>
        /// A search property representation of the SupportMaxRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> SupportMaxRange
        {
            get { return _supportMaxRange; }
            set { _supportMaxRange = value; }
        }

        private IList<Nullable<Int16>> _supportIsIn;

        /// <summary>
        /// A search property representation of the SupportIsIn field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> SupportIsIn
        {
            get
            {
                if (_supportIsIn == null)
                {
                    _supportIsIn = new List<Nullable<Int16>>();
                }
                return _supportIsIn;
            }
            set { _supportIsIn = value; }
        }

        private Nullable<Int16> _setbackMinRange;

        /// <summary>
        /// A search property representation of the SetbackMinRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> SetbackMinRange
        {
            get { return _setbackMinRange; }
            set { _setbackMinRange = value; }
        }

        private Nullable<Int16> _setbackMaxRange;

        /// <summary>
        /// A search property representation of the SetbackMaxRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> SetbackMaxRange
        {
            get { return _setbackMaxRange; }
            set { _setbackMaxRange = value; }
        }

        private IList<Nullable<Int16>> _setbackIsIn;

        /// <summary>
        /// A search property representation of the SetbackIsIn field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> SetbackIsIn
        {
            get
            {
                if (_setbackIsIn == null)
                {
                    _setbackIsIn = new List<Nullable<Int16>>();
                }
                return _setbackIsIn;
            }
            set { _setbackIsIn = value; }
        }

        private Nullable<Int16> _testMinRange;

        /// <summary>
        /// A search property representation of the TestMinRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> TestMinRange
        {
            get { return _testMinRange; }
            set { _testMinRange = value; }
        }

        private Nullable<Int16> _testMaxRange;

        /// <summary>
        /// A search property representation of the TestMaxRange field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> TestMaxRange
        {
            get { return _testMaxRange; }
            set { _testMaxRange = value; }
        }

        private IList<Nullable<Int16>> _testIsIn;

        /// <summary>
        /// A search property representation of the TestIsIn field for a record in the dbo.HistoricalPercent data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> TestIsIn
        {
            get
            {
                if (_testIsIn == null)
                {
                    _testIsIn = new List<Nullable<Int16>>();
                }
                return _testIsIn;
            }
            set { _testIsIn = value; }
        }

    }

    [Serializable]
    public partial class HistoricalPercentExtended : EntityExtendedBase
    {
        internal HistoricalPercentExtended() { }
    }
}