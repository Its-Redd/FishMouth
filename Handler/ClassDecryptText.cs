using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BIZ
{
    public class ClassDecryptText
    {
        private List<string> listStringKey;

        public ClassDecryptText(List<string> inKey)
        {
            listStringKey = inKey;

        }

        public string DecryptString(string inString)
        {
            string res = "";
            string decryptionKey = "TORSKEMUND";
            string temp = "";

            // Disse 2 linjer bruger Regex til at finde alle forekomster af bogstaverne i decryptionKey i inString
            string pattern = "[" + Regex.Escape(decryptionKey) + "]+";
            MatchCollection matches = Regex.Matches(inString, pattern);

            // For hvert match i vores MatchCollection matches
            foreach (Match match in matches)
            {
                foreach (char c in match.Value)
                {
                    temp += MakeCharOfCode(c);
                }
                temp = (char)int.Parse(temp) + "";
                res += temp;
                temp = "";
            }

            return res;
        }

        private string MakeCharOfCode(char inChar)
        {
            string res = "";
            string key = "TORSKEMUND";

            res += key.IndexOf(inChar);

            return res;
        }
    }
}
