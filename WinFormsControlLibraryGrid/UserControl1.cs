﻿using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsControlLibraryGrid
{
    public partial class UserControl1 : UserControl
    {
        GridView view;
        public event RowClickEventHandler RowClick;

        public UserControl1()
        {
            InitializeComponent();
            Display();
            view.RowClick += gridView1_RowClick;
        }

        public void Display()
        {
            string dataList = HttpRequest.GetRawDataList();
            dynamic dynamicObject = JsonConvert.DeserializeObject(dataList);
  
            gridControl.DataSource = dynamicObject;
            gridControl.ForceInitialize();

          
            view = gridControl.FocusedView as GridView;
            view.PopulateColumns();
            //그룹 패널의 열 그룹화 옵션 false 
            GridOptionsMenu optionsMenu = new GridOptionsMenu();
            optionsMenu.EnableGroupPanelMenu = false;

            view.OptionsView.ShowGroupPanel = true;
            view.GroupPanelText = " ";
            
            string[] name = { "Measure Time", "Wafer Number", "Actual Value", "Predict Value", "Accuracy", "Lot ID" };
            for (int i = 0; i < view.Columns.Count; i++)
            {
                view.Columns[i].Caption = name[i];
            }
        }


        

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            MessageBox.Show("dd");
        }

    }
    
}
