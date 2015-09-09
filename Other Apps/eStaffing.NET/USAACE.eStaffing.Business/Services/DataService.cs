using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using USAACE.Common;
using USAACE.Common.Util;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.FormEntities;
using USAACE.eStaffing.Domain.LookupEntities;

namespace USAACE.eStaffing.Business.Services
{
    public static class DataService
    {
        /// <summary>
        /// Gets a list of all Forms
        /// </summary>
        /// <returns>A list of all Forms</returns>
        public static IList<Form> ListForms()
        {
            return new Form().ListAll<Form>();
        }

        /// <summary>
        /// Gets a list of all Forms
        /// </summary>
        /// <returns>A list of all Forms</returns>
        public static IList<Form> ListForms(Form form)
        {
            Form formToList = new Form();
            formToList.FormTypeID = form.FormTypeID;
            formToList.FormStatusID = form.FormStatusID;
            formToList.SearchProperties.SuspenseDateMinRange = form.SearchProperties.SuspenseDateMinRange;
            formToList.SearchProperties.SuspenseDateMaxRange = form.SearchProperties.SuspenseDateMaxRange;
            formToList.SearchProperties.SubmitDateMinRange = form.SearchProperties.SubmitDateMinRange;
            formToList.SearchProperties.SubmitDateMaxRange = form.SearchProperties.SubmitDateMaxRange;
            formToList.SearchProperties.SubjectContains = form.SearchProperties.SubjectContains;
            formToList.SearchProperties.FormTypeIDIsIn = form.SearchProperties.FormTypeIDIsIn;
            formToList.SearchProperties.FormStatusIDIsIn = form.SearchProperties.FormStatusIDIsIn;

            return formToList.Search<Form>();
        }

        /// <summary>
        /// Loads a Form based on a provided Form with Form ID value
        /// </summary>
        /// <param name="form">The Form containing the Form ID</param>
        /// <returns>The loaded Form</returns>
        public static Form LoadForm(Form form)
        {
            Form formToLoad = new Form();
            formToLoad.FormID = form.FormID;

            return formToLoad.Load() ? formToLoad : null;
        }

        /// <summary>
        /// Loads a Form based on a provided Form with Form ID value
        /// </summary>
        /// <param name="form">The Form containing the Form ID</param>
        /// <returns>The loaded Form</returns>
        public static FormAttachment LoadFormAttachment(FormAttachment attachment)
        {
            FormAttachment attachmentToLoad = new FormAttachment();
            attachmentToLoad.FormAttachmentID = attachment.FormAttachmentID;

            attachmentToLoad.Load();

            return attachmentToLoad;
        }

        /// <summary>
        /// Loads a Form based on a provided Form with Form ID value
        /// </summary>
        /// <param name="form">The Form containing the Form ID</param>
        /// <returns>The loaded Form</returns>
        public static FormAttachmentData LoadFormAttachmentData(FormAttachmentData attachmentData)
        {
            FormAttachmentData attachmentToLoad = new FormAttachmentData();
            attachmentToLoad.FormAttachmentID = attachmentData.FormAttachmentID;

            IList<FormAttachmentData> attachmentDataList = attachmentToLoad.Search<FormAttachmentData>();

            return attachmentDataList.Count > 0 ? attachmentDataList[0] : new FormAttachmentData { FormAttachmentID = attachmentData.FormAttachmentID };
        }

        /// <summary>
        /// Saves a Form
        /// </summary>
        /// <param name="form">The Form to save</param>
        /// <returns>The saved Form with Form ID populated if new</returns>
        public static Form SaveForm(Form form)
        {
            if (form.FormID.HasValue)
            {
                Form oldForm = new Form();
                oldForm.FormID = form.FormID;

                oldForm = DataService.LoadForm(oldForm);

                if (form.Submitted == true)
                {
                    if (form.SubmitDate.HasValue == false)
                    {
                        form.SubmitDate = DateTime.Now;
                    }

                    if (oldForm.Submitted != true)
                    {
                        LogUtil.LogSubmission(form.FormID, DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = form.SubmitterGroupID }).OrganizationGroupName,
                            form.ExtendedProperties.ActingUser);
                    }
                }

