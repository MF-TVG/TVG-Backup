using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using USAACE.Common.Util;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Business.Services
{
    public static class UserService
    {
        public static Boolean GetUserInformation(User user)
        {
            String globalCatalog = ConfigUtil.GetConfigurationValue("GlobalCatalog");
            String domainString = ConfigUtil.GetConfigurationValue("DomainString");

            Boolean result = false;

            if (user.AuthenticationType == AuthenticationTypeConstants.WINDOWS_AUTH_NAME)
            {
                PrincipalContext context = new PrincipalContext(ContextType.Domain, globalCatalog, domainString);
                Principal principal = Principal.FindByIdentity(context, user.UserName);

                if (principal is GroupPrincipal)
                {
                    GroupPrincipal groupPrincipal = principal as GroupPrincipal;

                    user.UserDisplayName = groupPrincipal.Name;
                    user.UserSID = groupPrincipal.Sid.ToString();
                    user.IsADGroup = true;

                    result = true;
                }
                else if (principal is UserPrincipal)
                {
                    UserPrincipal userPrincipal = principal as UserPrincipal;

                    user.UserDisplayName = userPrincipal.DisplayName;
                    user.UserEmail = userPrincipal.EmailAddress;
                    user.UserSID = userPrincipal.Sid.ToString();
                    user.IsADGroup = false;

                    result = true;
                }

                context.Dispose();
            }
            else if (user.AuthenticationType == AuthenticationTypeConstants.SSO_AUTH_NAME)
            {
                user.UserDisplayName = user.UserName;
                user.UserEmail = user.UserName;

                result = true;
            }

            return result;
        }

        public static IList<User> SearchUser(String searchValue)
        {
            if (searchValue != null)
            {
                if (searchValue.Contains('\\'))
                {
                    // Assume Active Directory account

                    IList<User> users = DataService.ListUsers();

                    IList<User> userResults = users.Where(x => x.UserName.ToLower() == searchValue.ToLower()).ToList();

                    if (userResults.Count == 0)
                    {
                        User user = new User();

                        user.UserName = searchValue;
                        user.AuthenticationType = AuthenticationTypeConstants.WINDOWS_AUTH_NAME;

                        if (GetUserInformation(user))
                        {
                            user.ExtendedProperties.DisplayNameAndAuthMethod = String.Format("{0} ({1})", user.UserDisplayName, AuthenticationTypeConstants.WINDOWS_AUTH_NAME);

                            userResults.Add(user);
                        }
                    }

                    return userResults;
                }
                else if (searchValue.Contains('@'))
                {
                    // Assume E-mail Address or SSO

                    IList<User> users = DataService.ListUsers();

                    IList<User> userResults = users.Where(x => x.UserEmail != null && x.UserEmail.ToLower().Contains(searchValue.ToLower())).ToList();

                    if (userResults.Count == 0)
                    {
                        User user = new User();

                        user.UserName = searchValue;
                        user.UserDisplayName = searchValue;
                        user.UserEmail = searchValue;
                        user.ExtendedProperties.DisplayNameAndAuthMethod = String.Format("{0} ({1})", searchValue, AuthenticationTypeConstants.SSO_AUTH_NAME);

                        userResults.Add(user);
                    }

                    return userResults;
                }
                else
                {
                    IList<User> users = DataService.ListUsers();

                    IList<User> userResults = users.Where(x => (x.UserName != null && x.UserName.ToLower().Contains(searchValue.ToLower())) || (x.UserDisplayName != null && x.UserDisplayName.ToLower().StartsWith(searchValue.ToLower()))).ToList();

                    IList<Principal> principalList = SearchADUser(searchValue);

                    foreach (Principal principal in principalList)
                    {
                        User user = new User();
                        user.UserDisplayName = principal.DisplayName;
                        user.ExtendedProperties.DisplayNameAndAuthMethod = String.Format("{0} ({1})", principal.DisplayName, AuthenticationTypeConstants.WINDOWS_AUTH_NAME);
                        user.UserSID = principal.Sid.ToString();
                        user.AuthenticationType = AuthenticationTypeConstants.WINDOWS_AUTH_NAME;
                        user.UserName = String.Format("{0}\\{1}", GetDomainNameFromPrincipal(principal), principal.SamAccountName);

                        if (principal is UserPrincipal)
                        {
                            UserPrincipal userPrincipal = principal as UserPrincipal;

                            user.UserEmail = userPrincipal.EmailAddress;
                        }

                        if (!users.Any(x => x.UserDisplayName == user.UserDisplayName))
                        {
                            userResults.Add(user);
                        }
                    }

                    return userResults;
                }
            }
            else
            {
                return new List<User>();
            }
        }

        public static IList<Principal> SearchADUser(String displayName)
        {
            try
            {
                IList<Principal> principalResults = new List<Principal>();

                String globalCatalog = ConfigUtil.GetConfigurationValue("GlobalCatalog");
                String domainString = ConfigUtil.GetConfigurationValue("DomainString");

                PrincipalContext context = new PrincipalContext(ContextType.Domain, globalCatalog, domainString);

                UserPrincipal userSearchPrincipal = new UserPrincipal(context);
                userSearchPrincipal.DisplayName = displayName + "*";

                PrincipalSearcher userSearch = new PrincipalSearcher(userSearchPrincipal);

                foreach (Principal userPrincipal in userSearch.FindAll())
                {
                    principalResults.Add(userPrincipal);
                }

                userSearch.Dispose();

                GroupPrincipal groupSearchPrincipal = new GroupPrincipal(context);
                groupSearchPrincipal.SamAccountName = displayName + "*";

                PrincipalSearcher groupSearch = new PrincipalSearcher(groupSearchPrincipal);

                foreach (Principal groupPrincipal in groupSearch.FindAll())
                {
                    principalResults.Add(groupPrincipal);
                }

                groupSearch.Dispose();

                context.Dispose();

                return principalResults;
            }
            catch (Exception)
            {
                return new List<Principal>();
            }
        }

        public static IList<Group> GetUserGroups(User user)
        {
            IList<Group> userGroups = new List<Group>();

            IDictionary<Nullable<Int32>, Group> groups = DataService.ListGroupsDictionary();

            if (user.ExtendedProperties.UserSIDs == null)
            {
                GroupUser groupUser = new GroupUser();
                groupUser.UserID = user.UserID;

                IList<GroupUser> groupUsers = DataService.ListGroupUsers(groupUser);

                foreach (GroupUser groupItem in groupUsers)
                {
                    Group groupEntry = userGroups.FirstOrDefault(x => x.GroupID == groupItem.GroupID);

                    if (groupEntry == null)
                    {
                        groupEntry = groups[groupItem.GroupID];
                        userGroups.Add(groupEntry);
                    }

                    if (groupItem.Admin == true)
                    {
                        groupEntry.ExtendedProperties.IsAdmin = true;
                    }
                }
            }
            else
            {
                User userSearch = new User();
                userSearch.SearchProperties.UserSIDIsIn = user.ExtendedProperties.UserSIDs;

                IList<User> users = DataService.ListUsers(userSearch);

                GroupUser groupUser = new GroupUser();
                groupUser.SearchProperties.UserIDIsIn = users.Select(x => x.UserID).ToList();

                IList<GroupUser> groupUsers = DataService.ListGroupUsers(groupUser);

                foreach (GroupUser groupItem in groupUsers)
                {
                    Group groupEntry = userGroups.FirstOrDefault(x => x.GroupID == groupItem.GroupID);

                    if (groupEntry == null)
                    {
                        groupEntry = groups[groupItem.GroupID];
                        userGroups.Add(groupEntry);
                    }

                    if (groupItem.Admin == true)
                    {
                        groupEntry.ExtendedProperties.IsAdmin = true;
                    }
                }
            }

            return userGroups;
        }

        public static IList<User> GetADGroupUsers(String groupName)
        {
            String globalCatalog = ConfigUtil.GetConfigurationValue("GlobalCatalog");
            String domainString = ConfigUtil.GetConfigurationValue("DomainString");

            PrincipalContext context = new PrincipalContext(ContextType.Domain, globalCatalog, domainString);
            Principal principal = Principal.FindByIdentity(context, groupName);

            IList<User> users = new List<User>();
            IList<User> allUsers = DataService.ListUsers();

            if (principal is GroupPrincipal)
            {
                GroupPrincipal groupPrincipal = principal as GroupPrincipal;

                IList<Principal> groupUsers = groupPrincipal.GetMembers(true).ToList();

                foreach (UserPrincipal groupUser in groupUsers.OfType<UserPrincipal>())
                {
                    String groupUserName = GetDomainUserNameFromPrincipal(groupUser);

                    User user = allUsers.FirstOrDefault(x => x.UserName == groupUserName);

                    if (user == null)
                    {
                        user = new User();

                        user.UserName = groupUserName;
                        user.UserEmail = groupUser.EmailAddress;
                        user.NotifyComplete = true;
                        user.NotifyReject = true;
                        user.NotifyReview = true;
                    }

                    users.Add(user);
                }
            }

            context.Dispose();

            return users;
        }

        public static IList<String> GetUserADGroups(User user)
        {
            IList<String> results = new List<String>();

            if (user.AuthenticationType == AuthenticationTypeConstants.WINDOWS_AUTH_NAME)
            {
                String globalCatalog = ConfigUtil.GetConfigurationValue("GlobalCatalog");
                String domainString = ConfigUtil.GetConfigurationValue("DomainString");

                PrincipalContext context = new PrincipalContext(ContextType.Domain, globalCatalog, domainString);
                Principal principal = Principal.FindByIdentity(context, user.UserName);

                if (principal is UserPrincipal)
                {
                    PrincipalSearchResult<Principal> groups = (principal as UserPrincipal).GetAuthorizationGroups();

                    for (int i = 0; i < groups.Count() - 1; i++)
                    {
                        try
                        {
                            Principal group = groups.ElementAt(i);

                            if (group != null)
                            {
                                results.Add(GetDomainUserNameFromPrincipal(group));
                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }

                context.Dispose();
            }

            return results.Where(x => !String.IsNullOrEmpty(x)).Distinct().ToList();
        }

        private static String GetDomainUserNameFromPrincipal(Principal principal)
        {
            if (!String.IsNullOrEmpty(principal.DistinguishedName) && !String.IsNullOrEmpty(principal.SamAccountName))
            {
                return String.Format("{0}\\{1}", GetDomainNameFromPrincipal(principal), principal.SamAccountName);
            }
            else
            {
                return null;
            }
        }

        private static String GetDomainNameFromPrincipal(Principal principal)
        {
            if (principal.DistinguishedName != null)
            {
                DirectoryEntry entry = principal.GetUnderlyingObject() as DirectoryEntry;

                while (!entry.Name.StartsWith("DC="))
                {
                    entry = entry.Parent;
                }

                return entry.Name.Replace("DC=", String.Empty).ToUpper();
            }
            else
            {
                return null;
            }
        }
    }
}
