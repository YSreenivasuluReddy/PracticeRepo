using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddEx
{
    internal class Program
    {
        public int Add()
        {
            int a = 10; int b = 20;
            return a + b;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Add();
            Console.WriteLine(p.Add());
            Console.ReadLine();
        }
    }
}
