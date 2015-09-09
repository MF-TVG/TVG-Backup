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
using USAACE.eStaffing.Presentation.Presenters.Pages.Administration;
using USAACE.eStaffing.Presentation.Views.Pages.Administration;
using USAACE.eStaffing.Web.Enum;

namespace USAACE.eStaffing.Web.Pages.Administration
{
    public partial class System : BasePage, ISystemView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private SystemPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public SystemPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new SystemPresenter(this);
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

        protected void lkbResetCache_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.ResetCache();

                base.ShowNotice(MessageConstants.RESET_CACHE_SUCCESS, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void ddlFormType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadFormType();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveFormType_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.Save();
                base.ShowNotice(MessageConstants.SAVE_FORM_TYPE_SUCCESS, NoticeType.Information);
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

                foreach (FormType type in value)
                {
                    ddlFormType.Items.Add(new ListItem(type.FormTypeName, type.FormTypeID.ToStringSafe()));
                }
            }
        }

        public Nullable<Int32> FormTypeID
        {
            get
            {
                return ddlFormType.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                ddlFormType.SelectedValue = value.ToStringSafe();
            }
        }

        public String FormTypeName
        {
            get
            {
                return txtFormTypeName.Text;
            }
            set
            {
                txtFormTypeName.Text = value;
            }
        }

        public IList<String> SuspenseDateFields
        {
            
            set
            {
                ddlSuspenseDateField.Items.Clear();

                foreach (String field in value)
                {
                    ddlSuspenseDateField.Items.Add(field);
                }
            }
        }

        public String SelectedSuspenseDateField
        {
            get
            {
                return ddlSuspenseDateField.SelectedValue;
            }
            set
            {
                ddlSuspenseDateField.SelectedValue = value;
            }
        }

        public IList<String> SubjectFields
        {
            
            set
            {
                ddlSubjectField.Items.Clear();

                foreach (String field in value)
                {
                    ddlSubjectField.Items.Add(field);
                }
            }
        }

        public String SelectedSubjectField
        {
            get
            {
                return ddlSubjectField.SelectedValue;
            }
            set
            {
                ddlSubjectField.SelectedValue = value;
            }
        }

        public IList<String> FormNumberFields
        {
            set
            {
                ddlFormNumberField.Items.Clear();

                ddlFormNumberField.Items.Add(new ListItem("-- Autogenerate --", String.Empty));

                foreach (String field in value)
                {
                    ddlFormNumberField.Items.Add(field);
                }
            }
        }

        public String SelectedFormNumberField
        {
            get
            {
                return ddlFormNumberField.SelectedValue;
            }
            set
            {
                ddlFormNumberField.SelectedValue = value;
            }
        }

        public IList<FormActionType> FormActionTypes
        {
            set
            {
                ddlFormActionType.Items.Clear();

                foreach (FormActionType actionType in value)
                {
                    ddlFormActionType.Items.Add(new ListItem(actionType.FormActionTypeName, actionType.FormActionTypeID.ToStringSafe()));
                }
            }
        }

        public Nullable<Int32> SelectedFormActionType
        {
            get
            {
                return ddlFormActionType.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                ddlFormActionType.SelectedValue = value.ToStringSafe();
            }
        }
    }
}