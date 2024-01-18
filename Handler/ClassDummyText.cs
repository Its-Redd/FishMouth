using System;
using System.Collections.Generic;
using System.Text;

namespace BIZ
{
    public class ClassDummyText
    {
        // Declare private variables
        private List<string> key;
        private Random rnd;
        private Encoding win1252 = Encoding.GetEncoding("Windows-1252");



        public ClassDummyText(List<string> list)
        {
            // Initialize private variables
            rnd = new Random();
            key = list;
        }

        /// <summary>
        /// Makes a dummy string with random length
        /// and random chars from the win1252 encoding
        /// </summary>
        /// <returns>String - Result</returns>
        public string MakeDummyString()
        {
            string res = "";
            int noOfChars = rnd.Next(5, 16);

            for (int i = 1; i <= noOfChars; i++)
            {
                res += MakeDummyChar();
            }

            return res;
        }

        /// <summary>
        /// Makes a random dummy char from the win1252 encoding
        /// </summary>
        /// <returns>String - a random char</returns>
        private string MakeDummyChar()
        {
            string res = "";
            bool foundInKey = false;

            do
            {
                res = win1252.GetString(new byte[] { (byte)rnd.Next(33, 123) });
                foundInKey = key.Contains(res);
            } while (foundInKey);

            return res;
        }

    }
}
