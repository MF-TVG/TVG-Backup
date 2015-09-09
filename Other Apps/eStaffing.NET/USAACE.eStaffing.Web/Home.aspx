<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="USAACE.eStaffing.Web.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="js/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="js/eStaffingSlideShow.js"></script>
    <link rel="stylesheet" type="text/css" href="style/eStaffingSlideShow.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">eStaffing Home</h1>
    <div class="center">
        <div class="slideShow">
            <asp:Image runat="server" ID="imgFlow1" ImageUrl="~/images/flow1.png" />
            <asp:Image runat="server" ID="imgFlow2" ImageUrl="~/images/flow2.png" />
            <asp:Image runat="server" ID="imgFlow3" ImageUrl="~/images/flow3.png" />
            <asp:Image runat="server" ID="imgFlow4" ImageUrl="~/images/flow4.png" />
            <asp:Image runat="server" ID="imgFlow5" ImageUrl="~/images/flow5.png" />
            <asp:HyperLink runat="server" ID="lnkFlow6" NavigateUrl="~/Pages/Instructions.aspx">
                <asp:Image runat="server" ID="imgFlow6" ImageUrl="~/images/flow6.png" />
            </asp:HyperLink>
        </div>
    </div>
    <h2 class="formTitle">What is eStaffing?</h2>
    <div>
        eStaffing is a data system built for the creation and review of electronic forms used for staffing actions.
    </div>
    <h2 class="formTitle">Why Use eStaffing?</h2>
    <div>
        The premise behind eStaffing is availability and reliability whereby information is stored in a centralized database instead of traditional paper packets.
        This enables constant availability of information whereby the only requirement is an internet connection which means soldiers and civilians on the road 
        no longer have to wait to return home to work on packets that require their review and/or signature.
    </div>
</asp:Content>