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
    public class NewFormPresenter : BasePresenter
    {
        /// <summary>
        /// The INewFormView for the NewFormPresenter
        /// </summary>
        private new INewFormView View
        {
            get
            {
                return base.View as INewFormView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the INewFormView
        /// </summary>
        /// <param name="view">The IFormEntryView</param>
        public NewFormPresenter(INewFormView view)
        {
            base.View = view;
        }

        public void Load()
        {
            IList<OrganizationGroup> userOrganizationGroups = DataService.ListOrganizationGroupsForGroups(this.View.Roles);
            IList<FormType> formTypes = DataService.GetFormTypes().OrderBy(x => x.FormTypeName).ToList();

            IList<FormType> allowedFormTypes = formTypes.Where(x => PermissionUtil.CheckFormNewSubmitPermission(x, userOrganizationGroups).Count > 0).ToList();

            if (allowedFormTypes.Count > 0)
            {
                this.View.FormTypes = allowedFormTypes;

                LoadSubmitGroups();
            }
            else
            {
                throw new USAACEException(ExceptionType.Unrecoverable, MessageConstants.NOT_ALLOWED_SUBMIT_FORM);
            }
        }

        public void LoadSubmitGroups()
        {
            IList<OrganizationGroup> userOrganizationGroups = DataService.ListOrganizationGroupsForGroups(this.View.Roles);

            FormType formType = new FormType();
            formType.FormTypeID = this.View.SelectedFormTypeID;

            this.View.SubmitGroups = PermissionUtil.CheckFormNewSubmitPermission(formType, userOrganizationGroups);

            LoadRoutingChains();
        }

        public void LoadRoutingChains()
        {
            if (this.View.SelectedSubmitGroupID.HasValue && this.View.SelectedFormTypeID.HasValue)
            {
                OrganizationGroup submitter = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = this.View.SelectedSubmitGroupID });
                Organization submitTo = DataService.GetOrganization(new Organization { OrganizationID = submitter.OrganizationID });

                this.View.SubmitOrganization = submitTo.OrganizationName;

                OrganizationFormRouting formRouting = new OrganizationFormRouting();
                formRouting.OrganizationID = submitTo.OrganizationID;
                formRouting.FormTypeID = this.View.SelectedFormTypeID;

                FormType formType = new FormType();
                formType.FormTypeID = this.View.SelectedFormTypeID;

                IList<OrganizationFormRouting> formRoutings = DataService.ListOrganizationFormRoutings(formRouting)
                    .OrderBy(x => x.RoutingName != RoutingConstants.DEFAULT_ROUTING_CHAIN).ThenBy(x => x.RoutingName).ToList();

                Boolean canChoose = PermissionUtil.CheckAdminPermission(this.View.Roles) || PermissionUtil.CheckFormChooseRoutingPermission(formType, this.View.Roles, submitter);

                foreach (OrganizationFormRouting routing in formRoutings)
                {
                    OrganizationFormReviewer reviewer = new OrganizationFormReviewer();
                    reviewer.OrganizationFormRoutingID = routing.OrganizationFormRoutingID;

                    IList<OrganizationFormReviewer> routingReviewers = DataService.ListOrganizationFormRoutingReviewers(reviewer).OrderBy(x => x.ReviewOrder).ToList();

                    foreach (OrganizationFormReviewer routingReviewer in routingReviewers)
                    {
                        routingReviewer.ExtendedProperties.OrganizationGroupName = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = routingReviewer.ReviewerGroupID }).OrganizationGroupName;
                    }

                    routing.ExtendedProperties.RoutingNameAndReviewers = String.Format("{0} ({1})", routing.RoutingName, String.Join("; ", routingReviewers.Select(x => x.ExtendedProperties.OrganizationGroupName)));
                }

                this.View.RoutingChains = canChoose ? formRoutings : formRoutings.Where(x => x.RoutingName == RoutingConstants.DEFAULT_ROUTING_CHAIN).ToList();
            }
        }

        public void Save()
        {
            Form form = new Form();
            form.FormTypeID = this.View.SelectedFormTypeID;
            form.Submitted = false;
            form.HighPriority = false;
            form.FormStatusID = FormStatusConstants.DRAFT;
            form.SubmitterGroupID = this.View.SelectedSubmitGroupID;
            form = DataService.SaveForm(form);

            FormUtil.CreateNewFormData(form);

            OrganizationFormRouting formRouting = new OrganizationFormRouting();
            formRouting.OrganizationFormRoutingID = this.View.SelectedRoutingID;

            formRouting = DataService.LoadOrganizationFormRouting(formRouting);

            OrganizationFormReviewer formReviewer = new OrganizationFormReviewer();
            formReviewer.OrganizationFormRoutingID = formRouting.OrganizationFormRoutingID;

            IList<OrganizationFormReviewer> routingReviewers = DataService.ListOrganizationFormRoutingReviewers(formReviewer).OrderBy(x => x.ReviewOrder).ToList();

            foreach (OrganizationFormReviewer reviewer in routingReviewers)
            {
                ReviewStatus status = new ReviewStatus();
                status.FormID = form.FormID;
                status.OrganizationID = formRouting.OrganizationID;
                status.ReviewOrder = reviewer.ReviewOrder;
                status.ReviewerGroupID = reviewer.ReviewerGroupID;
                status.ReviewRoleID = reviewer.ReviewRoleID;
                status.Notified = false;
                status.Signed = false;
                status.Autopen = false;

                DataService.SaveReviewStatus(status);
            }

            this.View.FormID = form.FormID;
        }
    }
}
