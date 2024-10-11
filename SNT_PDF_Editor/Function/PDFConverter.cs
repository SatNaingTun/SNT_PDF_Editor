using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;

namespace SNT_PDF_Editor.Function
{
    class PDFConverter:IPDFFunction
    {
        PdfDocument outputDocument;

        public void openDocument(string fileName)
        {
            outputDocument = new PdfDocument();
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
        public void newDocument()
        { 
            outputDocument = new PdfDocument(); 
        }
        private void readPicture(string fileName,bool isNewPage=false)
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
        public void addPictureAndTitle(Image image,ref double yPoint,ref int count,string title="")
        {
            PdfPage page;
            
            if (outputDocument.Pages.Count == 0)
            {
                 page = outputDocument.AddPage();
            }
            
            else
            {
                 page = outputDocument.Pages[0];
                //if (yPoint-40+(page.Height.Point/2) >= page.Height.Point)
                if(count%2==1 && yPoint>0)
                {
                    page = outputDocument.AddPage();
                    yPoint = 0;
                }
            }
            
            if (string.IsNullOrEmpty(title) != true)
            {
                
                XGraphics gfx = XGraphics.FromPdfPage(page);
               
                XFont font = new XFont("Times New Roman", 12, XFontStyleEx.Bold);
                gfx.DrawString(title, font, XBrushes.Black, new XRect(0, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                gfx.Dispose();
                yPoint += 20;

            }
            if (image!=null)
            { 
                using (XImage xImage = XImage.FromStream(image.toStream()))
                {
                XGraphics gfx = XGraphics.FromPdfPage(page);
                    //yPoint += 20;
                    XRect box = new XRect(0, yPoint, page.Width.Value, (page.Height.Value/2)-40);
                gfx.DrawImage(xImage, box);
                gfx.Dispose();
                yPoint = (page.Height.Value / 2);

                }
            }

        }
        
        private void readTextFile(string fileName, double yPoint = 0)
        {
            PdfPage page = outputDocument.AddPage();
           
            using (StreamReader file = new StreamReader(fileName))
            {
                string ln;
                
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
