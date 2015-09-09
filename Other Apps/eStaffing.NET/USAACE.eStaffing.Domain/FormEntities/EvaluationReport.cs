using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.FormEntities
{
    [Serializable]
    public class EvaluationReport : FormEntityBase
    {
        private String _actionOfficer;

        /// <summary>
        /// A property representation of the ActionOfficer field for a record in the dbo.EvaluationReport data table. 
        /// </summary>
        public String ActionOfficer
        {
            get { return _actionOfficer; }
            set { _actionOfficer = value; }
        }

        private String _ratee;

        /// <summary>
        /// A property representation of the Ratee field for a record in the dbo.EvaluationReport data table. 
        /// </summary>
        public String Ratee
        {
            get { return _ratee; }
            set { _ratee = value; }
        }

        private Nullable<DateTime> _thruDate;

        /// <summary>
        /// A property representation of the ThruDate field for a record in the dbo.EvaluationReport data table. 
        /// </summary>
        public Nullable<DateTime> ThruDate
        {
            get { return _thruDate; }
            set { _thruDate = value; }
        }

        private String _rater;

        /// <summary>
        /// A property representation of the Rater field for a record in the dbo.EvaluationReport data table. 
        /// </summary>
        public String Rater
        {
            get { return _rater; }
            set { _rater = value; }
        }

        private String _intermediateRater;

        /// <summary>
        /// A property representation of the IntermediateRater field for a record in the dbo.EvaluationReport data table. 
        /// </summary>
        public String IntermediateRater
        {
            get { return _intermediateRater; }
            set { _intermediateRater = value; }
        }

        private String _seniorRater;

        /// <summary>
        /// A property representation of the SeniorRater field for a record in the dbo.EvaluationReport data table. 
        /// </summary>
        public String SeniorRater
        {
            get { return _seniorRater; }
            set { _seniorRater = value; }
        }

        private String _reviewer;

        /// <summary>
        /// A property representation of the Reviewer field for a record in the dbo.EvaluationReport data table. 
        /// </summary>
        public String Reviewer
        {
            get { return _reviewer; }
            set { _reviewer = value; }
        }

        private String _submissionReason;

        /// <summary>
        /// A property representation of the SubmissionReason field for a record in the dbo.EvaluationReport data table. 
        /// </summary>
        public String SubmissionReason
        {
            get { return _submissionReason; }
            set { _submissionReason = value; }
        }

        private Nullable<Boolean> _supportForm;

        /// <summary>
        /// A property representation of the SupportForm field for a record in the dbo.EvaluationReport data table. 
        /// </summary>
        public Nullable<Boolean> SupportForm
        {
            get { return _supportForm; }
            set { _supportForm = value; }
        }

        private Nullable<Boolean> _counselingForm;

        /// <summary>
        /// A property representation of the CounselingForm field for a record in the dbo.EvaluationReport data table. 
        /// </summary>
        public Nullable<Boolean> CounselingForm
        {
            get { return _counselingForm; }
            set { _counselingForm = value; }
        }

        private Nullable<Boolean> _physicalProfile;

        /// <summary>
        /// A property representation of the PhysicalProfile field for a record in the dbo.EvaluationReport data table. 
        /// </summary>
        public Nullable<Boolean> PhysicalProfile
        {
            get { return _physicalProfile; }
            set { _physicalProfile = value; }
        }

        private Nullable<Boolean> _recommendedComments;

        /// <summary>
        /// A property representation of the RecommendedComments field for a record in the dbo.EvaluationReport data table. 
        /// </summary>
        public Nullable<Boolean> RecommendedComments
        {
            get { return _recommendedComments; }
            set { _recommendedComments = value; }
        }

        private String _remarks;

        /// <summary>
        /// A property representation of the Remarks field for a record in the dbo.EvaluationReport data table. 
        /// </summary>
        public String Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        private Nullable<DateTime> _lossDate;

        /// <summary>
        /// A property representation of the LossDate field for a record in the dbo.EvaluationReport data table. 
        /// </summary>
        public Nullable<DateTime> LossDate
        {
            get { return _lossDate; }
            set { _lossDate = value; }
        }
    }
}
