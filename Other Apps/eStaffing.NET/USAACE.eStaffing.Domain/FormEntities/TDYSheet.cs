using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace USAACE.eStaffing.Domain.FormEntities
{
    [Serializable]
    public class TDYSheet : FormEntityBase
    {
        private String _actionOffice;

        /// <summary>
        /// A property representation of the ActionOffice field for a record in the dbo.TDYSheet data table. 
        /// </summary>
        public String ActionOffice
        {
            get { return _actionOffice; }
            set { _actionOffice = value; }
        }

        private String _phoneNumber;

        /// <summary>
        /// A property representation of the PhoneNumber field for a record in the dbo.TDYSheet data table. 
        /// </summary>
        public String PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        private Nullable<DateTime> _suspenseDate;

        /// <summary>
        /// A property representation of the SuspenseDate field for a record in the dbo.TDYSheet data table. 
        /// </summary>
        public Nullable<DateTime> SuspenseDate
        {
            get { return _suspenseDate; }
            set { _suspenseDate = value; }
        }

        private Nullable<DateTime> _transmittalDate;

        /// <summary>
        /// A property representation of the TransmittalDate field for a record in the dbo.TDYSheet data table. 
        /// </summary>
        public Nullable<DateTime> TransmittalDate
        {
            get { return _transmittalDate; }
            set { _transmittalDate = value; }
        }

        private String _subject;

        /// <summary>
        /// A property representation of the Subject field for a record in the dbo.TDYSheet data table. 
        /// </summary>
        public String Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        private String _actionOfficer;

        /// <summary>
        /// A property representation of the ActionOfficer field for a record in the dbo.TDYSheet data table. 
        /// </summary>
        public String ActionOfficer
        {
            get { return _actionOfficer; }
            set { _actionOfficer = value; }
        }

        private Nullable<Boolean> _signature;

        /// <summary>
        /// A property representation of the Signature field for a record in the dbo.TDYSheet data table. 
        /// </summary>
        public Nullable<Boolean> Signature
        {
            get { return _signature; }
            set { _signature = value; }
        }

        private Nullable<Boolean> _approval;

        /// <summary>
        /// A property representation of the Approval field for a record in the dbo.TDYSheet data table. 
        /// </summary>
        public Nullable<Boolean> Approval
        {
            get { return _approval; }
            set { _approval = value; }
        }

        private Nullable<Boolean> _information;

        /// <summary>
        /// A property representation of the Information field for a record in the dbo.TDYSheet data table. 
        /// </summary>
        public Nullable<Boolean> Information
        {
            get { return _information; }
            set { _information = value; }
        }

        private Nullable<Boolean> _readAhead;

        /// <summary>
        /// A property representation of the ReadAhead field for a record in the dbo.TDYSheet data table. 
        /// </summary>
        public Nullable<Boolean> ReadAhead
        {
            get { return _readAhead; }
            set { _readAhead = value; }
        }

        private String _missionEssential;

        /// <summary>
        /// A property representation of the MissionEssential field for a record in the dbo.TDYSheet data table. 
        /// </summary>
        public String MissionEssential
        {
            get { return _missionEssential; }
            set { _missionEssential = value; }
        }

        private String _purpose;

        /// <summary>
        /// A property representation of the Purpose field for a record in the dbo.TDYSheet data table. 
        /// </summary>
        public String Purpose
        {
            get { return _purpose; }
            set { _purpose = value; }
        }

        private String _location;

        /// <summary>
        /// A property representation of the Location field for a record in the dbo.TDYSheet data table. 
        /// </summary>
        public String Location
        {
            get { return _location; }
            set { _location = value; }
        }

        private Nullable<DateTime> _startDate;

        /// <summary>
        /// A property representation of the StartDate field for a record in the dbo.TDYSheet data table. 
        /// </summary>
        public Nullable<DateTime> StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        private Nullable<DateTime> _endDate;

        /// <summary>
        /// A property representation of the EndDate field for a record in the dbo.TDYSheet data table. 
        /// </summary>
        public Nullable<DateTime> EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        private String _funding;

        /// <summary>
        /// A property representation of the Funding field for a record in the dbo.TDYSheet data table. 
        /// </summary>
        public String Funding
        {
            get { return _funding; }
            set { _funding = value; }
        }

        private String _summary;

        /// <summary>
        /// A property representation of the Summary field for a record in the dbo.TDYSheet data table. 
        /// </summary>
        public String Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }

        private List<TDYAttendee> _tdyAttendees;

        public List<TDYAttendee> TDYAttendees
        {
            get
            {
                if (_tdyAttendees == null)
                {
                    _tdyAttendees = new List<TDYAttendee>();
                }

                return _tdyAttendees;
            }
            set
            {
                _tdyAttendees = value;
            }
        }
    }

    [Serializable]
    public class TDYAttendee : FormSubEntityBase
    {
        private String _name;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.TDYAttendee data table. 
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private String _dutyPosition;

        /// <summary>
        /// A property representation of the DutyPosition field for a record in the dbo.TDYAttendee data table. 
        /// </summary>
        public String DutyPosition
        {
            get { return _dutyPosition; }
            set { _dutyPosition = value; }
        }

        private Nullable<Decimal> _perDiemCost;

        /// <summary>
        /// A property representation of the PerDiemCost field for a record in the dbo.TDYAttendee data table. 
        /// </summary>
        public Nullable<Decimal> PerDiemCost
        {
            get { return _perDiemCost; }
            set { _perDiemCost = value; }
        }

        private Nullable<Decimal> _lodgingCost;

        /// <summary>
        /// A property representation of the LodgingCost field for a record in the dbo.TDYAttendee data table. 
        /// </summary>
        public Nullable<Decimal> LodgingCost
        {
            get { return _lodgingCost; }
            set { _lodgingCost = value; }
        }

        private Nullable<Decimal> _travelCost;

        /// <summary>
        /// A property representation of the TravelCost field for a record in the dbo.TDYAttendee data table. 
        /// </summary>
        public Nullable<Decimal> TravelCost
        {
            get { return _travelCost; }
            set { _travelCost = value; }
        }

        private String _tDYTravelMode;

        /// <summary>
        /// A property representation of the TDYTravelModeID field for a record in the dbo.TDYAttendee data table. 
        /// </summary>
        public String TDYTravelMode
        {
            get { return _tDYTravelMode; }
            set { _tDYTravelMode = value; }
        }

        private Nullable<Decimal> _rentalCost;

        /// <summary>
        /// A property representation of the RentalCost field for a record in the dbo.TDYAttendee data table. 
        /// </summary>
        public Nullable<Decimal> RentalCost
        {
            get { return _rentalCost; }
            set { _rentalCost = value; }
        }

        private Nullable<Decimal> _otherCost;

        /// <summary>
        /// A property representation of the OtherCost field for a record in the dbo.TDYAttendee data table. 
        /// </summary>
        public Nullable<Decimal> OtherCost
        {
            get { return _otherCost; }
            set { _otherCost = value; }
        }

        private Nullable<Decimal> _totalCost;

        /// <summary>
        /// A property representation of the TotalCost field for a record in the dbo.TDYAttendee data table. 
        /// </summary>
        [XmlIgnore]
        public Nullable<Decimal> TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }
    }
}
