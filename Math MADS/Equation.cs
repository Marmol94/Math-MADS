using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_MADS
{
    public class Equation
    {
        public int EquationSolve(InteractiveObject firstBox, InteractiveObject secondBox, InteractiveObject sign, InteractiveObject leftChecker,InteractiveObject rightChecker)
        {
            if(firstBox.Bottom == leftChecker.Top &&
               secondBox.Bottom == rightChecker.Top &&
               firstBox.Right >= leftChecker.Left &&
               firstBox.Left <= leftChecker.Right && secondBox.Right >= rightChecker.Left &&
               secondBox.Left <= rightChecker.Right)
            switch (sign.value)
            {
                case 1:
                    return firstBox.value - secondBox.value;

                case 2:
                    return firstBox.value / secondBox.value;

                case 3:
                    return firstBox.value * secondBox.value;

                default:
                    return firstBox.value + secondBox.value;
            }
            else
            {
                return -20000;
            }
        }
    }
}