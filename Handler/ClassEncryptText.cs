using System.Collections.Generic;
using System.Text;

namespace BIZ
{
    public class ClassEncryptText
    {
        private List<string> key;
        private ClassDummyText CDT;

        public ClassEncryptText(List<string> inKey)
        {
            key = inKey;
            CDT = new ClassDummyText(key);
        }

        public string EncryptString(string inString)
        {
            // Starter med at tilføje Dummy tekst
            string res = CDT.MakeDummyString();
            // Initialiser encoding
            Encoding enc1252 = Encoding.GetEncoding("Windows-1252");
            // Lav hele vores inString streng om til bytes.
            byte[] asciiBytes = enc1252.GetBytes(inString);

            // For hver byte i vores byte array
            foreach (byte aByte in asciiBytes)
            {
                // lav vores byte om til en char
                char aChar = (char)aByte;
                // tilføj vores char til res string objektet ved brug af MakeCodeOfChar metoden
                res += MakeCodeOfChar(aChar) + CDT.MakeDummyString();
            }

            return res;
        }

        /// <summary>
        /// Bliver sendt en char værdi
        /// Char værdien bliver lavet om til en int
        /// </summary>
        /// <param name="aChar"></param>
        /// <returns></returns>
        private string MakeCodeOfChar(char aChar)
        {
            string res = "";

            // Lav char om til en int
            int intChar = (int)aChar;
            // Lav int om til en string
            string strChar = intChar.ToString();

            // For hver char i vores string
            foreach (char aDigit in strChar)
            {
                // tilføj til res string objektet ved brug af key listen
                res += key[int.Parse(aDigit.ToString())];
            }

            return res;
        }
    }
}
