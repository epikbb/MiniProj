namespace ModelControl
{
    partial class ModelControl
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.modelGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.modelGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // modelGridView1
            // 
            this.modelGridView1.AllowUserToAddRows = false;
            this.modelGridView1.AllowUserToDeleteRows = false;
            this.modelGridView1.AllowUserToOrderColumns = true;
            this.modelGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.modelGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.modelGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelGridView1.Location = new System.Drawing.Point(0, 0);
            this.modelGridView1.Name = "modelGridView1";
            this.modelGridView1.RowHeadersWidth = 51;
            this.modelGridView1.RowTemplate.Height = 27;
            this.modelGridView1.Size = new System.Drawing.Size(800, 450);
            this.modelGridView1.TabIndex = 0;
            this.modelGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.modelGridView1_RowHeaderMouseDoubleClick_1);
            // 
            // ModelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ModelControl";
            this.Size = new System.Drawing.Size(800, 450);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.modelGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView modelGridView1;
    }
}
