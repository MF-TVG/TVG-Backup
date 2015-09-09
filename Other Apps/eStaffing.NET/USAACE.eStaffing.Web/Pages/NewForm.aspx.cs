using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.Common.Exceptions;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Presenters.Pages;
using USAACE.eStaffing.Presentation.Views.Pages;
using USAACE.eStaffing.Web.Controls;
using USAACE.eStaffing.Web.Controls.FormControls;
using USAACE.eStaffing.Web.Enum;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web.Pages
{
    public partial class NewForm : BasePage, INewFormView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private NewFormPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public NewFormPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new NewFormPresenter(this);
                }

                return _presenter;
            }
        }

        /// <summary>
        /// Event occurring on Page Load, loads appropriate lookups and the form on initial event
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected override void LoadPage()
        {
            try
            {
                if (!IsPostBack)
                {
                    Presenter.Load();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Save button is clicked, save the form
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.Save();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when Submit Group value is changed, loads the proper submit destination
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void ddlFormType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadSubmitGroups();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when Submit Group value is changed, loads the proper submit destination
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void ddlSubmitGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadRoutingChains();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        public IList<FormType> FormTypes
        {
            set
            {
                ddlFormType.Items.Clear();

                foreach (FormType formType in value)
                {
                    ddlFormType.Items.Add(new ListItem(formType.FormTypeName, formType.FormTypeID.ToString()));
                }
            }
        }

        public Nullable<Int32> SelectedFormTypeID
        {
            get
            {
                return ddlFormType.SelectedValue.ToNullable<Int32>();
            }
        }

        public IList<OrganizationGroup> SubmitGroups
        {
            set
            {
                ddlSubmitGroup.Items.Clear();

                foreach (OrganizationGroup group in value)
                {
                    ddlSubmitGroup.Items.Add(new ListItem(group.OrganizationGroupName, group.OrganizationGroupID.ToString()));
                }
            }
        }

        public Nullable<Int32> SelectedSubmitGroupID
        {
            get
            {
                return ddlSubmitGroup.SelectedValue.ToNullable<Int32>();
            }
        }

        public String SubmitOrganization
        {
            set
            {
                ltrOrganization.Text = value;
            }
        }

        public IList<OrganizationFormRouting> RoutingChains
        {
            set
            {
                rblRoutingChain.Items.Clear();

                foreach (OrganizationFormRouting routing in value)
                {
                    rblRoutingChain.Items.Add(new ListItem(routing.ExtendedProperties.RoutingNameAndReviewers, routing.OrganizationFormRoutingID.ToString()));
                }

                if (rblRoutingChain.Items.Count > 0)
                {
                    rblRoutingChain.SelectedIndex = 0;
                }
            }
        }

        public Nullable<Int32> SelectedRoutingID
        {
            get
            {
                return rblRoutingChain.SelectedValue.ToNullable<Int32>();
            }
        }

        public Nullable<Int32> FormID
        {
            set
            {
                Response.Redirect(NavigateUtil.GetFormLink(value), false);
            }
        }
    }
}