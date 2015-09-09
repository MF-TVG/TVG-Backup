using System;

namespace USAACE.eStaffing.Business.Constants
{
    public static class MessageConstants
    {
        public const String NOT_ALLOWED_SUBMIT_FORM = @"You are not authorized to create a new form.";
        public const String NOT_ALLOWED_VIEW_FORM = @"You are not authorized to view this form or you are accessing an invalid link for this form.";
        public const String NOT_ALLOWED_ADMIN = @"You are not authorized to view this page.";
        public const String INVALID_FORM_TYPE = @"The form type is not specified or does not exist.";
        public const String NOT_ALLOWED_VIEW_USER = @"You are not authorized to view this user.";
        public const String INVALID_FILE_NAME_TYPE = @"This file has an invalid name or is not one of the supported file types, supported file types include:
            doc, docx, xls, xlsx, ppt, pptx, jpg, jpeg, bmp, png, txt, pdf, xfdl";
        public const String SUBMIT_SUCCESS = @"The form was saved and submitted successfully.";
        public const String SAVE_SUCCESS = @"The form was saved successfully.";
        public const String FORM_VALIDATION_ERRORS = @"The form could not be submitted because of validation errors with the form.";
        public const String DELETE_SUCCESS = @"The form was deleted successfully.";
        public const String SAVE_REVIEW_SUCCESS = @"The review was saved successfully.";
        public const String SAVE_REVIEW_ORDER_SUCCESS = @"The review order was saved successfully.";
        public const String SAVE_FORM_TYPE_SUCCESS = @"The form type was saved successfully.";
        public const String RESET_CACHE_SUCCESS = @"The cache was reset successfully.";
        public const String SAVE_FORM_SETTINGS_SUCCESS = @"The form settings were saved successfully.";
        public const String SAVE_GROUP_SUCCESS = @"The group was saved successfully.";
        public const String SAVE_ORGANIZATION_SUCCESS = @"The organization was saved successfully.";
        public const String SAVE_ROUTING_SUCCESS = @"The routing chain was saved successfully.";
        public const String RESET_REVIEW_SUCCESS = @"The review was reset successfully.";
        public const String NOTIFY_REVIEW_SUCCESS = @"The reviewer was notified successfully.";
        public const String SAVE_PREFERENCES_SUCCESS = @"Your preferences were saved successfully.";
        public const String NO_FORWARDING_ORGANIZATIONS = @"No organizations have been configured to accepted forwarded packets from this organization.";
        public const String FORWARD_SUCCESS = @"The form was forwarded successfully.";
        public const String UNDELETE_SUCCESS = @"The form was restored successfully.";
        public const String IMPORT_SUCCESS = @"The import operation was successful.";
        public const String SAVE_ROUTING_CHAIN_SUCCESS = @"The routing chain was saved successfully.";
        public const String SAVE_FORWARDING_SUCCESS = @"The forwarding was saved successfully.";
        public const String SAVE_FORM_TYPE_LOOKUP_SUCCESS = @"The form type lookup was saved successfully";
        public const String SET_DEFAULT_SUCCESS = @"The form default was set successfully.";
        public const String SIGNATURE_SUCCESS = @"The review was signed successfully.";
        public const String SIGNATURE_REMOVE_SUCCESS = @"The review signature was removed successfully.";
        public const String SIGNATURE_INVALID = @"The digital signature is not valid because either the certificate is invalid or the data that was signed has changed.";
        public const String SIGNATURE_VALID = @"The digital signature is valid.";
        public const String SAVE_GROUP_DUPLICATE = @"The group could not be saved because another group exists with that name.";
        public const String SAVE_ORGANIZATION_GROUP_DUPLICATE = @"The organization group could not be saved because another organization group exists in this organization with that name.";
        public const String SAVE_ORGANIZATION_DUPLICATE = @"The organization could not be saved because another organization exists with that name.";
    }
}
