using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PdfSharp.Pdf;
using System.IO;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;

namespace SNT_PDF_Editor.Function
{
   static class PdfSecurity
    {
        //PdfDocument document;
        //public void openDocument(string fileName,string password)
        //{
        //    if (File.Exists(fileName))
        //    {
        //        if (string.IsNullOrEmpty(password))
        //        {
        //            document = PdfReader.Open(fileName);
        //        }
        //        else
        //        {
        //            document = PdfReader.Open(fileName, password);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(fileName + "File Not Exist");
        //    }

        //}

        //public void openDocument(PdfDocument document)
        //{
        //    document = this.document;
        //}

        //public void makeProtectedDocument()
        //{

        //}

       public static PdfDocument protectDocument(PdfDocument document, string ownerPassword, string userPassword,bool PermitModifyDocument = false, bool PermitPrint = false)
        {
           

           document.SecuritySettings.UserPassword = userPassword;

           document.SecuritySettings.OwnerPassword = ownerPassword;

           //document.SecuritySettings.PermitAssembleDocument = false;

           document.SecuritySettings.PermitAnnotations = false;

           document.SecuritySettings.PermitAssembleDocument = false;

           document.SecuritySettings.PermitExtractContent = false;

           document.SecuritySettings.PermitFormsFill = true;

           document.SecuritySettings.PermitFullQualityPrint = PermitPrint;

           document.SecuritySettings.PermitModifyDocument = PermitModifyDocument;

           document.SecuritySettings.PermitPrint = PermitPrint;

           return document;

         }

       
    }
}
