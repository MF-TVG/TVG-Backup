<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorLogs.aspx.cs" Inherits="USAACE.eStaffing.Web.Pages.Administration.ErrorLogs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Error Logs</h1>
    <table class="formGrid">
        <colgroup>
            <col style="width: 16em;" />
            <col style="width: 20em;" />
            <col style="width: 10em;" />
            <col style="width: auto;" />
            <col style="width: 5em;" />
        </colgroup>
        <thead>
            <tr>
                <th class="left">Date</th>
                <th class="left">User</th>
                <th>Type</th>
                <th class="left">Message</th>
                <th>Open</th>
            </tr>
        </thead>
        <tbody>
    <eStaffing:RepeaterListControl runat="server" ID="dlErrors" OnItemDataBound="dlErrors_ItemDataBound">
        <ItemTemplate>
            <tr>
                <td class="left"><asp:Literal runat="server" ID="ltrErrorDate" /></td>
                <td class="left"><asp:Literal runat="server" ID="ltrErrorUser" /></td>
                <td><asp:Literal runat="server" ID="ltrErrorType" /></td>
                <td class="left"><asp:Literal runat="server" ID="ltrErrorMessage" /></td>
                <td><asp:ImageButton runat="server" ID="imbOpenError" ImageUrl="~/images/search.gif" OnCommand="imbOpenError_Command" /></td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <tr>
                <td class="left" colspan="5">There are no logged errors.</td>
            </tr>
        </EmptyDataTemplate>
    </eStaffing:RepeaterListControl>
        </tbody>
    </table>
    <eStaffing:ModalPopup runat="server" ID="mpErrorDetails" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
        <div class="modalPopupTitle">Error Details</div>
        <table class="formTable">
            <colgroup>
                <col style="width: 8em;" />
                <col style="width: auto;" />
            </colgroup>
            <tbody>
                <tr>
                    <td class="label">Date:</td>
                    <td><asp:Literal runat="server" ID="ltrErrorItemDate" /></td>
                </tr>
                <tr>
                    <td class="label">User:</td>
                    <td><asp:Literal runat="server" ID="ltrErrorItemUser" /></td>
                </tr>
                <tr>
                    <td class="label">Type:</td>
                    <td><asp:Literal runat="server" ID="ltrErrorItemType" /></td>
                </tr>
                <tr>
                    <td class="label">URL:</td>
                    <td><asp:Literal runat="server" ID="ltrErrorItemLocation" /></td>
                </tr>
                <tr>
                    <td class="label">Message:</td>
                    <td><asp:Literal runat="server" ID="ltrErrorItemMessage" /></td>
                </tr>
                <tr>
                    <td class="label left" colspan="2">StackTrace:</td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Literal runat="server" ID="ltrErrorItemStackTrace" /></td>
                </tr>
            </tbody>
        </table>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnCloseError" Text="Close" CssClass="button ok" OnClick="btnCloseError_Click" />
        </div>
    </eStaffing:ModalPopup>
</asp:Content>
