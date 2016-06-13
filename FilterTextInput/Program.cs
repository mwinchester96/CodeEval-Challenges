using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PracticeProblem1
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllLines("output.txt",File.ReadAllLines("input.txt").Where(arg => !string.IsNullOrWhiteSpace(arg)).Select(line => string.Join(",", line.Split().Where(x => x.Length % 2 == 0 && x.Length > 1))).ToArray());
        }
    }
}
