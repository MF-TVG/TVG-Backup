using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.eStaffing.Presentation.Presenters.Controls.Forms;
using USAACE.eStaffing.Presentation.Views.Controls.Forms;

namespace USAACE.eStaffing.Web.Controls.Forms
{
    public partial class EvaluationReport : FormControl, IEvaluationReportView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private EvaluationReportPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public EvaluationReportPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new EvaluationReportPresenter(this);
                }

                return _presenter;
            }
        }

        protected override void LoadForm()
        {
            Presenter.Load();
        }

        protected override void SaveForm()
        {
            Presenter.Save();
        }

        protected override void SaveDefault()
        {
            Presenter.SaveDefault();
        }

        /// <summary>
        /// Validates that Thru Date has a value
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The validation arguments for the event</param>
        protected void cvThruDate_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                e.IsValid = dcThruDate.SelectedDate.HasValue;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Validates that at least one Document Checklist value is selected
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The validation arguments for the event</param>
        protected void cvChecklist_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                e.IsValid = chkSupportForm.Checked || chkCivilianForm.Checked || chkPTCard.Checked || chkRecommendedComments.Checked;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Validates that Loss Date has a value
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The validation arguments for the event</param>
        protected void cvLossDate_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                e.IsValid = dcLossDate.SelectedDate.HasValue;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        public String ActionOfficer
        {
            get
            {
                return txtActionOfficer.Text;
            }
            set
            {
                txtActionOfficer.Text = value;
            }
        }

        public String Ratee
        {
            get
            {
                return txtRatee.Text;
            }
            set
            {
                txtRatee.Text = value;
            }
        }

        public Nullable<DateTime> ThruDate
        {
            get
            {
                return dcThruDate.SelectedDate;
            }
            set
            {
                dcThruDate.SelectedDate = value;
            }
        }

        public String Rater
        {
            get
            {
                return txtRater.Text;
            }
            set
            {
                txtRater.Text = value;
            }
        }

        public String IntermediateRater
        {
            get
            {
                return txtIntermediateRater.Text;
            }
            set
            {
                txtIntermediateRater.Text = value;
            }
        }

        public String SeniorRater
        {
            get
            {
                return txtSeniorRater.Text;
            }
            set
            {
                txtSeniorRater.Text = value;
            }
        }

        public String Reviewer
        {
            get
            {
                return txtReviewer.Text;
            }
            set
            {
                txtReviewer.Text = value;
            }
        }

        public String SubmissionReason
        {
            get
            {
                return txtSubmissionReason.Text;
            }
            set
            {
                txtSubmissionReason.Text = value;
            }
        }

        public Nullable<Boolean> SupportForm
        {
            get
            {
                return chkSupportForm.Checked;
            }
            set
            {
                chkSupportForm.Checked = value == true;
            }
        }

        public Nullable<Boolean> CivilianForm
        {
            get
            {
                return chkCivilianForm.Checked;
            }
            set
            {
                chkCivilianForm.Checked = value == true;
            }
        }

        public Nullable<Boolean> PTCard
        {
            get
            {
                return chkPTCard.Checked;
            }
            set
            {
                chkPTCard.Checked = value == true;
            }
        }

        public Nullable<Boolean> RecommendedComments
        {
            get
            {
                return chkRecommendedComments.Checked;
            }
            set
            {
                chkRecommendedComments.Checked = value == true;
            }
        }

        public String Remarks
        {
            get
            {
                return hteRemarks.Text;
            }
            set
            {
                hteRemarks.Text = value;
            }
        }

        public Nullable<DateTime> LossDate
        {
            get
            {
                return dcLossDate.SelectedDate;
            }
            set
            {
                dcLossDate.SelectedDate = value;
            }
        }

        internal override void SetEnabledState(Boolean enabled)
        {
            txtActionOfficer.Enabled = enabled;
            txtRatee.Enabled = enabled;
            dcThruDate.Enabled = enabled;
            txtRater.Enabled = enabled;
            txtIntermediateRater.Enabled = enabled;
            txtSeniorRater.Enabled = enabled;
            txtReviewer.Enabled = enabled;
            txtSubmissionReason.Enabled = enabled;

            chkSupportForm.Enabled = enabled;
            chkCivilianForm.Enabled = enabled;
            chkPTCard.Enabled = enabled;
            chkRecommendedComments.Enabled = enabled;

            hteRemarks.Enabled = enabled;
            dcLossDate.Enabled = enabled;
        }
    }
}