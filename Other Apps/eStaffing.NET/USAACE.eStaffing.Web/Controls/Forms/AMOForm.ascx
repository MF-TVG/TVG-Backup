<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AMOForm.ascx.cs" Inherits="USAACE.eStaffing.Web.Controls.Forms.AMOForm" %>
<table class="formTable">
    <colgroup>
        <col style="width: 16.67%;" />
        <col style="width: 16.67%;" />
        <col style="width: 16.67%;" />
        <col style="width: 16.67%;" />
        <col style="width: 33.33%;" />
    </colgroup>
    <tbody>
        <tr>
            <td class="label left">Requiring Activity POC:</td>
            <td colspan="4"><eStaffing:TextControl runat="server" ID="txtRequiringActivityPOC" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label left required">Suspense:<asp:RequiredFieldValidator runat="server" ID="rfvSuspense" ControlToValidate="txtSuspense" Text="*" ErrorMessage="Suspense is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td colspan="2"><eStaffing:DateControl runat="server" ID="dcSuspenseDate" Width="100" /></td>
            <td class="label left">Contract End Date:</td>
            <td><eStaffing:DateControl runat="server" ID="dcContractEndDate" Width="100" /></td>
        </tr>
        <tr>
            <td class="label left required">Title:<asp:RequiredFieldValidator runat="server" ID="rfvTitle" ControlToValidate="txtTitle" Text="*" ErrorMessage="Title is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" /></td>
            <td colspan="4"><asp:TextBox runat="server" ID="txtTitle" MaxLength="255" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label left">Description:</td>
            <td colspan="4"><eStaffing:HTMLEditor runat="server" ID="hteDescription" Height="150" /></td>
        </tr>
        <tr>
            <td class="label left required">Amount:<asp:RequiredFieldValidator runat="server" ID="rfvAmount" ControlToValidate="txtAmount" Text="*" ErrorMessage="Amount is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" /></td>
            <td colspan="4"><eStaffing:TextControl runat="server" ID="txtAmount" Width="200" /></td>
        </tr>
        <tr>
            <td class="label left">Document Checklist:</td>
            <td colspan="4"><asp:CheckBoxList runat="server" ID="cklDocumentChecklist" RepeatLayout="Flow" CssClass="checkBoxList" /></td>
        </tr>
        <tr>
            <td class="label left">Other Documents:</td>
            <td colspan="4"><eStaffing:TextControl runat="server" ID="txtDocumentOther" Width="100%" /></td>
        </tr>
    </tbody>
</table>
