using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using USAACE.Common.Exceptions;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views;

namespace USAACE.eStaffing.Presentation.Presenters
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
                IIdentity identity = this.View.CurrentUser.Identity;

                User user = new User();
                user.UserName = identity.Name;
                user.ExtendedProperties.AuthenticationMethod = this.View.AuthenticationType;

                if (identity is WindowsIdentity)
                {
                    user.UserSID = (identity as WindowsIdentity).User.Value;
                }

                user = DataService.GetUser(user, true);

                this.View.UserID = user.UserID;
                this.View.DisplayName = user.UserDisplayName;

                if (user.AuthenticationType == AuthenticationTypeConstants.WINDOWS_AUTH_NAME)
                {
                    ClaimsPrincipal principal = this.View.CurrentUser as ClaimsPrincipal;
                    IList<String> groups = principal.Claims.Select(x => x.Value).ToList();

                    user.ExtendedProperties.UserSIDs = groups;
                }

                this.View.Roles = UserService.GetUserGroups(user);
            }

            this.View.ShowLogout = this.View.CurrentUser != null;
        }

        public void SaveError()
        {
            if (this.View.LastError != null)
            {
                Exception lastError = this.View.LastError;

                ErrorLog log = new ErrorLog();
                log.Message = lastError.Message;
                log.StackTrace = lastError.StackTrace;
                log.UserName = this.View.DisplayName;
                log.ErrorDate = DateTime.Now;
                log.Location = this.View.CurrentLocation;

                if (lastError is USAACEException)
                {
                    USAACEException specificError = lastError as USAACEException;
                    log.ErrorType = specificError.Type == ExceptionType.Recoverable ? "Recoverable" : "Unrecoverable";
                }
                else
                {
                    log.ErrorType = "Unexpected";
                }

                DataService.SaveErrorLog(log);
            }

        }
    }
}
