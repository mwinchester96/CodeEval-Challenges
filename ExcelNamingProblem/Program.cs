using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExcelNew
{
    class Program
    {
        private const string _inputFile = "in.txt";

        static void Main(string[] args)
        {
            var dict = new Dictionary<int, string>()
            {
                { 1, "A"},
                { 2, "B"},
                { 3, "C"},
                { 4, "D"},
                { 5, "E"},
                { 6, "F"},
                { 7, "G"},
                { 8, "H"},
                { 9, "I"},
                { 10, "J"},
                { 11, "K"},
                { 12, "L"},
                { 13, "M"},
                { 14, "N"},
                { 15, "O"},
                { 16, "P"},
                { 17, "Q"},
                { 18, "R"},
                { 19, "S"},
                { 20, "T"},
                { 21, "U"},
                { 22, "V"},
                { 23, "W"},
                { 24, "X"},
                { 25, "Y"},
            };

            using (StreamReader reader = File.OpenText(_inputFile))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                    {
                        continue;
                    }
                    var n = Convert.ToInt32(line);
                    var isDone = false;
                    var revColumnName = new StringBuilder();
                    while (!isDone)
                    {
                        var tempMod = n % 26;
                        if (tempMod == 0)
                        {
                            revColumnName.Append("Z");
                            n = (n / 26) - 1;
                        }
                        if (tempMod != 0)
                        {
                            revColumnName.Append(dict[tempMod]);
                            n = n / 26;
                        }
                        if (n == 0)
                        {
                            isDone = true;
                        }
                    }
                    char[] arr = revColumnName.ToString().ToCharArray();
                    Array.Reverse(arr);
                    Console.WriteLine(arr);
                    Console.ReadLine();
                }
        }
    }
}
