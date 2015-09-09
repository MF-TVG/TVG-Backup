using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Enums;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.FormEntities;

namespace USAACE.eStaffing.Business.Util
{
    public static class FormUtil
    {
        public static void SetFormTypeValues(Form form, FormEntityBase specificForm)
        {
            FormType formType = new FormType();
            formType.FormTypeID = form.FormTypeID;

            formType = DataService.GetFormType(formType);

            String subjectFieldName = formType.SubjectField;
            String suspenseFieldName = formType.SuspenseDateField;
            String formNumberFieldName = formType.FormNumberField;

            OrganizationFormType organizationFormType = new OrganizationFormType();
            organizationFormType.FormTypeID = form.FormTypeID;
            organizationFormType.OrganizationID = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = form.SubmitterGroupID }).OrganizationID;

            organizationFormType = DataService.GetOrganizationFormType(organizationFormType);

            Int16 suspenseAdjust = organizationFormType.SuspenseAdjust.GetValueOrDefault(0);

            PropertyInfo subjectProperty = !String.IsNullOrEmpty(subjectFieldName) ? specificForm.GetType().GetProperty(subjectFieldName) : null;
            PropertyInfo suspenseProperty = !String.IsNullOrEmpty(suspenseFieldName) ? specificForm.GetType().GetProperty(suspenseFieldName) : null;
            PropertyInfo formNumberProperty = !String.IsNullOrEmpty(formNumberFieldName) ? specificForm.GetType().GetProperty(formNumberFieldName) : null;

            form.FormNumber = formNumberProperty != null ? formNumberProperty.GetValue(specificForm) as String : GetFormNumber(form);
            form.Subject = subjectProperty != null ? subjectProperty.GetValue(specificForm) as String : form.FormNumber;

