using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTestVSP
{
    public class CalculatorTest
    {
        public void TestAdd()
        {
            if (c.Add(2, 6) == 8)
                Console.WriteLine("Addition test:           SUCCESS! ");
            else
                Console.WriteLine("Addition test:           FAILED! ");
        }

        public void TestSubtract()
        {
            if (c.Subtract(6, 8) == -2 && c.Subtract(8, 6) == 2)
                Console.WriteLine("Subtraction test:        SUCCESS! ");
            else
                Console.WriteLine("Addition test:           FAILED! ");
        }

        public void TestMultiply()
        {
            if (c.Multiply(3, 8) == 24 && c.Multiply(8, 0) == 0 && c.Multiply(-2, -2) == 4)
                Console.WriteLine("Multiplication test:     SUCCESS! ");
            else
                Console.WriteLine("Addition test:           FAILED! ");
        }

        public void TestPower()
        {
            if (c.Power(1,10) == 1 && c.Power(8,0) == 1 && c.Power(2,2) == 4)
                Console.WriteLine("Power test:              SUCCESS! ");
            else
                Console.WriteLine("Power test:              FAILED! ");
        }

        public void TestDivision()
        {
            try
            {
                if (c.Divide(5, 1) == 5 && c.Divide(1, 5) == 0.2)
                    Console.WriteLine("Division test:           SUCCESS! ");
                else
                    Console.WriteLine("Division test            FAILED! ");
                c.Divide(8, 0); //This must throw an exception!

            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division by 0 test:      SUCCESS! ");
            }
        }

        private Calculator c = new Calculator();
    }
}
