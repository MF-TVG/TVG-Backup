using System;
using System.Collections.Generic;
using System.Linq;
using USAACE.Common;
using USAACE.Common.Exceptions;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Business.Workflow;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views.Controls.FormControls;

namespace USAACE.eStaffing.Presentation.Presenters.Controls.FormControls
{
    public class ReviewerControlPresenter : BasePresenter
    {
        /// <summary>
        /// The IFileControlView for the FileControlPresenter
        /// </summary>
        private new IReviewerControlView View
        {
            get
            {
                return base.View as IReviewerControlView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IReviewerControlView
        /// </summary>
        /// <param name="view">The IReviewerControlView</param>
        public ReviewerControlPresenter(IReviewerControlView view)
        {
            base.View = view;
        }

        public void Load()
        {
            LoadReviewData();

            ChangeReviewTab();
        }

        public void LoadReviewData()
        {
            if (this.View.FormID.HasValue)
            {
                IList<ReviewRole> reviewRoles = DataService.GetReviewRoles();

                Form form = new Form();
                form.FormID = this.View.FormID;

                form = DataService.LoadForm(form);

                FormAttachment formAttachment = new FormAttachment();
                formAttachment.FormID = this.View.FormID;

                IList<FormAttachment> attachments = DataService.ListFormAttachments(formAttachment);

                FormType formType = DataService.GetFormType(new FormType { FormTypeID = this.View.FormTypeID });
                OrganizationGroup submitter = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = form.SubmitterGroupID });
                OrganizationFormType organizationFormType = DataService.GetOrganizationFormType(new OrganizationFormType { FormTypeID = form.FormTypeID, OrganizationID = submitter.OrganizationID });

                IList<OrganizationGroup> userOrganizationGroups = DataService.ListOrganizationGroupsForGroups(this.View.Roles);

                ReviewStatus reviewStatus = new ReviewStatus();
                reviewStatus.FormID = this.View.FormID;

                IList<ReviewStatus> reviewStatuses = DataService.ListReviewStatuses(reviewStatus).OrderBy(x => x.ReviewOrder).ToList();

                IList<Organization> reviewOrganizations = new List<Organization>();
                IDictionary<String, IList<ReviewStatus>> reviewStatusDictionary = new Dictionary<String, IList<ReviewStatus>>();

                Organization currentOrganization = null;

                Int32 organizationCount = 1;
                String organizationKey = null;

                foreach (ReviewStatus status in reviewStatuses)
                {
                    OrganizationFormType statusOrganizationFormType = DataService.GetOrganizationFormType(new OrganizationFormType { FormTypeID = form.FormTypeID, OrganizationID = status.OrganizationID });

                    status.ExtendedProperties.Attachments = attachments.Where(x => x.ReviewStatusID == status.ReviewStatusID).ToList();
                    status.ExtendedProperties.ReviewRoles = reviewRoles;

                    if (currentOrganization == null || currentOrganization.OrganizationID != status.OrganizationID)
                    {
                        currentOrganization = DataService.GetOrganization(new Organization { OrganizationID = status.OrganizationID }).Copy<Organization>();

                        organizationCount = reviewOrganizations.Count(x => x.OrganizationID == currentOrganization.OrganizationID) + 1;

                        currentOrganization.ExtendedProperties.ReviewTabValue = organizationCount > 1 ?
                            String.Format("{0} ({1})", currentOrganization.OrganizationName, organizationCount.ToString()) : currentOrganization.OrganizationName;

                        organizationKey = String.Format("{0}_{1}", currentOrganization.OrganizationID.ToStringSafe(), organizationCount.ToString());

                        currentOrganization.ExtendedProperties.ReviewTabKey = organizationKey;

                        reviewStatusDictionary.Add(organizationKey, new List<ReviewStatus>());

                        reviewOrganizations.Add(currentOrganization);
                    }

                    Boolean isAdmin = PermissionUtil.CheckAdminPermission(this.View.Roles);

                    status.ExtendedProperties.CanReview = isAdmin || PermissionUtil.CheckReviewStatusPermission(status, this.View.Roles, userOrganizationGroups);
                    status.ExtendedProperties.CanAdmin = isAdmin || PermissionUtil.CheckReviewAdminPermission(currentOrganization, formType, this.View.Roles, userOrganizationGroups);
                    status.ExtendedProperties.CanAutopen = isAdmin || PermissionUtil.CheckReviewAutopenPermission(formType, status, this.View.Roles);
                    status.ExtendedProperties.CanViewComments = isAdmin || PermissionUtil.CheckReviewViewCommentsPermission(currentOrganization, formType, this.View.Roles, userOrganizationGroups);
                    status.ExtendedProperties.CanForward = isAdmin || PermissionUtil.CheckReviewForwardPermission(currentOrganization, formType, this.View.Roles, userOrganizationGroups);
                    status.ExtendedProperties.CanModifyOrder = isAdmin || PermissionUtil.CheckReviewChangeRoutingPermission(currentOrganization, formType, this.View.Roles, userOrganizationGroups);

                    status.ExtendedProperties.CanMove = statusOrganizationFormType.ParallelReview != true;

                    status.ExtendedProperties.ReviewGroupName = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = status.ReviewerGroupID }).OrganizationGroupName;

                    status.ExtendedProperties.ReviewRoleName = DataService.GetReviewRole(new ReviewRole { ReviewRoleID = status.ReviewRoleID }).ReviewRoleName;
                    status.ExtendedProperties.ReviewActionName = FormUtil.GetReviewActionString(status);

                    reviewStatusDictionary[organizationKey].Add(status);
                }

