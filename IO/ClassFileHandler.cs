using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    public class ClassFileHandler
    {
        Encoding enc1252;
        Encoding encUTF8;

        public ClassFileHandler() {
            enc1252 = Encoding.GetEncoding("Windows-1252");
            encUTF8 = Encoding.GetEncoding("UTF-8");
        }

        public string ReadTextFromFile(string path)
        {
            // Initialisering af den variabel der skal indeholde teksten fra filen.
            string resText = "";
            // Validering af om der er modtaget en path
            if (path.Trim().Length == 0)
            {
                // Hvis der ikke er modtaget en path
                return $"Der er ikke angivet nogen sti til filen.";
            }

            // Validering af om filen findes på den angivne placering som fremgår af path.
            if (!File.Exists(path))
            {
                // Hvis filen ikke findes, returneres følgende tekst.
                return $"Filen med følgende sti\n\n{path}\n\n blev IKKE fundet.";
            }

            // Der benyttes Try-Catch for at kunne håndtere fejl/exceptions der kan
            // opstå ved kommunikation med eksterne enheder.
            try
            {
                // Der benyttes Using for at gøre håndteringen af resurserne FileStream og
                // StreamReader nemmere og mere sikker. GarbageCollectoren i styresystemet
                // vil håndtere handlingerne med at lukke for resurserne når de længer skal
                // benyttes.

                // FileStream åbner forbindelsen til filen
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    // StreamReader giver mulighed for at tilgå indholdet af filen
                    using (StreamReader reader = new StreamReader(fileStream, enc1252))
                    {
                        // reader læser indholdet af filen og skriver det ind i resText.
                        resText = reader.ReadToEnd();
                    }
                }
            }
            // Fanger en evt. Exception.
            catch (IOException ex)
            {
                // Tager den opståede Exception og sender den bagud til den metode der har
                // kaldt denne metode. 
                throw ex;
            }
            // Returnere indholdet af filen.
            return resText;
        }

        public void WriteTextToFile_StreamWriter(string path, string text)
        {
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fileStream, encUTF8))
                    {
                        writer.AutoFlush = true;
                        writer.WriteLine(text);
                    }
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

    }
}
