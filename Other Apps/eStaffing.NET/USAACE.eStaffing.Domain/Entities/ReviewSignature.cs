using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.ReviewSignature data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class ReviewSignature : EntityBase
    {
        private ReviewSignatureSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public ReviewSignatureSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new ReviewSignatureSearch();
                }

                return _searchProperties;
            }
        }

        private ReviewSignatureExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public ReviewSignatureExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new ReviewSignatureExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _reviewSignatureID;

        /// <summary>
        /// A property representation of the ReviewSignatureID field for a record in the dbo.ReviewSignature data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> ReviewSignatureID
        {
            get { return _reviewSignatureID; }
            set { _reviewSignatureID = value; }
        }

        private Nullable<Int32> _reviewStatusID;

        /// <summary>
        /// A property representation of the ReviewStatusID field for a record in the dbo.ReviewSignature data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> ReviewStatusID
        {
            get { return _reviewStatusID; }
            set { _reviewStatusID = value; }
        }

        private String _signatureData;

        /// <summary>
        /// A property representation of the SignatureData field for a record in the dbo.ReviewSignature data table. 
        /// </summary>
        [EntityProperty()]
        public String SignatureData
        {
            get { return _signatureData; }
            set { _signatureData = value; }
        }

    }

    [Serializable]
    public class ReviewSignatureSearch : EntitySearchBase
    {
        internal ReviewSignatureSearch() { }

        private Nullable<Int32> _reviewStatusIDMinRange;

        /// <summary>
        /// A search property representation of the ReviewStatusIDMinRange field for a record in the dbo.ReviewSignature data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ReviewStatusIDMinRange
        {
            get { return _reviewStatusIDMinRange; }
            set { _reviewStatusIDMinRange = value; }
        }

        private Nullable<Int32> _reviewStatusIDMaxRange;

        /// <summary>
        /// A search property representation of the ReviewStatusIDMaxRange field for a record in the dbo.ReviewSignature data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ReviewStatusIDMaxRange
        {
            get { return _reviewStatusIDMaxRange; }
            set { _reviewStatusIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _reviewStatusIDIsIn;

        /// <summary>
        /// A search property representation of the ReviewStatusIDIsIn field for a record in the dbo.ReviewSignature data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> ReviewStatusIDIsIn
        {
            get
            {
                if (_reviewStatusIDIsIn == null)
                {
                    _reviewStatusIDIsIn = new List<Nullable<Int32>>();
                }
                return _reviewStatusIDIsIn;
            }
            set { _reviewStatusIDIsIn = value; }
        }

        private String _signatureDataContains;

        /// <summary>
        /// A search property representation of the SignatureDataContains field for a record in the dbo.ReviewSignature data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public String SignatureDataContains
        {
            get { return _signatureDataContains; }
            set { _signatureDataContains = value; }
        }

        private IList<String> _signatureDataIsIn;

        /// <summary>
        /// A search property representation of the SignatureDataIsIn field for a record in the dbo.ReviewSignature data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<String> SignatureDataIsIn
        {
            get
            {
                if (_signatureDataIsIn == null)
                {
                    _signatureDataIsIn = new List<String>();
                }
                return _signatureDataIsIn;
            }
            set { _signatureDataIsIn = value; }
        }

    }

    [Serializable]
    public partial class ReviewSignatureExtended : EntityExtendedBase
    {
        internal ReviewSignatureExtended() { }
    }
}