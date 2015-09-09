using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.FormAttachment data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class FormAttachment : EntityBase
    {
        private FormAttachmentSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public FormAttachmentSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new FormAttachmentSearch();
                }

                return _searchProperties;
            }
        }

        private FormAttachmentExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public FormAttachmentExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new FormAttachmentExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _formAttachmentID;

        /// <summary>
        /// A property representation of the FormAttachmentID field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> FormAttachmentID
        {
            get { return _formAttachmentID; }
            set { _formAttachmentID = value; }
        }

        private Nullable<Int32> _formID;

        /// <summary>
        /// A property representation of the FormID field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> FormID
        {
            get { return _formID; }
            set { _formID = value; }
        }

        private String _fileName;

        /// <summary>
        /// A property representation of the FileName field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(Size = 255)]
        public String FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        private Nullable<Int32> _fileSize;

        /// <summary>
        /// A property representation of the FileSize field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> FileSize
        {
            get { return _fileSize; }
            set { _fileSize = value; }
        }

        private Nullable<DateTime> _creationDate;

        /// <summary>
        /// A property representation of the CreationDate field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<DateTime> CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }

        private Nullable<DateTime> _lastModifiedDate;

        /// <summary>
        /// A property representation of the LastModifiedDate field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<DateTime> LastModifiedDate
        {
            get { return _lastModifiedDate; }
            set { _lastModifiedDate = value; }
        }

        private String _contentType;

        /// <summary>
        /// A property representation of the ContentType field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(Size = 255)]
        public String ContentType
        {
            get { return _contentType; }
            set { _contentType = value; }
        }

        private Nullable<Int32> _reviewStatusID;

        /// <summary>
        /// A property representation of the ReviewStatusID field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> ReviewStatusID
        {
            get { return _reviewStatusID; }
            set { _reviewStatusID = value; }
        }

    }

    [Serializable]
    public class FormAttachmentSearch : EntitySearchBase
    {
        internal FormAttachmentSearch() { }

        private Nullable<Int32> _formIDMinRange;

        /// <summary>
        /// A search property representation of the FormIDMinRange field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormIDMinRange
        {
            get { return _formIDMinRange; }
            set { _formIDMinRange = value; }
        }

        private Nullable<Int32> _formIDMaxRange;

        /// <summary>
        /// A search property representation of the FormIDMaxRange field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormIDMaxRange
        {
            get { return _formIDMaxRange; }
            set { _formIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _formIDIsIn;

        /// <summary>
        /// A search property representation of the FormIDIsIn field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> FormIDIsIn
        {
            get
            {
                if (_formIDIsIn == null)
                {
                    _formIDIsIn = new List<Nullable<Int32>>();
                }
                return _formIDIsIn;
            }
            set { _formIDIsIn = value; }
        }

        private String _fileNameContains;

        /// <summary>
        /// A search property representation of the FileNameContains field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(Size = 255, SearchOnly = true)]
        public String FileNameContains
        {
            get { return _fileNameContains; }
            set { _fileNameContains = value; }
        }

        private IList<String> _fileNameIsIn;

        /// <summary>
        /// A search property representation of the FileNameIsIn field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(Size = 255, SearchOnly = true)]
        public IList<String> FileNameIsIn
        {
            get
            {
                if (_fileNameIsIn == null)
                {
                    _fileNameIsIn = new List<String>();
                }
                return _fileNameIsIn;
            }
            set { _fileNameIsIn = value; }
        }

        private Nullable<Int32> _fileSizeMinRange;

        /// <summary>
        /// A search property representation of the FileSizeMinRange field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FileSizeMinRange
        {
            get { return _fileSizeMinRange; }
            set { _fileSizeMinRange = value; }
        }

        private Nullable<Int32> _fileSizeMaxRange;

        /// <summary>
        /// A search property representation of the FileSizeMaxRange field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FileSizeMaxRange
        {
            get { return _fileSizeMaxRange; }
            set { _fileSizeMaxRange = value; }
        }

        private IList<Nullable<Int32>> _fileSizeIsIn;

        /// <summary>
        /// A search property representation of the FileSizeIsIn field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> FileSizeIsIn
        {
            get
            {
                if (_fileSizeIsIn == null)
                {
                    _fileSizeIsIn = new List<Nullable<Int32>>();
                }
                return _fileSizeIsIn;
            }
            set { _fileSizeIsIn = value; }
        }

        private Nullable<DateTime> _creationDateMinRange;

        /// <summary>
        /// A search property representation of the CreationDateMinRange field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> CreationDateMinRange
        {
            get { return _creationDateMinRange; }
            set { _creationDateMinRange = value; }
        }

        private Nullable<DateTime> _creationDateMaxRange;

        /// <summary>
        /// A search property representation of the CreationDateMaxRange field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> CreationDateMaxRange
        {
            get { return _creationDateMaxRange; }
            set { _creationDateMaxRange = value; }
        }

        private IList<Nullable<DateTime>> _creationDateIsIn;

        /// <summary>
        /// A search property representation of the CreationDateIsIn field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<Nullable<DateTime>> CreationDateIsIn
        {
            get
            {
                if (_creationDateIsIn == null)
                {
                    _creationDateIsIn = new List<Nullable<DateTime>>();
                }
                return _creationDateIsIn;
            }
            set { _creationDateIsIn = value; }
        }

        private Nullable<DateTime> _lastModifiedDateMinRange;

        /// <summary>
        /// A search property representation of the LastModifiedDateMinRange field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> LastModifiedDateMinRange
        {
            get { return _lastModifiedDateMinRange; }
            set { _lastModifiedDateMinRange = value; }
        }

        private Nullable<DateTime> _lastModifiedDateMaxRange;

        /// <summary>
        /// A search property representation of the LastModifiedDateMaxRange field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> LastModifiedDateMaxRange
        {
            get { return _lastModifiedDateMaxRange; }
            set { _lastModifiedDateMaxRange = value; }
        }

        private IList<Nullable<DateTime>> _lastModifiedDateIsIn;

        /// <summary>
        /// A search property representation of the LastModifiedDateIsIn field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<Nullable<DateTime>> LastModifiedDateIsIn
        {
            get
            {
                if (_lastModifiedDateIsIn == null)
                {
                    _lastModifiedDateIsIn = new List<Nullable<DateTime>>();
                }
                return _lastModifiedDateIsIn;
            }
            set { _lastModifiedDateIsIn = value; }
        }

        private String _contentTypeContains;

        /// <summary>
        /// A search property representation of the ContentTypeContains field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(Size = 255, SearchOnly = true)]
        public String ContentTypeContains
        {
            get { return _contentTypeContains; }
            set { _contentTypeContains = value; }
        }

        private IList<String> _contentTypeIsIn;

        /// <summary>
        /// A search property representation of the ContentTypeIsIn field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(Size = 255, SearchOnly = true)]
        public IList<String> ContentTypeIsIn
        {
            get
            {
                if (_contentTypeIsIn == null)
                {
                    _contentTypeIsIn = new List<String>();
                }
                return _contentTypeIsIn;
            }
            set { _contentTypeIsIn = value; }
        }

        private Nullable<Int32> _reviewStatusIDMinRange;

        /// <summary>
        /// A search property representation of the ReviewStatusIDMinRange field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ReviewStatusIDMinRange
        {
            get { return _reviewStatusIDMinRange; }
            set { _reviewStatusIDMinRange = value; }
        }

        private Nullable<Int32> _reviewStatusIDMaxRange;

        /// <summary>
        /// A search property representation of the ReviewStatusIDMaxRange field for a record in the dbo.FormAttachment data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ReviewStatusIDMaxRange
        {
            get { return _reviewStatusIDMaxRange; }
            set { _reviewStatusIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _reviewStatusIDIsIn;

        /// <summary>
        /// A search property representation of the ReviewStatusIDIsIn field for a record in the dbo.FormAttachment data table. 
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

    }

    [Serializable]
    public partial class FormAttachmentExtended : EntityExtendedBase
    {
        internal FormAttachmentExtended() { }
    }
}