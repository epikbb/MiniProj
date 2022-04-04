using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsControlLibraryGrid;
using ModelControl;
using TreeControl;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        private UserControl1 _gridControl;
        private UserControl22 _chartControl;
        private UserControl3 _propControl;
        private TreeControl.TreeControl _treeControl;
        private ModelControl.ModelControl _modelControl;
        private bool _flag = false;

        public delegate void ClickMe();

        public Form1()
        {
            InitializeComponent();
            InitText();
            simpleButton1.Visible = false;
            _gridControl = new UserControl1();
            _chartControl = new UserControl22();
            _propControl = new UserControl3();
            _treeControl = new TreeControl.TreeControl();
            _modelControl = new ModelControl.ModelControl();

            _gridControl.Dock = DockStyle.Fill;
            _chartControl.Dock = DockStyle.Fill;
            _propControl.Dock = DockStyle.Fill;
            _treeControl.Dock = DockStyle.Fill;
            _modelControl.Dock = DockStyle.Fill;
          
            dockPanel1.ControlContainer.Controls.Add(_treeControl);
            dockPanel2.ControlContainer.Controls.Add(_modelControl);
            dockPanel3.ControlContainer.Controls.Add(_propControl);
            dockPanel4.ControlContainer.Controls.Add(_gridControl);

            _treeControl.TreeNodeMouseClick += new TreeControl.MyTreeNodeClickEventHandler(_modelControl.RenderModel);
            _modelControl.ModelClickEventHandler += new ModelControl.MyModelClickEventHandler(_propControl.SetModelNameAndVersion);
            _modelControl.ModelClickEventHandler += new ModelControl.MyModelClickEventHandler(_propControl.RenderAlgo);
            
            _modelControl.ModelClickEventHandler2 += new ModelControl.MyModelClickEventHandler2(_gridControl.Display);
            _modelControl.ModelClickEventHandler3 += new ModelControl.MyModelClickEventHandler3(this.ShowBtn);

        }
        public void ShowBtn()
        {
            simpleButton1.Visible = true;
        }

        private void InitText()
        {
            simpleButton1.Text = "Chart Run";
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

            if (simpleButton1.Text == "Chart Run")
            {
                simpleButton1.Text = "Stop";
                if (!_flag) 
                {
                    _flag = true;
                    //_chartControl = new UserControl22();
                    //_chartControl.Dock = DockStyle.Fill;
                    _chartControl.ongoing = true;
                    _chartControl.ChartWrite();
                    dockPanel5.ControlContainer.Controls.Add(_chartControl);
                }
                _chartControl.ongoing = true;

            }
            else if (simpleButton1.Text == "Stop")
            {
                simpleButton1.Text = "Chart Run";
                _chartControl.ongoing = false;
            }

        }

    }
}
