using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Enums;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Business.Workflow
{
    public static class FormWorkflow
    {
        /// <summary>
        /// Runs the review workflow for a specific form
        /// </summary>
        /// <param name="formId">The ID of the form</param>
        /// <param name="forceNotify">Whether reviewers should be notified even if already notified</param>
        public static void RunWorkflow(Form form, ReviewStatus changedStatus)
        {
            if (form.Submitted == true && form.FormStatusID != FormStatusConstants.DRAFT)
            {
                Boolean isComplete = true;
                
                OrganizationGroup submitter = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = form.SubmitterGroupID });
                Organization organization = DataService.GetOrganization(new Organization { OrganizationID = submitter.OrganizationID });

                FormType formType = DataService.GetFormType(new FormType { FormTypeID = form.FormTypeID });
                FormActionType actionType = DataService.GetFormActionType(new FormActionType { FormActionTypeID = formType.FormActionTypeID });

                Boolean isTopDown = actionType.FormActionTopDown == true;

                ReviewStatus formStatus = new ReviewStatus();
                formStatus.FormID = form.FormID;
                IList<ReviewStatus> allReviewStatuses = DataService.ListReviewStatuses(formStatus).OrderBy(x => x.ReviewOrder.GetValueOrDefault(0)).ToList();

                foreach (ReviewStatus reviewStatus in allReviewStatuses)
                {
                    Boolean isChangedStatus = changedStatus != null && changedStatus.ReviewStatusID == reviewStatus.ReviewStatusID;

                    OrganizationFormType organizationFormType = DataService.GetOrganizationFormType(new OrganizationFormType { FormTypeID = form.FormTypeID, OrganizationID = reviewStatus.OrganizationID });

                    // Notify if not notified

                    if (reviewStatus.Notified != true && (isComplete == true || organizationFormType.ParallelReview == true))
                    {
                        reviewStatus.Notified = true;

                        if (FormUtil.GetReviewStatusType(reviewStatus) == StatusType.Rejected)
                        {
                            reviewStatus.ReviewActionID = null;
                            reviewStatus.ActionDate = null;
                        }
                        else
                        {
                            OrganizationFormActor actor = DataService.GetOrganizationFormActorByOrganizationGroupFormType(
                                new OrganizationGroup { OrganizationGroupID = reviewStatus.ReviewerGroupID }, new FormType { FormTypeID = form.FormTypeID });

                            if (actor.MustReview == true)
                            {
                                reviewStatus.ReviewActionID = null;
                                reviewStatus.ActionDate = null;
                            }
                        }

                        if (reviewStatus.ReviewActionID == null)
                        {
                            NotifyReviewer(form, reviewStatus);
                        }

                        DataService.SaveReviewStatus(reviewStatus);

                        if (organizationFormType.ParallelReview == true)
                        {
                            for (int i = allReviewStatuses.IndexOf(reviewStatus) + 1; i < allReviewStatuses.Count; i++)
                            {
                                if (allReviewStatuses[i].OrganizationID == organizationFormType.OrganizationID)
                                {
                                    if (allReviewStatuses[i].Notified != true)
                                    {
                                        allReviewStatuses[i].Notified = true;

                                        if (FormUtil.GetReviewStatusType(allReviewStatuses[i]) == StatusType.Rejected)
                                        {
                                            allReviewStatuses[i].ReviewActionID = null;
                                            allReviewStatuses[i].ActionDate = null;
                                        }

                                        if (allReviewStatuses[i].ReviewActionID == null)
                                        {
                                            NotifyReviewer(form, allReviewStatuses[i]);
                                        }

                                        DataService.SaveReviewStatus(allReviewStatuses[i]);
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else if (FormUtil.GetReviewStatusType(reviewStatus) == StatusType.Rejected)
                    {
                        if (isChangedStatus)
                        {
                            RejectForm(form, allReviewStatuses, reviewStatus, isTopDown);

                            if (isTopDown != true)
                            {
                                form.Submitted = false;
                                form = DataService.SaveForm(form);
                            }
                        }

                        isComplete = false;
                    }

                    if (FormUtil.GetReviewStatusType(reviewStatus) != StatusType.Completed)
                    {
                        isComplete = false;
                    }
                }

                if (isComplete && form.FormStatusID == FormStatusConstants.ACTIVE)
                {
                    form.FormStatusID = FormStatusConstants.COMPLETED;
                    form = DataService.SaveForm(form);

                    NotifyCompletion(form, allReviewStatuses.LastOrDefault(), allReviewStatuses);
                }
                else if (isComplete == false && form.FormStatusID == FormStatusConstants.COMPLETED)
                {
                    form.FormStatusID = FormStatusConstants.ACTIVE;
                    form = DataService.SaveForm(form);
                }
            }
        }

        /// <summary>
        /// Notifies a reviewer to review a form
        /// </summary>
        /// <param name="form">The form that needs to be reviewed</param>
        /// <param name="reviewStatus">The review status containing the reviewer to be notified</param>
        public static void ForceNotifyReviewer(Form form, ReviewStatus reviewStatus)
        {
            NotifyReviewer(form, reviewStatus);
        }

        /// <summary>
        /// Runs the process for rejecting a form
        /// </summary>
        /// <param name="form">The form to reject</param>
        /// <param name="allReviewStatuses">The review statuses of the form</param>
        /// <param name="rejectStatus">The review status that rejected the form</param>
        private static void RejectForm(Form form, IList<ReviewStatus> allReviewStatuses, ReviewStatus rejectStatus, Boolean isTopDown)
        {
            if (isTopDown == false)
            {
                OrganizationGroup submitter = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = form.SubmitterGroupID });
                Organization organization = DataService.GetOrganization(new Organization { OrganizationID = submitter.OrganizationID });

                foreach (ReviewStatus reviewStatus in allReviewStatuses)
                {
                    reviewStatus.Notified = false;

                    DataService.SaveReviewStatus(reviewStatus);
                }
            }

            EmailUtil.SendEmail(form, null, null, NotificationType.Reject, rejectStatus, true);
        }

        /// <summary>
        /// Notifies a reviewer to review a form
        /// </summary>
        /// <param name="form">The form that needs to be reviewed</param>
        /// <param name="reviewStatus">The review status containing the reviewer to be notified</param>
        private static void NotifyReviewer(Form form, ReviewStatus reviewStatus)
        {
            if (reviewStatus.ReviewerGroupID != null)
            {
                EmailUtil.SendEmail(form, reviewStatus, new List<ReviewStatus> { reviewStatus }, NotificationType.Review, null, false);
            }
        }

        /// <summary>
        /// Notifies a submitter that a form has been completed
        /// </summary>
        /// <param name="form">The form that was completed</param>
        /// <param name="reviewStatus">The review status that completed the form</param>
        private static void NotifyCompletion(Form form, ReviewStatus lastReviewStatus, IList<ReviewStatus> allReviewStatuses)
        {
            OrganizationGroup submitter = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = form.SubmitterGroupID });
            Organization organization = DataService.GetOrganization(new Organization { OrganizationID = submitter.OrganizationID });

            IList<OrganizationFormActor> formActors = DataService.ListOrganizationFormActors();

            IList<ReviewStatus> reviewersToNotify = new List<ReviewStatus>();

            foreach (ReviewStatus reviewStatus in allReviewStatuses)
            {
                OrganizationFormActor actor = DataService.GetOrganizationFormActorByOrganizationGroupFormType(
                    new OrganizationGroup { OrganizationGroupID = reviewStatus.ReviewerGroupID }, new FormType { FormTypeID = form.FormTypeID });

                if (actor != null && actor.NotifyComplete == true)
                {
                    reviewersToNotify.Add(reviewStatus);
                }
            }

            EmailUtil.SendEmail(form, null, reviewersToNotify, NotificationType.Complete, lastReviewStatus, true);
        }
    }
}
