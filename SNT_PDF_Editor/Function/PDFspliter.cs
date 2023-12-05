using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.IO;

namespace SNT_PDF_Editor.Function
{
  public class PDFspliter
    {
        PdfDocument inputDocument;

        public void openDocument(string fileName)
        {
            inputDocument = PdfReader.Open(fileName, PdfDocumentOpenMode.Import);
        }
        public void save(string fileName)
        {
            //FileInfo fileInfo = new FileInfo(fileName);
            if (inputDocument != null) 
            for (int i = 0; i < inputDocument.PageCount; i++)
            {
                PdfDocument document = new PdfDocument();
                  PdfPage page = inputDocument.Pages[i];
                  document.AddPage(page);
                //document.Save(fileInfo.DirectoryName+"\\"+fileInfo.Name + " Page" + i + 1+fileInfo.Extension);
                  document.Save(Path.GetDirectoryName(fileName) + "\\" + Path.GetFileNameWithoutExtension(fileName) + " Page" + (i+1).ToString() + ".pdf");
            }
        }
    }
}
