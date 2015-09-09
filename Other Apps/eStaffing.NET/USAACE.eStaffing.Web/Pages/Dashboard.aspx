<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="USAACE.eStaffing.Web.Pages.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">My Dashboard</h1>
    <asp:Panel runat="server" ID="pnlFilter">
        <table class="formTable">
            <colgroup>
                <col style="width: 18em;" />
                <col style="width: auto;" />
                <col style="width: 13em;" />
                <col style="width: 8em;" />
            </colgroup>
            <tr>
                <td class="label required">Show Forms with Status:</td>
                <td><eStaffing:CheckBoxListControl runat="server" ID="cklFormStatus" CssClass="checkBoxList" RepeatLayout="Flow" RepeatDirection="Horizontal" /></td>
                <td class="label left middle" rowspan="2"><asp:CheckBox runat="server" ID="chkMyReviewOnly" Text="Show Forms for My Review Only" Checked="true" /></td>
                <td class="right middle" rowspan="2"><asp:LinkButton runat="server" ID="btnFormSearch" CssClass="button search" Text="Search" OnClick="btnFormSearch_Click" /></td>
            </tr>
            <tr>
                <td class="label required">Subject (Contains):</td>
                <td><eStaffing:TextControl runat="server" ID="txtFormSubject" Width="95%" /></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlSubmitted" CssClass="marginTop">
        <table class="formGridLegend">
            <colgroup>
                <col style="width: auto;" />
                <col style="width: 12em;" />
                <col style="width: 9em;" />
                <col style="width: 9em;" />
                <col style="width: 9em;" />
                <col style="width: 9em;" />
                <col style="width: 9em;" />
            </colgroup>
            <thead>
                <tr>
                    <th class="left">Submitted eStaffings</th>
                    <th>
                        <asp:Image runat="server" ID="imgSubmitNone" ImageUrl="~/images/statusblack.png" /> Not Submitted
                    </th>
                    <th>
                        <asp:Image runat="server" ID="imgSubmitReject" ImageUrl="~/images/statusreject.png" /> Rejected
                    </th>
                    <th>
                        <asp:Image runat="server" ID="imgSubmitBlue" ImageUrl="~/images/statusblue.png" /> In Review
                    </th>
                    <th>
                        <asp:Image runat="server" ID="imgSubmitAmber" ImageUrl="~/images/statusamber.png" /> Near Due
                    </th>
                    <th>
                        <asp:Image runat="server" ID="imgSubmitRed" ImageUrl="~/images/statusred.png" /> Past Due
                    </th>
                    <th>
                        <asp:Image runat="server" ID="imgSubmitGreen" ImageUrl="~/images/statusgreen.png" /> Completed
                    </th>
                </tr>
            </thead>
        </table>
        <table class="formGrid">
            <colgroup>
                <col style="width: 5em;" />
                <col style="width: 16em;" />
                <col style="width: 12em;" />
                <col style="width: auto;" />
                <col style="width: 10em;" />
                <col style="width: 10em;" />
                <col style="width: 10em;" />
                <col style="width: 16em;" />
                <col class="hidePrint scrollCol" />
            </colgroup>
            <thead>
                <tr runat="server" id="trSubmitHeaders">
                    <th></th>
                    <th class="left">
                        <asp:LinkButton runat="server" ID="lkbSubmitTypeHeader" Text="Type" OnCommand="lkbHeader_Command" CommandArgument="Type" />
                        <asp:Image runat="server" ID="imgSubmitTypeAsc" ImageUrl="~/images/sort.gif" Visible="false" />
                        <asp:Image runat="server" ID="imgSubmitTypeDesc" ImageUrl="~/images/rsort.gif" Visible="false" />
                    </th>
                    <th class="center">
                        <asp:LinkButton runat="server" ID="lkbSubmitFormNumberHeader" Text="Form Number" OnCommand="lkbHeader_Command" CommandArgument="FormNumber" />
                        <asp:Image runat="server" ID="imgSubmitFormNumberAsc" ImageUrl="~/images/sort.gif" Visible="false" />
                        <asp:Image runat="server" ID="imgSubmitFormNumberDesc" ImageUrl="~/images/rsort.gif" Visible="false" />
                    </th>
                    <th class="left">
                        <asp:LinkButton runat="server" ID="lkbSubmitSubjectHeader" Text="Subject" OnCommand="lkbHeader_Command" CommandArgument="Subject" />
                        <asp:Image runat="server" ID="imgSubmitSubjectAsc" ImageUrl="~/images/sort.gif" Visible="false" />
                        <asp:Image runat="server" ID="imgSubmitSubjectDesc" ImageUrl="~/images/rsort.gif" Visible="false" />
                    </th>
                    <th>
                        <asp:LinkButton runat="server" ID="lkbSubmitSubmitDateHeader" Text="Submit Date" OnCommand="lkbHeader_Command" CommandArgument="SubmitDate" />
                        <asp:Image runat="server" ID="imgSubmitSubmitDateAsc" ImageUrl="~/images/sort.gif" Visible="false" />
                        <asp:Image runat="server" ID="imgSubmitSubmitDateDesc" ImageUrl="~/images/rsort.gif" Visible="false" />
                    </th>
                    <th>
                        <asp:LinkButton runat="server" ID="lkbSubmitSuspenseHeader" Text="Suspense" OnCommand="lkbHeader_Command" CommandArgument="Suspense" />
                        <asp:Image runat="server" ID="imgSubmitSuspenseAsc" ImageUrl="~/images/sort.gif" Visible="false" />
                        <asp:Image runat="server" ID="imgSubmitSuspenseDesc" ImageUrl="~/images/rsort.gif" Visible="false" />
                    </th>
                    <th>
                        <asp:LinkButton runat="server" ID="lkbSubmitLastActionHeader" Text="Last Action" OnCommand="lkbHeader_Command" CommandArgument="LastAction" />
                        <asp:Image runat="server" ID="imgSubmitLastActionAsc" ImageUrl="~/images/sort.gif" Visible="false" />
                        <asp:Image runat="server" ID="imgSubmitLastActionDesc" ImageUrl="~/images/rsort.gif" Visible="false" />
                    </th>
                    <th>
                        <asp:LinkButton runat="server" ID="lkbSubmitStatusHeader" Text="Status" OnCommand="lkbHeader_Command" CommandArgument="Status" />
                        <asp:Image runat="server" ID="imgSubmitStatusAsc" ImageUrl="~/images/sort.gif" Visible="false" />
                        <asp:Image runat="server" ID="imgSubmitStatusDesc" ImageUrl="~/images/rsort.gif" Visible="false" />
                    </th>
                    <th class="hidePrint"></th>
                </tr>
            </thead>
        </table>
        <div class="scrollGrid largeGrid">
            <table class="formGrid">
                <colgroup>
                    <col style="width: 5em;" />
                    <col style="width: 16em;" />
                    <col style="width: 12em;" />
                    <col style="width: auto;" />
                    <col style="width: 10em;" />
                    <col style="width: 10em;" />
                    <col style="width: 10em;" />
                    <col style="width: 16em;" />
                </colgroup>
                <tbody>
            <eStaffing:RepeaterListControl runat="server" ID="dlSubmittedList" OnItemDataBound="dlFormList_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td class="left top">
                            <asp:Image runat="server" ID="imgHighPriority" ImageUrl="~/images/exclaim.gif" /> <asp:Image runat="server" ID="imgStatus" />
                        </td>
                        <td class="left"><asp:Literal runat="server" ID="ltrFormType" /></td>
                        <td class="center"><asp:Literal runat="server" ID="ltrFormNumber" /></td>
                        <td class="left"><asp:HyperLink runat="server" ID="lnkFormTitle" Target="_blank" /></td>
                        <td><asp:Literal runat="server" ID="ltrSubmitDate" /></td>
                        <td><asp:Literal runat="server" ID="ltrSuspenseDate" /></td>
                        <td><asp:Literal runat="server" ID="ltrLastActionDate" /></td>
                        <td><asp:Literal runat="server" ID="ltrStatus" /></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <tr>
                        <td class="left" colspan="7">There are no eStaffing packets submitted by you that match the current filters.</td>
                    </tr>
                </EmptyDataTemplate>
            </eStaffing:RepeaterListControl>
                </tbody>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlForReview" CssClass="marginTop">
        <table class="formGridLegend">
            <colgroup>
                <col style="width: auto;" />
                <col style="width: 9em;" />
                <col style="width: 9em;" />
                <col style="width: 9em;" />
                <col style="width: 9em;" />
            </colgroup>
            <thead>
                <tr>
                    <th class="left">
                        eStaffings for Review
                    </th>
                    <th>
                        <asp:Image runat="server" ID="imgReviewBlue" ImageUrl="~/images/statusblue.png" /> In Review
                    </th>
                    <th>
                        <asp:Image runat="server" ID="imgReviewAmber" ImageUrl="~/images/statusamber.png" /> Near Due
                    </th>
                    <th>
                        <asp:Image runat="server" ID="imgReviewRed" ImageUrl="~/images/statusred.png" /> Past Due
                    </th>
                    <th>
                        <asp:Image runat="server" ID="imgReviewGreen" ImageUrl="~/images/statusgreen.png" /> Completed
                    </th>
                </tr>
            </thead>
        </table>
        <table class="formGrid">
            <colgroup>
                <col style="width: 5em;" />
                <col style="width: 16em;" />
                <col style="width: 12em;" />
                <col style="width: auto;" />
                <col style="width: 10em;" />
                <col style="width: 10em;" />
                <col style="width: 10em;" />
                <col style="width: 16em;" />
                <col class="hidePrint scrollCol" />
            </colgroup>
            <thead>
                <tr runat="server" id="trReviewHeaders">
                    <th></th>
                    <th class="left">
                        <asp:LinkButton runat="server" ID="lkbReviewTypeHeader" Text="Type" OnCommand="lkbHeader_Command" CommandArgument="Type" />
                        <asp:Image runat="server" ID="imgReviewTypeAsc" ImageUrl="~/images/sort.gif" Visible="false" />
                        <asp:Image runat="server" ID="imgReviewTypeDesc" ImageUrl="~/images/rsort.gif" Visible="false" />
                    </th>
                    <th class="center">
                        <asp:LinkButton runat="server" ID="lkbReviewFormNumberHeader" Text="Form Number" OnCommand="lkbHeader_Command" CommandArgument="FormNumber" />
                        <asp:Image runat="server" ID="imgReviewFormNumberAsc" ImageUrl="~/images/sort.gif" Visible="false" />
                        <asp:Image runat="server" ID="imgReviewFormNumberDesc" ImageUrl="~/images/rsort.gif" Visible="false" />
                    </th>
                    <th class="left">
                        <asp:LinkButton runat="server" ID="lkbReviewSubjectHeader" Text="Subject" OnCommand="lkbHeader_Command" CommandArgument="Subject" />
                        <asp:Image runat="server" ID="imgReviewSubjectAsc" ImageUrl="~/images/sort.gif" Visible="false" />
                        <asp:Image runat="server" ID="imgReviewSubjectDesc" ImageUrl="~/images/rsort.gif" Visible="false" />
                    </th>
                    <th>
                        <asp:LinkButton runat="server" ID="lkbReviewSubmitDateHeader" Text="Submit Date" OnCommand="lkbHeader_Command" CommandArgument="SubmitDate" />
                        <asp:Image runat="server" ID="imgReviewSubmitDateAsc" ImageUrl="~/images/sort.gif" Visible="false" />
                        <asp:Image runat="server" ID="imgReviewSubmitDateDesc" ImageUrl="~/images/rsort.gif" Visible="false" />
                    </th>
                    <th>
                        <asp:LinkButton runat="server" ID="lkbReviewSuspenseHeader" Text="Suspense" OnCommand="lkbHeader_Command" CommandArgument="Suspense" />
                        <asp:Image runat="server" ID="imgReviewSuspenseAsc" ImageUrl="~/images/sort.gif" Visible="false" />
                        <asp:Image runat="server" ID="imgReviewSuspenseDesc" ImageUrl="~/images/rsort.gif" Visible="false" />
                    </th>
                    <th>
                        <asp:LinkButton runat="server" ID="lkbReviewLastActionHeader" Text="Last Action" OnCommand="lkbHeader_Command" CommandArgument="LastAction" />
                        <asp:Image runat="server" ID="imgReviewLastActionAsc" ImageUrl="~/images/sort.gif" Visible="false" />
                        <asp:Image runat="server" ID="imgReviewLastActionDesc" ImageUrl="~/images/rsort.gif" Visible="false" />
                    </th>
                    <th>
                        <asp:LinkButton runat="server" ID="lkbReviewStatusHeader" Text="Status" OnCommand="lkbHeader_Command" CommandArgument="Status" />
                        <asp:Image runat="server" ID="imgReviewStatusAsc" ImageUrl="~/images/sort.gif" Visible="false" />
                        <asp:Image runat="server" ID="imgReviewStatusDesc" ImageUrl="~/images/rsort.gif" Visible="false" />
                    </th>
                    <th class="hidePrint"></th>
                </tr>
            </thead>
        </table>
        <div class="scrollGrid largeGrid">
            <table class="formGrid">
                <colgroup>
                    <col style="width: 5em;" />
                    <col style="width: 16em;" />
                    <col style="width: 12em;" />
                    <col style="width: auto;" />
                    <col style="width: 10em;" />
                    <col style="width: 10em;" />
                    <col style="width: 10em;" />
                    <col style="width: 16em;" />
                </colgroup>
                <tbody>
                    <eStaffing:RepeaterListControl runat="server" ID="dlReviewList" OnItemDataBound="dlFormList_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td class="left top">
                                    <asp:Image runat="server" ID="imgHighPriority" ImageUrl="~/images/exclaim.gif" /> <asp:Image runat="server" ID="imgStatus" />
                                </td>
                                <td class="left"><asp:Literal runat="server" ID="ltrFormType" /></td>
                                <td class="center"><asp:Literal runat="server" ID="ltrFormNumber" /></td>
                                <td class="left"><asp:HyperLink runat="server" ID="lnkFormTitle" Target="_blank" /></td>
                                <td><asp:Literal runat="server" ID="ltrSubmitDate" /></td>
                                <td><asp:Literal runat="server" ID="ltrSuspenseDate" /></td>
                                <td><asp:Literal runat="server" ID="ltrLastActionDate" /></td>
                                <td><asp:Literal runat="server" ID="ltrStatus" /></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td class="left" colspan="7">There are no eStaffing packets for your review that match the current filters.</td>
                            </tr>
                        </EmptyDataTemplate>
                    </eStaffing:RepeaterListControl>
                </tbody>
            </table>
        </div>
    </asp:Panel>
</asp:Content>