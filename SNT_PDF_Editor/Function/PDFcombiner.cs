using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace SNT_PDF_Editor.Function
{
    public class PDFcombiner
    {
        PdfDocument inputDocument;
        PdfDocument outputDocument=new PdfDocument();
       
       public void addDocument(string fileName)
        {
            inputDocument = PdfReader.Open(fileName, PdfDocumentOpenMode.Import);
            for (int i = 0; i < inputDocument.PageCount; i++)
            {
                PdfPage page = inputDocument.Pages[i];
                outputDocument.AddPage(page);
            }
        }
       public void save(string fileName)
       {
           outputDocument.Save(fileName);
       }
    }
}
