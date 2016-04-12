using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Calculator = CalculatorTestVSP.Calculator;

namespace Calculator.Test.Unit
{
    [TestFixture]
    public class CalcUnitTest
    {
        private CalculatorTestVSP.Calculator _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new CalculatorTestVSP.Calculator();
        }

        [Test]
        public void Add_Add2and4_ReturnsSix()
        { 
            Assert.That(_uut.Add(2,4),Is.EqualTo(6));
        }

        [Test]
        public void Subtract_sub2and6_returnMinusFour()
        {
            Assert.That(_uut.Subtract(2,6),Is.EqualTo(-4));
        }

        [Test]
        public void Add_Add4and8_returns12()
        {
            Assert.That(_uut.Add(4,8),Is.EqualTo(12));
        }

        [TestCase(9,8,17)]
        [TestCase(120,10,130)]
        [TestCase(120,17,137)]
        [TestCase(120,15,135)]
        public void Add_AddTwoNumbers_returnsCorr(double a, double b, double c)
        {
            Assert.That(_uut.Add(a,b),Is.EqualTo(c));
        }

        [Test]
        public void Divide_DivideWithZero_ThrowsArgException()
        {
            Assert.Throws<DivideByZeroException>(() => _uut.Divide(5, 0));
        }
    }
}
