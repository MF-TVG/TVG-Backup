using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.ATI.Business.Constants;
using USAACE.ATI.Domain.Entities;
using USAACE.ATI.Presentation.Presenters.Pages;
using USAACE.ATI.Presentation.Views.Pages;
using USAACE.ATI.Web.Enum;
using USAACE.ATI.Web.Util;
using USAACE.Common;

namespace USAACE.ATI.Web.Pages
{
    public partial class ReferenceTables : BasePage, IReferenceTablesView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private ReferenceTablesPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public ReferenceTablesPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new ReferenceTablesPresenter(this);
                }

                return _presenter;
            }
        }

        /// <summary>
        /// Loads the control
        /// </summary>
        protected override void LoadPage()
        {
            try
            {
                if (!IsPostBack)
                {
                    Presenter.Load();

                    DateSelectorUtil.BindMonths(cmbNoFlyStartDateMonth, "-- Select a Month --");
                    DateSelectorUtil.BindMonths(cmbNoFlyEndDateMonth, "-- Select a Month --");
                    DateSelectorUtil.BindMonths(cmbNoFlyWeekMonth, "-- Select a Month --");
                    DateSelectorUtil.BindDays(cmbNoFlyStartDateDay, "-- Select a Day --");
                    DateSelectorUtil.BindDays(cmbNoFlyEndDateDay, "-- Select a Day --");
                    DateSelectorUtil.BindWeekdays(cmbNoFlyWeekDay, "-- Select a Day of Week --");
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Reference Table selection changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void rblReferenceTableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.Load();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the objective text changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void cmbObjective_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadObjective();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Update Objective button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnUpdateObjective_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("Objective");

                if (Page.IsValid)
                {
                    Presenter.SaveObjective();
                    this.ShowNotice(MessageConstants.REF_OBJECTIVE_SAVE_SUCCESS, NoticeType.Information);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Objective button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteObjective_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteObjectiveConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Objective Confirmation button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteObjectiveConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteObjective();
                this.ShowNotice(MessageConstants.REF_OBJECTIVE_DELETE_SUCCESS, NoticeType.Information);
                mpDeleteObjectiveConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Objective Cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteObjectiveCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteObjectiveConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the system text changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void cmbSystem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadSystem();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when an item is bound to the system locations data list
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The data list item arguments of the event</param>
        protected void dlSystemLocations_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is Location)
                {
                    Location location = e.Item.DataItem as Location;

                    (e.Item.FindControl("hdfLocationID") as HiddenField).Value = location.LocationID.ToStringSafe();
                    (e.Item.FindControl("chkSystemLocation") as CheckBox).Text = location.LocationName;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Update System button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnUpdateSystem_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("System");

                if (Page.IsValid)
                {
                    Presenter.SaveSystem();
                    this.ShowNotice(MessageConstants.REF_SYSTEM_SAVE_SUCCESS, NoticeType.Information);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete System button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteSystem_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteSystemConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete System Confirmation button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteSystemConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteSystem();
                this.ShowNotice(MessageConstants.REF_SYSTEM_DELETE_SUCCESS, NoticeType.Information);
                mpDeleteSystemConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete System Cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteSystemCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteSystemConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the misc hours text changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void cmbMiscHours_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadMiscHours();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Update Misc Hours button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnUpdateMiscHours_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("MiscHours");

                if (Page.IsValid)
                {
                    Presenter.SaveMiscHours();
                    this.ShowNotice(MessageConstants.REF_MISC_HOURS_SAVE_SUCCESS, NoticeType.Information);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Misc Hours button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteMiscHours_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteMiscHoursConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Misc Hours Confirmation button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteMiscHoursConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteMiscHours();
                this.ShowNotice(MessageConstants.REF_MISC_HOURS_DELETE_SUCCESS, NoticeType.Information);
                mpDeleteMiscHoursConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Misc Hours Cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteMiscHoursCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteMiscHoursConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the location text changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void cmbLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadLocation();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Update Location button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnUpdateLocation_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("Location");

                if (Page.IsValid)
                {
                    Presenter.SaveLocation();
                    this.ShowNotice(MessageConstants.REF_LOCATION_SAVE_SUCCESS, NoticeType.Information);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Location button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteLocation_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteLocationConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Location Confirmation button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteLocationConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteLocation();
                this.ShowNotice(MessageConstants.REF_LOCATION_DELETE_SUCCESS, NoticeType.Information);
                mpDeleteLocationConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Location Cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteLocationCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteLocationConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the course level text changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void cmbCourseLevel_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadCourseLevel();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Update Course Level button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnUpdateCourseLevel_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("CourseLevel");

                if (Page.IsValid)
                {
                    Presenter.SaveCourseLevel();
                    this.ShowNotice(MessageConstants.REF_COURSE_LEVEL_SAVE_SUCCESS, NoticeType.Information);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Course Level button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteCourseLevel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteCourseLevelConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Course Level Confirmation button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteCourseLevelConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteCourseLevel();
                this.ShowNotice(MessageConstants.REF_COURSE_LEVEL_DELETE_SUCCESS, NoticeType.Information);
                mpDeleteCourseLevelConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Course Level Cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteCourseLevelCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteCourseLevelConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the course type text changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void cmbCourseType_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadCourseType();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Update Course Type button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnUpdateCourseType_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("CourseType");

                if (Page.IsValid)
                {
                    Presenter.SaveCourseType();
                    this.ShowNotice(MessageConstants.REF_COURSE_TYPE_SAVE_SUCCESS, NoticeType.Information);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Course Type button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteCourseType_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteCourseTypeConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Course Type Confirmation button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteCourseTypeConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteCourseType();
                this.ShowNotice(MessageConstants.REF_COURSE_TYPE_DELETE_SUCCESS, NoticeType.Information);
                mpDeleteCourseTypeConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Course Type Cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteCourseTypeCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteCourseTypeConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the course number text changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void cmbCourseNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadCourseNumber();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Update Course Number button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnUpdateCourseNumber_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("CourseNumber");

                if (Page.IsValid)
                {
                    Presenter.SaveCourseNumber();
                    this.ShowNotice(MessageConstants.REF_COURSE_NUMBER_SAVE_SUCCESS, NoticeType.Information);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Course Number button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteCourseNumber_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteCourseNumberConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Course Number Confirmation button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteCourseNumberConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteCourseNumber();
                this.ShowNotice(MessageConstants.REF_COURSE_NUMBER_DELETE_SUCCESS, NoticeType.Information);
                mpDeleteCourseNumberConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Course Number Cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteCourseNumberCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteCourseNumberConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Import Course Numbers button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnImportCourseNumber_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.ImportCourseNumber();
                this.ShowNotice(MessageConstants.REF_COURSE_NUMBER_IMPORT_SUCCESS, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the no fly type text changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void cmbNoFlyType_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadNoFlyType();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Update No Fly Type button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnUpdateNoFlyType_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("NoFlyType");

                if (Page.IsValid)
                {
                    Presenter.SaveNoFlyType();
                    this.ShowNotice(MessageConstants.REF_NO_FLY_TYPE_SAVE_SUCCESS, NoticeType.Information);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete No Fly Type button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteNoFlyType_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteNoFlyTypeConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete No Fly Type Confirmation button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteNoFlyTypeConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteNoFlyType();
                this.ShowNotice(MessageConstants.REF_NO_FLY_TYPE_DELETE_SUCCESS, NoticeType.Information);
                mpDeleteNoFlyTypeConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete No Fly Type Cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteNoFlyTypeCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteNoFlyTypeConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the no fly day text changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void cmbNoFlyDay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadNoFlyDay();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Update No Fly Day button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnUpdateNoFlyDay_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("NoFlyDay");

                if (Page.IsValid)
                {
                    Presenter.SaveNoFlyDay();
                    this.ShowNotice(MessageConstants.REF_NO_FLY_DAY_SAVE_SUCCESS, NoticeType.Information);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete No Fly Day button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteNoFlyDay_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteNoFlyDayConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete No Fly Day Confirmation button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteNoFlyDayConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteNoFlyDay();
                this.ShowNotice(MessageConstants.REF_NO_FLY_DAY_DELETE_SUCCESS, NoticeType.Information);
                mpDeleteNoFlyDayConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete No Fly Day Cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteNoFlyDayCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteNoFlyDayConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the no fly type specification selection changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void rblNoFlyDaySpec_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.SetNoFlyDaySpecification();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// The value for whether to show the objectives section
        /// </summary>
        public Boolean IsObjectivesVisible
        {
            get
            {
                return mvReferenceTables.ActiveViewIndex == 0;
            }
            set
            {
                if (value)
                {
                    mvReferenceTables.ActiveViewIndex = 0;
                }
            }
        }

        /// <summary>
        /// The value for whether to show the systems section
        /// </summary>
        public Boolean IsSystemsVisible
        {
            get
            {
                return mvReferenceTables.ActiveViewIndex == 1;
            }
            set
            {
                if (value)
                {
                    mvReferenceTables.ActiveViewIndex = 1;
                }
            }
        }

        /// <summary>
        /// The value for whether to show the miscellaneous hours section
        /// </summary>
        public Boolean IsMiscHoursVisible
        {
            get
            {
                return mvReferenceTables.ActiveViewIndex == 2;
            }
            set
            {
                if (value)
                {
                    mvReferenceTables.ActiveViewIndex = 2;
                }
            }
        }

        /// <summary>
        /// The value for whether to show the locations section
        /// </summary>
        public Boolean IsLocationsVisible
        {
            get
            {
                return mvReferenceTables.ActiveViewIndex == 3;
            }
            set
            {
                if (value)
                {
                    mvReferenceTables.ActiveViewIndex = 3;
                }
            }
        }

        /// <summary>
        /// The value for whether to show the course levels section
        /// </summary>
        public Boolean IsCourseLevelsVisible
        {
            get
            {
                return mvReferenceTables.ActiveViewIndex == 4;
            }
            set
            {
                if (value)
                {
                    mvReferenceTables.ActiveViewIndex = 4;
                }
            }
        }

        /// <summary>
        /// The value for whether to show the course types section
        /// </summary>
        public Boolean IsCourseTypesVisible
        {
            get
            {
                return mvReferenceTables.ActiveViewIndex == 5;
            }
            set
            {
                if (value)
                {
                    mvReferenceTables.ActiveViewIndex = 5;
                }
            }
        }

        /// <summary>
        /// The value for whether to show the course numbers section
        /// </summary>
        public Boolean IsCourseNumbersVisible
        {
            get
            {
                return mvReferenceTables.ActiveViewIndex == 6;
            }
            set
            {
                if (value)
                {
                    mvReferenceTables.ActiveViewIndex = 6;
                }
            }
        }

        /// <summary>
        /// The value for whether to show the no fly types section
        /// </summary>
        public Boolean IsNoFlyTypesVisible
        {
            get
            {
                return mvReferenceTables.ActiveViewIndex == 7;
            }
            set
            {
                if (value)
                {
                    mvReferenceTables.ActiveViewIndex = 7;
                }
            }
        }

        /// <summary>
        /// The value for whether to show the no fly days section
        /// </summary>
        public Boolean IsNoFlyDaysVisible
        {
            get
            {
                return mvReferenceTables.ActiveViewIndex == 8;
            }
            set
            {
                if (value)
                {
                    mvReferenceTables.ActiveViewIndex = 8;
                }
            }
        }

        /// <summary>
        /// The value for the selected section
        /// </summary>
        public String SelectedTable
        {
            get
            {
                return rblReferenceTableList.SelectedItem != null ? rblReferenceTableList.SelectedItem.Text : null;
            }
        }

        /// <summary>
        /// The list of objectives
        /// </summary>
        public IList<Objective> Objectives
        {
            set
            {
                cmbObjective.Items.Clear();

                cmbObjective.Items.Add(new ListItem("-- New Objective --", String.Empty));

                foreach (Objective objective in value)
                {
                    cmbObjective.Items.Add(new ListItem(objective.ObjectiveName, objective.ObjectiveID.ToString()));
                }

                cmbObjective.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected objective
        /// </summary>
        public Nullable<Int32> ObjectiveID
        {
            get
            {
                return cmbObjective.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbObjective.SelectedValue = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The value for the objective name
        /// </summary>
        public String ObjectiveName
        {
            get
            {
                return txtObjectiveName.Text;
            }
            set
            {
                txtObjectiveName.Text = value;
            }
        }

        /// <summary>
        /// The value for objective night mission status
        /// </summary>
        public Nullable<Boolean> ObjectiveNightMission
        {
            get
            {
                return chkObjectiveNightMission.Checked;
            }
            set
            {
                chkObjectiveNightMission.Checked = value == true;
            }
        }

        /// <summary>
        /// The value for objective flight hours status
        /// </summary>
        public Nullable<Boolean> ObjectiveFlightHours
        {
            get
            {
                return chkObjectiveFlightHours.Checked;
            }
            set
            {
                chkObjectiveFlightHours.Checked = value == true;
            }
        }

        /// <summary>
        /// The value for objective simulator hours status
        /// </summary>
        public Nullable<Boolean> ObjectiveSimulatorHours
        {
            get
            {
                return chkObjectiveSimulatorHours.Checked;
            }
            set
            {
                chkObjectiveSimulatorHours.Checked = value == true;
            }
        }

        /// <summary>
        /// The value for objective ammunition status
        /// </summary>
        public Nullable<Boolean> ObjectiveAmmunition
        {
            get
            {
                return chkObjectiveAmmunition.Checked;
            }
            set
            {
                chkObjectiveAmmunition.Checked = value == true;
            }
        }

        /// <summary>
        /// The value for objective contact status
        /// </summary>
        public Nullable<Boolean> ObjectiveContact
        {
            get
            {
                return chkObjectiveContact.Checked;
            }
            set
            {
                chkObjectiveContact.Checked = value == true;
            }
        }

        /// <summary>
        /// The value for the objective color
        /// </summary>
        public String ObjectiveColor
        {
            get
            {
                return txtObjectiveColor.Text;
            }
            set
            {
                txtObjectiveColor.Text = value;
            }
        }

        /// <summary>
        /// The calculated value for whether this is a new objective
        /// </summary>
        public Boolean IsNewObjective
        {
            set
            {
                btnDeleteObjective.Visible = !value;
            }
        }

        /// <summary>
        /// The list of miscellaneous hours
        /// </summary>
        public IList<MiscHours> MiscHours
        {
            set
            {
                cmbMiscHours.Items.Clear();

                cmbMiscHours.Items.Add(new ListItem("-- New Misc Hours --", String.Empty));

                foreach (MiscHours miscHour in value)
                {
                    cmbMiscHours.Items.Add(new ListItem(miscHour.MiscHoursName, miscHour.MiscHoursID.ToString()));
                }

                cmbMiscHours.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected miscellaneous hours
        /// </summary>
        public Nullable<Int32> MiscHoursID
        {
            get
            {
                return cmbMiscHours.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbMiscHours.SelectedValue = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The value for miscellaneous hours name
        /// </summary>
        public String MiscHoursName
        {
            get
            {
                return txtMiscHours.Text;
            }
            set
            {
                txtMiscHours.Text = value;
            }
        }

        /// <summary>
        /// The calculated value for whether this is a new miscellaneous hours
        /// </summary>
        public Boolean IsNewMiscHours
        {
            set
            {
                btnDeleteMiscHours.Visible = !value;
            }
        }

        /// <summary>
        /// The list of locations
        /// </summary>
        public IList<Location> Locations
        {
            set
            {
                cmbLocation.Items.Clear();

                cmbLocation.Items.Add(new ListItem("-- New Location --", String.Empty));

                foreach (Location location in value)
                {
                    cmbLocation.Items.Add(new ListItem(location.LocationName, location.LocationID.ToString()));
                }

                cmbLocation.SelectedIndex = 0;

                dlSystemLocations.DataSource = value;
                dlSystemLocations.DataBind();
            }
        }

        /// <summary>
        /// The ID of the currently selected location
        /// </summary>
        public Nullable<Int32> LocationID
        {
            get
            {
                return cmbLocation.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbLocation.SelectedValue = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The value for the location name
        /// </summary>
        public String LocationName
        {
            get
            {
                return txtLocation.Text;
            }
            set
            {
                txtLocation.Text = value;
            }
        }

        /// <summary>
        /// The calculated value for whether this is a new location
        /// </summary>
        public Boolean IsNewLocation
        {
            set
            {
                btnDeleteLocation.Visible = !value;
            }
        }

        /// <summary>
        /// The list of systems
        /// </summary>
        public IList<USAACE.ATI.Domain.Entities.System> Systems
        {
            set
            {
                cmbSystem.Items.Clear();

                cmbSystem.Items.Add(new ListItem("-- New System --", String.Empty));

                foreach (USAACE.ATI.Domain.Entities.System system in value)
                {
                    cmbSystem.Items.Add(new ListItem(system.SystemName, system.SystemID.ToString()));
                }

                cmbSystem.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected system
        /// </summary>
        public Nullable<Int32> SystemID
        {
            get
            {
                return cmbSystem.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbSystem.SelectedValue = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The value for the system name
        /// </summary>
        public String SystemName
        {
            get
            {
                return txtSystem.Text;
            }
            set
            {
                txtSystem.Text = value;
            }
        }

        /// <summary>
        /// The value for the system code used for overall ADP code
        /// </summary>
        public String SystemCode
        {
            get
            {
                return txtSystemCode.Text;
            }
            set
            {
                txtSystemCode.Text = value;
            }
        }

        /// <summary>
        /// The current list of system locations
        /// </summary>
        public IList<SystemLocation> SystemLocations
        {
            get
            {
                IList<SystemLocation> systemLocations = new List<SystemLocation>();

                foreach (DataListItem item in dlSystemLocations.Items)
                {
                    if ((item.FindControl("chkSystemLocation") as CheckBox).Checked)
                    {
                        SystemLocation location = new SystemLocation();

                        location.SystemLocationID = (item.FindControl("hdfSystemLocationID") as HiddenField).Value.ToNullable<Int32>();
                        location.LocationID = (item.FindControl("hdfLocationID") as HiddenField).Value.ToNullable<Int32>();

                        systemLocations.Add(location);
                    }
                }

                return systemLocations;
            }
            set
            {
                foreach (RepeaterItem item in dlSystemLocations.Items)
                {
                    (item.FindControl("chkSystemLocation") as CheckBox).Checked = false;
                    (item.FindControl("hdfSystemLocationID") as HiddenField).Value = null;
                }

                if (value != null)
                {
                    foreach (SystemLocation location in value)
                    {
                        RepeaterItem item = dlSystemLocations.Items.Cast<RepeaterItem>().FirstOrDefault(x => (x.FindControl("hdfLocationID") as HiddenField).Value.ToNullable<Int32>() == location.LocationID);

                        if (item != null)
                        {
                            (item.FindControl("chkSystemLocation") as CheckBox).Checked = true;
                            (item.FindControl("hdfSystemLocationID") as HiddenField).Value = location.SystemLocationID.ToStringSafe();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The calculated value for whether this is a new system
        /// </summary>
        public Boolean IsNewSystem
        {
            set
            {
                btnDeleteSystem.Visible = !value;
            }
        }

        /// <summary>
        /// The list of course levels
        /// </summary>
        public IList<CourseLevel> CourseLevels
        {
            set
            {
                cmbCourseLevel.Items.Clear();

                cmbCourseLevel.Items.Add(new ListItem("-- New Course Level --", String.Empty));

                foreach (CourseLevel courseLevel in value)
                {
                    cmbCourseLevel.Items.Add(new ListItem(courseLevel.CourseLevelName, courseLevel.CourseLevelID.ToString()));
                }

                cmbCourseLevel.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected course level
        /// </summary>
        public Nullable<Int32> CourseLevelID
        {
            get
            {
                return cmbCourseLevel.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbCourseLevel.SelectedValue = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The value for the course level name
        /// </summary>
        public String CourseLevelName
        {
            get
            {
                return txtCourseLevel.Text;
            }
            set
            {
                txtCourseLevel.Text = value;
            }
        }

        /// <summary>
        /// The calculated value for whether this is a new course level
        /// </summary>
        public Boolean IsNewCourseLevel
        {
            set
            {
                btnDeleteCourseLevel.Visible = !value;
            }
        }

        /// <summary>
        /// The list of course types
        /// </summary>
        public IList<CourseType> CourseTypes
        {
            set
            {
                cmbCourseType.Items.Clear();

                cmbCourseType.Items.Add(new ListItem("-- New Course Type --", String.Empty));

                foreach (CourseType courseType in value)
                {
                    cmbCourseType.Items.Add(new ListItem(courseType.CourseTypeName, courseType.CourseTypeID.ToString()));
                }

                cmbCourseType.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected course type
        /// </summary>
        public Nullable<Int32> CourseTypeID
        {
            get
            {
                return cmbCourseType.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbCourseType.SelectedValue = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The value for the course type name
        /// </summary>
        public String CourseTypeName
        {
            get
            {
                return txtCourseType.Text;
            }
            set
            {
                txtCourseType.Text = value;
            }
        }

        /// <summary>
        /// The value for the course type code used for overall ADP code
        /// </summary>
        public String CourseTypeCode
        {
            get
            {
                return txtCourseTypeCode.Text;
            }
            set
            {
                txtCourseTypeCode.Text = value;
            }
        }

        /// <summary>
        /// The calculated value for whether this is a new course type
        /// </summary>
        public Boolean IsNewCourseType
        {
            set
            {
                btnDeleteCourseType.Visible = !value;
            }
        }

        /// <summary>
        /// The list of course numbers
        /// </summary>
        public IList<CourseNumber> CourseNumbers
        {
            set
            {
                cmbCourseNumber.Items.Clear();

                cmbCourseNumber.Items.Add(new ListItem("-- New Course Number --", String.Empty));

                foreach (CourseNumber courseNumber in value)
                {
                    cmbCourseNumber.Items.Add(new ListItem(courseNumber.CourseNumberName, courseNumber.CourseNumberID.ToString()));
                }

                cmbCourseNumber.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected course number
        /// </summary>
        public Nullable<Int32> CourseNumberID
        {
            get
            {
                return cmbCourseNumber.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbCourseNumber.SelectedValue = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The value for the course number name
        /// </summary>
        public String CourseNumberName
        {
            get
            {
                return txtCourseNumber.Text;
            }
            set
            {
                txtCourseNumber.Text = value;
            }
        }

        /// <summary>
        /// The calculated value for whether this is a new course number
        /// </summary>
        public Boolean IsNewCourseNumber
        {
            set
            {
                btnDeleteCourseNumber.Visible = !value;
            }
        }

        /// <summary>
        /// The value for the course number import data
        /// </summary>
        public String CourseNumberImport
        {
            get
            {
                return txtCourseNumberImport.Text;
            }
            set
            {
                txtCourseNumberImport.Text = value;
            }
        }

        /// <summary>
        /// The list of no fly types
        /// </summary>
        public IList<NoFlyType> NoFlyTypes
        {
            set
            {
                cmbNoFlyType.Items.Clear();

                cmbNoFlyType.Items.Add(new ListItem("-- New No Fly Day Type --", String.Empty));

                foreach (NoFlyType type in value)
                {
                    cmbNoFlyType.Items.Add(new ListItem(type.NoFlyTypeName, type.NoFlyTypeID.ToString()));
                }

                cmbNoFlyType.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected no fly type
        /// </summary>
        public Nullable<Int32> NoFlyTypeID
        {
            get
            {
                return cmbNoFlyType.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbNoFlyType.SelectedValue = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The value for the no fly type name
        /// </summary>
        public String NoFlyTypeName
        {
            get
            {
                return txtNoFlyType.Text;
            }
            set
            {
                txtNoFlyType.Text = value;
            }
        }

        /// <summary>
        /// The value for the no fly type color
        /// </summary>
        public String NoFlyTypeColor
        {
            get
            {
                return txtNoFlyColor.Text;
            }
            set
            {
                txtNoFlyColor.Text = value;
            }
        }

        /// <summary>
        /// The value for whether the no fly type affects graduation dates
        /// </summary>
        public Nullable<Boolean> NoFlyTypeGraduationAffect
        {
            get
            {
                return chkNoFlyGraduation.Checked;
            }
            set
            {
                chkNoFlyGraduation.Checked = value == true;
            }
        }

        /// <summary>
        /// The calculated value for whether this is a new no fly type
        /// </summary>
        public Boolean IsNewNoFlyType
        {
            set
            {
                btnDeleteNoFlyType.Visible = !value;
            }
        }

        /// <summary>
        /// The list of no fly days
        /// </summary>
        public IList<NoFlyDay> NoFlyDays
        {
            set
            {
                cmbNoFlyDay.Items.Clear();

                cmbNoFlyDay.Items.Add(new ListItem("-- New No Fly Day --", String.Empty));

                foreach (NoFlyDay day in value)
                {
                    cmbNoFlyDay.Items.Add(new ListItem(day.NoFlyDayName, day.NoFlyDayID.ToString()));
                }

                cmbNoFlyDay.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected no fly day
        /// </summary>
        public Nullable<Int32> NoFlyDayID
        {
            get
            {
                return cmbNoFlyDay.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbNoFlyDay.SelectedValue = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The value for the no fly day name
        /// </summary>
        public String NoFlyDayName
        {
            get
            {
                return txtNoFlyDay.Text;
            }
            set
            {
                txtNoFlyDay.Text = value;
            }
        }

        /// <summary>
        /// The list of no fly types for no fly days
        /// </summary>
        public IList<NoFlyType> NoFlyDayTypes
        {
            set
            {
                cmbNoFlyDayType.Items.Clear();

                cmbNoFlyDayType.Items.Add(new ListItem("-- Select No Fly Day Type --", String.Empty));

                foreach (NoFlyType type in value)
                {
                    cmbNoFlyDayType.Items.Add(new ListItem(type.NoFlyTypeName, type.NoFlyTypeID.ToString()));
                }

                cmbNoFlyDayType.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected no fly day type
        /// </summary>
        public Nullable<Int32> NoFlyDayTypeID
        {
            get
            {
                return cmbNoFlyDayType.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbNoFlyDayType.SelectedValue = value.ToStringSafe(String.Empty);
            }
        }

        /// <summary>
        /// The specification type for the no fly day
        /// </summary>
        public String NoFlyDaySpecification
        {
            get
            {
                return rblNoFlyDaySpec.SelectedValue;
            }
            set
            {
                rblNoFlyDaySpec.SelectedValue = value;
            }
        }

        /// <summary>
        /// The calculated value for whether the no fly day start date should be visible
        /// </summary>
        public Boolean IsNoFlyDayStartDateVisible
        {
            set
            {
                pnlNoFlyStartDate.Visible = value;
            }
        }

        /// <summary>
        /// The calculated value for whether the no fly day end date should be visible
        /// </summary>
        public Boolean IsNoFlyDayEndDateVisible
        {
            set
            {
                pnlNoFlyEndDate.Visible = value;
            }
        }

        /// <summary>
        /// The calculated value for whether the no fly day relative date should be visible
        /// </summary>
        public Boolean IsNoFlyDayRelativeDateVisible
        {
            set
            {
                pnlNoFlyRelativeDate.Visible = value;
            }
        }

        /// <summary>
        /// The value for the no fly day start date month
        /// </summary>
        public Nullable<Byte> NoFlyStartDateMonth
        {
            get
            {
                return cmbNoFlyStartDateMonth.SelectedValue.ToNullable<Byte>();
            }
            set
            {
                cmbNoFlyStartDateMonth.SelectedValue = value.ToStringSafe(String.Empty);
            }
        }

        /// <summary>
        /// The value for the no fly day start date day
        /// </summary>
        public Nullable<Byte> NoFlyStartDateDay
        {
            get
            {
                return cmbNoFlyStartDateDay.SelectedValue.ToNullable<Byte>();
            }
            set
            {
                cmbNoFlyStartDateDay.SelectedValue = value.ToStringSafe(String.Empty);
            }
        }

        /// <summary>
        /// The value for the no fly day end date month
        /// </summary>
        public Nullable<Byte> NoFlyEndDateMonth
        {
            get
            {
                return cmbNoFlyEndDateMonth.SelectedValue.ToNullable<Byte>();
            }
            set
            {
                cmbNoFlyEndDateMonth.SelectedValue = value.ToStringSafe(String.Empty);
            }
        }

        /// <summary>
        /// The value for the no fly day end date day
        /// </summary>
        public Nullable<Byte> NoFlyEndDateDay
        {
            get
            {
                return cmbNoFlyEndDateDay.SelectedValue.ToNullable<Byte>();
            }
            set
            {
                cmbNoFlyEndDateDay.SelectedValue = value.ToStringSafe(String.Empty);
            }
        }

        /// <summary>
        /// The value for the no fly day day of week
        /// </summary>
        public Nullable<Byte> NoFlyWeekDay
        {
            get
            {
                return cmbNoFlyWeekDay.SelectedValue.ToNullable<Byte>();
            }
            set
            {
                cmbNoFlyWeekDay.SelectedValue = value.ToStringSafe(String.Empty);
            }
        }

        /// <summary>
        /// The value for the no fly day week number
        /// </summary>
        public Nullable<Byte> NoFlyWeekCount
        {
            get
            {
                return cmbNoFlyWeekNumber.SelectedValue.ToNullable<Byte>();
            }
            set
            {
                cmbNoFlyWeekNumber.SelectedValue = value.ToStringSafe(String.Empty);
            }
        }

        /// <summary>
        /// The value for the no fly day relative month
        /// </summary>
        public Nullable<Byte> NoFlyWeekMonth
        {
            get
            {
                return cmbNoFlyWeekMonth.SelectedValue.ToNullable<Byte>();
            }
            set
            {
                cmbNoFlyWeekMonth.SelectedValue = value.ToStringSafe(String.Empty);
            }
        }

        /// <summary>
        /// The value for whether the no fly day is mobilization exempt
        /// </summary>
        public Nullable<Boolean> NoFlyMobilizationExempt
        {
            get
            {
                return chkMobilizationExempt.Checked;
            }
            set
            {
                chkMobilizationExempt.Checked = value == true;
            }
        }

        /// <summary>
        /// The calculated value for whether this is a new no fly day
        /// </summary>
        public Boolean IsNewNoFlyDay
        {
            set
            {
                btnDeleteNoFlyDay.Visible = !value;
            }
        }
    }
}