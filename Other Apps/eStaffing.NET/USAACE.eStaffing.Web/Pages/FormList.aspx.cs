using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Presenters.Pages;
using USAACE.eStaffing.Presentation.Views.Pages;
using USAACE.eStaffing.Web.Controls;

namespace USAACE.eStaffing.Web.Pages
{
    public partial class FormList : BasePage, IFormListView
    {

        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private FormListPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public FormListPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new FormListPresenter(this);
                }

                return _presenter;
            }
        }

        protected override void LoadPage()
        {
            try
            {
                Presenter.Initialize();

                if (!IsPostBack)
                {
                    LoadList();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void lkbSort_Click(object sender, EventArgs e)
        {
            try
            {
                LoadList();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void lkbPrevGroup_Click(object sender, EventArgs e)
        {
            Presenter.DecrementIndex();
            FormListControl.LoadList();
        }

        protected void lkbNextGroup_Click(object sender, EventArgs e)
        {
            Presenter.IncrementIndex();
            FormListControl.LoadList();
        }

        internal void LoadList()
        {
            Presenter.Load();
            FormListControl.LoadList();
        }

        internal FormListControl FormListControl
        {
            get
            {
                return pnlFormList.Controls[0] as FormListControl;
            }
        }

        public Nullable<Int32> FormTypeID
        {
            get
            {
                return Request.QueryString["FormTypeID"].ToNullable<Int32>();
            }
        }

        public String SortField
        {
            get
            {
                return rblSortField.SelectedValue;
            }
        }

        public String SortDirection
        {
            get
            {
                return rblSortDirection.SelectedValue;
            }
        }

        public String FormTitle
        {
            set
            {
                ltrFormTitle.Text = value + " List";
            }
        }

        public String ControlName
        {
            set
            {
                FormListControl listControl = LoadControl(String.Format("~/Controls/ListControls/{0}.ascx", value)) as FormListControl;
                listControl.ID = "ucFormList";

                pnlFormList.Controls.Add(listControl);
            }
        }

        public IList<Form> Forms
        {
            get
            {
                return this.ViewState["Forms"] as IList<Form>;
            }
            set
            {
                this.ViewState["Forms"] = value;
            }
        }

        public Nullable<Int32> StartIndex
        {
            get
            {
                return lblStartIndex.Text.ToNullable<Int32>();
            }
            set
            {
                lblStartIndex.Text = value.GetValueOrDefault(1).ToString();
            }
        }


        public Nullable<Int32> EndIndex
        {
            set
            {
                lblEndIndex.Text = value.GetValueOrDefault(0).ToString();
            }
        }

        public Int32 IncrementRange
        {
            get
            {
                return ddlShowNumber.SelectedValue.ToNullable<Int32>().GetValueOrDefault(30);
            }
        }

        public Boolean ShowPrev
        {
            set
            {
                lkbPrevGroup.Visible = value;
            }
        }

        public Boolean ShowNext
        {
            set
            {
                lkbNextGroup.Visible = value;
            }
        }
    }
}