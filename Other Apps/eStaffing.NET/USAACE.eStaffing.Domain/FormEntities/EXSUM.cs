using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.FormEntities
{
    [Serializable]
    public class EXSUM : FormEntityBase
    {
        private Nullable<DateTime> _eXSUMDate;

        /// <summary>
        /// A property representation of the EXSUMDate field for a record in the dbo.EXSUM data table. 
        /// </summary>
        public Nullable<DateTime> EXSUMDate
        {
            get { return _eXSUMDate; }
            set { _eXSUMDate = value; }
        }

        private String _eXSUMTitle;

        /// <summary>
        /// A property representation of the EXSUMTitle field for a record in the dbo.EXSUM data table. 
        /// </summary>
        public String EXSUMTitle
        {
            get { return _eXSUMTitle; }
            set { _eXSUMTitle = value; }
        }

        private String _issues;

        /// <summary>
        /// A property representation of the Issues field for a record in the dbo.EXSUM data table. 
        /// </summary>
        public String Issues
        {
            get { return _issues; }
            set { _issues = value; }
        }

        private String _currentStatus;

        /// <summary>
        /// A property representation of the CurrentStatus field for a record in the dbo.EXSUM data table. 
        /// </summary>
        public String CurrentStatus
        {
            get { return _currentStatus; }
            set { _currentStatus = value; }
        }

        private String _futureStatus;

        /// <summary>
        /// A property representation of the FutureStatus field for a record in the dbo.EXSUM data table. 
        /// </summary>
        public String FutureStatus
        {
            get { return _futureStatus; }
            set { _futureStatus = value; }
        }

        private String _pointOfContact;

        /// <summary>
        /// A property representation of the PointOfContact field for a record in the dbo.EXSUM data table. 
        /// </summary>
        public String PointOfContact
        {
            get { return _pointOfContact; }
            set { _pointOfContact = value; }
        }

        private String _additionalInfo;

        /// <summary>
        /// A property representation of the AdditionalInfo field for a record in the dbo.EXSUM data table. 
        /// </summary>
        public String AdditionalInfo
        {
            get { return _additionalInfo; }
            set { _additionalInfo = value; }
        }
    }
}
