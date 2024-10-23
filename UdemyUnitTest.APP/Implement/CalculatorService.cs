using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyUnitTest.APP.Interfaces;

namespace UdemyUnitTest.APP.Implement
{
    public class CalculatorService : ICalculatorService
    {
        //implement edilecek
        public int add(int a, int b)
        {
            if (a == 0 || b == 0)
            {
                return 0;
            }

            return a + b;
        }

        public int multipt(int a, int b)
        {
            if (a == 0)
            {
                throw new Exception("a = 0 olamaz");//Hata mesajını fırlattık burada 
            }


            return a * b;
        }
    }
}
