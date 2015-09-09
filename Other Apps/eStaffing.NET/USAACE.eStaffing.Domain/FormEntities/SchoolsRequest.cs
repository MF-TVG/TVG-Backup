using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.FormEntities
{
    [Serializable]
    public class SchoolsRequest : FormEntityBase
    {
        private String _title;

        /// <summary>
        /// A property representation of the Title field for a record in the dbo.SchoolsRequest data table. 
        /// </summary>
        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private String _requestType;

        /// <summary>
        /// A property representation of the RequestType field for a record in the dbo.SchoolsRequest data table. 
        /// </summary>
        public String RequestType
        {
            get { return _requestType; }
            set { _requestType = value; }
        }

        private String _who;

        /// <summary>
        /// A property representation of the Who field for a record in the dbo.SchoolsRequest data table. 
        /// </summary>
        public String Who
        {
            get { return _who; }
            set { _who = value; }
        }

        private Nullable<Int16> _apftScore;

        /// <summary>
        /// A property representation of the APFTScore field for a record in the dbo.SchoolsRequest data table. 
        /// </summary>
        public Nullable<Int16> APFTScore
        {
            get { return _apftScore; }
            set { _apftScore = value; }
        }

        private Nullable<Boolean> _apftPass;

        /// <summary>
        /// A property representation of the APFTPass field for a record in the dbo.SchoolsRequest data table. 
        /// </summary>
        public Nullable<Boolean> APFTPass
        {
            get { return _apftPass; }
            set { _apftPass = value; }
        }

        private Nullable<Byte> _bodyFatPercent;

        /// <summary>
        /// A property representation of the BodyFatPercent field for a record in the dbo.SchoolsRequest data table. 
        /// </summary>
        public Nullable<Byte> BodyFatPercent
        {
            get { return _bodyFatPercent; }
            set { _bodyFatPercent = value; }
        }

        private String _ssdLevel;

        /// <summary>
        /// A property representation of the SSDLevel field for a record in the dbo.SchoolsRequest data table. 
        /// </summary>
        public String SSDLevel
        {
            get { return _ssdLevel; }
            set { _ssdLevel = value; }
        }

        private String _what;

        /// <summary>
        /// A property representation of the What field for a record in the dbo.SchoolsRequest data table. 
        /// </summary>
        public String What
        {
            get { return _what; }
            set { _what = value; }
        }

        private String _when;

        /// <summary>
        /// A property representation of the When field for a record in the dbo.SchoolsRequest data table. 
        /// </summary>
        public String When
        {
            get { return _when; }
            set { _when = value; }
        }

        private String _where;

        /// <summary>
        /// A property representation of the Where field for a record in the dbo.SchoolsRequest data table. 
        /// </summary>
        public String Where
        {
            get { return _where; }
            set { _where = value; }
        }

        private String _remarks;

        /// <summary>
        /// A property representation of the Remarks field for a record in the dbo.SchoolsRequest data table. 
        /// </summary>
        public String Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        private List<SchoolsRequestCheckItem> _schoolsRequestCheckItems;

        public List<SchoolsRequestCheckItem> SchoolsRequestCheckItems
        {
            get
            {
                if (_schoolsRequestCheckItems == null)
                {
                    _schoolsRequestCheckItems = new List<SchoolsRequestCheckItem>();
                }

                return _schoolsRequestCheckItems;
            }
            set
            {
                _schoolsRequestCheckItems = value;
            }
        }
    }

    [Serializable]
    public class SchoolsRequestCheckItem : FormSubEntityBase
    {
        private String _checklistItem;

        /// <summary>
        /// A property representation of the ChecklistItem field for a record in the dbo.SchoolsRequestCheckItem data table. 
        /// </summary>
        public String ChecklistItem
        {
            get { return _checklistItem; }
            set { _checklistItem = value; }
        }
    }
}
