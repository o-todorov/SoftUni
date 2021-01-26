// Write a program that reads a list of words from the file words.txt and finds how many times each of the words is contained in another file text.txt. Matching should be case-insensitive.
// The result should be written to another text file. Sort the words by frequency in descending order.

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._03.Word_Count
{
    class Program
    {
        static void Main(string[] args) 
        {
            var path    = Path.Combine("data", "words.txt");
            var words   = File.ReadAllText(path)
                              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                              .ToDictionary(w => w, w => 0);

            path = Path.Combine("data", "text.txt");
            var text = File.ReadAllText(path);
            
            foreach (var word in words.Keys.ToArray())
            {
                string pattern = @$"\b({word})\b";
                words[word] = Regex.Matches(text, pattern,RegexOptions.IgnoreCase).Count;
            }

            var outputLines = words.OrderByDescending(w => w.Value)
                        .Select(word => $"{word.Key} - {word.Value}");

            path = Path.Combine("data", "output.txt");
            File.WriteAllLines(path, outputLines);
        }
    }
}
