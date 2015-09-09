using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common;
using USAACE.Common.Exceptions;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views.Pages.Administration;

namespace USAACE.eStaffing.Presentation.Presenters.Pages.Administration
{
    public class OrganizationsPresenter : BasePresenter
    {
        /// <summary>
        /// The IOrganizationsView for the OrganizationsPresenter
        /// </summary>
        private new IOrganizationsView View
        {
            get
            {
                return base.View as IOrganizationsView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IOrganizationsView
        /// </summary>
        /// <param name="view">The IOrganizationsView</param>
        public OrganizationsPresenter(IOrganizationsView view)
        {
            base.View = view;
        }

        public void Load()
        {
            IList<Organization> organizationList = DataService.GetOrganizations().Where(x => PermissionUtil.CheckOrganizationViewPermission(x, this.View.Roles)).OrderBy(x => x.OrganizationName).ToList();

            if (PermissionUtil.CheckAdminPermission(this.View.Roles))
            {
                organizationList.Insert(0, new Organization { OrganizationName = "-- New Organization --" });
            }

            if (organizationList.Count > 0)
            {
                this.View.OrganizationList = organizationList;

                IList<Group> groups = DataService.GetGroups().OrderBy(x => x.GroupName).ToList();
                groups.Insert(0, new Group { GroupName = "-- No Group --" });

                this.View.Groups = groups;
                
                LoadOrganization();
            }
            else
            {
                throw new USAACEException(ExceptionType.Unrecoverable, MessageConstants.NOT_ALLOWED_ADMIN);
            }
        }

        public void LoadOrganization()
        {
            if (this.View.OrganizationID.HasValue)
            {
                Organization organization = new Organization();
                organization.OrganizationID = this.View.OrganizationID;

                organization = DataService.LoadOrganization(organization);

                this.View.OrganizationName = organization.OrganizationName;

                OrganizationGroup organizationGroup = new OrganizationGroup();
                organizationGroup.OrganizationID = this.View.OrganizationID;

                IList<OrganizationGroup> organizationGroups = DataService.ListOrganizationGroups(organizationGroup);

                IDictionary<Nullable<Int32>, Group> groups = DataService.ListGroupsDictionary();

                foreach (OrganizationGroup group in organizationGroups)
                {
                    group.ExtendedProperties.GroupName = group.GroupID.HasValue ? groups[group.GroupID].GroupName : String.Empty;
                }

                this.View.OrganizationGroups = organizationGroups;
            }
            else
            {
                this.View.OrganizationName = null;
                this.View.OrganizationGroups = new List<OrganizationGroup>();
            }

            this.View.EnableEdit = PermissionUtil.CheckAdminPermission(this.View.Roles);
        }

        public void LoadSelectedOrganizationGroup()
        {
            if (this.View.SelectedOrganizationGroupID.HasValue)
            {
                OrganizationGroup organizationGroup = this.View.OrganizationGroups.FirstOrDefault(x => x.OrganizationGroupID == this.View.SelectedOrganizationGroupID);

                this.View.OrganizationGroupName = organizationGroup.OrganizationGroupName;
                this.View.OrganizationGroupGroupID = organizationGroup.GroupID;
            }
            else
            {
                this.View.OrganizationGroupName = null;
                this.View.OrganizationGroupGroupID = null;
            }
        }

        public void SaveSelectedOrganizationGroup()
        {
            if (this.View.OrganizationGroups.Any(x => x.OrganizationGroupID != this.View.SelectedOrganizationGroupID
                && x.OrganizationGroupName == this.View.OrganizationGroupName && x.ExtendedProperties.MarkForDeletion != true))
            {
                throw new USAACEException(ExceptionType.Recoverable, MessageConstants.SAVE_ORGANIZATION_GROUP_DUPLICATE);
            }
            else
            {
                if (this.View.SelectedOrganizationGroupID.HasValue)
                {
                    IList<OrganizationGroup> organizationGroups = this.View.OrganizationGroups;

                    OrganizationGroup organizationGroup = organizationGroups.FirstOrDefault(x => x.OrganizationGroupID == this.View.SelectedOrganizationGroupID);

                    organizationGroup.OrganizationGroupName = this.View.OrganizationGroupName;
                    organizationGroup.GroupID = this.View.OrganizationGroupGroupID;
                    organizationGroup.ExtendedProperties.GroupName = this.View.OrganizationGroupGroupName;

                    this.View.OrganizationGroups = organizationGroups;
                }
                else
                {
                    IList<OrganizationGroup> organizationGroups = this.View.OrganizationGroups;

                    Int32 newId = -1 * organizationGroups.Count(x => x.OrganizationGroupID < 0) - 1;

                    OrganizationGroup organizationGroup = new OrganizationGroup();

                    organizationGroup.OrganizationGroupID = newId;
                    organizationGroup.OrganizationID = this.View.OrganizationID;
                    organizationGroup.OrganizationGroupName = this.View.OrganizationGroupName;
                    organizationGroup.GroupID = this.View.OrganizationGroupGroupID;
                    organizationGroup.ExtendedProperties.GroupName = this.View.OrganizationGroupGroupName;

                    organizationGroups.Add(organizationGroup);

                    this.View.OrganizationGroups = organizationGroups;
                }
            }
        }

        public void DeleteSelectedOrganizationGroup()
        {
            if (this.View.SelectedOrganizationGroupID.HasValue)
            {
                IList<OrganizationGroup> organizationGroups = this.View.OrganizationGroups;

                OrganizationGroup organizationGroup = this.View.OrganizationGroups.FirstOrDefault(x => x.OrganizationGroupID == this.View.SelectedOrganizationGroupID);

                organizationGroup.ExtendedProperties.MarkForDeletion = true;

                this.View.OrganizationGroups = organizationGroups;
            }
        }

        public void Save()
        {
            Organization organization = new Organization();

            if (this.View.OrganizationID.HasValue)
            {
                organization.OrganizationID = this.View.OrganizationID;
                organization = DataService.LoadOrganization(organization);
            }

            if (DataService.GetOrganizations().Any(x => x.OrganizationID != this.View.OrganizationID && x.OrganizationName == this.View.OrganizationName))
            {
                throw new USAACEException(ExceptionType.Recoverable, MessageConstants.SAVE_ORGANIZATION_DUPLICATE);
            }
            else
            {
                organization.OrganizationName = this.View.OrganizationName;

                DataService.SaveOrganization(organization);

                foreach (OrganizationGroup group in this.View.OrganizationGroups)
                {
                    if (group.OrganizationGroupID < 0)
                    {
                        group.OrganizationGroupID = null;
                    }

                    if (group.ExtendedProperties.MarkForDeletion != true)
                    {
                        group.OrganizationID = organization.OrganizationID;
                        DataService.SaveOrganizationGroup(group);
                    }
                    else if (group.OrganizationGroupID.HasValue)
                    {
                        DataService.DeleteOrganizationGroup(group);
                    }
                }

                Load();

                this.View.OrganizationID = organization.OrganizationID;

                LoadOrganization();
            }
        }
    }
}
