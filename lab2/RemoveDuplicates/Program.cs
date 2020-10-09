using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments!\nUsage remove_duplicates.exe <input string>");
            }
            else
            {
                var duplicates = "";
                foreach (var ch in args[0].Where(ch => !duplicates.Contains(ch)))
                {
                    duplicates += ch;
                    Console.Write(ch);
                }
                Console.WriteLine();
            }
        }
    }
}