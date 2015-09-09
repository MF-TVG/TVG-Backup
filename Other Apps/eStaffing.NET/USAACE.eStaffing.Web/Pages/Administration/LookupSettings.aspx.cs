using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.Common.Exceptions;
using USAACE.Common.Web.Controls;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.LookupEntities;
using USAACE.eStaffing.Presentation.Presenters.Pages.Administration;
using USAACE.eStaffing.Presentation.Views.Pages.Administration;
using USAACE.eStaffing.Web.Enum;

namespace USAACE.eStaffing.Web.Pages.Administration
{
    public partial class LookupSettings : BasePage, ILookupSettingsView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private LookupSettingsPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public LookupSettingsPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new LookupSettingsPresenter(this);
                }

                return _presenter;
            }
        }

        protected override void LoadPage()
        {
            try
            {
                if (!IsPostBack)
                {
                    Presenter.Load();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (gvLookupValues.HeaderRow != null)
            {
                gvLookupValues.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void ddlFormType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadFormTypeLookups();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void ddlFormTypeLookup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadFormTypeLookup();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void gvLookupValues_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                this.SelectedLookupValue = e.CommandArgument.ToNullable<Int32>();

                if (e.CommandName == "EditValue")
                {
                    Presenter.LoadFormTypeLookupRow();
                    mpEditLookupValue.Show();
                }
                else if (e.CommandName == "DeleteValue")
                {
                    mpDeleteLookupValueConfirm.Show();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnAddLookupValue_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedLookupValue = null;
                Presenter.LoadFormTypeLookupRow();
                mpEditLookupValue.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveFormTypeLookup_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SaveFormTypeLookup();
                this.ShowNotice(MessageConstants.SAVE_FORM_TYPE_LOOKUP_SUCCESS, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveLookupValue_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SaveFormTypeLookupRow();
                mpEditLookupValue.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelLookupValue_Click(object sender, EventArgs e)
        {
            try
            {
                mpEditLookupValue.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteLookupValueConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteFormTypeLookupRow();
                mpDeleteLookupValueConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteLookupValueCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteLookupValueConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dlLookupValueFields_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is KeyValuePair<String, Object>)
                {
                    KeyValuePair<String, Object> value = (KeyValuePair<String, Object>)e.Item.DataItem;

                    (e.Item.FindControl("ltrFieldName") as Literal).Text = value.Key;
                    (e.Item.FindControl("txtFieldValue") as TextControl).Text = value.Value.ToStringSafe();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        public IList<FormType> FormTypeList
        {
            set
            {
                ddlFormType.Items.Clear();

                foreach (FormType formType in value)
                {
                    ddlFormType.Items.Add(new ListItem(formType.FormTypeName, formType.FormTypeID.ToStringSafe()));
                }
            }
        }

        public Nullable<Int32> FormTypeID
        {
            get
            {
                return ddlFormType.SelectedValue.ToNullable<Int32>();
            }
        }

        public IList<Organization> OrganizationList
        {
            set
            {
                ddlOrganization.Items.Clear();

                ddlOrganization.Items.Add(new ListItem("-- Default Values --", String.Empty));

                foreach (Organization organization in value)
                {
                    ddlOrganization.Items.Add(new ListItem(organization.OrganizationName, organization.OrganizationID.ToStringSafe()));
                }
            }
        }

        public Nullable<Int32> OrganizationID
        {
            get
            {
                return ddlOrganization.SelectedValue.ToNullable<Int32>();
            }
        }

        public IList<FormTypeLookup> FormTypeLookupList
        {
            set
            {
                ddlFormTypeLookup.Items.Clear();

                foreach (FormTypeLookup lookup in value)
                {
                    ddlFormTypeLookup.Items.Add(new ListItem(lookup.LookupName, lookup.LookupName));
                }
            }
        }

        public String SelectedFormTypeLookup
        {
            get
            {
                return ddlFormTypeLookup.SelectedValue;
            }
            set
            {
                ddlFormTypeLookup.SelectedValue = value;
            }
        }

        public Nullable<Int32> FormTypeLookupID
        {
            get
            {
                return this.ViewState["FormTypeLookupID"] as Nullable<Int32>;
            }
            set
            {
                this.ViewState["FormTypeLookupID"] = value;
            }
        }

        public String LookupDataType
        {
            get
            {
                return this.ViewState["LookupDataType"] as String;
            }
            set
            {
                this.ViewState["LookupDataType"] = value;
            }
        }

        public DataTable LookupValues
        {
            get
            {
                return this.ViewState["LookupValues"] as DataTable;
            }
            set
            {
                this.ViewState["LookupValues"] = value;

                gvLookupValues.Columns.Clear();

                if (value != null)
                {
                    foreach (DataColumn column in value.Columns)
                    {
                        BoundField field = new BoundField();
                        field.DataField = column.ColumnName;
                        field.HeaderText = column.ColumnName;

                        gvLookupValues.Columns.Add(field);
                    }

                    ButtonField editField = new ButtonField();
                    editField.HeaderStyle.Width = Unit.Parse("5em");
                    editField.ImageUrl = "~/images/edit.gif";
                    editField.ButtonType = ButtonType.Image;
                    editField.CommandName = "EditValue";
                    editField.HeaderText = "Edit";

                    gvLookupValues.Columns.Add(editField);

                    ButtonField deleteField = new ButtonField();
                    deleteField.HeaderStyle.Width = Unit.Parse("5em");
                    deleteField.ImageUrl = "~/images/delete.gif";
                    deleteField.ButtonType = ButtonType.Image;
                    deleteField.CommandName = "DeleteValue";
                    deleteField.HeaderText = "Delete";

                    gvLookupValues.Columns.Add(deleteField);
                }

                gvLookupValues.DataSource = value;
                gvLookupValues.DataBind();
            }
        }

        public Nullable<Int32> SelectedLookupValue
        {
            get
            {
                return this.ViewState["SelectedLookupValue"] as Nullable<Int32>;
            }
            set
            {
                this.ViewState["SelectedLookupValue"] = value;
            }
        }

        public IDictionary<String, Object> LookupValueRow
        {
            get
            {
                IDictionary<String, Object> values = new Dictionary<String, Object>();

                for (int i = 0; i < dlLookupValueFields.Items.Count; i++)
                {
                    values.Add((dlLookupValueFields.Items[i].FindControl("ltrFieldName") as Literal).Text,
                        (dlLookupValueFields.Items[i].FindControl("txtFieldValue") as TextControl).Text);
                }

                return values;
            }
            set
            {
                dlLookupValueFields.DataSource = value;
                dlLookupValueFields.DataBind();
            }
        }
    }
}