using System.Collections.Generic;
using System.Text;

namespace BIZ
{
    public class ClassRollingEncryptText
    {
        private List<string> key;
        private ClassDummyText CDT;
        private int Jump = 3;

        public ClassRollingEncryptText(List<string> inKey)
        {
            CDT = new ClassDummyText(inKey);
            key = inKey;
        }

        public string RollingEncryptString(string inString)
        {
            string res = CDT.MakeDummyString();

            // Initialiser encoding
            Encoding enc1252 = Encoding.GetEncoding("Windows-1252");
            // Lav hele vores inString streng om til bytes.
            byte[] asciiBytes = enc1252.GetBytes(inString);

            // For hver byte i vores byte array
            foreach (char aByte in asciiBytes)
            {
                res += MakeCodeOfChar(aByte) + CDT.MakeDummyString();
            }

            Jump = 3; // Reset Jump
            return res;
        }

        private string MakeCodeOfChar(char aChar)
        {
            string res = "";
            int JumpUp = 3;

            // Lav char om til en int
            int intChar = (int)aChar;
            // Lav int om til en string
            string strChar = intChar.ToString();

            // For hver char i vores string
            foreach (char aDigit in strChar)
            {
                int intDigit = ((int.Parse(aDigit.ToString())) + Jump) % 10; // Math
                Jump += JumpUp; // JumpUp   

                // tilføj til res string objektet ved brug af key listen
                res += key[intDigit];
            }

            return res;
        }
    }
}
