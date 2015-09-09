<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewForm.aspx.cs" Inherits="USAACE.eStaffing.Web.Pages.NewForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Create New Form</h1>
    <asp:ValidationSummary runat="server" ID="vsFormSubmit" ValidationGroup="FormSubmit" CssClass="validationError" />
    <table class="formTable">
        <colgroup>
            <col style="width: 24em;" />
            <col style="width: auto;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label required">Select a Form Type:</td>
                <td><eStaffing:DropDownControl runat="server" ID="ddlFormType" AutoPostBack="true" OnSelectedIndexChanged="ddlFormType_SelectedIndexChanged" /></td>
            </tr>
            <tr>
                <td class="label required">Select Your Submission Group:</td>
                <td><eStaffing:DropDownControl runat="server" ID="ddlSubmitGroup" AutoPostBack="true" OnSelectedIndexChanged="ddlSubmitGroup_SelectedIndexChanged" /></td>
            </tr>
            <tr>
                <td class="label">Submitting To:</td>
                <td><asp:Literal runat="server" ID="ltrOrganization" /></td>
            </tr>
            <tr>
                <td class="label required">Select Your Routing Chain:</td>
                <td>
                    <eStaffing:RadioButtonListControl runat="server" ID="rblRoutingChain" RepeatLayout="Flow" />
                </td>
            </tr>
        </tbody>
    </table>
    <div class="right">
        <asp:LinkButton runat="server" ID="btnSave" Text="Create" CssClass="button save" OnClick="btnSave_Click" ValidationGroup="Form" />
    </div>
</asp:Content>