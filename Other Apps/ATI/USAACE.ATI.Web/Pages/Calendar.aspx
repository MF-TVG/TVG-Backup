<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="USAACE.ATI.Web.Pages.Calendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Calendar Reference</h1>
    <table class="formTable">
        <colgroup>
            <col style="width: 33.33%;" />
            <col style="width: 33.33%;" />
            <col style="width: 33.33%;" />
        </colgroup>
        <tbody>
            <tr>
                <td>
                    <asp:CheckBox runat="server" ID="chkMobilization" Text="Show Mobilization Calendar" AutoPostBack="true" OnCheckedChanged="chkMobilization_Checked" />
                </td>
                <td colspan="2" class="label right required">
                    <asp:ImageButton runat="server" ID="imbFiscalYearDown" OnClick="imbFiscalYearDown_Click" ImageUrl="~/images/leftarrowblack.png" />
                    <asp:Literal runat="server" ID="ltrFiscalYear" />
                    <asp:ImageButton runat="server" ID="imbFiscalYearUp" OnClick="imbFiscalYearUp_Click" ImageUrl="~/images/rightarrowblack.png" />
                </td>
            </tr>
            <tr>
                <td class="center">
                    <asp:Calendar runat="server" ID="calOctober" OnDayRender="calCalendar_DayRender" SelectionMode="None" ShowNextPrevMonth="false" CssClass="calendarTable" OtherMonthDayStyle-CssClass="calendarNonMonthDay" DayNameFormat="FirstTwoLetters" TitleFormat="MonthYear" TitleStyle-CssClass="calendarTableHeader" />
                </td>
                <td class="center">
                    <asp:Calendar runat="server" ID="calNovember" OnDayRender="calCalendar_DayRender" SelectionMode="None" ShowNextPrevMonth="false" CssClass="calendarTable" OtherMonthDayStyle-CssClass="calendarNonMonthDay" DayNameFormat="FirstTwoLetters" TitleFormat="MonthYear" TitleStyle-CssClass="calendarTableHeader" />
                </td>
                <td class="center">
                    <asp:Calendar runat="server" ID="calDecember" OnDayRender="calCalendar_DayRender" SelectionMode="None" ShowNextPrevMonth="false" CssClass="calendarTable" OtherMonthDayStyle-CssClass="calendarNonMonthDay" DayNameFormat="FirstTwoLetters" TitleFormat="MonthYear" TitleStyle-CssClass="calendarTableHeader" />
                </td>
            </tr>
            <tr>
                <td class="center">
                    <asp:Calendar runat="server" ID="calJanuary" OnDayRender="calCalendar_DayRender" SelectionMode="None" ShowNextPrevMonth="false" CssClass="calendarTable" OtherMonthDayStyle-CssClass="calendarNonMonthDay" DayNameFormat="FirstTwoLetters" TitleFormat="MonthYear" TitleStyle-CssClass="calendarTableHeader" />
                </td>
                <td class="center">
                    <asp:Calendar runat="server" ID="calFebruary" OnDayRender="calCalendar_DayRender" SelectionMode="None" ShowNextPrevMonth="false" CssClass="calendarTable" OtherMonthDayStyle-CssClass="calendarNonMonthDay" DayNameFormat="FirstTwoLetters" TitleFormat="MonthYear" TitleStyle-CssClass="calendarTableHeader" />
                </td>
                <td class="center">
                    <asp:Calendar runat="server" ID="calMarch" OnDayRender="calCalendar_DayRender" SelectionMode="None" ShowNextPrevMonth="false" CssClass="calendarTable" OtherMonthDayStyle-CssClass="calendarNonMonthDay" DayNameFormat="FirstTwoLetters" TitleFormat="MonthYear" TitleStyle-CssClass="calendarTableHeader" />
                </td>
            </tr>
            <tr>
                <td class="center">
                    <asp:Calendar runat="server" ID="calApril" OnDayRender="calCalendar_DayRender" SelectionMode="None" ShowNextPrevMonth="false" CssClass="calendarTable" OtherMonthDayStyle-CssClass="calendarNonMonthDay" DayNameFormat="FirstTwoLetters" TitleFormat="MonthYear" TitleStyle-CssClass="calendarTableHeader" />
                </td>
                <td class="center">
                    <asp:Calendar runat="server" ID="calMay" OnDayRender="calCalendar_DayRender" SelectionMode="None" ShowNextPrevMonth="false" CssClass="calendarTable" OtherMonthDayStyle-CssClass="calendarNonMonthDay" DayNameFormat="FirstTwoLetters" TitleFormat="MonthYear" TitleStyle-CssClass="calendarTableHeader" />
                </td>
                <td class="center">
                    <asp:Calendar runat="server" ID="calJune" OnDayRender="calCalendar_DayRender" SelectionMode="None" ShowNextPrevMonth="false" CssClass="calendarTable" OtherMonthDayStyle-CssClass="calendarNonMonthDay" DayNameFormat="FirstTwoLetters" TitleFormat="MonthYear" TitleStyle-CssClass="calendarTableHeader" />
                </td>
            </tr>
            <tr>
                <td class="center">
                    <asp:Calendar runat="server" ID="calJuly" OnDayRender="calCalendar_DayRender" SelectionMode="None" ShowNextPrevMonth="false" CssClass="calendarTable" OtherMonthDayStyle-CssClass="calendarNonMonthDay" DayNameFormat="FirstTwoLetters" TitleFormat="MonthYear" TitleStyle-CssClass="calendarTableHeader" />
                </td>
                <td class="center">
                    <asp:Calendar runat="server" ID="calAugust" OnDayRender="calCalendar_DayRender" SelectionMode="None" ShowNextPrevMonth="false" CssClass="calendarTable" OtherMonthDayStyle-CssClass="calendarNonMonthDay" DayNameFormat="FirstTwoLetters" TitleFormat="MonthYear" TitleStyle-CssClass="calendarTableHeader" />
                </td>
                <td class="center">
                    <asp:Calendar runat="server" ID="calSeptember" OnDayRender="calCalendar_DayRender" SelectionMode="None" ShowNextPrevMonth="false" CssClass="calendarTable" OtherMonthDayStyle-CssClass="calendarNonMonthDay" DayNameFormat="FirstTwoLetters" TitleFormat="MonthYear" TitleStyle-CssClass="calendarTableHeader" />
                </td>
            </tr>
        </tbody>
    </table>
    <h2 class="formTitle">Calendar Legend</h2>
    <asp:DataList runat="server" ID="dlNoFlyTypes" RepeatDirection="Horizontal" RepeatColumns="5" OnItemDataBound="dlNoFlyTypes_ItemDataBound" style="table-layout: fixed; width: 100%;">
        <ItemTemplate>
            <asp:Panel runat="server" ID="pnlNoFlyTypeColor" style="display: inline-block; height: 15px; width: 15px; border: 1px solid #000000; vertical-align: middle;" />
            <asp:Literal runat="server" ID="ltrNoFlyTypeName" />
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
