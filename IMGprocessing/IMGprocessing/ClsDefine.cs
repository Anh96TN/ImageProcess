using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMGprocessing
{
    struct ClsNameConfig
    {
        /// lưu ảnh 
        public const string SECTION_IMAGE = "SECTION_IMAGE";
        public const string KEY_IMAGE_INPUT = "KEY_IMAGE_INPUT";
        public const string KEY_IMAGE_OUTPUT = "KEY_IMAGE_OUTPUT";


        /// Template (mark)
        public const string SECTION_PMALIGN = "SECTION_PMALIGN";
        public const string KEY_PMALIGN_ROI = "KEY_PMALIGN_ROI";

    }


    class ClsDefine
    {
        public static double _VERSION_ = 2.0; // Version
        public static string _DATE_MAKE_ = "10/10/2024"; // ngày sửa

        // PATH
        public static string PATH_ROOT_APP = "";
        public static string PATH_INI = @"\APP\config.ini";
        public static string PATH_LOG = @"\APP\LOG";

        public static string PATH_IMG_INPUT = "";
        public static string PATH_IMG_OUTPUT = "";

        public static string PATH_TOOL_PMALIGN_PATTEN = @"\APP\Patten.bmp";

        public static string PATH_FOLDER_AI = "";
    }
}
