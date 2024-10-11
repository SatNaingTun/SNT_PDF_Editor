using PdfSharp.Pdf;
using SNT_PDF_Editor.Function;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SNT_PDF_Editor
{
    public partial class Images2PDF : Form
    {
        //PdfSharp.Pdf.PdfDocument pdfDocument=new PdfSharp.Pdf.PdfDocument();
        PDFConverter converter = new PDFConverter();
        double yPoint = 0;int count=0;
        public Images2PDF()
        {
            InitializeComponent();
            converter.newDocument();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Insert a image";
            //ofd.Filter = "Save an image";
            ofd.Filter = @"(*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.gif;*.ico)|*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.gif;*.ico|
                             jpg file(*.jpg)|*.jpg|
                        jpeg file(*.jpeg)|*.jpeg|
                        png(*.png)|*.png|
                         Bitmap(*.bmp)|*.bmp|
                        Tagged Image File Format(*.tiff)|*.tiff|
                         Graphics Interchange Format(*.gif)|*.gif|
                          Icon Format(*.ico)|*.ico";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //if (pictureBox1.Image == null)
                //{
                //    pictureBox1.Image = Image.FromFile(ofd.FileName);

                //}
                if(pictureBox1 != null)
                {
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
                

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (pictureBox1.Image != null&& string.IsNullOrEmpty(title.Text))
            //{

             count++;
                converter.addPictureAndTitle(pictureBox1.Image,ref yPoint,ref count,title.Text);
            lblCount.Text = count.ToString();
            //}

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                converter.save(saveFileDialog.FileName);
                converter.newDocument();
                yPoint = 0;
            }
        }

        private void lblCount_TextChanged(object sender, EventArgs e)
        {
            if(count > 0)
            {
                btnSave.Visible = true;
            }
        }
    }
}
