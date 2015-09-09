using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Business.Util
{
    public static class LogUtil
    {
        public static void LogSubmission(Nullable<Int32> formId, String submittingGroup, String userName)
        {
            FormLog log = new FormLog();
            log.FormID = formId;
            log.Action = "Submit";
            log.LogDate = DateTime.Now;
            log.Role = submittingGroup;
            log.UserName = userName;
            log.Notes = null;

            DataService.SaveFormLog(log);
        }

        public static void LogFormStatusChange(Nullable<Int32> formId, String newStatus, String role, String userName)
        {
            FormLog log = new FormLog();
            log.FormID = formId;
            log.Action = newStatus;
            log.LogDate = DateTime.Now;
            log.Role = role;
            log.UserName = userName;
            log.Notes = null;

            DataService.SaveFormLog(log);
        }

        public static void LogReviewStatusChange(Nullable<Int32> formId, String newStatus, String role, String userName)
        {
            FormLog log = new FormLog();
            log.FormID = formId;
            log.Action = newStatus;
            log.LogDate = DateTime.Now;
            log.Role = role;
            log.UserName = userName;
            log.Notes = null;

            DataService.SaveFormLog(log);
        }

        public static void LogReviewSignatureChange(Nullable<Int32> formId, Boolean signed, String role, String userName)
        {
            FormLog log = new FormLog();
            log.FormID = formId;
            log.Action = signed ? "Signed" : "Unsigned";
            log.LogDate = DateTime.Now;
            log.Role = role;
            log.UserName = userName;
            log.Notes = null;

            DataService.SaveFormLog(log);
        }

        public static void LogForwarding(Nullable<Int32> formId, String forwardingOrganization, String userName,
            String receivingOrganization, String routingChain)
        {
            FormLog log = new FormLog();
            log.FormID = formId;
            log.Action = "Forward";
            log.LogDate = DateTime.Now;
            log.Role = forwardingOrganization;
            log.UserName = userName;
            log.Notes = String.Format("To {0} following {1} routing chain", receivingOrganization, routingChain);

            DataService.SaveFormLog(log);
        }

        public static void LogModifyChain(Nullable<Int32> formId, String modifyingOrganization, String userName,
            Int32 itemsChanged, Int32 netAdd)
        {
            FormLog log = new FormLog();
            log.FormID = formId;
            log.Action = "Modify Chain";
            log.LogDate = DateTime.Now;
            log.Role = modifyingOrganization;
            log.UserName = userName;
            log.Notes = String.Format("{0} reviewers changed, {1} reviewers {2}", itemsChanged.ToString(), Math.Abs(netAdd), netAdd >= 0 ? "added" : "removed");

            DataService.SaveFormLog(log);
        }
    }
}
