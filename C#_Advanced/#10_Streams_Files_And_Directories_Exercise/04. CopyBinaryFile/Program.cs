using System;
using System.IO;

namespace _04._CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream reader = new FileStream("copyMe.png", FileMode.Open, FileAccess.Read);
            using FileStream writer = new FileStream("copyPicture.png", FileMode.Create);

            while (reader.CanRead)
            {
                byte[] buffer = new byte[4096];
                int readBytes = reader.Read(buffer, 0, buffer.Length);

                if (readBytes == 0)
                {
                    break;
                }

                writer.Write(buffer, 0, readBytes);
            }
        }
    }
}
