<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TransmittalSheet.ascx.cs" Inherits="USAACE.eStaffing.Web.Controls.Forms.TransmittalSheet" %>
<table class="formTable">
    <colgroup>
        <col style="width: 25%;" />
        <col style="width: 25%;" />
        <col style="width: 25%;" />
        <col style="width: 25%;" />
    </colgroup>
    <tbody>
        <tr>
            <td class="label left">Is this in response to a Tasker?</td>
            <td><eStaffing:RadioButtonListControl runat="server" ID="rblIsTasker" CssClass="radioButtonList" RepeatDirection="Horizontal"
                RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="rblIsTasker_SelectedIndexChanged" /></td>
            <td class="label right" runat="server" id="tdTaskerNumber1" visible="false">Tasker Number:</td>
            <td runat="server" id="tdTaskerNumber2" visible="false"><eStaffing:TextControl runat="server" ID="txtTaskerNumber" Width="100%" /></td>
        </tr>
        <tr>
            <td colspan="3" class="label required left">Subject:<asp:RequiredFieldValidator runat="server" ID="rfvSubject" ControlToValidate="txtSubject" Text="*" ErrorMessage="Subject is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td class="label required left">Action Officer:<asp:RequiredFieldValidator runat="server" ID="rfvActionOfficer" ControlToValidate="txtActionOfficer" Text="*" ErrorMessage="Action Officer is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
        </tr>
        <tr>
            <td colspan="3"><eStaffing:TextControl runat="server" ID="txtSubject" Width="100%" TextMode="MultiLine" /></td>
            <td><eStaffing:TextControl runat="server" ID="txtActionOfficer" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label required left">Office Symbol:<asp:RequiredFieldValidator runat="server" ID="rfvOfficeSymbol" ControlToValidate="txtOfficeSymbol" Text="*" ErrorMessage="Office Symbol is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td class="label required left">Phone #:<asp:RequiredFieldValidator runat="server" ID="rfvPhoneNumber" ControlToValidate="txtPhoneNumber" Text="*" ErrorMessage="Phone Number is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td class="label left">Suspense Date:<asp:RequiredFieldValidator runat="server" ID="rfvSuspenseDate" ControlToValidate="dcSuspenseDate" Text="*" ErrorMessage="Suspense Date is a required field and must be a valid date." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td class="label left">Date:</td>
        </tr>
        <tr>
            <td><eStaffing:TextControl runat="server" ID="txtOfficeSymbol" Width="100%" /></td>
            <td><eStaffing:TextControl runat="server" ID="txtPhoneNumber" Width="100%" /></td>
            <td><eStaffing:DateControl runat="server" ID="dcSuspenseDate" Width="100" /></td>
            <td><eStaffing:DateControl runat="server" ID="dcDate" Width="100" /></td>
        </tr>
        <tr>
            <td colspan="4" class="checkBoxList">
                <asp:CheckBox runat="server" ID="chkSignature" Text="Signature" />
                <asp:CheckBox runat="server" ID="chkApproval" Text="Approval" />
                <asp:CheckBox runat="server" ID="chkInformation" Text="Information" />
                <asp:CheckBox runat="server" ID="chkReadAhead" Text="Read Ahead" />
                <asp:CheckBox runat="server" ID="chkOther" Text="Other" AutoPostBack="true" OnCheckedChanged="chkOther_CheckedChanged" />
                <eStaffing:TextControl runat="server" ID="txtOtherText" Width="200" />
            </td>
        </tr>
        <tr>
            <td colspan="4" class="label required left">Recommendation for Senior Leader:<asp:RequiredFieldValidator runat="server" ID="rfvRecommendation" ControlToValidate="hteRecommendation" Text="*" ErrorMessage="Recommendation for Senior Leader is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
        </tr>
        <tr>
            <td colspan="4"><eStaffing:HTMLEditor runat="server" ID="hteRecommendation" Height="150" /></td>
        </tr>
        <tr>
            <td colspan="4" class="checkBoxList">
                <asp:CheckBox runat="server" ID="chkRecommendCSM" Text="CSM" />
                <asp:CheckBox runat="server" ID="chkRecommendCPG" Text="CPG" />
                <asp:CheckBox runat="server" ID="chkRecommendDCOS" Text="DCOS" />
                <asp:CheckBox runat="server" ID="chkRecommendDCG" Text="DCG" />
                <asp:CheckBox runat="server" ID="chkRecommendCG" Text="CG" />
            </td>
        </tr>
        <tr>
            <td colspan="4" class="label required left">Discussion:<asp:RequiredFieldValidator runat="server" ID="rfvDiscussion" ControlToValidate="hteDiscussion" Text="*" ErrorMessage="Purpose is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
        </tr>
        <tr>
            <td colspan="4"><eStaffing:HTMLEditor runat="server" ID="hteDiscussion" Height="150" /></td>
        </tr>
        <tr>
            <td colspan="4" class="label left">Key Areas Impacted:</td>
        </tr>
        <tr>
            <td colspan="4" class="checkBoxList">
                <asp:CheckBox runat="server" ID="chkKeyAreaFunding" Text="Funding" />
                <asp:CheckBox runat="server" ID="chkKeyAreaPolicy" Text="Policy" />
                <asp:CheckBox runat="server" ID="chkKeyAreaEquipment" Text="Equipment" />
                <asp:CheckBox runat="server" ID="chkKeyAreaLegal" Text="Legal" />
                <asp:CheckBox runat="server" ID="chkKeyAreaTraining" Text="Training" />
                <asp:CheckBox runat="server" ID="chkKeyAreaPersonnel" Text="Personnel" />
                <asp:CheckBox runat="server" ID="chkKeyAreaCongressional" Text="Congressional" />
                <asp:CheckBox runat="server" ID="chkKeyAreaStrategy" Text="Strategy" />
                <asp:CheckBox runat="server" ID="chkKeyAreaOther" Text="Other" AutoPostBack="true" OnCheckedChanged="chkKeyAreaOther_CheckedChanged" />
                <eStaffing:TextControl runat="server" ID="txtKeyAreaOtherText" Width="200" />
            </td>
        </tr>
        <tr>
            <td colspan="4" class="label left">Principal Comments:</td>
        </tr>
        <tr>
            <td colspan="4"><eStaffing:HTMLEditor runat="server" ID="htePrincipalComments" Height="150" /></td>
        </tr>
    </tbody>