            if (suspenseProperty != null)
            {
                Nullable<DateTime> suspenseValue = suspenseProperty.GetValue(specificForm) as Nullable<DateTime>;

                form.SuspenseDate = suspenseValue.HasValue ? suspenseValue.Value.AddDays(suspenseAdjust) : suspenseValue;
            }
        }

        public static IList<String> GetFormTypeFieldsByType(FormType formType, Type specificType)
        {
            IList<String> fields = new List<String>();

            Type formTypeClass = Assembly.GetAssembly(typeof(FormType)).GetType("USAACE.eStaffing.Domain.FormEntities." + formType.FormDataTable);

            foreach (PropertyInfo property in formTypeClass.GetProperties())
            {
                if (property.PropertyType == specificType)
                {
                    fields.Add(property.Name);
                }
            }

            return fields;
        }

        public static void CreateNewFormData(Form form)
        {
            OrganizationFormDefault formDefault = new OrganizationFormDefault();
            formDefault.OrganizationGroupID = form.SubmitterGroupID;
            formDefault.FormTypeID = form.FormTypeID;

            formDefault = DataService.LoadOrganizationFormDefault(formDefault);

            FormData formData = new FormData();
            formData.FormID = form.FormID;
            formData.FormDataXML = formDefault != null ? formDefault.FormDataXML : null;

            DataService.SaveFormData(formData);
        }

        public static String GetFormNumber(Form form)
        {
            return String.Format("ES-{0}", form.FormID.ToString().PadLeft(6, '0'));
        }

        /// <summary>
        /// Gets the status of the form given the form and a list of review statuses
        /// </summary>
        /// <param name="form">The form to get the status for</param>
        /// <param name="formStatuses">The review statuses of the form</param>
        /// <returns>The status of the form</returns>
        public static String GetFormStatus(Form form, IList<ReviewStatus> reviewStatuses)
        {
            if (form.FormStatusID == FormStatusConstants.DRAFT)
            {
                return "Draft";
            }
            else if (form.FormStatusID == FormStatusConstants.ARCHIVED)
            {
                return "Archived";
            }
            else if (form.FormStatusID == FormStatusConstants.CANCELLED)
            {
                return "Cancelled";
            }
            else if (form.FormStatusID == FormStatusConstants.COMPLETED)
            {
                return "Approved";
            }
            else if (form.Submitted != true)
            {
                return reviewStatuses.Any(x => GetReviewStatusType(x) == StatusType.Rejected) ? "Rejected" : "Not Submitted";
            }
            else
            {
                ReviewStatus currentReviewer = reviewStatuses.FirstOrDefault(x => GetReviewStatusType(x) == StatusType.InReview);

                if (currentReviewer != null)
                {
                    return DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = currentReviewer.ReviewerGroupID }).OrganizationGroupName + " Review";
                }
                else
                {
                    return String.Empty;
                }
            }
        }

        /// <summary>
        /// Gets the status of the form given the form and a list of review statuses
        /// </summary>
        /// <param name="form">The form to get the status for</param>
        /// <param name="formStatuses">The review statuses of the form</param>
        /// <returns>The status of the form</returns>
        public static StatusType GetFormStatusType(Form form, IList<ReviewStatus> reviewStatuses, OrganizationFormType formType)
        {
            if (form.FormStatusID == FormStatusConstants.ARCHIVED || form.FormStatusID == FormStatusConstants.COMPLETED)
            {
                return StatusType.Completed;
            }
            else if (form.FormStatusID == FormStatusConstants.CANCELLED || form.FormStatusID == FormStatusConstants.DRAFT)
            {
                return StatusType.NotSubmitted;
            }
            else if (form.Submitted != true)
            {
                return reviewStatuses.Any(x => GetReviewStatusType(x) == StatusType.Rejected) ? StatusType.Rejected : StatusType.NotSubmitted;
            }
            else if (reviewStatuses.All(x => GetReviewStatusType(x) == StatusType.Completed))
            {
                return StatusType.Completed;
            }
            else
            {
                return GetReviewAlertStatusType(form, formType);
            }
        }

        public static StatusType GetOrganizationStatusType(Form form, IList<ReviewStatus> reviewStatuses, OrganizationFormType formType)
        {
            if (form.Submitted != true && reviewStatuses.Any(x => GetReviewStatusType(x) == StatusType.Rejected))
            {
                return StatusType.Rejected;
            }
            else if (reviewStatuses.All(x => GetReviewStatusType(x) == StatusType.NotSubmitted))
            {
                return StatusType.NotSubmitted;
            }
            else if (reviewStatuses.All(x => GetReviewStatusType(x) == StatusType.Completed))
            {
                return StatusType.Completed;
            }
            else
            {
                return GetReviewAlertStatusType(form, formType);
            }
        }

        public static StatusType GetReviewStatusType(Form form, ReviewStatus reviewStatus, OrganizationFormType formType)
        {
            ReviewAction action = DataService.GetReviewAction(new ReviewAction { ReviewActionID = reviewStatus.ReviewActionID });
            ReviewRole role = DataService.GetReviewRole(new ReviewRole { ReviewRoleID = reviewStatus.ReviewRoleID });

            if (role.ActionRequired == true)
            {
                if (action != null && action.CausesRejection == true)
                {
                    return StatusType.Rejected;
                }
                else if (action != null && action.CausesCompletion == true)
                {
                    return StatusType.Completed;
                }
                else if (reviewStatus.Notified != true)
                {
                    return StatusType.NotSubmitted;
                }
                else
                {
                    return GetReviewAlertStatusType(form, formType);
                }
            }
            else
            {
                return reviewStatus.Notified == true ? StatusType.Completed : StatusType.NotSubmitted;
            }
        }

        public static StatusType GetReviewStatusType(ReviewStatus reviewStatus)
        {
            return GetReviewStatusType(null, reviewStatus, null);
        }

        public static StatusType GetReviewAlertStatusType(Form form, OrganizationFormType formType)
        {
            if (form != null && formType != null)
            {
                TimeSpan suspenseDifference = form.SuspenseDate.GetValueOrDefault(DateTime.MaxValue).Subtract(DateTime.Now);

                if (suspenseDifference.TotalDays <= formType.PastDueDays.GetValueOrDefault(0))
                {
                    return StatusType.PastDue;
                }
                else if (suspenseDifference.TotalDays <= formType.NearDueDays.GetValueOrDefault(30))
                {
                    return StatusType.NearDue;
                }
            }

            return StatusType.InReview;
        }

        public static String GetReviewActionString(ReviewStatus reviewStatus)
        {
            StatusType type = GetReviewStatusType(reviewStatus);

            if (type == StatusType.Completed || type == StatusType.Rejected)
            {
                if (reviewStatus.ReviewActionID == null)
                {
                    return "Info Only";
                }
                else
                {
                    return DataService.GetReviewAction(new ReviewAction { ReviewActionID = reviewStatus.ReviewActionID }).ReviewActionName;
                }
            }
            else
            {
                if (reviewStatus.ReviewActionID == null)
                {
                    return reviewStatus.Notified == true ? "In Review" : "Queued";
                }
                else
                {
                    return DataService.GetReviewAction(new ReviewAction { ReviewActionID = reviewStatus.ReviewActionID }).ReviewActionName;
                }
            }
        }
    }
}
