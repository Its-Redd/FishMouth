using System;
using System.Collections.Generic;
using System.Text;

namespace BIZ
{
    public class ClassDummyText
    {
        private List<string> key;
        private Random rnd;
        private Encoding win1252 = Encoding.GetEncoding("Windows-1252");



        public ClassDummyText(List<string> list)
        {
            rnd = new Random();
            key = list;
        }

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

        private string MakeDummyChar()
        {
            string res = "";
            bool FoundInKey = false;

            do
            {
                res = win1252.GetString(new byte[] { (byte)rnd.Next(33, 123) });
                FoundInKey = key.Contains(res);
            } while (FoundInKey);

            return res;
        }

    }
}
