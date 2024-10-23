using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyUnitTest.APP.Interfaces
{
    public interface ICalculatorService //Burası mock için olması gerekli
    {
        int add(int a, int b);

        int multipt(int a, int b);
    }
}
