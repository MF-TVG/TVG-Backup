using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views.Pages.Administration;

namespace USAACE.eStaffing.Presentation.Presenters.Pages.Administration
{
    public class FormSettingsPresenter : BasePresenter
    {
        /// <summary>
        /// The IFormSettingsView for the FormSettingsPresenter
        /// </summary>
        private new IFormSettingsView View
        {
            get
            {
                return base.View as IFormSettingsView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IFormSettingsView
        /// </summary>
        /// <param name="view">The IFormSettingsView</param>
        public FormSettingsPresenter(IFormSettingsView view)
        {
            base.View = view;
        }

        public void Load()
        {
            this.View.Organizations = DataService.ListOrganizations();
            this.View.FormTypes = DataService.GetFormTypes();

            LoadOrganizationFormType();
        }

        public void LoadOrganizationFormType()
        {
            if (this.View.SelectedOrganization.HasValue && this.View.SelectedFormType.HasValue)
            {
                OrganizationFormType organizationFormType = new OrganizationFormType();
                organizationFormType.OrganizationID = this.View.SelectedOrganization;
                organizationFormType.FormTypeID = this.View.SelectedFormType;

                organizationFormType = DataService.GetOrganizationFormType(organizationFormType);

                this.View.ParallelReview = organizationFormType.ParallelReview;
                this.View.NearDueDays = organizationFormType.NearDueDays;
                this.View.PastDueDays = organizationFormType.PastDueDays;
                this.View.SuspenseAdjust = organizationFormType.SuspenseAdjust;
                this.View.ReviewSubject = organizationFormType.NotifyReviewSubject;
                this.View.ReviewMessage = organizationFormType.NotifyReviewMessage;
                this.View.RejectSubject = organizationFormType.NotifyRejectSubject;
                this.View.RejectMessage = organizationFormType.NotifyRejectMessage;
                this.View.CompleteSubject = organizationFormType.NotifyCompleteSubject;
                this.View.CompleteMessage = organizationFormType.NotifyCompleteMessage;
                
                IList<OrganizationGroup> userOrganizationGroups = DataService.ListOrganizationGroupsForGroups(this.View.Roles);

                Organization organization = new Organization { OrganizationID = this.View.SelectedOrganization };
                FormType formType = new FormType { FormTypeID = this.View.SelectedFormType };

                Boolean enableEdit = PermissionUtil.CheckReviewAdminPermission(organization, formType, this.View.Roles, userOrganizationGroups);

                OrganizationFormActor actor = new OrganizationFormActor();
                actor.OrganizationID = this.View.SelectedOrganization;
                actor.FormTypeID = this.View.SelectedFormType;

                IList<OrganizationFormActor> actors = DataService.ListOrganizationFormActors(actor, true);

                foreach (OrganizationFormActor actorItem in actors)
                {
                    actorItem.ExtendedProperties.OrganizationGroupName = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = actorItem.OrganizationGroupID }).OrganizationGroupName;
                }

                this.View.Actors = actors.OrderBy(x => x.ExtendedProperties.OrganizationGroupName).ToList();

                this.View.EnableEdit = enableEdit;
            }

            this.View.ShowData = this.View.SelectedOrganization.HasValue && this.View.SelectedFormType.HasValue;
        }

        public void LoadSelectedActor()
        {
            if (this.View.SelectedFormActorID.HasValue)
            {
                OrganizationFormActor actor = this.View.Actors.FirstOrDefault(x => x.OrganizationFormActorID == this.View.SelectedFormActorID);

                this.View.SelectedFormActorName = actor.ExtendedProperties.OrganizationGroupName;
                this.View.CanAdmin = actor.CanAdmin;
                this.View.CanSubmit = actor.CanSubmit;
                this.View.CanReview = actor.CanReview;
                this.View.CanChooseRoute = actor.CanChooseRoute;
                this.View.CanChangeRoute = actor.CanChangeRoute;
                this.View.CanEditSubmission = actor.CanEditSubmission;
                this.View.CanForward = actor.CanForward;
                this.View.CanSeeComments = actor.CanSeeComments;
                this.View.CanViewAll = actor.CanView;
                this.View.CanAssignAutopen = actor.CanAssignAutopen;
                this.View.MustReview = actor.MustReview;
                this.View.NotifyComplete = actor.NotifyComplete;
            }
        }

