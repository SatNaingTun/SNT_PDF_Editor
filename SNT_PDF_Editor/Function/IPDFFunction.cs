using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SNT_PDF_Editor.Function
{
    interface IPDFFunction
    {
         void openDocument(string fileName);
         void save(string fileName);

    }
}
