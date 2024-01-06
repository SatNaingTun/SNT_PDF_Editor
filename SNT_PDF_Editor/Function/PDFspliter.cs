using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.IO;

namespace SNT_PDF_Editor.Function
{
  public class PDFspliter:IPDFFunction
    {
        PdfDocument inputDocument;
        PdfDocument outputDocument = new PdfDocument();

        public void openDocument(string fileName)
        {
            if (File.Exists(fileName))
            {
                inputDocument = PdfReader.Open(fileName, PdfDocumentOpenMode.Import);
                for (int i = 0; i < inputDocument.PageCount; i++)
                {
                    PdfPage page = inputDocument.Pages[i];
                    outputDocument.AddPage(page);
                }
            }
            else
            {
                Console.WriteLine(fileName + "File Not Exist");
            }
        }
        public void openDocument(string fileName, string password)
        {
            if (File.Exists(fileName))
            {
                inputDocument = PdfReader.Open(fileName, password, PdfDocumentOpenMode.Import);
                for (int i = 0; i < inputDocument.PageCount; i++)
                {
                    PdfPage page = inputDocument.Pages[i];
                    outputDocument.AddPage(page);
                }
            }
            else
            {
                Console.WriteLine(fileName + "File Not Exist");
            }

        }

        public void save(string fileName)
        {
            //FileInfo fileInfo = new FileInfo(fileName);
            if (outputDocument != null) 
            for (int i = 0; i < inputDocument.PageCount; i++)
            {
                PdfDocument document = new PdfDocument();
                PdfPage page = outputDocument.Pages[i];
                  document.AddPage(page);
                //document.Save(fileInfo.DirectoryName+"\\"+fileInfo.Name + " Page" + i + 1+fileInfo.Extension);
                  document.Save(Path.GetDirectoryName(fileName) + "\\" + Path.GetFileNameWithoutExtension(fileName) + " Page" + (i+1).ToString() + ".pdf");
                
            }
        }
        public IEnumerable<PdfDocument> getOutput()
        {
            if (outputDocument != null)
                for (int i = 0; i < inputDocument.PageCount; i++)
                {
                    PdfDocument document = new PdfDocument();
                    PdfPage page = outputDocument.Pages[i];
                    document.AddPage(page);
                    //document.Save(fileInfo.DirectoryName+"\\"+fileInfo.Name + " Page" + i + 1+fileInfo.Extension);
                    yield return document;
                }
            else
               yield return null;
        }
    }
}
