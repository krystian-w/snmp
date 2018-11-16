using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ZSK_Projekt.SMIParser
{
    public class MIBSequence
    {
        public MIBSequence(string Name, string Values)
        {
            name = Name;            // name ::= SEQUENCE
            string min = "-1";      // Jeżeli brak to będzie -1
            string max = "-1";      // Jeżeli brak to będzie -1

            RegexOptions options = RegexOptions.Singleline | RegexOptions.Multiline;
            string pattern_NameType = @"(?<name>\w*)\s*(?<type>\w*)(\,|(?<minmax>\s*\(\S*\)))+";

            foreach (Match m in Regex.Matches(Values, pattern_NameType, options))
            {
                string _name = m.Groups[2].Value.Replace("\n", "");   // Ustaw [2] Name
                string _type = m.Groups[3].Value.Replace("\n", "");   // Ustaw [3] Type

                // Jeżeli występuje min i max to ustaw wartości
                string pattern_minmax = @"\((?<min>\d*)..(?<max>\d*)\)";
                Match minmax = Regex.Match(m.Groups[4].Value.Replace("\n", ""), pattern_minmax, options); // [4] MinMax
                if (minmax.Success == true)
                {
                    min = (minmax.Groups[1].Value);  // [1] - min
                    max = (minmax.Groups[2].Value);  // [2] - max
                    sequenceValues.Add(new SequenceValues(_name, _type, min, max));
                }
                // W przeciwnym wypadku zostaw -1 i -1
                else
                {
                    sequenceValues.Add(new SequenceValues(_name, _type, min, max));
                }
            }
        }

        public string name;     // nazwa sekwencji
        public List<SequenceValues> sequenceValues = new List<SequenceValues>(); // elementy w sekwencji
    }

    public class SequenceValues
    {
        public SequenceValues(string Name, string Type, string Min, string Max)
        {
            name = Name;
            type = Type;
            min = Min;
            max = Max;
        }
        public string name;
        public string type;
        public string min;
        public string max;
    }
}
