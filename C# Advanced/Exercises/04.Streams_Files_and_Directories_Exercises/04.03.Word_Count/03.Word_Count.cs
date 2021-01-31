// Write a program that reads a list of words from the file words.txt and finds how many times each of the words is contained in another file text.txt. Matching should be case-insensitive. Write the results in file actualResults.txt. Sort the words by frequency in descending order and then compare the result with the file expectedResult.txt. Use the File class.

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
            var words   = File.ReadAllLines(path)
                              .ToDictionary(w => w.Trim(), w => 0);

            path        = Path.Combine("data", "text.txt");
            var text    = File.ReadAllText(path);

            foreach (var word in words.Keys.ToArray())
            {
                string pattern  = @$"\b({word})\b";
                words[word]     = Regex.Matches(text, pattern, RegexOptions.IgnoreCase).Count;
            }

            var outputLines = words.OrderByDescending(w => w.Value)
                        .Select(word => $"{word.Key} - {word.Value}");

            path = Path.Combine("data", "actualResult.txt");
            File.WriteAllLines(path, outputLines);
        }
    }
}
