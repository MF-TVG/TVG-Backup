<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AwardsSheet.ascx.cs" Inherits="USAACE.eStaffing.Web.Controls.Forms.AwardsSheet" %>
<table class="formTable">
    <colgroup>
        <col style="width: 16.67%;" />
        <col style="width: 16.67%;" />
        <col style="width: 16.67%;" />
        <col style="width: 16.67%;" />
        <col style="width: 33.33%;" />
    </colgroup>
    <tbody>
        <tr>
            <td colspan="5" class="center"><h2 class="formTitle">Section I. Administrative Data</h2></td>
        </tr>
        <tr>
            <td colspan="3" class="label required left">a. Rank, Name (Last, First, MI):<asp:RequiredFieldValidator runat="server" ID="rfvName" ControlToValidate="txtName" Text="*" ErrorMessage="Rank/Name is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td colspan="2" class="label required left">b. Unit/Organization:<asp:RequiredFieldValidator runat="server" ID="rfvOrganization" ControlToValidate="txtOrganization" Text="*" ErrorMessage="Unit/Organization is a required field." ValidationGroup="FormSubmit" EnableClientScript="false"  CssClass="validationError" /></td>
        </tr>
        <tr>
            <td colspan="3"><eStaffing:TextControl runat="server" ID="txtName" Width="100%" /></td>
            <td colspan="2"><eStaffing:TextControl runat="server" ID="txtOrganization" Width="100%" /></td>
        </tr>
        <tr>
            <td colspan="3" class="label required left">c. Presentation Date:<asp:RequiredFieldValidator runat="server" ID="rfvPresentationDate" ControlToValidate="dcPresentationDate" Text="*" ErrorMessage="Presentation Date is a required field and must be a valid date." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td colspan="2" class="label required left">d. Present Duty Position:<asp:RequiredFieldValidator runat="server" ID="rfvDutyPosition" ControlToValidate="txtDutyPosition" Text="*" ErrorMessage="Present Duty Position is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
        </tr>
        <tr>
            <td colspan="3"><eStaffing:DateControl runat="server" ID="dcPresentationDate" Width="100" /></td>
            <td colspan="2"><eStaffing:TextControl runat="server" ID="txtDutyPosition" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label required left">e. Highest Previous Award:<asp:RequiredFieldValidator runat="server" ID="cpvPreviousAward" ControlToValidate="ddlPreviousAward" Text="*" ErrorMessage="Highest Previous Award is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td colspan="2"><eStaffing:DropDownControl runat="server" ID="ddlPreviousAward" /></td>
            <td colspan="2" class="label required left">g. Time on Station:<asp:RequiredFieldValidator runat="server" ID="rfvStationTime" ControlToValidate="txtStationTime" Text="*" ErrorMessage="Time on Station is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
        </tr>
        <tr>
            <td class="label required left">f. Is soldier flagged:<asp:RequiredFieldValidator runat="server" ID="rfvFlagged" ControlToValidate="rblFlagged" Text="*" ErrorMessage="Soldier Flagged is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td colspan="2">
                <eStaffing:RadioButtonListControl runat="server" ID="rblFlagged" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="rblFlagged_SelectedIndexChanged" CssClass="radioButtonList" />
            </td>
            <td colspan="2"><eStaffing:TextControl runat="server" ID="txtStationTime" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label left">If "Yes", reason why:</td>
            <td colspan="2"><eStaffing:TextControl runat="server" ID="txtReasonFlagged" Width="100%" /></td>
            <td colspan="2"></td>
        </tr>
        <tr>
            <td colspan="3" class="label required left">h. Reason for Award:<asp:RequiredFieldValidator runat="server" ID="rfvAwardReason" ControlToValidate="rblAwardReason" Text="*" ErrorMessage="Reason for Award is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td colspan="2" class="label required left">i. Award level:<asp:RequiredFieldValidator runat="server" ID="rfvAwardLevel" ControlToValidate="rblAwardLevel" Text="*" ErrorMessage="Award Level is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
        </tr>
        <tr>
            <td colspan="3"><eStaffing:RadioButtonListControl runat="server" ID="rblAwardReason" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radioButtonList" /></td>
            <td colspan="2"><eStaffing:RadioButtonListControl runat="server" ID="rblAwardLevel" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radioButtonList" /></td>
        </tr>
        <tr>
            <td colspan="5" class="center"><h2 class="formTitle">Section II. Eligibility</h2></td>
        </tr>
        <tr>
            <td colspan="3" class="center"><h3 class="formTitle">Height/Weight Data</h3></td>
            <td colspan="2" class="center"><h3 class="formTitle">APFT Data</h3></td>
        </tr>
        <tr>
            <td>
                <span class="label required left">a. Height:</span><asp:RequiredFieldValidator runat="server" ID="rfvHeight" ControlToValidate="ncHeight" Text="*" ErrorMessage="Height is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" />
                <eStaffing:NumericControl runat="server" ID="ncHeight" Width="40" MaxLength="2" Mask="99" ClearMaskOnLostFocus="true" AcceptNegative="None" />
            </td>
            <td>
                <span class="label required left">b. Weight:</span><asp:RequiredFieldValidator runat="server" ID="rfvWeight" ControlToValidate="ncWeight" Text="*" ErrorMessage="Weight is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" />
                <eStaffing:NumericControl runat="server" ID="ncWeight" Width="40" MaxLength="3" Mask="999" ClearMaskOnLostFocus="true" AcceptNegative="None" />
            </td>
            <td>
                <span class="label required left">c. Age:</span><asp:RequiredFieldValidator runat="server" ID="rfvAge" ControlToValidate="ncAge" Text="*" ErrorMessage="Age is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" />
                <eStaffing:NumericControl runat="server" ID="ncAge" Width="40" MaxLength="3" Mask="999" ClearMaskOnLostFocus="true" AcceptNegative="None" />
            </td>
            <td class="label required left">a. APFT Date:<asp:RequiredFieldValidator runat="server" ID="rfvAPFTDate" ControlToValidate="dcAPFTDate" Text="*" ErrorMessage="APFT Date is a required field and must be a valid date." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td><eStaffing:DateControl runat="server" ID="dcAPFTDate" Width="100" /></td>
        </tr>
        <tr>
            <td class="label left">d. Body fat - Auth %:<asp:CustomValidator runat="server" ID="cvBodyFatAuth" Text="*" ErrorMessage="Body Fat Auth is a required field for No Go and must be numeric." ValidationGroup="FormSubmit" EnableClientScript="false" OnServerValidate="cvBodyFatAuth_ServerValidate" CssClass="validationError" /></td>
            <td><eStaffing:NumericControl runat="server" ID="ncBodyFatAuth" Width="40" MaxLength="3" Mask="999" ClearMaskOnLostFocus="true" AcceptNegative="None" /></td>
            <td class="label required left">Go / No Go:</td>
            <td class="label required left">b. Pass (Yes or No):<asp:RequiredFieldValidator runat="server" ID="rfvAPFTPass" ControlToValidate="rblAPFTPass" Text="*" ErrorMessage="APFT Pass is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td><eStaffing:RadioButtonListControl runat="server" ID="rblAPFTPass" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radioButtonList" /></td>
        </tr>
        <tr>
            <td class="label left">e. Body fat - Has %:<asp:CustomValidator runat="server" ID="cvBodyFatHas" Text="*" ErrorMessage="Body Fat Has is a required field for No Go and must be numeric." ValidationGroup="FormSubmit" EnableClientScript="false" OnServerValidate="cvBodyFatHas_ServerValidate" CssClass="validationError" /></td>
            <td><eStaffing:NumericControl runat="server" ID="ncBodyFatHas" Width="40" MaxLength="3" Mask="999" ClearMaskOnLostFocus="true" AcceptNegative="None" /></td>
            <td><eStaffing:RadioButtonListControl runat="server" ID="rblGo" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radioButtonList" /><asp:RequiredFieldValidator runat="server" ID="rfvGo" ControlToValidate="rblGo" Text="*" ErrorMessage="Go/No Go is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td class="label required left">c. Profile (Yes or No):<asp:RequiredFieldValidator runat="server" ID="rfvAPFTProfile" ControlToValidate="rblAPFTProfile" Text="*" ErrorMessage="APFT Profile is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td><eStaffing:RadioButtonListControl runat="server" ID="rblAPFTProfile" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radioButtonList" /></td>
        </tr>
        <tr>
            <td colspan="3" class="center"><h3 class="formTitle">Retirement Awards</h3></td>
            <td colspan="2" class="center"><h3 class="formTitle">PCS Awards</h3></td>
        </tr>
        <tr>
            <td class="label left">a. Total years service:</td>
            <td colspan="2"><eStaffing:NumericControl runat="server" ID="ncYearsService" Width="40" MaxLength="2" Mask="99" ClearMaskOnLostFocus="true" AcceptNegative="None" /></td>
            <td colspan="2" class="label left">a. Positions held at current duty station:</td>
        </tr>
        <tr>
            <td colspan="3"></td>
            <td colspan="2"><eStaffing:HTMLEditor runat="server" ID="htePositionsCurrent" Height="150" /></td>
        </tr>
        <tr>
            <td colspan="3" class="label left">b. Key Command or Staff Positions held (command, combat...):</td>
            <td colspan="2" class="label left">b. Awards received at current duty station:</td>
        </tr>
        <tr>
            <td colspan="3"><eStaffing:HTMLEditor runat="server" ID="hteKeyPositions" Height="150" /></td>
            <td colspan="2"><eStaffing:HTMLEditor runat="server" ID="hteAwardsCurrent" Height="150" /></td>
        </tr>
        <tr>
            <td colspan="5" class="center"><h2 class="formTitle">Section III. Recommender Comments (From 638)</h2></td>
        </tr>
        <tr>
            <td colspan="3" class="center"><h3 class="formTitle">Leader Comments</h3></td>
            <td colspan="2" class="center"><h3 class="formTitle">Unit Actions</h3></td>
        </tr>
        <tr>
            <td colspan="3" class="label required left">a. BDE CDR / Director Comments:<asp:RequiredFieldValidator runat="server" ID="rfvDirectorComments" ControlToValidate="hteDirectorComments" Text="*" ErrorMessage="BDE CDR / Director Comments is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td class="label left">a. BDE CDR Date Signed:</td>
            <td><eStaffing:DateControl runat="server" ID="dcBDESignDate" Width="100" /></td>
        </tr>
        <tr>
            <td colspan="3"><eStaffing:HTMLEditor runat="server" ID="hteDirectorComments" Height="150" /></td>
            <td colspan="2"></td>
        </tr>
        <tr>
            <td colspan="3" class="label required left">b. Senior NCO Comments:<asp:RequiredFieldValidator runat="server" ID="rfvSeniorNCOComments" ControlToValidate="hteSeniorNCOComments" Text="*" ErrorMessage="Senior NCO Comments is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td colspan="2" class="label left">b. Comments:</td>
        </tr>
        <tr>
            <td colspan="3"><eStaffing:HTMLEditor runat="server" ID="hteSeniorNCOComments" Height="150" /></td>
            <td colspan="2"><eStaffing:HTMLEditor runat="server" ID="hteBDEComments" Height="150" /></td>
        </tr>
    </tbody>
</table>
