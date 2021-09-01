using System;
using System.IO.Compression;

namespace _06._ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"C:\Users\Blago\Desktop\New folder", @"C:\Users\Blago\Desktop\New folder (2)\zipped.zip");
            ZipFile.ExtractToDirectory(@"C:\Users\Blago\Desktop\New folder (2)\zipped.zip", @"C:\Users\Blago\Desktop\New folder (2)");
        }
    }
}
