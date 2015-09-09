<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Form2028Sheet.ascx.cs" Inherits="USAACE.eStaffing.Web.Controls.Forms.Form2028Sheet" %>
<h2 class="formTitle center">Part I - All Publications (Except RPSTL and SC/SM) and Blank Forms</h2>
<table class="formTable">
    <colgroup>
        <col style="width: 50%;" />
        <col style="width: 50%;" />
    </colgroup>
    <tbody>
        <tr>
            <td class="label left">Lesson ID</td>
            <td class="label left">Lesson Version</td>
        </tr>
        <tr>
            <td><eStaffing:TextControl runat="server" ID="txtLessonID" Width="100%" /></td>
            <td><eStaffing:TextControl runat="server" ID="txtLessonVersion" Width="100%" /></td>
        </tr>
        <tr>
            <td colspan="2" class="label left">Course Type</td>
        </tr>
        <tr>
            <td colspan="2"><eStaffing:DropDownControl runat="server" ID="ddlCourseType" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlCourseType_SelectedIndexChanged" /></td>
        </tr>
        <tr>
            <td class="label left">Course Number</td>
            <td class="label left">Course Title</td>
        </tr>
        <tr>
            <td><eStaffing:DropDownControl runat="server" ID="ddlCourseNumber" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlCourseNumber_SelectedIndexChanged" /></td>
            <td><asp:Literal runat="server" ID="ltrCourseTitle" /></td>
        </tr>
    </tbody>
</table>
<table class="formGrid">
    <colgroup>
        <col style="width: 3em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: auto;" />
        <col class="hidePrint" style="width: 5em;" />
        <col class="hidePrint" style="width: 5em;" />
    </colgroup>
    <thead>
        <tr>
            <th></th>
            <th>Page No.</th>
            <th>Para- graph</th>
            <th>Line No.</th>
            <th>Figure No.</th>
            <th>Table No.</th>
            <th class="left">Recommended Changes and Reason</th>
            <th class="hidePrint">Edit</th>
            <th class="hidePrint">Delete</th>
        </tr>
    </thead>
    <tbody>
        <eStaffing:RepeaterListControl runat="server" ID="dlPublicationChanges" OnItemDataBound="dlPublicationChanges_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td><asp:Literal runat="server" ID="ltrItem" /></td>
                    <td><asp:Literal runat="server" ID="ltrPageNumber" /></td>
                    <td><asp:Literal runat="server" ID="ltrParagraph" /></td>
                    <td><asp:Literal runat="server" ID="ltrLineNumber" /></td>
                    <td><asp:Literal runat="server" ID="ltrFigureNumber" /></td>
                    <td><asp:Literal runat="server" ID="ltrTableNumber" /></td>
                    <td class="left"><asp:Literal runat="server" ID="ltrRecommendedChanges" /></td>
                    <td class="hidePrint">
                        <asp:ImageButton runat="server" ID="imbEditPublicationChange" ImageUrl="~/images/edit.gif" OnCommand="imbEditPublicationChange_Command" />
                    </td>
                    <td class="hidePrint">
                        <asp:ImageButton runat="server" ID="imbDeletePublicationChange" ImageUrl="~/images/delete.gif" OnCommand="imbDeletePublicationChange_Command" />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr>
                    <td class="left" colspan="9">There are no publication changes.</td>
                </tr>
            </EmptyDataTemplate>
        </eStaffing:RepeaterListControl>
    </tbody>
</table>
<div class="right">
    <asp:LinkButton runat="server" ID="btnAddPublicationChange" OnClick="btnAddPublicationChange_Click" Text="Add Publication Change" CssClass="button add" />
