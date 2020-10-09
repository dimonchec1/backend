using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIdentifier
{
    public class Program
    {
        public static bool IsEngLetter(char ch)
        {
            return (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z');
        }

        public static string IsIdentifier(string identifier)
        {
            if (identifier == "")
            {
                return "no, Empty string is not an identifier!";
            }
            if (!IsEngLetter(identifier[0]))
            { 
                return "no, The identifier must start with a letter!";
            }
            for (var i = 1; i < identifier.Length; i++)
            {
                if (!(IsEngLetter(identifier[i]) || char.IsDigit(identifier[i])))
                {
                    return "no, The identifier must contain only digits or letters";
                }
            }
            return "yes";
        }

        private static void Main(string[] args)
        {
            Console.WriteLine(args.Length == 1 ? IsIdentifier(args[0]) : "Incorrect number of arguments!\nUsage remove_duplicates.exe <input string>");
        }
    }
}
