namespace ACMDotNetCore.WinForms
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
            btnHello = new Button();
            SuspendLayout();
            // 
            // btnHello
            // 
            btnHello.BackColor = Color.FromArgb(255, 255, 128);
            btnHello.Location = new Point(259, 157);
            btnHello.Name = "btnHello";
            btnHello.Size = new Size(159, 62);
            btnHello.TabIndex = 0;
            btnHello.Text = "Hello";
            btnHello.UseVisualStyleBackColor = false;
            btnHello.Click += btnHello_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnHello);
            Name = "Form1";
            Text = "Hello Form";
            ResumeLayout(false);
        }

        #endregion

        private Button btnHello;
    }
}
