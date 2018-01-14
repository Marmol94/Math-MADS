using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_MADS
{
    /// <summary>
    /// Klasa odpowiedzialna za działania na wartościach obiektów
    /// </summary>
    public class Equation
    {
        /// <summary>
        /// Metoda zwracająca wynik działania
        ///
        /// </summary>
        /// <param name="firstBox">pierwsza skrzynka</param>
        /// <param name="secondBox">druga szkrynka</param>
        /// <param name="sign">znak działania</param>
        /// <param name="leftChecker">lewa platforma działania</param>
        /// <param name="rightChecker">prawa platforma działania</param>
        /// <returns> Zwraca ona wartości działania gdy skrzynki znajdą się w odpowiednich miejscach (Horyzontalnie), gdy się nie znajdują zwraca -2000 </returns>
        public int EquationSolve(InteractiveObject firstBox, InteractiveObject secondBox, InteractiveObject sign, InteractiveObject leftChecker,InteractiveObject rightChecker)
        {
            if(firstBox.Right >= leftChecker.Left &&
               firstBox.Left <= leftChecker.Right && secondBox.Right >= rightChecker.Left &&
               secondBox.Left <= rightChecker.Right)
                return CheckSign(firstBox, secondBox, sign,leftChecker,rightChecker);
            else if (secondBox.Right >= leftChecker.Left &&
                     secondBox.Left <= leftChecker.Right && firstBox.Right >= rightChecker.Left &&
                     firstBox.Left <= rightChecker.Right)
                return CheckSign(secondBox, firstBox, sign, leftChecker, rightChecker);
            else
            {
                return -2000;
            }
        }
        /// <summary>
        /// Metoda Sprawdzająca znak i wykonująca odpowiadające mu zadanie
        /// </summary>
        /// <param name="firstBox">pierwsza skrzynka</param>
        /// <param name="secondBox">druga szkrynka</param>
        /// <param name="sign">znak działania</param>
        /// <param name="leftChecker">lewa platforma działania</param>
        /// <param name="rightChecker">prawa platforma działania</param>
        /// <returns>Zwraca wartość równania w zależności od znaku, gdy skrzynka ma te same współrzędne pionowe, w przeciwnym wypadku zwraca -2000</returns>
        private static int CheckSign(InteractiveObject firstBox, InteractiveObject secondBox, InteractiveObject sign, InteractiveObject leftChecker, InteractiveObject rightChecker)
        {
            if(firstBox.Bottom == leftChecker.Top &&
               secondBox.Bottom == rightChecker.Top)
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