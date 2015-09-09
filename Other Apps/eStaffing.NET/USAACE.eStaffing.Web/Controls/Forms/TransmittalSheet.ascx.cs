using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.Common.Web;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.FormEntities;
using USAACE.eStaffing.Presentation.Presenters.Controls.Forms;
using USAACE.eStaffing.Presentation.Views.Controls.Forms;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web.Controls.Forms
{
    public partial class TransmittalSheet : FormControl, ITransmittalSheetView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private TransmittalSheetPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public TransmittalSheetPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new TransmittalSheetPresenter(this);
                }

                return _presenter;
            }
        }

        protected void rblIsTasker_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.ShowTaskerNumber();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void chkOther_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.ShowOtherText();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void chkKeyAreaOther_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.ShowKeyAreaOtherText();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring when an item is bound to the Attendees repeater, it gets information about the attendee and displays the information
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The item arguments of the event</param>
        protected void dlCoords_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is TransmittalCoord)
                {
                    TransmittalCoord coord = e.Item.DataItem as TransmittalCoord;

                    (e.Item.FindControl("imgCoordConcur") as Image).Visible = coord.Concur == true;
                    (e.Item.FindControl("imgCoordNonConcur") as Image).Visible = coord.Concur == false;
                    (e.Item.FindControl("ltrCoordAgency") as Literal).Text = coord.Agency;
                    (e.Item.FindControl("ltrCoordName") as Literal).Text = coord.Name;
                    (e.Item.FindControl("ltrCoordPhone") as Literal).Text = coord.Phone;
                    (e.Item.FindControl("ltrCoordDate") as Literal).Text = coord.CoordDate.HasValue ? coord.CoordDate.Value.ToShortDateString() : null;
                    (e.Item.FindControl("ltrCoordRemarks") as Literal).Text = coord.Remarks;
                    (e.Item.FindControl("imbEditCoord") as ImageButton).CommandArgument = coord.ListIndex.ToString();
                    (e.Item.FindControl("imbDeleteCoord") as ImageButton).CommandArgument = coord.ListIndex.ToString();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when Add Coordination is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnAddCoord_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedCoordID = null;
                Presenter.LoadCoord();
                mpEditCoord.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when Edit Coordination is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The item arguments of the event</param>
        protected void imbEditCoord_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedCoordID = e.CommandArgument.ToStringSafe().ToNullable<Int32>();
                Presenter.LoadCoord();
                mpEditCoord.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when Delete Attendee is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The item arguments of the event</param>
        protected void imbDeleteCoord_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedCoordID = e.CommandArgument.ToStringSafe().ToNullable<Int32>();
                mpDeleteCoordConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteCoordConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteCoord();
                mpDeleteCoordConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteCoordCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteCoordConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveCoord_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SaveCoord();
                mpEditCoord.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelCoord_Click(object sender, EventArgs e)
        {
            try
            {
                mpEditCoord.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected override void LoadForm()
        {
            rblIsTasker.BindBooleanListControl("Yes", "No");
            rblCoordResponse.BindBooleanListControl("Concur", "Non-Concur", "No Response");

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

        public Nullable<Boolean> IsTaskerResponse
        {
            get
            {
                return rblIsTasker.SelectedValue.ToNullable<Boolean>();
            }
            set
            {
                rblIsTasker.SelectedValue = value.ToStringSafe();
            }
        }

        public Boolean ShowTaskerNumber
        {
            set
            {
                tdTaskerNumber1.Visible = value;
                tdTaskerNumber2.Visible = value;
            }
        }

        public String TaskerNumber
        {
            get
            {
                return txtTaskerNumber.Text;
            }
            set
            {
                txtTaskerNumber.Text = value;
            }
        }

        public String Subject
        {
            get
            {
                return txtSubject.Text;
            }
            set
            {
                txtSubject.Text = value;
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

        public String OfficeSymbol
        {
            get
            {
                return txtOfficeSymbol.Text;
            }
            set
            {
                txtOfficeSymbol.Text = value;
            }
        }

        public String PhoneNumber
        {
            get
            {
                return txtPhoneNumber.Text;
            }
            set
            {
                txtPhoneNumber.Text = value;
            }
        }

        public Nullable<DateTime> SuspenseDate
        {
            get
            {
                return dcSuspenseDate.SelectedDate;
            }
            set
            {
                dcSuspenseDate.SelectedDate = value;
            }
        }

        public Nullable<DateTime> FormDate
        {
            get
            {
                return dcDate.SelectedDate;
            }
            set
            {
                dcDate.SelectedDate = value;
            }
        }

        public Nullable<Boolean> Signature
        {
            get
            {
                return chkSignature.Checked;
            }
            set
            {
                chkSignature.Checked = value == true;
            }
        }

        public Nullable<Boolean> Approval
        {
            get
            {
                return chkApproval.Checked;
            }
            set
            {
                chkApproval.Checked = value == true;
            }
        }

        public Nullable<Boolean> Information
        {
            get
            {
                return chkInformation.Checked;
            }
            set
            {
                chkInformation.Checked = value == true;
            }
        }

        public Nullable<Boolean> ReadAhead
        {
            get
            {
                return chkReadAhead.Checked;
            }
            set
            {
                chkReadAhead.Checked = value == true;
            }
        }

        public Nullable<Boolean> Other
        {
            get
            {
                return chkOther.Checked;
            }
            set
            {
                chkOther.Checked = value == true;
            }
        }

        public Boolean ShowOtherText
        {
            set
            {
                txtOtherText.Visible = value;
            }
        }

        public String OtherText
        {
            get
            {
                return txtOtherText.Text;
            }
            set
            {
                txtOtherText.Text = value;
            }
        }

        public String Recommendation
        {
            get
            {
                return hteRecommendation.Text;
            }
            set
            {
                hteRecommendation.Text = value;
            }
        }

        public Nullable<Boolean> RecommendationCSM
        {
            get
            {
                return chkRecommendCSM.Checked;
            }
            set
            {
                chkRecommendCSM.Checked = value == true;
            }
        }

        public Nullable<Boolean> RecommendationCPG
        {
            get
            {
                return chkRecommendCPG.Checked;
            }
            set
            {
                chkRecommendCPG.Checked = value == true;
            }
        }

        public Nullable<Boolean> RecommendationDCOS
        {
            get
            {
                return chkRecommendDCOS.Checked;
            }
            set
            {
                chkRecommendDCOS.Checked = value == true;
            }
        }

        public Nullable<Boolean> RecommendationDCG
        {
            get
            {
                return chkRecommendDCG.Checked;
            }
            set
            {
                chkRecommendDCG.Checked = value == true;
            }
        }

        public Nullable<Boolean> RecommendationCG
        {
            get
            {
                return chkRecommendCG.Checked;
            }
            set
            {
                chkRecommendCG.Checked = value == true;
            }
        }

        public String Discussion
        {
            get
            {
                return hteDiscussion.Text;
            }
            set
            {
                hteDiscussion.Text = value;
            }
        }

        public Nullable<Boolean> KeyAreaFunding
        {
            get
            {
                return chkKeyAreaFunding.Checked;
            }
            set
            {
                chkKeyAreaFunding.Checked = value == true;
            }
        }

        public Nullable<Boolean> KeyAreaPolicy
        {
            get
            {
                return chkKeyAreaPolicy.Checked;
            }
            set
            {
                chkKeyAreaPolicy.Checked = value == true;
            }
        }

        public Nullable<Boolean> KeyAreaEquipment
        {
            get
            {
                return chkKeyAreaEquipment.Checked;
            }
            set
            {
                chkKeyAreaEquipment.Checked = value == true;
            }
        }

        public Nullable<Boolean> KeyAreaLegal
        {
            get
            {
                return chkKeyAreaLegal.Checked;
            }
            set
            {
                chkKeyAreaLegal.Checked = value == true;
            }
        }

        public Nullable<Boolean> KeyAreaTraining
        {
            get
            {
                return chkKeyAreaTraining.Checked;
            }
            set
            {
                chkKeyAreaTraining.Checked = value == true;
            }
        }

        public Nullable<Boolean> KeyAreaPersonnel
        {
            get
            {
                return chkKeyAreaPersonnel.Checked;
            }
            set
            {
                chkKeyAreaPersonnel.Checked = value == true;
            }
        }

        public Nullable<Boolean> KeyAreaCongressional
        {
            get
            {
                return chkKeyAreaCongressional.Checked;
            }
            set
            {
                chkKeyAreaCongressional.Checked = value == true;
            }
        }

        public Nullable<Boolean> KeyAreaStrategy
        {
            get
            {
                return chkKeyAreaStrategy.Checked;
            }
            set
            {
                chkKeyAreaStrategy.Checked = value == true;
            }
        }

        public Nullable<Boolean> KeyAreaOther
        {
            get
            {
                return chkKeyAreaOther.Checked;
            }
            set
            {
                chkKeyAreaOther.Checked = value == true;
            }
        }

        public Boolean ShowKeyAreaOtherText
        {
            set
            {
                txtKeyAreaOtherText.Visible = value;
            }
        }

        public String KeyAreaOtherText
        {
            get
            {
                return txtKeyAreaOtherText.Text;
            }
            set
            {
                txtKeyAreaOtherText.Text = value;
            }
        }

        public String PrincipalComments
        {
            get
            {
                return htePrincipalComments.Text;
            }
            set
            {
                htePrincipalComments.Text = value;
            }
        }

        public IList<TransmittalCoord> Coordinations
        {
            get
            {
                return this.ViewState["Coordinations"] as IList<TransmittalCoord>;
            }
            set
            {
                this.ViewState["Coordinations"] = value;

                dlCoords.DataSource = value;
                dlCoords.DataBind();
            }
        }

        public Nullable<Int32> SelectedCoordID
        {
            get
            {
                return this.ViewState["SelectedCoordID"] as Nullable<Int32>;
            }
            set
            {
                this.ViewState["SelectedCoordID"] = value;
            }
        }

        public Nullable<Boolean> CoordResponse
        {
            get
            {
                return rblCoordResponse.SelectedValue.ToNullable<Boolean>();
            }
            set
            {
                rblCoordResponse.SelectedValue = value.ToStringSafe(String.Empty);
            }
        }

        public String CoordAgency
        {
            get
            {
                return txtCoordAgency.Text;
            }
            set
            {
                txtCoordAgency.Text = value;
            }
        }

        public String CoordName
        {
            get
            {
                return txtCoordName.Text;
            }
            set
            {
                txtCoordName.Text = value;
            }
        }

        public String CoordPhone
        {
            get
            {
                return txtCoordPhone.Text;
            }
            set
            {
                txtCoordPhone.Text = value;
            }
        }

        public Nullable<DateTime> CoordDate
        {
            get
            {
                return dcCoordDate.SelectedDate;
            }
            set
            {
                dcCoordDate.SelectedDate = value;
            }
        }

        public String CoordRemarks
        {
            get
            {
                return txtCoordRemarks.Text;
            }
            set
            {
                txtCoordRemarks.Text = value;
            }
        }

        internal override void SetEnabledState(Boolean enabled)
        {
            rblIsTasker.Enabled = enabled;
            txtTaskerNumber.Enabled = enabled;

            txtSubject.Enabled = enabled;
            txtActionOfficer.Enabled = enabled;

            txtOfficeSymbol.Enabled = enabled;
            txtPhoneNumber.Enabled = enabled;
            dcSuspenseDate.Enabled = enabled;
            dcDate.Enabled = enabled;

            chkSignature.Enabled = enabled;
            chkApproval.Enabled = enabled;
            chkInformation.Enabled = enabled;
            chkReadAhead.Enabled = enabled;
            chkOther.Enabled = enabled;
            txtOtherText.Enabled = enabled;

            hteRecommendation.Enabled = enabled;
            chkRecommendCSM.Enabled = enabled;
            chkRecommendCPG.Enabled = enabled;
            chkRecommendDCOS.Enabled = enabled;
            chkRecommendDCG.Enabled = enabled;
            chkRecommendCG.Enabled = enabled;

            hteDiscussion.Enabled = enabled;

            chkKeyAreaFunding.Enabled = enabled;
            chkKeyAreaPolicy.Enabled = enabled;
            chkKeyAreaEquipment.Enabled = enabled;
            chkKeyAreaLegal.Enabled = enabled;
            chkKeyAreaTraining.Enabled = enabled;
            chkKeyAreaPersonnel.Enabled = enabled;
            chkKeyAreaCongressional.Enabled = enabled;
            chkKeyAreaStrategy.Enabled = enabled;
            chkKeyAreaOther.Enabled = enabled;
            txtKeyAreaOtherText.Enabled = enabled;

            htePrincipalComments.Enabled = enabled;

            btnAddCoord.Visible = enabled;

            dlCoords.Enabled = enabled;

            /*foreach (RepeaterItem item in dlCoords.Items)
            {
                (item.FindControl("imbEditCoord") as ImageButton).Visible = enabled;
                (item.FindControl("imbDeleteCoord") as ImageButton).Visible = enabled;
            }*/
        }
    }
}