using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Business.Workflow;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views.Pages;

namespace USAACE.eStaffing.Presentation.Presenters.Pages
{
    public class ActionsPresenter : BasePresenter
    {
        /// <summary>
        /// The IActionsView for the ActionsPresenter
        /// </summary>
        private new IActionsView View
        {
            get
            {
                return base.View as IActionsView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IActionsView
        /// </summary>
        /// <param name="view">The IActionsView</param>
        public ActionsPresenter(IActionsView view)
        {
            base.View = view;
        }

        public void Load()
        {
            if (this.View.Roles != null && this.View.Roles.Count > 0)
            {
                IList<OrganizationGroup> userOrganizationGroups = DataService.ListOrganizationGroupsForGroups(this.View.Roles);

                IList<Form> forms = ReportUtil.GetUserForms(new List<Nullable<Int32>> { FormStatusConstants.ACTIVE }, null);

                this.View.ReviewForms = ReportUtil.GetUserReviewForms(forms, userOrganizationGroups, true, "Suspense", SortDirectionConstants.ASCENDING);
            }
        }
    }
}
