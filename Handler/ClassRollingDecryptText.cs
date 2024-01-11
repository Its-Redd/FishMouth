using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BIZ
{
    public class ClassRollingDecryptText
    {
        private List<string> listStringKey;
        private int keyJump = 3;
        private int keyUp = 3;

        /* Make Constructor for ClassRollingDecryptText
        // Initialize List<string> listStringKey
         Initialize int keyJump = 2 */

        public ClassRollingDecryptText(List<string> inKey)
        {
            listStringKey = inKey;
        }

        /// <summary>
        /// Decrypts encrypted text (from RollingEncrypt)
        /// </summary>
        /// <param name="inString">Encrypted text</param>
        /// <returns>String - </returns>
        public string RollingDecrypt(string inString)
        {
            string res = ""; // Initialize res as empty string
            string tempString = ""; // Initialize tempString as empty string

            Encoding enc1252 = Encoding.GetEncoding("Windows-1252"); // Initialize encoder enc1252

            byte[] asciiBytes = enc1252.GetBytes(inString); // Initialize byte array asciiBytes

            foreach (char encryptedChar in asciiBytes) // For each char in byte array asciiBytes
            {
                if (listStringKey.Contains(encryptedChar.ToString())) // If listStringKey contains encryptedChar.ToString()
                {
                    tempString += encryptedChar.ToString(); // Add encryptedChar.ToString() to tempString
                }
                else
                {
                    if (tempString.Length > 0) // If tempString.Length is greater than 0
                    {
                        res += MakeCharOfCode(tempString);
                        tempString = ""; // Reset tempString to empty string
                    }
                }
            }
            // TODO: Set up string res as empty string,  Initialize encoder and byte array asciiBytes
            // Seperate dummy text and encrypted text, and add encrypted text to tempString and
            // send to MakeCharOfCode() to get decrypted char (Go to MakeCharOfCode() for
            // pseudo on what happens in the method)
            return res;
        }

        // Convert encrypted char to decrypted char
        private string MakeCharOfCode(string inCharString)
        {
            string res = "";
            foreach (char c in inCharString)
            {
                res += GetRealRollingKey(c);
            }
            Debug.WriteLine($"{res}");
            return $"{(char)Convert.ToInt32(res)}";
        }

        // TODO: Check if this is correct. 
        // Gets the int value of the decrypted char 
        private int GetRealRollingKey(char inChar)
        {
            int intChar = listStringKey.IndexOf(inChar.ToString());
            int oDigit = (intChar - keyJump + 10 * listStringKey.Count) % 10;
            if (oDigit < 0)
            {
                oDigit += 10;
            }
            keyJump += keyUp;

            Debug.WriteLine($"GetRealRollingKey: {oDigit}");

            return oDigit;
        }
    }
}
