using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordStrength
{
    public class Program
    {
        public static int GetStrengthForChars(string password)
        {
            return password.Length * 4;
        }

        public static int GetStrengthForDigits(string password)
        {
            return password.Count(ch => ch >= '0' && ch <= '9') * 4;
        }

        public static int GetStrengthForUpperCase(string password)
        {
            return password.Count(ch => ch >= 'A' && ch <= 'Z') > 0 ? (password.Length - password.Count(ch => ch >= 'A' && ch <= 'Z')) * 2 : 0;
        }

        public static int GetStrengthForLowerCase(string password)
        {
            return password.Count(ch => ch >= 'a' && ch <= 'z') > 0 ? (password.Length - password.Count(ch => ch >= 'a' && ch <= 'z')) * 2 : 0;
        }

        public static int GetStrengthIfOnlyDigits(string password)
        {
            return password.Length == password.Count(ch => ch >= '0' && ch <= '9') ? password.Length : 0;
        }

        public static int GetStrengthIfOnlyLetters(string password)
        {
            return password.Length == password.Count(ch => (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')) ? password.Length : 0;
        }

        public static int GetStrengthForRepetitiveChars(string password)
        {
            var duplicates = "";
            var counter = 0;
            foreach (var ch in password.Where(ch => !duplicates.Contains(ch)))

            {
                duplicates += ch;
            }

            foreach (char ch in duplicates)
            {
                if (password.Count(x => x == ch) > 1)
                {
                    counter += password.Count(x => x == ch);
                }
            }

            return counter;
        }
        private static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments!\nUsage PasswordStrength.exe <input string>");
                return;
            }

            if (args[0].Count(ch => !((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9'))) > 0)
            {
                Console.WriteLine("String must contain only letters or digits!");
                return;
            }

                var strength = 0;
            var password = args[0];
            strength += GetStrengthForChars(password);
            strength += GetStrengthForDigits(password);
            strength += GetStrengthForUpperCase(password);
            strength += GetStrengthForLowerCase(password);
            strength -= GetStrengthIfOnlyDigits(password);
            strength -= GetStrengthIfOnlyLetters(password);
            strength -= GetStrengthForRepetitiveChars(password);

            Console.WriteLine(strength);
        }
    }
}
