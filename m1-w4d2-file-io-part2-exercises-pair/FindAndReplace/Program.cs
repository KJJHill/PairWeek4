using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace FindAndReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What word do you want to replace?");
            string wordToReplace = Console.ReadLine();
            Console.WriteLine("What word do you want to replace it with?");
            string replacementWord = Console.ReadLine();
            Console.WriteLine("What directory is the file located in?");
            string originalDirectory = Console.ReadLine();
            Console.WriteLine("What is the file called?");
            string originalFileName = Console.ReadLine();
            Console.WriteLine("In what directory would you like to place the new file?");
            string newDirectory = Console.ReadLine();
            Console.WriteLine("What would you like to name the new file?");
            string newFileName = Console.ReadLine();
            string originalFullPath = Path.Combine(originalDirectory, originalFileName);
            string newFullPath = Path.Combine(newDirectory, newFileName);

            File.WriteAllText(newFullPath, Regex.Replace(File.ReadAllText(originalFullPath), wordToReplace, replacementWord));
        }
    }
}
