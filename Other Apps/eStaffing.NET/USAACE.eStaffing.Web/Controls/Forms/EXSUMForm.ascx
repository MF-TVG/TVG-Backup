<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EXSUMForm.ascx.cs" Inherits="USAACE.eStaffing.Web.Controls.Forms.EXSUMForm" %>
<table class="formTable">
    <colgroup>
        <col style="width: 12em;" />
        <col style="width: auto;" />
    </colgroup>
    <tbody>
        <tr>
            <td class="label left required">EXSUM Period End Date:<asp:RequiredFieldValidator runat="server" ID="rfvEXSUMDate" ControlToValidate="dcEXSUMDate" Text="*" ErrorMessage="EXSUM Date is a required field and must be a valid date." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td><eStaffing:DateControl runat="server" ID="dcEXSUMDate" Width="100" /></td>
        </tr>
        <tr>
            <td class="label left">Title (optional):</td>
            <td><eStaffing:TextControl runat="server" ID="txtEXSUMTitle" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label left">Issues Requiring CG Attention:</td>
            <td><eStaffing:HTMLEditor runat="server" ID="hteIssues" Height="150" /></td>
        </tr>
        <tr>
            <td class="label left">Current Status:</td>
            <td><eStaffing:HTMLEditor runat="server" ID="hteCurrentStatus" Height="150" /></td>
        </tr>
        <tr>
            <td class="label left">Future Status:</td>
            <td><eStaffing:HTMLEditor runat="server" ID="hteFutureStatus" Height="150" /></td>
        </tr>
        <tr>
            <td class="label left">Point of Contact:</td>
            <td><eStaffing:HTMLEditor runat="server" ID="htePointOfContact" Height="150" /></td>
        </tr>
        <tr>
            <td class="label left">Additional Information:</td>
            <td><eStaffing:HTMLEditor runat="server" ID="hteAdditionalInformation" Height="150" /></td>
        </tr>
    </tbody>
</table>