        public void SaveSelectedActor()
        {
            if (this.View.SelectedFormActorID.HasValue)
            {
                IList<OrganizationFormActor> actors = this.View.Actors;

                OrganizationFormActor actor = this.View.Actors.FirstOrDefault(x => x.OrganizationFormActorID == this.View.SelectedFormActorID);

                actor.CanAdmin = this.View.CanAdmin;
                actor.CanSubmit = this.View.CanSubmit;
                actor.CanReview = this.View.CanReview;
                actor.CanChooseRoute = this.View.CanChooseRoute;
                actor.CanChangeRoute = this.View.CanChangeRoute;
                actor.CanEditSubmission = this.View.CanEditSubmission;
                actor.CanForward = this.View.CanForward;
                actor.CanSeeComments = this.View.CanSeeComments;
                actor.CanView = this.View.CanViewAll;
                actor.CanAssignAutopen = this.View.CanAssignAutopen;
                actor.MustReview = this.View.MustReview;
                actor.NotifyComplete = this.View.NotifyComplete;

                this.View.Actors = actors;
            }
        }

        public void LoadSelectedMessage()
        {
            if (!String.IsNullOrEmpty(this.View.SelectedNoticeType))
            {
                switch (this.View.SelectedNoticeType)
                {
                    case "Review":
                        this.View.EditSubject = this.View.ReviewSubject;
                        this.View.EditMessage = this.View.ReviewMessage;
                        break;
                    case "Rejection":
                        this.View.EditSubject = this.View.RejectSubject;
                        this.View.EditMessage = this.View.RejectMessage;
                        break;
                    case "Completion":
                        this.View.EditSubject = this.View.CompleteSubject;
                        this.View.EditMessage = this.View.CompleteMessage;
                        break;
                }
            }
        }

        public void SaveSelectedMessage()
        {
            if (!String.IsNullOrEmpty(this.View.SelectedNoticeType))
            {
                switch (this.View.SelectedNoticeType)
                {
                    case "Review":
                        this.View.ReviewSubject = this.View.EditSubject;
                        this.View.ReviewMessage = this.View.EditMessage;
                        break;
                    case "Rejection":
                        this.View.RejectSubject = this.View.EditSubject;
                        this.View.RejectMessage = this.View.EditMessage;
                        break;
                    case "Completion":
                        this.View.CompleteSubject = this.View.EditSubject;
                        this.View.CompleteMessage = this.View.EditMessage;
                        break;
                }
            }
        }

        public void Save()
        {
            if (this.View.SelectedOrganization.HasValue && this.View.SelectedFormType.HasValue)
            {
                OrganizationFormType formType = new OrganizationFormType();
                formType.OrganizationID = this.View.SelectedOrganization;
                formType.FormTypeID = this.View.SelectedFormType;

                formType = DataService.GetOrganizationFormType(formType);

                formType.ParallelReview = this.View.ParallelReview;
                formType.NearDueDays = this.View.NearDueDays;
                formType.PastDueDays = this.View.PastDueDays;
                formType.SuspenseAdjust = this.View.SuspenseAdjust;
                formType.NotifyReviewSubject = this.View.ReviewSubject;
                formType.NotifyReviewMessage = this.View.ReviewMessage;
                formType.NotifyRejectSubject = this.View.RejectSubject;
                formType.NotifyRejectMessage = this.View.RejectMessage;
                formType.NotifyCompleteSubject = this.View.CompleteSubject;
                formType.NotifyCompleteMessage = this.View.CompleteMessage;

                DataService.SaveOrganizationFormType(formType);

                foreach (OrganizationFormActor actor in this.View.Actors)
                {
                    DataService.SaveOrganizationFormActor(actor);
                }
            }

            LoadOrganizationFormType();
        }
    }
}
