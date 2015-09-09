<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TDYSheet.ascx.cs" Inherits="USAACE.eStaffing.Web.Controls.Forms.TDYSheet" %>
<table class="formTable">
    <colgroup>
        <col style="width: 10%;" />
        <col style="width: 15%;" />
        <col style="width: 25%;" />
        <col style="width: 25%;" />
        <col style="width: 25%;" />
    </colgroup>
    <tbody>
        <tr>
            <td colspan="2" class="label required left">1. Action Office:<asp:RequiredFieldValidator runat="server" ID="rfvActionOffice" ControlToValidate="txtActionOffice" Text="*" ErrorMessage="Action Office is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td class="label required left">2. Phone #:<asp:RequiredFieldValidator runat="server" ID="rfvPhoneNumber" ControlToValidate="txtPhoneNumber" Text="*" ErrorMessage="Phone Number is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td class="label required left">3. Suspense Date:<asp:RequiredFieldValidator runat="server" ID="rfvSuspenseDate" ControlToValidate="dcSuspenseDate" Text="*" ErrorMessage="Suspense Date is a required field and must be a valid date." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td class="label left">4. Date:</td>
        </tr>
        <tr>
            <td colspan="2"><eStaffing:TextControl runat="server" ID="txtActionOffice" Width="100%" /></td>
            <td><eStaffing:TextControl runat="server" ID="txtPhoneNumber" Width="100%" /></td>
            <td><eStaffing:DateControl runat="server" ID="dcSuspenseDate" Width="100" /></td>
            <td><eStaffing:DateControl runat="server" ID="dcDate" Width="100" /></td>
        </tr>
        <tr>
            <td colspan="3" class="label required left">5. Subject:<asp:RequiredFieldValidator runat="server" ID="rfvSubject" ControlToValidate="txtSubject" Text="*" ErrorMessage="Subject is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td colspan="2" class="label required left">6. Action Officer:<asp:RequiredFieldValidator runat="server" ID="rfvActionOfficer" ControlToValidate="txtActionOfficer" Text="*" ErrorMessage="Action Officer is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
        </tr>
        <tr>
            <td colspan="3"><eStaffing:TextControl runat="server" ID="txtSubject" Width="100%" /></td>
            <td colspan="2"><eStaffing:TextControl runat="server" ID="txtActionOfficer" Width="100%" /></td>
        </tr>
        <tr>
            <td colspan="5" class="checkBoxList">
                <asp:CheckBox runat="server" ID="chkSignature" Text="Signature" />
                <asp:CheckBox runat="server" ID="chkApproval" Text="Approval" />
                <asp:CheckBox runat="server" ID="chkInformation" Text="Information" />
                <asp:CheckBox runat="server" ID="chkReadAhead" Text="Read Ahead" />
            </td>
        </tr>
        <tr>
            <td colspan="5" class="label left">Is this trip mission essential, and how does it provide priority support to the ongoing and future efforts in the GWOT, OIF, and/or OEF?</td>
        </tr>
        <tr>
            <td colspan="5"><eStaffing:TextControl runat="server" ID="txtMissionEssential" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label required">7. Purpose:<asp:RequiredFieldValidator runat="server" ID="rfvPurpose" ControlToValidate="txtPurpose" Text="*" ErrorMessage="Purpose is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td colspan="4"><eStaffing:TextControl runat="server" ID="txtPurpose" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label required">8. Location:<asp:RequiredFieldValidator runat="server" ID="rfvLocation" ControlToValidate="txtLocation" Text="*" ErrorMessage="Location is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td colspan="4"><eStaffing:TextControl runat="server" ID="txtLocation" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label required">9. Dates:<asp:CustomValidator runat="server" ID="cvDates" Text="*" ErrorMessage="Dates is a required field and must be a valid range." ValidationGroup="FormSubmit" EnableClientScript="false" OnServerValidate="cvDates_ServerValidate" CssClass="validationError" /></td>
            <td colspan="4"><eStaffing:DateControl runat="server" ID="dcDateStart" Width="100" /><span style="padding: 0em 1em;">to</span><eStaffing:DateControl runat="server" ID="dcDateEnd" Width="100" /></td>
        </tr>
        <tr>
            <td class="label required">10. Funding:<asp:RequiredFieldValidator runat="server" ID="rfvFunding" ControlToValidate="hteFunding" Text="*" ErrorMessage="Funding is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td colspan="4"><eStaffing:HTMLEditor runat="server" ID="hteFunding" Height="150" /></td>
        </tr>
        <tr>
            <td class="label required">11. Summary:<asp:RequiredFieldValidator runat="server" ID="rfvSummary" ControlToValidate="hteSummary" Text="*" ErrorMessage="Summary is a required field." ValidationGroup="FormSubmit" EnableClientScript="false" CssClass="validationError" /></td>
            <td colspan="4"><eStaffing:HTMLEditor runat="server" ID="hteSummary" Height="150" /></td>
        </tr>
    </tbody>
