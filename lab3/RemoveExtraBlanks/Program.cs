using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveExtraBlanks
{
    public class Program
    {
        public static void RemoveRepetitiveSeparatorsInLine(ref string str)
        {
            var newStr = "";
            var isRepeat = false;
            foreach (char ch in str)
            {
                if (!((ch == ' ') || (ch == '\t')))
                {
                    newStr += ch;
                    isRepeat = false;
                    continue;
                }

                if (isRepeat) continue;

                newStr += ch;
                isRepeat = true;
            }
            str = newStr;
        }

        public static void RemoveExtraSeparatorsInLine(ref string str)
        {
            str = str.Trim();
            RemoveRepetitiveSeparatorsInLine(ref str);
        }

        public static void ReadFileAndRemoveExtraSeparatorsInLines(string inputFilename, string outputFilename)
        {
            using (var strReader = new StreamReader(inputFilename, Encoding.UTF8))
            using (var strWriter = new StreamWriter(outputFilename, false, Encoding.UTF8))
            {
                string str;
                while ((str = strReader.ReadLine()) != null)
                {
                    RemoveExtraSeparatorsInLine(ref str);
                    strWriter.WriteLine(str);
                }
            }




        }

        public static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Incorrect number of arguments!\nUsage remove_duplicates.exe <input string>");
                return 1;
            }

            var inputFilename = args[0];
            var outputFilename = args[1];

            if (!File.Exists(inputFilename))
            {
                Console.WriteLine("File  " + inputFilename + " doesn't exist");
                return 2;
            }

            ReadFileAndRemoveExtraSeparatorsInLines(inputFilename, outputFilename);

            Console.WriteLine("Extra separators was successfully deleted from " + inputFilename);

            return 0;
        }
    }
}
