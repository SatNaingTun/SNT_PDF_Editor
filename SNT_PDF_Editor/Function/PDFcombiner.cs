﻿using System;
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
           outputDocument.Save(fileName);
       }
    }
}
