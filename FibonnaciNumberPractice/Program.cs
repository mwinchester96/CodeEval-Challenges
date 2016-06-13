using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FibonnaciPractice
{

    class Program
    {
        static void Main(string[] args)
        {
            //var allNums = File.ReadAllLines("input.txt").Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();
            var allNums = new List<string>();
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    allNums.Add(line);
                }

            var fibList = new List<string>();

            for (int i = 0; i < allNums.Count(); i++)
            {
                fibList.Add(calculateFib(Convert.ToInt32(allNums[i])).ToString());
            }
            //File.WriteAllLines("out.txt", fibList);
            foreach(string line in fibList)
            {
                Console.Out.WriteLine(line);
            }
        }

        private static int calculateFib(int num)
        {
            int a = 0;
            int b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < num; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }

}
