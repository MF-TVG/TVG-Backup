using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.FormAttachmentData data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class FormAttachmentData : EntityBase
    {
        private FormAttachmentDataSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public FormAttachmentDataSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new FormAttachmentDataSearch();
                }

                return _searchProperties;
            }
        }

        private FormAttachmentDataExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public FormAttachmentDataExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new FormAttachmentDataExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _formAttachmentDataID;

        /// <summary>
        /// A property representation of the FormAttachmentDataID field for a record in the dbo.FormAttachmentData data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> FormAttachmentDataID
        {
            get { return _formAttachmentDataID; }
            set { _formAttachmentDataID = value; }
        }

        private Nullable<Int32> _formAttachmentID;

        /// <summary>
        /// A property representation of the FormAttachmentID field for a record in the dbo.FormAttachmentData data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> FormAttachmentID
        {
            get { return _formAttachmentID; }
            set { _formAttachmentID = value; }
        }

        private Byte[] _fileContent;

        /// <summary>
        /// A property representation of the FileContent field for a record in the dbo.FormAttachmentData data table. 
        /// </summary>
        [EntityProperty()]
        public Byte[] FileContent
        {
            get { return _fileContent; }
            set { _fileContent = value; }
        }

    }

    [Serializable]
    public class FormAttachmentDataSearch : EntitySearchBase
    {
        internal FormAttachmentDataSearch() { }

        private Nullable<Int32> _formAttachmentIDMinRange;

        /// <summary>
        /// A search property representation of the FormAttachmentIDMinRange field for a record in the dbo.FormAttachmentData data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormAttachmentIDMinRange
        {
            get { return _formAttachmentIDMinRange; }
            set { _formAttachmentIDMinRange = value; }
        }

        private Nullable<Int32> _formAttachmentIDMaxRange;

        /// <summary>
        /// A search property representation of the FormAttachmentIDMaxRange field for a record in the dbo.FormAttachmentData data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormAttachmentIDMaxRange
        {
            get { return _formAttachmentIDMaxRange; }
            set { _formAttachmentIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _formAttachmentIDIsIn;

        /// <summary>
        /// A search property representation of the FormAttachmentIDIsIn field for a record in the dbo.FormAttachmentData data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> FormAttachmentIDIsIn
        {
            get
            {
                if (_formAttachmentIDIsIn == null)
                {
                    _formAttachmentIDIsIn = new List<Nullable<Int32>>();
                }
                return _formAttachmentIDIsIn;
            }
            set { _formAttachmentIDIsIn = value; }
        }

    }

    [Serializable]
    public partial class FormAttachmentDataExtended : EntityExtendedBase
    {
        internal FormAttachmentDataExtended() { }
    }
}