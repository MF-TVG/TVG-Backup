using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USAACE.Common.Presentation
{
    /// <summary>
    /// An abstract class for the basics of a presenter
    /// </summary>
    public abstract class BasePresenter
    {
        /// <summary>
        /// The view for the presenter
        /// </summary>
        public IBaseView View;
    }
}
