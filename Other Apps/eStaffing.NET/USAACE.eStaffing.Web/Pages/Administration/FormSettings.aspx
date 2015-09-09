<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormSettings.aspx.cs" Inherits="USAACE.eStaffing.Web.Pages.Administration.FormSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Organization Form Settings</h1>
    <table class="formTable">
        <colgroup>
            <col style="width: 18em;" />
            <col style="width: auto;" />
            <col style="width: 18em;" />
            <col style="width: auto;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label required">
                    Select an Organization:
                </td>
                <td>
                    <eStaffing:DropDownControl runat="server" ID="ddlOrganization" AutoPostBack="true" OnSelectedIndexChanged="ddlOrganizationFormType_SelectedIndexChanged" />
                </td>
                <td class="label required">
                    Select a Form Type:
                </td>
                <td>
                    <eStaffing:DropDownControl runat="server" ID="ddlFormType" AutoPostBack="true" OnSelectedIndexChanged="ddlOrganizationFormType_SelectedIndexChanged" />
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Panel runat="server" ID="pnlData" Visible="false">
        <h2 class="formTitle">Basic Organization Form Settings</h2>
        <table class="formTable">
            <colgroup>
                <col style="width: 38em;" />
                <col style="width: auto;" />
            </colgroup>
            <tbody>
                <tr>
                    <td>
                        <div class="label left">Review Process Type:</div>
                        <div>Parallel = All reviewers in your organization are notified at once</div>
                        <div>Serial = Reviewers in your organization are notified one at a time</div>
                    </td>
                    <td>
                        <eStaffing:RadioButtonListControl runat="server" ID="rblParallelReview" CssClass="radioButtonList" RepeatDirection="Horizontal" RepeatLayout="Flow" />
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Number of Days Before Due Date to Show "Near Due" Status:
                    </td>
                    <td>
                        <eStaffing:TextControl runat="server" ID="txtNearDueDays" MaxLength="5" Width="60" />
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Number of Days Before Due Date to Show "Past Due" Status:
                    </td>
                    <td>
                        <eStaffing:TextControl runat="server" ID="txtPastDueDays" MaxLength="5" Width="60" />
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Number of Days to Adjust Date to Get Final Suspense Date:
                    </td>
                    <td>
                        <eStaffing:TextControl runat="server" ID="txtSuspenseAdjust" MaxLength="5" Width="60" />
                    </td>
                </tr>
            </tbody>
        </table>
        <h2 class="formTitle">Organization Form Actors</h2>
        <table class="formGrid">
            <colgroup>
                <col style="width: auto;" />
                <col style="width: 6em;" />
                <col style="width: 6em;" />
                <col style="width: 6em;" />
                <col style="width: 6em;" />
                <col style="width: 6em;" />
                <col style="width: 6em;" />
                <col style="width: 6em;" />
                <col style="width: 6em;" />
                <col style="width: 6em;" />
                <col style="width: 6em;" />
                <col style="width: 6em;" />
                <col style="width: 6em;" />
                <col style="width: 5em;" />
            </colgroup>
            <thead>
                <tr>
                    <th class="left">Group</th>
                    <th>Admin</th>
                    <th>Submit</th>
                    <th>Review</th>
                    <th>Choose Route</th>
                    <th>Change Route</th>
                    <th>Edit Submit</th>
                    <th>Forward</th>
                    <th>See Remarks</th>
                    <th>View All</th>
                    <th>Assign Autopen</th>
                    <th>Force Review</th>
                    <th>Finish Notify</th>
                    <th>Edit</th>
                </tr>
            </thead>
            <tbody>
        <eStaffing:RepeaterListControl runat="server" ID="dlOrganizationFormActors" OnItemDataBound="dlOrganizationFormActors_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td class="left"><asp:Literal runat="server" ID="ltrOrganizationGroupName" /></td>
                    <td><asp:Image runat="server" ID="imgAdmin" ImageUrl="~/images/ok.gif" /></td>
                    <td><asp:Image runat="server" ID="imgSubmit" ImageUrl="~/images/ok.gif" /></td>
                    <td><asp:Image runat="server" ID="imgReview" ImageUrl="~/images/ok.gif" /></td>
                    <td><asp:Image runat="server" ID="imgChooseRoute" ImageUrl="~/images/ok.gif" /></td>
                    <td><asp:Image runat="server" ID="imgChangeRoute" ImageUrl="~/images/ok.gif" /></td>
                    <td><asp:Image runat="server" ID="imgEditSubmission" ImageUrl="~/images/ok.gif" /></td>
                    <td><asp:Image runat="server" ID="imgForward" ImageUrl="~/images/ok.gif" /></td>
                    <td><asp:Image runat="server" ID="imgSeeComments" ImageUrl="~/images/ok.gif" /></td>
                    <td><asp:Image runat="server" ID="imgViewAll" ImageUrl="~/images/ok.gif" /></td>
                    <td><asp:Image runat="server" ID="imgAssignAutopen" ImageUrl="~/images/ok.gif" /></td>
                    <td><asp:Image runat="server" ID="imgMustReview" ImageUrl="~/images/ok.gif" /></td>
                    <td><asp:Image runat="server" ID="imgNotifyComplete" ImageUrl="~/images/ok.gif" /></td>
                    <td><asp:ImageButton runat="server" ID="imbEditFormActor" ImageUrl="~/images/edit.gif" OnCommand="imbEditFormActor_Command" /></td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr>
                    <td class="left" colspan="14">There are no form actors for this organization and form type.</td>
                </tr>
            </EmptyDataTemplate>
        </eStaffing:RepeaterListControl>
            </tbody>
        </table>
        <eStaffing:ModalPopup runat="server" ID="mpEditFormActor" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
            <div class="modalPopupTitle">Edit Form Actor</div>
            <div>
                <span class="label required">Organization:</span> <asp:Literal runat="server" ID="ltrSelectedOrganizationName" />
            </div>
            <div class="marginTop">
                <asp:CheckBox runat="server" ID="chkAdmin" Text="This group has full administrator capabilities." />
            </div>
            <div>
                <asp:CheckBox runat="server" ID="chkSubmit" Text="This group has the ability to submit new forms." />
            </div>
            <div>
                <asp:CheckBox runat="server" ID="chkReview" Text="This group has can be selected to review forms." />
            </div>
            <div>
                <asp:CheckBox runat="server" ID="chkChooseRoute" Text="This group has the ability to choose a routing chain for new forms." />
            </div>
            <div>
                <asp:CheckBox runat="server" ID="chkChangeRoute" Text="This group has the ability to change the routing chain for forms." />
            </div>
            <div>
                <asp:CheckBox runat="server" ID="chkEditSubmission" Text="This group has the ability to edit forms even after submission." />
            </div>
            <div>
                <asp:CheckBox runat="server" ID="chkForward" Text="This group has the ability to forward forms to other organizations." />
            </div>
            <div>
                <asp:CheckBox runat="server" ID="chkSeeComments" Text="This group has the ability to see review comments." />
            </div>
            <div>
                <asp:CheckBox runat="server" ID="chkViewAll" Text="This group has the ability to view all forms for this organization." />
            </div>
            <div>
                <asp:CheckBox runat="server" ID="chkAssignAutopen" Text="This group has the ability to assign autopen permission." />
            </div>
            <div>
                <asp:CheckBox runat="server" ID="chkMustReview" Text="This group must review all forms resubmitted because of rejection." />
            </div>
            <div>
                <asp:CheckBox runat="server" ID="chkNotifyComplete" Text="This group must be notified upon completion of a form review process." />
            </div>
            <div class="right marginTop">
                <asp:LinkButton runat="server" ID="btnSaveFormActor" Text="Save" CssClass="button save" OnClick="btnSaveFormActor_Click" />
                <asp:LinkButton runat="server" ID="btnCancelFormActor" Text="Cancel" CssClass="button delete" OnClick="btnCancelFormActor_Click" />
            </div>
        </eStaffing:ModalPopup>
        <h2 class="formTitle">Notification Templates</h2>
        <table class="formGrid">
            <colgroup>
                <col style="width: 10em;" />
                <col style="width: 30em;" />
                <col style="width: auto;" />
                <col style="width: 5em;" />
            </colgroup>
            <thead>
                <tr>
                    <th class="left">Notice Type</th>
                    <th class="left">Subject</th>
                    <th class="left">Message</th>
                    <th>Edit</th>
                </tr>
            </thead>
            <tbody>
                <tr class="gridrow">
                    <td class="left">Review</td>
                    <td class="left"><asp:Literal runat="server" ID="ltrReviewSubject" /></td>
                    <td class="left"><asp:Literal runat="server" ID="ltrReviewMessage" /></td>
                    <td><asp:ImageButton runat="server" ID="imbEditReviewMessage" ImageUrl="~/images/edit.gif" CommandArgument="Review" OnCommand="imbEditMessage_Command" /></td>
                </tr>
                <tr class="altgridrow">
                    <td class="left">Rejection</td>
                    <td class="left"><asp:Literal runat="server" ID="ltrRejectSubject" /></td>
                    <td class="left"><asp:Literal runat="server" ID="ltrRejectMessage" /></td>
                    <td><asp:ImageButton runat="server" ID="imbEditRejectMessage" ImageUrl="~/images/edit.gif" CommandArgument="Rejection" OnCommand="imbEditMessage_Command" /></td>
                </tr>
                <tr class="gridrow">
                    <td class="left">Completion</td>
                    <td class="left"><asp:Literal runat="server" ID="ltrCompleteSubject" /></td>
                    <td class="left"><asp:Literal runat="server" ID="ltrCompleteMessage" /></td>
                    <td><asp:ImageButton runat="server" ID="imbEditCompleteMessage" ImageUrl="~/images/edit.gif" CommandArgument="Completion" OnCommand="imbEditMessage_Command" /></td>
                </tr>
            </tbody>
        </table>
        <eStaffing:ModalPopup runat="server" ID="mpEditMessage" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
            <div class="modalPopupTitle">Edit Message Template</div>
            <div>
                <span class="label required">Notice Type:</span> <asp:Literal runat="server" ID="ltrSelectedNoticeType" />
            </div>
            <div class="marginTop">Subject:</div>
            <div><eStaffing:TextControl runat="server" ID="txtEditSubject" MaxLength="200" Width="100%" /></div>
            <div>Message:</div>
            <div><eStaffing:HTMLEditor runat="server" ID="hteEditMessage" Height="150" /></div>
            <div class="right marginTop">
                <asp:LinkButton runat="server" ID="btnSaveMessage" Text="Save" CssClass="button save" OnClick="btnSaveMessage_Click" />
                <asp:LinkButton runat="server" ID="btnCancelMessage" Text="Cancel" CssClass="button delete" OnClick="btnCancelMessage_Click" />
            </div>
        </eStaffing:ModalPopup>
        <h3 class="formTitle">Template Options</h3>
        <ul>
            <li><b>{Title}</b> - Inserts the type of the form</li>
            <li><b>{Subject}</b> - Inserts the subject of the form</li>
            <li><b>{Link}</b> - Inserts a hyperlink to the form</li>
            <li><b>{Reviewer}</b> - Inserts the current reviewer being notified (only applies to Review Notice)</li>
            <li><b>{Actor}</b> - Inserts the reviewer that took the action (only applies to Rejection and Completion Notices)</li>
            <li><b>{Comments}</b> - Inserts the comments provided by the acting reviewer (only applies to Rejection and Completion Notices)</li>
        </ul>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnSaveFormSettings" CssClass="button save" Text="Save Form Settings" OnClick="btnSaveFormSettings_Click" />
        </div>
    </asp:Panel>
</asp:Content>
