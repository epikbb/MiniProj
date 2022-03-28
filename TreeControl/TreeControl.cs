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

namespace TreeControl
{
    public delegate void MyTreeNodeClickEventHandler(string str);
    public partial class TreeControl : UserControl
    {
        public event MyTreeNodeClickEventHandler TreeNodeMouseClick;

        public TreeControl()
        {
            InitializeComponent();
            RenderTree();
        }

        private void RenderTree()
        {
            List<TreeDto> TreeList = GetTreeData();
            List<TreeDto> AreaList = new List<TreeDto>();
            List<TreeDto> OperList = new List<TreeDto>();
            List<TreeDto> EqpList = new List<TreeDto>();

            foreach (TreeDto tree in TreeList)
            {
                if (tree.objType.Equals("ROOT"))
                {
                    treeView1.Nodes.Add(tree.objName);
                }
                else if (tree.objType.Equals("AREA"))
                {
                    treeView1.Nodes[0].Nodes.Add(tree.objName).Name = tree.objId.ToString();
                }
                else if (tree.objType.Equals("OPER"))
                {
                    for (int i = 0; i < treeView1.Nodes[0].Nodes.Count; i++)
                    {
                        if (treeView1.Nodes[0].Nodes[i].Name.Equals(tree.parentObjid.ToString()))
                        {
                            treeView1.Nodes[0].Nodes[i].Nodes.Add(tree.objName).Name = tree.objId.ToString();
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < treeView1.Nodes[0].Nodes.Count; i++)
                    {
                        for (int j = 0; j < treeView1.Nodes[0].Nodes[i].Nodes.Count; j++)
                        {
                            if (treeView1.Nodes[0].Nodes[i].Nodes[j].Name.Equals(tree.parentObjid.ToString()))
                            {
                                treeView1.Nodes[0].Nodes[i].Nodes[j].Nodes.Add(tree.objName).Name = tree.objId.ToString();
                            }

                        }
                    }
                }
            }
        }

        private List<TreeDto> GetTreeData()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest
        .Create("http://127.0.0.1:8081/getTreeData");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stReadData = response.GetResponseStream();
            StreamReader srReadData = new StreamReader(stReadData, Encoding.UTF8);

            string strResult = srReadData.ReadToEnd();
            List<TreeDto> TreeList = JsonConvert.DeserializeObject<List<TreeDto>>(strResult);

            return TreeList;
        }

        public void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.TreeNodeMouseClick(e.Node.Name);
        }
    }

    public class TreeDto
    {
        public int objId { get; set; }
        public string objName { get; set; }
        public string objType { get; set; }
        public int? parentObjid { get; set; }
    }
}
