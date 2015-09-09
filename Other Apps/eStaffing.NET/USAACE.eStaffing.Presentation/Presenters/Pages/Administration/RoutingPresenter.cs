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
    public class RoutingPresenter : BasePresenter
    {
        /// <summary>
        /// The IRoutingView for the FormSettingsPresenter
        /// </summary>
        private new IRoutingView View
        {
            get
            {
                return base.View as IRoutingView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IFormSettingsView
        /// </summary>
        /// <param name="view">The IFormSettingsView</param>
        public RoutingPresenter(IRoutingView view)
        {
            base.View = view;
        }

        public void Load()
        {
            IList<Organization> organizationList = DataService.GetOrganizations().Where(x => PermissionUtil.CheckOrganizationViewPermission(x, this.View.Roles)).OrderBy(x => x.OrganizationName).ToList();
            
            if (organizationList.Count > 0)
            {
                this.View.Organizations = organizationList;
                this.View.FormTypes = DataService.GetFormTypes();

                LoadOrganizationFormType();
            }
            else
            {
                throw new USAACEException(ExceptionType.Unrecoverable, MessageConstants.NOT_ALLOWED_ADMIN);
            }
        }

        public void LoadOrganizationFormType()
        {
            if (this.View.SelectedOrganization.HasValue && this.View.SelectedFormType.HasValue)
            {
                IList<ReviewRole> reviewRoles = DataService.GetReviewRoles();

                OrganizationFormRouting formRouting = new OrganizationFormRouting();
                formRouting.OrganizationID = this.View.SelectedOrganization;
                formRouting.FormTypeID = this.View.SelectedFormType;

                IList<OrganizationFormRouting> formRoutings = DataService.ListOrganizationFormRoutings(formRouting)
                    .OrderBy(x => x.RoutingName != RoutingConstants.DEFAULT_ROUTING_CHAIN).ThenBy(x => x.RoutingName).ToList();

                if (formRoutings.Any(x => x.RoutingName == RoutingConstants.DEFAULT_ROUTING_CHAIN) == false)
                {
                    OrganizationFormRouting defaultFormRouting = new OrganizationFormRouting();
                    defaultFormRouting.OrganizationID = this.View.SelectedOrganization;
                    defaultFormRouting.FormTypeID = this.View.SelectedFormType;
                    defaultFormRouting.RoutingName = RoutingConstants.DEFAULT_ROUTING_CHAIN;
                    defaultFormRouting.OrganizationFormRoutingID = -1;

                    formRoutings.Add(defaultFormRouting);
                }

                IList<OrganizationGroup> userOrganizationGroups = DataService.ListOrganizationGroupsForGroups(this.View.Roles);

                Organization organization = new Organization { OrganizationID = this.View.SelectedOrganization };
                FormType formType = new FormType { FormTypeID = this.View.SelectedFormType };

                Boolean enableEdit = PermissionUtil.CheckReviewAdminPermission(organization, formType, this.View.Roles, userOrganizationGroups);

                OrganizationFormType organizationFormType = DataService.GetOrganizationFormType(new OrganizationFormType { FormTypeID = this.View.SelectedFormType, OrganizationID = this.View.SelectedOrganization });

                foreach (OrganizationFormRouting routing in formRoutings)
                {
                    OrganizationFormReviewer reviewer = new OrganizationFormReviewer();
                    reviewer.OrganizationFormRoutingID = routing.OrganizationFormRoutingID;

                    IList<OrganizationFormReviewer> routingReviewers = DataService.ListOrganizationFormRoutingReviewers(reviewer).OrderBy(x => x.ReviewOrder).ToList();

                    foreach (OrganizationFormReviewer routingReviewer in routingReviewers)
                    {
                        routingReviewer.ExtendedProperties.ReviewRoles = reviewRoles;
                        routingReviewer.ExtendedProperties.CanMove = organizationFormType.ParallelReview != true;
                        routingReviewer.ExtendedProperties.OrganizationGroupName = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = routingReviewer.ReviewerGroupID }).OrganizationGroupName;
                        routingReviewer.ExtendedProperties.ReviewRoleName = DataService.GetReviewRole(new ReviewRole { ReviewRoleID = routingReviewer.ReviewRoleID }).ReviewRoleName;
                    }

                    if (routingReviewers.Count > 0)
                    {
                        routingReviewers.First().ExtendedProperties.IsFirst = true;
                        routingReviewers.Last().ExtendedProperties.IsLast = true;
                    }

                    routing.ExtendedProperties.Reviewers = routingReviewers;
                    routing.ExtendedProperties.RoutingReviewers = String.Join("; ", routingReviewers.Select(x => x.ExtendedProperties.OrganizationGroupName));
                }

                this.View.RoutingChains = formRoutings;

                IList<OrganizationFormRouting> routings = this.View.RoutingChains;

                OrganizationForwarding formForwarding = new OrganizationForwarding();
                formForwarding.ReceiveOrganizationID = this.View.SelectedOrganization;
                formForwarding.FormTypeID = this.View.SelectedFormType;

                IList<OrganizationForwarding> formForwardings = DataService.ListOrganizationForwardings(formForwarding);

                foreach (OrganizationForwarding forward in formForwardings)
                {
                    forward.ExtendedProperties.OrganizationName = DataService.GetOrganization(new Organization { OrganizationID = forward.ForwardOrganizationID }).OrganizationName;
                    forward.ExtendedProperties.RoutingName = routings.FirstOrDefault(x => x.OrganizationFormRoutingID == forward.OrganizationFormRoutingID).RoutingName;
                }

                this.View.OrganizationForwards = formForwardings;

                this.View.ForwardOrganizations = DataService.GetOrganizations().Where(x => x.OrganizationID != this.View.SelectedOrganization).ToList();
                
                IList<OrganizationFormActor> formActors = DataService.GetOrganizationFormActorByOrganizationFormType(organization, formType).Where(x => x.CanReview == true).ToList();

                foreach (OrganizationFormActor actor in formActors)
                {
                    actor.ExtendedProperties.OrganizationGroupName = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = actor.OrganizationGroupID }).OrganizationGroupName;
                }

                this.View.ReviewOrderGroups = formActors;

                this.View.EnableEdit = enableEdit;
            }

            this.View.ShowData = this.View.SelectedOrganization.HasValue && this.View.SelectedFormType.HasValue;
        }

        public void EditRoutingChain()
        {
            if (this.View.SelectedReviewRoutingID.HasValue)
            {
                OrganizationFormRouting routing = this.View.RoutingChains.FirstOrDefault(x => x.OrganizationFormRoutingID == this.View.SelectedReviewRoutingID);

                this.View.RoutingChainName = routing.RoutingName;
                this.View.ReviewOrders = routing.ExtendedProperties.Reviewers;
            }
            else
            {
                this.View.RoutingChainName = null;
                this.View.ReviewOrders = new List<OrganizationFormReviewer>();
            }

            this.View.ReviewOrderRoles = DataService.GetReviewRoles();
        }

        public void DeleteRoutingChain()
        {
            if (this.View.SelectedReviewRoutingID.HasValue)
            {
                IList<OrganizationFormRouting> routingChains = this.View.RoutingChains;

                OrganizationFormRouting routingChain = routingChains.FirstOrDefault(x => x.OrganizationFormRoutingID == this.View.SelectedReviewRoutingID);
                routingChain.ExtendedProperties.MarkForDeletion = true;

                this.View.RoutingChains = routingChains;
            }
        }

        public void SaveRoutingChain()
        {
            IList<OrganizationFormRouting> routingChains = this.View.RoutingChains;
            IList<OrganizationFormReviewer> routingReviewers = this.View.ReviewOrders;

            if (this.View.SelectedReviewRoutingID.HasValue)
            {
                OrganizationFormRouting routing = routingChains.FirstOrDefault(x => x.OrganizationFormRoutingID == this.View.SelectedReviewRoutingID);

                routing.RoutingName = this.View.RoutingChainName;
                routing.ExtendedProperties.RoutingReviewers = String.Join("; ", routingReviewers.Where(x => x.ExtendedProperties.MarkForDeletion != true).Select(x => x.ExtendedProperties.OrganizationGroupName));
                routing.ExtendedProperties.Reviewers = routingReviewers;
            }
            else
            {
                OrganizationFormRouting routing = new OrganizationFormRouting();

                Int32 newId = -1 * routingChains.Count(x => x.OrganizationFormRoutingID < 0) - 1;
                routing.OrganizationFormRoutingID = newId;
                routing.OrganizationID = this.View.SelectedOrganization;
                routing.FormTypeID = this.View.SelectedFormType;
                routing.RoutingName = this.View.RoutingChainName;
                routing.ExtendedProperties.RoutingReviewers = String.Join("; ", routingReviewers.Where(x => x.ExtendedProperties.MarkForDeletion != true).Select(x => x.ExtendedProperties.OrganizationGroupName));
                routing.ExtendedProperties.Reviewers = routingReviewers;

                routingChains.Add(routing);
            }

            this.View.RoutingChains = routingChains;
        }

        public void MoveReviewOrderUp()
        {
            IList<OrganizationFormReviewer> reviewOrders = this.View.ReviewOrders;

            OrganizationFormReviewer reviewOrderToMove = reviewOrders.FirstOrDefault(x => x.OrganizationFormReviewerID == this.View.SelectedReviewOrderID);
            OrganizationFormReviewer otherReviewOrder = reviewOrders.FirstOrDefault(x => x.ReviewOrder == reviewOrderToMove.ReviewOrder - 1);

            reviewOrderToMove.ReviewOrder -= 1;
            otherReviewOrder.ReviewOrder += 1;

            reviewOrders = reviewOrders.OrderBy(x => x.ReviewOrder).ToList();

            reviewOrderToMove.ExtendedProperties.IsLast = null;
            otherReviewOrder.ExtendedProperties.IsFirst = null;

            if (reviewOrders.Count(x => x.ExtendedProperties.MarkForDeletion != true) > 0)
            {
                reviewOrders.First(x => x.ExtendedProperties.MarkForDeletion != true).ExtendedProperties.IsFirst = true;
                reviewOrders.Last(x => x.ExtendedProperties.MarkForDeletion != true).ExtendedProperties.IsLast = true;
            }

            this.View.ReviewOrders = reviewOrders;
        }

        public void MoveReviewOrderDown()
        {
            IList<OrganizationFormReviewer> reviewOrders = this.View.ReviewOrders;

            OrganizationFormReviewer reviewOrderToMove = reviewOrders.FirstOrDefault(x => x.OrganizationFormReviewerID == this.View.SelectedReviewOrderID);
            OrganizationFormReviewer otherReviewOrder = reviewOrders.FirstOrDefault(x => x.ReviewOrder == reviewOrderToMove.ReviewOrder + 1);

            reviewOrderToMove.ReviewOrder += 1;
            otherReviewOrder.ReviewOrder -= 1;

            reviewOrders = reviewOrders.OrderBy(x => x.ReviewOrder).ToList();

            reviewOrderToMove.ExtendedProperties.IsFirst = null;
            otherReviewOrder.ExtendedProperties.IsLast = null;

            if (reviewOrders.Count(x => x.ExtendedProperties.MarkForDeletion != true) > 0)
            {
                reviewOrders.First(x => x.ExtendedProperties.MarkForDeletion != true).ExtendedProperties.IsFirst = true;
                reviewOrders.Last(x => x.ExtendedProperties.MarkForDeletion != true).ExtendedProperties.IsLast = true;
            }

            this.View.ReviewOrders = reviewOrders;
        }

        public void DeleteReviewOrder()
        {
            IList<OrganizationFormReviewer> reviewOrders = this.View.ReviewOrders;

            OrganizationFormReviewer reviewOrderToDelete = reviewOrders.FirstOrDefault(x => x.OrganizationFormReviewerID == this.View.SelectedReviewOrderID);

            for (int i = reviewOrders.IndexOf(reviewOrderToDelete) + 1; i < reviewOrders.Count; i++)
            {
                reviewOrders[i].ReviewOrder -= 1;
            }

            reviewOrders = reviewOrders.OrderBy(x => x.ReviewOrder).ToList();

            reviewOrderToDelete.ExtendedProperties.MarkForDeletion = true;
            reviewOrderToDelete.ReviewOrder = null;
            reviewOrderToDelete.ExtendedProperties.IsFirst = null;
            reviewOrderToDelete.ExtendedProperties.IsLast = null;

            if (reviewOrders.Count(x => x.ExtendedProperties.MarkForDeletion != true) > 0)
            {
                reviewOrders.First(x => x.ExtendedProperties.MarkForDeletion != true).ExtendedProperties.IsFirst = true;
                reviewOrders.Last(x => x.ExtendedProperties.MarkForDeletion != true).ExtendedProperties.IsLast = true;
            }

            this.View.ReviewOrders = reviewOrders;
        }

        public void ChangeReviewOrderRole()
        {
            if (this.View.SelectedReviewOrderID.HasValue)
            {
                IList<OrganizationFormReviewer> reviewOrders = this.View.ReviewOrders;

                OrganizationFormReviewer reviewOrderToChange = reviewOrders.FirstOrDefault(x => x.OrganizationFormReviewerID == this.View.SelectedReviewOrderID);

                reviewOrderToChange.ReviewRoleID = this.View.SelectedReviewOrderRoleID;
                reviewOrderToChange.ExtendedProperties.ReviewRoleName = DataService.GetReviewRole(new ReviewRole { ReviewRoleID = reviewOrderToChange.ReviewRoleID }).ReviewRoleName;

                this.View.ReviewOrders = reviewOrders;
            }
        }

        public void AddReviewOrder()
        {
            if (this.View.SelectedReviewGroupsID.Count > 0)
            {
                OrganizationFormType organizationFormType = DataService.GetOrganizationFormType(new OrganizationFormType { FormTypeID = this.View.SelectedFormType, OrganizationID = this.View.SelectedOrganization });
                IList<ReviewRole> reviewRoles = DataService.GetReviewRoles();

                IList<OrganizationFormReviewer> reviewOrders = this.View.ReviewOrders.OrderBy(x => x.ReviewOrder).ToList();

                foreach (Nullable<Int32> reviewGroupId in this.View.SelectedReviewGroupsID)
                {
                    Int32 newId = -1 * reviewOrders.Count(x => x.OrganizationFormReviewerID < 0) - 1;

                    OrganizationFormReviewer reviewOrderToAdd = new OrganizationFormReviewer();

                    reviewOrderToAdd.OrganizationFormReviewerID = newId;
                    reviewOrderToAdd.OrganizationFormRoutingID = this.View.SelectedReviewRoutingID;
                    reviewOrderToAdd.ExtendedProperties.CanMove = organizationFormType.ParallelReview != true;
                    reviewOrderToAdd.ReviewerGroupID = reviewGroupId;
                    reviewOrderToAdd.ReviewRoleID = this.View.SelectedReviewRoleID;
                    reviewOrderToAdd.ReviewOrder = (Byte)(reviewOrders.Count(x => x.ExtendedProperties.MarkForDeletion != true) + 1);
                    reviewOrderToAdd.ExtendedProperties.IsFirst = reviewOrders.Count == 0;
                    reviewOrderToAdd.ExtendedProperties.IsLast = true;
                    reviewOrderToAdd.ExtendedProperties.OrganizationGroupName = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = reviewOrderToAdd.ReviewerGroupID }).OrganizationGroupName;
                    reviewOrderToAdd.ExtendedProperties.ReviewRoleName = DataService.GetReviewRole(new ReviewRole { ReviewRoleID = reviewOrderToAdd.ReviewRoleID }).ReviewRoleName;
                    reviewOrderToAdd.ExtendedProperties.ReviewRoles = reviewRoles;

                    if (reviewOrders.Count(x => x.ExtendedProperties.MarkForDeletion != true) > 0)
                    {
                        reviewOrders.Last(x => x.ExtendedProperties.MarkForDeletion != true).ExtendedProperties.IsLast = null;
                    }

                    reviewOrders.Add(reviewOrderToAdd);

                    if (reviewOrderToAdd.ExtendedProperties.CanMove != true)
                    {
                        Byte currentOrderValue = reviewOrders.First().ReviewOrder.GetValueOrDefault();

                        foreach (OrganizationFormReviewer reviewer in reviewOrders.Where(x => x.ExtendedProperties.MarkForDeletion != true).OrderBy(x => x.ExtendedProperties.OrganizationGroupName))
                        {
                            reviewer.ReviewOrder = currentOrderValue;
                            currentOrderValue += 1;
                        }
                    }
                }

                this.View.ReviewOrders = reviewOrders.OrderBy(x => x.ReviewOrder).ToList();

                this.View.SelectedReviewGroupsID = null;
            }
        }

        public void EditForwarding()
        {
            if (this.View.SelectedOrganizationForwardingID.HasValue)
            {
                OrganizationForwarding forward = this.View.OrganizationForwards.FirstOrDefault(x => x.OrganizationForwardingID == this.View.SelectedOrganizationForwardingID);

                this.View.ForwardRoutingChains = this.View.RoutingChains.Where(x => x.ExtendedProperties.MarkForDeletion != true).ToList();
                this.View.SelectedForwardOrganizationID = forward.ForwardOrganizationID;
                this.View.SelectedForwardRoutingID = forward.OrganizationFormRoutingID;
            }
            else
            {
                this.View.ForwardRoutingChains = this.View.RoutingChains.Where(x => x.ExtendedProperties.MarkForDeletion != true).ToList();
                this.View.SelectedForwardOrganizationID = null;
                this.View.SelectedForwardRoutingID = null;
            }
        }

        public void DeleteForwarding()
        {
            if (this.View.SelectedOrganizationForwardingID.HasValue)
            {
                IList<OrganizationForwarding> formForwardings = this.View.OrganizationForwards;

                OrganizationForwarding forward = formForwardings.FirstOrDefault(x => x.OrganizationForwardingID == this.View.SelectedOrganizationForwardingID);
                forward.ExtendedProperties.MarkForDeletion = true;

                this.View.OrganizationForwards = formForwardings;
            }
        }

        public void SaveForwarding()
        {
            IList<OrganizationForwarding> formForwardings = this.View.OrganizationForwards;

            if (this.View.SelectedOrganizationForwardingID.HasValue)
            {
                OrganizationForwarding forward = formForwardings.FirstOrDefault(x => x.OrganizationForwardingID == this.View.SelectedOrganizationForwardingID);

                forward.ForwardOrganizationID = this.View.SelectedForwardOrganizationID;
                forward.OrganizationFormRoutingID = this.View.SelectedForwardRoutingID;
                forward.ExtendedProperties.OrganizationName = DataService.GetOrganization(new Organization { OrganizationID = forward.ForwardOrganizationID }).OrganizationName;
                forward.ExtendedProperties.RoutingName = this.View.RoutingChains.FirstOrDefault(x => x.OrganizationFormRoutingID == forward.OrganizationFormRoutingID).RoutingName;
            }
            else
            {
                OrganizationForwarding forward = new OrganizationForwarding();

                Int32 newId = -1 * formForwardings.Count(x => x.OrganizationForwardingID < 0) - 1;
                forward.OrganizationForwardingID = newId;
                forward.ReceiveOrganizationID = this.View.SelectedOrganization;
                forward.FormTypeID = this.View.SelectedFormType;
                forward.ForwardOrganizationID = this.View.SelectedForwardOrganizationID;
                forward.OrganizationFormRoutingID = this.View.SelectedForwardRoutingID;
                forward.ExtendedProperties.OrganizationName = DataService.GetOrganization(new Organization { OrganizationID = forward.ForwardOrganizationID }).OrganizationName;
                forward.ExtendedProperties.RoutingName = this.View.RoutingChains.FirstOrDefault(x => x.OrganizationFormRoutingID == forward.OrganizationFormRoutingID).RoutingName;

                formForwardings.Add(forward);
            }

            this.View.OrganizationForwards = formForwardings;
        }

        public void SaveRouting()
        {
            IList<OrganizationFormRouting> routings = this.View.RoutingChains;
            IList<OrganizationForwarding> formForwardings = this.View.OrganizationForwards;

            foreach (OrganizationFormRouting routing in routings)
            {
                Int32 oldId = routing.OrganizationFormRoutingID.GetValueOrDefault(0);

                if (routing.OrganizationFormRoutingID < 0)
                {
                    routing.OrganizationFormRoutingID = null;
                }

                if (routing.ExtendedProperties.MarkForDeletion != true)
                {
                    DataService.SaveOrganizationFormRouting(routing);

                    if (oldId < 0)
                    {
                        foreach (OrganizationForwarding forward in formForwardings)
                        {
                            if (forward.OrganizationFormRoutingID == oldId)
                            {
                                forward.OrganizationFormRoutingID = routing.OrganizationFormRoutingID;
                            }
                        }
                    }

                    foreach (OrganizationFormReviewer reviewer in routing.ExtendedProperties.Reviewers)
                    {
                        if (reviewer.OrganizationFormReviewerID < 0)
                        {
                            reviewer.OrganizationFormReviewerID = null;
                        }

                        if (reviewer.ExtendedProperties.MarkForDeletion != true)
                        {
                            reviewer.OrganizationFormRoutingID = routing.OrganizationFormRoutingID;

                            DataService.SaveOrganizationFormReviewer(reviewer);
                        }
                        else if (reviewer.ExtendedProperties.MarkForDeletion == true && reviewer.OrganizationFormReviewerID.HasValue)
                        {
                            DataService.DeleteOrganizationFormReviewer(reviewer);
                        }
                    }
                }
                else if (routing.ExtendedProperties.MarkForDeletion == true && routing.OrganizationFormRoutingID.HasValue)
                {
                    DataService.DeleteOrganizationFormRouting(routing);
                }
            }

            foreach (OrganizationForwarding forward in formForwardings)
            {
                if (forward.OrganizationForwardingID < 0)
                {
                    forward.OrganizationForwardingID = null;
                }

                if (forward.ExtendedProperties.MarkForDeletion != true)
                {
                    DataService.SaveOrganizationForwarding(forward);
                }
                else if (forward.ExtendedProperties.MarkForDeletion == true && forward.OrganizationForwardingID.HasValue)
                {
                    DataService.DeleteOrganizationForwarding(forward);
                }
            }

            LoadOrganizationFormType();
        }
    }
}
