using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.FormEntities
{
    [Serializable]
    public class Transmittal : FormEntityBase
    {
        private Nullable<Boolean> _isTaskerResponse;

        /// <summary>
        /// A property representation of the IsTaskerResponse field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> IsTaskerResponse
        {
            get { return _isTaskerResponse; }
            set { _isTaskerResponse = value; }
        }

        private String _taskerNumber;

        /// <summary>
        /// A property representation of the TaskerNumber field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public String TaskerNumber
        {
            get { return _taskerNumber; }
            set { _taskerNumber = value; }
        }

        private String _officeSymbol;

        /// <summary>
        /// A property representation of the OfficeSymbol field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public String OfficeSymbol
        {
            get { return _officeSymbol; }
            set { _officeSymbol = value; }
        }

        private String _phoneNumber;

        /// <summary>
        /// A property representation of the PhoneNumber field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public String PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        private Nullable<DateTime> _suspenseDate;

        /// <summary>
        /// A property representation of the SuspenseDate field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<DateTime> SuspenseDate
        {
            get { return _suspenseDate; }
            set { _suspenseDate = value; }
        }

        private Nullable<DateTime> _transmittalDate;

        /// <summary>
        /// A property representation of the TransmittalDate field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<DateTime> TransmittalDate
        {
            get { return _transmittalDate; }
            set { _transmittalDate = value; }
        }

        private String _subject;

        /// <summary>
        /// A property representation of the Subject field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public String Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        private String _actionOfficer;

        /// <summary>
        /// A property representation of the ActionOfficer field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public String ActionOfficer
        {
            get { return _actionOfficer; }
            set { _actionOfficer = value; }
        }

        private Nullable<Boolean> _signature;

        /// <summary>
        /// A property representation of the Signature field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> Signature
        {
            get { return _signature; }
            set { _signature = value; }
        }

        private Nullable<Boolean> _approval;

        /// <summary>
        /// A property representation of the Approval field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> Approval
        {
            get { return _approval; }
            set { _approval = value; }
        }

        private Nullable<Boolean> _information;

        /// <summary>
        /// A property representation of the Information field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> Information
        {
            get { return _information; }
            set { _information = value; }
        }

        private Nullable<Boolean> _readAhead;

        /// <summary>
        /// A property representation of the ReadAhead field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> ReadAhead
        {
            get { return _readAhead; }
            set { _readAhead = value; }
        }

        private Nullable<Boolean> _other;

        /// <summary>
        /// A property representation of the Other field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> Other
        {
            get { return _other; }
            set { _other = value; }
        }

        private String _otherText;

        /// <summary>
        /// A property representation of the OtherText field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public String OtherText
        {
            get { return _otherText; }
            set { _otherText = value; }
        }

        private String _recommendation;

        /// <summary>
        /// A property representation of the Recommendation field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public String Recommendation
        {
            get { return _recommendation; }
            set { _recommendation = value; }
        }

        private Nullable<Boolean> _recommendationCSM;

        /// <summary>
        /// A property representation of the RecommendationCSM field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> RecommendationCSM
        {
            get { return _recommendationCSM; }
            set { _recommendationCSM = value; }
        }

        private Nullable<Boolean> _recommendationCPG;

        /// <summary>
        /// A property representation of the RecommendationCPG field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> RecommendationCPG
        {
            get { return _recommendationCPG; }
            set { _recommendationCPG = value; }
        }

        private Nullable<Boolean> _recommendationDCOS;

        /// <summary>
        /// A property representation of the RecommendationDCOS field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> RecommendationDCOS
        {
            get { return _recommendationDCOS; }
            set { _recommendationDCOS = value; }
        }

        private Nullable<Boolean> _recommendationDCG;

        /// <summary>
        /// A property representation of the RecommendationDCG field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> RecommendationDCG
        {
            get { return _recommendationDCG; }
            set { _recommendationDCG = value; }
        }

        private Nullable<Boolean> _recommendationCG;

        /// <summary>
        /// A property representation of the RecommendationCG field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> RecommendationCG
        {
            get { return _recommendationCG; }
            set { _recommendationCG = value; }
        }

        private String _discussion;

        /// <summary>
        /// A property representation of the Discussion field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public String Discussion
        {
            get { return _discussion; }
            set { _discussion = value; }
        }

        private Nullable<Boolean> _keyAreaFunding;

        /// <summary>
        /// A property representation of the KeyAreaFunding field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> KeyAreaFunding
        {
            get { return _keyAreaFunding; }
            set { _keyAreaFunding = value; }
        }

        private Nullable<Boolean> _keyAreaPolicy;

        /// <summary>
        /// A property representation of the KeyAreaPolicy field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> KeyAreaPolicy
        {
            get { return _keyAreaPolicy; }
            set { _keyAreaPolicy = value; }
        }

        private Nullable<Boolean> _keyAreaEquipment;

        /// <summary>
        /// A property representation of the KeyAreaEquipment field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> KeyAreaEquipment
        {
            get { return _keyAreaEquipment; }
            set { _keyAreaEquipment = value; }
        }

        private Nullable<Boolean> _keyAreaLegal;

        /// <summary>
        /// A property representation of the KeyAreaLegal field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> KeyAreaLegal
        {
            get { return _keyAreaLegal; }
            set { _keyAreaLegal = value; }
        }

        private Nullable<Boolean> _keyAreaTraining;

        /// <summary>
        /// A property representation of the KeyAreaTraining field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> KeyAreaTraining
        {
            get { return _keyAreaTraining; }
            set { _keyAreaTraining = value; }
        }

        private Nullable<Boolean> _keyAreaPersonnel;

        /// <summary>
        /// A property representation of the KeyAreaPersonnel field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> KeyAreaPersonnel
        {
            get { return _keyAreaPersonnel; }
            set { _keyAreaPersonnel = value; }
        }

        private Nullable<Boolean> _keyAreaCongressional;

        /// <summary>
        /// A property representation of the KeyAreaCongressional field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> KeyAreaCongressional
        {
            get { return _keyAreaCongressional; }
            set { _keyAreaCongressional = value; }
        }

        private Nullable<Boolean> _keyAreaStrategy;

        /// <summary>
        /// A property representation of the KeyAreaStrategy field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> KeyAreaStrategy
        {
            get { return _keyAreaStrategy; }
            set { _keyAreaStrategy = value; }
        }

        private Nullable<Boolean> _keyAreaOther;

        /// <summary>
        /// A property representation of the KeyAreaOther field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public Nullable<Boolean> KeyAreaOther
        {
            get { return _keyAreaOther; }
            set { _keyAreaOther = value; }
        }

        private String _keyAreaOtherText;

        /// <summary>
        /// A property representation of the KeyAreaOtherText field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public String KeyAreaOtherText
        {
            get { return _keyAreaOtherText; }
            set { _keyAreaOtherText = value; }
        }

        private String _principalComments;

        /// <summary>
        /// A property representation of the PrincipalComments field for a record in the dbo.Transmittal data table. 
        /// </summary>
        public String PrincipalComments
        {
            get { return _principalComments; }
            set { _principalComments = value; }
        }

        private List<TransmittalCoord> _transmittalCoords;

        public List<TransmittalCoord> TransmittalCoords
        {
            get
            {
                if (_transmittalCoords == null)
                {
                    _transmittalCoords = new List<TransmittalCoord>();
                }

                return _transmittalCoords;
            }
            set
            {
                _transmittalCoords = value;
            }
        }
    }

    [Serializable]
    public class TransmittalCoord : FormSubEntityBase
    {
        private Nullable<Boolean> _concur;

        /// <summary>
        /// A property representation of the Concur field for a record in the dbo.TransmittalCoord data table. 
        /// </summary>
        public Nullable<Boolean> Concur
        {
            get { return _concur; }
            set { _concur = value; }
        }

        private String _agency;

        /// <summary>
        /// A property representation of the Agency field for a record in the dbo.TransmittalCoord data table. 
        /// </summary>
        public String Agency
        {
            get { return _agency; }
            set { _agency = value; }
        }

        private String _name;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.TransmittalCoord data table. 
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private String _phone;

        /// <summary>
        /// A property representation of the Phone field for a record in the dbo.TransmittalCoord data table. 
        /// </summary>
        public String Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private Nullable<DateTime> _coordDate;

        /// <summary>
        /// A property representation of the CoordDate field for a record in the dbo.TransmittalCoord data table. 
        /// </summary>
        public Nullable<DateTime> CoordDate
        {
            get { return _coordDate; }
            set { _coordDate = value; }
        }

        private String _remarks;

        /// <summary>
        /// A property representation of the Remarks field for a record in the dbo.TransmittalCoord data table. 
        /// </summary>
        public String Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
    }
}
