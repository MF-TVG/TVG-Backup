using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.FormEntities
{
    [Serializable]
    public class Tasking : FormEntityBase
    {
        private String _taskNumber;

        /// <summary>
        /// A property representation of the TaskNumber field for a record in the dbo.Tasking data table. 
        /// </summary>
        public String TaskNumber
        {
            get { return _taskNumber; }
            set { _taskNumber = value; }
        }

        private String _eccNumber;

        /// <summary>
        /// A property representation of the ECCNumber field for a record in the dbo.Tasking data table. 
        /// </summary>
        public String ECCNumber
        {
            get { return _eccNumber; }
            set { _eccNumber = value; }
        }

        private String _taskingType;

        /// <summary>
        /// A property representation of the TaskingTypeID field for a record in the dbo.Tasking data table. 
        /// </summary>
        public String TaskingType
        {
            get { return _taskingType; }
            set { _taskingType = value; }
        }

        private String _taskingSource;

        /// <summary>
        /// A property representation of the TaskingSourceID field for a record in the dbo.Tasking data table. 
        /// </summary>
        public String TaskingSource
        {
            get { return _taskingSource; }
            set { _taskingSource = value; }
        }

        private String _sourcePOC;

        /// <summary>
        /// A property representation of the SourcePOC field for a record in the dbo.Tasking data table. 
        /// </summary>
        public String SourcePOC
        {
            get { return _sourcePOC; }
            set { _sourcePOC = value; }
        }

        private String _subject;

        /// <summary>
        /// A property representation of the Subject field for a record in the dbo.Tasking data table. 
        /// </summary>
        public String Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        private String _actionOfficer;

        /// <summary>
        /// A property representation of the ActionOfficer field for a record in the dbo.Tasking data table. 
        /// </summary>
        public String ActionOfficer
        {
            get { return _actionOfficer; }
            set { _actionOfficer = value; }
        }

        private String _phoneNumber;

        /// <summary>
        /// A property representation of the PhoneNumber field for a record in the dbo.Tasking data table. 
        /// </summary>
        public String PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        private String _officeSymbol;

        /// <summary>
        /// A property representation of the OfficeSymbol field for a record in the dbo.Tasking data table. 
        /// </summary>
        public String OfficeSymbol
        {
            get { return _officeSymbol; }
            set { _officeSymbol = value; }
        }

        private Nullable<DateTime> _suspenseDate;

        /// <summary>
        /// A property representation of the SuspenseDate field for a record in the dbo.Tasking data table. 
        /// </summary>
        public Nullable<DateTime> SuspenseDate
        {
            get { return _suspenseDate; }
            set { _suspenseDate = value; }
        }

        private Nullable<DateTime> _taskDate;

        /// <summary>
        /// A property representation of the TaskDate field for a record in the dbo.Tasking data table. 
        /// </summary>
        public Nullable<DateTime> TaskDate
        {
            get { return _taskDate; }
            set { _taskDate = value; }
        }

        private String _documentType;

        /// <summary>
        /// A property representation of the DocumentType field for a record in the dbo.Tasking data table. 
        /// </summary>
        public String DocumentType
        {
            get { return _documentType; }
            set { _documentType = value; }
        }

        private String _task5W;

        /// <summary>
        /// A property representation of the TaskWhatWhyHow field for a record in the dbo.Tasking data table. 
        /// </summary>
        public String Task5W
        {
            get { return _task5W; }
            set { _task5W = value; }
        }

        private String _actionRequired;

        /// <summary>
        /// A property representation of the ActionRequired field for a record in the dbo.Tasking data table. 
        /// </summary>
        public String ActionRequired
        {
            get { return _actionRequired; }
            set { _actionRequired = value; }
        }

        private String _securityLevel;

        /// <summary>
        /// A property representation of the SecurityLevel field for a record in the dbo.Tasking data table. 
        /// </summary>
        public String SecurityLevel
        {
            get { return _securityLevel; }
            set { _securityLevel = value; }
        }

        private String _taskInstructions;

        /// <summary>
        /// A property representation of the TaskInstructions field for a record in the dbo.Tasking data table. 
        /// </summary>
        public String TaskInstructions
        {
            get { return _taskInstructions; }
            set { _taskInstructions = value; }
        }

        private String _taskPOC;

        /// <summary>
        /// A property representation of the TaskPOC field for a record in the dbo.Tasking data table. 
        /// </summary>
        public String TaskPOC
        {
            get { return _taskPOC; }
            set { _taskPOC = value; }
        }

        private String _location;

        /// <summary>
        /// A property representation of the ActionRequired field for a record in the dbo.Tasking data table. 
        /// </summary>
        public String Location
        {
            get { return _location; }
            set { _location = value; }
        }

        private String _taskNotes;

        /// <summary>
        /// A property representation of the TaskNotes field for a record in the dbo.Tasking data table. 
        /// </summary>
        public String TaskNotes
        {
            get { return _taskNotes; }
            set { _taskNotes = value; }
        }
    }
}
