using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.FormEntities;

namespace USAACE.eStaffing.Business.Util
{
    public static class FormDataUtil
    {
        public static T LoadSpecificFormData<T>(FormData formData) where T : FormEntityBase, new()
        {
            return FormEntityBase.LoadFromXml<T>(formData.FormDataXML);
        }
    }
}
