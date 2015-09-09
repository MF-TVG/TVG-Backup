using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.ATI.Presentation.Views;

namespace USAACE.ATI.Presentation.Presenters
{
    public class SitePresenter : BasePresenter
    {
        /// <summary>
        /// The ISiteView for the SitePresenter
        /// </summary>
        private new ISiteView View
        {
            get
            {
                return base.View as ISiteView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the ISiteView
        /// </summary>
        /// <param name="view">The ISiteView</param>
        public SitePresenter(ISiteView view)
        {
            base.View = view;
        }

        public void Load()
        {
            this.View.IADesignation = ConfigurationManager.AppSettings["IADesignation"];
        }
    }
}