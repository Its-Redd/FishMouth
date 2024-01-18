using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BIZ
{
    public class ClassDecryptText
    {
        // Declare private variables
        private List<string> listStringKey;
        private string decryptionKey = "TORSKEMUND"; // Declaring the decryption key as a string instead of a list

        public ClassDecryptText(List<string> inKey)
        {
            // Initialize private variables
            listStringKey = inKey;
        }

        /// <summary>
        /// Decrypts encrypted text (from Encrypt)
        /// </summary>
        /// <param name="inString">Contains the encrypted text</param>
        /// <returns>String - Result</returns>
        public string DecryptString(string inString)
        {
            string res = "";

            string temp = "";

            // Making a string pattern that matches the decryption key
            string pattern = "[" + Regex.Escape(decryptionKey) + "]+";
            MatchCollection matches = Regex.Matches(inString, pattern);

            // for each match in the matches collection
            foreach (Match match in matches)
            {
                // for each char in the match value
                foreach (char c in match.Value)
                {
                    temp += MakeCharOfCode(c); // Add the decrypted char to temp
                }
                temp = (char)int.Parse(temp) + "";

                // Add temp to res and reset temp
                res += temp;
                temp = "";
            }

            return res;
        }

        /// <summary>
        /// Converts a char to a string of the index of the char in the decryption key
        /// </summary>
        /// <param name="inChar">Sends along the char from DecryptString()</param>
        /// <returns>String - Result</returns>
        private string MakeCharOfCode(char inChar)
        {
            string res = "";

            res += listStringKey.IndexOf(inChar.ToString());

            return res;
        }
    }
}
