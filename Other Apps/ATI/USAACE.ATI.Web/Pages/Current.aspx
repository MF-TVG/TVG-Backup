<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Current.aspx.cs" Inherits="USAACE.ATI.Web.Pages.Current" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Current Classes</h1>
    <table class="formTable">
        <colgroup>
            <col style="width: 50%;" />
            <col style="width: 50%;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label required left">Select a Program:</td>
                <td class="label required left">Select a Course:</td>
            </tr>
            <tr>
                <td><ATI:ComboBoxControl runat="server" ID="cmbProgram" Width="250" AutoPostBack="true" OnTextChanged="cmbProgram_TextChanged" /></td>
                <td><ATI:ComboBoxControl runat="server" ID="cmbCourse" Width="250" AutoPostBack="true" OnTextChanged="cmbCourse_TextChanged" /></td>
            </tr>
        </tbody>
    </table>
    <asp:Panel runat="server" ID="pnlClassInfo" Visible="false">
        <h2 class="formTitle">Current In-Session Class Information</h2>
        <div>
            <asp:ValidationSummary runat="server" ID="vsClasses" ValidationGroup="Classes" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
            <asp:CustomValidator runat="server" ID="cvClasses" CssClass="validationError" Display="None" ErrorMessage="One or more classes is missing a class number, date, or student count." ValidationGroup="Classes" OnServerValidate="cvClasses_ServerValidate" EnableClientScript="false" />
        </div>
        <table class="formGrid">
            <colgroup>
                <col style="width: 2em;" />
                <col style="width: 6em;" />
                <col style="width: 6em;" />
                <col style="width: auto;" />
                <col style="width: 12em;" />
                <col style="width: 8em;" />
                <col style="width: 8em;" />
                <col style="width: 6em;" />
                <col style="width: 6em;" />
                <col style="width: 6em;" />
            </colgroup>
            <thead>
                <tr>
                    <th><asp:CheckBox runat="server" ID="chkAllClasses" AutoPostBack="true" OnCheckedChanged="chkAllClasses_CheckedChanged" /></th>
                    <th>ADP</th>
                    <th>Class #</th>
                    <th>POI</th>
                    <th>Report Date</th>
                    <th>Start Date</th>
                    <th>End Date</th>
                    <th>Students</th>
                    <th>Reimbur.</th>
                    <th>Interval</th>
                </tr>
            </thead>
            <tbody>
                <ATI:RepeaterListControl runat="server" ID="dlClasses" OnItemDataBound="dlClasses_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td><asp:CheckBox runat="server" ID="chkClassSelect" /></td>
                            <td><asp:Literal runat="server" ID="ltrClassADPCode" /></td>
                            <td><ATI:NumericControl runat="server" ID="ncClassNumber" MaxLength="3" Width="30" Mask="???" AcceptNegative="None" MaskType="None" ClearMaskOnLostFocus="false" PromptCharacter="0" TextBoxCssClass="center" /></td>
                            <td style="white-space: nowrap;">
                                <asp:ImageButton runat="server" ID="imgPOI" CssClass="statusImage" OnCommand="imgPOI_Command" />
                                <asp:Literal runat="server" ID="ltrPOIName" />
                            </td>
                            <td>
                                <asp:Image runat="server" ID="imgReportDate" CssClass="statusImage" />
                                <ATI:DateControl runat="server" ID="dcReportDate" TextBoxCssClass="center" Width="80" />
                            </td>
                            <td><asp:Literal runat="server" ID="ltrStartDate" /></td>
                            <td><asp:Literal runat="server" ID="ltrEndDate" /></td>
                            <td><ATI:NumericControl runat="server" ID="ncClassStudents" Width="30" MaxLength="3" Mask="999" ClearMaskOnLostFocus="true" TextBoxCssClass="center" /></td>
                            <td><ATI:NumericControl runat="server" ID="ncClassReimbursable" Width="30" MaxLength="3" Mask="999" TextBoxCssClass="center" /></td>
                            <td><ATI:NumericControl runat="server" ID="ncInterval" Width="30" MaxLength="3" Mask="999" TextBoxCssClass="center" /></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <tr>
                            <td colspan="10" class="left">
                                No Classes Exist for the Selected Course
                            </td>
                        </tr>
                    </EmptyDataTemplate>
                </ATI:RepeaterListControl>
            </tbody>
        </table>
        <div class="right">
            <asp:LinkButton runat="server" ID="btnAddClasses" Text="Add a Class" OnClick="btnAddClasses_Click" CssClass="button add" />
            <asp:LinkButton runat="server" ID="btnDeleteClasses" Text="Remove Selected Classes" OnClick="btnDeleteClasses_Click" CssClass="button delete" />
        </div>
        <table class="formTable marginTop">
            <colgroup>
                <col style="width: 20em;" />
                <col style="width: 20em;" />
                <col style="width: auto;" />
                <col style="width: 4em;" />
            </colgroup>
            <tbody>
                <tr>
                    <td class="label left">POI Status Images:</td>
                    <td class="label left">Report Date Status Images:</td>
                    <td class="label">Total Classes:</td>
                    <td class="right"><asp:Literal runat="server" ID="ltrTotalClasses" /></td>
                </tr>
                <tr>
                    <td><asp:Image runat="server" ID="imgGreenPOI" CssClass="statusImage" ImageUrl="~/images/statusgreen.png" /> - Matches Course Default</td>
                    <td><asp:Image runat="server" ID="imgGreen" CssClass="statusImage" ImageUrl="~/images/statusgreen.png" /> - Matches calculated report date</td>
                    <td class="label">Total Students:</td>
                    <td class="right"><asp:Literal runat="server" ID="ltrTotalStudents" /></td>
                </tr>
                <tr>
                    <td><asp:Image runat="server" ID="imgYellowPOI" CssClass="statusImage" ImageUrl="~/images/statusamber.png" /> - Does not match Course Default</td>
                    <td><asp:Image runat="server" ID="imgYellow" CssClass="statusImage" ImageUrl="~/images/statusamber.png" /> - After calculated report date</td>
                    <td class="label">Total Reimbursable:</td>
                    <td class="right"><asp:Literal runat="server" ID="ltrTotalReimbursable" /></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><asp:Image runat="server" ID="imgRed" CssClass="statusImage" ImageUrl="~/images/statusred.png" /> - Before calculated report date</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </tbody>
        </table>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnUpdateClasses" Text="Update Classes" OnClick="btnUpdateClasses_Click" CssClass="button save" />
        </div>
        <asp:Panel runat="server" ID="pnlMassEdit" Visible="false">
            <h2 class="formTitle">Mass Edit Operations</h2>
            <div>
                <asp:LinkButton runat="server" ID="btnApplyRecommended" Text="Apply Recommended Report Dates" OnClick="btnApplyRecommended_Click" CssClass="button refresh" />
            </div>
            <h3 class="formTitle">Apply New POI</h3>
            <table class="formTable">
                <colgroup>
                    <col style="width: 10em;" />
                    <col style="width: 20em;" />
                    <col style="width: auto;" />
                </colgroup>
                <tbody>
                    <tr>
                        <td class="label left required">New POI:</td>
                        <td><ATI:ComboBoxControl runat="server" ID="cmbPOI" Width="250" /></td>
                        <td class="right">
                            <asp:LinkButton runat="server" ID="btnApplyPOI" Text="Apply POI to Selected Classes" OnClick="btnApplyPOI_Click" CssClass="button submit" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <h3 class="formTitle">Mass Change</h3>
            <table class="formTable">
                <colgroup>
                    <col style="width: 10em;" />
                    <col style="width: 6em;" />
                    <col style="width: 8em;" />
                    <col style="width: 6em;" />
                    <col style="width: 12em;" />
                    <col style="width: 5em;" />
                    <col style="width: 6em;" />
                    <col style="width: auto;" />
                </colgroup>
                <tbody>
                    <tr>
                        <td class="label left required">Begin Class Number:</td>
                        <td><ATI:NumericControl runat="server" ID="ncBeginClassNumber" Width="50" MaxLength="4" Mask="9999" /></td>
                        <td class="label left required">New Interval:</td>
                        <td><ATI:NumericControl runat="server" ID="ncNewInterval" Width="50" MaxLength="4" Mask="9999" /></td>
                        <td class="label left required">New Total Student Load:</td>
                        <td><ATI:NumericControl runat="server" ID="ncStudentLoad" Width="50" MaxLength="4" Mask="9999" /></td>
                        <td>
                            <ATI:ComboBoxControl runat="server" ID="cmbAddStudents" Width="30">
                                <asp:ListItem Text="All" Value="All" Selected="True" />
                                <asp:ListItem Text="Odd" Value="Odd" />
                                <asp:ListItem Text="Even" Value="Even" />
                            </ATI:ComboBoxControl>
                        </td>
                        <td class="right">
                            <asp:LinkButton runat="server" ID="btnChangeAll" Text="Apply Changes" OnClick="btnChangeAll_Click" CssClass="button submit" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </asp:Panel>
    </asp:Panel>
    <ATI:ModalPopup runat="server" ID="mpConfirmDeleteClass" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
        <div class="modalPopupTitle">Confirm Class Deletion</div>
        <div>Are you sure you want to delete the selected classes?</div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnDeleteClassConfirm" Text="Delete Classes" OnClick="btnDeleteClassConfirm_Click" CssClass="button ok" />
            <asp:LinkButton runat="server" ID="btnDeleteClassCancel" Text="Cancel" OnClick="btnDeleteClassCancel_Click" CssClass="button delete" />
        </div>
    </ATI:ModalPopup>
    <ATI:ModalPopup runat="server" ID="mpClassReport" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
        <div class="modalPopupTitle">Class Report</div>
        <div style="max-height: 50em; overflow-y: auto; padding: 1.5em;">
            <div id="divReport" style="width: 100%;">
                <asp:GridView runat="server" ID="gvReport" AutoGenerateColumns="true" CellPadding="0" CellSpacing="0" GridLines="None"
                    EmptyDataText="No Records Exist for the Selected Options" ShowHeaderWhenEmpty="false" CssClass="reportGrid"
                    RowStyle-CssClass="reportGridCellNoBorder" style="width: 100%; min-width: 40em;" />
            </div>
        </div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnPrintClassReport" Text="Print" OnClientClick="javascript:PrintDiv('divReport');" CssClass="button print" />
            <asp:LinkButton runat="server" ID="btnCloseClassReport" Text="Close" OnClick="btnCloseClassReport_Click" CssClass="button delete" />
        </div>
    </ATI:ModalPopup>
</asp:Content>
