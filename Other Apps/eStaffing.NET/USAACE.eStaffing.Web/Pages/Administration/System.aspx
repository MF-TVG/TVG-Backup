<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="System.aspx.cs" Inherits="USAACE.eStaffing.Web.Pages.Administration.System" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">System Settings</h1>
    <h2 class="formTitle">Basic System Settings</h2>
    <asp:LinkButton runat="server" ID="lkbResetCache" Text="Reset Cache" CssClass="button refresh" OnClick="lkbResetCache_Click" />
    <h2 class="formTitle">System Form Settings</h2>
    <table class="formTable">
        <colgroup>
            <col style="width: 16em;" />
            <col style="width: auto;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label required">Select a Form Type:</td>
                <td><eStaffing:DropDownControl runat="server" ID="ddlFormType" AutoPostBack="true" OnSelectedIndexChanged="ddlFormType_SelectedIndexChanged" /></td>
            </tr>
        </tbody>
    </table>
    <h2 class="formTitle">Basic Form Settings</h2>
    <table class="formTable">
        <colgroup>
            <col style="width: 14em;" />
            <col style="width: auto;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label">Form Type Name:</td>
                <td><eStaffing:TextControl runat="server" ID="txtFormTypeName" MaxLength="50" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label">Suspense Date Field:</td>
                <td><eStaffing:DropDownControl runat="server" ID="ddlSuspenseDateField" /></td>
            </tr>
            <tr>
                <td class="label">Subject Field:</td>
                <td><eStaffing:DropDownControl runat="server" ID="ddlSubjectField" /></td>
            </tr>
            <tr>
                <td class="label">Form Number Field:</td>
                <td><eStaffing:DropDownControl runat="server" ID="ddlFormNumberField" /></td>
            </tr>
            <tr>
                <td class="label">Form Action Type:</td>
                <td><eStaffing:DropDownControl runat="server" ID="ddlFormActionType" /></td>
            </tr>
        </tbody>
    </table>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnSaveFormType" CssClass="button save" Text="Save Form Type" OnClick="btnSaveFormType_Click" />
    </div>
</asp:Content>
