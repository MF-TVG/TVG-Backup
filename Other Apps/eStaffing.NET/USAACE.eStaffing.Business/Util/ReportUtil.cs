using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common;
using USAACE.Common.Entities;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Enums;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Business.Util
{
    public static class ReportUtil
    {
        public static IList<Form> GetFormsReport(IList<Nullable<Int32>> formTypes, Nullable<DateTime> suspenseDateStart, Nullable<DateTime> suspenseDateEnd,
            IList<Nullable<Int32>> reviewGroups, Nullable<DateTime> submitDateStart, Nullable<DateTime> submitDateEnd, String subject, IList<Nullable<Int32>> formStatuses, IList<Group> groups)
        {
            IList<Form> results = new List<Form>();

            Form searchForm = new Form();
            searchForm.SearchProperties.FormStatusIDIsIn = formStatuses;
            searchForm.SearchProperties.SuspenseDateMinRange = suspenseDateStart;
            searchForm.SearchProperties.SuspenseDateMaxRange = suspenseDateEnd;
            searchForm.SearchProperties.SubmitDateMinRange = submitDateStart;
            searchForm.SearchProperties.SubmitDateMaxRange = submitDateEnd;
            searchForm.SearchProperties.SubjectContains = subject;
            searchForm.SearchProperties.FormTypeIDIsIn = formTypes;

            IList<Form> allForms = DataService.ListForms(searchForm);

            ReviewStatus statusSearch = new ReviewStatus();
            statusSearch.SearchProperties.FormIDIsIn = allForms.Select(x => x.FormID).ToList();
            statusSearch.SearchProperties.ReviewerGroupIDIsIn = reviewGroups;

            IDictionary<Nullable<Int32>, IList<ReviewStatus>> allReviewStatuses = DataService.ListReviewStatusesByForm(statusSearch);

            IList<OrganizationGroup> userOrganizationGroups = DataService.ListOrganizationGroupsForGroups(groups);

            foreach (Form form in allForms.OrderBy(x => x.SuspenseDate.GetValueOrDefault(DateTime.MaxValue)))
            {
                OrganizationGroup submitter = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = form.SubmitterGroupID });
                Organization organization = DataService.GetOrganization(new Organization { OrganizationID = submitter.OrganizationID });
                FormType formType = DataService.GetFormType(new FormType { FormTypeID = form.FormTypeID });
                OrganizationFormType organizationFormType = DataService.GetOrganizationFormType(new OrganizationFormType { FormTypeID = form.FormTypeID, OrganizationID = submitter.OrganizationID });

                TimeSpan span = form.SuspenseDate.GetValueOrDefault(DateTime.MaxValue).Subtract(DateTime.Now);

                form.ExtendedProperties.FormTypeName = formType.FormTypeName;

                IList<ReviewStatus> reviewStatuses = allReviewStatuses.ContainsKey(form.FormID) ? allReviewStatuses[form.FormID] : null;

                if (reviewStatuses != null && reviewStatuses.Any(x => reviewGroups.Contains(x.ReviewerGroupID)))
                {
                    if (PermissionUtil.CheckFormViewPermission(form, formType, reviewStatuses, groups, userOrganizationGroups))
                    {
                        IList<ReviewStatus> formReviews = new List<ReviewStatus>();

                        foreach (Nullable<Int32> reviewGroupId in reviewGroups)
                        {
                            ReviewStatus searchStatus = reviewStatuses.FirstOrDefault(x => x.ReviewerGroupID == reviewGroupId);
                            
                            if (searchStatus != null)
                            {
                                searchStatus.ExtendedProperties.StatusType = FormUtil.GetReviewStatusType(form, searchStatus, organizationFormType);
                            }

                            formReviews.Add(searchStatus);
                        }

                        form.ExtendedProperties.Reviews = formReviews;
                        results.Add(form);
                    }
                }
            }

            return results;
        }

        public static IDictionary<StatusType, IList<OrganizationGroup>> GetFormsMetrics(IList<Form> forms, IList<Nullable<Int32>> reviewGroups)
        {
            IDictionary<StatusType, IList<OrganizationGroup>> metrics = new Dictionary<StatusType, IList<OrganizationGroup>>();

            IDictionary<StatusType, List<ReviewStatus>> reviewStatuses = forms.SelectMany(x => x.ExtendedProperties.Reviews)
                .Where(x => x != null).GroupBy(x => (StatusType)x.ExtendedProperties.StatusType).ToDictionary(x => x.Key, x => x.ToList());

            foreach (Object type in Enum.GetValues(typeof(StatusType)))
            {
                StatusType statusType = (StatusType)type;

                metrics.Add(statusType, new List<OrganizationGroup>());

                Boolean containsStatusType = reviewStatuses.ContainsKey(statusType);

                foreach (Nullable<Int32> reviewGroup in reviewGroups)
                {
                    OrganizationGroup group = new OrganizationGroup { OrganizationGroupID = reviewGroup };
                    Int32 metricValue = containsStatusType ? reviewStatuses[statusType].Count(x => x.ReviewerGroupID == group.OrganizationGroupID) : 0;
                    group.ExtendedProperties.MetricValue = metricValue;

                    metrics[statusType].Add(group);
                }
            }

            return metrics;
        }

        public static IList<Form> GetFormsList(Form form, IList<Group> roles, String sortField, String sortDirection)
        {
            IList<Form> userForms = new List<Form>();

            Form formList = new Form();
            formList.FormStatusID = form.FormStatusID;
            formList.FormTypeID = form.FormTypeID;

            IList<Form> forms = DataService.ListForms(formList);

            ReviewStatus statusSearch = new ReviewStatus();
            statusSearch.SearchProperties.FormIDIsIn = forms.Select(x => x.FormID).ToList();

            IDictionary<Nullable<Int32>, IList<ReviewStatus>> allReviewStatuses = DataService.ListReviewStatusesByForm(statusSearch);

            IList<OrganizationGroup> userOrganizationGroups = DataService.ListOrganizationGroupsForGroups(roles);
            FormType formType = new FormType { FormTypeID = form.FormTypeID };

            foreach (Form formItem in forms)
            {
                OrganizationGroup submitter = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = formItem.SubmitterGroupID });
                OrganizationFormType organizationFormType = DataService.GetOrganizationFormType(new OrganizationFormType { FormTypeID = formItem.FormTypeID, OrganizationID = submitter.OrganizationID });

                IList<ReviewStatus> reviewStatuses = allReviewStatuses.GetValueOrDefault(formItem.FormID, new List<ReviewStatus>());

                if (PermissionUtil.CheckFormViewPermission(formItem, formType, reviewStatuses, roles, userOrganizationGroups))
                {
                    String formStatus = FormUtil.GetFormStatus(formItem, reviewStatuses);

                    formItem.ExtendedProperties.Status = formStatus;

                    StatusType formStatusType = FormUtil.GetFormStatusType(formItem, reviewStatuses, organizationFormType);

                    formItem.ExtendedProperties.StatusType = formStatusType;

                    userForms.Add(formItem);
                }
            }

            return GetSortedForms(userForms, sortField, sortDirection);
        }

        public static IList<Form> GetUserForms(IList<Nullable<Int32>> formStatusFilter, String subjectFilter)
        {
            Form searchForm = new Form();
            searchForm.SearchProperties.FormStatusIDIsIn = formStatusFilter;
            searchForm.SearchProperties.SubjectContains = subjectFilter;
            IList<Form> forms = DataService.ListForms(searchForm);

            ReviewStatus statusSearch = new ReviewStatus();
            statusSearch.SearchProperties.FormIDIsIn = forms.Select(x => x.FormID).ToList();

            IDictionary<Nullable<Int32>, IList<ReviewStatus>> allReviewStatuses = DataService.ListReviewStatusesByForm(statusSearch);

            foreach (Form form in forms)
            {
                IList<ReviewStatus> reviewStatuses = allReviewStatuses.ContainsKey(form.FormID) ? allReviewStatuses[form.FormID] : new List<ReviewStatus>();
                form.ExtendedProperties.Reviews = reviewStatuses;
            }

            return forms;
        }
        
        public static IList<Form> GetUserSubmittedForms(IList<Form> forms, IList<OrganizationGroup> userOrganizationGroups, String sortField, String sortDirection)
        {
            IList<Form> userForms = new List<Form>();

            foreach (Form form in forms)
            {
                FormType formType = new FormType();
                formType.FormTypeID = form.FormTypeID;

                if (PermissionUtil.CheckFormIsSubmitter(form, userOrganizationGroups))
                {
                    form.ExtendedProperties.FormTypeName = DataService.GetFormType(new FormType { FormTypeID = form.FormTypeID }).FormTypeName;

                    OrganizationGroup submitter = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = form.SubmitterGroupID });
                    OrganizationFormType organizationFormType = DataService.GetOrganizationFormType(new OrganizationFormType { FormTypeID = form.FormTypeID, OrganizationID = submitter.OrganizationID });

                    IList<ReviewStatus> statuses = form.ExtendedProperties.Reviews;

                    String formStatus = FormUtil.GetFormStatus(form, statuses);
                    StatusType formStatusType = FormUtil.GetFormStatusType(form, statuses, organizationFormType);

                    form.ExtendedProperties.Status = formStatus;
                    form.ExtendedProperties.StatusType = formStatusType;
                    form.ExtendedProperties.LastAction = statuses.Count > 0 ? statuses.Max(x => x.ActionDate) : null;

                    userForms.Add(form);
                }
            }

            return GetSortedForms(userForms, sortField, sortDirection);
        }

        public static IList<Form> GetUserReviewForms(IList<Form> forms, IList<OrganizationGroup> userOrganizationGroups, Boolean myReviewOnly, String sortField, String sortDirection)
        {
            IList<Form> userForms = new List<Form>();

            foreach (Form form in forms)
            {
                IList<ReviewStatus> statuses = myReviewOnly ? form.ExtendedProperties.Reviews.Where(x => x.ReviewActionID == null && x.Notified == true).ToList() : form.ExtendedProperties.Reviews;

                if (statuses.Count > 0 && PermissionUtil.CheckFormIsReviewer(form, statuses, userOrganizationGroups))
                {
                    FormType formType = new FormType();
                    formType.FormTypeID = form.FormTypeID;
                    OrganizationGroup submitter = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = form.SubmitterGroupID });
                    OrganizationFormType organizationFormType = DataService.GetOrganizationFormType(new OrganizationFormType { FormTypeID = form.FormTypeID, OrganizationID = submitter.OrganizationID });

                    form.ExtendedProperties.FormTypeName = DataService.GetFormType(new FormType { FormTypeID = form.FormTypeID }).FormTypeName;

                    String formStatus = FormUtil.GetFormStatus(form, form.ExtendedProperties.Reviews);
                    StatusType formStatusType = FormUtil.GetFormStatusType(form, statuses, organizationFormType);

                    form.ExtendedProperties.Status = formStatus;
                    form.ExtendedProperties.StatusType = formStatusType;
                    form.ExtendedProperties.LastAction = statuses.Count > 0 ? statuses.Max(x => x.ActionDate) : null;

                    userForms.Add(form);
                }
            }

            return GetSortedForms(userForms, sortField, sortDirection);
        }

        private static IList<Form> GetSortedForms(IList<Form> forms, String sortField, String sortDirection)
        {
            IOrderedEnumerable<Form> prioritySortedForms = forms.OrderByDescending(x => x.HighPriority.GetValueOrDefault(false));

            if (sortDirection == SortDirectionConstants.ASCENDING)
            {
                switch (sortField)
                {
                    case "Type": return prioritySortedForms.ThenBy(x => x.ExtendedProperties.FormTypeName).ToList();
                    case "FormNumber": return prioritySortedForms.ThenBy(x => x.FormNumber.ToString()).ToList();
                    case "Subject": return prioritySortedForms.ThenBy(x => x.Subject).ToList();
                    case "SubmitDate": return prioritySortedForms.ThenBy(x => x.SubmitDate).ToList();
                    case "Suspense": return prioritySortedForms.ThenBy(x => x.SuspenseDate).ToList();
                    case "LastAction": return prioritySortedForms.ThenBy(x => x.ExtendedProperties.LastAction).ToList();
                    case "Status": return prioritySortedForms.ThenBy(x => x.ExtendedProperties.Status.ToString()).ToList();
                    default: return prioritySortedForms.ToList();
                }
            }
            else if (sortDirection == SortDirectionConstants.DESCENDING)
            {
                switch (sortField)
                {
                    case "Type": return prioritySortedForms.ThenByDescending(x => x.ExtendedProperties.FormTypeName).ToList();
                    case "FormNumber": return prioritySortedForms.ThenByDescending(x => x.FormNumber.ToString()).ToList();
                    case "Subject": return prioritySortedForms.ThenByDescending(x => x.Subject).ToList();
                    case "SubmitDate": return prioritySortedForms.ThenByDescending(x => x.SubmitDate).ToList();
                    case "Suspense": return prioritySortedForms.ThenByDescending(x => x.SuspenseDate).ToList();
                    case "LastAction": return prioritySortedForms.ThenByDescending(x => x.ExtendedProperties.LastAction).ToList();
                    case "Status": return prioritySortedForms.ThenByDescending(x => x.ExtendedProperties.Status).ToList();
                    default: return prioritySortedForms.ToList();
                }
            }
            else
            {
                return prioritySortedForms.ToList();
            }
        }
    }
}
