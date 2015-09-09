using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views.Controls.Forms;

namespace USAACE.eStaffing.Presentation.Presenters.Controls.Forms
{
    public class AMOFormPresenter : BasePresenter
    {
        /// <summary>
        /// The IAMOFormView for the AMOFormPresenter
        /// </summary>
        private new IAMOFormView View
        {
            get
            {
                return base.View as IAMOFormView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IAMOFormView
        /// </summary>
        /// <param name="view">The IAMOFormView</param>
        public AMOFormPresenter(IAMOFormView view)
        {
            base.View = view;
        }

        public void Initialize()
        {

        }

        public void Load()
        {

        }

        public void LoadLookups()
        {

        }

        public void Save()
        {

        }

        public void SaveDefault()
        {

        }
    }
}
