using System.Linq;
using USAACE.Common.Presentation;
using USAACE.Common.Util;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Presentation.Views;

namespace USAACE.eStaffing.Presentation.Presenters
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
            this.View.FormTypes = DataService.GetFormTypes().OrderBy(x => x.FormTypeName).ToList();
            this.View.IADesignation = ConfigUtil.GetConfigurationValue("IADesignation");
        }
    }
}