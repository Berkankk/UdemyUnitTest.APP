using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyUnitTest.APP.Interfaces;

namespace UdemyUnitTest.APP.Calculatorss
{
    public class Calculator
    {
        private readonly ICalculatorService _calculatorService; //private olma sebebi dış dünyaya açılmayacak

        public Calculator(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public int add(int a, int b)
        {
            return _calculatorService.add(a, b);
        }

        public int multip(int a, int b)
        {
            return _calculatorService.multipt(a, b);
        }
    }
}
