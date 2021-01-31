// Write a program that copies the contents of a binary file (e.g. image, video, etc.) to another using FileStream.You are not allowed to use the File class or similar helper classes.

using System;
using System.IO;

namespace _04._04.Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("data", "binaryFife.jpg");
            string dest = Path.Combine("data", "CopyOfbinaryFife.jpg");
            FileStream file = new FileStream(path, FileMode.Open);
            FileStream copy = new FileStream(dest, FileMode.Create);
            int buffSize = 4096;
            int bytesRead = 0;
            Byte[] bytes = new byte[buffSize];

            try
            {
                while ((bytesRead = file.Read(bytes, 0, buffSize)) > 0)
                {
                    copy.Write(bytes, 0, bytesRead);
                }

            }
            finally
            {
                file.Close();
                copy.Close();
            }
        }
    }
}
