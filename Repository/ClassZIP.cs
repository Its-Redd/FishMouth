using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Repository
{
    public class ClassZIP
    {
        public ClassZIP()
        {
        }

        /// <summary>
        /// Divided the text into individual bytes and zips them
        /// </summary>
        /// <param name="text">String - Contains the text that needs to be zipped</param>
        /// <returns>String - Returns the zipped text</returns>
        public string Zip(string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);

            using (var memoryStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
                {
                    gzipStream.Write(data, 0, data.Length);
                }
                Debug.WriteLine(Convert.ToBase64String(memoryStream.ToArray()));
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }

        /// <summary>
        /// Unzips the text and returns the original text
        /// </summary>
        /// <param name="compressedText">String - Contains the text that needs to be unzipped</param>
        /// <returns>String - Returns the unzipped text</returns>
        public string Unzip(string compressedText)
        {
            byte[] data = Convert.FromBase64String(compressedText);

            using (var memoryStream = new MemoryStream(data))
            using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
            using (var reader = new StreamReader(gzipStream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