</table>
<h2 class="formTitle">Coordination Block</h2>
<table class="formGrid">
    <colgroup>
        <col style="width: 6em;" />
        <col style="width: 6em;" />
        <col style="width: 12em;" />
        <col style="width: 16em;" />
        <col style="width: 10em;" />
        <col style="width: 10em;" />
        <col style="width: auto;" />
        <col class="hidePrint" style="width: 5em;" />
        <col class="hidePrint" style="width: 5em;" />
    </colgroup>
    <thead>
        <tr>
            <th>Concur</th>
            <th>Non-Concur</th>
            <th>Agency</th>
            <th>Name (Title, Last Name)</th>
            <th>Phone</th>
            <th>Date</th>
            <th>Remarks</th>
            <th class="hidePrint">Edit</th>
            <th class="hidePrint">Delete</th>
        </tr>
    </thead>
    <tbody>
        <eStaffing:RepeaterListControl runat="server" ID="dlCoords" OnItemDataBound="dlCoords_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td><asp:Image runat="server" ID="imgCoordConcur" ImageUrl="~/images/ok.gif" /></td>
                    <td><asp:Image runat="server" ID="imgCoordNonConcur" ImageUrl="~/images/ok.gif" /></td>
                    <td><asp:Literal runat="server" ID="ltrCoordAgency" /></td>
                    <td><asp:Literal runat="server" ID="ltrCoordName" /></td>
                    <td><asp:Literal runat="server" ID="ltrCoordPhone" /></td>
                    <td><asp:Literal runat="server" ID="ltrCoordDate" /></td>
                    <td><asp:Literal runat="server" ID="ltrCoordRemarks" /></td>
                    <td class="hidePrint">
                        <asp:ImageButton runat="server" ID="imbEditCoord" ImageUrl="~/images/edit.gif" OnCommand="imbEditCoord_Command" />
                    </td>
                    <td class="hidePrint">
                        <asp:ImageButton runat="server" ID="imbDeleteCoord" ImageUrl="~/images/delete.gif" OnCommand="imbDeleteCoord_Command" />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr>
                    <td class="left" colspan="9">There are no coordinations.</td>
                </tr>
            </EmptyDataTemplate>
        </eStaffing:RepeaterListControl>
    </tbody>
</table>
<div class="right">
    <asp:LinkButton runat="server" ID="btnAddCoord" OnClick="btnAddCoord_Click" Text="Add Coordination" CssClass="button add" />
</div>
<eStaffing:ModalPopup runat="server" ID="mpEditCoord" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
    <div class="modalPopupTitle">Add/Edit Coordination</div>
    <div class="label left">Response:</div>
    <div><eStaffing:RadioButtonListControl runat="server" ID="rblCoordResponse" CssClass="radioButtonList" RepeatLayout="Flow" RepeatDirection="Horizontal" /></div>
    <div class="label left">Agency:</div>
    <div><eStaffing:TextControl runat="server" ID="txtCoordAgency" Width="100%" /></div>
    <div class="label left">Name (Title, Rank):</div>
    <div><eStaffing:TextControl runat="server" ID="txtCoordName" Width="100%" /></div>
    <div class="label left">Phone Number:</div>
    <div><eStaffing:TextControl runat="server" ID="txtCoordPhone" Width="100%" /></div>
    <div class="label left">Date:</div>
    <div><eStaffing:DateControl runat="server" ID="dcCoordDate" Width="100" /></div>
    <div class="label left">Remarks:</div>
    <div><eStaffing:TextControl runat="server" ID="txtCoordRemarks" Width="100%" /></div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnSaveCoord" Text="Save" CssClass="button save" OnClick="btnSaveCoord_Click" />
        <asp:LinkButton runat="server" ID="btnCancelCoord" Text="Cancel" CssClass="button delete" OnClick="btnCancelCoord_Click" />
    </div>
</eStaffing:ModalPopup>
<eStaffing:ModalPopup runat="server" ID="mpDeleteCoordConfirm" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
    <div class="modalPopupTitle">Confirm</div>
    <div>Are you sure you want to delete this coordination block item?</div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnDeleteCoordConfirm" Text="OK" CssClass="button ok" OnClick="btnDeleteCoordConfirm_Click" />
        <asp:LinkButton runat="server" ID="btnDeleteCoordCancel" Text="Cancel" CssClass="button delete" OnClick="btnDeleteCoordCancel_Click" />
    </div>
</eStaffing:ModalPopup>