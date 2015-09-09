using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Entities;
using USAACE.eStaffing.Domain.FormEntities;

namespace USAACE.eStaffing.Domain.Entities
{
    public partial class ErrorLogExtended
    {

    }

    public partial class FormExtended
    {
        public ReviewStatus ChangedReviewStatus { get; set; }
        public FormEntityBase FormData { get; set; }
        public String FormTypeName { get; set; }
        public IList<ReviewStatus> Reviews { get; set; }
        public String ActingUser { get; set; }
        public String Status { get; set; }
        public Object StatusType { get; set; }
        public Nullable<DateTime> LastAction { get; set; }
        public String NumberAndSubject { get; set; }
        public String FormLink { get; set; }
    }

    public partial class FormActionTypeExtended
    {

    }

    public partial class FormAttachmentExtended
    {
        public Byte[] FileContent { get; set; }
        public String NewFileName { get; set; }
        public Nullable<Boolean> MarkForDeletion { get; set; }
        public String FileStatus { get; set; }
    }

    public partial class FormAttachmentDataExtended
    {
        public String FileName { get; set; }
        public Int32 FileSize { get; set; }
    }

    public partial class FormLogExtended
    {

    }

    public partial class FormStatusExtended
    {
        public Nullable<Boolean> Preselected { get; set; }
    }

    public partial class FormTypeExtended
    {
        
    }

    public partial class GroupExtended
    {
        public Nullable<Boolean> IsAdmin { get; set; }
    }

    public partial class GroupUserExtended
    {
        public String UserName { get; set; }
        public String DisplayName { get; set; }
        public String EmailAddress { get; set; }
        public String AuthenticationType { get; set; }
        public String SID { get; set; }
        public Nullable<Boolean> IsADGroup { get; set; }
        public Nullable<Boolean> MarkForDeletion { get; set; }
    }

    public partial class OrganizationExtended
    {
        public String ReviewTabKey { get; set; }
        public String ReviewTabValue { get; set; }
        public Object StatusType { get; set; }
    }

    public partial class OrganizationFormActorExtended
    {
        public String OrganizationGroupName { get; set; }
    }

    public partial class OrganizationFormReviewerExtended
    {
        public String OrganizationGroupName { get; set; }
        public String ReviewRoleName { get; set; }
        public Nullable<Boolean> IsFirst { get; set; }
        public Nullable<Boolean> IsLast { get; set; }
        public Nullable<Boolean> CanMove { get; set; }
        public IList<ReviewRole> ReviewRoles { get; set; }
        public Nullable<Boolean> MarkForDeletion { get; set; }
    }

    public partial class OrganizationFormRoutingExtended
    {
        public String RoutingNameAndReviewers { get; set; }
        public String RoutingReviewers { get; set; }
        public IList<OrganizationFormReviewer> Reviewers { get; set; }
        public Nullable<Boolean> MarkForDeletion { get; set; }
    }

    public partial class OrganizationFormTypeExtended
    {

    }

    public partial class OrganizationForwardingExtended
    {
        public String OrganizationName { get; set; }
        public String RoutingName { get; set; }
        public Nullable<Boolean> MarkForDeletion { get; set; }
    }

    public partial class OrganizationGroupExtended
    {
        public Nullable<Int32> MetricValue { get; set; }
        public String GroupName { get; set; }
        public Nullable<Boolean> MarkForDeletion { get; set; }
    }

    public partial class ReviewActionExtended
    {
        public Nullable<Boolean> CanSelect { get; set; }
    }

    public partial class ReviewRoleExtended
    {

    }

    public partial class ReviewSignatureExtended
    {
        public String SubjectName { get; set; }
        public Nullable<DateTime> SignatureDate { get; set; }
        public Boolean IsValid { get; set; }
    }

    public partial class ReviewStatusExtended
    {
        public Nullable<Int32> PreviousReviewActionID { get; set; }
        public Object StatusType { get; set; }
        public String ActingUser { get; set; }
        public Nullable<Boolean> CanAdmin { get; set; }
        public Nullable<Boolean> CanAutopen { get; set; }
        public Nullable<Boolean> CanForward { get; set; }
        public Nullable<Boolean> CanModifyOrder { get; set; }
        public Nullable<Boolean> CanReview { get; set; }
        public Nullable<Boolean> CanViewComments { get; set; }
        public String ReviewGroupName { get; set; }
        public String ReviewRoleName { get; set; }
        public String ReviewActionName { get; set; }
        public Nullable<Boolean> IsFirst { get; set; }
        public Nullable<Boolean> IsLast { get; set; }
        public Nullable<Boolean> CanMove { get; set; }
        public IList<ReviewRole> ReviewRoles { get; set; }
        public IList<FormAttachment> Attachments { get; set; }
        public Nullable<Boolean> MarkForDeletion { get; set; }
    }

    public partial class UserExtended
    {
        public IList<String> UserSIDs { get; set; }
        public String AuthenticationMethod { get; set; }
        public String DisplayNameAndAuthMethod { get; set; }
    }
}
