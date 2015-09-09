using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Enums;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Business.Util
{
    public static class PermissionUtil
    {
        public const String ADMINISTRATOR_GROUP = "Administrators";

        public static IList<OrganizationGroup> CheckFormNewSubmitPermission(FormType formType, IList<OrganizationGroup> organizationGroups)
        {
            IList<OrganizationGroup> submitGroups = new List<OrganizationGroup>();

            foreach (OrganizationGroup organizationGroup in organizationGroups)
            {
                OrganizationFormActor formActor = DataService.GetOrganizationFormActorByOrganizationGroupFormType(organizationGroup, formType);

                if (formActor != null && (formActor.CanAdmin == true || formActor.CanSubmit == true))
                {
                    submitGroups.Add(organizationGroup);
                }
            }

            return submitGroups;
        }

        public static Boolean CheckFormChooseRoutingPermission(FormType formType, IList<Group> groups, OrganizationGroup organizationGroup)
        {
            if (CheckAdminPermission(groups))
            {
                return true;
            }

            OrganizationFormActor formActor = DataService.GetOrganizationFormActorByOrganizationGroupFormType(organizationGroup, formType);

            return formActor != null && (formActor.CanAdmin == true || formActor.CanChooseRoute == true);
        }

        public static Boolean CheckFormIsSubmitter(Form form, IList<OrganizationGroup> organizationGroups)
        {
            return organizationGroups.Any(x => x.OrganizationGroupID == form.SubmitterGroupID);
        }

        public static Boolean CheckFormCurrentEditPermission(Form form, FormType formType, IList<ReviewStatus> reviewStatuses, IList<Group> groups, IList<OrganizationGroup> organizationGroups)
        {
            if (form.Submitted != true && organizationGroups.Any(x => x.OrganizationGroupID == form.SubmitterGroupID))
            {
                return true;
            }
            else if (form.Submitted == true)
            {
                if (reviewStatuses.Any(x => x.DigitalSignature == true))
                {
                    return false;
                }

                foreach (OrganizationGroup organizationGroup in organizationGroups.Where(x => reviewStatuses.Any(y => y.ReviewerGroupID == x.OrganizationGroupID)))
                {
                    OrganizationFormActor formActor = DataService.GetOrganizationFormActorByOrganizationGroupFormType(organizationGroup, formType);

                    if (formActor != null && formActor.CanEditSubmission == true)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static Boolean CheckFormViewPermission(Form form, FormType formType, IList<ReviewStatus> reviewStatuses, IList<Group> groups, IList<OrganizationGroup> organizationGroups)
        {
            if (CheckAdminPermission(groups))
            {
                return true;
            }
            else if (organizationGroups.Any(x => x.OrganizationGroupID == form.SubmitterGroupID || 
                (form.FormStatusID != FormStatusConstants.DRAFT && reviewStatuses.Any(y => y.ReviewerGroupID == x.OrganizationGroupID))))
            {
                return true;
            }
            else if (form.Submitted == true)
            {
                foreach (OrganizationGroup organizationGroup in organizationGroups.Where(x => reviewStatuses.Any(y => y.ReviewerGroupID == x.OrganizationGroupID)))
                {
                    OrganizationFormActor formActor = DataService.GetOrganizationFormActorByOrganizationGroupFormType(organizationGroup, formType);

                    if (formActor != null && formActor.CanView == true)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static Boolean CheckReviewStatusPermission(ReviewStatus reviewStatus, IList<Group> groups, IList<OrganizationGroup> organizationGroups)
        {
            if (CheckAdminPermission(groups))
            {
                return true;
            }
            else
            {
                return organizationGroups.Any(x => x.OrganizationGroupID == reviewStatus.ReviewerGroupID);
            }
        }

        public static Boolean CheckFormIsReviewer(Form form, IList<ReviewStatus> reviewStatuses, IList<OrganizationGroup> organizationGroups)
        {
            return form.FormStatusID != FormStatusConstants.DRAFT && organizationGroups.Any(x => reviewStatuses.Any(y => y.ReviewerGroupID == x.OrganizationGroupID));
        }

        public static Boolean CheckReviewAdminPermission(Organization organization, FormType formType, IList<Group> groups, IList<OrganizationGroup> organizationGroups)
        {
            if (CheckAdminPermission(groups))
            {
                return true;
            }

            foreach (OrganizationGroup organizationGroup in organizationGroups.Where(x => x.OrganizationID == organization.OrganizationID))
            {
                OrganizationFormActor formActor = DataService.GetOrganizationFormActorByOrganizationGroupFormType(organizationGroup, formType);

                if (formActor != null && formActor.CanAdmin == true)
                {
                    return true;
                }
            }

            return false;
        }

        public static Boolean CheckReviewViewCommentsPermission(Organization organization, FormType formType, IList<Group> groups, IList<OrganizationGroup> organizationGroups)
        {
            foreach (OrganizationGroup organizationGroup in organizationGroups.Where(x => x.OrganizationID == organization.OrganizationID))
            {
                OrganizationFormActor formActor = DataService.GetOrganizationFormActorByOrganizationGroupFormType(organizationGroup, formType);

                if (formActor != null && formActor.CanSeeComments == true)
                {
                    return true;
                }
            }

            return false;
        }

        public static Boolean CheckReviewAutopenPermission(FormType formType, ReviewStatus reviewStatus, IList<Group> groups)
        {
            OrganizationGroup organizationGroup = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = reviewStatus.ReviewerGroupID });

            OrganizationFormActor formActor = DataService.GetOrganizationFormActorByOrganizationGroupFormType(organizationGroup, formType);

            return formActor != null && formActor.CanAssignAutopen == true;
        }

        public static Boolean CheckReviewForwardPermission(Organization organization, FormType formType, IList<Group> groups, IList<OrganizationGroup> organizationGroups)
        {
            foreach (OrganizationGroup organizationGroup in organizationGroups.Where(x => x.OrganizationID == organization.OrganizationID))
            {
                OrganizationFormActor formActor = DataService.GetOrganizationFormActorByOrganizationGroupFormType(organizationGroup, formType);

                if (formActor != null && formActor.CanForward == true)
                {
                    return true;
                }
            }

            return false;
        }

        public static Boolean CheckReviewChangeRoutingPermission(Organization organization, FormType formType, IList<Group> groups, IList<OrganizationGroup> organizationGroups)
        {
            foreach (OrganizationGroup organizationGroup in organizationGroups.Where(x => x.OrganizationID == organization.OrganizationID))
            {
                OrganizationFormActor formActor = DataService.GetOrganizationFormActorByOrganizationGroupFormType(organizationGroup, formType);

                if (formActor != null && formActor.CanChangeRoute == true)
                {
                    return true;
                }
            }

            return false;
        }

        public static Boolean CheckGroupViewPermission(Group group, IList<Group> groups)
        {
            return groups.Any(x => x.GroupID == group.GroupID);
        }

        public static Boolean CheckGroupEditPermission(Group group, IList<Group> groups)
        {
            return groups.Any(x => x.GroupID == group.GroupID && x.ExtendedProperties.IsAdmin == true);
        }

        public static Boolean CheckOrganizationViewPermission(Organization organization, IList<Group> groups)
        {
            if (CheckAdminPermission(groups))
            {
                return true;
            }

            IEnumerable<OrganizationGroup> organizationGroups = DataService.GetOrganizationGroups().Where(x => x.OrganizationID == organization.OrganizationID);

            return groups.Any(x => organizationGroups.Any(y => y.GroupID == x.GroupID));
        }

        public static Boolean CheckUserViewPermission(User user, User currentUser, IList<Group> groups)
        {
            return CheckAdminPermission(groups) || user.UserID == currentUser.UserID;
        }

        public static Boolean CheckAdminPermission(IList<Group> groups)
        {
            return groups.Any(x => x.GroupName == ADMINISTRATOR_GROUP);
        }

        public static IList<Group> CheckUserGroups(User user)
        {
            IDictionary<Nullable<Int32>, IList<GroupUser>> groupUserDictionary = DataService.ListGroupUsersByGroup();
            IDictionary<Nullable<Int32>, User> userDictionary = DataService.ListUsersDictionary();

            IList<String> adGroups = UserService.GetUserADGroups(user);

            IList<Group> memberGroups = new List<Group>();

            foreach (Group group in DataService.GetGroups())
            {
                if (groupUserDictionary.ContainsKey(group.GroupID))
                {
                    IList<GroupUser> groupUsers = groupUserDictionary[group.GroupID];

                    foreach (GroupUser groupUser in groupUsers)
                    {
                        if (groupUser.UserID == user.UserID)
                        {
                            memberGroups.Add(group);
                            break;
                        }
                        else
                        {
                            if (userDictionary.ContainsKey(groupUser.UserID) && adGroups.Any(x => x.ToUpper() == userDictionary[groupUser.UserID].UserName.ToUpper()))
                            {
                                memberGroups.Add(group);
                                break;
                            }
                        }
                    }
                }
            }

            return memberGroups;
        }
    }
}
