<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProgramDev.aspx.cs" Inherits="USAACE.ATI.Web.Pages.ProgramDev" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Program Development</h1>
    <table class="formTable">
        <colgroup>
            <col style="width: 50%;" />
            <col style="width: 50%;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label required left">Select a Program:</td>
                <td rowspan="2" class="right"><asp:LinkButton runat="server" ID="btnCreateProgramCopy" Text="Create a Copy" OnClick="btnCreateProgramCopy_Click" Visible="false" CssClass="button copy" /></td>
            </tr>
            <tr>
                <td><ATI:ComboBoxControl runat="server" ID="cmbProgramName" Width="300" AutoPostBack="true" OnTextChanged="cmbProgramName_TextChanged" /></td>
            </tr>
        </tbody>
    </table>
    <h2 class="formTitle">Program Details</h2>
    <div>
        <asp:ValidationSummary runat="server" ID="vsProgram" ValidationGroup="Program" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
    </div>
    <table class="formTable">
        <colgroup>
            <col style="width: 50%;" />
            <col style="width: 25%;" />
            <col style="width: 25%;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label required left">
                    Program Name
                    <asp:RequiredFieldValidator runat="server" ID="rfvProgramName" CssClass="validationError" ControlToValidate="txtProgramName" ErrorMessage="Program Name cannot be empty." Text="*" ValidationGroup="Program" EnableClientScript="false" />
                </td>
                <td class="label left">Fiscal Year</td>
                <td rowspan="2"><asp:CheckBox runat="server" ID="chkLocked" Text="Locked" /></td>
            </tr>
            <tr>
                <td><ATI:TextControl runat="server" ID="txtProgramName" MaxLength="50" Width="300" /></td>
                <td><ATI:NumericControl runat="server" ID="ncFiscalYear" MaxLength="4" Width="50" Mask="9999" /></td>
            </tr>
            <tr>
                <td colspan="3" class="label left">Program Description</td>
            </tr>
            <tr>
                <td colspan="3"><ATI:HTMLEditor runat="server" ID="hteProgramDescription" Height="150" /></td>
            </tr>
        </tbody>
    </table>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnUpdateProgram" Text="Save Program" OnClick="btnUpdateProgram_Click" CssClass="button save" />
        <asp:LinkButton runat="server" ID="btnDeleteProgram" Text="Delete Program" Visible="false" OnClick="btnDeleteProgram_Click" CssClass="button delete" />
    </div>
    <ATI:ModalPopup runat="server" ID="mpCopyProgram" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
        <div class="modalPopupTitle">Copy Program</div>
        <div>
            <asp:ValidationSummary runat="server" ID="vsCopyProgram" ValidationGroup="CopyProgram" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
        </div>
        <div class="label required left">
            Name of New Program
            <asp:RequiredFieldValidator runat="server" ID="rfvCopyProgramName" CssClass="validationError" ControlToValidate="txtCopyProgramName" ErrorMessage="Program Name cannot be empty." Text="*" ValidationGroup="CopyProgram" EnableClientScript="false" />
        </div>
        <div><asp:TextBox runat="server" ID="txtCopyProgramName" Width="300" MaxLength="50" /></div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnCopyProgramConfirm" Text="Copy Program" OnClick="btnCopyProgramConfirm_Click" CssClass="button copy" />
            <asp:LinkButton runat="server" ID="btnCopyProgramCancel" Text="Cancel" OnClick="btnCopyProgramCancel_Click" CssClass="button delete" />
        </div>
    </ATI:ModalPopup>
    <ATI:ModalPopup runat="server" ID="mpDeleteProgram" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
        <div class="modalPopupTitle">Confirm Program Deletion</div>
        <div class="label left">
            Are you sure you want to delete this program?  All associated courses and classes will be deleted as well.
        </div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnDeleteProgramConfirm" Text="Delete Program" OnClick="btnDeleteProgramConfirm_Click" CssClass="button ok" />
            <asp:LinkButton runat="server" ID="btnDeleteProgramCancel" Text="Cancel" OnClick="btnDeleteProgramCancel_Click" CssClass="button delete" />
        </div>
    </ATI:ModalPopup>
</asp:Content>
