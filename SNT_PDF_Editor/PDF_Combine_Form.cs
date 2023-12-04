using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SNT_PDF_Editor.Function;


namespace SNT_PDF_Editor
{
    public partial class PDF_Combine_Form : Form
    {
        private int rowIndex = 0;

        public PDF_Combine_Form()
        {
            InitializeComponent();
        }
        public PDF_Combine_Form(string[] args)
        {
            InitializeComponent();
            foreach (string item in args)
            {
                addFile2Grid(item);
            }
        }

        private void addFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                addFile2Grid(fileDialog.FileName);
            }
        }
        public void addFile2Grid(string fileName)
        {
           // MessageBox.Show(fileName);
            try
            {
                if (Directory.Exists(fileName)||File.Exists(fileName))
                {
                    FileInfo fileInfo = new FileInfo(fileName);
                    
                    if (fileInfo.Extension == ".pdf")
                    {
                        dataGridView1.Rows.Add(fileInfo.Name, fileInfo.Length, fileName);

                        if (dataGridView1.InvokeRequired)
                            dataGridView1.Invoke(new Action(() =>
                            {
                                dataGridView1.Rows.Add(fileInfo.Name, fileInfo.Length, fileName);

                            }));
                    }
                    if (dataGridView1.InvokeRequired)
                        dataGridView1.Invoke(new Action(() =>
                        {
                            dataGridView1.Refresh(); 

                        }));
                   

                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"SNT PDF Editor");
            }
        }
        public void addFiles2Grid(string[] files)
        {
            foreach (var item in files)
            {
                addFile2Grid((string)item);
            }
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
             string[] dropFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
             foreach (string file in dropFiles)
             {
                 string ext = Path.GetExtension(file);
                 if (ext == ".pdf")
                 {
                     string fileName = Path.GetFullPath(file);
                     addFile2Grid(fileName);
                    
                 }
             }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (!this.dataGridView1.Rows[this.rowIndex].IsNewRow)
            {
                this.dataGridView1.Rows.RemoveAt(this.rowIndex);
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                e.Effect = DragDropEffects.All;
        }

        private void btnCombine_Click(object sender, EventArgs e)
        {
           
           PDFcombiner combiner = new PDFcombiner();
           foreach (DataGridViewRow row in  dataGridView1.Rows)
           {
               string filePath = (string)row.Cells["FilePath"].Value;
              combiner.addDocument(filePath);
           }
           SaveFileDialog saveFileDialog = new SaveFileDialog();
           saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
           if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
           {
               combiner.save(saveFileDialog.FileName);
           }
           

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int myIndex = dataGridView1.Rows.IndexOf(dataGridView1.CurrentRow);
                if (myIndex == 0) return;
                DataGridViewRow myRow = dataGridView1.CurrentRow;

                dataGridView1.Rows.Remove(myRow);
                dataGridView1.Rows.Insert(myIndex - 1, myRow);

               
                dataGridView1.CurrentCell = myRow.Cells[0];
            }
            
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int totalCount = dataGridView1.Rows.Count;
                int myIndex = dataGridView1.Rows.IndexOf(dataGridView1.CurrentRow);
                if (myIndex == totalCount - 1) return;
                DataGridViewRow myRow = dataGridView1.CurrentRow;

                dataGridView1.Rows.Remove(myRow);
                dataGridView1.Rows.Insert(myIndex + 1, myRow);

             
                dataGridView1.CurrentCell = myRow.Cells[0];
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.InvokeRequired)
                dataGridView1.Invoke(new Action(() =>
                {
                    dataGridView1.Refresh();

                }));
        }
    }
}
