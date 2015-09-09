using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.FormEntities
{
    [Serializable]
    public class Form2028 : FormEntityBase
    {
        private String _form2028Type;

        /// <summary>
        /// A property representation of the Form2028Type field for a record in the dbo.Form2028 data table. 
        /// </summary>
        public String Form2028Type
        {
            get { return _form2028Type; }
            set { _form2028Type = value; }
        }

        private String _lessonId;

        /// <summary>
        /// A property representation of the LessonID field for a record in the dbo.Form2028 data table. 
        /// </summary>
        public String LessonID
        {
            get { return _lessonId; }
            set { _lessonId = value; }
        }

        private String _lessonVersion;

        /// <summary>
        /// A property representation of the LessonVersion field for a record in the dbo.Form2028 data table. 
        /// </summary>
        public String LessonVersion
        {
            get { return _lessonVersion; }
            set { _lessonVersion = value; }
        }

        private String _courseType;

        /// <summary>
        /// A property representation of the CourseNumber field for a record in the dbo.Form2028 data table. 
        /// </summary>
        public String CourseType
        {
            get { return _courseType; }
            set { _courseType = value; }
        }

        private String _courseNumber;

        /// <summary>
        /// A property representation of the CourseNumber field for a record in the dbo.Form2028 data table. 
        /// </summary>
        public String CourseNumber
        {
            get { return _courseNumber; }
            set { _courseNumber = value; }
        }

        private String _remarks;

        /// <summary>
        /// A property representation of the Remarks field for a record in the dbo.Form2028 data table. 
        /// </summary>
        public String Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        private String _phoneNumber;

        /// <summary>
        /// A property representation of the PhoneNumber field for a record in the dbo.Form2028 data table. 
        /// </summary>
        public String PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        private String _submitterName;

        /// <summary>
        /// A property representation of the SubmitterName field for a record in the dbo.Form2028 data table. 
        /// </summary>
        public String SubmitterName
        {
            get { return _submitterName; }
            set { _submitterName = value; }
        }

        private List<PublicationChange> _publicationChanges;

        public List<PublicationChange> PublicationChanges
        {
            get
            {
                if (_publicationChanges == null)
                {
                    _publicationChanges = new List<PublicationChange>();
                }

                return _publicationChanges;
            }
            set
            {
                _publicationChanges = value;
            }
        }

        private List<RepairPartChange> _repairPartChanges;

        public List<RepairPartChange> RepairPartChanges
        {
            get
            {
                if (_repairPartChanges == null)
                {
                    _repairPartChanges = new List<RepairPartChange>();
                }

                return _repairPartChanges;
            }
            set
            {
                _repairPartChanges = value;
            }
        }
    }

    [Serializable]
    public class PublicationChange : FormSubEntityBase
    {
        private String _pageNumber;

        /// <summary>
        /// A property representation of the PageNumber field for a record in the dbo.PublicationChange data table. 
        /// </summary>
        public String PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; }
        }

        private String _paragraph;

        /// <summary>
        /// A property representation of the Paragraph field for a record in the dbo.PublicationChange data table. 
        /// </summary>
        public String Paragraph
        {
            get { return _paragraph; }
            set { _paragraph = value; }
        }

        private String _lineNumber;

        /// <summary>
        /// A property representation of the LineNumber field for a record in the dbo.PublicationChange data table. 
        /// </summary>
        public String LineNumber
        {
            get { return _lineNumber; }
            set { _lineNumber = value; }
        }

        private String _figureNumber;

        /// <summary>
        /// A property representation of the FigureNumber field for a record in the dbo.PublicationChange data table. 
        /// </summary>
        public String FigureNumber
        {
            get { return _figureNumber; }
            set { _figureNumber = value; }
        }

        private String _tableNumber;

        /// <summary>
        /// A property representation of the TableNumber field for a record in the dbo.PublicationChange data table. 
        /// </summary>
        public String TableNumber
        {
            get { return _tableNumber; }
            set { _tableNumber = value; }
        }

        private String _recommendedChanges;

        /// <summary>
        /// A property representation of the RecommendedChanges field for a record in the dbo.PublicationChange data table. 
        /// </summary>
        public String RecommendedChanges
        {
            get { return _recommendedChanges; }
            set { _recommendedChanges = value; }
        }
    }

    [Serializable]
    public class RepairPartChange : FormSubEntityBase
    {
        private String _pageNumber;

        /// <summary>
        /// A property representation of the PageNumber field for a record in the dbo.RepairPartChange data table. 
        /// </summary>
        public String PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; }
        }

        private String _columnNumber;

        /// <summary>
        /// A property representation of the ColumnNumber field for a record in the dbo.RepairPartChange data table. 
        /// </summary>
        public String ColumnNumber
        {
            get { return _columnNumber; }
            set { _columnNumber = value; }
        }

        private String _lineNumber;

        /// <summary>
        /// A property representation of the LineNumber field for a record in the dbo.RepairPartChange data table. 
        /// </summary>
        public String LineNumber
        {
            get { return _lineNumber; }
            set { _lineNumber = value; }
        }

        private String _nationalStockNumber;

        /// <summary>
        /// A property representation of the NationalStockNumber field for a record in the dbo.RepairPartChange data table. 
        /// </summary>
        public String NationalStockNumber
        {
            get { return _nationalStockNumber; }
            set { _nationalStockNumber = value; }
        }

        private String _referenceNumber;

        /// <summary>
        /// A property representation of the FigureNumber field for a record in the dbo.RepairPartChange data table. 
        /// </summary>
        public String ReferenceNumber
        {
            get { return _referenceNumber; }
            set { _referenceNumber = value; }
        }

        private String _figureNumber;

        /// <summary>
        /// A property representation of the FigureNumber field for a record in the dbo.RepairPartChange data table. 
        /// </summary>
        public String FigureNumber
        {
            get { return _figureNumber; }
            set { _figureNumber = value; }
        }

        private String _itemNumber;

        /// <summary>
        /// A property representation of the ItemNumber field for a record in the dbo.RepairPartChange data table. 
        /// </summary>
        public String ItemNumber
        {
            get { return _itemNumber; }
            set { _itemNumber = value; }
        }

        private String _itemCount;

        /// <summary>
        /// A property representation of the ItemCount field for a record in the dbo.RepairPartChange data table. 
        /// </summary>
        public String ItemCount
        {
            get { return _itemCount; }
            set { _itemCount = value; }
        }

        private String _recommendedChanges;

        /// <summary>
        /// A property representation of the RecommendedChanges field for a record in the dbo.RepairPartChange data table. 
        /// </summary>
        public String RecommendedChanges
        {
            get { return _recommendedChanges; }
            set { _recommendedChanges = value; }
        }
    }
}
