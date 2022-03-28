using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace delegateExample
{

    public partial class UcTree : UserControl
    {
        public event MyClickEventHandler IClicked; // Declear Event 

        public UcTree()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //ex)Tree에서 노드가 더블클릭 될 때
        {
            this.IClicked(((Button)sender).Text); //Rise Event
        }
    }
}
