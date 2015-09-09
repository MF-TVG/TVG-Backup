using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace USAACE.ATI.Web
{
    /// <summary>
    /// Class containing several events specific to the web application
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Event taking place when the application starts
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
        }

        /// <summary>
        /// Event taking place when the application end
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
        }

        /// <summary>
        /// Event taking place when the application errors
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        void Application_Error(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Event taking place when the session starts
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
        }

        /// <summary>
        /// Event taking place when the session end
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
        }
    }
}
