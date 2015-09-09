using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
    public partial class Actions : BasePage, IActionsView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private ActionsPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public ActionsPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new ActionsPresenter(this);
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
            catch (Exception)
            {

            }
        }

        protected void dlForms_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                Form form = e.Item.DataItem as Form;

                Nullable<DateTime> suspenseDate = form.SuspenseDate;

                (e.Item.FindControl("imgHighPriority") as Image).Style[HtmlTextWriterStyle.Visibility] = form.HighPriority == true ? "visible" : "hidden";
                (e.Item.FindControl("imgStatus") as Image).ImageUrl = ImageUtil.GetColorCode((StatusType)form.ExtendedProperties.StatusType);

                HyperLink lnkFormTitle = e.Item.FindControl("lnkFormTitle") as HyperLink;
                lnkFormTitle.Text = String.Format("{0} (Due: {1})", form.Subject, form.SuspenseDate.HasValue ? form.SuspenseDate.Value.ToShortDateString() : "No Suspense");
                lnkFormTitle.NavigateUrl = NavigateUtil.GetFormLink(form);
            }
            catch (Exception)
            {

            }
        }

        public IList<Form> ReviewForms
        {
            set
            {
                dlForms.DataSource = value;
                dlForms.DataBind();
            }
        }
    }
}