<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClassDev.aspx.cs" Inherits="USAACE.ATI.Web.Pages.ClassDev" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Build Classes</h1>
    <div>
        <asp:ValidationSummary runat="server" ID="vsClass" ValidationGroup="Class" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
        <asp:CustomValidator runat="server" ID="cvCreateClasses" ErrorMessage="All fields are required to create classes." ValidationGroup="Class" CssClass="validationError" Display="None" OnServerValidate="cvCreateClasses_ServerValidate" EnableClientScript="false" />
    </div>
    <table class="formTable">
        <colgroup>
            <col style="width: 50%;" />
            <col style="width: 25%;" />
            <col style="width: 25%;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label required left">Select Program</td>
                <td class="label required left">Maximum Classes</td>
                <td class="label required left">Beginning Class Number</td>
            </tr>
            <tr>
                <td><ATI:ComboBoxControl runat="server" ID="cmbProgram" Width="250" AutoPostBack="true" OnTextChanged="cmbProgram_TextChanged" /></td>
                <td><ATI:NumericControl runat="server" ID="ncMaximumClasses" Width="100" MaxLength="3" Mask="999" /></td>
                <td><ATI:NumericControl runat="server" ID="ncBeginningClass" Width="100" MaxLength="3" Mask="999" /></td>
            </tr>
            <tr>
                <td class="label required left">Select Course</td>
                <td class="label required left">Add Students To</td>
                <td class="label required left">Report Date Interval</td>
            </tr>
            <tr>
                <td><ATI:ComboBoxControl runat="server" ID="cmbCourse" Width="250" AutoPostBack="true" OnTextChanged="cmbCourse_TextChanged" /></td>
                <td>
                    <ATI:ComboBoxControl runat="server" ID="cmbAddStudents" Width="100">
                        <asp:ListItem Text="All Classes" Value="All" Selected="True" />
                        <asp:ListItem Text="Odd Classes" Value="Odd" />
                        <asp:ListItem Text="Even Classes" Value="Even" />
                    </ATI:ComboBoxControl>
                </td>
                <td><ATI:NumericControl runat="server" ID="ncReportDateInterval" Width="50" MaxLength="4" Mask="999" /> Day(s)</td>
            </tr>
            <tr>
                <td class="label required left">Select POI</td>
                <td class="label required left">
                    First Class Report Date
                    <asp:CustomValidator runat="server" ID="cvReportDate" ErrorMessage="First report date is not within the program flight year." Text="*" ValidationGroup="Class" CssClass="validationError" OnServerValidate="cvReportDate_ServerValidate" EnableClientScript="false" />
                </td>
                <td class="label required left">Total Students</td>
            </tr>
            <tr>
                <td><ATI:ComboBoxControl runat="server" ID="cmbPOI" Width="250" /></td>
                <td><ATI:DateControl runat="server" ID="dcFirstClassReportDate" Width="100" /></td>
                <td><ATI:NumericControl runat="server" ID="ncClassLoad" Width="100" MaxLength="4" Mask="9999" /></td>
            </tr>
        </tbody>
    </table>
    <asp:Panel runat="server" ID="pnlCarryOver" Visible="false">
        <h3 class="formTitle">Carry Over (if needed)</h3>
        <table class="formTable">
            <colgroup>
                <col style="width: 50%;" />
                <col style="width: 50%;" />
            </colgroup>
            <tbody>
                <tr>
                    <td class="label required left">Carry Over Program</td>
                    <td class="label left">Carry Over Course</td>
                </tr>
                <tr>
                    <td><ATI:ComboBoxControl runat="server" ID="cmbCarryOverProgram" Width="250" AutoPostBack="true" OnTextChanged="cmbCarryOverProgram_TextChanged" /></td>
                    <td><asp:Literal runat="server" ID="ltrCarryOverCourse" /></td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnCreateClasses" Text="Create Classes" OnClick="btnCreateClasses_Click" CssClass="button submit" />
    </div>
</asp:Content>
