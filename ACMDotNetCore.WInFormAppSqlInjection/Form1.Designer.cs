namespace ACMDotNetCore.WInFormAppSqlInjection
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtemail = new TextBox();
            txtpass = new TextBox();
            btnlog = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtemail
            // 
            txtemail.Location = new Point(237, 50);
            txtemail.Name = "txtemail";
            txtemail.Size = new Size(245, 31);
            txtemail.TabIndex = 0;
            // 
            // txtpass
            // 
            txtpass.Location = new Point(237, 113);
            txtpass.Name = "txtpass";
            txtpass.Size = new Size(245, 31);
            txtpass.TabIndex = 1;
            txtpass.UseSystemPasswordChar = true;
            // 
            // btnlog
            // 
            btnlog.Location = new Point(237, 176);
            btnlog.Name = "btnlog";
            btnlog.Size = new Size(112, 34);
            btnlog.TabIndex = 2;
            btnlog.Text = "LogIn";
            btnlog.UseVisualStyleBackColor = true;
            btnlog.Click += btnlog_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(105, 56);
            label1.Name = "label1";
            label1.Size = new Size(54, 25);
            label1.TabIndex = 3;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(105, 119);
            label2.Name = "label2";
            label2.Size = new Size(87, 25);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnlog);
            Controls.Add(txtpass);
            Controls.Add(txtemail);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtemail;
        private TextBox txtpass;
        private Button btnlog;
        private Label label1;
        private Label label2;
    }
}
