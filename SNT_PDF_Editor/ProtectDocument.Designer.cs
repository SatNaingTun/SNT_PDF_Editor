namespace SNT_PDF_Editor
{
    partial class ProtectDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProtectDocument));
            this.ownerPassword = new System.Windows.Forms.TextBox();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkModify = new System.Windows.Forms.CheckBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ownerPassword
            // 
            this.ownerPassword.Location = new System.Drawing.Point(102, 40);
            this.ownerPassword.Name = "ownerPassword";
            this.ownerPassword.Size = new System.Drawing.Size(142, 20);
            this.ownerPassword.TabIndex = 0;
            // 
            // userPassword
            // 
            this.userPassword.Location = new System.Drawing.Point(101, 90);
            this.userPassword.Name = "userPassword";
            this.userPassword.Size = new System.Drawing.Size(142, 20);
            this.userPassword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Owner Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "User Password";
            // 
            // chkModify
            // 
            this.chkModify.AutoSize = true;
            this.chkModify.Location = new System.Drawing.Point(20, 141);
            this.chkModify.Name = "chkModify";
            this.chkModify.Size = new System.Drawing.Size(57, 17);
            this.chkModify.TabIndex = 4;
            this.chkModify.Text = "Modify";
            this.chkModify.UseVisualStyleBackColor = true;
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Location = new System.Drawing.Point(102, 141);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(79, 17);
            this.chkPrint.TabIndex = 4;
            this.chkPrint.Text = "Permit Print";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "protect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProtectDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkPrint);
            this.Controls.Add(this.chkModify);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userPassword);
            this.Controls.Add(this.ownerPassword);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProtectDocument";
            this.Text = "ProtectDocument";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ownerPassword;
        private System.Windows.Forms.TextBox userPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkModify;
        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.Button button1;
    }
}