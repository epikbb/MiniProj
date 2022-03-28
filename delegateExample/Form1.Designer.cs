namespace delegateExample
{
    partial class Form1
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
            this.ucTree1 = new delegateExample.UcTree();
            this.ucModel1 = new delegateExample.UcModel();
            this.SuspendLayout();
            // 
            // ucTree1
            // 
            this.ucTree1.BackColor = System.Drawing.Color.Red;
            this.ucTree1.Location = new System.Drawing.Point(61, 70);
            this.ucTree1.Name = "ucTree1";
            this.ucTree1.Size = new System.Drawing.Size(224, 249);
            this.ucTree1.TabIndex = 0;
            // 
            // ucModel1
            // 
            this.ucModel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ucModel1.Location = new System.Drawing.Point(379, 83);
            this.ucModel1.Name = "ucModel1";
            this.ucModel1.Size = new System.Drawing.Size(399, 221);
            this.ucModel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucModel1);
            this.Controls.Add(this.ucTree1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UcTree ucTree1;
        private UcModel ucModel1;
    }
}