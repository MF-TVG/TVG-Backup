<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Preferences.aspx.cs" Inherits="USAACE.eStaffing.Web.Pages.Preferences" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">My Preferences</h1>
    <table class="formTable">
        <colgroup>
            <col style="width: 12em;" />
            <col style="width: auto;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label">User ID:</td>
                <td><asp:Label runat="server" ID="lblUserID" /></td>
            </tr>
            <tr>
                <td class="label">User Name:</td>
                <td><asp:Label runat="server" ID="lblUserName" /></td>
            </tr>
            <tr>
                <td class="label">Auth Provider:</td>
                <td><asp:Label runat="server" ID="lblAuthProvider" /></td>
            </tr>
            <tr>
                <td class="label">Display Name:</td>
                <td><asp:Label runat="server" ID="lblDisplayName" /></td>
            </tr>
            <tr>
                <td class="label">Email Address:</td>
                <td><asp:Label runat="server" ID="lblEmailAddress" /></td>
            </tr>
            <tr>
                <td class="label">Assigned Roles:</td>
                <td><asp:Label runat="server" ID="lblRoles" /></td>
            </tr>
            <tr>
                <td colspan="2"><asp:CheckBox runat="server" ID="chkNotifyReject" Text="Notify on Rejections" /></td>
            </tr>
            <tr>
                <td colspan="2"><asp:CheckBox runat="server" ID="chkNotifyReview" Text="Notify on Review" /></td>
            </tr>
            <tr>
                <td colspan="2"><asp:CheckBox runat="server" ID="chkNotifyComplete" Text="Notify on Completion" /></td>
            </tr>
        </tbody>
    </table>
    <div class="right">
        <asp:LinkButton runat="server" ID="btnSave" Text="Save Preferences" CssClass="button save" OnClick="btnSave_Click" />
    </div>
</asp:Content>
