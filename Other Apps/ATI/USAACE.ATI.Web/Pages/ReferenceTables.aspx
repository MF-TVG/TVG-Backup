<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReferenceTables.aspx.cs" Inherits="USAACE.ATI.Web.Pages.ReferenceTables" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Update Reference Tables</h1>
    <table class="formTable">
        <colgroup>
            <col style="width: 25%;" />
            <col style="width: 75%;" />
        </colgroup>
        <tbody>
            <tr>
                <td>
                    <h2 class="formTitle">Choose a Table</h2>
                    <asp:RadioButtonList runat="server" ID="rblReferenceTableList" AutoPostBack="true" OnSelectedIndexChanged="rblReferenceTableList_SelectedIndexChanged" CssClass="radioButtonList" RepeatLayout="Flow">
                        <asp:ListItem Text="Objectives" Value="Objectives" />
                        <asp:ListItem Text="Systems" Value="Systems" />
                        <asp:ListItem Text="Miscellaneous Hours" Value="Miscellaneous Hours" />
                        <asp:ListItem Text="Locations" Value="Locations" />
                        <asp:ListItem Text="Course Levels" Value="Course Levels" />
                        <asp:ListItem Text="Course Types" Value="Course Types" />
                        <asp:ListItem Text="Course Numbers" Value="Course Numbers" />
                        <asp:ListItem Text="No Fly Day Types" Value="No Fly Day Types" />
                        <asp:ListItem Text="No Fly Days" Value="No Fly Days" />
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:MultiView runat="server" ID="mvReferenceTables">
                        <asp:View runat="server" ID="vwObjectives">
                            <h2 class="formTitle">Objectives</h2>
                            <div class="label left required">Select an Objective:</div>
                            <div><ATI:ComboBoxControl runat="server" ID="cmbObjective" Width="300" AutoPostBack="true" OnTextChanged="cmbObjective_TextChanged" /></div>
                            <div>
                                <asp:ValidationSummary runat="server" ID="vsObjective" ValidationGroup="Objective" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
                            </div>
                            <div class="label left required marginTopSmall">
                                Objective Name
                                <asp:RequiredFieldValidator runat="server" ID="rfvObjective" CssClass="validationError" ControlToValidate="txtObjectiveName" ErrorMessage="Objective Name cannot be empty." Text="*" ValidationGroup="Objective" EnableClientScript="false" />
                            </div>
                            <div><ATI:TextControl runat="server" ID="txtObjectiveName" MaxLength="50" Width="300" /></div>
                            <div class="marginTopSmall"><asp:CheckBox runat="server" ID="chkObjectiveNightMission" Text="Night Mission" /></div>
                            <div><asp:CheckBox runat="server" ID="chkObjectiveFlightHours" Text="Flight Hours" /></div>
                            <div><asp:CheckBox runat="server" ID="chkObjectiveSimulatorHours" Text="Simulator Hours" /></div>
                            <div><asp:CheckBox runat="server" ID="chkObjectiveAmmunition" Text="Ammunition" /></div>
                            <div><asp:CheckBox runat="server" ID="chkObjectiveContact" Text="Contact" /></div>
                            <div class="label left marginTopSmall">
                                Color
                                <asp:RegularExpressionValidator runat="server" ID="revObjectiveColor" CssClass="validationError" ControlToValidate="txtObjectiveColor" ValidationExpression="^[A-F0-9]{6}$" ErrorMessage="Color must be in proper format" Text="*" ValidationGroup="Objective" EnableClientScript="false" />
                            </div>
                            <div>
                                <ATI:TextControl runat="server" ID="txtObjectiveColor" MaxLength="6" Width="60" />
                            </div>
                            <div class="right marginTop">
                                <asp:LinkButton runat="server" ID="btnUpdateObjective" Text="Save Objective" OnClick="btnUpdateObjective_Click" CssClass="button save" />
                                <asp:LinkButton runat="server" ID="btnDeleteObjective" Text="Delete Objective" Visible="false" OnClick="btnDeleteObjective_Click" CssClass="button delete" />
                            </div>
                            <ATI:ModalPopup runat="server" ID="mpDeleteObjectiveConfirm" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
                                <div class="modalPopupTitle">Confirm Objective Deletion</div>
                                <div class="label left">Are you sure you want to delete this objective?</div>
                                <div class="right marginTop">
                                    <asp:LinkButton runat="server" ID="btnDeleteObjectiveConfirm" Text="Delete Objective" OnClick="btnDeleteObjectiveConfirm_Click" CssClass="button ok" />
                                    <asp:LinkButton runat="server" ID="btnDeleteObjectiveCancel" Text="Cancel" OnClick="btnDeleteObjectiveCancel_Click" CssClass="button delete" />
                                </div>
                            </ATI:ModalPopup>
                        </asp:View>
                        <asp:View runat="server" ID="vwSystems">
                            <h2 class="formTitle">Systems</h2>
                            <div class="label left required">Select System:</div>
                            <div><ATI:ComboBoxControl runat="server" ID="cmbSystem" Width="300" AutoPostBack="true" OnTextChanged="cmbSystem_TextChanged" /></div>
                            <div>
                                <asp:ValidationSummary runat="server" ID="vsSystem" ValidationGroup="System" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
                            </div>
                            <div class="label left required marginTopSmall">
                                System Name
                                <asp:RequiredFieldValidator runat="server" ID="rfvSystem" CssClass="validationError" ControlToValidate="txtSystem" ErrorMessage="System Name cannot be empty." Text="*" ValidationGroup="System" EnableClientScript="false" />
                            </div>
                            <div><ATI:TextControl runat="server" ID="txtSystem" MaxLength="50" Width="300" /></div>
                            <div class="label left marginTopSmall">System Code</div>
                            <div><ATI:TextControl runat="server" ID="txtSystemCode" MaxLength="5" Width="50" /></div>
                            <div class="label left marginTopSmall">Tied Locations</div>
                            <div style="max-height: 300px; overflow-y: auto; border: 1px solid #000000; display: inline-block; padding: 10px;">
                                <asp:Repeater runat="server" ID="dlSystemLocations" OnItemDataBound="dlSystemLocations_ItemDataBound">
                                    <ItemTemplate>
                                        <div>
                                            <asp:HiddenField runat="server" ID="hdfSystemLocationID" />
                                            <asp:HiddenField runat="server" ID="hdfLocationID" />
                                            <asp:CheckBox runat="server" ID="chkSystemLocation" />
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="right marginTop">
                                <asp:LinkButton runat="server" ID="btnUpdateSystem" Text="Save System" OnClick="btnUpdateSystem_Click" CssClass="button save" />
                                <asp:LinkButton runat="server" ID="btnDeleteSystem" Text="Delete System" Visible="false" OnClick="btnDeleteSystem_Click" CssClass="button delete" />
                            </div>
                            <ATI:ModalPopup runat="server" ID="mpDeleteSystemConfirm" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
                                <div class="modalPopupTitle">Confirm Objective Deletion</div>
                                <div class="label left">Are you sure you want to delete this System?</div>
                                <div class="right marginTop">
                                    <asp:LinkButton runat="server" ID="btnDeleteSystemConfirm" Text="Delete System" OnClick="btnDeleteSystemConfirm_Click" CssClass="button ok" />
                                    <asp:LinkButton runat="server" ID="btnDeleteSystemCancel" Text="Cancel" OnClick="btnDeleteSystemCancel_Click" CssClass="button delete" />
                                </div>
                            </ATI:ModalPopup>
                        </asp:View>
                        <asp:View runat="server" ID="vwMiscHours">
                            <h2 class="formTitle">Miscellaneous Hours</h2>
                            <div class="label left required">Select Miscellaneous Hours Type:</div>
                            <div><ATI:ComboBoxControl runat="server" ID="cmbMiscHours" Width="300" AutoPostBack="true" OnTextChanged="cmbMiscHours_TextChanged" /></div>
                            <div>
                                <asp:ValidationSummary runat="server" ID="vsMiscHours" ValidationGroup="MiscHours" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
                            </div>
                            <div class="label left required marginTopSmall">
                                Miscellaneous Hours Name
                                <asp:RequiredFieldValidator runat="server" ID="rfvMiscHours" CssClass="validationError" ControlToValidate="txtMiscHours" ErrorMessage="Miscellaenous Hours Name cannot be empty." Text="*" ValidationGroup="MiscHours" EnableClientScript="false" />
                            </div>
                            <div><ATI:TextControl runat="server" ID="txtMiscHours" MaxLength="50" Width="300" /></div>
                            <div class="right marginTop">
                                <asp:LinkButton runat="server" ID="btnUpdateMiscHours" Text="Save Miscellaneous Hours" OnClick="btnUpdateMiscHours_Click" CssClass="button save" />
                                <asp:LinkButton runat="server" ID="btnDeleteMiscHours" Text="Delete Miscellaneous Hours" Visible="false" OnClick="btnDeleteMiscHours_Click" CssClass="button delete" />
                            </div>
                            <ATI:ModalPopup runat="server" ID="mpDeleteMiscHoursConfirm" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
                                <div class="modalPopupTitle">Confirm Miscellaneous Hours Deletion</div>
                                <div class="label left">Are you sure you want to delete this Miscellaneous Hours Type?</div>
                                <div class="right marginTop">
                                    <asp:LinkButton runat="server" ID="btnDeleteMiscHoursConfirm" Text="Delete Miscellaneous Hours" OnClick="btnDeleteMiscHoursConfirm_Click" CssClass="button ok" />
                                    <asp:LinkButton runat="server" ID="btnDeleteMiscHoursCancel" Text="Cancel" OnClick="btnDeleteMiscHoursCancel_Click" CssClass="button delete" />
                                </div>
                            </ATI:ModalPopup>
                        </asp:View>
                        <asp:View runat="server" ID="vwLocations">
                            <h2 class="formTitle">Locations</h2>
                            <div class="label left required">Select Location:</div>
                            <div><ATI:ComboBoxControl runat="server" ID="cmbLocation" Width="300" AutoPostBack="true" OnTextChanged="cmbLocation_TextChanged" /></div>
                            <div>
                                <asp:ValidationSummary runat="server" ID="vsLocation" ValidationGroup="Location" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
                            </div>
                            <div class="label left required marginTopSmall">
                                Location Name
                                <asp:RequiredFieldValidator runat="server" ID="rfvLocation" CssClass="validationError" ControlToValidate="txtLocation" ErrorMessage="Location Name cannot be empty." Text="*" ValidationGroup="Location" EnableClientScript="false" />
                            </div>
                            <div><ATI:TextControl runat="server" ID="txtLocation" MaxLength="50" Width="300" /></div>
                            <div class="right marginTop">
                                <asp:LinkButton runat="server" ID="btnUpdateLocation" Text="Save Location" OnClick="btnUpdateLocation_Click" CssClass="button save" />
                                <asp:LinkButton runat="server" ID="btnDeleteLocation" Text="Delete Location" Visible="false" OnClick="btnDeleteLocation_Click" CssClass="button delete" />
                            </div>
                            <ATI:ModalPopup runat="server" ID="mpDeleteLocationConfirm" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
                                <div class="modalPopupTitle">Confirm Location Deletion</div>
                                <div class="label left">Are you sure you want to delete this Location?</div>
                                <div class="right marginTop">
                                    <asp:LinkButton runat="server" ID="btnDeleteLocationConfirm" Text="Delete Location" OnClick="btnDeleteLocationConfirm_Click" CssClass="button save" />
                                    <asp:LinkButton runat="server" ID="btnDeleteLocationCancel" Text="Cancel" OnClick="btnDeleteLocationCancel_Click" CssClass="button delete" />
                                </div>
                            </ATI:ModalPopup>
                        </asp:View>
                        <asp:View runat="server" ID="vwCourseLevels">
                            <h2 class="formTitle">Course Levels</h2>
                            <div class="label left required">Select Course Level:</div>
                            <div><ATI:ComboBoxControl runat="server" ID="cmbCourseLevel" Width="300" AutoPostBack="true" OnTextChanged="cmbCourseLevel_TextChanged" /></div>
                            <div>
                                <asp:ValidationSummary runat="server" ID="vsCourseLevel" ValidationGroup="CourseLevel" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
                            </div>
                            <div class="label left required marginTopSmall">
                                Course Level Name
                                <asp:RequiredFieldValidator runat="server" ID="rfvCourseLevel" CssClass="validationError" ControlToValidate="txtCourseLevel" ErrorMessage="Course Level Name cannot be empty." Text="*" ValidationGroup="CourseLevel" EnableClientScript="false" />
                            </div>
                            <div><ATI:TextControl runat="server" ID="txtCourseLevel" MaxLength="50" Width="300" /></div>
                            <div class="right marginTop">
                                <asp:LinkButton runat="server" ID="btnUpdateCourseLevel" Text="Save Course Level" OnClick="btnUpdateCourseLevel_Click" CssClass="button save" />
                                <asp:LinkButton runat="server" ID="btnDeleteCourseLevel" Text="Delete Course Level" Visible="false" OnClick="btnDeleteCourseLevel_Click" CssClass="button delete" />
                            </div>
                            <ATI:ModalPopup runat="server" ID="mpDeleteCourseLevelConfirm" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
                                <div class="modalPopupTitle">Confirm Course Level Deletion</div>
                                <div class="label left">Are you sure you want to delete this Course Level?</div>
                                <div class="right marginTop">
                                    <asp:LinkButton runat="server" ID="btnDeleteCourseLevelConfirm" Text="Delete Course Level" OnClick="btnDeleteCourseLevelConfirm_Click" CssClass="button ok" />
                                    <asp:LinkButton runat="server" ID="btnDeleteCourseLevelCancel" Text="Cancel" OnClick="btnDeleteCourseLevelCancel_Click" CssClass="button save" />
                                </div>
                            </ATI:ModalPopup>
                        </asp:View>
                        <asp:View runat="server" ID="vwCourseTypes">
                            <h2 class="formTitle">Course Types</h2>
                            <div class="label left required">Select Course Type:</div>
                            <div><ATI:ComboBoxControl runat="server" ID="cmbCourseType" Width="300" AutoPostBack="true" OnTextChanged="cmbCourseType_TextChanged" /></div>
                            <div>
                                <asp:ValidationSummary runat="server" ID="vsCourseType" ValidationGroup="CourseType" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
                            </div>
                            <div class="label left required marginTopSmall">
                                Course Type Name
                                <asp:RequiredFieldValidator runat="server" ID="rfvCourseType" CssClass="validationError" ControlToValidate="txtCourseType" ErrorMessage="Course Type Name cannot be empty." Text="*" ValidationGroup="CourseType" EnableClientScript="false" />
                            </div>
                            <div><ATI:TextControl runat="server" ID="txtCourseType" MaxLength="50" Width="300" /></div>
                            <div class="label left required marginTopSmall">Course Type Code</div>
                            <div><ATI:TextControl runat="server" ID="txtCourseTypeCode" MaxLength="5" Width="50" /></div>
                            <div class="right marginTop">
                                <asp:LinkButton runat="server" ID="btnUpdateCourseType" Text="Save Course Type" OnClick="btnUpdateCourseType_Click" CssClass="button save" />
                                <asp:LinkButton runat="server" ID="btnDeleteCourseType" Text="Delete Course Type" Visible="false" OnClick="btnDeleteCourseType_Click" CssClass="button delete" />
                            </div>
                            <ATI:ModalPopup runat="server" ID="mpDeleteCourseTypeConfirm" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
                                <div class="modalPopupTitle">Confirm Course Type Deletion</div>
                                <div class="label left">Are you sure you want to delete this Course Type?</div>
                                <div class="right marginTop">
                                    <asp:LinkButton runat="server" ID="btnDeleteCourseTypeConfirm" Text="Delete Course Type" OnClick="btnDeleteCourseTypeConfirm_Click" CssClass="button ok" />
                                    <asp:LinkButton runat="server" ID="btnDeleteCourseTypeCancel" Text="Cancel" OnClick="btnDeleteCourseTypeCancel_Click" CssClass="button delete" />
                                </div>
                            </ATI:ModalPopup>
                        </asp:View>
                        <asp:View runat="server" ID="vwCourseNumbers">
                            <h2 class="formTitle">Course Numbers</h2>
                            <div class="label left required">Select Course Number:</div>
                            <div><ATI:ComboBoxControl runat="server" ID="cmbCourseNumber" Width="300" AutoPostBack="true" OnTextChanged="cmbCourseNumber_TextChanged" /></div>
                            <div>
                                <asp:ValidationSummary runat="server" ID="vsCourseNumber" ValidationGroup="CourseNumber" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
                            </div>
                            <div class="label left required marginTopSmall">
                                Course Number
                                <asp:RequiredFieldValidator runat="server" ID="rfvCourseNumber" CssClass="validationError" ControlToValidate="txtCourseNumber" ErrorMessage="Course Number cannot be empty." Text="*" ValidationGroup="CourseNumber" EnableClientScript="false" />
                            </div>
                            <div><ATI:TextControl runat="server" ID="txtCourseNumber" MaxLength="50" Width="300" /></div>
                            <div class="right marginTop">
                                <asp:LinkButton runat="server" ID="btnUpdateCourseNumber" Text="Save Course Number" OnClick="btnUpdateCourseNumber_Click" CssClass="button save" />
                                <asp:LinkButton runat="server" ID="btnDeleteCourseNumber" Text="Delete Course Number" Visible="false" OnClick="btnDeleteCourseNumber_Click" CssClass="button delete" />
                            </div>
                            <h3 class="formTitle">Import Course Numbers</h3>
                            <div><ATI:TextControl runat="server" ID="txtCourseNumberImport" Width="100%" Height="300" TextMode="MultiLine" /></div>
                            <div class="right marginTop">
                                <asp:LinkButton runat="server" ID="btnImportCourseNumber" Text="Import Course Numbers" OnClick="btnImportCourseNumber_Click" CssClass="button import" />
                            </div>
                            <ATI:ModalPopup runat="server" ID="mpDeleteCourseNumberConfirm" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
                                <div class="modalPopupTitle">Confirm Course Number Deletion</div>
                                <div class="label left">Are you sure you want to delete this Course Number?</div>
                                <div class="right marginTop">
                                    <asp:LinkButton runat="server" ID="btnDeleteCourseNumberConfirm" Text="Delete Course Number" OnClick="btnDeleteCourseNumberConfirm_Click" CssClass="button ok" />
                                    <asp:LinkButton runat="server" ID="btnDeleteCourseNumberCancel" Text="Cancel" OnClick="btnDeleteCourseNumberCancel_Click" CssClass="button delete" />
                                </div>
                            </ATI:ModalPopup>
                        </asp:View>
                        <asp:View runat="server" ID="vwNoFlyTypes">
                            <h2 class="formTitle">No Fly Types</h2>
                            <div class="label left required">Select a No Fly Day Type:</div>
                            <div><ATI:ComboBoxControl runat="server" ID="cmbNoFlyType" Width="300" AutoPostBack="true" OnTextChanged="cmbNoFlyType_TextChanged" /></div>
                            <div>
                                <asp:ValidationSummary runat="server" ID="vsNoFlyType" ValidationGroup="NoFlyType" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
                            </div>
                            <div class="label left required marginTopSmall">
                                No Fly Day Type Name
                                <asp:RequiredFieldValidator runat="server" ID="rfvNoFlyType" CssClass="validationError" ControlToValidate="txtNoFlyType" ErrorMessage="No Fly Day Type Name cannot be empty." Text="*" ValidationGroup="NoFlyType" EnableClientScript="false" />
                            </div>
                            <div><ATI:TextControl runat="server" ID="txtNoFlyType" MaxLength="50" Width="300" /></div>
                            <div class="marginTopSmall"><asp:CheckBox runat="server" ID="chkNoFlyGraduation" Text="Affects Graduation Date" /></div>
                            <div class="label left marginTopSmall">
                                Color
                                <asp:RegularExpressionValidator runat="server" ID="revNoFlyTypeColor" CssClass="validationError" ControlToValidate="txtNoFlyColor" ValidationExpression="^[A-F0-9]{6}$" ErrorMessage="Color must be in proper format" Text="*" ValidationGroup="NoFlyType" EnableClientScript="false" />
                            </div>
                            <div>
                                <ATI:TextControl runat="server" ID="txtNoFlyColor" MaxLength="6" Width="60" />
                            </div>
                            <div class="right marginTop">
                                <asp:LinkButton runat="server" ID="btnUpdateNoFlyType" Text="Save No Fly Day Type" OnClick="btnUpdateNoFlyType_Click" CssClass="button save" />
                                <asp:LinkButton runat="server" ID="btnDeleteNoFlyType" Text="Delete No Fly Day Type" Visible="false" OnClick="btnDeleteNoFlyType_Click" CssClass="button delete" />
                            </div>
                            <ATI:ModalPopup runat="server" ID="mpDeleteNoFlyTypeConfirm" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
                                <div class="modalPopupTitle">Confirm No Fly Day Type Deletion</div>
                                <div class="label left">Are you sure you want to delete this No Fly Day Type?</div>
                                <div class="right marginTop">
                                    <asp:LinkButton runat="server" ID="btnDeleteNoFlyTypeConfirm" Text="Delete No Fly Day Type" OnClick="btnDeleteNoFlyTypeConfirm_Click" CssClass="button ok" />
                                    <asp:LinkButton runat="server" ID="btnDeleteNoFlyTypeCancel" Text="Cancel" OnClick="btnDeleteNoFlyTypeCancel_Click" CssClass="button delete" />
                                </div>
                            </ATI:ModalPopup>
                        </asp:View>
                        <asp:View runat="server" ID="vwNoFlyDays">
                            <h2 class="formTitle">No Fly Days</h2>
                            <div class="label left required">Select a No Fly Day:</div>
                            <div><ATI:ComboBoxControl runat="server" ID="cmbNoFlyDay" Width="300" AutoPostBack="true" OnTextChanged="cmbNoFlyDay_TextChanged" /></div>
                            <div>
                                <asp:ValidationSummary runat="server" ID="vsNoFlyDay" ValidationGroup="NoFlyDay" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
                            </div>
                            <div class="label left required marginTopSmall">
                                No Fly Day Name
                                <asp:RequiredFieldValidator runat="server" ID="rfvNoFlyDay" CssClass="validationError" ControlToValidate="txtNoFlyDay" ErrorMessage="No Fly Day Name cannot be empty." Text="*" ValidationGroup="NoFlyDay" EnableClientScript="false" />
                            </div>
                            <div><ATI:TextControl runat="server" ID="txtNoFlyDay" MaxLength="50" Width="300" /></div>
                            <div class="label left marginTopSmall">No Fly Day Type</div>
                            <div><ATI:ComboBoxControl runat="server" ID="cmbNoFlyDayType" Width="300" /></div>
                            <div class="label left marginTopSmall">Day Specification</div>
                            <div>
                                <asp:RadioButtonList runat="server" ID="rblNoFlyDaySpec" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblNoFlyDaySpec_SelectedIndexChanged" CssClass="radioButtonList" RepeatLayout="Flow">
                                    <asp:ListItem Text="Specific Date" Value="Specific" />
                                    <asp:ListItem Text="Date Range" Value="Range" />
                                    <asp:ListItem Text="Floating Date" Value="Relative" />
                                </asp:RadioButtonList>
                            </div>
                            <asp:Panel runat="server" ID="pnlNoFlyStartDate" CssClass="marginTopSmall">
                                <div class="label left">(Start) Date</div>
                                <div>
                                    <ATI:ComboBoxControl runat="server" ID="cmbNoFlyStartDateMonth" Width="150" />
                                    <ATI:ComboBoxControl runat="server" ID="cmbNoFlyStartDateDay" Width="120" />
                                </div>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="pnlNoFlyEndDate" CssClass="marginTopSmall">
                                <div class="label left">End Date</div>
                                <div>
                                    <ATI:ComboBoxControl runat="server" ID="cmbNoFlyEndDateMonth" Width="150" />
                                    <ATI:ComboBoxControl runat="server" ID="cmbNoFlyEndDateDay" Width="120" />
                                </div>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="pnlNoFlyRelativeDate" CssClass="marginTopSmall">
                                <div class="label left">Week Number</div>
                                <div>
                                    <ATI:ComboBoxControl runat="server" ID="cmbNoFlyWeekNumber" Width="300" AutoCompleteMode="SuggestAppend" DropDownStyle="DropDownList">
                                        <asp:ListItem Text="-- Select a Week --" Value="" />
                                        <asp:ListItem Text="1st" Value="1" />
                                        <asp:ListItem Text="2nd" Value="2" />
                                        <asp:ListItem Text="3rd" Value="3" />
                                        <asp:ListItem Text="4th" Value="4" />
                                        <asp:ListItem Text="5th (or Last)" Value="5" />
                                    </ATI:ComboBoxControl>
                                </div>
                                <div class="label left marginTopSmall">Day of Week</div>
                                <div><ATI:ComboBoxControl runat="server" ID="cmbNoFlyWeekDay" Width="300" /></div>
                                <div class="label left marginTopSmall">Month</div>
                                <div><ATI:ComboBoxControl runat="server" ID="cmbNoFlyWeekMonth" Width="300" /></div>
                            </asp:Panel>
                            <div class="marginTopSmall"><asp:CheckBox runat="server" ID="chkMobilizationExempt" Text="This no fly day does not apply to mobilization POIs" /></div>
                            <div class="right marginTop">
                                <asp:LinkButton runat="server" ID="btnUpdateNoFlyDay" Text="Save No Fly Day" OnClick="btnUpdateNoFlyDay_Click" CssClass="button save" />
                                <asp:LinkButton runat="server" ID="btnDeleteNoFlyDay" Text="Delete No Fly Day" Visible="false" OnClick="btnDeleteNoFlyDay_Click" CssClass="button delete" />
                            </div>
                            <ATI:ModalPopup runat="server" ID="mpDeleteNoFlyDayConfirm" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
                                <div class="modalPopupTitle">Confirm No Fly Day Deletion</div>
                                <div class="label left">Are you sure you want to delete this No Fly Day?</div>
                                <div class="right marginTop">
                                    <asp:LinkButton runat="server" ID="btnDeleteNoFlyDayConfirm" Text="Delete No Fly Day" OnClick="btnDeleteNoFlyDayConfirm_Click" CssClass="button save" />
                                    <asp:LinkButton runat="server" ID="btnDeleteNoFlyDayCancel" Text="Cancel" OnClick="btnDeleteNoFlyDayCancel_Click" CssClass="button delete" />
                                </div>
                            </ATI:ModalPopup>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
