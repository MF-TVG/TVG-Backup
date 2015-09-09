using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.eStaffing.Business.Enums;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Presenters.Pages;
using USAACE.eStaffing.Presentation.Views.Pages;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web.Pages
{
    public partial class Search : BasePage, ISearchView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private SearchPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public SearchPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new SearchPresenter(this);
                }

                return _presenter;
            }
        }

        protected override void LoadPage()
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

        protected void lkbSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.Search();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dlFormList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is Form)
                {
                    Form form = e.Item.DataItem as Form;

                    Nullable<DateTime> suspenseDate = form.SuspenseDate;
                    String status = form.ExtendedProperties.Status;

                    (e.Item.FindControl("imgHighPriority") as Image).Style[HtmlTextWriterStyle.Visibility] = form.HighPriority == true ? "visible" : "hidden";
                    (e.Item.FindControl("imgStatus") as Image).ImageUrl = ImageUtil.GetColorCode((StatusType)form.ExtendedProperties.StatusType);

                    HyperLink lnkFormTitle = e.Item.FindControl("lnkFormTitle") as HyperLink;
                    lnkFormTitle.Text = !String.IsNullOrEmpty(form.Subject) ? form.Subject : "{No Subject}";
                    lnkFormTitle.NavigateUrl = NavigateUtil.GetFormLink(form);

                    (e.Item.FindControl("ltrFormType") as Literal).Text = form.ExtendedProperties.FormTypeName;
                    (e.Item.FindControl("ltrSubmitDate") as Literal).Text = form.SubmitDate.HasValue ? form.SubmitDate.Value.ToShortDateString() : null;
                    (e.Item.FindControl("ltrSuspenseDate") as Literal).Text = suspenseDate.HasValue ? suspenseDate.Value.ToShortDateString() : null;
                    (e.Item.FindControl("ltrStatus") as Literal).Text = status;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        public String SearchTerm
        {
            get
            {
                return txtSearchTerm.Text;
            }
        }

        public IList<Form> Forms
        {
            set
            {
                dlFormList.DataSource = value;
                dlFormList.DataBind();
            }
        }
    }
}