</div>
<h2 class="formTitle center">Part II - Repair Parts and Special Tool Lists and Supply Catalogs/Supply Manuals</h2>
<table class="formGrid">
    <colgroup>
        <col style="width: 3em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: auto;" />
        <col class="hidePrint" style="width: 5em;" />
        <col class="hidePrint" style="width: 5em;" />
    </colgroup>
    <thead>
        <tr>
            <th></th>
            <th>Page No.</th>
            <th>Colm No.</th>
            <th>Line No.</th>
            <th>National Stock Number</th>
            <th>Reference No.</th>
            <th>Figure No.</th>
            <th>Item No.</th>
            <th>Total No. of Major Items Supported</th>
            <th class="left">Recommended Action</th>
            <th class="hidePrint">Edit</th>
            <th class="hidePrint">Delete</th>
        </tr>
    </thead>
    <tbody>
        <eStaffing:RepeaterListControl runat="server" ID="dlRepairChanges" OnItemDataBound="dlRepairChanges_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td><asp:Literal runat="server" ID="ltrItem" /></td>
                    <td><asp:Literal runat="server" ID="ltrPageNumber" /></td>
                    <td><asp:Literal runat="server" ID="ltrColumnNumber" /></td>
                    <td><asp:Literal runat="server" ID="ltrLineNumber" /></td>
                    <td><asp:Literal runat="server" ID="ltrNationalStockNumber" /></td>
                    <td><asp:Literal runat="server" ID="ltrReferenceNumber" /></td>
                    <td><asp:Literal runat="server" ID="ltrFigureNumber" /></td>
                    <td><asp:Literal runat="server" ID="ltrItemNumber" /></td>
                    <td><asp:Literal runat="server" ID="ltrItemCount" /></td>
                    <td class="left"><asp:Literal runat="server" ID="ltrRecommendedAction" /></td>
                    <td class="hidePrint">
                        <asp:ImageButton runat="server" ID="imbEditRepairChange" ImageUrl="~/images/edit.gif" OnCommand="imbEditRepairChange_Command" />
                    </td>
                    <td class="hidePrint">
                        <asp:ImageButton runat="server" ID="imbDeleteRepairChange" ImageUrl="~/images/delete.gif" OnCommand="imbDeleteRepairChange_Command" />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr>
                    <td class="left" colspan="11">There are no repair part changes.</td>
                </tr>
            </EmptyDataTemplate>
        </eStaffing:RepeaterListControl>
    </tbody>
</table>
<div class="right">
    <asp:LinkButton runat="server" ID="btnAddRepairChange" OnClick="btnAddRepairChange_Click" Text="Add Repair Change" CssClass="button add" />
</div>
<h2 class="formTitle center">Part III - Remarks</h2>
<table class="formTable">
    <colgroup>
        <col style="width: 50%;" />
        <col style="width: 50%;" />
    </colgroup>
    <tbody>
        <tr>
            <td colspan="2"><eStaffing:HTMLEditor runat="server" ID="hteRemarks" Height="150" /></td>
        </tr>
        <tr>
            <td class="label left">Typed Name, Grade or Title</td>
            <td class="label left">Telephone Exchange/Autovon, Plus Extension</td>
        </tr>
        <tr>
            <td><eStaffing:TextControl runat="server" ID="txtSubmitterName" Width="100%" /></td>
            <td><eStaffing:TextControl runat="server" ID="txtPhoneNumber" Width="100%" /></td>
        </tr>
    </tbody>
