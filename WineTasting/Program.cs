using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WineTasting
{
    class Program
    {
        static void Main(string[] args)
        {
            var allAnswers = new List<string>();

            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine().ToString();
                    if (null == line)
                        continue;
                    var splitList = line.Split('|');

                    var rememberedLetters = splitList[1].ToCharArray();
                    var wineTypes = splitList[0].Split(' ');
                    var containsAllLetters = true;
                    var satisfyingWines = new StringBuilder();

                    foreach (string wine in wineTypes)
                    {
                        foreach (char l in rememberedLetters)
                        {
                            if (!wine.Contains(l.ToString()))
                            {
                                containsAllLetters = false;
                                break;
                            }
                            else
                            {
                                containsAllLetters = true;
                            }
                        }

                        if (containsAllLetters)
                        {
                            satisfyingWines.Append(wine.ToString() + ' ');
                        }
                        else
                        {
                            allAnswers.Add("False");
                        }
                    }
                    allAnswers.Add(satisfyingWines.ToString());
                }

            foreach(string ans in allAnswers)
            {
                Console.WriteLine(ans);
            }
        }
    }
}
