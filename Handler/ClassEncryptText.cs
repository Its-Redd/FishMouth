using System.Collections.Generic;
using System.Text;

namespace BIZ
{
    public class ClassEncryptText
    {

        // Declare private variables
        private List<string> key;
        private ClassDummyText CDT;

        public ClassEncryptText(List<string> inKey)
        {
            // Initialize private variables
            key = inKey;
            CDT = new ClassDummyText(key);
        }

        /// <summary>
        /// Encrypts a string using the key
        /// </summary>
        /// <param name="inString">String to be encrypted</param>
        /// <returns>string - Encrypted string</returns>
        public string EncryptString(string inString)
        {
            // Add dummy string to res
            string res = CDT.MakeDummyString();

            // Initializes encoding
            Encoding enc1252 = Encoding.GetEncoding("Windows-1252");

            // Divides the entire string into bytes
            byte[] asciiBytes = enc1252.GetBytes(inString);

            // For each byte in the byte array
            foreach (byte aByte in asciiBytes)
            {
                // Turns the byte into a char
                char aChar = (char)aByte;

                // Add the encrypted char to res
                res += MakeCodeOfChar(aChar) + CDT.MakeDummyString();
            }
            return res;
        }

        /// <summary>
        /// Converts a char to a string of the index of the char in the key
        /// </summary>
        /// <param name="aChar"> The char that needs to be converted</param>
        /// <returns>string - returns the converted char</returns>
        private string MakeCodeOfChar(char aChar)
        {
            string res = "";

            // Turn char into int
            int intChar = (int)aChar;

            // Turn int into string (The number of the char in the ASCII table)
            string strChar = intChar.ToString();

            // For each char in the strChar String, looks for the char in the key, and adds the index to res
            foreach (char aDigit in strChar)
            {
                // Add the key[int.Parse(aDigit.ToString())] to res
                res += key[int.Parse(aDigit.ToString())];
            }
            return res;
        }
    }
}
