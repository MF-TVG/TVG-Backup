using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Util;
using USAACE.eStaffing.Business.Enums;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Business.Util
{
    public static class EmailUtil
    {
        /// <summary>
        /// Builds and sends an e-mail based on the specified form, review status, notification list, e-mail template, and actor
        /// </summary>
        /// <param name="form">The form that is the subject of the e-mail</param>
        /// <param name="reviewStatus">The review status that needs to take action</param>
        /// <param name="reviewersToNotify">The list of reviewers that need to be notified</param>
        /// <param name="templateName">The e-mail template to use</param>
        /// <param name="actor">The review status that took the action</param>
        /// <param name="sendToCreators">Whether to send the e-mail to the form submitter</param>
        /// <param name="additionalReviewerEmail">An e-mail to be sent to a non-role based reviewer</param>
        public static void SendEmail(Form form, ReviewStatus reviewStatus, IList<ReviewStatus> reviewersToNotify, NotificationType notificationType, ReviewStatus actor, Boolean sendToCreators)
        {
            FormType formType = DataService.GetFormType(new FormType { FormTypeID = form.FormTypeID });

            String link = form.ExtendedProperties.FormLink;

            if (sendToCreators)
            {
                // Send to creators as well if set to

                String emailAddresses = GetGroupEmailAddresses(DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = form.SubmitterGroupID }), notificationType);

                if (!String.IsNullOrEmpty(emailAddresses))
                {
                    OrganizationFormType organizationFormType = new OrganizationFormType();
                    organizationFormType.FormTypeID = form.FormTypeID;
                    organizationFormType.OrganizationID = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = form.SubmitterGroupID }).OrganizationID;

                    organizationFormType = DataService.GetOrganizationFormType(organizationFormType);

                    String subjectTemplate = String.Empty;
                    String messageTemplate = String.Empty;

                    switch (notificationType)
                    {
                        case NotificationType.Review: subjectTemplate = organizationFormType.NotifyReviewSubject; messageTemplate = organizationFormType.NotifyReviewMessage; break;
                        case NotificationType.Reject: subjectTemplate = organizationFormType.NotifyRejectSubject; messageTemplate = organizationFormType.NotifyRejectMessage; break;
                        case NotificationType.Complete: subjectTemplate = organizationFormType.NotifyCompleteSubject; messageTemplate = organizationFormType.NotifyCompleteMessage; break;
                    }

                    String subject = GenerateTemplate(subjectTemplate, form, formType, reviewStatus, actor, link);
                    String message = GenerateTemplate(messageTemplate, form, formType, reviewStatus, actor, link);

                    SendEmail(emailAddresses, subject, message);
                }
            }

            if (reviewersToNotify != null)
            {
                foreach (ReviewStatus reviewer in reviewersToNotify)
                {
                    String emailAddresses = GetGroupEmailAddresses(DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = reviewer.ReviewerGroupID} ), notificationType);

                    if (!String.IsNullOrEmpty(emailAddresses))
                    {
                        OrganizationFormType organizationFormType = new OrganizationFormType();
                        organizationFormType.FormTypeID = form.FormTypeID;
                        organizationFormType.OrganizationID = DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = reviewer.ReviewerGroupID }).OrganizationID;

                        organizationFormType = DataService.GetOrganizationFormType(organizationFormType);

                        String subjectTemplate = String.Empty;
                        String messageTemplate = String.Empty;

                        switch (notificationType)
                        {
                            case NotificationType.Review: subjectTemplate = organizationFormType.NotifyReviewSubject; messageTemplate = organizationFormType.NotifyReviewMessage; break;
                            case NotificationType.Reject: subjectTemplate = organizationFormType.NotifyRejectSubject; messageTemplate = organizationFormType.NotifyRejectMessage; break;
                            case NotificationType.Complete: subjectTemplate = organizationFormType.NotifyCompleteSubject; messageTemplate = organizationFormType.NotifyCompleteMessage; break;
                        }

                        String subject = GenerateTemplate(subjectTemplate, form, formType, reviewStatus, actor, link);
                        String message = GenerateTemplate(messageTemplate, form, formType, reviewStatus, actor, link);

                        SendEmail(emailAddresses, subject, message);
                    }
                }
            }
        }

        /// <summary>
        /// Sends an e-mail based on a specified list of e-mail addresses, subject, and message
        /// </summary>
        /// <param name="emailAddresses">The recipients of the e-mail in semi-colon separated format</param>
        /// <param name="subject">The subject of the e-mail</param>
        /// <param name="message">The body of the e-mail</param>
        public static void SendEmail(String emailAddresses, String subject, String message)
        {
            try
            {
                String mailServerAddress = ConfigUtil.GetConfigurationValue("MailServer");
                String mailFromAddress = ConfigUtil.GetConfigurationValue("MailFromAddress");

                MailMessage mailMessage = new MailMessage(mailFromAddress, emailAddresses, subject.Replace("\r", String.Empty).Replace("\n", String.Empty), message);
                mailMessage.IsBodyHtml = true;

                SmtpClient client = new SmtpClient(mailServerAddress);
                client.Send(mailMessage);
            }
            catch (Exception)
            {

            }
        }

        public static String GetGroupEmailAddresses(OrganizationGroup group, NotificationType notificationType)
        {
            IDictionary<Nullable<Int32>, User> allUsers = DataService.ListUsersDictionary();

            GroupUser userGroup = new GroupUser();
            userGroup.GroupID = group.GroupID;

            IList<GroupUser> groupUsers = DataService.ListGroupUsers(userGroup);

            List<User> usersToEmail = new List<User>();

            foreach (GroupUser groupUser in groupUsers)
            {
                User user = allUsers[groupUser.UserID];

                if (user.IsADGroup == true)
                {
                    IList<User> adGroupUsers = UserService.GetADGroupUsers(user.UserName);

                    foreach (User adGroupUser in adGroupUsers)
                    {
                        if (CheckUserNotificationSetting(adGroupUser, notificationType))
                        {
                            usersToEmail.Add(adGroupUser);
                        }
                    }
                }
                else
                {
                    if (CheckUserNotificationSetting(user, notificationType))
                    {
                        usersToEmail.Add(user);
                    }
                }
            }

            if (usersToEmail.Count > 0)
            {
                return String.Join(";", usersToEmail.Where(x => !String.IsNullOrEmpty(x.UserEmail)).Select(x => x.UserEmail).ToArray());
            }
            else
            {
                return null;
            }
        }

        private static Boolean CheckUserNotificationSetting(User user, NotificationType notificationType)
        {
            return (user.NotifyReview == true && notificationType == NotificationType.Review)
                || (user.NotifyReject == true && notificationType == NotificationType.Reject)
                || (user.NotifyComplete == true && notificationType == NotificationType.Complete);
        }

        private static String GenerateTemplate(String template, Form form, FormType formType, ReviewStatus reviewer, ReviewStatus actor, String link)
        {
            return template != null ? template.Replace("{Title}", formType.FormTypeName)
                .Replace("{Subject}", form.Subject)
                .Replace("{Reviewer}", reviewer != null ? DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = reviewer.ReviewerGroupID }).OrganizationGroupName : null)
                .Replace("{Actor}", actor != null ? DataService.GetOrganizationGroup(new OrganizationGroup { OrganizationGroupID = actor.ReviewerGroupID }).OrganizationGroupName : null)
                .Replace("{Comments}", actor != null ? actor.Comments : null)
                .Replace("{Link}", link) : String.Empty;
        }
    }
}
