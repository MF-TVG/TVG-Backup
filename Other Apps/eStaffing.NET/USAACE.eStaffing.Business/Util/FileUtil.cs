using System;
using System.Collections.Generic;
using System.Linq;

namespace USAACE.eStaffing.Business.Util
{
    public static class FileUtil
    {
        private static readonly String[] ALLOWED_EXTENSIONS = { "doc", "docx", "xls", "xlsx", "ppt", "pptx", "jpg", "jpeg", "bmp", "png", "txt", "pdf", "xfdl" };

        public static Boolean FileValid(String fileName)
        {
            return fileName != null && !fileName.Contains("~") && !fileName.Contains("#") && !fileName.Contains("%") && !fileName.Contains("&") && !fileName.Contains("*")
                && !fileName.Contains("{") && !fileName.Contains("}") && !fileName.Contains("\\") && !fileName.Contains(":") && !fileName.Contains("<") && !fileName.Contains(">")
                && !fileName.Contains("?") && !fileName.Contains("/") && !fileName.Contains("+") && !fileName.Contains("|") && !fileName.Contains("\"")
                && ALLOWED_EXTENSIONS.Contains(GetFileExtension(fileName));
        }

        public static String GetFileName(String fullPath)
        {
            return fullPath.Substring(fullPath.LastIndexOf(@"\") + 1);
        }

        public static String GetFileExtension(String fullPath)
        {
            return fullPath.Substring(fullPath.LastIndexOf(".") + 1);
        }
    }
}