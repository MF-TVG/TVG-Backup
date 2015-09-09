<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormList.aspx.cs" Inherits="USAACE.eStaffing.Web.Pages.FormList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle"><asp:Literal runat="server" ID="ltrFormTitle" /></h1>
    <table class="formTable">
        <colgroup>
            <col style="width: 9em;" />
            <col style="width: 34em;" />
            <col style="width: 10em;" />
            <col style="width: 19em;" />
            <col style="width: 13em;" />
            <col style="width: 5em;" />
            <col style="width: auto;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label required">Sort By:</td>
                <td>
                    <eStaffing:RadioButtonListControl runat="server" ID="rblSortField" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radioButtonList">
                        <asp:ListItem Text="Suspense Date" Value="Suspense" Selected="True" />
                        <asp:ListItem Text="Subject" Value="Subject" />
                        <asp:ListItem Text="Submit Date" Value="Submit Date" />
                        <asp:ListItem Text="Status" Value="Status" />
                    </eStaffing:RadioButtonListControl>
                </td>
                <td class="label required">Sort Order:</td>
                <td>
                    <eStaffing:RadioButtonListControl runat="server" ID="rblSortDirection" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radioButtonList">
                        <asp:ListItem Text="Ascending" Value="Ascending" Selected="True" />
                        <asp:ListItem Text="Descending" Value="Descending" />
                    </eStaffing:RadioButtonListControl>
                </td>
                <td class="label required">Number to Show:</td>
                <td>
                    <eStaffing:DropDownControl runat="server" ID="ddlShowNumber">
                        <asp:ListItem Text="30" Value="30" Selected="True" />
                        <asp:ListItem Text="50" Value="50" />
                        <asp:ListItem Text="100" Value="100" />
                        <asp:ListItem Text="200" Value="200" />
                    </eStaffing:DropDownControl>
                </td>
                <td class="right">
                    <asp:LinkButton runat="server" ID="lkbRefresh" Text="Refresh" OnClick="lkbSort_Click" CssClass="button refresh" />
                </td>
            </tr>
        </tbody>
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
                <th class="left">Packets</th>
                <th>
                    <asp:Image runat="server" ID="imgSubmitNone" ImageUrl="~/images/statusblack.png" /> Not Submitted
                </th>
                <th>
                    <asp:Image runat="server" ID="imgSubmitReject" ImageUrl="~/images/statusreject.png" /> Rejected
                </th>
                <th>
                    <asp:Image runat="server" ID="imgSubmitBlue" ImageUrl="~/images/statusblue.png" /> In Review
                </th>
                <th>
                    <asp:Image runat="server" ID="imgSubmitAmber" ImageUrl="~/images/statusamber.png" /> Near Due
                </th>
                <th>
                    <asp:Image runat="server" ID="imgSubmitRed" ImageUrl="~/images/statusred.png" /> Past Due
                </th>
                <th>
                    <asp:Image runat="server" ID="imgSubmitGreen" ImageUrl="~/images/statusgreen.png" /> Completed
                </th>
            </tr>
        </thead>
    </table>
    <asp:Panel runat="server" ID="pnlFormList" />
    <div class="center marginTop">
        <asp:ImageButton runat="server" ID="lkbPrevGroup" ImageUrl="~/images/leftarrowblack.png" OnClick="lkbPrevGroup_Click" />
        <span style="padding: 5px;"><asp:Label runat="server" ID="lblStartIndex" Text="1" /> to <asp:Label runat="server" ID="lblEndIndex" Text="100" /></span>
        <asp:ImageButton runat="server" ID="lkbNextGroup" ImageUrl="~/images/rightarrowblack.png" OnClick="lkbNextGroup_Click" />
    </div>
</asp:Content>