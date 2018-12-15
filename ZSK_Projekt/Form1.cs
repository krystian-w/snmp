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
                txtValue.Text = "";
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
            // Jeżeli pusta wartość
            if (value == "")
            {
                txtBer.Text = "Empty Value";
                return;
            }

            foreach (var MIB in parser.MIBObjects)
            {
                // Jeżeli pusty syntax

                if (MIB.oID == OID)
                {
                    // Kodowanie pola TAG
                    int TAG = 0;
                    TAG = returnTAG(MIB);               
                    // Zamiana TAG na HEX
                    string strTAG = string.Format("{0:x2}", TAG).ToString();

                    // Kodowanie pola LENGTH
                    int LENGTH = 0;

                    // Zamiana wartosci na HEX:
                    string hexValue = "";
                    if (MIB.syntax == "INTEGER" || MIB.syntax == "TimeTicks") // Jeżeli INTEGER
                    {
                        int intValue;
                        if (value.StartsWith("-")) // jeżeli liczba jest ujemna
                        {
                            string valueRemoveFirstChar = value.Remove(0, 1);       // usuń '-' na początku
                            intValue = Int32.Parse(valueRemoveFirstChar) * -1;      // zamień string na liczbę ujemną
                            hexValue = Convert.ToString(intValue, 16);              // przedstawienie wartości jako HEX
                            LENGTH = returnPOW(valueRemoveFirstChar);               // Szukanie ilości Bajtów dla danej wartości
                            hexValue = hexValue.Substring(hexValue.Length - LENGTH*2, LENGTH*2);
                        }
                        else // jeżeli liczba jest dodatnia
                        { 
                            intValue = Int32.Parse(value);
                            hexValue = Convert.ToString(intValue, 16);          // przedstawienie wartości jako HEX
                            LENGTH = returnPOW(value);                          // Szukanie ilości Bajtów dla danej wartości
                            int testWartosci = LENGTH;
                        }                     
                        String hexValue_temp = new String(new char[LENGTH * 2]).Replace('\0', '0'); // Stworzenie stringa wypełnionego '0' o danej długości
                        int ileDoUsuniecia = System.Text.ASCIIEncoding.ASCII.GetByteCount(hexValue); // Ile ostatnich znaków do usunięcia, które mają być nadpisane przez nową wartość
                        hexValue_temp = hexValue_temp.Remove(hexValue_temp.Length - ileDoUsuniecia, ileDoUsuniecia) + hexValue; // Utworzenie końcowej wartości w HEX
                        hexValue = hexValue_temp;
                    }
                    else if(MIB.syntax == "OBJECT IDENTIFIER")
                    {
                        LENGTH = System.Text.ASCIIEncoding.ASCII.GetByteCount(value); // Sparwdzenie długości  
                        hexValue = coderOID(value);
                    }
                    else if (MIB.syntax.StartsWith("SEQUENCE OF") == false)
                    {
                        byte[] byteValue = Encoding.Default.GetBytes(value);
                        hexValue = BitConverter.ToString(byteValue);
                        hexValue = hexValue.Replace("-", "");
                        LENGTH = System.Text.ASCIIEncoding.ASCII.GetByteCount(value); // Sparwdzenie długości      
                    }
                    else
                    {
                        // todo pozostałe typy, SEQUENCE OF nie obsługiwane
                        LENGTH = 0;
                        hexValue = "NOT IMPLEMENTED";
                    }
                    string strLENGTH = string.Format("{0:x2}", LENGTH).ToString();

                    // kodowanie OID
                    string codedOID = coderOID(MIB.oID);

                    // Wyświetlenie zakodowanego ciągu:
                    txtBer.Text = string.Concat(strTAG, strLENGTH, hexValue);
                    txtBerOID.Text = codedOID;
                }
            }
        }

        public int returnTAG(MIBObjectType MIB)
        {
            ASN1Type asn1type;
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

            return TAG;

        }

        public int returnPOW(string v)
        {
            int n = 1;
            while (true)
            {
                int intValue = Int32.Parse(v);
                int powValue = (int)Math.Pow(2, (7 * n));
                if (intValue < powValue)
                {
                    return n;
                }
                n++;
            }
        }

        public string coderOID(string oID)
        {
            if(oID.StartsWith("1.3.") == true)
            {
                // Usunięcie 1.3.
                oID = oID.Remove(0, 4);
                // Z = 40*x + y = 43, gdzie x = iso(1), y = org(3)
                string hexOID = "2B";
                // Zamiana na listę wartości
                string[] parts = oID.Split('.'); // Call Split method
                List<string> list = new List<string>(parts); // Use List constructor
                foreach (string item in list)
                {
                    // Konwerrtowanie do HEX
                    string hexValue = string.Format("{0:X2}", Int32.Parse(item)).ToString();
                    hexOID = String.Concat(hexOID, hexValue);
                }
                return hexOID;
            }
            return "NOT VALID";
        }
    }
}