                foreach (Organization organization in reviewOrganizations)
                {
                    organization.ExtendedProperties.StatusType = FormUtil.GetOrganizationStatusType(form, reviewStatusDictionary[organization.ExtendedProperties.ReviewTabKey], organizationFormType);
                }

                this.View.ReviewOrganizations = reviewOrganizations;

                this.View.ReviewStatuses = reviewStatusDictionary;

                FormLog formLog = new FormLog();
                formLog.FormID = this.View.FormID;

                IList<FormLog> formLogs = DataService.ListFormLogs(formLog).OrderByDescending(x => x.LogDate).ToList();

                this.View.LogItems = formLogs;
            }
        }

        public void LoadReviewStatus()
        {
            if (this.View.SelectedReviewStatusID.HasValue)
            {
                IDictionary<String, IList<ReviewStatus>> reviewStatuses = this.View.ReviewStatuses;

                ReviewStatus reviewStatus = reviewStatuses[this.View.SelectedTab].FirstOrDefault(x => x.ReviewStatusID == this.View.SelectedReviewStatusID);

                FormType formType = DataService.GetFormType(new FormType { FormTypeID = this.View.FormTypeID });
                
                IList<ReviewAction> reviewActions = DataService.GetReviewActionsByFormActionType(new FormActionType { FormActionTypeID = formType.FormActionTypeID }).OrderBy(x => x.ReviewActionName).ToList();

                foreach (ReviewAction action in reviewActions)
                {
                    action.ExtendedProperties.CanSelect =
                        action.AdminOnly != true || reviewStatus.ExtendedProperties.CanAdmin == true ||
                        action.ReviewActionID == reviewStatus.ReviewActionID;
                }

                this.View.ReviewActions = reviewActions;

                this.View.ReviewDuty = reviewStatus.ExtendedProperties.ReviewGroupName;
                this.View.SelectedReviewAction = reviewStatus.ReviewActionID;
                this.View.ReviewIsRejection = reviewStatus.ReviewActionID != null && DataService.GetReviewAction(new ReviewAction { ReviewActionID = reviewStatus.ReviewActionID }).CausesRejection == true;
                this.View.ReviewDate = reviewStatus.ActionDate;
                this.View.ReviewSigned = reviewStatus.Signed;
                this.View.ReviewAutopen = reviewStatus.Autopen;
                this.View.ReviewRemarks = reviewStatus.Comments;

                this.View.ReviewCanAdmin = reviewStatus.ExtendedProperties.CanAdmin == true;
                this.View.ReviewCanAutopen = reviewStatus.ExtendedProperties.CanAdmin == true || reviewStatus.ExtendedProperties.CanAutopen == true;
                
                this.View.SignaturePresent = reviewStatus.DigitalSignature;
                this.View.SignatureEnable = reviewStatus.ReviewActionID.HasValue;

                if (reviewStatus.DigitalSignature == true)
                {
                    FormData data = new FormData();
                    data.FormID = this.View.FormID;

                    data = DataService.LoadFormData(data);

                    ReviewSignature signature = new ReviewSignature();
                    signature.ReviewStatusID = reviewStatus.ReviewStatusID;

                    signature = DataService.LoadReviewSignature(signature);

                    this.View.SignatureDate = signature != null ? SignatureUtil.GetSignatureDate(signature) : null;
                    this.View.SignatureSubject = signature != null ? SignatureUtil.GetSignatureName(signature) : null;
                    this.View.SignatureValid = signature != null ? SignatureUtil.VerifyFormSignature(data, signature) : false;
                }
            }
        }

        public void SaveReviewStatus()
        {
            if (this.View.SelectedReviewStatusID.HasValue)
            {
                IDictionary<String, IList<ReviewStatus>> reviewStatuses = this.View.ReviewStatuses;

                ReviewStatus reviewStatus = reviewStatuses[this.View.SelectedTab].FirstOrDefault(x => x.ReviewStatusID == this.View.SelectedReviewStatusID);

                Boolean statusChanged = reviewStatus.ReviewActionID != this.View.SelectedReviewAction;

                reviewStatus.ExtendedProperties.PreviousReviewActionID = reviewStatus.ReviewActionID;
                reviewStatus.ReviewActionID = this.View.SelectedReviewAction;
                reviewStatus.ActionDate = this.View.ReviewDate;
                reviewStatus.Signed = this.View.ReviewSigned;
                reviewStatus.Autopen = this.View.ReviewAutopen;
                reviewStatus.Comments = this.View.ReviewRemarks;
                reviewStatus.ExtendedProperties.ActingUser = this.View.CurrentUserName;
                reviewStatus.DigitalSignature = this.View.SignaturePresent;

                DataService.SaveReviewStatus(reviewStatus);

                if (statusChanged)
                {
                    Form form = new Form();
                    form.FormID = this.View.FormID;

                    form = DataService.LoadForm(form);

                    form.ExtendedProperties.ActingUser = this.View.CurrentUserName;
                    form.ExtendedProperties.FormLink = this.View.FormLink;

                    FormWorkflow.RunWorkflow(form, reviewStatus);
                }

                String selectedTab = this.View.SelectedTab;

                LoadReviewData();

                this.View.SelectedTab = selectedTab;

                ChangeReviewTab();
            }
        }

        public void ResetReviewStatus()
        {
            if (this.View.SelectedReviewStatusID.HasValue)
            {
                IDictionary<String, IList<ReviewStatus>> reviewStatuses = this.View.ReviewStatuses;

                ReviewStatus reviewStatus = reviewStatuses[this.View.SelectedTab].FirstOrDefault(x => x.ReviewStatusID == this.View.SelectedReviewStatusID);

                Boolean statusChanged = reviewStatus.ReviewActionID != null;

                reviewStatus.ExtendedProperties.PreviousReviewActionID = reviewStatus.ReviewActionID;
                reviewStatus.ReviewActionID = null;
                reviewStatus.ActionDate = this.View.ReviewDate;
                reviewStatus.Signed = false;
                reviewStatus.Autopen = false;
                reviewStatus.Comments = null;
                reviewStatus.ExtendedProperties.ActingUser = this.View.CurrentUserName;

                DataService.SaveReviewStatus(reviewStatus);

                Unsign();

                if (statusChanged)
                {
                    Form form = new Form();
                    form.FormID = this.View.FormID;
                    form.ExtendedProperties.ActingUser = this.View.CurrentUserName;

                    form = DataService.LoadForm(form);

                    form.ExtendedProperties.FormLink = this.View.FormLink;

                    FormWorkflow.RunWorkflow(form, reviewStatus);
                }

                String selectedTab = this.View.SelectedTab;

                LoadReviewData();

                this.View.SelectedTab = selectedTab;

                ChangeReviewTab();
            }
        }

        public void NotifyReviewStatus()
        {
            if (this.View.SelectedReviewStatusID.HasValue)
            {
                IDictionary<String, IList<ReviewStatus>> reviewStatuses = this.View.ReviewStatuses;

                ReviewStatus reviewStatus = reviewStatuses[this.View.SelectedTab].FirstOrDefault(x => x.ReviewStatusID == this.View.SelectedReviewStatusID);

                Form form = new Form();
                form.FormID = this.View.FormID;

                form = DataService.LoadForm(form);

                form.ExtendedProperties.FormLink = this.View.FormLink;

                FormWorkflow.ForceNotifyReviewer(form, reviewStatus);
            }
        }

        public void ChangeReviewTab()
        {
            if (this.View.SelectedTab == "ActionLog")
            {
                this.View.ShowActionLog = true;
                this.View.ShowReview = false;
            }
            else
            {
                this.View.ShowActionLog = false;
                this.View.ShowReview = true;

                IList<ReviewStatus> reviewStatuses = this.View.ReviewStatuses[this.View.SelectedTab];

                this.View.CurrentReviewStatuses = reviewStatuses;

                this.View.CanModifyOrder = reviewStatuses.Any(x => x.ExtendedProperties.CanAdmin == true || x.ExtendedProperties.CanModifyOrder == true);
                this.View.CanForward = reviewStatuses.Any(x => x.ExtendedProperties.CanAdmin == true || x.ExtendedProperties.CanForward == true);
            }
        }

        public void SetReviewDate()
        {
            IDictionary<String, IList<ReviewStatus>> reviewStatuses = this.View.ReviewStatuses;

            ReviewStatus reviewStatus = reviewStatuses[this.View.SelectedTab].FirstOrDefault(x => x.ReviewStatusID == this.View.SelectedReviewStatusID);

            if (this.View.SelectedReviewAction != reviewStatus.ReviewActionID)
            {
                this.View.ReviewDate = DateTime.Now.Date;
            }
            else
            {
                this.View.ReviewDate = reviewStatus.ActionDate;
            }

            this.View.ReviewIsRejection = this.View.SelectedReviewAction.HasValue && DataService.GetReviewAction(new ReviewAction { ReviewActionID = this.View.SelectedReviewAction }).CausesRejection == true;
            this.View.SignatureEnable = this.View.SelectedReviewAction.HasValue;
        }

        public void LoadReviewOrders()
        {
            IList<ReviewStatus> reviewOrders = this.View.ReviewStatuses[this.View.SelectedTab].OrderBy(x => x.ReviewOrder).ToList();

            reviewOrders.First().ExtendedProperties.IsFirst = true;
            reviewOrders.Last().ExtendedProperties.IsLast = true;

            this.View.ReviewOrders = reviewOrders;

            FormType formType = new FormType();
            formType.FormTypeID = this.View.FormTypeID;

            Organization organization = new Organization();
            organization.OrganizationID = reviewOrders.First().OrganizationID;
            
            IList<OrganizationFormActor> formActors = DataService.GetOrganizationFormActorByOrganizationFormType(organization, formType).Where(x => x.CanReview == true).ToList();

            foreach (OrganizationFormActor actor in formActors)
            {
                actor.ExtendedProperties.OrganizationGroupName = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = actor.OrganizationGroupID }).OrganizationGroupName;
            }

            this.View.ReviewOrderGroups = formActors;
            this.View.ReviewOrderRoles = DataService.GetReviewRoles();
        }

        public void MoveReviewOrderUp()
        {
            IList<ReviewStatus> reviewOrders = this.View.ReviewOrders;

            ReviewStatus reviewOrderToMove = reviewOrders.FirstOrDefault(x => x.ReviewStatusID == this.View.SelectedReviewOrderID);
            ReviewStatus otherReviewOrder = reviewOrders.FirstOrDefault(x => x.ReviewOrder == reviewOrderToMove.ReviewOrder - 1);

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
            IList<ReviewStatus> reviewOrders = this.View.ReviewOrders;

            ReviewStatus reviewOrderToMove = reviewOrders.FirstOrDefault(x => x.ReviewStatusID == this.View.SelectedReviewOrderID);
            ReviewStatus otherReviewOrder = reviewOrders.FirstOrDefault(x => x.ReviewOrder == reviewOrderToMove.ReviewOrder + 1);

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
            IList<ReviewStatus> reviewOrders = this.View.ReviewOrders;

            ReviewStatus reviewOrderToDelete = reviewOrders.FirstOrDefault(x => x.ReviewStatusID == this.View.SelectedReviewOrderID);

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
                IList<ReviewStatus> reviewOrders = this.View.ReviewOrders;

                ReviewStatus reviewOrderToChange = reviewOrders.FirstOrDefault(x => x.ReviewStatusID == this.View.SelectedReviewOrderID);

                reviewOrderToChange.ReviewRoleID = this.View.SelectedReviewOrderRoleID;
                reviewOrderToChange.ExtendedProperties.ReviewRoleName = DataService.GetReviewRole(new ReviewRole { ReviewRoleID = reviewOrderToChange.ReviewRoleID }).ReviewRoleName;

                this.View.ReviewOrders = reviewOrders;
            }
        }

        public void AddReviewOrder()
        {
            if (this.View.SelectedReviewGroupsID.Count > 0)
            {
                IList<ReviewStatus> reviewOrders = this.View.ReviewOrders.OrderBy(x => x.ReviewOrder).ToList();

                foreach (Nullable<Int32> reviewGroupId in this.View.SelectedReviewGroupsID)
                {
                    Int32 newId = -1 * reviewOrders.Count(x => x.ReviewStatusID < 0) - 1;

                    ReviewStatus reviewOrderToAdd = new ReviewStatus();

                    reviewOrderToAdd.ReviewStatusID = newId;
                    reviewOrderToAdd.FormID = this.View.FormID;
                    reviewOrderToAdd.OrganizationID = reviewOrders.First().OrganizationID;
                    reviewOrderToAdd.ExtendedProperties.CanMove = reviewOrders.First().ExtendedProperties.CanMove;
                    reviewOrderToAdd.ReviewerGroupID = reviewGroupId;
                    reviewOrderToAdd.ReviewRoleID = this.View.SelectedReviewRoleID;
                    reviewOrderToAdd.ReviewOrder = (Byte)(reviewOrders.Last().ReviewOrder + 1);
                    reviewOrderToAdd.Notified = false;
                    reviewOrderToAdd.Signed = false;
                    reviewOrderToAdd.Autopen = false;
                    reviewOrderToAdd.ExtendedProperties.IsLast = true;

                    reviewOrderToAdd.ExtendedProperties.ReviewGroupName = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = reviewOrderToAdd.ReviewerGroupID }).OrganizationGroupName;
                    reviewOrderToAdd.ExtendedProperties.ReviewRoleName = DataService.GetReviewRole(new ReviewRole { ReviewRoleID = reviewOrderToAdd.ReviewRoleID }).ReviewRoleName;
                    reviewOrderToAdd.ExtendedProperties.ReviewRoles = reviewOrders.First().ExtendedProperties.ReviewRoles;

                    if (reviewOrders.Count(x => x.ExtendedProperties.MarkForDeletion != true) > 0)
                    {
                        reviewOrders.Last(x => x.ExtendedProperties.MarkForDeletion != true).ExtendedProperties.IsLast = null;
                    }

                    reviewOrders.Add(reviewOrderToAdd);

                    if (reviewOrderToAdd.ExtendedProperties.CanMove != true)
                    {
                        Byte currentOrderValue = reviewOrders.First().ReviewOrder.GetValueOrDefault();

                        foreach (ReviewStatus status in reviewOrders.Where(x => x.ExtendedProperties.MarkForDeletion != true).OrderBy(x => x.ExtendedProperties.ReviewGroupName))
                        {
                            status.ReviewOrder = currentOrderValue;
                            currentOrderValue += 1;
                        }
                    }
                }

                this.View.ReviewOrders = reviewOrders.OrderBy(x => x.ReviewOrder).ToList();

                this.View.SelectedReviewGroupsID = null;
            }
        }

        public void SaveReviewOrder()
        {
            if (this.View.FormID.HasValue)
            {
                IList<ReviewStatus> reviewOrders = this.View.ReviewOrders.OrderBy(x => x.ReviewOrder).ToList();

                Int32 netCount = reviewOrders.Count(x => x.ReviewStatusID < 0) - reviewOrders.Count(x => x.ExtendedProperties.MarkForDeletion == true);
                Int32 itemsChanged = 0;

                foreach (ReviewStatus reviewOrder in reviewOrders)
                {
                    if (reviewOrder.ReviewStatusID < 0)
                    {
                        reviewOrder.ReviewStatusID = null;
                    }

                    if (reviewOrder.ExtendedProperties.MarkForDeletion != true)
                    {
                        DataService.SaveReviewStatus(reviewOrder);
                        itemsChanged++;
                    }
                    else if (reviewOrder.ExtendedProperties.MarkForDeletion == true && reviewOrder.ReviewStatusID.HasValue)
                    {
                        DataService.DeleteReviewStatus(reviewOrder);
                        itemsChanged++;
                    }
                }

                if (netCount != 0)
                {
                    Nullable<Byte> lastReviewOrder = reviewOrders.Last().ReviewOrder;

                    foreach (ReviewStatus reviewStatus in this.View.ReviewStatuses.Values.SelectMany(x => x))
                    {
                        if (reviewStatus.ReviewOrder > (Byte)(lastReviewOrder - netCount))
                        {
                            reviewStatus.ReviewOrder += (Byte)netCount;

                            DataService.SaveReviewStatus(reviewStatus);
                        }
                    }
                }

                LogUtil.LogModifyChain(this.View.FormID, DataService.GetOrganization(new Organization { OrganizationID = reviewOrders.Last().OrganizationID }).OrganizationName,
                    this.View.CurrentUserName, itemsChanged, netCount);

                Form form = new Form();
                form.FormID = this.View.FormID;
                form.ExtendedProperties.ActingUser = this.View.CurrentUserName;

                form = DataService.LoadForm(form);

                form.ExtendedProperties.FormLink = this.View.FormLink;

                FormWorkflow.RunWorkflow(form, null);

                String selectedTab = this.View.SelectedTab;

                LoadReviewData();

                this.View.SelectedTab = selectedTab;

                ChangeReviewTab();
            }
        }

        public void LoadForwarding()
        {
            IList<ReviewStatus> reviewOrders = this.View.ReviewStatuses[this.View.SelectedTab];

            OrganizationForwarding forwarding = new OrganizationForwarding();
            forwarding.FormTypeID = this.View.FormTypeID;
            forwarding.ForwardOrganizationID = reviewOrders.First().OrganizationID;

            IList<OrganizationForwarding> forwardList = DataService.ListOrganizationForwardings(forwarding);

            IList<Organization> forwardOrganizations = new List<Organization>();

            foreach (OrganizationForwarding forward in forwardList)
            {
                Organization receiveOrganization = DataService.GetOrganization(new Organization { OrganizationID = forward.ReceiveOrganizationID });

                if (!forwardOrganizations.Contains(receiveOrganization))
                {
                    forwardOrganizations.Add(receiveOrganization);
                }
            }

            if (forwardOrganizations.Count == 0)
            {
                throw new USAACEException(ExceptionType.Recoverable, MessageConstants.NO_FORWARDING_ORGANIZATIONS);
            }
            else
            {
                this.View.ForwardOrganizations = forwardOrganizations;

                LoadForwardRouting();
            }
        }

        public void LoadForwardRouting()
        {
            if (this.View.SelectedForwardOrganizationID.HasValue)
            {
                IList<ReviewStatus> reviewOrders = this.View.ReviewStatuses[this.View.SelectedTab];

                OrganizationForwarding forwarding = new OrganizationForwarding();
                forwarding.FormTypeID = this.View.FormTypeID;
                forwarding.ReceiveOrganizationID = this.View.SelectedForwardOrganizationID;
                forwarding.ForwardOrganizationID = reviewOrders.First().OrganizationID;

                IList<OrganizationForwarding> forwardList = DataService.ListOrganizationForwardings(forwarding);

                OrganizationFormRouting formRouting = new OrganizationFormRouting();
                formRouting.OrganizationID = this.View.SelectedForwardOrganizationID;
                formRouting.FormTypeID = this.View.FormTypeID;

                IList<OrganizationFormRouting> formRoutings = DataService.ListOrganizationFormRoutings(formRouting);

                IList<OrganizationFormRouting> forwardRoutings = new List<OrganizationFormRouting>();

                foreach (OrganizationForwarding forward in forwardList)
                {
                    OrganizationFormRouting routing = formRoutings.FirstOrDefault(x => x.OrganizationFormRoutingID == forward.OrganizationFormRoutingID);

                    if (routing != null)
                    {
                        OrganizationFormReviewer reviewer = new OrganizationFormReviewer();
                        reviewer.OrganizationFormRoutingID = routing.OrganizationFormRoutingID;

                        IList<OrganizationFormReviewer> routingReviewers = DataService.ListOrganizationFormRoutingReviewers(reviewer).OrderBy(x => x.ReviewOrder).ToList();

                        foreach (OrganizationFormReviewer routingReviewer in routingReviewers)
                        {
                            routingReviewer.ExtendedProperties.OrganizationGroupName = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = routingReviewer.ReviewerGroupID }).OrganizationGroupName;
                        }

                        routing.ExtendedProperties.RoutingNameAndReviewers = String.Format("{0} ({1})", routing.RoutingName, String.Join("; ", routingReviewers.Select(x => x.ExtendedProperties.OrganizationGroupName)));

                        forwardRoutings.Add(routing);
                    }
                }

                this.View.ForwardRoutingChains = forwardRoutings.OrderBy(x => x.RoutingName != RoutingConstants.DEFAULT_ROUTING_CHAIN).ThenBy(x => x.RoutingName).ToList();
            }
            else
            {
                this.View.ForwardRoutingChains = new List<OrganizationFormRouting>();
            }
        }

        public void SaveForwarding()
        {
            if (this.View.SelectedForwardRoutingID.HasValue)
            {
                IList<ReviewStatus> reviewOrders = this.View.ReviewStatuses[this.View.SelectedTab].OrderBy(x => x.ReviewOrder).ToList();

                OrganizationFormRouting formRouting = new OrganizationFormRouting();
                formRouting.OrganizationFormRoutingID = this.View.SelectedForwardRoutingID;

                formRouting = DataService.LoadOrganizationFormRouting(formRouting);

                OrganizationFormReviewer formReviewer = new OrganizationFormReviewer();
                formReviewer.OrganizationFormRoutingID = this.View.SelectedForwardRoutingID;

                IList<OrganizationFormReviewer> routingReviewers = DataService.ListOrganizationFormRoutingReviewers(formReviewer).OrderBy(x => x.ReviewOrder).ToList();

                Int32 netCount = routingReviewers.Count;

                Nullable<Byte> lastReviewOrder = reviewOrders.Last().ReviewOrder;

                foreach (OrganizationFormReviewer reviewer in routingReviewers)
                {
                    ReviewStatus status = new ReviewStatus();
                    status.FormID = this.View.FormID;
                    status.OrganizationID = formRouting.OrganizationID;
                    status.ReviewOrder = (Nullable<Byte>)(reviewer.ReviewOrder + lastReviewOrder);
                    status.ReviewerGroupID = reviewer.ReviewerGroupID;
                    status.ReviewRoleID = reviewer.ReviewRoleID;
                    status.Notified = false;
                    status.Signed = false;
                    status.Autopen = false;

                    DataService.SaveReviewStatus(status);
                }

                if (netCount != 0)
                {
                    foreach (ReviewStatus reviewStatus in this.View.ReviewStatuses.Values.SelectMany(x => x))
                    {
                        if (reviewStatus.ReviewOrder > lastReviewOrder)
                        {
                            reviewStatus.ReviewOrder += (Byte)netCount;

                            DataService.SaveReviewStatus(reviewStatus);
                        }
                    }
                }

                LogUtil.LogForwarding(this.View.FormID, DataService.GetOrganization(new Organization { OrganizationID = reviewOrders.Last().OrganizationID }).OrganizationName,
                    this.View.CurrentUserName, DataService.GetOrganization(new Organization { OrganizationID = formRouting.OrganizationID }).OrganizationName, formRouting.RoutingName);

                Form form = new Form();
                form.FormID = this.View.FormID;
                form.ExtendedProperties.ActingUser = this.View.CurrentUserName;

                form = DataService.LoadForm(form);

                form.ExtendedProperties.FormLink = this.View.FormLink;

                FormWorkflow.RunWorkflow(form, null);

                String selectedTab = this.View.SelectedTab;

                LoadReviewData();

                this.View.SelectedTab = selectedTab;

                ChangeReviewTab();
            }
        }

        public void Sign()
        {
            if (this.View.SelectedReviewStatusID.HasValue)
            {
                FormData data = new FormData();
                data.FormID = this.View.FormID;

                data = DataService.LoadFormData(data);

                this.View.SignatureFormHash = SignatureUtil.CalculateFormDataHash(data);
            }
        }

        public void SignFinal()
        {
            if (this.View.SelectedReviewStatusID.HasValue)
            {
                this.View.SignatureFormHash = null;

                ReviewSignature signature = new ReviewSignature();
                signature.ReviewStatusID = this.View.SelectedReviewStatusID;
                signature.SignatureData = this.View.SignatureData;

                signature = DataService.SaveReviewSignature(signature);

                this.View.SignaturePresent = true;

                SaveReviewStatus();

                LoadReviewStatus();
            }
        }

        public void Unsign()
        {
            if (this.View.SelectedReviewStatusID.HasValue)
            {
                ReviewSignature signature = new ReviewSignature();
                signature.ReviewStatusID = this.View.SelectedReviewStatusID;

                signature = DataService.LoadReviewSignature(signature);

                if (signature != null)
                {
                    DataService.DeleteReviewSignature(signature);
                }

                this.View.SignaturePresent = false;

                SaveReviewStatus();

                LoadReviewStatus();
            }
        }

        public void ViewReviewSignature()
        {
            if (this.View.SelectedReviewStatusID.HasValue)
            {
                IDictionary<String, IList<ReviewStatus>> reviewStatuses = this.View.ReviewStatuses;

                ReviewStatus reviewStatus = reviewStatuses[this.View.SelectedTab].FirstOrDefault(x => x.ReviewStatusID == this.View.SelectedReviewStatusID);

                if (reviewStatus.DigitalSignature == true)
                {
                    FormData data = new FormData();
                    data.FormID = this.View.FormID;

                    data = DataService.LoadFormData(data);

                    ReviewSignature signature = new ReviewSignature();
                    signature.ReviewStatusID = reviewStatus.ReviewStatusID;

                    signature = DataService.LoadReviewSignature(signature);

                    this.View.SignatureViewDate = signature != null ? SignatureUtil.GetSignatureDate(signature) : null;
                    this.View.SignatureViewSubject = signature != null ? SignatureUtil.GetSignatureName(signature) : null;
                    this.View.SignatureViewValid = signature != null ? SignatureUtil.VerifyFormSignature(data, signature) : false;
                }
            }
        }
    }
}
