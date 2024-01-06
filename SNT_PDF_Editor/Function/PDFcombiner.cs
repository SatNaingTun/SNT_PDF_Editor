using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.IO;

namespace SNT_PDF_Editor.Function
{
    public class PDFcombiner:IPDFFunction
    {
        PdfDocument inputDocument;
        PdfDocument outputDocument=new PdfDocument();
       
       public void openDocument(string fileName)
        {
            if (File.Exists(fileName))
            {
                inputDocument = PdfReader.Open(fileName, PdfDocumentOpenMode.Import);
               
                
                for (int i = 0; i < inputDocument.PageCount; i++)
                {
                    PdfPage page = inputDocument.Pages[i];
                   PdfPage outputPage= outputDocument.AddPage(page);
                   //addFileNameBookMark(fileName, i,ref outputPage);
                   
                   if (i == 0)
                   {
                       addFileNameBookMark(fileName, outputPage);
                   }
                  
                   
                 
                   
                }
            }
            else
            {
                Console.WriteLine(fileName + "File Not Exist");
            }
            
        }

      private PdfOutline addFileNameBookMark(string fileName, PdfPage page)
       {
           //PdfOutline bookmark = outputDocument.Outlines.Add(Path.GetFileNameWithoutExtension(fileName), page);
           PdfOutline bookmark = outputDocument.Outlines.Add(Path.GetFileNameWithoutExtension(fileName), page);
           return bookmark;
       }
      
       public void openDocument(string fileName,string password)
       {
           if (File.Exists(fileName))
           {
               inputDocument = PdfReader.Open(fileName,password, PdfDocumentOpenMode.Import);
               for (int i = 0; i < inputDocument.PageCount; i++)
               {
                   PdfPage page = inputDocument.Pages[i];
                   PdfPage outputPage = outputDocument.AddPage(page);

                   if (i == 0)
                   {
                       addFileNameBookMark(fileName, outputPage);
                   }
               }
           }
           else
           {
               Console.WriteLine(fileName + "File Not Exist");
           }

       }
       public void openDocument(PdfDocument pdf)
       {
           if (pdf != null)
           {
               MemoryStream stream = new MemoryStream();
               pdf.Save(stream, false);
               inputDocument = PdfReader.Open(stream, PdfDocumentOpenMode.Import);

               for (int i = 0; i < inputDocument.PageCount; i++)
                   {
                       PdfPage page = inputDocument.Pages[i];
                       PdfPage outputPage = outputDocument.AddPage(page);
                   }
              
           }
       }
       public  PdfDocument getOutput()
       {
           return outputDocument;
       }
       public void save(string fileName)
       {
           //PDFBookmarks.addPageBookmarks(ref outputDocument);
               outputDocument.Save(fileName);
       }
    }
}
