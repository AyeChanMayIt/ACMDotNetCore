namespace ACMDotNetCore.WinForms
{
    partial class FrmBlog
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
            lbltitle = new Label();
            lblauthor = new Label();
            lblContent = new Label();
            txttitle = new TextBox();
            txtauthor = new TextBox();
            txtcontent = new TextBox();
            btnsave = new Button();
            btnCancle = new Button();
            btnupdate = new Button();
            SuspendLayout();
            // 
            // lbltitle
            // 
            lbltitle.AutoSize = true;
            lbltitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbltitle.Location = new Point(50, 34);
            lbltitle.Name = "lbltitle";
            lbltitle.Size = new Size(58, 28);
            lbltitle.TabIndex = 0;
            lbltitle.Text = "Title :";
            // 
            // lblauthor
            // 
            lblauthor.AutoSize = true;
            lblauthor.Location = new Point(50, 134);
            lblauthor.Name = "lblauthor";
            lblauthor.Size = new Size(76, 25);
            lblauthor.TabIndex = 1;
            lblauthor.Text = "Author :";
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Location = new Point(50, 223);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(84, 25);
            lblContent.TabIndex = 1;
            lblContent.Text = "Content :";
            // 
            // txttitle
            // 
            txttitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txttitle.Location = new Point(50, 69);
            txttitle.Name = "txttitle";
            txttitle.Size = new Size(360, 34);
            txttitle.TabIndex = 2;
            // 
            // txtauthor
            // 
            txtauthor.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtauthor.Location = new Point(50, 162);
            txtauthor.Name = "txtauthor";
            txtauthor.Size = new Size(360, 34);
            txtauthor.TabIndex = 2;
            // 
            // txtcontent
            // 
            txtcontent.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtcontent.Location = new Point(48, 254);
            txtcontent.Multiline = true;
            txtcontent.Name = "txtcontent";
            txtcontent.Size = new Size(360, 119);
            txtcontent.TabIndex = 2;
            // 
            // btnsave
            // 
            btnsave.BackColor = Color.Lime;
            btnsave.Location = new Point(97, 418);
            btnsave.Name = "btnsave";
            btnsave.Size = new Size(112, 34);
            btnsave.TabIndex = 3;
            btnsave.Text = "Save";
            btnsave.UseVisualStyleBackColor = false;
            btnsave.Click += btnsave_Click;
            // 
            // btnCancle
            // 
            btnCancle.Location = new Point(215, 418);
            btnCancle.Name = "btnCancle";
            btnCancle.Size = new Size(112, 34);
            btnCancle.TabIndex = 3;
            btnCancle.Text = "Cancle";
            btnCancle.UseVisualStyleBackColor = true;
            btnCancle.Click += btnCancle_Click;
            // 
            // btnupdate
            // 
            btnupdate.BackColor = Color.FromArgb(128, 128, 255);
            btnupdate.Location = new Point(97, 418);
            btnupdate.Name = "btnupdate";
            btnupdate.Size = new Size(112, 34);
            btnupdate.TabIndex = 3;
            btnupdate.Text = "Update";
            btnupdate.UseVisualStyleBackColor = false;
            btnupdate.Visible = false;
            btnupdate.Click += btnupdate_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(479, 494);
            Controls.Add(btnCancle);
            Controls.Add(btnupdate);
            Controls.Add(btnsave);
            Controls.Add(txtcontent);
            Controls.Add(txtauthor);
            Controls.Add(txttitle);
            Controls.Add(lblContent);
            Controls.Add(lblauthor);
            Controls.Add(lbltitle);
            Name = "FrmBlog";
            Text = "Blog Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbltitle;
        private Label lblauthor;
        private Label lblContent;
        private TextBox txttitle;
        private TextBox txtauthor;
        private TextBox txtcontent;
        private Button btnsave;
        private Button btnCancle;
        private Button btnupdate;
    }
}