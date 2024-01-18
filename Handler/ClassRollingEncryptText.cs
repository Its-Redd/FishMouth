using System.Collections.Generic;
using System.Text;

namespace BIZ
{
    public class ClassRollingEncryptText
    {
        // Declare private variables
        private List<string> key;
        private ClassDummyText CDT;
        private int Jump = 3;

        public ClassRollingEncryptText(List<string> inKey)
        {
            // Initialize private variables
            CDT = new ClassDummyText(inKey);
            key = inKey;
        }

        /// <summary>
        /// Encrypts a string using the key (Rolling)
        /// </summary>
        /// <param name="inString"> String to be encrypted </param>
        /// <returns>string - Encrypted string</returns>
        public string RollingEncryptString(string inString)
        {
            // Adds some dummy text to res
            string res = CDT.MakeDummyString();

            // Initializes encoding
            Encoding enc1252 = Encoding.GetEncoding("Windows-1252");

            // Divides the entire string into bytes
            byte[] asciiBytes = enc1252.GetBytes(inString);

            // For each byte in the byte array, add the encrypted char to res
            foreach (char aByte in asciiBytes)
            {
                res += MakeCodeOfChar(aByte) + CDT.MakeDummyString();
            }

            Jump = 3; // Reset Jump
            return res;
        }

        /// <summary>
        /// Turns a char into a string of the index of the char in the key
        /// </summary>
        /// <param name="aChar"> The char that needs to be converted</param>
        /// <returns>string - returns the converted char</returns>
        private string MakeCodeOfChar(char aChar)
        {
            string res = "";
            int JumpUp = 3;

            // Turn char into int
            int intChar = (int)aChar;
            // turn int into string
            string strChar = intChar.ToString();

            // For each char in the strChar String
            foreach (char aDigit in strChar)
            {
                int intDigit = ((int.Parse(aDigit.ToString())) + Jump) % 10; // Math
                Jump += JumpUp; // JumpUp   

                // Add the key[intDigit] to res
                res += key[intDigit];
            }

            return res;
        }
    }
}
