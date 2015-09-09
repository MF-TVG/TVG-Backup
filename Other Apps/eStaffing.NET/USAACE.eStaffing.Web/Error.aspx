<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="USAACE.eStaffing.Web.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Error</h1>
    <asp:MultiView runat="server" ID="mvError">
        <asp:View runat="server" ID="vwDefault">
            There was an error accessing the page.
        </asp:View>
        <asp:View runat="server" ID="vw401">
            You are not authorized to access this resource.
        </asp:View>
        <asp:View runat="server" ID="vw403">
            You are forbidden from accessing this resource.
        </asp:View>
        <asp:View runat="server" ID="vw404">
            The page you are navigating to cannot be found.
        </asp:View>
        <asp:View runat="server" ID="vw500">
            An unknown server error has occurred.
        </asp:View>
    </asp:MultiView>
</asp:Content>
