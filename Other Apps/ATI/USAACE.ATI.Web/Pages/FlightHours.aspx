<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlightHours.aspx.cs" Inherits="USAACE.ATI.Web.Pages.FlightHours" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Flight Hours</h1>
    <table class="formTable">
        <colgroup>
            <col style="width: 15%;" />
            <col style="width: 35%;" />
            <col style="width: 15%;" />
            <col style="width: 35%;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label required">Select a Program:</td>
                <td>
                    <ATI:ComboBoxControl runat="server" ID="cmbProgramName" Width="300" AutoPostBack="true" OnTextChanged="cmbProgramName_TextChanged" />
                </td>
                <td class="label">Default Cutoff Date:</td>
                <td><ATI:DateControl runat="server" ID="dcDefaultCutoffDate" TextBoxCssClass="center" Width="85" /></td>
            </tr>
            <tr>
                <td colspan="2" class="label left">Hours Type:</td>
                <td colspan="2"><asp:CheckBox runat="server" ID="chkForecastHours" Text="Forecast Hours" AutoPostBack="true" OnCheckedChanged="chkForecastHours_Changed" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <ATI:RadioButtonListControl runat="server" ID="rblHoursType" AutoPostBack="true" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radioButtonList" OnSelectedIndexChanged="rblHoursType_SelectedIndexChanged" />
                </td>
                <td colspan="2"><asp:CheckBox runat="server" ID="chkReimburseableHours" Text="Reimburseable Hours" AutoPostBack="true" OnCheckedChanged="cmbParameter_Changed" /></td>
            </tr>
            <tr>
                <td runat="server" id="tdCourseTitle" colspan="2" class="label left">Select a Course:</td>
                <td runat="server" id="tdSupportTitle" colspan="2" class="label left">Select a Support Type:</td>
                <td class="label left">Select a System:</td>
                <td class="label left">Select a Course Level:</td>
            </tr>
            <tr>
                <td runat="server" id="tdCourse" colspan="2">
                    <ATI:ComboBoxControl runat="server" ID="cmbCourseName" Width="300" AutoPostBack="true" OnTextChanged="cmbCourseName_TextChanged" />
                </td>
                <td runat="server" id="tdSupport" colspan="2">
                    <ATI:ComboBoxControl runat="server" ID="cmbSupportType" Width="300" AutoPostBack="true" OnTextChanged="cmbParameter_Changed" />
                </td>
                <td>
                    <ATI:ComboBoxControl runat="server" ID="cmbSystem" Width="160" AutoPostBack="true" OnTextChanged="cmbParameter_Changed" />
                </td>
                <td>
                    <ATI:ComboBoxControl runat="server" ID="cmbCourseLevel" Width="160" AutoPostBack="true" OnTextChanged="cmbParameter_Changed" />
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Panel runat="server" ID="pnlHours" Visible="false">
        <h2 class="formTitle">Current Flight Hours</h2>
        <div>
            <asp:ValidationSummary runat="server" ID="vsHours" ValidationGroup="Hours" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
            <asp:CustomValidator runat="server" ID="cvHours" CssClass="validationError" Display="None" ErrorMessage="One or more hours entries is missing a cutoff date or number of hours." ValidationGroup="Hours" OnServerValidate="cvHours_ServerValidate" EnableClientScript="false" />
        </div>
        <table class="formGrid">
            <colgroup>
                <col style="width: 10%;" />
                <col style="width: 40%;" />
                <col style="width: 30%;" />
                <col style="width: 20%;" />
            </colgroup>
            <thead>
                <tr>
                    <th>Delete</th>
                    <th class="left">Cutoff Date</th>
                    <th>Hours</th>
                    <th>Month</th>
                </tr>
            </thead>
            <tbody>
                <ATI:RepeaterListControl runat="server" ID="dlHours" OnItemDataBound="dlHours_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td><asp:CheckBox runat="server" ID="chkHoursDelete" /></td>
                            <td class="left"><ATI:DateControl runat="server" ID="dcCutoffDate" TextBoxCssClass="noborder center" Width="85" /></td>
                            <td><ATI:NumericControl runat="server" ID="ncHours" Width="70" MaxLength="6" Mask="9999.9" MaskType="Number" /></td>
                            <td><asp:Literal runat="server" ID="ltrMonth" /></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <tr>
                            <td colspan="4" class="left">No Hours Exist for the Selected Parameters</td>
                        </tr>
                    </EmptyDataTemplate>
                </ATI:RepeaterListControl>
            </tbody>
            <tfoot>
                <tr>
                    <td>&nbsp;</td>
                    <td class="left">Through Date: <asp:Literal runat="server" ID="ltrHoursEndDate" /></td>
                    <td class="left">Total Hours: <asp:Literal runat="server" ID="ltrHoursTotal" /></td>
                    <td>&nbsp;</td>
                </tr>
            </tfoot>
        </table>
        <div class="right">
            <asp:LinkButton runat="server" ID="btnAddHours" Text="Add Hours" OnClick="btnAddHours_Click" CssClass="button add" />
        </div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnUpdateHours" Text="Update Hours" OnClick="btnUpdateHours_Click" CssClass="button save" />
            <asp:LinkButton runat="server" ID="btnDeleteHours" Text="Delete All Hours" OnClick="btnDeleteHours_Click" CssClass="button delete" />
        </div>
    </asp:Panel>
    <ATI:ModalPopup runat="server" ID="mpConfirmDeleteHours" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
        <div class="modalPopupTitle">Confirm Flight Hours Deletion</div>
        <div class="label left">Are you sure you want to delete the selected hours?</div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnDeleteHoursConfirm" Text="Delete Hours" OnClick="btnDeleteHoursConfirm_Click" CssClass="button ok" />
            <asp:LinkButton runat="server" ID="btnDeleteHoursCancel" Text="Cancel" OnClick="btnDeleteHoursCancel_Click" CssClass="button delete" />
        </div>
    </ATI:ModalPopup>
    <ATI:ModalPopup runat="server" ID="mpConfirmDeleteAllHours" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
        <div class="modalPopupTitle">Confirm All Flight Hours Deletion</div>
        <div class="label left">Are you sure you want to delete all hours?</div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnDeleteAllHoursConfirm" Text="Delete Hours" OnClick="btnDeleteAllHoursConfirm_Click" CssClass="button ok" />
            <asp:LinkButton runat="server" ID="btnDeleteAllHoursCancel" Text="Cancel" OnClick="btnDeleteAllHoursCancel_Click" CssClass="button delete" />
        </div>
    </ATI:ModalPopup>
</asp:Content>
