//Write a program that reads a text file and writes it's every odd line in another file. Line numbers starts from 0. 

//using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Text;

namespace _04._01.Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("data", "Input.txt");
            string ouput = Path.Combine("data", "Output.txt");

            var sb = new StringBuilder();
            var file = new FileStream(path, FileMode.Open);

            using (file)
            {
                using(TextReader reader=new StreamReader(file))
                {
                    string line;
                    bool oddLine = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (oddLine)
                        {
                            sb.AppendLine(line);
                        }

                        oddLine = !oddLine;
                    }
                }
            }

            using (FileStream fileOut = new FileStream(ouput, FileMode.Create))
            {
                using (TextWriter writer = new StreamWriter(fileOut))
                {
                    writer.Write(sb);
                    writer.Close();
                    Console.WriteLine(fileOut.Name);
                }
            }
        }
    }
}
