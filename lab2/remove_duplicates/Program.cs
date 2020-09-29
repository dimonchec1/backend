using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remove_duplicates
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
                string duplicates = "";
                foreach (char item in args[0])
                {
                    if (duplicates.Contains(item))
                    {
                        continue;
                    }
                    duplicates += item;
                    Console.Write(item);
                }
                Console.WriteLine();
            }
        }
    }
}
