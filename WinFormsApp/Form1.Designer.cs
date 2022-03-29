namespace WinFormsApp
{
    partial class Form1
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel5_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel3 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel7_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel4 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel5 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.panelContainer1.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.dockPanel3.SuspendLayout();
            this.dockPanel4.SuspendLayout();
            this.dockPanel5.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.panelContainer1,
            this.dockPanel4,
            this.dockPanel5});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel5_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("9a5ac961-4608-4b0f-ab82-f783ecfe6f5e");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(239, 200);
            this.dockPanel1.Size = new System.Drawing.Size(239, 853);
            this.dockPanel1.Text = "dockPanel1";
            // 
            // dockPanel5_Container
            // 
            this.dockPanel5_Container.Location = new System.Drawing.Point(4, 32);
            this.dockPanel5_Container.Name = "dockPanel5_Container";
            this.dockPanel5_Container.Size = new System.Drawing.Size(229, 817);
            this.dockPanel5_Container.TabIndex = 0;
            // 
            // panelContainer1
            // 
            this.panelContainer1.Controls.Add(this.dockPanel2);
            this.panelContainer1.Controls.Add(this.dockPanel3);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.panelContainer1.ID = new System.Guid("97d12918-cf6f-408a-9b2d-57196b83c071");
            this.panelContainer1.Location = new System.Drawing.Point(239, 0);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(297, 200);
            this.panelContainer1.Size = new System.Drawing.Size(297, 853);
            this.panelContainer1.Text = "panelContainer1";
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel3_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.ID = new System.Guid("f22fb35c-aea3-404e-abae-4b00fc14ebd3");
            this.dockPanel2.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(297, 553);
            this.dockPanel2.Size = new System.Drawing.Size(297, 423);
            this.dockPanel2.Text = "dockPanel2";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Location = new System.Drawing.Point(4, 32);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(287, 385);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // dockPanel3
            // 
            this.dockPanel3.Controls.Add(this.dockPanel7_Container);
            this.dockPanel3.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel3.FloatVertical = true;
            this.dockPanel3.ID = new System.Guid("19f083c5-1e31-4d23-87ce-d5e60367862a");
            this.dockPanel3.Location = new System.Drawing.Point(0, 423);
            this.dockPanel3.Name = "dockPanel3";
            this.dockPanel3.OriginalSize = new System.Drawing.Size(297, 300);
            this.dockPanel3.Size = new System.Drawing.Size(297, 430);
            this.dockPanel3.Text = "dockPanel3";
            // 
            // dockPanel7_Container
            // 
            this.dockPanel7_Container.Location = new System.Drawing.Point(4, 32);
            this.dockPanel7_Container.Name = "dockPanel7_Container";
            this.dockPanel7_Container.Size = new System.Drawing.Size(287, 394);
            this.dockPanel7_Container.TabIndex = 0;
            // 
            // dockPanel4
            // 
            this.dockPanel4.Controls.Add(this.dockPanel2_Container);
            this.dockPanel4.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanel4.ID = new System.Guid("5fe3418d-6870-4c6f-90c5-9ddcca71547e");
            this.dockPanel4.Location = new System.Drawing.Point(536, 553);
            this.dockPanel4.Name = "dockPanel4";
            this.dockPanel4.OriginalSize = new System.Drawing.Size(200, 300);
            this.dockPanel4.Size = new System.Drawing.Size(1146, 300);
            this.dockPanel4.Text = "Chart Datas";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 34);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(1138, 262);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // dockPanel5
            // 
            this.dockPanel5.Controls.Add(this.dockPanel1_Container);
            this.dockPanel5.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel5.FloatVertical = true;
            this.dockPanel5.ID = new System.Guid("de21bd08-6d0a-4530-b41d-9b634fc70546");
            this.dockPanel5.Location = new System.Drawing.Point(536, 0);
            this.dockPanel5.Name = "dockPanel5";
            this.dockPanel5.OriginalSize = new System.Drawing.Size(508, 200);
            this.dockPanel5.Size = new System.Drawing.Size(1146, 553);
            this.dockPanel5.Text = "Predict Result Chart";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.simpleButton1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 32);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1138, 515);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(1036, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(94, 29);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Chart Run";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1682, 853);
            this.Controls.Add(this.dockPanel5);
            this.Controls.Add(this.dockPanel4);
            this.Controls.Add(this.panelContainer1);
            this.Controls.Add(this.dockPanel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.panelContainer1.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel3.ResumeLayout(false);
            this.dockPanel4.ResumeLayout(false);
            this.dockPanel5.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel5;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel3;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel7_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel5_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel4;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}

