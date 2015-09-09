using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.FormEntities;
using USAACE.eStaffing.Domain.LookupEntities;
using USAACE.eStaffing.Presentation.Presenters.Controls.Forms;
using USAACE.eStaffing.Presentation.Views.Controls.Forms;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web.Controls.Forms
{
    public partial class Form2028Sheet : FormControl, IForm2028SheetView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private Form2028SheetPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public Form2028SheetPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new Form2028SheetPresenter(this);
                }

                return _presenter;
            }
        }

        protected override void LoadForm()
        {
            Presenter.LoadLookups();
            Presenter.Load();
        }

        protected override void SaveForm()
        {
            Presenter.Save();
        }

        protected override void SaveDefault()
        {
            Presenter.SaveDefault();
        }

        protected void ddlCourseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadCourses();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void ddlCourseNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadSelectedCourse();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dlPublicationChanges_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is PublicationChange)
                {
                    PublicationChange change = e.Item.DataItem as PublicationChange;

                    (e.Item.FindControl("ltrItem") as Literal).Text = (e.Item.ItemIndex + 1).ToString();
                    (e.Item.FindControl("ltrPageNumber") as Literal).Text = change.PageNumber;
                    (e.Item.FindControl("ltrParagraph") as Literal).Text = change.Paragraph;
                    (e.Item.FindControl("ltrLineNumber") as Literal).Text = change.LineNumber;
                    (e.Item.FindControl("ltrFigureNumber") as Literal).Text = change.FigureNumber;
                    (e.Item.FindControl("ltrTableNumber") as Literal).Text = change.TableNumber;
                    (e.Item.FindControl("ltrRecommendedChanges") as Literal).Text = change.RecommendedChanges;
                    (e.Item.FindControl("imbEditPublicationChange") as ImageButton).CommandArgument = change.ListIndex.ToString();
                    (e.Item.FindControl("imbDeletePublicationChange") as ImageButton).CommandArgument = change.ListIndex.ToString();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbEditPublicationChange_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedPublicationChange = e.CommandArgument.ToStringSafe().ToNullable<Int32>();
                Presenter.LoadPublicationChange();
                mpEditPublication.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbDeletePublicationChange_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedPublicationChange = e.CommandArgument.ToStringSafe().ToNullable<Int32>();
                mpDeletePublicationConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnAddPublicationChange_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedPublicationChange = null;
                Presenter.LoadPublicationChange();
                mpEditPublication.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSavePublication_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SavePublicationChange();
                mpEditPublication.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelPublication_Click(object sender, EventArgs e)
        {
            try
            {
                mpEditPublication.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeletePublicationConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeletePublicationChange();
                mpDeletePublicationConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeletePublicationCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeletePublicationConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dlRepairChanges_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is RepairPartChange)
                {
                    RepairPartChange change = e.Item.DataItem as RepairPartChange;

                    (e.Item.FindControl("ltrItem") as Literal).Text = (e.Item.ItemIndex + 1).ToString();
                    (e.Item.FindControl("ltrPageNumber") as Literal).Text = change.PageNumber;
                    (e.Item.FindControl("ltrColumnNumber") as Literal).Text = change.ColumnNumber;
                    (e.Item.FindControl("ltrLineNumber") as Literal).Text = change.LineNumber;
                    (e.Item.FindControl("ltrNationalStockNumber") as Literal).Text = change.NationalStockNumber;
                    (e.Item.FindControl("ltrReferenceNumber") as Literal).Text = change.ReferenceNumber;
                    (e.Item.FindControl("ltrFigureNumber") as Literal).Text = change.FigureNumber;
                    (e.Item.FindControl("ltrItemNumber") as Literal).Text = change.ItemNumber;
                    (e.Item.FindControl("ltrItemCount") as Literal).Text = change.ItemCount;
                    (e.Item.FindControl("ltrRecommendedAction") as Literal).Text = change.RecommendedChanges;
                    (e.Item.FindControl("imbEditRepairChange") as ImageButton).CommandArgument = change.ListIndex.ToString();
                    (e.Item.FindControl("imbDeleteRepairChange") as ImageButton).CommandArgument = change.ListIndex.ToString();
                }

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbEditRepairChange_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedRepairChange = e.CommandArgument.ToStringSafe().ToNullable<Int32>();
                Presenter.LoadRepairChange();
                mpEditRepair.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbDeleteRepairChange_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedRepairChange = e.CommandArgument.ToStringSafe().ToNullable<Int32>();
                mpDeleteRepairConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnAddRepairChange_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedRepairChange = null;
                Presenter.LoadRepairChange();
                mpEditRepair.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveRepair_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SaveRepairChange();
                mpEditRepair.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelRepair_Click(object sender, EventArgs e)
        {
            try
            {
                mpEditRepair.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteRepairConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteRepairChange();
                mpDeleteRepairConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteRepairCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteRepairConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        public String LessonID
        {
            get
            {
                return txtLessonID.Text;
            }
            set
            {
                txtLessonID.Text = value;
            }
        }

        public String LessonVersion
        {
            get
            {
                return txtLessonVersion.Text;
            }
            set
            {
                txtLessonVersion.Text = value;
            }
        }

        public String SelectedCourseType
        {
            get
            {
                return ddlCourseType.SelectedValue;
            }
            set
            {
                ddlCourseType.SelectedValue = value;
            }
        }

        public IList<Form2028CourseType> CourseTypes
        {
            set
            {
                ddlCourseType.Items.Clear();

                ddlCourseType.Items.Add(String.Empty);

                foreach (Form2028CourseType courseType in value)
                {
                    ddlCourseType.Items.Add(new ListItem(courseType.CourseTypeName, courseType.CourseTypeName));
                }
            }
        }

        public String SelectedCourseNumber
        {
            get
            {
                return ddlCourseNumber.SelectedValue;
            }
            set
            {
                ddlCourseNumber.SelectedValue = value;
            }
        }

        public IList<Form2028Course> CourseNumbers
        {
            set
            {
                ddlCourseNumber.Items.Clear();

                ddlCourseNumber.Items.Add(String.Empty);

                foreach (Form2028Course course in value)
                {
                    ddlCourseNumber.Items.Add(new ListItem(course.CourseNumber, course.CourseNumber));
                }
            }
        }

        public String CourseTitle
        {
            set
            {
                ltrCourseTitle.Text = value;
            }
        }

        public IList<PublicationChange> PublicationChanges
        {
            get
            {
                return this.ViewState["PublicationChanges"] as IList<PublicationChange>;
            }
            set
            {
                this.ViewState["PublicationChanges"] = value;

                dlPublicationChanges.DataSource = value;
                dlPublicationChanges.DataBind();
            }
        }

        public Nullable<Int32> SelectedPublicationChange
        {
            get
            {
                return this.ViewState["SelectedPublicationChange"] as Nullable<Int32>;
            }
            set
            {
                this.ViewState["SelectedPublicationChange"] = value;
            }
        }

        public IList<RepairPartChange> RepairChanges
        {
            get
            {
                return this.ViewState["RepairChanges"] as IList<RepairPartChange>;
            }
            set
            {
                this.ViewState["RepairChanges"] = value;

                dlRepairChanges.DataSource = value;
                dlRepairChanges.DataBind();
            }
        }

        public Nullable<Int32> SelectedRepairChange
        {
            get
            {
                return this.ViewState["SelectedRepairChange"] as Nullable<Int32>;
            }
            set
            {
                this.ViewState["SelectedRepairChange"] = value;
            }
        }

        public String Remarks
        {
            get
            {
                return hteRemarks.Text;
            }
            set
            {
                hteRemarks.Text = value;
            }
        }

        public String SubmitterName
        {
            get
            {
                return txtSubmitterName.Text;
            }
            set
            {
                txtSubmitterName.Text = value;
            }
        }

        public String PhoneNumber
        {
            get
            {
                return txtPhoneNumber.Text;
            }
            set
            {
                txtPhoneNumber.Text = value;
            }
        }

        public String PublicationPageNumber
        {
            get
            {
                return txtPublicationPageNumber.Text;
            }
            set
            {
                txtPublicationPageNumber.Text = value;
            }
        }

        public String PublicationParagraph
        {
            get
            {
                return txtPublicationParagraph.Text;
            }
            set
            {
                txtPublicationParagraph.Text = value;
            }
        }

        public String PublicationLineNumber
        {
            get
            {
                return txtPublicationLineNumber.Text;
            }
            set
            {
                txtPublicationLineNumber.Text = value;
            }
        }

        public String PublicationFigureNumber
        {
            get
            {
                return txtPublicationFigureNumber.Text;
            }
            set
            {
                txtPublicationFigureNumber.Text = value;
            }
        }

        public String PublicationTableNumber
        {
            get
            {
                return txtPublicationTableNumber.Text;
            }
            set
            {
                txtPublicationTableNumber.Text = value;
            }
        }

        public String PublicationRecommendedChanges
        {
            get
            {
                return htePublicationRecommendedChanges.Text;
            }
            set
            {
                htePublicationRecommendedChanges.Text = value;
            }
        }

        public String RepairPageNumber
        {
            get
            {
                return txtRepairPageNumber.Text;
            }
            set
            {
                txtRepairPageNumber.Text = value;
            }
        }

        public String RepairColumnNumber
        {
            get
            {
                return txtRepairColumnNumber.Text;
            }
            set
            {
                txtRepairColumnNumber.Text = value;
            }
        }

        public String RepairLineNumber
        {
            get
            {
                return txtRepairLineNumber.Text;
            }
            set
            {
                txtRepairLineNumber.Text = value;
            }
        }

        public String RepairNationalStockNumber
        {
            get
            {
                return txtRepairNationalStockNumber.Text;
            }
            set
            {
                txtRepairNationalStockNumber.Text = value;
            }
        }

        public String RepairReferenceNumber
        {
            get
            {
                return txtRepairReferenceNumber.Text;
            }
            set
            {
                txtRepairReferenceNumber.Text = value;
            }
        }

        public String RepairFigureNumber
        {
            get
            {
                return txtRepairFigureNumber.Text;
            }
            set
            {
                txtRepairFigureNumber.Text = value;
            }
        }

        public String RepairItemNumber
        {
            get
            {
                return txtRepairItemNumber.Text;
            }
            set
            {
                txtRepairItemNumber.Text = value;
            }
        }

        public String RepairItemCount
        {
            get
            {
                return txtRepairItemCount.Text;
            }
            set
            {
                txtRepairItemCount.Text = value;
            }
        }

        public String RepairRecommendedAction
        {
            get
            {
                return hteRepairRecommendedAction.Text;
            }
            set
            {
                hteRepairRecommendedAction.Text = value;
            }
        }

        internal override void SetEnabledState(Boolean enabled)
        {
            txtLessonID.Enabled = enabled;
            txtLessonVersion.Enabled = enabled;
            ddlCourseType.Enabled = enabled;
            ddlCourseNumber.Enabled = enabled;

            dlPublicationChanges.Enabled = enabled;
            btnAddPublicationChange.Visible = enabled;

            dlRepairChanges.Enabled = enabled;
            btnAddRepairChange.Enabled = enabled;

            hteRemarks.Enabled = enabled;
            txtSubmitterName.Enabled = enabled;
            txtPhoneNumber.Enabled = enabled;
        }
    }
}