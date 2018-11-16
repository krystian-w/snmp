using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ZSK_Projekt.SMIParser
{
    class Parser
    {
        List<MIBObjectType> MIBObjects = new List<MIBObjectType>(); // OBJECT-TYPE list
        List<MIBSequence> MIBSequences = new List<MIBSequence>();   // SEQUENCE list

        public Parser()
        {
            SMIParser();
        }

        public const string oid_mgmt = "1.3.6.1.2";
        public const string oid_mib2 = "1.3.6.1.2.1";
        public const string oid_system = "1.3.6.1.2.1.1";           // system OBJECT IDENTIFIER::= { mib-2 1 }
        public const string oid_interfaces = "1.3.6.1.2.1.2";       // interfaces OBJECT IDENTIFIER::= { mib-2 2 }
        public const string oid_at = "1.3.6.1.2.1.3";               // at OBJECT IDENTIFIER::= { mib-2 3 }
        public const string oid_ip = "1.3.6.1.2.1.4";               // ip OBJECT IDENTIFIER::= { mib-2 4 }
        public const string oid_icmp = "1.3.6.1.2.1.5";             // icmp OBJECT IDENTIFIER::= { mib-2 5 }
        public const string oid_tcp = "1.3.6.1.2.1.6";              // tcp OBJECT IDENTIFIER::= { mib-2 6 }
        public const string oid_udp = "1.3.6.1.2.1.7";              // udp OBJECT IDENTIFIER::= { mib-2 7 }
        public const string oid_egp = "1.3.6.1.2.1.8";              // egp OBJECT IDENTIFIER::= { mib-2 8 }
        public const string oid_cmot = "1.3.6.1.2.1.9";             // cmot OBJECT IDENTIFIER::= { mib-2 9 }
        public const string oid_transmission = "1.3.6.1.2.1.10";    // transmission OBJECT IDENTIFIER::= { mib-2 10 }
        public const string oid_snmp = "1.3.6.1.2.1.11";            // snmp OBJECT IDENTIFIER::= { mib-2 11 }

        public void SMIParser()
        {
            RegexOptions options = RegexOptions.Multiline | RegexOptions.Singleline;
            // Regex: OBJECT-TYPE
            string pattern_ObjectType = @"(?<name>\w*)\s*OBJECT-TYPE\s*SYNTAX\s*(?<syntax>.*?)ACCESS\s*(?<access>.*?)STATUS\s*(?<status>.*?)DESCRIPTION\s*\""(?<description>.*?)\""?\s*::=\s*[{]\s*(?<parent>.*?)\s*(?=\d)(?<id>.*?)\s*[}]";

            // Regex: SEQUENCE
            string pattern_Sequence = @"(?<name>\w*)\s*\:\:\=\s*(?<sequence>SEQUENCE)\s*\{(?<values>.*?)\s*[}]";

            // Opens a text file, reads all lines of the file into a string, and then closes the file.
            string path_input = @"D:\RFC1213-MIB.txt";
            //string path_output = @"D:\output_test.txt";
            //File.WriteAllText(path_output, String.Empty);

            try
            {
                if (!File.Exists(path_input))
                    throw new FileNotFoundException();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file is not found in the specified location");
                Environment.Exit(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(2);
            }

            string text = File.ReadAllText(path_input);



            // Add elements to OBJECT-TYPE List
            foreach (Match m in Regex.Matches(text, pattern_ObjectType, options))
            {
                string name = m.Groups[1].Value.Replace("\n", "");      // [1] Name
                string syntax = m.Groups[2].Value.Replace("\n", "");    // [2] Syntax
                string access = m.Groups[3].Value.Replace("\n", "");    // [3] Access
                string status = m.Groups[4].Value.Replace("\n", "");    // [4] Status   [5] Desciption
                string parent = m.Groups[6].Value.Replace("\n", "");    // [6] Parent
                string oid = m.Groups[7].Value.Replace("\n", "");       // [7] ID
                MIBObjects.Add(new MIBObjectType(name, syntax, access, status, parent, oid));
            }

            // Add elements to SEQUENCE List 
            foreach (Match m in Regex.Matches(text, pattern_Sequence, options))
            {
                string name = m.Groups[1].Value.Replace("\n", "");      // [1] Name
                string values = m.Groups[3].Value.Replace("\n", "");    // [3] Values
                MIBSequences.Add(new MIBSequence(name, values));
            }
        }

        // Wykorzystanie mib.parent do określenia odpowiedniego oID przy wyświetlaniu TreeView
        public void CreateSMITreeView(ref List<TreeNode> list, string parent)
        {
            foreach (var mib in MIBObjects)
            {
                if (mib.parent == parent)
                    list.Add(new TreeNode(mib.name));
            }
        }

        public void CreateSMITreeViewDetails(ref List<TreeNode> list, string name)
        {
            foreach (var mib in MIBObjects)
            {
                if (mib.name == name)
                { 
                    list.Add(new TreeNode(mib.syntax));
                    list.Add(new TreeNode(mib.access));
                    list.Add(new TreeNode(mib.status));
                    if (mib.valMin != -1) list.Add(new TreeNode(mib.valMin.ToString()));
                    if (mib.valMax != -1) list.Add(new TreeNode(mib.valMax.ToString()));
                    if (mib.charMin != -1) list.Add(new TreeNode(mib.charMin.ToString()));
                    if (mib.charMax != -1) list.Add(new TreeNode(mib.charMax.ToString()));
                }
            }
        }
    }
}
