using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lecture.Aids
{
    public static class ReadingInFiles
    {
        public static void SentenceWordCounter()
        {
            Console.WriteLine("Input your directory!");
            string directory = Console.ReadLine();
            Console.WriteLine("Input your file-name!");
            string filename = Console.ReadLine();

            string fullPath = Path.Combine(directory, filename);

            try
            {
                //Open a StreamReader with the using statement
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    // Read the file until the end of the stream is reached
                    // EndOfStream is a "marker" that the stream uses to determine 
                    // if it has reached the end
                    // As we read forward the marker moves forward like a typewriter.
                    while (!sr.EndOfStream)
                    {
                        string pattern = @"(?<!Mr?s?|\b[A-Z])\.\s*\d*";
                        RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Compiled;
                        string wholeFile = sr.ReadToEnd();
                        MatchCollection matches;

                        Regex optionRegex = new Regex(pattern, options);
                        matches = optionRegex.Matches(wholeFile);

                        char[] wordSeperators = { ' ' };
                        string[] words = wholeFile.Split(wordSeperators);

                        Console.WriteLine($"There are {matches.Count} sentences in the document.");
                        Console.WriteLine($"There are {words.Count()} words in the document.");

                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            catch (IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
        }



    }
}