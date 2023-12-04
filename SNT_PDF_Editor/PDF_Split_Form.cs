using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SNT_PDF_Editor.Function;

namespace SNT_PDF_Editor
{
    public partial class PDF_Split_Form : Form
    {
        public PDF_Split_Form()
        {
            InitializeComponent();
        }
        public PDF_Split_Form(string arg)
        {
            InitializeComponent();
            filename.Text = arg;
        }

        private void splitFile_Click(object sender, EventArgs e)
        {

            PDFspliter spliter = new PDFspliter();
            spliter.openDocument(filename.Text);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               
                spliter.save(saveFileDialog.FileName);
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename.Text = fileDialog.FileName;
            }
        }

    }
}
