using IO;
using Repository;
using System.Collections.Generic;

namespace BIZ
{
    public class ClassBIZ
    {
        ClassFileHandler fileIO = new ClassFileHandler();
        ClassZIP zip = new ClassZIP();
        List<string> cryptKey = new List<string>() { "T", "O", "R", "S", "K", "E", "M", "U", "N", "D" };
        public ClassBIZ()
        {
            clearText = new ClassText();
            cryptText = new ClassText();
        }
        public ClassText clearText { get; set; }
        public ClassText cryptText { get; set; }


        public void MakeEncryptedText()
        {
            ClassEncryptText CET = new ClassEncryptText(cryptKey);
            cryptText.fishText = CET.EncryptString(clearText.fishText);
        }

        public void MakeDecryptedText()
        {
            ClassDecryptText CDT = new ClassDecryptText(cryptKey);
            clearText.fishText = CDT.DecryptString(cryptText.fishText);
        }

        public void MakeRollingEncryptedText()
        {
            ClassRollingEncryptText CRET = new ClassRollingEncryptText(cryptKey);
            cryptText.fishText = CRET.RollingEncryptString(clearText.fishText);
        }

        public void MakeRollingDecryptedText()
        {
            ClassRollingDecryptText CRDT = new ClassRollingDecryptText(cryptKey);
            clearText.fishText = CRDT.RollingDecrypt(cryptText.fishText);
        }

        public void MakeExtraEncryptedText()
        {
            // TODO: Add functionality here
        }

        public void MakeExtraDecryptedText()
        {
            // TODO: Add functionality here
        }

        public void ReadClearTextFromFile(string path)
        {

        }

        public void ReadEncryptedTextFromFile(string path)
        {

        }

        public void WriteEncryptedTextToFile(string path)
        {
            // TODO: Add functionality here
        }

        public void WriteClearTextToFile(string path)
        {
            // TODO: Add functionality here
        }

    }
}
