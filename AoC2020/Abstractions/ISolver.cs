using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020.Abstractions
{
   public interface ISolver<T>
    {
        T StepA();
        T StepB();
    }
}
