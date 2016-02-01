using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTestVSP
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator();

            Console.WriteLine(c.Power(2, 3));

            Console.WriteLine(c.Add(3, 7));

            Console.WriteLine(c.Multiply(10, 21));

            Console.WriteLine(c.Subtract(20, 80));

        }
    }
}
