using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.FormEntities
{
    [Serializable]
    public class AwardSheet : FormEntityBase
    {
        private String _name;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private String _unit;

        /// <summary>
        /// A property representation of the Unit field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        private Nullable<DateTime> _presentationDate;

        /// <summary>
        /// A property representation of the PresentationDate field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public Nullable<DateTime> PresentationDate
        {
            get { return _presentationDate; }
            set { _presentationDate = value; }
        }

        private String _presentDutyPosition;

        /// <summary>
        /// A property representation of the PresentDutyPosition field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String PresentDutyPosition
        {
            get { return _presentDutyPosition; }
            set { _presentDutyPosition = value; }
        }

        private String _highestAwardLevel;

        /// <summary>
        /// A property representation of the HighestAwardLevel field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String HighestAwardLevel
        {
            get { return _highestAwardLevel; }
            set { _highestAwardLevel = value; }
        }

        private Nullable<Boolean> _soldierFlagged;

        /// <summary>
        /// A property representation of the SoldierFlagged field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public Nullable<Boolean> SoldierFlagged
        {
            get { return _soldierFlagged; }
            set { _soldierFlagged = value; }
        }

        private String _soldierFlaggedReason;

        /// <summary>
        /// A property representation of the SoldierFlaggedReason field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String SoldierFlaggedReason
        {
            get { return _soldierFlaggedReason; }
            set { _soldierFlaggedReason = value; }
        }

        private String _stationTime;

        /// <summary>
        /// A property representation of the StationTime field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String StationTime
        {
            get { return _stationTime; }
            set { _stationTime = value; }
        }

        private String _awardReason;

        /// <summary>
        /// A property representation of the AwardReason field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String AwardReason
        {
            get { return _awardReason; }
            set { _awardReason = value; }
        }

        private String _awardLevel;

        /// <summary>
        /// A property representation of the AwardLevel field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String AwardLevel
        {
            get { return _awardLevel; }
            set { _awardLevel = value; }
        }

        private Nullable<Int16> _height;

        /// <summary>
        /// A property representation of the Height field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public Nullable<Int16> Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private Nullable<Int16> _weight;

        /// <summary>
        /// A property representation of the Weight field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public Nullable<Int16> Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        private Nullable<Byte> _age;

        /// <summary>
        /// A property representation of the Age field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public Nullable<Byte> Age
        {
            get { return _age; }
            set { _age = value; }
        }

        private Nullable<Byte> _bodyFatAuth;

        /// <summary>
        /// A property representation of the BodyFatAuth field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public Nullable<Byte> BodyFatAuth
        {
            get { return _bodyFatAuth; }
            set { _bodyFatAuth = value; }
        }

        private Nullable<Byte> _bodyFatHas;

        /// <summary>
        /// A property representation of the BodyFatHas field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public Nullable<Byte> BodyFatHas
        {
            get { return _bodyFatHas; }
            set { _bodyFatHas = value; }
        }

        private Nullable<Boolean> _go;

        /// <summary>
        /// A property representation of the Go field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public Nullable<Boolean> Go
        {
            get { return _go; }
            set { _go = value; }
        }

        private Nullable<DateTime> _aPFTDate;

        /// <summary>
        /// A property representation of the APFTDate field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public Nullable<DateTime> APFTDate
        {
            get { return _aPFTDate; }
            set { _aPFTDate = value; }
        }

        private Nullable<Boolean> _aPFTPass;

        /// <summary>
        /// A property representation of the APFTPass field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public Nullable<Boolean> APFTPass
        {
            get { return _aPFTPass; }
            set { _aPFTPass = value; }
        }

        private Nullable<Boolean> _aPFTProfile;

        /// <summary>
        /// A property representation of the APFTProfile field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public Nullable<Boolean> APFTProfile
        {
            get { return _aPFTProfile; }
            set { _aPFTProfile = value; }
        }

        private Nullable<Byte> _totalYearsService;

        /// <summary>
        /// A property representation of the TotalYearsService field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public Nullable<Byte> TotalYearsService
        {
            get { return _totalYearsService; }
            set { _totalYearsService = value; }
        }

        private String _keyPositions;

        /// <summary>
        /// A property representation of the KeyPositions field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String KeyPositions
        {
            get { return _keyPositions; }
            set { _keyPositions = value; }
        }

        private String _currentPositions;

        /// <summary>
        /// A property representation of the CurrentPositions field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String CurrentPositions
        {
            get { return _currentPositions; }
            set { _currentPositions = value; }
        }

        private String _currentAwards;

        /// <summary>
        /// A property representation of the CurrentAwards field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String CurrentAwards
        {
            get { return _currentAwards; }
            set { _currentAwards = value; }
        }

        private String _leaderComments;

        /// <summary>
        /// A property representation of the LeaderComments field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String LeaderComments
        {
            get { return _leaderComments; }
            set { _leaderComments = value; }
        }

        private String _seniorNCOComments;

        /// <summary>
        /// A property representation of the SeniorNCOComments field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String SeniorNCOComments
        {
            get { return _seniorNCOComments; }
            set { _seniorNCOComments = value; }
        }

        private Nullable<DateTime> _unitSignDate;

        /// <summary>
        /// A property representation of the UnitSignDate field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public Nullable<DateTime> UnitSignDate
        {
            get { return _unitSignDate; }
            set { _unitSignDate = value; }
        }

        private String _unitComments;

        /// <summary>
        /// A property representation of the UnitComments field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String UnitComments
        {
            get { return _unitComments; }
            set { _unitComments = value; }
        }
    }
}
