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

        Parser parser = new Parser();

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
                txtValues.Text = "";
                
                // name ; oid ; syntax ; access ; status ; min ; max
                txtName.Text = parser.displayText(treeView1.SelectedNode.Text.ToString(),"name");
                txtOID.Text = parser.displayText(treeView1.SelectedNode.Text.ToString(),"oid");
                txtSyntax.Text = parser.displayText(treeView1.SelectedNode.Text.ToString(), "syntax");
                txtAccess.Text = parser.displayText(treeView1.SelectedNode.Text.ToString(), "access");
                txtStatus.Text = parser.displayText(treeView1.SelectedNode.Text.ToString(), "status");
                txtMin.Text = (Int32.Parse(parser.displayText(treeView1.SelectedNode.Text, "min")) == -1) ? "" : parser.displayText(treeView1.SelectedNode.Text.ToString(), "min");
                txtMax.Text = (Int32.Parse(parser.displayText(treeView1.SelectedNode.Text, "max")) == -1) ? "" : parser.displayText(treeView1.SelectedNode.Text.ToString(), "max");
                txtValues.Text = parser.displayText(treeView1.SelectedNode.Text.ToString(), "values");
            }
            catch { }

        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            BERCoder(txtOID.Text, txtValue.Text);
        }

        public void BERCoder(string OID, string value)
        {
            foreach (var MIB in parser.MIBObjects)
            {
                ASN1Type asn1type;
                
                if (MIB.oID == OID)
                {
                    // Kodowanie pola TAG
                        int TAG = 0;
                        // Encode INTEGER (2)
                        if (MIB.syntax == "INTEGER")
                        {
                            asn1type = ASN1Type.Integer;
                            TAG = TAG + (int)asn1type;
                        }

                        // Encode OCTET STRING (4)
                        if (MIB.syntax == "OCTET STRING" || MIB.syntax == "DisplayString" || MIB.syntax == "PhysAddress")
                        {
                            asn1type = ASN1Type.OctetString;
                            TAG = TAG + (int)asn1type;
                        }

                        // Encode OBJECT IDENTIFIER (6)
                        if (MIB.syntax == "OBJECT IDENTIFIER")
                        {
                            asn1type = ASN1Type.ObjectIdentifier;
                            TAG = TAG + (int)asn1type;
                        }

                        // Encode IpAddress (64)
                        if (MIB.syntax == "IpAddress")
                        {
                            asn1type = ASN1Type.IpAddress;
                            TAG = TAG + (int)asn1type;
                        }

                        // Encode Counter (65)
                        if (MIB.syntax == "Counter")
                        {
                            asn1type = ASN1Type.Counter;
                            TAG = TAG + (int)asn1type;
                        }

                        // encode Gauge (66)
                        if (MIB.syntax == "Gauge")
                        {
                            asn1type = ASN1Type.Gauge;
                            TAG = TAG + (int)asn1type;
                        }

                        // Encode TimeTicks (67)
                        if (MIB.syntax == "TimeTicks")
                        {
                            asn1type = ASN1Type.TimeTicks;
                            TAG = TAG + (int)asn1type;
                        }

                        //txtBer.Text = TAG.ToString();
                         string strTAG = string.Format("{0:x2}", TAG).ToString();

                    // Kodowanie pola LENGTH
                        int LENGTH = 0;
                        // Sprawdzenie rozmiaru wartości
                        //int size = value.Length * sizeof(Char);
                        int size = System.Text.ASCIIEncoding.ASCII.GetByteCount(value); // Sparwdzenie długości                      
                                                                                        // Zamiana wartosci na HEX:
                        byte[] byteValue = Encoding.Default.GetBytes(value);
                        var hexValue = BitConverter.ToString(byteValue);
                        hexValue = hexValue.Replace("-", "");

                        if (size < 127)
                        {
                            LENGTH = size;
                        }
                        else
                        {
                        }
                    string strLENGTH = string.Format("{0:x2}", LENGTH).ToString();

                    txtBer.Text = string.Concat(strTAG, strLENGTH, hexValue);
                }
            }
        }
    }
}
