using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common;
using USAACE.Common.Exceptions;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Enums;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Business.Workflow;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views.Pages;

namespace USAACE.eStaffing.Presentation.Presenters.Pages
{
    public class TrackingPresenter : BasePresenter
    {
        /// <summary>
        /// The ITrackingView for the TrackingPresenter
        /// </summary>
        private new ITrackingView View
        {
            get
            {
                return base.View as ITrackingView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the ITrackingView
        /// </summary>
        /// <param name="view">The ITrackingView</param>
        public TrackingPresenter(ITrackingView view)
        {
            base.View = view;
        }

        public void Load()
        {
            IList<Organization> organizations = DataService.GetOrganizations().Where(x => PermissionUtil.CheckOrganizationViewPermission(x, this.View.Roles)).OrderBy(x => x.OrganizationName).ToList();

            if (PermissionUtil.CheckAdminPermission(this.View.Roles))
            {
                organizations.Insert(0, new Organization { OrganizationName = "All" });
            }

            if (organizations.Count > 0)
            {
                this.View.FormTypes = DataService.GetFormTypes().OrderBy(x => x.FormTypeName).ToList();

                IList<FormStatus> formStatuses = DataService.GetFormStatuses();
                formStatuses.First(x => x.FormStatusID == FormStatusConstants.ACTIVE).ExtendedProperties.Preselected = true;

                this.View.FormStatuses = formStatuses;

                this.View.Organizations = organizations;

                LoadReviewGroups();
            }
            else
            {
                throw new USAACEException(ExceptionType.Unrecoverable, MessageConstants.NOT_ALLOWED_ADMIN);
            }
        }

        public void LoadReviewGroups()
        {
            if (this.View.SelectedOrganization.HasValue)
            {
                this.View.ReviewGroups = DataService.GetOrganizationGroups().Where(x => x.OrganizationID == this.View.SelectedOrganization).OrderBy(x => x.OrganizationGroupName).ToList();
            }
            else
            {
                this.View.ReviewGroups = DataService.GetOrganizationGroups().OrderBy(x => x.OrganizationGroupName).ToList();
            }
        }

        public void GenerateDashboard()
        {
            IList<Form> forms = ReportUtil.GetFormsReport(this.View.SelectedFormTypes, this.View.SuspenseDateStart, this.View.SuspenseDateEnd, this.View.SelectedReviewGroups,
                this.View.SubmitDateStart, this.View.SubmitDateEnd, this.View.Subject, this.View.SelectedFormStatuses, this.View.Roles);

            this.View.Forms = forms;

            IDictionary<StatusType, IList<OrganizationGroup>> metrics = ReportUtil.GetFormsMetrics(forms, this.View.SelectedReviewGroups);

            this.View.MetricsQueued = metrics[StatusType.NotSubmitted];
            this.View.MetricsReview = metrics[StatusType.InReview];
            this.View.MetricsNearDue = metrics[StatusType.NearDue];
            this.View.MetricsPastDue = metrics[StatusType.PastDue];
            this.View.MetricsCompleted = metrics[StatusType.Completed];
            this.View.MetricsRejected = metrics[StatusType.Rejected];

            IList<OrganizationGroup> total = new List<OrganizationGroup>();

            foreach (StatusType type in metrics.Keys)
            {
                IList<OrganizationGroup> groupList = metrics[type];

                if (total.Count == 0)
                {
                    for (int i = 0; i < groupList.Count; i++)
                    {
                        OrganizationGroup group = groupList[i].Copy<OrganizationGroup>();
                        group.ExtendedProperties.MetricValue = groupList[i].ExtendedProperties.MetricValue;

                        total.Add(group);
                    }
                }
                else
                {
                    for (int i = 0; i < groupList.Count; i++)
                    {
                        total[i].ExtendedProperties.MetricValue += groupList[i].ExtendedProperties.MetricValue.GetValueOrDefault(0);
                    }
                }
            }

            this.View.MetricsTotal = total;

            this.View.ShowDashboard = true;
        }
    }
}
