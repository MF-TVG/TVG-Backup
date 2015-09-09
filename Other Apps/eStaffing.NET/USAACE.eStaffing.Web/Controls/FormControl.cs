using System;
using System.Collections.Generic;
using System.Web.UI;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views.Controls;
using USAACE.eStaffing.Web.Enum;
using USAACE.eStaffing.Web.Pages;

namespace USAACE.eStaffing.Web.Controls
{
    public abstract class FormControl : UserControl, IFormControlView
    {
        public Nullable<Int32> FormID
        {
            get
            {
                return FormPage.FormID;
            }
        }

        public Nullable<Int32> FormTypeID
        {
            get
            {
                return FormPage.FormTypeID;
            }
        }

        public Nullable<Int32> SubmitGroupID
        {
            get
            {
                return FormPage.SubmitGroupID;
            }
        }

        public Nullable<Int32> SubmitOrganizationID
        {
            get
            {
                return FormPage.SubmitOrganizationID;
            }
        }

        public String CurrentUserName
        {
            get
            {
                return FormPage.DisplayName;
            }
        }

        public String FormLink
        {
            get
            {
                return FormPage.FormLink;
            }
        }

        public IList<Group> Roles
        {
            get
            {
                return FormPage.Roles;
            }
        }

        internal void LoadData()
        {
            LoadForm();
            SetEnabledState(FormPage.EnableEdit);
        }

        internal void SaveData()
        {
            SaveForm();
        }

        internal void SaveDefaultData()
        {
            SaveDefault();
        }

        private FormEntry FormPage
        {
            get
            {
                return this.Page as FormEntry;
            }
        }

        protected abstract void LoadForm();

        protected abstract void SaveForm();

        protected virtual void SaveDefault()
        {

        }

        internal abstract void SetEnabledState(Boolean enabled);

        protected void ReloadForm()
        {
            FormPage.LoadForm(true);
        }

        protected void HandleException(Exception ex)
        {
            FormPage.HandleException(ex);
        }

        protected void ShowNotice(String message, NoticeType noticeType)
        {
            FormPage.ShowNotice(message, noticeType);
        }
    }
}