using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PdfSharp.Pdf;

namespace SNT_PDF_Editor.Function
{
    interface IPDFFunction
    {
         void openDocument(string fileName);
         void save(string fileName);
       

    }
}
