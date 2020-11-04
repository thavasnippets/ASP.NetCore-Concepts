using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Components
{
    public interface ICalc<T>
    {
        T add(T num1, T num2);
    }
    public class Calc<T> : ICalc<T>
    {
        public T add(T num1, T num2)
        {
            dynamic n1 = num1;
            dynamic n2 = num2;
            return n1 + n2;
        }
    }
}
