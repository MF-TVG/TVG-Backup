<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="USAACE.eStaffing.Web.Pages.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Search</h1>
    <table class="formTable">
        <colgroup>
            <col style="width: 20em;" />
            <col style="width: 20em;" />
            <col style="width: auto;" />
        </colgroup>
        <tr>
            <td class="label required">Search forms for keyword:</td>
            <td>
                <eStaffing:TextControl runat="server" ID="txtSearchTerm" Width="100%" />
            </td>
            <td class="right">
                <asp:LinkButton runat="server" ID="lkbSearch" Text="Search" CssClass="button search" OnClick="lkbSearch_Click" />
            </td>
        </tr>
    </table>
    <table class="formGridLegend">
        <colgroup>
            <col style="width: auto;" />
            <col style="width: 12em;" />
            <col style="width: 10em;" />
            <col style="width: 10em;" />
            <col style="width: 10em;" />
            <col style="width: 10em;" />
            <col style="width: 10em;" />
        </colgroup>
        <thead>
            <tr>
                <th class="left">Search Results</th>
                <th><asp:Image runat="server" ID="imgNone" ImageUrl="~/images/statusblack.png" /> Not Submitted</th>
                <th><asp:Image runat="server" ID="imgReject" ImageUrl="~/images/statusreject.png" /> Rejected</th>
                <th><asp:Image runat="server" ID="imgBlue" ImageUrl="~/images/statusblue.png" /> In Review</th>
                <th><asp:Image runat="server" ID="imgAmber" ImageUrl="~/images/statusamber.png" /> Near Due</th>
                <th><asp:Image runat="server" ID="imgRed" ImageUrl="~/images/statusred.png" /> Past Due</th>
                <th><asp:Image runat="server" ID="imgGreen" ImageUrl="~/images/statusgreen.png" /> Completed</th>
            </tr>
        </thead>
    </table>
    <table class="formGrid">
        <colgroup>
            <col style="width: 5em;" />
            <col style="width: 16em;" />
            <col style="width: auto;" />
            <col style="width: 10em;" />
            <col style="width: 10em;" />
            <col style="width: 16em;" />
            <col class="hidePrint scrollCol" />
        </colgroup>
        <thead>
            <tr>
                <th></th>
                <th class="left">Type</th>
                <th class="left">Subject</th>
                <th class="center">Submit Date</th>
                <th class="center">Suspense</th>
                <th class="center">Status</th>
                <th></th>
            </tr>
        </thead>
    </table>
    <div class="scrollGrid largeGrid">
        <table class="formGrid noborder">
            <colgroup>
                <col style="width: 5em;" />
                <col style="width: 16em;" />
                <col style="width: auto;" />
                <col style="width: 10em;" />
                <col style="width: 10em;" />
                <col style="width: 16em;" />
            </colgroup>
            <tbody>
    <eStaffing:RepeaterListControl runat="server" ID="dlFormList" OnItemDataBound="dlFormList_ItemDataBound">
        <ItemTemplate>
            <tr>
                <td class="left top">
                    <asp:Image runat="server" ID="imgHighPriority" ImageUrl="~/images/exclaim.gif" /> <asp:Image runat="server" ID="imgStatus" />
                </td>
                <td class="left">
                    <asp:Literal runat="server" ID="ltrFormType" />
                </td>
                <td class="left">
                    <asp:HyperLink runat="server" ID="lnkFormTitle" Target="_blank" />
                </td>
                <td>
                    <asp:Literal runat="server" ID="ltrSubmitDate" />
                </td>
                <td>
                    <asp:Literal runat="server" ID="ltrSuspenseDate" />
                </td>
                <td>
                    <asp:Literal runat="server" ID="ltrStatus" />
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <tr>
                <td class="left" colspan="6">There are no forms that match the search keyword.</td>
            </tr>
        </EmptyDataTemplate>
    </eStaffing:RepeaterListControl>
            </tbody>
        </table>
    </div>
</asp:Content>