                if (oldForm.FormStatusID != form.FormStatusID)
                {
                    LogUtil.LogFormStatusChange(form.FormID, DataService.GetFormStatus(new FormStatus { FormStatusID = form.FormStatusID }).FormStatusName,
                        DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = form.SubmitterGroupID }).OrganizationGroupName,
                        form.ExtendedProperties.ActingUser);
                }

                form.Save();
            }
            else
            {
                if (form.Submitted == true)
                {
                    if (form.SubmitDate.HasValue == false)
                    {
                        form.SubmitDate = DateTime.Now;
                    }

                    form.Save();

                    LogUtil.LogSubmission(form.FormID, DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = form.SubmitterGroupID }).OrganizationGroupName,
                        form.ExtendedProperties.ActingUser);
                }
                else
                {
                    form.Save();
                }
            }

            return form;
        }

        public static FormData SaveFormData(FormData formData)
        {
            formData.Save();
            return formData;
        }

        /// <summary>
        /// Deletes a Form based on a provided Form with Form ID value
        /// </summary>
        /// <param name="form">The Form to delete</param>
        public static void DeleteForm(Form form)
        {
            form.Delete();
        }

        /// <summary>
        /// Deletes a Form based on a provided Form with Form ID value
        /// </summary>
        /// <param name="form">The Form to delete</param>
        public static void MarkCancelForm(Form form)
        {
            form.Load();
            form.FormStatusID = FormStatusConstants.CANCELLED;
            form.Submitted = false;
            form.SubmitDate = null;

            form = DataService.SaveForm(form);

            ReviewStatus formReviewStatus = new ReviewStatus();
            formReviewStatus.FormID = form.FormID;

            IList<ReviewStatus> reviewStatuses = DataService.ListReviewStatuses(formReviewStatus);

            foreach (ReviewStatus status in reviewStatuses)
            {
                status.Notified = false;
                status.ReviewActionID = null;
                status.Signed = false;
                status.Autopen = false;
                status.ActionDate = null;
                status.Comments = null;
                status.Save();
            }
        }

        /// <summary>
        /// Deletes a Form based on a provided Form with Form ID value
        /// </summary>
        /// <param name="form">The Form to delete</param>
        public static void UnmarkCancelForm(Form form)
        {
            form.Load();
            form.FormStatusID = FormStatusConstants.ACTIVE;

            form = DataService.SaveForm(form);
        }

        /// <summary>
        /// Gets a list of all FormTypes
        /// </summary>
        /// <returns>A list of all FormTypes</returns>
        public static IDictionary<Nullable<Int32>, FormType> ListFormTypeDictionary()
        {
            IDictionary<Nullable<Int32>, FormType> formTypes = CacheUtil.GetCache("FormTypeDictionary") as IDictionary<Nullable<Int32>, FormType>;

            if (formTypes == null)
            {
                formTypes = new FormType().ListAllDictionary<FormType>();
                CacheUtil.SetCache("FormTypeDictionary", formTypes);
            }

            return formTypes;
        }

        /// <summary>
        /// Gets a list of all FormTypes
        /// </summary>
        /// <returns>A list of all FormTypes</returns>
        public static IList<FormType> GetFormTypes()
        {
            IDictionary<Nullable<Int32>, FormType> formTypeDictionary = DataService.ListFormTypeDictionary();

            return formTypeDictionary.Values.ToList();
        }

        /// <summary>
        /// Loads a FormType based on a provided FormType with FormType ID value
        /// </summary>
        /// <param name="formType">The FormType containing the FormType ID</param>
        /// <returns>The loaded FormType</returns>
        public static FormType GetFormType(FormType formType)
        {
            IDictionary<Nullable<Int32>, FormType> formTypeDictionary = DataService.ListFormTypeDictionary();

            return formTypeDictionary.GetValueOrDefault(formType.FormTypeID);
        }

        /// <summary>
        /// Gets a list of all FormStatuss
        /// </summary>
        /// <returns>A list of all FormStatuss</returns>
        public static IDictionary<Nullable<Int32>, FormStatus> ListFormStatusDictionary()
        {
            IDictionary<Nullable<Int32>, FormStatus> formStatuses = CacheUtil.GetCache("FormStatusDictionary") as IDictionary<Nullable<Int32>, FormStatus>;

            if (formStatuses == null)
            {
                formStatuses = new FormStatus().ListAllDictionary<FormStatus>();
                CacheUtil.SetCache("FormStatusDictionary", formStatuses);
            }

            return formStatuses;
        }

        /// <summary>
        /// Gets a list of all FormStatuss
        /// </summary>
        /// <returns>A list of all FormStatuss</returns>
        public static IList<FormStatus> GetFormStatuses()
        {
            IDictionary<Nullable<Int32>, FormStatus> formStatusDictionary = DataService.ListFormStatusDictionary();

            return formStatusDictionary.Values.ToList();
        }

        /// <summary>
        /// Loads a FormStatus based on a provided FormStatus with FormStatus ID value
        /// </summary>
        /// <param name="formStatus">The FormStatus containing the FormStatus ID</param>
        /// <returns>The loaded FormStatus</returns>
        public static FormStatus GetFormStatus(FormStatus formStatus)
        {
            IDictionary<Nullable<Int32>, FormStatus> formStatusDictionary = DataService.ListFormStatusDictionary();

            return formStatusDictionary.GetValueOrDefault(formStatus.FormStatusID);
        }

        public static IDictionary<String, OrganizationFormType> ListOrganizationFormTypeDictionary()
        {
            IDictionary<String, OrganizationFormType> formTypeDictionary = CacheUtil.GetCache("OrganizationFormTypeDictionary") as IDictionary<String, OrganizationFormType>;

            if (formTypeDictionary == null)
            {
                formTypeDictionary = new Dictionary<String, OrganizationFormType>();

                foreach (OrganizationFormType formType in new OrganizationFormType().ListAll<OrganizationFormType>())
                {
                    String key = String.Format("{0}_{1}", formType.OrganizationID.ToStringSafe(), formType.FormTypeID.ToStringSafe());

                    if (!formTypeDictionary.ContainsKey(key))
                    {
                        formTypeDictionary.Add(key, formType);
                    }
                }

                CacheUtil.SetCache("OrganizationFormTypeDictionary", formTypeDictionary);
            }

            return formTypeDictionary;
        }

        public static OrganizationFormType GetOrganizationFormType(OrganizationFormType formType)
        {
            IDictionary<String, OrganizationFormType> formTypeDictionary = DataService.ListOrganizationFormTypeDictionary();

            String key = String.Format("{0}_{1}", formType.OrganizationID.ToStringSafe(), formType.FormTypeID.ToStringSafe());

            if (formTypeDictionary.ContainsKey(key))
            {
                return formTypeDictionary[key];
            }
            else
            {
                OrganizationFormType organizationFormType = new OrganizationFormType();
                organizationFormType.OrganizationID = formType.OrganizationID;
                organizationFormType.FormTypeID = formType.FormTypeID;
                organizationFormType.ParallelReview = false;

                organizationFormType = DataService.SaveOrganizationFormType(organizationFormType);

                return organizationFormType;
            }
        }

        public static OrganizationFormType SaveOrganizationFormType(OrganizationFormType formType)
        {
            formType.Save();
            CacheUtil.RemoveCache("OrganizationFormTypeDictionary");

            return formType;
        }

        /// <summary>
        /// Saves a FormType
        /// </summary>
        /// <param name="formType">The FormType to save</param>
        /// <returns>The saved FormType with FormType ID populated if new</returns>
        public static FormType SaveFormType(FormType formType)
        {
            formType.Save();
            CacheUtil.RemoveCache("FormTypeDictionary");

            return formType;
        }

        public static FormData LoadFormData(FormData formData)
        {
            FormData formDataToLoad = new FormData();
            formDataToLoad.FormID = formData.FormID;

            IList<FormData> formDatas = formDataToLoad.Search<FormData>();

            if (formDatas.Count > 0)
            {
                return formDatas.First();
            }
            else
            {
                formDataToLoad.Save();

                return formDataToLoad;
            }
        }

        public static FormData SaveFormData(FormData formData, FormEntityBase formSpecificData)
        {
            formData = DataService.LoadFormData(formData);
            formData.FormDataXML = formSpecificData.SaveToXml();

            formData.Save();

            return formData;
        }

        public static FormTypeLookup GetFormTypeLookup(FormTypeLookup lookup)
        {
            IDictionary<String, FormTypeLookup> lookupDictionary = DataService.ListFormTypeLookupDictionary();

            String key = String.Format("{0}_{1}_{2}", lookup.FormTypeID.ToStringSafe(), lookup.OrganizationID.ToStringSafe(), lookup.LookupName);

            return lookupDictionary.GetValueOrDefault(key);
        }

        public static IList<FormTypeLookup> GetFormTypeLookups()
        {
            IDictionary<String, FormTypeLookup> lookupDictionary = DataService.ListFormTypeLookupDictionary();

            return lookupDictionary.Values.ToList();
        }

        public static IDictionary<String, FormTypeLookup> ListFormTypeLookupDictionary()
        {
            IDictionary<String, FormTypeLookup> lookupDictionary = CacheUtil.GetCache("FormTypeLookupDictionary") as IDictionary<String, FormTypeLookup>;

            if (lookupDictionary == null)
            {
                lookupDictionary = new Dictionary<String, FormTypeLookup>();

                IList<FormTypeLookup> lookupList = new FormTypeLookup().ListAll<FormTypeLookup>();

                foreach (FormTypeLookup lookup in lookupList)
                {
                    String key = String.Format("{0}_{1}_{2}", lookup.FormTypeID.ToStringSafe(), lookup.OrganizationID.ToStringSafe(), lookup.LookupName);

                    lookupDictionary.Add(key, lookup);
                }

                CacheUtil.SetCache("FormTypeLookupDictionary", lookupDictionary);
            }

            return lookupDictionary;
        }

        public static FormTypeLookup SaveFormTypeLookup(FormTypeLookup lookupData)
        {
            lookupData.Save();

            CacheUtil.RemoveCache("FormTypeLookupDictionary");

            return lookupData;
        }

        /// <summary>
        /// Gets a list of FormLogs for a specifc Form
        /// </summary>
        /// <param name="formLog">A FormLog with FormID specified</param>
        /// <returns>A list of FormLogs for the specified Form</returns>
        public static IList<FormLog> ListFormLogs(FormLog formLog)
        {
            FormLog formLogsToList = new FormLog();
            formLogsToList.FormID = formLog.FormID;

            return formLogsToList.Search<FormLog>();
        }

        public static FormLog SaveFormLog(FormLog formLog)
        {
            formLog.Save();

            return formLog;
        }

        /// <summary>
        /// Gets a list of ErrorLogs
        /// </summary>
        /// <returns>A list of ErrorLogs</returns>
        public static IList<ErrorLog> ListErrorLogs()
        {
            return new ErrorLog().ListAll<ErrorLog>();
        }

        public static ErrorLog SaveErrorLog(ErrorLog errorLog)
        {
            errorLog.Save();

            return errorLog;
        }

        public static IDictionary<Nullable<Int32>, Group> ListGroupsDictionary()
        {
            IDictionary<Nullable<Int32>, Group> groupDictionary = CacheUtil.GetCache("GroupDictionary") as IDictionary<Nullable<Int32>, Group>;

            if (groupDictionary == null)
            {
                groupDictionary = new Group().ListAllDictionary<Group>();
                CacheUtil.SetCache("GroupDictionary", groupDictionary);
            }

            return groupDictionary;
        }

        public static IList<Group> GetGroups()
        {
            IDictionary<Nullable<Int32>, Group> groupDictionary = DataService.ListGroupsDictionary();

            return groupDictionary.Values.ToList();
        }

        /// <summary>
        /// Gets a list of all Users
        /// </summary>
        /// <returns>A list of all Users</returns>
        public static IList<User> ListUsers()
        {
            return new User().ListAll<User>();
        }

        public static IDictionary<Nullable<Int32>, User> ListUsersDictionary()
        {
            return new User().ListAllDictionary<User>();
        }

        /// <summary>
        /// Gets a list of all Users
        /// </summary>
        /// <returns>A list of all Users</returns>
        public static IList<User> ListUsers(User user)
        {
            User userToSearch = new User();
            userToSearch.SearchProperties.UserSIDIsIn = user.SearchProperties.UserSIDIsIn;

            return user.Search<User>();
        }

        /// <summary>
        /// Loads a Organization based on a provided Organization with Organization ID value
        /// </summary>
        /// <param name="organization">The Organization containing the Organization ID</param>
        /// <returns>The loaded Organization</returns>
        public static Organization LoadOrganization(Organization organization)
        {
            Organization organizationToLoad = new Organization();
            organizationToLoad.OrganizationID = organization.OrganizationID;

            organizationToLoad.Load();

            return organizationToLoad;
        }

        public static Organization SaveOrganization(Organization organization)
        {
            Boolean newOrganization = !organization.OrganizationID.HasValue;

            organization.Save();
            CacheUtil.RemoveCache("OrganizationDictionary");

            if (newOrganization)
            {
                foreach (FormType formType in DataService.GetFormTypes())
                {
                    OrganizationFormRouting routing = new OrganizationFormRouting();
                    routing.RoutingName = RoutingConstants.DEFAULT_ROUTING_CHAIN;
                    routing.OrganizationID = organization.OrganizationID;
                    routing.FormTypeID = formType.FormTypeID;

                    DataService.SaveOrganizationFormRouting(routing);

                    OrganizationFormType organizationFormType = new OrganizationFormType();
                    organizationFormType.OrganizationID = organization.OrganizationID;
                    organizationFormType.FormTypeID = formType.FormTypeID;
                    organizationFormType.ParallelReview = false;

                    DataService.SaveOrganizationFormType(organizationFormType);
                }
            }

            return organization;
        }

        /// <summary>
        /// Gets a list of all Organizations
        /// </summary>
        /// <returns>A list of all Organizations</returns>
        public static IList<Organization> ListOrganizations()
        {
            return new Organization().ListAll<Organization>();
        }

        /// <summary>
        /// Gets a list of all OrganizationGroups for an Organization
        /// </summary>
        /// <returns>A list of all OrganizationGroups for the Organization</returns>
        public static IList<OrganizationGroup> ListOrganizationGroups(OrganizationGroup group)
        {
            OrganizationGroup groupsToList = new OrganizationGroup();
            groupsToList.OrganizationID = group.OrganizationID;

            return groupsToList.Search<OrganizationGroup>();
        }

        /// <summary>
        /// Loads a OrganizationGroup based on a provided OrganizationGroup with OrganizationGroup ID value
        /// </summary>
        /// <param name="organizationGroup">The OrganizationGroup containing the OrganizationGroup ID</param>
        /// <returns>The loaded OrganizationGroup</returns>
        public static OrganizationGroup LoadOrganizationGroup(OrganizationGroup organizationGroup)
        {
            OrganizationGroup organizationGroupToLoad = new OrganizationGroup();
            organizationGroupToLoad.OrganizationGroupID = organizationGroup.OrganizationGroupID;

            organizationGroupToLoad.Load();

            return organizationGroupToLoad;
        }

        public static OrganizationGroup SaveOrganizationGroup(OrganizationGroup group)
        {
            Boolean newGroup = !group.OrganizationGroupID.HasValue;

            group.Save();
            CacheUtil.RemoveCache("OrganizationGroupDictionary");

            if (newGroup)
            {
                foreach (FormType formType in DataService.GetFormTypes())
                {
                    OrganizationFormActor actor = new OrganizationFormActor();
                    actor.OrganizationID = group.OrganizationID;
                    actor.OrganizationGroupID = group.OrganizationGroupID;
                    actor.FormTypeID = formType.FormTypeID;

                    DataService.SaveOrganizationFormActor(actor);
                }
            }

            return group;
        }

        public static void DeleteOrganizationGroup(OrganizationGroup group)
        {
            group.Delete();
            CacheUtil.RemoveCache("OrganizationGroupDictionary");
        }

        public static OrganizationFormActor SaveOrganizationFormActor(OrganizationFormActor actor)
        {
            actor.Save();
            CacheUtil.RemoveCache("OrganizationFormActorDictionaryByOrganizationGroupFormType");
            CacheUtil.RemoveCache("OrganizationFormActorDictionaryByOrganizationFormType");
            CacheUtil.RemoveCache("OrganizationFormActorList");

            return actor;
        }

        public static IDictionary<Nullable<Int32>, Organization> ListOrganizationDictionary()
        {
            IDictionary<Nullable<Int32>, Organization> organizationDictionary = CacheUtil.GetCache("OrganizationDictionary") as IDictionary<Nullable<Int32>, Organization>;

            if (organizationDictionary == null)
            {
                organizationDictionary = new Organization().ListAllDictionary<Organization>();
                CacheUtil.SetCache("OrganizationDictionary", organizationDictionary);
            }

            return organizationDictionary;
        }

        public static Organization GetOrganization(Organization organization)
        {
            IDictionary<Nullable<Int32>, Organization> organizationDictionary = DataService.ListOrganizationDictionary();

            return organizationDictionary.GetValueOrDefault(organization.OrganizationID);
        }

        public static IList<Organization> GetOrganizations()
        {
            IDictionary<Nullable<Int32>, Organization> organizationDictionary = DataService.ListOrganizationDictionary();

            return organizationDictionary.Values.ToList();
        }

        public static IDictionary<Nullable<Int32>, OrganizationGroup> ListOrganizationGroupDictionary()
        {
            IDictionary<Nullable<Int32>, OrganizationGroup> organizationGroupDictionary = CacheUtil.GetCache("OrganizationGroupDictionary") as IDictionary<Nullable<Int32>, OrganizationGroup>;

            if (organizationGroupDictionary == null)
            {
                organizationGroupDictionary = new OrganizationGroup().ListAllDictionary<OrganizationGroup>();
                CacheUtil.SetCache("OrganizationGroupDictionary", organizationGroupDictionary);
            }

            return organizationGroupDictionary;
        }

        public static OrganizationGroup GetOrganizationGroup(OrganizationGroup organizationGroup)
        {
            IDictionary<Nullable<Int32>, OrganizationGroup> organizationGroupDictionary = DataService.ListOrganizationGroupDictionary();

            return organizationGroupDictionary.GetValueOrDefault(organizationGroup.OrganizationGroupID);
        }

        public static IList<OrganizationGroup> GetOrganizationGroups()
        {
            IDictionary<Nullable<Int32>, OrganizationGroup> organizationGroupDictionary = DataService.ListOrganizationGroupDictionary();

            return organizationGroupDictionary.Values.ToList();
        }

        /// <summary>
        /// Loads a OrganizationFormType based on a provided OrganizationFormType with FormType ID value and Organization ID value
        /// </summary>
        /// <param name="organizationFormType">The OrganizationFormType containing the FormType ID value and Organization ID value</param>
        /// <returns>The loaded OrganizationFormType</returns>
        public static IList<OrganizationFormActor> ListOrganizationFormActors(OrganizationFormActor organizationFormActor, Boolean ensureComplete)
        {
            OrganizationFormActor organizationFormActorToList = new OrganizationFormActor();
            organizationFormActorToList.FormTypeID = organizationFormActor.FormTypeID;
            organizationFormActorToList.OrganizationID = organizationFormActor.OrganizationID;

            IList<OrganizationFormActor> actors = organizationFormActorToList.Search<OrganizationFormActor>();

            if (ensureComplete)
            {
                IList<OrganizationGroup> groups = DataService.GetOrganizationGroups().Where(x => x.OrganizationID == organizationFormActor.OrganizationID).ToList();

                foreach (OrganizationGroup group in groups)
                {
                    if (actors.Any(x => x.OrganizationGroupID == group.OrganizationGroupID) == false)
                    {
                        OrganizationFormActor newActor = new OrganizationFormActor();
                        newActor.OrganizationGroupID = group.OrganizationGroupID;
                        newActor.OrganizationID = group.OrganizationID;
                        newActor.FormTypeID = organizationFormActor.FormTypeID;
                        newActor = DataService.SaveOrganizationFormActor(newActor);

                        actors.Add(newActor);
                    }
                }
            }

            return actors;
        }

        /// <summary>
        /// Gets a list of ReviewStatuses for a specifc Form and/or Organization
        /// </summary>
        /// <param name="reviewStatus">A ReviewStatus with FormID and/or OrganizationID specified</param>
        /// <returns>A list of ReviewStatuses for the specified Form and/or Organization</returns>
        public static IList<ReviewStatus> ListReviewStatuses(ReviewStatus reviewStatus)
        {
            ReviewStatus reviewStatusesToList = new ReviewStatus();
            reviewStatusesToList.FormID = reviewStatus.FormID;
            reviewStatusesToList.SearchProperties.FormIDIsIn = reviewStatus.SearchProperties.FormIDIsIn;
            reviewStatusesToList.SearchProperties.ReviewerGroupIDIsIn = reviewStatus.SearchProperties.ReviewerGroupIDIsIn;

            return reviewStatusesToList.Search<ReviewStatus>();
        }

        /// <summary>
        /// Gets a list of all ReviewStatuses
        /// </summary>
        /// <returns>A list of all ReviewStatuses</returns>
        public static IList<ReviewStatus> ListReviewStatuses()
        {
            return new ReviewStatus().Search<ReviewStatus>();
        }

        /// <summary>
        /// Gets a list of all ReviewStatuses
        /// </summary>
        /// <returns>A list of all ReviewStatuses</returns>
        public static IDictionary<Nullable<Int32>, IList<ReviewStatus>> ListReviewStatusesByForm()
        {
            return ListReviewStatuses().GroupBy(x => x.FormID).ToDictionary(x => x.Key, x => (IList<ReviewStatus>)x.ToList());
        }

        /// <summary>
        /// Gets a list of all ReviewStatuses
        /// </summary>
        /// <returns>A list of all ReviewStatuses</returns>
        public static IDictionary<Nullable<Int32>, IList<ReviewStatus>> ListReviewStatusesByForm(ReviewStatus reviewStatus)
        {
            return ListReviewStatuses(reviewStatus).GroupBy(x => x.FormID).ToDictionary(x => x.Key, x => (IList<ReviewStatus>)x.ToList());
        }

        /// <summary>
        /// Saves a ReviewStatus
        /// </summary>
        /// <param name="reviewStatus">The ReviewStatus to save</param>
        /// <returns>The saved ReviewStatus with ReviewStatus ID populated if new</returns>
        public static ReviewStatus SaveReviewStatus(ReviewStatus reviewStatus)
        {
            if (reviewStatus.ReviewStatusID.HasValue)
            {
                ReviewStatus oldStatus = new ReviewStatus();
                oldStatus.ReviewStatusID = reviewStatus.ReviewStatusID;

                oldStatus.Load();

                if (oldStatus.ReviewActionID != reviewStatus.ReviewActionID && reviewStatus.ExtendedProperties.ActingUser != null)
                {
                    LogUtil.LogReviewStatusChange(reviewStatus.FormID, FormUtil.GetReviewActionString(reviewStatus),
                        DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = reviewStatus.ReviewerGroupID }).OrganizationGroupName,
                        reviewStatus.ExtendedProperties.ActingUser);
                }

                if (oldStatus.DigitalSignature.GetValueOrDefault(false) != reviewStatus.DigitalSignature.GetValueOrDefault(false))
                {
                    LogUtil.LogReviewSignatureChange(reviewStatus.FormID, reviewStatus.DigitalSignature == true,
                        DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = reviewStatus.ReviewerGroupID }).OrganizationGroupName,
                        reviewStatus.ExtendedProperties.ActingUser);
                }
            }

            reviewStatus.Save();
            return reviewStatus;
        }

        /// <summary>
        /// Deletes a ReviewStatus based on a provided ReviewStatus with ReviewStatus ID value
        /// </summary>
        /// <param name="reviewStatus">The ReviewStatus to delete</param>
        public static void DeleteReviewStatus(ReviewStatus reviewStatus)
        {
            reviewStatus.Delete();
        }

        /// <summary>
        /// Gets a list of all ReviewSignaturees
        /// </summary>
        /// <returns>A list of all ReviewSignaturees</returns>
        public static ReviewSignature LoadReviewSignature(ReviewSignature reviewSignature)
        {
            ReviewSignature signatureToLoad = new ReviewSignature();
            signatureToLoad.ReviewStatusID = reviewSignature.ReviewStatusID;

            return signatureToLoad.Search<ReviewSignature>().FirstOrDefault();
        }

        /// <summary>
        /// Saves a ReviewSignature
        /// </summary>
        /// <param name="reviewSignature">The ReviewSignature to save</param>
        /// <returns>The saved ReviewSignature with ReviewSignature ID populated if new</returns>
        public static ReviewSignature SaveReviewSignature(ReviewSignature reviewSignature)
        {
            reviewSignature.Save();
            return reviewSignature;
        }

        /// <summary>
        /// Deletes a ReviewSignature based on a provided ReviewSignature with ReviewSignature ID value
        /// </summary>
        /// <param name="reviewSignature">The ReviewSignature to delete</param>
        public static void DeleteReviewSignature(ReviewSignature reviewSignature)
        {
            reviewSignature.Delete();
        }

        /// <summary>
        /// Gets a list of FormAttachments for a specifc Form
        /// </summary>
        /// <param name="attachment">A FormAttachment with FormID specified</param>
        /// <returns>A list of FormAttachments for the specified Form</returns>
        public static IList<FormAttachment> ListFormAttachments(FormAttachment attachment)
        {
            FormAttachment attachmentsToList = new FormAttachment();
            attachmentsToList.FormID = attachment.FormID;
            attachmentsToList.ReviewStatusID = attachment.ReviewStatusID;

            return attachmentsToList.Search<FormAttachment>();
        }

        /// <summary>
        /// Saves a FormAttachment
        /// </summary>
        /// <param name="attachment">The FormAttachment to save</param>
        /// <returns>The saved FormAttachment with FormAttachment ID populated if new</returns>
        public static FormAttachment SaveFormAttachment(FormAttachment attachment)
        {
            attachment.Save();
            return attachment;
        }

        /// <summary>
        /// Saves a FormAttachmentData
        /// </summary>
        /// <param name="data">The FormAttachmentData to save</param>
        /// <returns>The saved FormAttachmentData with FormAttachmentData ID populated if new</returns>
        public static FormAttachmentData SaveFormAttachmentData(FormAttachmentData data)
        {
            data.Save();
            return data;
        }

        /// <summary>
        /// Deletes a FormAttachment based on a provided FormAttachment with FormAttachment ID value
        /// </summary>
        /// <param name="attachment">The FormAttachment to delete</param>
        public static void DeleteFormAttachment(FormAttachment attachment)
        {
            attachment.Delete();
        }

        /// <summary>
        /// Loads a Form based on a provided Form with Form ID value
        /// </summary>
        /// <param name="form">The Form containing the Form ID</param>
        /// <returns>The loaded Form</returns>
        public static User GetUser(User user, Boolean createIfNotMember)
        {
            User userToLoad = new User();
            userToLoad.UserName = user.UserName;
            userToLoad.AuthenticationType = user.ExtendedProperties.AuthenticationMethod;
            userToLoad.UserSID = user.UserSID;

            IList<User> users = userToLoad.Search<User>();

            if (users.Count == 1)
            {
                return users[0];
            }
            else if (createIfNotMember)
            {
                UserService.GetUserInformation(userToLoad);

                userToLoad.NotifyComplete = true;
                userToLoad.NotifyReject = true;
                userToLoad.NotifyReview = true;
                userToLoad = SaveUser(userToLoad);

                return userToLoad;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Loads a User based on a provided User with User ID value
        /// </summary>
        /// <param name="user">The User containing the User ID</param>
        /// <returns>The loaded User</returns>
        public static User LoadUser(User user)
        {
            User userToLoad = new User();
            userToLoad.UserID = user.UserID;

            userToLoad.Load();

            return userToLoad;
        }

        /// <summary>
        /// Saves a User
        /// </summary>
        /// <param name="form">The User to save</param>
        /// <returns>The saved Form with User ID populated if new</returns>
        public static User SaveUser(User user)
        {
            user.Save();
            return user;
        }

        /// <summary>
        /// Loads a Group based on a provided Group with Group ID value
        /// </summary>
        /// <param name="group">The Group containing the Group ID</param>
        /// <returns>The loaded Group</returns>
        public static Group LoadGroup(Group group)
        {
            Group groupToLoad = new Group();
            groupToLoad.GroupID = group.GroupID;

            groupToLoad.Load();

            return groupToLoad;
        }

        /// <summary>
        /// Saves a Group
        /// </summary>
        /// <param name="form">The Group to save</param>
        /// <returns>The saved Form with Group ID populated if new</returns>
        public static Group SaveGroup(Group group)
        {
            group.Save();
            CacheUtil.RemoveCache("GroupDictionary");

            return group;
        }

        public static void DeleteGroup(Group group)
        {
            group.Delete();
            CacheUtil.RemoveCache("GroupDictionary");
        }

        /// <summary>
        /// Saves a GroupUser
        /// </summary>
        /// <param name="form">The GroupUser to save</param>
        /// <returns>The saved Form with GroupUser ID populated if new</returns>
        public static GroupUser SaveGroupUser(GroupUser groupUser)
        {
            groupUser.Save();
            return groupUser;
        }

        public static void DeleteGroupUser(GroupUser groupUser)
        {
            groupUser.Delete();
        }

        /// <summary>
        /// Gets a list of all GroupUsers for an Group
        /// </summary>
        /// <returns>A list of all GroupUsers for the Group</returns>
        public static IList<GroupUser> ListGroupUsers(GroupUser group)
        {
            GroupUser groupUsersToList = new GroupUser();
            groupUsersToList.GroupID = group.GroupID;
            groupUsersToList.UserID = group.UserID;
            groupUsersToList.SearchProperties.UserIDIsIn = group.SearchProperties.UserIDIsIn;

            return groupUsersToList.Search<GroupUser>();
        }

        public static IDictionary<Nullable<Int32>, IList<GroupUser>> ListGroupUsersByGroup()
        {
            return new GroupUser().ListAll<GroupUser>().GroupBy(x => x.GroupID).ToDictionary(x => x.Key, x => (IList<GroupUser>)x.ToList());
        }

        public static IList<OrganizationGroup> ListOrganizationGroupsForGroups(IList<Group> groups)
        {
            return groups != null ? DataService.GetOrganizationGroups().Where(x => groups.Any(y => y.GroupID == x.GroupID)).ToList() : new List<OrganizationGroup>();
        }

        public static OrganizationFormDefault LoadOrganizationFormDefault(OrganizationFormDefault formDefault)
        {
            OrganizationFormDefault defaultToSearch = new OrganizationFormDefault();
            defaultToSearch.FormTypeID = formDefault.FormTypeID;
            defaultToSearch.OrganizationGroupID = formDefault.OrganizationGroupID;

            IList<OrganizationFormDefault> defaults = defaultToSearch.Search<OrganizationFormDefault>();

            return defaults.Count > 0 ? defaults.First() : new OrganizationFormDefault();
        }

        public static OrganizationFormDefault SaveOrganizationFormDefault(OrganizationFormDefault formDefault, FormEntityBase formSpecificData)
        {
            formDefault = DataService.LoadOrganizationFormDefault(formDefault);
            formDefault.FormDataXML = formSpecificData.SaveToXml();

            formDefault.Save();

            return formDefault;
        }

        public static OrganizationFormRouting LoadOrganizationFormRouting(OrganizationFormRouting routing)
        {
            routing.Load();
            return routing;
        }

        public static IList<OrganizationFormRouting> ListOrganizationFormRoutings(OrganizationFormRouting routing)
        {
            OrganizationFormRouting routingToSearch = new OrganizationFormRouting();
            routingToSearch.FormTypeID = routing.FormTypeID;
            routingToSearch.OrganizationID = routing.OrganizationID;

            return routingToSearch.Search<OrganizationFormRouting>();
        }

        public static OrganizationFormRouting SaveOrganizationFormRouting(OrganizationFormRouting routing)
        {
            routing.Save();
            return routing;
        }

        public static void DeleteOrganizationFormRouting(OrganizationFormRouting routing)
        {
            routing.Delete();
        }

        public static IList<OrganizationFormReviewer> ListOrganizationFormRoutingReviewers(OrganizationFormReviewer reviewer)
        {
            OrganizationFormReviewer reviewerToSearch = new OrganizationFormReviewer();
            reviewerToSearch.OrganizationFormRoutingID = reviewer.OrganizationFormRoutingID;

            return reviewerToSearch.Search<OrganizationFormReviewer>();
        }

        public static OrganizationFormReviewer SaveOrganizationFormReviewer(OrganizationFormReviewer reviewer)
        {
            reviewer.Save();
            return reviewer;
        }

        public static void DeleteOrganizationFormReviewer(OrganizationFormReviewer reviewer)
        {
            reviewer.Delete();
        }

        public static IList<OrganizationForwarding> ListOrganizationForwardings(OrganizationForwarding forward)
        {
            OrganizationForwarding forwardToSearch = new OrganizationForwarding();
            forwardToSearch.FormTypeID = forward.FormTypeID;
            forwardToSearch.ReceiveOrganizationID = forward.ReceiveOrganizationID;
            forwardToSearch.ForwardOrganizationID = forward.ForwardOrganizationID;

            return forwardToSearch.Search<OrganizationForwarding>();
        }

        public static OrganizationForwarding SaveOrganizationForwarding(OrganizationForwarding forward)
        {
            forward.Save();
            return forward;
        }

        public static void DeleteOrganizationForwarding(OrganizationForwarding forward)
        {
            forward.Delete();
        }

        public static IList<OrganizationFormActor> ListOrganizationFormActors()
        {
            IList<OrganizationFormActor> organizationFormActorList = CacheUtil.GetCache("OrganizationFormActorList") as IList<OrganizationFormActor>;

            if (organizationFormActorList == null)
            {
                organizationFormActorList = new OrganizationFormActor().ListAll<OrganizationFormActor>();
                CacheUtil.SetCache("OrganizationFormActorList", organizationFormActorList);
            }

            return organizationFormActorList;
        }

        public static IDictionary<String, IList<OrganizationFormActor>> ListOrganizationFormActorDictionaryByOrganizationFormType()
        {
            IDictionary<String, IList<OrganizationFormActor>> formActorDictionary = CacheUtil.GetCache("OrganizationFormActorDictionaryByOrganizationFormType") as IDictionary<String, IList<OrganizationFormActor>>;

            if (formActorDictionary == null)
            {
                IList<OrganizationFormActor> formActors = DataService.ListOrganizationFormActors();

                formActorDictionary = new Dictionary<String, IList<OrganizationFormActor>>();

                foreach (OrganizationFormActor actor in formActors)
                {
                    String key = String.Format("{0}_{1}", actor.OrganizationID.ToStringSafe(), actor.FormTypeID.ToStringSafe());

                    if (!formActorDictionary.ContainsKey(key))
                    {
                        formActorDictionary.Add(key, new List<OrganizationFormActor>());
                    }

                    formActorDictionary[key].Add(actor);
                }

                CacheUtil.SetCache("OrganizationFormActorDictionaryByOrganizationFormType", formActorDictionary);
            }

            return formActorDictionary;
        }

        public static IList<OrganizationFormActor> GetOrganizationFormActorByOrganizationFormType(Organization organization, FormType formType)
        {
            IDictionary<String, IList<OrganizationFormActor>> formActorDictionary = DataService.ListOrganizationFormActorDictionaryByOrganizationFormType();

            String key = String.Format("{0}_{1}", organization.OrganizationID.ToStringSafe(), formType.FormTypeID.ToStringSafe());

            return formActorDictionary.GetValueOrDefault(key, new List<OrganizationFormActor>());
        }

        public static IDictionary<String, OrganizationFormActor> ListOrganizationFormActorDictionaryByOrganizationGroupFormType()
        {
            IDictionary<String, OrganizationFormActor> formActorDictionary = CacheUtil.GetCache("OrganizationFormActorDictionaryByOrganizationGroupFormType") as IDictionary<String, OrganizationFormActor>;

            if (formActorDictionary == null)
            {
                IList<OrganizationFormActor> formActors = DataService.ListOrganizationFormActors();

                formActorDictionary = new Dictionary<String, OrganizationFormActor>();

                foreach (OrganizationFormActor actor in formActors)
                {
                    String key = String.Format("{0}_{1}", actor.OrganizationGroupID.ToStringSafe(), actor.FormTypeID.ToStringSafe());

                    if (!formActorDictionary.ContainsKey(key))
                    {
                        formActorDictionary.Add(key, actor);
                    }
                }

                CacheUtil.SetCache("OrganizationFormActorDictionaryByOrganizationGroupFormType", formActorDictionary);
            }

            return formActorDictionary;
        }

        public static OrganizationFormActor GetOrganizationFormActorByOrganizationGroupFormType(OrganizationGroup organizationGroup, FormType formType)
        {
            IDictionary<String, OrganizationFormActor> formActorDictionary = ListOrganizationFormActorDictionaryByOrganizationGroupFormType();

            String key = String.Format("{0}_{1}", organizationGroup.OrganizationGroupID.ToStringSafe(), formType.FormTypeID.ToStringSafe());

            return formActorDictionary.GetValueOrDefault(key, new OrganizationFormActor());
        }

        public static IDictionary<Nullable<Int32>, ReviewAction> ListReviewActionDictionary()
        {
            IDictionary<Nullable<Int32>, ReviewAction> reviewActionDictionary = CacheUtil.GetCache("ReviewActionDictionary") as IDictionary<Nullable<Int32>, ReviewAction>;

            if (reviewActionDictionary == null)
            {
                reviewActionDictionary = new ReviewAction().ListAllDictionary<ReviewAction>();
                CacheUtil.SetCache("ReviewActionDictionary", reviewActionDictionary);
            }

            return reviewActionDictionary;
        }

        public static ReviewAction GetReviewAction(ReviewAction reviewAction)
        {
            IDictionary<Nullable<Int32>, ReviewAction> reviewActionDictionary = DataService.ListReviewActionDictionary();

            return reviewActionDictionary.GetValueOrDefault(reviewAction.ReviewActionID);
        }

        public static IList<ReviewAction> GetReviewActions()
        {
            IDictionary<Nullable<Int32>, ReviewAction> reviewActionDictionary = DataService.ListReviewActionDictionary();

            return reviewActionDictionary.Values.ToList();
        }

        public static IDictionary<Nullable<Int32>, ReviewRole> ListReviewRoleDictionary()
        {
            IDictionary<Nullable<Int32>, ReviewRole> reviewRoleDictionary = CacheUtil.GetCache("ReviewRoleDictionary") as IDictionary<Nullable<Int32>, ReviewRole>;

            if (reviewRoleDictionary == null)
            {
                reviewRoleDictionary = new ReviewRole().ListAllDictionary<ReviewRole>();
                CacheUtil.SetCache("ReviewRoleDictionary", reviewRoleDictionary);
            }

            return reviewRoleDictionary;
        }

        public static ReviewRole GetReviewRole(ReviewRole reviewRole)
        {
            IDictionary<Nullable<Int32>, ReviewRole> reviewRoleDictionary = DataService.ListReviewRoleDictionary();

            return reviewRoleDictionary.GetValueOrDefault(reviewRole.ReviewRoleID);
        }

        public static IList<ReviewRole> GetReviewRoles()
        {
            IDictionary<Nullable<Int32>, ReviewRole> reviewRoleDictionary = DataService.ListReviewRoleDictionary();

            return reviewRoleDictionary.Values.ToList();
        }

        public static IDictionary<Nullable<Int32>, IList<ReviewAction>> ListReviewActionDictionaryByFormActionType()
        {
            IDictionary<Nullable<Int32>, IList<ReviewAction>> reviewActionDictionary = CacheUtil.GetCache("ReviewActionDictionaryByFormActionType") as IDictionary<Nullable<Int32>, IList<ReviewAction>>;

            if (reviewActionDictionary == null)
            {
                IList<ReviewAction> reviewActions = DataService.GetReviewActions();

                reviewActionDictionary = new Dictionary<Nullable<Int32>, IList<ReviewAction>>();

                foreach (ReviewAction action in reviewActions)
                {
                    if (!reviewActionDictionary.ContainsKey(action.FormActionTypeID))
                    {
                        reviewActionDictionary.Add(action.FormActionTypeID, new List<ReviewAction>());
                    }

                    reviewActionDictionary[action.FormActionTypeID].Add(action);
                }

                CacheUtil.SetCache("ReviewActionDictionaryByFormActionType", reviewActionDictionary);
            }

            return reviewActionDictionary;
        }

        public static IList<ReviewAction> GetReviewActionsByFormActionType(FormActionType actionType)
        {
            IDictionary<Nullable<Int32>, IList<ReviewAction>> reviewActionDictionary = DataService.ListReviewActionDictionaryByFormActionType();

            return reviewActionDictionary.GetValueOrDefault(actionType.FormActionTypeID, new List<ReviewAction>());
        }

        public static IDictionary<Nullable<Int32>, FormActionType> ListFormActionTypeDictionary()
        {
            IDictionary<Nullable<Int32>, FormActionType> formActionTypeDictionary = CacheUtil.GetCache("FormActionTypeDictionary") as IDictionary<Nullable<Int32>, FormActionType>;

            if (formActionTypeDictionary == null)
            {
                formActionTypeDictionary = new FormActionType().ListAllDictionary<FormActionType>();
                CacheUtil.SetCache("FormActionTypeDictionary", formActionTypeDictionary);
            }

            return formActionTypeDictionary;
        }

        public static FormActionType GetFormActionType(FormActionType formActionType)
        {
            IDictionary<Nullable<Int32>, FormActionType> formActionTypeDictionary = DataService.ListFormActionTypeDictionary();

            return formActionTypeDictionary.GetValueOrDefault(formActionType.FormActionTypeID);
        }

        public static IList<FormActionType> GetFormActionTypes()
        {
            IDictionary<Nullable<Int32>, FormActionType> formActionTypeDictionary = DataService.ListFormActionTypeDictionary();

            return formActionTypeDictionary.Values.ToList();
        }

        public static IDictionary<Nullable<Int32>, FormData> ListFormDataByForm(FormData formData)
        {
            IDictionary<Nullable<Int32>, FormData> formDataDictionary = new Dictionary<Nullable<Int32>, FormData>();

            foreach (FormData data in formData.Search<FormData>())
            {
                formDataDictionary.Add(data.FormID, data);
            }

            return formDataDictionary;
        }

        public static void ResetCache()
        {
            CacheUtil.RemoveCache("FormActionTypeDictionary");
            CacheUtil.RemoveCache("FormStatusDictionary");
            CacheUtil.RemoveCache("FormTypeDictionary");
            CacheUtil.RemoveCache("FormTypeLookupDictionary");
            CacheUtil.RemoveCache("GroupDictionary");
            CacheUtil.RemoveCache("OrganizationDictionary");
            CacheUtil.RemoveCache("OrganizationGroupDictionary");
            CacheUtil.RemoveCache("OrganizationFormActorList");
            CacheUtil.RemoveCache("OrganizationFormActorDictionaryByOrganizationFormType");
            CacheUtil.RemoveCache("OrganizationFormActorDictionaryByOrganizationGroupFormType");
            CacheUtil.RemoveCache("OrganizationFormTypeDictionary");
            CacheUtil.RemoveCache("ReviewActionDictionary");
            CacheUtil.RemoveCache("ReviewActionDictionaryByFormActionType");
            CacheUtil.RemoveCache("ReviewRoleDictionary");
        }
    }
}
