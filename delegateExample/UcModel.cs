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
    public partial class UcModel : UserControl
    {
        public UcModel()
        {
            InitializeComponent();
        }


        public void Icalled(string text)
        {
            MessageBox.Show(text);
        }
    }
}
