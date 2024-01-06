using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace SNT_PDF_Editor.Function
{
   public static class PdfBookmarks
    {

        public static void addPageBookmarks(ref PdfDocument pdf)
        {
            for (int i = 0; i < pdf.PageCount; i++)
            {
                string pageName = "Page" + (i + 1).ToString();
                pdf.Outlines.Add(pageName, pdf.Pages[i]);
            }
        }

        public static PdfOutline  setBookmark(ref PdfDocument pdf,string text, PdfPage page)
        {
            PdfOutline bookmark = pdf.Outlines.Add(text, page);
            return bookmark;
        }

        public static PdfOutline setBookmark(ref PdfDocument pdf, string text, int pageIndex)
        {
            PdfOutline bookmark = pdf.Outlines.Add(text, pdf.Pages[pageIndex]);
            return bookmark;
        }

        
    }
}
