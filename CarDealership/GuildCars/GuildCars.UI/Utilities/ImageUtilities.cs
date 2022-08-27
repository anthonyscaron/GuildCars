using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Utilities
{
    public class ImageUtilities
    {
        public static string GetCurrentPictureForSpecial()
        {
            var fileNameInImagesSupport = "background-2.jpg";
            return fileNameInImagesSupport;
        }

        public static string GetCurrentIconForSpecial()
        {
            var fileNameInImagesSupport = "dollar-edited.jpg";
            return fileNameInImagesSupport;
        }
    }
}