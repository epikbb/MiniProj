using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace ModelControl
{
    public delegate void MyModelClickEventHandler(string name, string version);
    public delegate void MyModelClickEventHandler2();
    public delegate void MyModelClickEventHandler3();

    public partial class ModelControl : UserControl
    {
        public event MyModelClickEventHandler ModelClickEventHandler;
        public event MyModelClickEventHandler2 ModelClickEventHandler2;
        public event MyModelClickEventHandler3 ModelClickEventHandler3;
        
        public ModelControl()
        {
            InitializeComponent();
        }

        public void RenderModel(string NodeName)
        {
            List<ModelDto> Models = new List<ModelDto>();

            Models = GetModelData(NodeName);
            DataTable dt = new DataTable();
            dt.Columns.Add("Model Name", typeof(string));
            dt.Columns.Add("Model Version", typeof(string));

            foreach (ModelDto model in Models)
            {
                dt.Rows.Add(model.modelName, model.modelVersion);
            }

            this.modelGridView1.DataSource = dt;
        }

        private List<ModelDto> GetModelData(string NodeName)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest
        .Create("http://127.0.0.1:8081/getModelData?objId=" + NodeName);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stReadData = response.GetResponseStream();
            StreamReader srReadData = new StreamReader(stReadData, Encoding.UTF8);

            string strResult = srReadData.ReadToEnd();
            List<ModelDto> ModelList = JsonConvert.DeserializeObject<List<ModelDto>>(strResult);

            return ModelList;
        }

        private void modelGridView1_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.ModelClickEventHandler((string)modelGridView1.Rows[e.RowIndex].Cells[0].Value, (string)modelGridView1.Rows[e.RowIndex].Cells[1].Value);
            this.ModelClickEventHandler2();
            this.ModelClickEventHandler3();
        }
    }

    public class ModelDto
    {
        public string modelName { get; set; }
        public string modelVersion { get; set; }
    }
}