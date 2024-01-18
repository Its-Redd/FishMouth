using IO;
using Repository;
using System.Collections.Generic;

namespace BIZ
{
    public class ClassBIZ
    {
        // Declare private variables
        ClassFileHandler fileIO = new ClassFileHandler();
        ClassZIP zip = new ClassZIP();
        List<string> cryptKey = new List<string>() { "T", "O", "R", "S", "K", "E", "M", "U", "N", "D" };

        public ClassBIZ()
        {
            // Initialize private variables
            clearText = new ClassText();
            cryptText = new ClassText();
        }

        // Declare properties
        public ClassText clearText { get; set; }
        public ClassText cryptText { get; set; }


        public void MakeEncryptedText()
        {
            ClassEncryptText CET = new ClassEncryptText(cryptKey); // Initialize CET with cryptKey
            cryptText.fishText = CET.EncryptString(clearText.fishText); // Sets cryptText.fishText to the encrypted string
        }

        public void MakeDecryptedText()
        {
            ClassDecryptText CDT = new ClassDecryptText(cryptKey); // Initialize CDT with cryptKey
            clearText.fishText = CDT.DecryptString(cryptText.fishText); // Sets clearText.fishText to the decrypted string
        }

        public void MakeRollingEncryptedText()
        {
            ClassRollingEncryptText CRET = new ClassRollingEncryptText(cryptKey); // Initialize CRET with cryptKey
            cryptText.fishText = CRET.RollingEncryptString(clearText.fishText); // Sets cryptText.fishText to the encrypted string
        }

        public void MakeRollingDecryptedText()
        {
            ClassRollingDecryptText CRDT = new ClassRollingDecryptText(cryptKey); // Initialize CRDT with cryptKey
            clearText.fishText = CRDT.RollingDecrypt(cryptText.fishText); // Sets clearText.fishText to the decrypted string
        }

        // Encrypt pseudocode
        // 1. Rolling Encrypt
        // 2. Rolling Enc data -> ZIP
        // 3. ZIP data -> Rolling Enc
        // 4. Show on GUI


        /// <summary>
        /// Initializes ClassRollingEncryptText with cryptKey
        /// We encrypt the clearText.fishText
        /// Then the encrypted text is zipped
        /// The zipped text is encrypted again
        /// </summary>
        public void MakeExtraEncryptedText()
        {
            ClassRollingEncryptText CRET = new ClassRollingEncryptText(cryptKey);
            string temp = CRET.RollingEncryptString(clearText.fishText);
            temp = zip.Zip(temp);
            cryptText.fishText = CRET.RollingEncryptString(temp);
        }

        // Decrypt pseudocode
        // 1. Rolling Dec
        // 2. Rolling Dec data -> UnZIP
        // 3. UnZIP data -> Rolling Dec
        // 4. Show on GUI

        /// <summary>
        /// Initializes ClassRollingDecryptText with cryptKey 
        /// Decrypts the encrypted text
        /// Unzips the decrypted text
        /// Decrypts the unzipped text
        /// </summary>
        public void MakeExtraDecryptedText()
        {
            ClassRollingDecryptText CRDT = new ClassRollingDecryptText(cryptKey);
            string temp = CRDT.RollingDecrypt(cryptText.fishText);
            temp = zip.Unzip(temp);
            clearText.fishText = CRDT.RollingDecrypt(temp);
        }

        public void ReadClearTextFromFile(string path)
        {
            // TODO: Add functionality here
        }

        public void ReadEncryptedTextFromFile(string path)
        {
            // TODO: Add functionality here
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
