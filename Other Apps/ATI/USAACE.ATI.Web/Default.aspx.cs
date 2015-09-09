using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using USAACE.ATI.Domain.Entities;

namespace USAACE.ATI.Web
{
    /// <summary>
    /// Class for the Default page
    /// </summary>
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Current.aspx", false);
        }
    }
}