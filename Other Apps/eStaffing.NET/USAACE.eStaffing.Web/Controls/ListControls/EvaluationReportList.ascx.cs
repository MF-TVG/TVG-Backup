using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using USAACE.eStaffing.Business.Enums;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.FormEntities;
using USAACE.eStaffing.Presentation.Presenters.Controls.ListControls;
using USAACE.eStaffing.Presentation.Views.Controls.ListControls;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web.Controls.ListControls
{
    public partial class EvaluationReportList : FormListControl, IEvaluationReportListView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private EvaluationReportListPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public EvaluationReportListPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new EvaluationReportListPresenter(this);
                }

                return _presenter;
            }
        }

        protected void dlFormList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is Form)
                {
                    Form form = e.Item.DataItem as Form;
                    EvaluationReport evaluation = form.ExtendedProperties.FormData as EvaluationReport;

                    (e.Item.FindControl("lnkEdit") as HyperLink).NavigateUrl = NavigateUtil.GetFormLink(form);

                    (e.Item.FindControl("ltrFormNumber") as Literal).Text = form.FormNumber;
                    (e.Item.FindControl("ltrRatee") as Literal).Text = evaluation.Ratee;
                    (e.Item.FindControl("ltrSubmitDate") as Literal).Text = form.SubmitDate.HasValue ? form.SubmitDate.Value.ToShortDateString() : null;
                    (e.Item.FindControl("ltrSuspenseDate") as Literal).Text = form.SuspenseDate.HasValue ? form.SuspenseDate.Value.ToShortDateString() : null;
                    (e.Item.FindControl("ltrRater") as Literal).Text = evaluation.Rater;
                    (e.Item.FindControl("ltrStatus") as Literal).Text = form.ExtendedProperties.Status;
                    (e.Item.FindControl("imgStatus") as Image).ImageUrl = ImageUtil.GetColorCode((StatusType)form.ExtendedProperties.StatusType);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        internal override void LoadList()
        {
            Presenter.Load();
        }

        public new IList<Form> Forms
        {
            get
            {
                return base.Forms;
            }
            set
            {
                dlFormList.DataSource = value;
                dlFormList.DataBind();
            }
        }
    }
}