</table>
<h2 class="formTitle">TDY Attendees</h2>
<table class="formGrid">
    <colgroup>
        <col style="width: auto;" />
        <col style="width: 12em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col class="hidePrint" style="width: 5em;" />
        <col class="hidePrint" style="width: 5em;" />
    </colgroup>
    <thead>
        <tr>
            <th class="left">Rank/Name<asp:CustomValidator runat="server" ID="cvAttendees" Text="*" ErrorMessage="At least one Attendee is required." ValidationGroup="FormSubmit" EnableClientScript="false" OnServerValidate="cvAttendees_ServerValidate" CssClass="validationError" /></th>
            <th>Duty Pos</th>
            <th>Per Diem</th>
            <th>Lodge</th>
            <th>Travel</th>
            <th>Travel Mode</th>
            <th>Rental</th>
            <th>Other</th>
            <th>Total</th>
            <th class="hidePrint">Edit</th>
            <th class="hidePrint">Delete</th>
        </tr>
    </thead>
    <tbody>
        <eStaffing:RepeaterListControl runat="server" ID="dlAttendees" OnItemDataBound="dlAttendees_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td class="left"><asp:Literal runat="server" ID="ltrAttendeeName" /></td>
                    <td><asp:Literal runat="server" ID="ltrAttendeeDuty" /></td>
                    <td><asp:Literal runat="server" ID="ltrAttendeePerDiem" /></td>
                    <td><asp:Literal runat="server" ID="ltrAttendeeLodge" /></td>
                    <td><asp:Literal runat="server" ID="ltrAttendeeTravel" /></td>
                    <td><asp:Literal runat="server" ID="ltrAttendeeTravelMode" /></td>
                    <td><asp:Literal runat="server" ID="ltrAttendeeRental" /></td>
                    <td><asp:Literal runat="server" ID="ltrAttendeeOther" /></td>
                    <td><asp:Literal runat="server" ID="ltrAttendeeTotal" /></td>
                    <td class="hidePrint">
                        <asp:ImageButton runat="server" ID="imbEditAttendee" ImageUrl="~/images/edit.gif" OnCommand="imbEditAttendee_Command" />
                    </td>
                    <td class="hidePrint">
                        <asp:ImageButton runat="server" ID="imbDeleteAttendee" ImageUrl="~/images/delete.gif" OnCommand="imbDeleteAttendee_Command" />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr>
                    <td class="left" colspan="11">There are no attendees.</td>
                </tr>
            </EmptyDataTemplate>
        </eStaffing:RepeaterListControl>
    </tbody>
    <tfoot>
        <tr>
            <td></td>
            <td class="label required">Total</td>
            <td><asp:Literal runat="server" ID="ltrAttendeePerDiemTotal" /></td>
            <td><asp:Literal runat="server" ID="ltrAttendeeLodgeTotal" /></td>
            <td><asp:Literal runat="server" ID="ltrAttendeeTravelTotal" /></td>
            <td></td>
            <td><asp:Literal runat="server" ID="ltrAttendeeRentalTotal" /></td>
            <td><asp:Literal runat="server" ID="ltrAttendeeOtherTotal" /></td>
            <td><asp:Literal runat="server" ID="ltrAttendeeTotalTotal" /></td>
            <td></td>
            <td></td>
        </tr>
    </tfoot>
</table>
<div class="right">
    <asp:LinkButton runat="server" ID="btnAddAttendee" OnClick="btnAddAttendee_Click" Text="Add Attendee" CssClass="button add" />
</div>
<eStaffing:ModalPopup runat="server" ID="mpEditAttendee" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
    <div class="modalPopupTitle">Add/Edit TDY Attendee</div>
    <div class="label left">Rank / Name:</div>
    <div><eStaffing:TextControl runat="server" ID="txtAttendeeName" Width="100%" /></div>
    <div class="label left">Duty Position:</div>
    <div><eStaffing:TextControl runat="server" ID="txtAttendeeDuty" Width="100%" /></div>
    <div class="label left">Per Diem:</div>
    <div><eStaffing:TextControl runat="server" ID="txtAttendeePerDiem" Width="100%" /></div>
    <div class="label left">Lodge:</div>
    <div><eStaffing:TextControl runat="server" ID="txtAttendeeLodge" Width="100%" /></div>
    <div class="label left">Travel:</div>
    <div><eStaffing:TextControl runat="server" ID="txtAttendeeTravel" Width="100%" /></div>
    <div class="label left">Travel Mode:</div>
    <div><eStaffing:DropDownControl runat="server" ID="ddlAttendeeTravelMode" /></div>
    <div class="label left">Rental:</div>
    <div><eStaffing:TextControl runat="server" ID="txtAttendeeRental" Width="100%" /></div>
    <div class="label left">Other:</div>
    <div><eStaffing:TextControl runat="server" ID="txtAttendeeOther" Width="100%" /></div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnSaveAttendee" Text="Save" CssClass="button save" OnClick="btnSaveAttendee_Click" />
        <asp:LinkButton runat="server" ID="btnCancelAttendee" Text="Cancel" CssClass="button delete" OnClick="btnCancelAttendee_Click" />
    </div>
</eStaffing:ModalPopup>
<eStaffing:ModalPopup runat="server" ID="mpDeleteAttendeeConfirm" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
    <div class="modalPopupTitle">Confirm</div>
    <div>Are you sure you want to delete this TDY attendee?</div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnDeleteAttendeeConfirm" Text="OK" CssClass="button ok" OnClick="btnDeleteAttendeeConfirm_Click" />
        <asp:LinkButton runat="server" ID="btnDeleteAttendeeCancel" Text="Cancel" CssClass="button delete" OnClick="btnDeleteAttendeeCancel_Click" />
    </div>
</eStaffing:ModalPopup>