using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNT_PDF_Editor.Function
{
    public static class ImageFunctions
    {
        public static byte[] toByteArray(this Image image)
        {
            MemoryStream imageStream = new MemoryStream();
            image.Save(imageStream, image.RawFormat);
            return imageStream.ToArray();
        }
        public static Image toImage(this byte[] byteArray)
        {
            MemoryStream imageStream = new MemoryStream(byteArray);
            Image image = Image.FromStream(imageStream);
            return image;
        }
        public static Stream toStream(this Image image)
        {
            MemoryStream imageStream = new MemoryStream();
            image.Save(imageStream, image.RawFormat);
            return imageStream;
        }

    }
}
