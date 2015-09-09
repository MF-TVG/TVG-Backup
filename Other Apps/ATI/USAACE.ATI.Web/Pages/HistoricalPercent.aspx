<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistoricalPercent.aspx.cs" Inherits="USAACE.ATI.Web.Pages.HistoricalPercent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Historical Precents</h1>
    <table class="formTable">
        <colgroup>
            <col style="width: 40%;" />
            <col style="width: 60%;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label required left">Select a Program:</td>
                <td class="label required left">Edit Mode:</td>
            </tr>
            <tr>
                <td><ATI:ComboBoxControl runat="server" ID="cmbProgram" Width="250" AutoPostBack="true" OnTextChanged="cmbProgram_TextChanged" /></td>
                <td>
                    <ATI:RadioButtonListControl runat="server" ID="rblEditMode" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblEditMode_SelectedIndexChanged" CssClass="radioButtonList" RepeatLayout="Flow">
                        <asp:ListItem Text="By Course" Value="Course" Selected="True" />
                        <asp:ListItem Text="Mass Edit By Course Details" Value="MassEdit" />
                    </ATI:RadioButtonListControl>
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Panel runat="server" ID="pnlByCourse">
        <table class="formTable">
            <colgroup>
                <col style="width: 50%;" />
                <col style="width: 50%;" />
            </colgroup>
            <tbody>
                <tr>
                    <td class="label required left">Select a Course:</td>
                </tr>
                <tr>
                    <td><ATI:ComboBoxControl runat="server" ID="cmbCourse" Width="250" AutoPostBack="true" OnTextChanged="cmbCourse_TextChanged" /></td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlMassEdit">
        <table class="formTable">
            <colgroup>
                <col style="width: 40%;" />
                <col style="width: 40%;" />
                <col style="width: 20%;" />
            </colgroup>
            <tbody>
                <tr>
                    <td class="label required left">Select System(s):</td>
                    <td class="label left required">Select Course Type(s):</td>
                    <td class="label left required">Select Course Level(s):</td>
                </tr>
                <tr>
                    <td><ATI:CheckBoxListControl runat="server" ID="cklSystem" RepeatLayout="UnorderedList" CssClass="reportFilter" /></td>
                    <td><ATI:CheckBoxListControl runat="server" ID="cklCourseType" RepeatLayout="UnorderedList" CssClass="reportFilter" /></td>
                    <td><ATI:CheckBoxListControl runat="server" ID="cklCourseLevel" RepeatLayout="UnorderedList" CssClass="reportFilter" /></td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlPercents" Visible="false">
        <h2 class="formTitle">Historical Precent Values</h2>
        <table class="formTable">
            <colgroup>
                <col style="width: 25%;" />
                <col style="width: 25%;" />
                <col style="width: 25%;" />
                <col style="width: 25%;" />
            </colgroup>
            <tbody>
                <tr>
                    <td class="label left">October</td>
                    <td class="label left">February</td>
                    <td class="label left">June</td>
                    <td class="label left">Support</td>
                </tr>
                <tr>
                    <td><ATI:NumericControl runat="server" ID="ncOctober" Width="50" MaxLength="5" Mask="9999" ClearMaskOnLostFocus="true" /></td>
                    <td><ATI:NumericControl runat="server" ID="ncFebruary" Width="50" MaxLength="5" Mask="9999" ClearMaskOnLostFocus="true" /></td>
                    <td><ATI:NumericControl runat="server" ID="ncJune" Width="50" MaxLength="5" Mask="9999" ClearMaskOnLostFocus="true" /></td>
                    <td><ATI:NumericControl runat="server" ID="ncSupport" Width="50" MaxLength="5" Mask="9999" ClearMaskOnLostFocus="true" /></td>
                </tr>
                <tr>
                    <td class="label left">November</td>
                    <td class="label left">March</td>
                    <td class="label left">July</td>
                    <td class="label left">Setback</td>
                </tr>
                <tr>
                    <td><ATI:NumericControl runat="server" ID="ncNovember" Width="50" MaxLength="5" Mask="9999" ClearMaskOnLostFocus="true" /></td>
                    <td><ATI:NumericControl runat="server" ID="ncMarch" Width="50" MaxLength="5" Mask="9999" ClearMaskOnLostFocus="true" /></td>
                    <td><ATI:NumericControl runat="server" ID="ncJuly" Width="50" MaxLength="5" Mask="9999" ClearMaskOnLostFocus="true" /></td>
                    <td><ATI:NumericControl runat="server" ID="ncSetback" Width="50" MaxLength="5" Mask="9999" ClearMaskOnLostFocus="true" /></td>
                </tr>
                <tr>
                    <td class="label left">December</td>
                    <td class="label left">April</td>
                    <td class="label left">August</td>
                    <td class="label left">Test</td>
                </tr>
                <tr>
                    <td><ATI:NumericControl runat="server" ID="ncDecember" Width="50" MaxLength="5" Mask="9999" ClearMaskOnLostFocus="true" /></td>
                    <td><ATI:NumericControl runat="server" ID="ncApril" Width="50" MaxLength="5" Mask="9999" ClearMaskOnLostFocus="true" /></td>
                    <td><ATI:NumericControl runat="server" ID="ncAugust" Width="50" MaxLength="5" Mask="9999" ClearMaskOnLostFocus="true" /></td>
                    <td><ATI:NumericControl runat="server" ID="ncTest" Width="50" MaxLength="5" Mask="9999" ClearMaskOnLostFocus="true" /></td>
                </tr>
                <tr>
                    <td class="label left">January</td>
                    <td class="label left">May</td>
                    <td class="label left">September</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><ATI:NumericControl runat="server" ID="ncJanuary" Width="50" MaxLength="5" Mask="9999" ClearMaskOnLostFocus="true" /></td>
                    <td><ATI:NumericControl runat="server" ID="ncMay" Width="50" MaxLength="5" Mask="9999" ClearMaskOnLostFocus="true" /></td>
                    <td><ATI:NumericControl runat="server" ID="ncSeptember" Width="50" MaxLength="5" Mask="9999" ClearMaskOnLostFocus="true" /></td>
                    <td>&nbsp;</td>
                </tr>
            </tbody>
        </table>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnUpdatePercent" Text="Update Historical Percents" OnClick="btnUpdatePercent_Click" CssClass="button save" />
        </div>
    </asp:Panel>
    <h2 class="formTitle">Historical Percent Report by Program</h2>
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
