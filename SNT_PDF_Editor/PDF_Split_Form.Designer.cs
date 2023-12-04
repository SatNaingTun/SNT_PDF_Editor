namespace SNT_PDF_Editor
{
    partial class PDF_Split_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDF_Split_Form));
            this.splitFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.filename = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // splitFile
            // 
            this.splitFile.Location = new System.Drawing.Point(62, 174);
            this.splitFile.Name = "splitFile";
            this.splitFile.Size = new System.Drawing.Size(141, 23);
            this.splitFile.TabIndex = 1;
            this.splitFile.Text = "Save Split pdf files";
            this.splitFile.UseVisualStyleBackColor = true;
            this.splitFile.Click += new System.EventHandler(this.splitFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "filename";
            // 
            // filename
            // 
            this.filename.AutoSize = true;
            this.filename.Location = new System.Drawing.Point(99, 49);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(51, 13);
            this.filename.TabIndex = 2;
            this.filename.Text = "unknown";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(62, 82);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "open File";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // PDF_Split_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.filename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PDF_Split_Form";
            this.Text = "PDF_Split";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button splitFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label filename;
        private System.Windows.Forms.Button btnOpen;
    }
}