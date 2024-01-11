using System;
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

        public static string Zip(string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);

            using (var memoryStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
                {
                    gzipStream.Write(data, 0, data.Length);
                }

                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }

        public static string Unzip(string compressedText)
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
