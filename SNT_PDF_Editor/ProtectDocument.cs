using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PdfSharp.Pdf;
using SNT_PDF_Editor.Function;


namespace SNT_PDF_Editor
{
    public partial class ProtectDocument : Form
    {
         PdfDocument document;

        public ProtectDocument()
        {
            InitializeComponent();
        }
        public ProtectDocument(PdfDocument document)
        {
            InitializeComponent();
            this.document = document;
        }
        public PdfDocument getProtectedDocument()
        {
            return document;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ownerPassword.Text)) throw new  ArgumentNullException();
             
            //document.protect(ownerPassword.Text,userPassword.Text,chkModify.Checked,chkPrint.Checked);
            document = PdfSecurity.protectDocument(document, ownerPassword.Text, userPassword.Text, chkModify.Checked, chkPrint.Checked);

           this.DialogResult = DialogResult.OK;
        }
    }
}
