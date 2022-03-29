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

        bool flag = false;

        public delegate void ClickMe();

        public Form1()
        {
            InitializeComponent();
            InitText();
            _gridControl = new UserControl1();
            _chartControl = new UserControl22();
            _propControl = new UserControl3();
            _gridControl.Dock = DockStyle.Fill;
            _chartControl.Dock = DockStyle.Fill;
            _propControl.Dock = DockStyle.Fill;

            dockPanel4.ControlContainer.Controls.Add(_gridControl);

            //this._gridControl.RowClick += new MyClickEventHandler(UcTree1_IClicked);
            _treeControl = new TreeControl.TreeControl();
            _modelControl = new ModelControl.ModelControl();
            _treeControl.Dock = DockStyle.Fill;
            _modelControl.Dock = DockStyle.Fill;
            _propControl.Dock = DockStyle.Fill;

            dockPanel1.ControlContainer.Controls.Add(_treeControl);
            dockPanel2.ControlContainer.Controls.Add(_modelControl);
            dockPanel3.ControlContainer.Controls.Add(_propControl);


            _treeControl.TreeNodeMouseClick += new TreeControl.MyTreeNodeClickEventHandler(_modelControl.RenderModel);
            _modelControl.ModelClickEventHandler += new ModelControl.MyModelClickEventHandler(_propControl.SetModelNameAndVersion);
            _modelControl.ModelClickEventHandler += new ModelControl.MyModelClickEventHandler(_propControl.RenderAlgo);
            _modelControl.ModelClickEventHandler += new ModelControl.MyModelClickEventHandler(_propControl.test);
        }

        private void InitText()
        {
            simpleButton1.Text = "Chart Run";
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            //simpleButton1.Visible = false;

            if (simpleButton1.Text == "Chart Run")
            {
                simpleButton1.Text = "Stop";
                if (!flag)
                {
                    flag = true;
                    _chartControl = new UserControl22();
                    _chartControl.Dock = DockStyle.Fill;
                    _chartControl.ongoing = true;
                    dockPanel5.ControlContainer.Controls.Add(_chartControl);
                }
                _chartControl.ongoing = true;

            }
            else if (simpleButton1.Text == "Stop")
            {
                simpleButton1.Text = "Chart Run";
                _chartControl.ongoing = false;

                //UserControl22 userControl22 = new UserControl22();
                //chartControl.userTimer;
                //WinFormsControlLibraryGrid.UserControl22.con.timer.Stop();

            }

        }

    }
}