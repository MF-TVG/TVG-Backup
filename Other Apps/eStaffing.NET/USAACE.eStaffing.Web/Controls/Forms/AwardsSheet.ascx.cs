using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.Common.Web;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.LookupEntities;
using USAACE.eStaffing.Presentation.Presenters.Controls.Forms;
using USAACE.eStaffing.Presentation.Views.Controls.Forms;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web.Controls.Forms
{
    public partial class AwardsSheet : FormControl, IAwardsSheetView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private AwardsSheetPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public AwardsSheetPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new AwardsSheetPresenter(this);
                }

                return _presenter;
            }
        }

        protected override void LoadForm()
        {
            rblFlagged.BindBooleanListControl("Yes", "No");
            rblGo.BindBooleanListControl("Go", "No Go");
            rblAPFTPass.BindBooleanListControl("Yes", "No");
            rblAPFTProfile.BindBooleanListControl("Yes", "No");

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
        /// Event taking place when Flagged value is changed, enables or disables Flagged Reason field
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void rblFlagged_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.ShowSoldierFlaggedReason();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Validates that Body Fat Auth has a value when No Go
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The validation arguments for the event</param>
        protected void cvBodyFatAuth_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                e.IsValid = ncBodyFatAuth.Value.ToNullable<Int32>().HasValue || rblGo.SelectedValue != "False";
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Validates that Body Fat Has has a value when No Go
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The validation arguments for the event</param>
        protected void cvBodyFatHas_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                e.IsValid = ncBodyFatHas.Value.ToNullable<Int32>().HasValue || rblGo.SelectedValue != "False";
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        public String Name
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        public String Organization
        {
            get
            {
                return txtOrganization.Text;
            }
            set
            {
                txtOrganization.Text = value;
            }
        }

        public Nullable<DateTime> PresentationDate
        {
            get
            {
                return dcPresentationDate.SelectedDate;
            }
            set
            {
                dcPresentationDate.SelectedDate = value;
            }
        }

        public String DutyPosition
        {
            get
            {
                return txtDutyPosition.Text;
            }
            set
            {
                txtDutyPosition.Text = value;
            }
        }

        public String PreviousAward
        {
            get
            {
                return ddlPreviousAward.SelectedValue;
            }
            set
            {
                ddlPreviousAward.SelectedValue = value;
            }
        }

        public IList<AwardLevel> PreviousAwards
        {
            set
            {
                ddlPreviousAward.Items.Clear();

                ddlPreviousAward.Items.Add(String.Empty);

                foreach (AwardLevel level in value)
                {
                    ddlPreviousAward.Items.Add(new ListItem(level.AwardLevelName, level.AwardLevelName));
                }
            }
        }

        public Nullable<Boolean> SoldierFlagged
        {
            get
            {
                return rblFlagged.SelectedValue.ToNullable<Boolean>();
            }
            set
            {
                rblFlagged.SelectedValue = value.ToStringSafe();
            }
        }

        public String StationTime
        {
            get
            {
                return txtStationTime.Text;
            }
            set
            {
                txtStationTime.Text = value;
            }
        }

        public Boolean ShowSoldierFlaggedReason
        {
            set
            {
                txtReasonFlagged.Visible = value;
            }
        }

        public String SoldierFlaggedReason
        {
            get
            {
                return txtReasonFlagged.Text;
            }
            set
            {
                txtReasonFlagged.Text = value;
            }
        }

        public String AwardReason
        {
            get
            {
                return rblAwardReason.SelectedValue;
            }
            set
            {
                rblAwardReason.SelectedValue = value;
            }
        }

        public IList<AwardReason> AwardReasons
        {
            set
            {
                rblAwardReason.Items.Clear();

                foreach (AwardReason reason in value)
                {
                    rblAwardReason.Items.Add(new ListItem(reason.AwardReasonName, reason.AwardReasonName));
                }
            }
        }

        public String AwardLevel
        {
            get
            {
                return rblAwardLevel.SelectedValue;
            }
            set
            {
                rblAwardLevel.SelectedValue = value;
            }
        }

        public IList<AwardLevel> AwardLevels
        {
            set
            {
                rblAwardLevel.Items.Clear();

                foreach (AwardLevel level in value)
                {
                    rblAwardLevel.Items.Add(new ListItem(level.AwardLevelName, level.AwardLevelName));
                }
            }
        }

        public Nullable<Int16> Height
        {
            get
            {
                return ncHeight.Value.ToNullable<Int16>();
            }
            set
            {
                ncHeight.Value = value;
            }
        }

        public Nullable<Int16> Weight
        {
            get
            {
                return ncWeight.Value.ToNullable<Int16>();
            }
            set
            {
                ncWeight.Value = value;
            }
        }

        public Nullable<Byte> Age
        {
            get
            {
                return ncAge.Value.ToNullable<Byte>();
            }
            set
            {
                ncAge.Value = value;
            }
        }

        public Nullable<Byte> BodyFatAuth
        {
            get
            {
                return ncBodyFatAuth.Value.ToNullable<Byte>();
            }
            set
            {
                ncBodyFatAuth.Value = value;
            }
        }

        public Nullable<Byte> BodyFatHas
        {
            get
            {
                return ncBodyFatHas.Value.ToNullable<Byte>();
            }
            set
            {
                ncBodyFatHas.Value = value;
            }
        }

        public Nullable<Boolean> BodyFatGo
        {
            get
            {
                return rblGo.SelectedValue.ToNullable<Boolean>();
            }
            set
            {
                rblGo.SelectedValue = value.ToStringSafe();
            }
        }

        public Nullable<DateTime> APFTDate
        {
            get
            {
                return dcAPFTDate.SelectedDate;
            }
            set
            {
                dcAPFTDate.SelectedDate = value;
            }
        }

        public Nullable<Boolean> APFTPass
        {
            get
            {
                return rblAPFTPass.SelectedValue.ToNullable<Boolean>();
            }
            set
            {
                rblAPFTPass.SelectedValue = value.ToStringSafe();
            }
        }

        public Nullable<Boolean> Profile
        {
            get
            {
                return rblAPFTProfile.SelectedValue.ToNullable<Boolean>();
            }
            set
            {
                rblAPFTProfile.SelectedValue = value.ToStringSafe();
            }
        }

        public Nullable<Byte> TotalServiceYears
        {
            get
            {
                return ncYearsService.Value.ToNullable<Byte>();
            }
            set
            {
                ncYearsService.Value = value;
            }
        }

        public String KeyPositions
        {
            get
            {
                return hteKeyPositions.Text;
            }
            set
            {
                hteKeyPositions.Text = value;
            }
        }

        public String CurrentPositions
        {
            get
            {
                return htePositionsCurrent.Text;
            }
            set
            {
                htePositionsCurrent.Text = value;
            }
        }

        public String CurrentAwards
        {
            get
            {
                return hteAwardsCurrent.Text;
            }
            set
            {
                hteAwardsCurrent.Text = value;
            }
        }

        public String LeaderComments
        {
            get
            {
                return hteDirectorComments.Text;
            }
            set
            {
                hteDirectorComments.Text = value;
            }
        }

        public String SeniorNCOComments
        {
            get
            {
                return hteSeniorNCOComments.Text;
            }
            set
            {
                hteSeniorNCOComments.Text = value;
            }
        }

        public Nullable<DateTime> UnitSignDate
        {
            get
            {
                return dcBDESignDate.SelectedDate;
            }
            set
            {
                dcBDESignDate.SelectedDate = value;
            }
        }

        public String UnitComments
        {
            get
            {
                return hteBDEComments.Text;
            }
            set
            {
                hteBDEComments.Text = value;
            }
        }

        internal override void SetEnabledState(Boolean enabled)
        {
            txtName.Enabled = enabled;
            txtOrganization.Enabled = enabled;
            dcPresentationDate.Enabled = enabled;
            txtDutyPosition.Enabled = enabled;
            ddlPreviousAward.Enabled = enabled;
            rblFlagged.Enabled = enabled;
            txtStationTime.Enabled = enabled;
            txtReasonFlagged.Enabled = enabled;
            rblAwardReason.Enabled = enabled;
            rblAwardLevel.Enabled = enabled;

            ncHeight.Enabled = enabled;
            ncWeight.Enabled = enabled;
            ncAge.Enabled = enabled;
            dcAPFTDate.Enabled = enabled;
            ncBodyFatAuth.Enabled = enabled;
            rblAPFTPass.Enabled = enabled;
            ncBodyFatHas.Enabled = enabled;
            rblGo.Enabled = enabled;
            rblAPFTProfile.Enabled = enabled;

            ncYearsService.Enabled = enabled;
            htePositionsCurrent.Enabled = enabled;
            hteKeyPositions.Enabled = enabled;
            hteAwardsCurrent.Enabled = enabled;

            dcBDESignDate.Enabled = enabled;
            hteDirectorComments.Enabled = enabled;
            hteSeniorNCOComments.Enabled = enabled;
            hteBDEComments.Enabled = enabled;
        }
    }
}