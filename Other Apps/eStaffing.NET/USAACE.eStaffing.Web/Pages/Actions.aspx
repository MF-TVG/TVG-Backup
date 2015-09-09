<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Actions.aspx.cs" Inherits="USAACE.eStaffing.Web.Pages.Actions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        html
        {
            width: 100%;
        }

        body
        {
            margin: 0em;
            padding: 0em;
            width: 100%;
            font-family: Verdana;
            font-size: 0.75em;
        }

        a
        {
            text-decoration: none;
        }
    </style>
    <title>My Actions</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink runat="server" ID="lnkDashboard" Text="Go to Dashboard" NavigateUrl="~/Pages/Dashboard.aspx" Target="_blank" /><br />
        <eStaffing:RepeaterListControl runat="server" ID="dlForms" OnItemDataBound="dlForms_ItemDataBound">
            <ItemTemplate>
                <br />
                <asp:Image runat="server" ID="imgHighPriority" ImageUrl="~/images/exclaim.gif" />
                <asp:Image runat="server" ID="imgStatus" />
                <asp:HyperLink runat="server" ID="lnkFormTitle" Target="_blank" />
            </ItemTemplate>
            <EmptyDataTemplate>
                There are no actions for your review.
            </EmptyDataTemplate>
        </eStaffing:RepeaterListControl>
        <asp:BulletedList runat="server" ID="bllForms" DisplayMode="HyperLink" Target="_blank" />
    </div>
    </form>
</body>
</html>
