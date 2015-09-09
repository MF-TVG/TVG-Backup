<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TaskingForm.ascx.cs" Inherits="USAACE.eStaffing.Web.Controls.Forms.TaskingForm" %>
<table class="formTable">
    <colgroup>
        <col style="width: 13em;" />
        <col style="width: auto;" />
        <col style="width: 13em;" />
        <col style="width: auto;" />
    </colgroup>
    <tbody>
        <tr>
            <td class="label left required">Task Number:<asp:RequiredFieldValidator runat="server" ID="rfvTaskNumber" EnableClientScript="false" ControlToValidate="txtTaskNumber" ErrorMessage="Task Number is required." Text="*" ValidationGroup="FormSubmit" /></td>
            <td><eStaffing:TextControl runat="server" ID="txtTaskNumber" Width="100%" /></td>
            <td class="label left">ECC Number:</td>
            <td><eStaffing:TextControl runat="server" ID="txtECCNumber" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label left required">Type:</td>
            <td><eStaffing:DropDownControl runat="server" ID="ddlTaskType" Width="100%" /></td>
            <td class="label left required">Originator:</td>
            <td><eStaffing:DropDownControl runat="server" ID="ddlSource" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label left required">POC(s) - Originator:<asp:RequiredFieldValidator runat="server" ID="rfvSourcePOC" EnableClientScript="false" ControlToValidate="hteSourcePOC" ErrorMessage="Source POCs is required." Text="*" ValidationGroup="FormSubmit" /></td>
            <td colspan="3"><eStaffing:HTMLEditor runat="server" ID="hteSourcePOC" Height="150" /></td>
        </tr>
        <tr>
            <td class="label left required">Tasker Name:<asp:RequiredFieldValidator runat="server" ID="rfvSubject" EnableClientScript="false" ControlToValidate="hteSubject" ErrorMessage="Tasker Name is required." Text="*" ValidationGroup="FormSubmit" /></td>
            <td colspan="3"><eStaffing:HTMLEditor runat="server" ID="hteSubject" Height="150" /></td>
        </tr>
        <tr>
            <td class="label left">Action Officer(s):</td>
            <td colspan="3"><eStaffing:TextControl runat="server" ID="txtActionOfficer" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label left">Phone:</td>
            <td><eStaffing:TextControl runat="server" ID="txtPhone" Width="100%" /></td>
            <td class="label left">Office Symbol:</td>
            <td><eStaffing:TextControl runat="server" ID="txtOfficeSymbol" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label left">Suspense:</td>
            <td><eStaffing:DateControl runat="server" ID="dcSuspense" Width="100" /></td>
            <td class="label left">Received:</td>
            <td><eStaffing:DateControl runat="server" ID="dcDateTasked" Width="100" /></td>
        </tr>
    </tbody>
</table>
<h2 class="formTitle">Task Deliverables and Details</h2>
<table class="formTable">
    <colgroup>
        <col style="width: 13em;" />
        <col style="width: auto;" />
        <col style="width: 13em;" />
        <col style="width: auto;" />
    </colgroup>
    <tbody>
        <tr>
            <td class="label left">Document Type:</td>
            <td><eStaffing:DropDownControl runat="server" ID="ddlDocumentType" Width="100%" /></td>
            <td class="label left">Action Required:</td>
            <td><eStaffing:DropDownControl runat="server" ID="ddlActionRequired" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label left">Security Level:</td>
            <td><eStaffing:DropDownControl runat="server" ID="ddlSecurityLevel" Width="100%" /></td>
            <td class="label left">Set Tasker Location:</td>
            <td><eStaffing:DropDownControl runat="server" ID="ddlTaskerLocation" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label left">Who, What, Why, Where, When:</td>
            <td colspan="3"><eStaffing:HTMLEditor runat="server" ID="hte5W" Height="150" /></td>
        </tr>
        <tr>
            <td class="label left">Coordinating Instructions:</td>
            <td colspan="3"><eStaffing:HTMLEditor runat="server" ID="hteCoordinateInstructions" Height="150" /></td>
        </tr>
        <tr>
            <td class="label left">POC(s):</td>
            <td colspan="3"><eStaffing:HTMLEditor runat="server" ID="htePOC" Height="150" /></td>
        </tr>
        <tr>
            <td class="label left">Admin Comments and Details:</td>
            <td colspan="3"><eStaffing:HTMLEditor runat="server" ID="hteComments" Height="150" /></td>
        </tr>
    </tbody>
</table>