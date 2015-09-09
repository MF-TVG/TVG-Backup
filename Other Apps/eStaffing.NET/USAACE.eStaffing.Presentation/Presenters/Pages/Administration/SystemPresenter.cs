using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common;
using USAACE.Common.Exceptions;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views.Pages.Administration;

namespace USAACE.eStaffing.Presentation.Presenters.Pages.Administration
{
    public class SystemPresenter : BasePresenter
    {
        /// <summary>
        /// The ISystemView for the FormsPresenter
        /// </summary>
        private new ISystemView View
        {
            get
            {
                return base.View as ISystemView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the ISystemView
        /// </summary>
        /// <param name="view">The ISystemView</param>
        public SystemPresenter(ISystemView view)
        {
            base.View = view;
        }

        public void Load()
        {
            if (!PermissionUtil.CheckAdminPermission(this.View.Roles))
            {
                throw new USAACEException(ExceptionType.Unrecoverable, MessageConstants.NOT_ALLOWED_ADMIN);
            }
            else
            {
                this.View.FormTypeList = DataService.GetFormTypes().OrderBy(x => x.FormTypeName).ToList();
                this.View.FormActionTypes = DataService.GetFormActionTypes().OrderBy(x => x.FormActionTypeName).ToList();

                LoadFormType();
            }
        }

        public void ResetCache()
        {
            DataService.ResetCache();
        }

        public void LoadFormType()
        {
            if (this.View.FormTypeID.HasValue)
            {
                FormType formType = new FormType();
                formType.FormTypeID = this.View.FormTypeID;

                formType = DataService.GetFormType(formType);

                IList<String> stringFields = FormUtil.GetFormTypeFieldsByType(formType, typeof(String));

                this.View.SuspenseDateFields = FormUtil.GetFormTypeFieldsByType(formType, typeof(Nullable<DateTime>));
                this.View.SubjectFields = stringFields;
                this.View.FormNumberFields = stringFields;

                this.View.FormTypeName = formType.FormTypeName;
                this.View.SelectedSuspenseDateField = formType.SuspenseDateField;
                this.View.SelectedSubjectField = formType.SubjectField;
                this.View.SelectedFormNumberField = formType.FormNumberField;
                this.View.SelectedFormActionType = formType.FormActionTypeID;
            }
            else
            {
                this.View.FormTypeName = null;
                this.View.SelectedSuspenseDateField = null;
                this.View.SelectedSubjectField = null;
                this.View.SelectedFormNumberField = null;
                this.View.SelectedFormActionType = null;
            }
        }

        public void Save()
        {
            FormType formType = new FormType();

            if (this.View.FormTypeID.HasValue)
            {
                formType.FormTypeID = this.View.FormTypeID;
                formType = DataService.GetFormType(formType);
            }

            formType.FormTypeName = this.View.FormTypeName;
            formType.SuspenseDateField = this.View.SelectedSuspenseDateField;
            formType.SubjectField = this.View.SelectedSubjectField;
            formType.FormNumberField = this.View.SelectedFormNumberField;
            formType.FormActionTypeID = this.View.SelectedFormActionType;

            formType = DataService.SaveFormType(formType);

            this.View.FormTypeList = DataService.GetFormTypes().OrderBy(x => x.FormTypeName).ToList();
            this.View.FormTypeID = formType.FormTypeID;

            LoadFormType();
        }
    }
}
