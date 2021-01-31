// Write a program that creates a zip file in a given directory and extracts it in another one. Use the copyMe.png file from your resources and zip it in a directory of your choice. Extract the zip file in another directory, again, by your choice.

using System;
using System.IO;
using System.IO.Compression;

namespace _04._06_Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath       = "data";
            string zipPath          = "newdata";
            string zippedFileName   = Path.Combine(zipPath, "ZipFile.zip");

            Directory.CreateDirectory(zipPath);

            foreach (var fileName in Directory.GetFiles(zipPath))
            {
                File.Delete(fileName);
            }

            ZipFile.CreateFromDirectory(sourcePath, zippedFileName);
            ZipFile.ExtractToDirectory(zippedFileName, zipPath );
        }
    }
}
