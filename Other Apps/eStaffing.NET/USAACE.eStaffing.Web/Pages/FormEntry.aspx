<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormEntry.aspx.cs" Inherits="USAACE.eStaffing.Web.Pages.FormEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle"><asp:Literal runat="server" ID="ltrFormTitle" /></h1>
    <div class="right">
        <div style="float: left;">
            <span class="label required">Submitter:</span> <asp:Literal runat="server" ID="ltrSubmitGroup" />
        </div>
        <span class="label required">Form Number:</span> <asp:Literal runat="server" ID="ltrFormNumber" />
    </div>
    <div>
        <asp:ValidationSummary runat="server" ID="vsFormSubmit" ValidationGroup="FormSubmit" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
    </div>
    <div class="right marginTopSmall">
        <div class="label left" style="float: left;">
            <asp:CheckBox runat="server" ID="chkHighPriority" Text="This is a high priority packet" />
        </div>
        <asp:LinkButton runat="server" ID="btnSubmit" Text="Submit" CssClass="button submit" OnClick="btnSubmit_Click" />
        <asp:LinkButton runat="server" ID="btnSave" Text="Save" CssClass="button save" OnClick="btnSave_Click" />
    </div>
    <div>
        <asp:PlaceHolder runat="server" ID="plhForm" />
    </div>
    <h1 class="formTitle">Supporting Documentation</h1>
    <div>
        <eStaffing:FileControl runat="server" ID="ucFileControl" />
    </div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnSaveDefault" Text="Set as Default Template" CssClass="button import" OnClick="btnSaveDefault_Click" />
        <asp:LinkButton runat="server" ID="btnImport" Text="Import Form" CssClass="button import" OnClick="btnImport_Click" />
        <asp:LinkButton runat="server" ID="btnUndelete" Text="Mark Active" CssClass="button refresh" OnClick="btnUndelete_Click" />
        <asp:LinkButton runat="server" ID="btnDelete" Text="Cancel" CssClass="button delete" OnClick="btnDelete_Click" />
        <asp:LinkButton runat="server" ID="btnSubmitBottom" Text="Submit" CssClass="button submit" OnClick="btnSubmit_Click" />
        <asp:LinkButton runat="server" ID="btnSaveBottom" Text="Save" CssClass="button save" OnClick="btnSave_Click" />
    </div>
    <div>
        <eStaffing:ReviewerControl runat="server" ID="ucReviewControl" />
    </div>
    <eStaffing:ModalPopup runat="server" ID="mpDeleteFormConfirm" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
        <div class="modalPopupTitle">Confirm</div>
        <div>This is a permanent action and all reviewer data will be reset. Continue with form cancellation?</div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnDeleteFormConfirm" Text="OK" CssClass="button ok" OnClick="btnDeleteFormConfirm_Click" />
            <asp:LinkButton runat="server" ID="btnDeleteFormCancel" Text="Cancel" CssClass="button delete" OnClick="btnDeleteFormCancel_Click" />
        </div>
    </eStaffing:ModalPopup>
    <eStaffing:ModalPopup runat="server" ID="mpImportForm" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
        <div class="modalPopupTitle">Import Form</div>
        <table class="formTable">
            <colgroup>
                <col style="width: 16em;" />
                <col style="width: auto;" />
            </colgroup>
            <tbody>
                <tr>
                    <td colspan="2" class="label required left">
                        NOTE: This is a permanent action and all current form data will be overwritten.
                    </td>
                </tr>
                <tr>
                    <td class="label required left">Search By Form Number or Subject:</td>
                    <td><asp:TextBox runat="server" ID="txtImportSearch" Width="100%" AutoPostBack="true" OnTextChanged="txtImportSearch_TextChanged" /></td>
                </tr>
                <tr>
                    <td class="label required left">Select Form to Import:</td>
                    <td><asp:DropDownList runat="server" ID="ddlImportForms" Width="100%" /></td>
                </tr>
                <tr>
                    <td colspan="2"><asp:CheckBox runat="server" ID="chkImportAttachments" Text="Include Attachments" /></td>
                </tr>
            </tbody>
        </table>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnSaveImportForm" Text="Import" CssClass="button import" OnClick="btnSaveImportForm_Click" />
            <asp:LinkButton runat="server" ID="btnCancelImportForm" Text="Cancel" CssClass="button delete" OnClick="btnCancelImportForm_Click" />
        </div>
    </eStaffing:ModalPopup>
</asp:Content>