</table>
<eStaffing:ModalPopup runat="server" ID="mpEditPublication" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
    <div class="modalPopupTitle">Add/Edit Publication Change</div>
    <table class="formTable">
        <colgroup>
            <col style="width: 10em;" />
            <col style="width: 40em;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label left">Page Number:</td>
                <td><eStaffing:TextControl runat="server" ID="txtPublicationPageNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Paragraph:</td>
                <td><eStaffing:TextControl runat="server" ID="txtPublicationParagraph" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Line Number:</td>
                <td><eStaffing:TextControl runat="server" ID="txtPublicationLineNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Figure Number:</td>
                <td><eStaffing:TextControl runat="server" ID="txtPublicationFigureNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Table Number:</td>
                <td><eStaffing:TextControl runat="server" ID="txtPublicationTableNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <div class="label left">Recommended Changes and Reason:</div>
                    (Provide exact wording of recommended changes, if possible)
                </td>
            </tr>
            <tr>
                <td colspan="2"><eStaffing:HTMLEditor runat="server" ID="htePublicationRecommendedChanges" Height="150" /></td>
            </tr>
        </tbody>
    </table>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnSavePublication" Text="Save" CssClass="button save" OnClick="btnSavePublication_Click" />
        <asp:LinkButton runat="server" ID="btnCancelPublication" Text="Cancel" CssClass="button delete" OnClick="btnCancelPublication_Click" />
    </div>
</eStaffing:ModalPopup>
<eStaffing:ModalPopup runat="server" ID="mpDeletePublicationConfirm" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
    <div class="modalPopupTitle">Confirm</div>
    <div>Are you sure you want to delete this publication change?</div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnDeletePublicationConfirm" Text="OK" CssClass="button ok" OnClick="btnDeletePublicationConfirm_Click" />
        <asp:LinkButton runat="server" ID="btnDeletePublicationCancel" Text="Cancel" CssClass="button delete" OnClick="btnDeletePublicationCancel_Click" />
    </div>
</eStaffing:ModalPopup>
<eStaffing:ModalPopup runat="server" ID="mpEditRepair" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
    <div class="modalPopupTitle">Add/Edit Repair Part Change</div>
    <table class="formTable">
        <colgroup>
            <col style="width: 15em;" />
            <col style="width: 25em;" />
            <col style="width: 10em;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label left">Page Number:</td>
                <td colspan="2"><eStaffing:TextControl runat="server" ID="txtRepairPageNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Column Number:</td>
                <td colspan="2"><eStaffing:TextControl runat="server" ID="txtRepairColumnNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Line Number:</td>
                <td colspan="2"><eStaffing:TextControl runat="server" ID="txtRepairLineNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">National Stock Number:</td>
                <td colspan="2"><eStaffing:TextControl runat="server" ID="txtRepairNationalStockNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Reference Number:</td>
                <td colspan="2"><eStaffing:TextControl runat="server" ID="txtRepairReferenceNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Figure Number:</td>
                <td colspan="2"><eStaffing:TextControl runat="server" ID="txtRepairFigureNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Item Number:</td>
                <td colspan="2"><eStaffing:TextControl runat="server" ID="txtRepairItemNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td colspan="2" class="label left">Total Number of Major Items Supported:</td>
                <td><eStaffing:TextControl runat="server" ID="txtRepairItemCount" Width="100%" /></td>
            </tr>
            <tr>
                <td colspan="3" class="label left">Recommended Action:</td>
            </tr>
            <tr>
                <td colspan="3"><eStaffing:HTMLEditor runat="server" ID="hteRepairRecommendedAction" Height="150" /></td>
            </tr>
        </tbody>
    </table>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnSaveRepair" Text="Save" CssClass="button save" OnClick="btnSaveRepair_Click" />
        <asp:LinkButton runat="server" ID="btnCancelRepair" Text="Cancel" CssClass="button delete" OnClick="btnCancelRepair_Click" />
    </div>
</eStaffing:ModalPopup>
<eStaffing:ModalPopup runat="server" ID="mpDeleteRepairConfirm" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
    <div class="modalPopupTitle">Confirm</div>
    <div>Are you sure you want to delete this repair part change?</div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnDeleteRepairConfirm" Text="OK" CssClass="button ok" OnClick="btnDeleteRepairConfirm_Click" />
        <asp:LinkButton runat="server" ID="btnDeleteRepairCancel" Text="Cancel" CssClass="button delete" OnClick="btnDeleteRepairCancel_Click" />
    </div>
</eStaffing:ModalPopup>