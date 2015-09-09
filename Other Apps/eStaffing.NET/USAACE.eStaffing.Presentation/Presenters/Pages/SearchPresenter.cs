using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Business.Workflow;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views.Pages;

namespace USAACE.eStaffing.Presentation.Presenters.Pages
{
    public class SearchPresenter : BasePresenter
    {
        /// <summary>
        /// The ISearchView for the SearchPresenter
        /// </summary>
        private new ISearchView View
        {
            get
            {
                return base.View as ISearchView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the ISearchView
        /// </summary>
        /// <param name="view">The ISearchView</param>
        public SearchPresenter(ISearchView view)
        {
            base.View = view;
        }

        public void Load()
        {

        }

        public void Search()
        {
            this.View.Forms = SearchUtil.SearchForms(this.View.SearchTerm, this.View.Roles);
        }
    }
}
