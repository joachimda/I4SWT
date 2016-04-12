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
            CalculatorTest ct = new CalculatorTest();
            Calculator c = new Calculator();            
            ct.TestAdd();
            ct.TestMultiply();
            ct.TestPower();
            ct.TestSubtract();
            ct.TestDivision();


        }
    }
}
