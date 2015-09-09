using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Exceptions;
using USAACE.Common.Presentation;
using USAACE.ATI.Presentation.Views;

namespace USAACE.ATI.Presentation.Presenters
{
    public class BasePagePresenter : BasePresenter
    {
        /// <summary>
        /// The IBasePageView for the BasePagePresenter
        /// </summary>
        private new IBasePageView View
        {
            get
            {
                return base.View as IBasePageView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IBasePageView
        /// </summary>
        /// <param name="view">The IBasePageView</param>
        public BasePagePresenter(IBasePageView view)
        {
            base.View = view;
        }

        public void LoadUser()
        {
            if (this.View.CurrentUser != null)
            {
                this.View.DisplayName = this.View.CurrentUser.Identity.Name;
            }
        }
    }
}
