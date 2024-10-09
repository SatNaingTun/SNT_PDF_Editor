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
                //outputDocument.Info.Title = Path.GetFileNameWithoutExtension(fileName);
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
                //page.Width = img.Size.Width;
                //page.Height = img.Size.Height;
                XGraphics gfx = XGraphics.FromPdfPage(page);
                if (img.Size.Width <= 842)//A4 height
                    gfx.DrawImage(img, 0, 0); // don't scale
                    
                else
                {
                    //double Scale = img.Size.Width / 842.0;
                    //gfx.DrawImage(img, 0, 0, (int)(img.Size.Width / Scale), (int)(img.Size.Height / Scale));//scale to A4
                    if (img.Size.Height >page.Height.Value)
                    {
                        XRect box = new XRect(0, 0, page.Width.Value, page.Height.Value);
                        gfx.DrawImage(img, box);
                    }
                    else
                    {
                        XRect box = new XRect(0, 0, page.Width.Value, img.Size.Height);
                        gfx.DrawImage(img, box);
                    }
                   
                }
                //gfx.DrawImage(img, 0, 0, page.Width, page.Height);
                //gfx.DrawImage(img, 0, 0);


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
                        if (yPoint > page.Height.Point)
                        {
                            page = outputDocument.AddPage();
                             gfx = XGraphics.FromPdfPage(page);
                             yPoint = 0;
                        }
                        
                            XFont font = new XFont("Times New Roman", 10, XFontStyleEx.Regular);
                            gfx.DrawString(ln, font, XBrushes.Black, new XRect(0, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                            if (gfx.MeasureString(ln, font).Width > page.Width.Point)
                            {
                                yPoint += 20;
                                string inString = ln.Substring(0,Convert.ToInt16( ln.Length * page.Width.Point / gfx.MeasureString(ln, font).Width)-3);
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
