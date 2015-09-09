<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="USAACE.eStaffing.Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Login</h1>
    <table class="formTable">
        <colgroup>
            <col style="width: 18em;" />
            <col style="width: auto;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label required">Select a Login Method:</td>
                <td>
                    <eStaffing:DropDownControl runat="server" ID="ddlLoginMethod" AutoPostBack="true" OnSelectedIndexChanged="ddlLoginMethod_SelectedIndexChanged">
                        <asp:ListItem Text="-- Choose a Method --" Value="" />
                        <asp:ListItem Text="Windows Authentication" Value="Windows" />
                        <asp:ListItem Text="Single Sign-On" Value="SSO" />
                    </eStaffing:DropDownControl>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
