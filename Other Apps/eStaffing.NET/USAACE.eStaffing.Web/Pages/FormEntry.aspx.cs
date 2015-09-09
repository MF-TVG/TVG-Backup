using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.Common.Exceptions;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Presenters.Pages;
using USAACE.eStaffing.Presentation.Views.Pages;
using USAACE.eStaffing.Web.Controls;
using USAACE.eStaffing.Web.Controls.FormControls;
using USAACE.eStaffing.Web.Enum;

namespace USAACE.eStaffing.Web.Pages
{
    public partial class FormEntry : BasePage, IFormEntryView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private FormEntryPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public FormEntryPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new FormEntryPresenter(this);
                }

                return _presenter;
            }
        }

        /// <summary>
        /// Event occurring on Page Load, loads appropriate lookups and the form on initial event
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected override void LoadPage()
        {
            try
            {
                Presenter.Initialize();

                if (!IsPostBack)
                {
                    LoadForm(false);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Submit button is clicked, save the form with submission
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SaveForm(MessageConstants.SUBMIT_SUCCESS, true);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Save button is clicked, save the form
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveForm(MessageConstants.SAVE_SUCCESS, this.Submitted == true);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Undelete button is clicked, undeletes the form
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnUndelete_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.Undelete();
                ShowNotice(MessageConstants.UNDELETE_SUCCESS, NoticeType.Information);
                LoadForm(false);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete button is clicked, deletes the form
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteFormConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteFormConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteFormConfirm.Hide();
                Presenter.Delete();
                ShowNotice(MessageConstants.DELETE_SUCCESS, NoticeType.Information, "~/Pages/Dashboard.aspx");
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteFormCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteFormConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.BeginImport();
                mpImportForm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void txtImportSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.ImportSearch();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveImportForm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.ExecuteImport();
                ShowNotice(MessageConstants.IMPORT_SUCCESS, NoticeType.Information);
                mpImportForm.Hide();

                LoadForm(false);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelImportForm_Click(object sender, EventArgs e)
        {
            try
            {
                mpImportForm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveDefault_Click(object sender, EventArgs e)
        {
            try
            {
                FormControl.SaveDefaultData();
                ShowNotice(MessageConstants.SET_DEFAULT_SUCCESS, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        internal void LoadForm(Boolean isReload)
        {
            Presenter.Load();
            FormControl.LoadData();
            ucFileControl.LoadData();

            if (!isReload)
            {
                ucReviewControl.LoadData();
            }
        }

        internal void SaveForm(String noticeMessage, Boolean submit)
        {
            if (submit == true)
            {
                Page.Validate("FormSubmit");
            }

            if (submit != true || Page.IsValid)
            {
                this.Submitted = submit;

                Presenter.Save();

                FormControl.SaveData();
                ucFileControl.SaveData();

                base.ShowNotice(noticeMessage, NoticeType.Information);
                LoadForm(false);
            }
            else
            {
                //ShowNotice(MessageConstants.FORM_VALIDATION_ERRORS, NoticeType.Warning);
            }
        }

        private FormControl FormControl
        {
            get
            {
                return plhForm.FindControl("ucForm") as FormControl;
            }
        }

        public Nullable<Int32> FormID
        {
            get
            {
                return Request.QueryString["FormID"].ToNullable<Int32>();
            }
        }

        public Nullable<Int32> FormTypeID
        {
            get
            {
                return this.ViewState["FormTypeID"] as Nullable<Int32>;
            }
            set
            {
                this.ViewState["FormTypeID"] = value;
            }
        }

        public String FormLink
        {
            get
            {
                return Request.Url.AbsoluteUri;
            }
        }

        public String ControlName
        {
            set
            {
                FormControl formControl = LoadControl(String.Format("~/Controls/Forms/{0}.ascx", value)) as FormControl;
                formControl.ID = "ucForm";

                plhForm.Controls.Add(formControl);
            }
        }

        public String FormTitle
        {
            set
            {
                this.Title = value;
                ltrFormTitle.Text = value;
            }
        }

        public String FormNumber
        {
            set
            {
                ltrFormNumber.Text = value;
            }
        }

        public Nullable<Boolean> Submitted
        {
            get
            {
                return this.ViewState["Submitted"].ToStringSafe() == "1";
            }
            set
            {
                this.ViewState["Submitted"] = value == true ? "1" : "0";
            }
        }

        public Nullable<Boolean> HighPriority
        {
            get
            {
                return chkHighPriority.Checked;
            }
            set
            {
                chkHighPriority.Checked = value == true;
            }
        }

        public String SubmitGroupName
        {
            set
            {
                ltrSubmitGroup.Text = value;
            }
        }

        public Nullable<Int32> SubmitGroupID 
        {
            internal get
            {
                return this.ViewState["SubmitGroupID"] as Nullable<Int32>;
            }
            set
            {
                this.ViewState["SubmitGroupID"] = value;
            }
        }

        public Nullable<Int32> SubmitOrganizationID
        {
            internal get
            {
                return this.ViewState["SubmitOrganizationID"] as Nullable<Int32>;
            }
            set
            {
                this.ViewState["SubmitOrganizationID"] = value;
            }
        }

        public Boolean EnableEdit
        {
            internal get
            {
                return btnSave.Visible;
            }
            set
            {
                chkHighPriority.Enabled = value;
                btnSave.Visible = value;
                btnSaveBottom.Visible = value;
            }
        }

        public Boolean EnableDelete
        {
            set
            {
                btnDelete.Visible = value;
            }
        }

        public Boolean EnableUndelete
        {
            set
            {
                btnUndelete.Visible = value;
            }
        }

        public Boolean EnableSubmit
        {
            set
            {
                btnSubmit.Visible = value;
                btnSubmitBottom.Visible = value;
                btnSaveDefault.Visible = value;
            }
        }

        public Boolean EnableImport
        {
            set
            {
                btnImport.Visible = value;
            }
        }

        public String ImportSearch
        {
            get
            {
                return txtImportSearch.Text;
            }
            set
            {
                txtImportSearch.Text = value;
            }
        }

        public IList<Form> ImportForms
        {
            set
            {
                ddlImportForms.Items.Clear();

                if (value.Count > 0)
                {
                    foreach (Form form in value)
                    {
                        ddlImportForms.Items.Add(new ListItem(form.ExtendedProperties.NumberAndSubject, form.FormID.ToStringSafe()));
                    }
                }
                else
                {
                    ddlImportForms.Items.Add(new ListItem("-- No Results Found --", String.Empty));
                }
            }
        }

        public Nullable<Int32> SelectedImportFormID
        {
            get
            {
                return ddlImportForms.SelectedValue.ToNullable<Int32>();
            }
        }

        public Nullable<Boolean> ImportIncludeAttachments
        {
            get
            {
                return chkImportAttachments.Checked;
            }
            set
            {
                chkImportAttachments.Checked = value == true;
            }
        }
    }
}