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
using WinFormsControlLibraryGrid;
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
            TreeNode RootNode = null;
            List<TreeNode> AreaNodes = new List<TreeNode>();
            List<TreeNode> OperNodes = new List<TreeNode>();
            List<TreeNode> EpqNodes = new List<TreeNode>();

            foreach (TreeDto tree in TreeList)
            {
                TreeNode Node = new TreeNode(tree.objName);
                Node.Name = tree.objId.ToString();
                string parentId = tree.parentObjid.ToString();

                if (tree.objType.Equals("ROOT"))
                {
                    RootNode = Node;
                }
                else if (tree.objType.Equals("AREA"))
                {
                    AreaNodes.Add(Node);
                    Node.Tag = parentId; //어떤 TreeNode의 자식 TreeNode인지 표시하기 위해 Tag에 부모노드의 Id를 넣어줌
                }
                else if (tree.objType.Equals("OPER"))
                {
                    OperNodes.Add(Node);
                    Node.Tag = parentId;
                }
                else
                {
                    EpqNodes.Add(Node);
                    Node.Tag = parentId;
                }
            }
            //Root는 이렇게 등록하는게 제일 간결
            treeView1.Nodes.Add(RootNode);
            //Area의 상위노드는 Root하나 뿐이므로 이렇게 등록
            treeView1.Nodes[0].Nodes.AddRange(AreaNodes.ToArray());
            //OPER,EQP 의 상위 노드는 여러개 이므로 따로 메서드로 treeView에 추가
            RenderTree2(AreaNodes, OperNodes);
            RenderTree2(OperNodes, EpqNodes);

        }

        private void RenderTree2(List<TreeNode> parentNodes, List<TreeNode> subNodes)
        {
            foreach (TreeNode node in parentNodes)
            {
                foreach(TreeNode subNode in subNodes)
                {
                    //부모노드의 Name(ObjId)와 자식노드의 Tag(ParentId)가 같다면 자식노드를 부모노드의 하위트리로 넣어줌
                    if (node.Name.Equals(subNode.Tag))
                    {
                        node.Nodes.Add(subNode);
                    }
                }
            }
        }

        private List<TreeDto> GetTreeData()
        {
            List<TreeDto> TreeList = HttpRequest.LocalGetRequest<TreeDto>("getTreeData");

            return TreeList;
        }

        public void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Name == null)
            {
                return;
            }
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
