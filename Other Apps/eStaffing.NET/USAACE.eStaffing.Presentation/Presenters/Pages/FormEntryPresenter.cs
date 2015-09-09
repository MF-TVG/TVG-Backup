using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Exceptions;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Business.Workflow;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views.Pages;

namespace USAACE.eStaffing.Presentation.Presenters.Pages
{
    public class FormEntryPresenter : BasePresenter
    {
        /// <summary>
        /// The IFormEntryView for the FormEntryPresenter
        /// </summary>
        private new IFormEntryView View
        {
            get
            {
                return base.View as IFormEntryView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IFormEntryView
        /// </summary>
        /// <param name="view">The IFormEntryView</param>
        public FormEntryPresenter(IFormEntryView view)
        {
            base.View = view;
        }

        public void Initialize()
        {
            if (this.View.FormTypeID.HasValue)
            {
                FormType formType = DataService.GetFormType(new FormType { FormTypeID = this.View.FormTypeID });

                this.View.ControlName = formType.PageName;
                this.View.FormTitle = formType.FormTypeName;
            }
            else if (this.View.FormID.HasValue)
            {
                Form form = new Form();
                form.FormID = this.View.FormID;
                form = DataService.LoadForm(form);

                if (form != null)
                {
                    FormType formType = DataService.GetFormType(new FormType { FormTypeID = form.FormTypeID });

                    this.View.FormTypeID = form.FormTypeID;
                    this.View.ControlName = formType.PageName;
                    this.View.FormTitle = formType.FormTypeName;
                }
                else
                {
                    throw new USAACEException(ExceptionType.Unrecoverable, MessageConstants.NOT_ALLOWED_VIEW_FORM);
                }
            }
            else
            {
                throw new USAACEException(ExceptionType.Unrecoverable, MessageConstants.INVALID_FORM_TYPE);
            }
        }

        public void Load()
        {
            Boolean isAdmin = PermissionUtil.CheckAdminPermission(this.View.Roles);

            IList<OrganizationGroup> userOrganizationGroups = DataService.ListOrganizationGroupsForGroups(this.View.Roles);

            Form form = new Form();
            form.FormID = this.View.FormID;
            form = DataService.LoadForm(form);

            this.View.FormNumber = form.FormNumber;

            OrganizationGroup group = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = form.SubmitterGroupID });

            this.View.SubmitGroupName = group.OrganizationGroupName;
            this.View.SubmitGroupID = group.OrganizationGroupID;

            Organization submitOrganization = DataService.GetOrganization(new Organization { OrganizationID = group.OrganizationID });

            this.View.SubmitOrganizationID = submitOrganization.OrganizationID;

            ReviewStatus reviewStatus = new ReviewStatus();
            reviewStatus.FormID = this.View.FormID;

            IList<ReviewStatus> reviewStatuses = DataService.ListReviewStatuses(reviewStatus).OrderBy(x => x.ReviewOrder).ToList();

            FormType formType = new FormType { FormTypeID = form.FormTypeID };

            Boolean hasPermission = isAdmin || (form.FormStatusID != FormStatusConstants.CANCELLED &&
                PermissionUtil.CheckFormViewPermission(form, formType, reviewStatuses, this.View.Roles, userOrganizationGroups));

            if (hasPermission)
            {
                this.View.Submitted = form.Submitted;
                this.View.HighPriority = form.HighPriority;

                Boolean canEdit = form.FormStatusID != FormStatusConstants.CANCELLED && (isAdmin || (form.FormStatusID != FormStatusConstants.ARCHIVED &&
                    PermissionUtil.CheckFormCurrentEditPermission(form, formType, reviewStatuses, this.View.Roles, userOrganizationGroups)));

                this.View.EnableUndelete = form.FormStatusID == FormStatusConstants.CANCELLED && isAdmin;
                this.View.EnableDelete = form.FormStatusID != FormStatusConstants.CANCELLED && (isAdmin || form.Submitted == false) && canEdit;
                this.View.EnableEdit = form.FormStatusID != FormStatusConstants.CANCELLED && canEdit;
                this.View.EnableSubmit = form.FormStatusID != FormStatusConstants.CANCELLED && form.Submitted == false && canEdit;
                this.View.EnableImport = form.FormStatusID != FormStatusConstants.CANCELLED && form.Submitted == false && canEdit;
            }
            else
            {
                throw new USAACEException(ExceptionType.Unrecoverable, MessageConstants.NOT_ALLOWED_VIEW_FORM);
            }
        }

        public void Save()
        {
            Form form = new Form();
            form.FormID = this.View.FormID;

            form = DataService.LoadForm(form);

            form.Submitted = this.View.Submitted;

            if (this.View.Submitted == true && form.FormStatusID == FormStatusConstants.DRAFT)
            {
                form.FormStatusID = FormStatusConstants.ACTIVE;
            }

            form.HighPriority = this.View.HighPriority;
            form.ExtendedProperties.ActingUser = this.View.DisplayName;
            form = DataService.SaveForm(form);

            if (form.Submitted == true)
            {
                form.ExtendedProperties.FormLink = this.View.FormLink;

                FormWorkflow.RunWorkflow(form, null);
            }
        }

        public void Delete()
        {
            Form form = new Form();
            form.FormID = this.View.FormID;
            form.ExtendedProperties.ActingUser = this.View.DisplayName;

            DataService.MarkCancelForm(form);
        }

        public void Undelete()
        {
            Form form = new Form();
            form.FormID = this.View.FormID;
            form.ExtendedProperties.ActingUser = this.View.DisplayName;

            DataService.UnmarkCancelForm(form);
        }

        public void BeginImport()
        {
            this.View.ImportSearch = null;
            this.View.ImportIncludeAttachments = false;

            ImportSearch();
        }

        public void ImportSearch()
        {
            this.View.ImportForms = SearchUtil.SearchFormsBasic(this.View.ImportSearch, this.View.FormTypeID, this.View.Roles).Where(x => x.FormID != this.View.FormID).ToList();
        }

        public void ExecuteImport()
        {
            if (this.View.SelectedImportFormID.HasValue)
            {
                Form sourceForm = new Form();
                sourceForm.FormID = this.View.SelectedImportFormID;

                sourceForm = DataService.LoadForm(sourceForm);

                Form destinationForm = new Form();
                destinationForm.FormID = this.View.FormID;

                destinationForm = DataService.LoadForm(destinationForm);

                ImportUtil.CopyForm(sourceForm, destinationForm, this.View.ImportIncludeAttachments == true);
            }
        }
    }
}
