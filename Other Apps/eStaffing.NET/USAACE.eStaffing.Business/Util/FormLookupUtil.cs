using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.LookupEntities;

namespace USAACE.eStaffing.Business.Util
{
    public static class FormLookupUtil
    {
        public static List<T> LoadSpecificLookup<T>(Nullable<Int32> formTypeId, Nullable<Int32> organizationId, String lookupName)
            where T : LookupEntityBase, new()
        {
            FormTypeLookup lookupToLoad = new FormTypeLookup();
            lookupToLoad.FormTypeID = formTypeId;
            lookupToLoad.OrganizationID = organizationId;
            lookupToLoad.LookupName = lookupName;

            return FormLookupUtil.LoadSpecificLookup<T>(lookupToLoad);
        }

        private static List<T> LoadSpecificLookup<T>(FormTypeLookup lookupData) where T : LookupEntityBase, new()
        {
            FormTypeLookup lookupToLoad = new FormTypeLookup();
            lookupToLoad.FormTypeID = lookupData.FormTypeID;
            lookupToLoad.OrganizationID = lookupData.OrganizationID;
            lookupToLoad.LookupName = lookupData.LookupName;

            lookupToLoad = DataService.GetFormTypeLookup(lookupToLoad);

            if (lookupToLoad != null && !String.IsNullOrEmpty(lookupToLoad.LookupValuesXML))
            {
                LookupEntityList<T> lookupList = new LookupEntityList<T>(lookupToLoad.LookupValuesXML);

                return lookupList.Values;
            }
            else
            {
                lookupToLoad = new FormTypeLookup();
                lookupToLoad.FormTypeID = lookupData.FormTypeID;
                lookupToLoad.LookupName = lookupData.LookupName;

                lookupToLoad = DataService.GetFormTypeLookup(lookupToLoad);

                if (lookupToLoad != null && !String.IsNullOrEmpty(lookupToLoad.LookupValuesXML))
                {
                    LookupEntityList<T> lookupList = new LookupEntityList<T>(lookupToLoad.LookupValuesXML);

                    return lookupList.Values;
                }
                else
                {
                    return new List<T>();
                }
            }
        }

        public static DataTable LoadLookupData(FormTypeLookup lookupData)
        {
            FormTypeLookup lookupToLoad = new FormTypeLookup();
            lookupToLoad.FormTypeID = lookupData.FormTypeID;
            lookupToLoad.OrganizationID = lookupData.OrganizationID;
            lookupToLoad.LookupName = lookupData.LookupName;

            lookupToLoad = DataService.GetFormTypeLookup(lookupToLoad);

            if (lookupToLoad != null)
            {
                String typeName = String.Format("USAACE.eStaffing.Domain.LookupEntities.{0},USAACE.eStaffing.Domain", lookupToLoad.LookupDataType);

                Type dataType = Type.GetType(typeName);

                PropertyInfo[] dataTypeProperties = dataType.GetProperties();

                DataTable lookupValueTable = new DataTable();

                foreach (PropertyInfo lookupProperty in dataTypeProperties)
                {
                    lookupValueTable.Columns.Add(lookupProperty.Name, lookupProperty.PropertyType);
                }

                Type listType = typeof(LookupEntityList<>).MakeGenericType(dataType);

                Object lookupList = Activator.CreateInstance(listType, new Object[] { lookupToLoad.LookupValuesXML });

                IList lookupValueList = listType.GetProperty("Values").GetValue(lookupList, null) as IList;

                foreach (Object lookupValue in lookupValueList)
                {
                    DataRow lookupValueRow = lookupValueTable.NewRow();

                    foreach (PropertyInfo lookupProperty in dataTypeProperties)
                    {
                        lookupValueRow[lookupProperty.Name] = lookupProperty.GetValue(lookupValue, null);
                    }

                    lookupValueTable.Rows.Add(lookupValueRow);
                }

                return lookupValueTable;
            }
            else
            {
                return null;
            }
        }

        public static void SaveLookupData(FormTypeLookup lookupData, DataTable lookupValues)
        {
            FormTypeLookup lookupToSave = new FormTypeLookup();
            lookupToSave.FormTypeID = lookupData.FormTypeID;
            lookupToSave.OrganizationID = lookupData.OrganizationID;
            lookupToSave.LookupName = lookupData.LookupName;

            lookupToSave = DataService.GetFormTypeLookup(lookupToSave);

            if (lookupToSave == null)
            {
                lookupToSave = new FormTypeLookup();
                lookupToSave.FormTypeID = lookupData.FormTypeID;
                lookupToSave.OrganizationID = lookupData.OrganizationID;
                lookupToSave.LookupName = lookupData.LookupName;
                lookupToSave.LookupDataType = lookupData.LookupDataType;
            }

            String typeName = String.Format("USAACE.eStaffing.Domain.LookupEntities.{0},USAACE.eStaffing.Domain", lookupToSave.LookupDataType);

            Type dataType = Type.GetType(typeName);

            PropertyInfo[] dataTypeProperties = dataType.GetProperties();

            Type listType = typeof(LookupEntityList<>).MakeGenericType(dataType);

            Object lookupList = Activator.CreateInstance(listType);

            IList lookupValueList = listType.GetProperty("Values").GetValue(lookupList, null) as IList;

            lookupValueList.Clear();

            foreach (DataRow lookupValue in lookupValues.Rows)
            {
                Object lookupEntity = Activator.CreateInstance(dataType);

                foreach (PropertyInfo dataTypeProperty in dataTypeProperties)
                {
                    dataTypeProperty.SetValue(lookupEntity, lookupValue[dataTypeProperty.Name]);
                }

                lookupValueList.Add(lookupEntity);
            }

            listType.GetProperty("Values").SetValue(lookupList, lookupValueList);

            lookupToSave.LookupValuesXML = listType.GetMethod("SaveToXml").Invoke(lookupList, null) as String;

            lookupToSave = DataService.SaveFormTypeLookup(lookupToSave);
        }
    }
}
