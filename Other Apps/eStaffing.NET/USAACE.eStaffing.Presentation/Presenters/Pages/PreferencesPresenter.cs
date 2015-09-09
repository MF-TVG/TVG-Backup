using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Exceptions;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views.Pages;

namespace USAACE.eStaffing.Presentation.Presenters.Pages
{
    public class PreferencesPresenter : BasePresenter
    {
        /// <summary>
        /// The IPreferencesView for the PreferencesPresenter
        /// </summary>
        private new IPreferencesView View
        {
            get
            {
                return base.View as IPreferencesView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IPreferencesView
        /// </summary>
        /// <param name="view">The IPreferencesView</param>
        public PreferencesPresenter(IPreferencesView view)
        {
            base.View = view;
        }

        public void Load()
        {
            if (this.View.CurrentUserID.HasValue)
            {
                User user = new User();
                user.UserID = this.View.CurrentUserID;

                user = DataService.LoadUser(user);

                User currentUser = new User();
                currentUser.UserID = this.View.UserID;

                if (!PermissionUtil.CheckUserViewPermission(user, currentUser, this.View.Roles))
                {
                    throw new USAACEException(ExceptionType.Unrecoverable, MessageConstants.NOT_ALLOWED_VIEW_USER);
                }

                this.View.CurrentUserID = user.UserID;
                this.View.UserName = user.UserName;
                this.View.UserAuthenticationType = user.AuthenticationType;
                this.View.UserDisplayName = user.UserDisplayName;
                this.View.UserEmail = user.UserEmail;
                this.View.NotifyReject = user.NotifyReject;
                this.View.NotifyReview = user.NotifyReview;
                this.View.NotifyComplete = user.NotifyComplete;

                IList<Group> groups = PermissionUtil.CheckUserGroups(user);

                this.View.UserRoles = String.Join(", ", groups.Select(x => x.GroupName).ToArray());
            }
        }

        public void Save()
        {
            if (this.View.CurrentUserID.HasValue)
            {
                User user = new User();
                user.UserID = this.View.CurrentUserID;

                user = DataService.LoadUser(user);

                user.NotifyReject = this.View.NotifyReject;
                user.NotifyReview = this.View.NotifyReview;
                user.NotifyComplete = this.View.NotifyComplete;

                user = DataService.SaveUser(user);
            }
        }
    }
}
