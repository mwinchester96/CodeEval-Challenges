using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblemTwo
{
    class Node
    {
        private int _value;
        private List<Node> _children;
        private bool _toPrint;

        public Node(int n)
        {
            _value = n;
            _children = new List<Node>();
        }

        public int GetValue()
        {
            return _value;
        }

        public void AddChild(Node n)
        {
            _children.Add(n);
        }

        public List<Node> GetChildren()
        {
            return _children;
        }

        public void AddChildren(int StartingVal, int maxVal)
        {
            for (int i = StartingVal; i < maxVal + 1; i++)
            {
                _children.Add(new Node(i));
            }
        }

        public bool GetToPrint()
        {
            return _toPrint;
        }

        public void SetToPrint(bool toPrint)
        {
            _toPrint = toPrint;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter an integer: ");
            int input;

            if (!Int32.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Not an integer, you failed");
            }
            var newNodes = new List<Node>();

            for (int i = 1; i < input + 1; i++)
            {
                var toAdd = new Node(i);
                toAdd.AddChildren((i), input);
                newNodes.Add(toAdd);
            }

            var toPrint = new List<Node>();
            var nodeValidNums = new List<string>();
            var childValidNums = new List<string>();

            foreach (Node n in newNodes)
            {
                bool toAdd = true;

                foreach (var c in n.GetValue().ToString())
                {
                    
                }

                foreach (var c in n.GetValue().ToString())
                {
                    nodeValidNums.Add(c.ToString());
                }
                foreach (Node child in n.GetChildren())
                {
                    foreach (var c in child.GetValue().ToString().ToCharArray())
                    {
                        childValidNums.Add(c.ToString());
                    }
                    var product = (n.GetValue() * child.GetValue()).ToString();

                    var validNums = childValidNums.Concat(nodeValidNums);

                    HashSet<string> set1 = new HashSet<string>(validNums);
                    HashSet<string> set2 = new HashSet<string>(product.ToCharArray().ToList().Select(c => c.ToString()).ToList());

                    if (set1.SetEquals(set2))
                    {
                        Console.WriteLine(n.GetValue() + " * " + child.GetValue() + " = " + product);
                    }
                    childValidNums.Clear();
                }
                nodeValidNums.Clear();
            }
            Console.ReadLine();
        }
    }
}
