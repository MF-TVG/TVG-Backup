<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tracking.aspx.cs" Inherits="USAACE.eStaffing.Web.Pages.Tracking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Tracking</h1>
    <table class="formTable">
        <colgroup>
            <col style="width: 19em;" />
            <col style="width: 15em;" />
            <col style="width: auto;" />
            <col style="width: 10em;" />
        </colgroup>
        <tbody>
            <tr>
                <td>
                    <span class="label required left">Form Type:</span>
                    (<asp:LinkButton runat="server" ID="lkbSelectAllForms" OnClick="lkbSelectAllForms_Click" Text="All" /> | <asp:LinkButton runat="server" ID="lkbUnselectAllForms" OnClick="lkbUnselectAllForms_Click" Text="None" />)
                </td>
                <td class="label required left">
                    Suspense Date:
                </td>
                <td colspan="2">
                    <span class="label required left">Reviewers:</span>
                    (<asp:LinkButton runat="server" ID="lkbSelectAllUnits" OnClick="lkbSelectAllUnits_Click" Text="All" /> | <asp:LinkButton runat="server" ID="lkbUnselectAllUnits" OnClick="lkbUnselectAllUnits_Click" Text="None" />)
                </td>
            </tr>
            <tr>
                <td rowspan="3">
                    <asp:CheckBoxList runat="server" ID="cklFormTypes" RepeatLayout="UnorderedList" CssClass="reviewerFilter" />
                </td>
                <td>
                    <div><eStaffing:DateControl runat="server" ID="dcStartDate" Width="80" /><span style="margin-left: 1em;">to</span></div>
                    <div style="margin-top: 0.2em;"><eStaffing:DateControl runat="server" ID="dcEndDate" Width="80" /></div>
                </td>
                <td rowspan="3" colspan="2">
                    <asp:CheckBoxList runat="server" ID="cklReviewers" RepeatLayout="UnorderedList" CssClass="reviewerFilter" />
                </td>
            </tr>
            <tr>
                <td class="label required left">
                    Submit Date:
                </td>
            </tr>
            <tr>
                <td>
                    <div><eStaffing:DateControl runat="server" ID="dcSubmitDateStart" Width="80" /><span style="margin-left: 1em;">to</span></div>
                    <div style="margin-top: 0.2em;"><eStaffing:DateControl runat="server" ID="dcSubmitDateEnd" Width="80" /></div>
                </td>
            </tr>
            <tr>
                <td class="label required left">
                    Organization:
                </td>
                <td class="label required left">
                    Subject (Contains):
                </td>
                <td class="label required left">
                    Form Status:
                </td>
                <td rowspan="2" class="middle right">
                    <asp:LinkButton runat="server" ID="btnFilter" Text="Load Chart" CssClass="button refresh" OnClick="btnFilter_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <eStaffing:DropDownControl runat="server" ID="ddlOrganization" AutoPostBack="true" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged" Width="100%" />
                </td>
                <td>
                    <eStaffing:TextControl runat="server" ID="txtSubject" Width="100%" />
                </td>
                <td>
                    <asp:CheckBoxList runat="server" ID="cklFormStatus" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="checkBoxList" />
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Panel runat="server" ID="pnlDashboard" Visible="false" CssClass="marginTop">
        <table class="formGrid border">
            <colgroup>
                <col style="width: 16em;" />
                <col style="width: 8em;" />
                <col style="min-width: 25em;" />
            </colgroup>
            <thead>
                <tr>
                    <th colspan="3" class="left middle">
                        <div class="label left" style="height: 1.8em;"><asp:Image runat="server" ImageUrl="~/images/statusblack.png" /> Queued for Review</div>
                        <div class="label left" style="height: 1.8em;"><asp:Image runat="server" ImageUrl="~/images/statusblue.png" /> For Review</div>
                        <div class="label left" style="height: 1.8em;"><asp:Image runat="server" ImageUrl="~/images/statusamber.png" /> Near Due</div>
                        <div class="label left" style="height: 1.8em;"><asp:Image runat="server" ImageUrl="~/images/statusred.png" /> Past Due</div>
                        <div class="label left" style="height: 1.8em;"><asp:Image runat="server" ImageUrl="~/images/statusgreen.png" /> Completed</div>
                        <div class="label left" style="height: 1.8em;"><asp:Image runat="server" ImageUrl="~/images/statusreject.png" /> Rejected</div>
                    </th>
                    <eStaffing:RepeaterListControl runat="server" ID="dlReviewers" OnItemDataBound="dlReviewers_ItemDataBound">
                        <ItemTemplate>
                            <th rowspan="2" class="bottom left unitHeader">
                                <div class="label">
                                    <asp:Literal runat="server" ID="ltrReviewerName" />
                                </div>
                            </th>
                        </ItemTemplate>
                    </eStaffing:RepeaterListControl>
                    <th rowspan="2" class="scrollCol hidePrint"></th>
                </tr>
                <tr>
                    <th class="label left bottom">Type</th>
                    <th class="label center bottom">Suspense</th>
                    <th class="label left bottom">Subject</th>
                </tr>
            </thead>
        </table>
        <div class="trackingGrid">
            <table class="formGrid border">
                <colgroup>
                    <col style="width: 16em;" />
                    <col style="width: 8em;" />
                    <col style="min-width: 25em;" />
                </colgroup>
                <eStaffing:RepeaterListControl runat="server" ID="dlForms" OnItemDataBound="dlForms_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td class="left"><asp:Literal runat="server" ID="ltrType" /></td>
                            <td class="center"><asp:Literal runat="server" ID="ltrSuspense" /></td>
                            <td class="left"><asp:HyperLink runat="server" ID="lnkSubject" /></td>
                            <eStaffing:RepeaterListControl runat="server" ID="dlFormReviews" OnItemDataBound="dlFormReviews_ItemDataBound">
                                <ItemTemplate>
                                    <td class="top center unitCell"><asp:Image runat="server" ID="imgStatus" Visible="false" /></td>
                                </ItemTemplate>
                            </eStaffing:RepeaterListControl>
                        </tr>
                    </ItemTemplate>
                </eStaffing:RepeaterListControl>
                <tr>
                    <td class="label required center" colspan="3"><asp:Image runat="server" ImageUrl="~/images/statusblack.png" /> Queued for Review</td>
                    <eStaffing:RepeaterListControl runat="server" ID="dlFormCountQueued" OnItemDataBound="dlFormCount_ItemDataBound">
                        <ItemTemplate>
                            <td class="middle center unitCell"><asp:Literal runat="server" ID="ltrCount" /></td>
                        </ItemTemplate>
                    </eStaffing:RepeaterListControl>
                </tr>
                <tr>
                    <td class="label required center" colspan="3"><asp:Image runat="server" ImageUrl="~/images/statusblue.png" /> In Review</td>
                    <eStaffing:RepeaterListControl runat="server" ID="dlFormCountReview" OnItemDataBound="dlFormCount_ItemDataBound">
                        <ItemTemplate>
                            <td class="middle center unitCell"><asp:Literal runat="server" ID="ltrCount" /></td>
                        </ItemTemplate>
                    </eStaffing:RepeaterListControl>
                </tr>
                <tr>
                    <td class="label required center" colspan="3"><asp:Image runat="server" ImageUrl="~/images/statusamber.png" /> Near Due</td>
                    <eStaffing:RepeaterListControl runat="server" ID="dlFormCountNearDue" OnItemDataBound="dlFormCount_ItemDataBound">
                        <ItemTemplate>
                            <td class="middle center unitCell"><asp:Literal runat="server" ID="ltrCount" /></td>
                        </ItemTemplate>
                    </eStaffing:RepeaterListControl>
                </tr>
                <tr>
                    <td class="label required center" colspan="3"><asp:Image runat="server" ImageUrl="~/images/statusred.png" /> Past Due</td>
                    <eStaffing:RepeaterListControl runat="server" ID="dlFormCountPastDue" OnItemDataBound="dlFormCount_ItemDataBound">
                        <ItemTemplate>
                            <td class="middle center unitCell"><asp:Literal runat="server" ID="ltrCount" /></td>
                        </ItemTemplate>
                    </eStaffing:RepeaterListControl>
                </tr>
                <tr>
                    <td class="label required center" colspan="3"><asp:Image runat="server" ImageUrl="~/images/statusgreen.png" /> Completed</td>
                    <eStaffing:RepeaterListControl runat="server" ID="dlFormCountCompleted" OnItemDataBound="dlFormCount_ItemDataBound">
                        <ItemTemplate>
                            <td class="middle center unitCell"><asp:Literal runat="server" ID="ltrCount" /></td>
                        </ItemTemplate>
                    </eStaffing:RepeaterListControl>
                </tr>
                <tr>
                    <td class="label required center" colspan="3"><asp:Image runat="server" ImageUrl="~/images/statusreject.png" /> Rejected</td>
                    <eStaffing:RepeaterListControl runat="server" ID="dlFormCountRejected" OnItemDataBound="dlFormCount_ItemDataBound">
                        <ItemTemplate>
                            <td class="middle center unitCell"><asp:Literal runat="server" ID="ltrCount" /></td>
                        </ItemTemplate>
                    </eStaffing:RepeaterListControl>
                </tr>
                
                <tr>
                    <td class="label required center" colspan="3">Total</td>
                    <eStaffing:RepeaterListControl runat="server" ID="dlFormCountTotal" OnItemDataBound="dlFormCount_ItemDataBound">
                        <ItemTemplate>
                            <td class="middle center unitCell"><asp:Literal runat="server" ID="ltrCount" /></td>
                        </ItemTemplate>
                    </eStaffing:RepeaterListControl>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
