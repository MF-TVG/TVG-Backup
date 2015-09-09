using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public static class SearchUtil
    {
        public static IList<Form> SearchForms(String searchTerm, IList<Group> groups)
        {
            if (String.IsNullOrEmpty(searchTerm))
            {
                return null;
            }

            IList<Form> results = new List<Form>();

            Form formList = new Form();
            IList<Form> allForms = DataService.ListForms(formList);

            IList<Nullable<Int32>> allFormIds = allForms.Select(x => x.FormID).ToList();

            FormData formData = new FormData();
            formData.SearchProperties.FormDataXMLContains = searchTerm;
            formData.SearchProperties.FormIDIsIn = allFormIds;

            IDictionary<Nullable<Int32>, FormData> formDatas = DataService.ListFormDataByForm(formData);

            ReviewStatus statusSearch = new ReviewStatus();
            statusSearch.SearchProperties.FormIDIsIn = allFormIds;

            IDictionary<Nullable<Int32>, IList<ReviewStatus>> allReviewStatuses = DataService.ListReviewStatusesByForm(statusSearch);

            IList<OrganizationGroup> userOrganizationGroups = DataService.ListOrganizationGroupsForGroups(groups);

            foreach (Form form in allForms.OrderBy(x => x.SuspenseDate))
            {
                if (formDatas.ContainsKey(form.FormID))
                {
                    OrganizationGroup submitter = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = form.SubmitterGroupID });
                    FormType formType = DataService.GetFormType(new FormType { FormTypeID = form.FormTypeID });
                    OrganizationFormType organizationFormType = DataService.GetOrganizationFormType(new OrganizationFormType { FormTypeID = form.FormTypeID, OrganizationID = submitter.OrganizationID });

                    form.ExtendedProperties.FormTypeName = formType.FormTypeName;

                    IList<ReviewStatus> reviewStatuses = allReviewStatuses.ContainsKey(form.FormID) ? allReviewStatuses[form.FormID] : new List<ReviewStatus>();

                    if (PermissionUtil.CheckFormViewPermission(form, formType, reviewStatuses, groups, userOrganizationGroups))
                    {
                        String formStatus = FormUtil.GetFormStatus(form, reviewStatuses);

                        form.ExtendedProperties.Status = formStatus;

                        StatusType formStatusType = FormUtil.GetFormStatusType(form, reviewStatuses, organizationFormType);

                        form.ExtendedProperties.StatusType = formStatusType;

                        results.Add(form);
                    }
                }
            }

            return results;
        }

        public static IList<Form> SearchFormsBasic(String searchTerm, Nullable<Int32> formTypeId, IList<Group> groups)
        {
            if (String.IsNullOrEmpty(searchTerm))
            {
                return new List<Form>();
            }

            IList<Form> results = new List<Form>();

            Form formList = new Form();
            formList.FormStatusID = FormStatusConstants.ACTIVE;
            formList.FormTypeID = formTypeId;
            IList<Form> allForms = DataService.ListForms(formList);

            IList<Nullable<Int32>> allFormIds = allForms.Select(x => x.FormID).ToList();

            FormData formData = new FormData();
            formData.SearchProperties.FormDataXMLContains = searchTerm;
            formData.SearchProperties.FormIDIsIn = allFormIds;

            IDictionary<Nullable<Int32>, FormData> formDatas = DataService.ListFormDataByForm(formData);

            ReviewStatus statusSearch = new ReviewStatus();
            statusSearch.SearchProperties.FormIDIsIn = allFormIds;

            IDictionary<Nullable<Int32>, IList<ReviewStatus>> allReviewStatuses = DataService.ListReviewStatusesByForm(statusSearch);

            IList<OrganizationGroup> userOrganizationGroups = DataService.ListOrganizationGroupsForGroups(groups);

            foreach (Form form in allForms.OrderBy(x => x.FormNumber))
            {
                if (formDatas.ContainsKey(form.FormID))
                {
                    FormType formType = DataService.GetFormType(new FormType { FormTypeID = form.FormTypeID });

                    IList<ReviewStatus> reviewStatuses = allReviewStatuses.GetValueOrDefault(form.FormID, new List<ReviewStatus>());

                    if (PermissionUtil.CheckFormViewPermission(form, formType, reviewStatuses, groups, userOrganizationGroups))
                    {
                        form.ExtendedProperties.NumberAndSubject = String.Format("{0}: {1}", form.FormNumber, form.Subject);

                        results.Add(form);
                    }
                }
            }

            return results;
        }
    }
}
