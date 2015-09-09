using System;
using System.Collections.Generic;
using System.Data;
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
using USAACE.eStaffing.Domain.LookupEntities;
using USAACE.eStaffing.Presentation.Views.Pages.Administration;

namespace USAACE.eStaffing.Presentation.Presenters.Pages.Administration
{
    public class LookupSettingsPresenter : BasePresenter
    {
        /// <summary>
        /// The ILookupSettingsView for the LookupSettingsPresenter
        /// </summary>
        private new ILookupSettingsView View
        {
            get
            {
                return base.View as ILookupSettingsView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the ILookupSettingsView
        /// </summary>
        /// <param name="view">The ILookupSettingsView</param>
        public LookupSettingsPresenter(ILookupSettingsView view)
        {
            base.View = view;
        }

        public void Load()
        {
            if (!PermissionUtil.CheckAdminPermission(this.View.Roles))
            {
                throw new USAACEException(ExceptionType.Unrecoverable, MessageConstants.NOT_ALLOWED_ADMIN);
            }
            else
            {
                this.View.FormTypeList = DataService.GetFormTypes().OrderBy(x => x.FormTypeName).ToList();
                this.View.OrganizationList = DataService.GetOrganizations().OrderBy(x => x.OrganizationName).ToList();

                LoadFormTypeLookups();
            }
        }

        public void LoadFormTypeLookups()
        {
            if (this.View.FormTypeID.HasValue)
            {
                this.View.FormTypeLookupList = DataService.GetFormTypeLookups().Where(x => x.FormTypeID == this.View.FormTypeID && x.OrganizationID == null).ToList();
            }
            else
            {
                this.View.FormTypeLookupList = new List<FormTypeLookup>();
            }

            LoadFormTypeLookup();
        }

        public void LoadFormTypeLookup()
        {
            if (!String.IsNullOrEmpty(this.View.SelectedFormTypeLookup))
            {
                FormTypeLookup lookup = new FormTypeLookup();
                lookup.FormTypeID = this.View.FormTypeID;
                lookup.OrganizationID = this.View.OrganizationID;
                lookup.LookupName = this.View.SelectedFormTypeLookup;

                lookup = DataService.GetFormTypeLookup(lookup);

                if (lookup == null)
                {
                    lookup = new FormTypeLookup();
                    lookup.FormTypeID = this.View.FormTypeID;
                    lookup.OrganizationID = null;
                    lookup.LookupName = this.View.SelectedFormTypeLookup;

                    lookup = DataService.GetFormTypeLookup(lookup);
                }

                this.View.LookupValues = FormLookupUtil.LoadLookupData(lookup);
                this.View.LookupDataType = lookup.LookupDataType;
            }
            else
            {
                this.View.LookupValues = null;
            }
        }

        public void SaveFormTypeLookup()
        {
            if (!String.IsNullOrEmpty(this.View.SelectedFormTypeLookup))
            {
                FormTypeLookup lookup = new FormTypeLookup();
                lookup.FormTypeID = this.View.FormTypeID;
                lookup.OrganizationID = this.View.OrganizationID;
                lookup.LookupName = this.View.SelectedFormTypeLookup;

                lookup = DataService.GetFormTypeLookup(lookup);

                if (lookup == null)
                {
                    lookup = new FormTypeLookup();
                    lookup.FormTypeID = this.View.FormTypeID;
                    lookup.LookupName = this.View.SelectedFormTypeLookup;

                    lookup = DataService.GetFormTypeLookup(lookup);

                    lookup.OrganizationID = this.View.OrganizationID;
                    lookup.LookupDataType = this.View.LookupDataType;
                }

                FormLookupUtil.SaveLookupData(lookup, this.View.LookupValues);

                LoadFormTypeLookup();
            }
        }

        public void LoadFormTypeLookupRow()
        {
            DataTable lookupTable = this.View.LookupValues;

            IDictionary<String, Object> lookupValue = new Dictionary<String, Object>();

            foreach (DataColumn column in lookupTable.Columns)
            {
                lookupValue.Add(column.ColumnName, this.View.SelectedLookupValue.HasValue ? lookupTable.Rows[this.View.SelectedLookupValue.Value][column] : null);
            }

            this.View.LookupValueRow = lookupValue;
        }

        public void SaveFormTypeLookupRow()
        {
            DataTable lookupTable = this.View.LookupValues;
            IDictionary<String, Object> lookupValue = this.View.LookupValueRow;

            if (this.View.SelectedLookupValue.HasValue)
            {
                foreach (DataColumn column in lookupTable.Columns)
                {
                    lookupTable.Rows[this.View.SelectedLookupValue.Value][column] = lookupValue[column.ColumnName];
                }
            }
            else
            {
                DataRow newValue = lookupTable.NewRow();

                foreach (DataColumn column in lookupTable.Columns)
                {
                    newValue[column] = lookupValue[column.ColumnName];
                }

                lookupTable.Rows.Add(newValue);
            }

            this.View.LookupValues = lookupTable;
        }

        public void DeleteFormTypeLookupRow()
        {
            if (this.View.SelectedLookupValue.HasValue)
            {
                DataTable lookupTable = this.View.LookupValues;

                lookupTable.Rows.RemoveAt(this.View.SelectedLookupValue.Value);

                this.View.LookupValues = lookupTable;
            }
        }
    }
}
