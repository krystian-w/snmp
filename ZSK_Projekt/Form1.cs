using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZSK_Projekt.SMIParser;

namespace ZSK_Projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void CreateSMITree(List<MIBObjectType> MIBObjects, string name)
        {
            foreach (var mib in MIBObjects)
            {
                // Wykorzystanie mib.parent oraz mib.oID do określenia odpowiedniego oID
                mib.oID = "123";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var parser = new Parser();

            //List<string> ObjectList = new List<string>() { "system", "interfaces", "at", "ip", "icmp", "tcp", "udp", "egp", "cmot", "transmission", "snmp" };
            // Lista OBJECT IDENTIFIER:
            List<string> ObjecIdentifiertList = new List<string>();
            parser.CreateOIList(ref ObjecIdentifiertList);

            foreach (var _object in ObjecIdentifiertList)
            {
                List<TreeNode> list = new List<TreeNode>();                     // Utwórz listę
                parser.CreateSMITreeView(ref list, _object);                    // Szukaj elementy, które mają "_object" ustawiony jako parent
                TreeNode[] array = list.ToArray();                              // Zmień listę w tablicę
                TreeNode TreeNodeSystem = new TreeNode(_object, array);         
                treeView1.Nodes.Add(TreeNodeSystem);
            }
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                txtName.Text = "";
                txtOID.Text = "";
                txtSyntax.Text = "";
                txtAccess.Text = "";
                txtStatus.Text = "";
                txtMin.Text = "";
                txtMax.Text = "";

                var parser = new Parser();
                // name ; oid ; syntax ; access ; status ; min ; max
                txtName.Text = parser.displayText(treeView1.SelectedNode.Text.ToString(),"name");
                txtOID.Text = parser.displayText(treeView1.SelectedNode.Text.ToString(),"oid");
                txtSyntax.Text = parser.displayText(treeView1.SelectedNode.Text.ToString(), "syntax");
                txtAccess.Text = parser.displayText(treeView1.SelectedNode.Text.ToString(), "access");
                txtStatus.Text = parser.displayText(treeView1.SelectedNode.Text.ToString(), "status");
                txtMin.Text = (Int32.Parse(parser.displayText(treeView1.SelectedNode.Text, "min")) == -1) ? "" : parser.displayText(treeView1.SelectedNode.Text.ToString(), "min");
                txtMax.Text = (Int32.Parse(parser.displayText(treeView1.SelectedNode.Text, "max")) == -1) ? "" : parser.displayText(treeView1.SelectedNode.Text.ToString(), "max");
            }
            catch { }

        }
    }
}
