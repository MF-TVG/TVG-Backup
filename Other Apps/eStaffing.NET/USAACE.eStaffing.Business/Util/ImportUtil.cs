using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Entities;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Business.Util
{
    public static class ImportUtil
    {
        public static void CopyForm(Form sourceForm, Form destinationForm, Boolean includeAttachments)
        {
            FormData sourceFormData = new FormData();
            sourceFormData.FormID = sourceForm.FormID;

            sourceFormData = DataService.LoadFormData(sourceFormData);

            FormData destinationFormData = new FormData();
            destinationFormData.FormID = destinationForm.FormID;

            destinationFormData = DataService.LoadFormData(destinationFormData);

            destinationFormData.FormDataXML = sourceFormData.FormDataXML;

            DataService.SaveFormData(sourceFormData);

            /*if (sourceFormDataList.Count > 0)
            {
                EntityBase destinationFormData = Activator.CreateInstance(dataType) as EntityBase;
                formId.SetValue(destinationFormData, destinationForm.FormID);

                IList destinationFormDataList = searchMethod.Invoke(destinationFormData, null) as IList;

                if (destinationFormDataList.Count > 0)
                {
                    EntityBase sourceFormForCopy = sourceFormDataList[0] as EntityBase;
                    EntityBase destinationFormForCopy = destinationFormDataList[0] as EntityBase;

                    sourceFormForCopy.Copy(false, destinationFormForCopy);
                    formId.SetValue(destinationFormForCopy, destinationForm.FormID);
                    DataService.SaveFormData(destinationFormForCopy);

                    FormUtil.SetFormTypeValues(destinationForm, destinationFormForCopy);

                    DataService.SaveForm(destinationForm);
                }
            }*/

            if (includeAttachments)
            {
                FormAttachment oldAttachment = new FormAttachment();
                oldAttachment.FormID = destinationForm.FormID;

                IList<FormAttachment> oldAttachments = DataService.ListFormAttachments(oldAttachment).Where(x => x.ReviewStatusID == null).ToList();

                foreach (FormAttachment oldAttachmentItem in oldAttachments)
                {
                    DataService.DeleteFormAttachment(oldAttachmentItem);
                }

                FormAttachment sourceAttachment = new FormAttachment();
                sourceAttachment.FormID = sourceForm.FormID;

                IList<FormAttachment> sourceAttachments = DataService.ListFormAttachments(sourceAttachment).Where(x => x.ReviewStatusID == null).ToList();

                foreach (FormAttachment sourceAttachmentItem in sourceAttachments)
                {
                    FormAttachment newAttachment = sourceAttachmentItem.Copy<FormAttachment>(false);
                    newAttachment.FormID = destinationForm.FormID;

                    newAttachment = DataService.SaveFormAttachment(newAttachment);

                    FormAttachmentData sourceAttachmentData = new FormAttachmentData();
                    sourceAttachmentData.FormAttachmentID = sourceAttachmentItem.FormAttachmentID;

                    sourceAttachmentData = DataService.LoadFormAttachmentData(sourceAttachmentData);

                    FormAttachmentData newAttachmentData = sourceAttachmentData.Copy<FormAttachmentData>(false);
                    newAttachmentData.FormAttachmentID = newAttachment.FormAttachmentID;

                    DataService.SaveFormAttachmentData(newAttachmentData);
                }
            }
        }
    }
}
