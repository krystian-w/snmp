using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ZSK_Projekt.SMIParser
{
    public class MIBObjectType
    {

        public MIBObjectType(string Name, string Syntax, string Access, string Status, string Parent, string OID)
        {
            name = Name;
            access = Access;
            status = Status;
            parent = Parent;
            oID = OID;
            charMin = -1;
            charMax = -1;
            valMin = -1;
            valMax = -1;

            RegexOptions options = RegexOptions.Multiline | RegexOptions.Singleline;
            // Pattern: xyz SIZE(0..255)
            string pattern_size = @"(?<syntax>\w*)\s*\((?<name>SIZE)\s*\((?<min>\d*)\.\.(?<max>\d*)\)\)";
            Match match_size = Regex.Match(Syntax, pattern_size, options);

            // Pattern: xyz (0..65535)
            string pattern_minmax = @"(?<syntax>\w*)\s*\((?<min>\d*)\.\.(?<max>\d*)\)";
            Match match_minmax = Regex.Match(Syntax, pattern_minmax, options);

            // Pattern: xyz { abc(1), efg(2) ... }
            string pattern_values = @"(?<name>\w*)\s*{(?<rest>(?<={)(.*?)(?=}))}";
            Match match_values = Regex.Match(Syntax, pattern_values, options);

            // If SIZE(min..max) -> set charMin and charMax
            if (match_size.Success == true)
            {
                syntax = match_size.Groups[1].Value.Replace("\n", "");
                charMin = Int32.Parse(match_size.Groups[3].Value.Replace("\n", ""));
                charMax = Int32.Parse(match_size.Groups[4].Value.Replace("\n", ""));

            }
            // If (min..max) -> set valMin and valMax
            else if (match_minmax.Success == true)
            {
                syntax = match_minmax.Groups[1].Value.Replace("\n", "");
                valMin = Int32.Parse(match_minmax.Groups[2].Value.Replace("\n", ""));
                valMax = Int32.Parse(match_minmax.Groups[3].Value.Replace("\n", ""));
            }
            // If { abc(1), efg(2) } then add values to listValues list
            else if (match_values.Success == true)
            {
                syntax = match_values.Groups[2].Value.Replace("\n", "");
                string pattern_stringint = @"(?<word>\w*)\((?<number>\d*)\)";
                foreach (Match stringint in Regex.Matches(Syntax, pattern_stringint, options))
                {
                    string ValueString = stringint.Groups[1].Value.Replace("\n", "");
                    String ValueInt = stringint.Groups[2].Value.Replace("\n", "");
                    listValues.Add(new Values(ValueString, Int32.Parse(ValueInt)));
                }
            }
            // else
            else
            {
                syntax = Syntax;
            }
        }
        public string name;     // nazwa 
        public string syntax;   // Określamy, jakiego typu będzie wartość obiektu
        public string access;   // Określają dostęp do obiektu
        public string status;   // Określa poziom implementacji obiektu
        //public string description; // Opis obiektu
        public string parent;   // Rodzic
        public string oID;      // Określa numer obiektu w poddrzewie
        public int valMin;      // Minimalny zakres wartości, które może zostać przyporządkowany obiektowi
        public int valMax;      // Maksymalny zakres wartości, które może zostać przyporządkowany obiektowi
        public int charMin;     // Minimalna wartość znaków
        public int charMax;     // Maksymalna wartość znaków

        // Lista zawierająca elementy { abc(1), xyz(2) ... }
        public List<Values> listValues = new List<Values>();
        public struct Values
        {
            public Values(string Name, int Value)
            {
                name = Name;
                value = Value;
            }

            public int value { get; private set; }
            public string name { get; private set; }
        }
    }
   
}
