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
    public class DashboardPresenter : BasePresenter
    {
        /// <summary>
        /// The IDashboardView for the DashboardPresenter
        /// </summary>
        private new IDashboardView View
        {
            get
            {
                return base.View as IDashboardView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IDashboardView
        /// </summary>
        /// <param name="view">The IDashboardView</param>
        public DashboardPresenter(IDashboardView view)
        {
            base.View = view;
        }

        public void LoadLookups()
        {
            IList<FormStatus> formStatuses = DataService.GetFormStatuses();
            formStatuses.First(x => x.FormStatusID == FormStatusConstants.ACTIVE).ExtendedProperties.Preselected = true;
            formStatuses.First(x => x.FormStatusID == FormStatusConstants.DRAFT).ExtendedProperties.Preselected = true;

            this.View.FormStatuses = formStatuses;
        }

        public void Load()
        {
            IList<OrganizationGroup> userOrganizationGroups = DataService.ListOrganizationGroupsForGroups(this.View.Roles);

            if (userOrganizationGroups.Count > 0)
            {
                IList<Form> forms = ReportUtil.GetUserForms(this.View.SelectedFormStatuses, this.View.SubjectFilter);

                this.View.SubmitForms = ReportUtil.GetUserSubmittedForms(forms, userOrganizationGroups, this.View.SortField, this.View.SortDirection);
                this.View.ReviewForms = ReportUtil.GetUserReviewForms(forms, userOrganizationGroups, this.View.MyReviewOnly, this.View.SortField, this.View.SortDirection);
            }
            else
            {
                throw new USAACEException(ExceptionType.Unrecoverable, MessageConstants.NOT_ALLOWED_ADMIN);
            }
        }
    }
}
