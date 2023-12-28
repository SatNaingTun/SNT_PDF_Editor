using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace SNT_PDF_Editor.Function
{
    class PDFConverter:IPDFFunction
    {
        PdfDocument outputDocument = new PdfDocument();
        public void openDocument(string fileName)
        {
            if (File.Exists(fileName))
            {
                string ext = Path.GetExtension(fileName);
                if (ext == ".jpg"||ext==".jpeg"||ext==".png"||ext==".gif")
                {
                    readPicture(fileName);
                }
                if (ext == ".txt")
                {
                    readTextFile(fileName);
                }
            }
            
            else
            {
                Console.WriteLine(fileName + "File Not Exist");
            }
        }
        private void readPicture(string fileName)
        {
            PdfPage page = outputDocument.AddPage();

            using (XImage img = XImage.FromFile(fileName))
            {
                page.Width = img.PixelWidth;
                page.Height = img.PixelHeight;
                XGraphics gfx = XGraphics.FromPdfPage(page);
                gfx.DrawImage(img, 0, 0, page.Width, page.Height);
            }
        }
        private void readTextFile(string fileName)
        {
            PdfPage page = outputDocument.AddPage();
           
            using (StreamReader file = new StreamReader(fileName))
            {
                string ln;
                double yPoint = 0;
                XGraphics gfx = XGraphics.FromPdfPage(page);
                {
                    while ((ln = file.ReadLine()) != null)
                    {
                        yPoint += 20;
                        if (yPoint > page.Height)
                        {
                            page = outputDocument.AddPage();
                             gfx = XGraphics.FromPdfPage(page);
                             yPoint = 0;
                        }
                        
                            XFont font = new XFont("Times New Roman", 10, XFontStyle.Regular);
                            gfx.DrawString(ln, font, XBrushes.Black, new XRect(0, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                            if (gfx.MeasureString(ln, font).Width > page.Width)
                            {
                                yPoint += 20;
                                string inString = ln.Substring(0,Convert.ToInt16( ln.Length * page.Width / gfx.MeasureString(ln, font).Width)-3);
                                string outString = ln.Remove(0,inString.Length);
                                gfx.DrawString(outString, font, XBrushes.Black, new XRect(0, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                            }
                           
                        }

                       
                       

                    }
                }
            }
        
        public PdfDocument getOutput()
        {
            return outputDocument;
        }

        public void save(string fileName)
        {
            outputDocument.Save(fileName);
        }
    }
}
