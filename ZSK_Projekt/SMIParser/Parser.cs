using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Reflection;

namespace ZSK_Projekt.SMIParser
{
    class Parser
    {
        public List<MIBObjectType> MIBObjects = new List<MIBObjectType>(); // OBJECT-TYPE list
        List<MIBSequence> MIBSequences = new List<MIBSequence>();   // SEQUENCE list

        public Parser()
        {
            SMIParser();
        }



        public void SMIParser()
        {
            RegexOptions options = RegexOptions.Multiline | RegexOptions.Singleline;
            // Regex: OBJECT-TYPE (name,syntax,access,status,description,parent,oid)
            //string pattern_ObjectType = @"(?<name>\w*)\s*OBJECT-TYPE\s*SYNTAX\s*(?<syntax>.*?)ACCESS\s*(?<access>.*?)STATUS\s*(?<status>.*?)DESCRIPTION\s*\""(?<description>.*?)\""?\s*::=\s*[{]\s*(?<parent>.*?)\s*(?=\d)(?<id>.*?)\s*[}]";
            string pattern_ObjectType = @"(?<name>\w*)\s*OBJECT-TYPE\s*SYNTAX\s*(?<syntax>.*?)\s*ACCESS\s*(?<access>.*?)\s*STATUS\s*(?<status>.*?)\s*DESCRIPTION\s*\""(?<description>.*?)\""?\s*::=\s*[{]\s*(?<parent>.*?)\s*(?=\d)(?<id>.*?)\s*[}]";

            // Regex: SEQUENCE (name,values)
            string pattern_Sequence = @"(?<name>\w*)\s*\:\:\=\s*(?<sequence>SEQUENCE)\s*\{(?<values>.*?)\s*[}]";

            // Regex: OBJECT IDENTIFIER (name, parent, oid)
            string pattern_ObjectIdentifier = @"^(?<name>\w*)\s*(?<oi>OBJECT\sIDENTIFIER)\s\:\:\=\s\{\s(?<parent>\S*)\s(?<oid>\d)\s\}";
            //@"^(?<name>\w*)\s*(?<oi>OBJECT\sIDENTIFIER)\s\:\:\=\s\{\s(?<parent>\S*)\s(?<oid>\d)\s\}$";

            // Opens a text file, reads all lines of the file into a string, and then closes the file.
            string path_input = @"C:\Users\Krystian\Source\Repos\krystian-w\snmp\ZSK_Projekt\RFC1213-MIB.txt";


            //string path_output = @"D:\output_test.txt";
            //File.WriteAllText(path_output, String.Empty);

            try
            {
                if (!File.Exists(path_input))
                    throw new FileNotFoundException();
            }
            catch (FileNotFoundException)
            {
                 Environment.Exit(2);
            }
            catch (Exception ex)
            {
                Environment.Exit(2);
            }

            string text = File.ReadAllText(path_input);

            // Add OBJECT IDENTIFIER to OBJECT-TYPE List  
            foreach (Match m in Regex.Matches(text, pattern_ObjectIdentifier, options))
            {
                string name = m.Groups[1].Value.Replace("\n", "");      // [1] Name
                string parent = m.Groups[3].Value.Replace("\n", "");    // [6] Parent
                string oid = m.Groups[4].Value.Replace("\n", "");       // [7] ID
                MIBObjects.Add(new MIBObjectType(name, parent, oid));
            }

            // Add elements to OBJECT-TYPE List
            foreach (Match m in Regex.Matches(text, pattern_ObjectType, options))
            {
                string name = m.Groups[1].Value.Replace("\n", "");      // [1] Name
                string syntax = m.Groups[2].Value.Replace("\n", "");    // [2] Syntax
                string access = m.Groups[3].Value.Replace("\n", "");    // [3] Access
                string status = m.Groups[4].Value.Replace("\n", "");    // [4] Status   [5] Desciption
                string parent = m.Groups[6].Value.Replace("\n", "");    // [6] Parent
                //string oid = m.Groups[7].Value.Replace("\n", "");       // [7] ID
                string parent_oid = getParentOID(m.Groups[6].Value.Replace("\n", ""));
                string oid = string.Concat(parent_oid,".",m.Groups[7].Value.Replace("\n", ""));
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

        // Utworzenie list dzieci, które mają mib-2 jako parent
        public void CreateOIList(ref List<string> list)
        {
            foreach (var mib in MIBObjects)
            {
                if (mib.parent == "mib-2")
                    list.Add((mib.name));
            }
        }

        public string displayText(string name, string value)
        {
            // name ; oid ; syntax ; access ; status ; min ; max
            foreach (var mib in MIBObjects)
            {
                if (mib.name == name)
                { 
                    if (value == "name") return mib.name;
                    if (value == "oid") return mib.oID;
                    if (value == "syntax") return mib.syntax;
                    if (value == "access") return mib.access;
                    if (value == "status") return mib.status;
                    if (value == "min") return mib.min.ToString();
                    if (value == "max") return mib.max.ToString();
                    string values = "";
                    foreach (var list in mib.listValues)
                    {
                        values = String.Concat(values,list.name,"\t",list.value.ToString(),"\r\n");
                    }
              
                    if (value == "values") return values;
                }
            }
            return "";
        }

        // Szukanie OID rodzica
        private string getParentOID(string parent)
        {
            foreach (var mib in MIBObjects)
            {
                if (mib.name == parent)
                {
                    return mib.oID;
                }
            }
            return "";
        }
    }
}
