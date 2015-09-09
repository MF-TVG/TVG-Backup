<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EvaluationReport.ascx.cs" Inherits="USAACE.eStaffing.Web.Controls.Forms.EvaluationReport" %>
<table class="formTable">
    <colgroup>
        <col style="width: 18em;" />
        <col style="width: auto;" />
        <col style="width: 10em;" />
        <col style="width: 13em;" />
    </colgroup>
    <tbody>
        <tr>
            <td class="label required">Action Officer:<asp:RequiredFieldValidator runat="server" ID="rfvActionOfficer" ControlToValidate="txtActionOfficer" Text="*" ErrorMessage="Action Officer is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td colspan="3"><eStaffing:TextControl runat="server" ID="txtActionOfficer" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label required">Ratee:<asp:RequiredFieldValidator runat="server" ID="rfvRatee" ControlToValidate="txtRatee" Text="*" ErrorMessage="Ratee is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td><eStaffing:TextControl runat="server" ID="txtRatee" Width="100%" /></td>
            <td class="label required">Thru Date:<asp:CustomValidator runat="server" ID="cvThruDate" Text="*" ErrorMessage="Thru Date is a required field and must be a valid date." ValidationGroup="FormSubmit" EnableClientScript="false" OnServerValidate="cvThruDate_ServerValidate" CssClass="validationError" /></td>
            <td><eStaffing:DateControl runat="server" ID="dcThruDate" Width="100" /></td>
        </tr>
        <tr>
            <td class="label required">Rater:<asp:RequiredFieldValidator runat="server" ID="rfvRater" ControlToValidate="txtRater" Text="*" ErrorMessage="Rater is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td colspan="3"><eStaffing:TextControl runat="server" ID="txtRater" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label">Intermediate Rater:</td>
            <td colspan="3"><eStaffing:TextControl runat="server" ID="txtIntermediateRater" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label required">Senior Rater:<asp:RequiredFieldValidator runat="server" ID="rfvSeniorRater" ControlToValidate="txtSeniorRater" Text="*" ErrorMessage="Senior Rater is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td colspan="3"><eStaffing:TextControl runat="server" ID="txtSeniorRater" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label required">Reviewer:<asp:RequiredFieldValidator runat="server" ID="rfvReviewer" ControlToValidate="txtReviewer" Text="*" ErrorMessage="Reviewer is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td colspan="3"><eStaffing:TextControl runat="server" ID="txtReviewer" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label required">Reason for Submission:<asp:RequiredFieldValidator runat="server" ID="rfvSubmissionReason" ControlToValidate="txtSubmissionReason" Text="*" ErrorMessage="Reason for Submission is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td colspan="3"><eStaffing:TextControl runat="server" ID="txtSubmissionReason" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label required">Checklist:<asp:CustomValidator runat="server" ID="cvChecklist" Text="*" ErrorMessage="At least one Checklist item must be checked." ValidationGroup="FormSubmit" EnableClientScript="false" OnServerValidate="cvChecklist_ServerValidate" CssClass="validationError" /></td>
            <td colspan="3">
                <asp:CheckBox runat="server" ID="chkSupportForm" Text="Support Form/Counseling Form" /><br />
                <asp:CheckBox runat="server" ID="chkCivilianForm" Text="ORB/ERB/Civilian Counseling Form" /><br />
                <asp:CheckBox runat="server" ID="chkPTCard" Text="Most Recent PT Card/Body Fat Worksheet/Profile (if applicable)" /><br />
                <asp:CheckBox runat="server" ID="chkRecommendedComments" Text="Recommended Comments" />
            </td>
        </tr>
        <tr>
            <td colspan="4" class="label left">Remarks: (Indicate where applicable: Date of next board for promotion or schooling; Follow-on assignment; Tentative change of command or PCS date, etc):</td>
        </tr>
        <tr>
            <td colspan="4"><eStaffing:HTMLEditor runat="server" ID="hteRemarks" Height="150" /></td>
        </tr>
        <tr>
            <td class="label">Estimated Date of Loss:<asp:CustomValidator runat="server" ID="cvLossDate" Text="*" ErrorMessage="Estimated Date of Loss is a required field and must be a valid date." ValidationGroup="FormSubmit" EnableClientScript="false" OnServerValidate="cvLossDate_ServerValidate" Enabled="false" CssClass="validationError" /></td>
            <td colspan="3"><eStaffing:DateControl runat="server" ID="dcLossDate" Width="100" /></td>
        </tr>
    </tbody>
</table>