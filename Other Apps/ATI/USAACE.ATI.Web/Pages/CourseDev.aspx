<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CourseDev.aspx.cs" Inherits="USAACE.ATI.Web.Pages.CourseDev" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Build / Update Course</h1>
    <div>
        <asp:ValidationSummary runat="server" ID="vsCourse" ValidationGroup="Course" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
        <asp:CustomValidator runat="server" ID="cvCourse" ErrorMessage="Program, POI, System, Course Level, Course Name, and Interval are required." ValidationGroup="Course" CssClass="validationError" Display="None" OnServerValidate="cvCourse_ServerValidate" EnableClientScript="false" />
    </div>
    <table class="formTable">
        <colgroup>
            <col style="width: 40%;" />
            <col style="width: 40%;" />
            <col style="width: 20%;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label left required">Select a Program:</td>
                <td class="label left required">Select a Course:</td>
                <td rowspan="2" class="middle"><asp:LinkButton runat="server" ID="btnCreateCourseCopy" Text="Create a Copy" OnClick="btnCreateCourseCopy_Click" Visible="false" CssClass="button copy" /></td>
            </tr>
            <tr>
                <td><ATI:ComboBoxControl runat="server" ID="cmbProgram" Width="250" AutoPostBack="true" OnTextChanged="cmbProgram_TextChanged" /></td>
                <td><ATI:ComboBoxControl runat="server" ID="cmbCourse" Width="250" AutoPostBack="true" OnTextChanged="cmbCourse_TextChanged" /></td>
            </tr>
            <tr>
                <td class="label left">Course Number</td>
                <td class="label left required">Choose Existing System</td>
                <td rowspan="6">
                    <h3 class="formTitle">Class Size</h3>
                    <table class="formTable">
                        <colgroup>
                            <col style="width: 60%;" />
                            <col style="width: 40%;" />
                        </colgroup>
                        <tbody>
                            <tr>
                                <td class="label left">Minimum:</td>
                                <td><ATI:NumericControl runat="server" ID="ncClassSizeMinimum" Width="30" MaxLength="4" Mask="9999" /></td>
                            </tr>
                            <tr>
                                <td class="label left">Optimum:</td>
                                <td><ATI:NumericControl runat="server" ID="ncClassSizeOptimum" Width="30" MaxLength="4" Mask="9999" /></td>
                            </tr>
                            <tr>
                                <td class="label left">Maximum:</td>
                                <td><ATI:NumericControl runat="server" ID="ncClassSizeMaximum" Width="30" MaxLength="4" Mask="9999" /></td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td><ATI:ComboBoxControl runat="server" ID="cmbCourseNumber" Width="250" /></td>
                <td><ATI:ComboBoxControl runat="server" ID="cmbSystem" Width="250" /></td>
            </tr>
            <tr>
                <td class="label left required">Course Name</td>
                <td class="label left required">Choose Default POI</td>
            </tr>
            <tr>
                <td><ATI:TextControl runat="server" ID="txtCourseName" Width="250" /></td>
                <td><ATI:ComboBoxControl runat="server" ID="cmbPOI" Width="250" AutoPostBack="true" OnTextChanged="cmbPOI_TextChanged" /></td>
            </tr>
            <tr>
                <td class="label left required">Class Interval</td>
                <td class="label left">Course Type</td>
            </tr>
            <tr>
                <td><ATI:NumericControl runat="server" ID="ncClassInterval" Width="30" MaxLength="4" Mask="9999" /></td>
                <td><ATI:ComboBoxControl runat="server" ID="cmbCourseType" Width="250" /></td>
            </tr>
            <tr>
                <td class="label left">Phase</td>
                <td class="label left required">Course Level</td>
                <td rowspan="4">
                    <h3 class="formTitle">Course Length</h3>
                    <table class="formTable">
                        <colgroup>
                            <col style="width: 60%;" />
                            <col style="width: 40%;" />
                        </colgroup>
                        <tbody>
                            <tr>
                                <td class="label left">Weeks:</td>
                                <td class="center"><asp:Literal runat="server" ID="ltrCourseLengthWeeks" /></td>
                            </tr>
                            <tr>
                                <td class="label left">Days:</td>
                                <td class="center"><asp:Literal runat="server" ID="ltrCourseLengthDays" /></td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td><ATI:TextControl runat="server" ID="txtPhase" Width="100" /></td>
                <td><ATI:ComboBoxControl runat="server" ID="cmbCourseLevel" Width="250" /></td>
            </tr>
            <tr>
                <td class="label left">Prefix</td>
                <td rowspan="2"><asp:Label runat="server" ID="lblCarryOver" Text="* - This Course is a carry over Course and cannot be edited directly" Visible="false" /></td>
            </tr>
            <tr>
                <td><ATI:TextControl runat="server" ID="txtPrefix" Width="100" /></td>
            </tr>
            <tr>
                <td><asp:CheckBox runat="server" ID="chkTrainNoFlyDays" Text="This course can train on No Fly Days" /></td>
                <td><asp:CheckBox runat="server" ID="chkReportNoFlyDays" Text="This course can report on No Fly Days" /></td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
        </tbody>
    </table>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnCreateCourse" Text="Create Course" OnClick="btnUpdateCourse_Click" CssClass="button save" />
        <asp:LinkButton runat="server" ID="btnUpdateCourse" Text="Update Course" OnClick="btnUpdateCourse_Click" Visible="false" CssClass="button save"  />
        <asp:LinkButton runat="server" ID="btnDeleteCourse" Text="Delete Course" OnClick="btnDeleteCourse_Click" Visible="false" CssClass="button delete"  />
    </div>
    <ATI:ModalPopup runat="server" ID="mpCopyCourse" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
        <div class="modalPopupTitle">Copy Course</div>
        <div class="label left required">Designator/Name of New Course</div>
        <div><asp:TextBox runat="server" ID="txtCopyCourseName" Width="300" MaxLength="50" /></div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnCopyCourseConfirm" Text="Copy Course" OnClick="btnCopyCourseConfirm_Click" CssClass="button ok" />
            <asp:LinkButton runat="server" ID="btnCopyCourseCancel" Text="Cancel" OnClick="btnCopyCourseCancel_Click" CssClass="button delete" />
        </div>
    </ATI:ModalPopup>
    <ATI:ModalPopup runat="server" ID="mpConfirmDeleteCourse" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
        <div class="modalPopupTitle">Confirm</div>
        <div class="label left">Are you sure you want to delete this course?  All associated classes will be deleted as well.</div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnDeleteCourseConfirm" Text="Delete Course" OnClick="btnDeleteCourseConfirm_Click" CssClass="button ok" />
            <asp:LinkButton runat="server" ID="btnDeleteCourseCancel" Text="Cancel" OnClick="btnDeleteCourseCancel_Click" CssClass="button delete" />
        </div>
    </ATI:ModalPopup>
</asp:Content>
