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

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var parser = new Parser();
            /*
            system          OBJECT IDENTIFIER::= { mib - 2 1 }
            interfaces      OBJECT IDENTIFIER::= { mib - 2 2 }
            at              OBJECT IDENTIFIER::= { mib - 2 3 }
            ip              OBJECT IDENTIFIER::= { mib - 2 4 }
            icmp            OBJECT IDENTIFIER::= { mib - 2 5 }
            tcp             OBJECT IDENTIFIER::= { mib - 2 6 }
            udp             OBJECT IDENTIFIER::= { mib - 2 7 }
            egp             OBJECT IDENTIFIER::= { mib - 2 8 }
            cmot            OBJECT IDENTIFIER::= { mib - 2 9 }
            transmission    OBJECT IDENTIFIER::= { mib - 2 10 }
            snmp            OBJECT IDENTIFIER::= { mib - 2 11 }
            */      

            List<string> ObjectList = new List<string>() { "system", "interfaces", "at", "ip", "icmp", "tcp", "udp", "egp", "cmot", "transmission", "snmp" };
            foreach (var _object in ObjectList)
            {
                List<TreeNode> list = new List<TreeNode>();                     // Utwórz listę
                parser.CreateSMITreeView(ref list, _object);                    // Szukaj elementy, które mają "_object" ustawiony jako parent
                TreeNode[] array = list.ToArray();                              // Zmień listę w tablicę
                TreeNode TreeNodeSystem = new TreeNode(_object, array);         
                treeView1.Nodes.Add(TreeNodeSystem);
                foreach (var name in array)                                     // Wyświetlanie szczegółów dotyczących danego OBJECT-TYPE (Syntax, Access itp.)
                {
                    List<TreeNode> list_details = new List<TreeNode>();
                    parser.CreateSMITreeViewDetails(ref list_details, name.Text);
                    TreeNode[] tempArray = list_details.ToArray();
                    TreeNode temp = new TreeNode(name.Text, tempArray);
                    foreach (var detail in tempArray)
                    {
                        name.Nodes.Add(detail.Text);
                    }
                }
            }
          
        }
    }
}
