<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="USAACE.ATI.Web.Pages.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Reports</h1>
    <div>
        <asp:ValidationSummary runat="server" ID="vsReports" ValidationGroup="Reports" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
    </div>
    <table class="formTable">
        <colgroup>
            <col style="width: 25%;" />
            <col style="width: 25%;" />
            <col style="width: 25%;" />
            <col style="width: 25%;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label left required">
                    Select a Program:
                    <asp:RequiredFieldValidator runat="server" ID="rfvProgramName" ControlToValidate="cmbProgramName" EnableClientScript="false" ValidationGroup="Reports" ErrorMessage="You must select at least a Program to run a report." Text="*" CssClass="validationError" />
                </td>
                <td><ATI:ComboBoxControl runat="server" ID="cmbProgramName" Width="250" AutoPostBack="true" OnTextChanged="cmbProgramName_TextChanged" /></td>
                <td class="label left">Select the Carry Over Program:</td>
                <td><ATI:ComboBoxControl runat="server" ID="cmbCarryProgramName" Width="250" AutoPostBack="true" OnTextChanged="cmbCarryProgramName_TextChanged" /></td>
            </tr>
            <tr>
                <td class="label left">Select a Course:</td>
                <td><ATI:ComboBoxControl runat="server" ID="cmbCourseName" Width="250" AutoPostBack="true" OnTextChanged="cmbCourseName_TextChanged" /></td>
                <td class="label left">Select a Carry Over Course:</td>
                <td><ATI:ComboBoxControl runat="server" ID="cmbCarryCourseName" Width="250" AutoPostBack="true" OnTextChanged="cmbCarryCourseName_TextChanged" /></td>
            </tr>
            <tr>
                <td class="label left" colspan="2">Group By:</td>
                <td class="label left">Report Type:</td>
                <td class="label left">Hours:</td>
            </tr>
            <tr>
                <td colspan="2">
                    <ATI:RadioButtonListControl runat="server" ID="rblGroupBy" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblGroupBy_SelectedIndexChanged" CssClass="radioButtonList" RepeatLayout="Flow">
                        <asp:ListItem Text="System" Value="System" Selected="True" />
                        <asp:ListItem Text="Course" Value="Course" />
                        <asp:ListItem Text="Non-POI Hours" Value="None" />
                        <asp:ListItem Text="FY By Course" Value="FYByCourse" />
                    </ATI:RadioButtonListControl>
                </td>
                <td>
                    <ATI:RadioButtonListControl runat="server" ID="rblFrequency" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblFrequency_SelectedIndexChanged" CssClass="radioButtonList" RepeatLayout="Flow">
                        <asp:ListItem Text="Monthly" Selected="True" Value="Monthly" />
                        <asp:ListItem Text="Daily" Value="Daily" />
                        <asp:ListItem Text="Yearly" Value="Yearly" Enabled="false" />
                    </ATI:RadioButtonListControl>
                </td>
                <td>
                    <ATI:RadioButtonListControl runat="server" ID="rblHours" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblHours_SelectedIndexChanged" CssClass="radioButtonList" RepeatLayout="Flow">
                        <asp:ListItem Text="Forecast" Value="Forecast" Selected="True" />
                        <asp:ListItem Text="Actual" Value="Actual" />
                    </ATI:RadioButtonListControl>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <span class="label left">System(s):</span>
                    (<asp:LinkButton runat="server" ID="lkbAllSystem" Text="All" OnClick="lkbAllSystem_Click" />)
                </td>
                <td>
                    <span class="label left">Daily Requirements:</span>
                    (<asp:LinkButton runat="server" ID="lkbAllRequirements" Text="All" OnClick="lkbAllRequirements_Click" />)<br />
                </td>
                <td class="label left">Direct / Reimbursable:</td>
            </tr>
            <tr>
                <td colspan="2" rowspan="5">
                    <ATI:CheckBoxListControl runat="server" ID="cklSystem" RepeatLayout="UnorderedList" CssClass="reportFilter" />
                </td>
                <td rowspan="5">
                    <ATI:CheckBoxListControl runat="server" ID="cklRequirements" RepeatLayout="UnorderedList" CssClass="reportFilter">
                        <asp:ListItem Text="Day Flight" />
                        <asp:ListItem Text="Night Flight" />
                        <asp:ListItem Text="Daily Flight Hours" />
                        <asp:ListItem Text="Total in Training" />
                        <asp:ListItem Text="Simulator Students" />
                        <asp:ListItem Text="Simulator Hours" />
                        <asp:ListItem Text="Aircraft for Day" />
                        <asp:ListItem Text="Aircraft for Night" />
                        <asp:ListItem Text="Launches for Day" />
                        <asp:ListItem Text="Launches for Night" />
                        <asp:ListItem Text="Total Launches" />
                        <asp:ListItem Text="Total IPs Required" />
                    </ATI:CheckBoxListControl>
                </td>
                <td>
                    <ATI:RadioButtonListControl runat="server" ID="rblReimbursable" CssClass="radioButtonList" RepeatLayout="Flow">
                        <asp:ListItem Text="All" Selected="True" Value="" />
                        <asp:ListItem Text="Direct Only" Value="False" />
                        <asp:ListItem Text="Reimbursable Only" Value="True" />
                    </ATI:RadioButtonListControl>
                </td>
            </tr>
            <tr>
                <td class="label left">Course Level(s):</td>
            </tr>
            <tr>
                <td><ATI:CheckBoxListControl runat="server" ID="cklCourseLevel" RepeatLayout="UnorderedList" CssClass="reportFilter" /></td>
            </tr>
            <tr>
                <td class="label left">Hours Type Inclusions:<br /></td>
            </tr>
            <tr>
                <td>
                    <ATI:CheckBoxListControl runat="server" ID="cklHoursType" RepeatLayout="UnorderedList" CssClass="reportFilter">
                        <asp:ListItem Text="BASOPS" Value="BASOPS" />
                        <asp:ListItem Text="Add-Ins" Value="Add-Ins" />
                        <asp:ListItem Text="Support" Value="Support" />
                    </ATI:CheckBoxListControl>
                </td>
            </tr>
        </tbody>
    </table>
    <div class="right">
        <asp:LinkButton runat="server" ID="btnRunReport" Text="Run Report" OnClick="btnRunReport_Click" CssClass="button refresh" />
    </div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="lkbDownloadExcel" OnClick="lkbDownloadExcel_Click" Text="Download to Excel" CssClass="button save" />
    </div>
    <div style="width: 100%; overflow: auto; max-height: 30em;">
        <asp:GridView runat="server" ID="gvReport" AutoGenerateColumns="true" CellPadding="0" CellSpacing="0" GridLines="None"
            EmptyDataText="No Records Exist for the Selected Options" ShowHeaderWhenEmpty="false" CssClass="reportGrid" />
    </div>
</asp:Content>
