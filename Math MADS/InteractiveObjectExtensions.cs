using System.Windows.Forms;

namespace Math_MADS
{
    /// <summary>
    /// Klasa rozszerzeń Interaktywnych Obiektów
    /// </summary>
    public static class InteractiveObjectExtensions
    {

        /// <summary>
        /// Metoda sprawdza czy obiekt jest pod platformą
        /// </summary>
        /// <param name="interactiveObject">Interaktywny Obiekt</param>
        /// <param name="platform">Platforma</param>
        /// <returns>Zwraca true gdy obiekt jest pod platformą</returns>
        public static bool IsBelow(this Platform interactiveObject, Platform platform)
        {
            return interactiveObject.Top <= platform.Top + platform.Height;
        }
        /// <summary>
        /// Metoda sprawdza czy obiekt jest pod platformą
        /// </summary>
        /// <param name="interactiveObject">Interaktywny Obiekt</param>
        /// <param name="platform">Platforma</param>
        /// <returns>Zwraca true gdy obiekt jest nad platformą</returns>
        public static bool IsAbove(this Platform interactiveObject, Platform platform)
        {
            return interactiveObject.Top + interactiveObject.Height >= platform.Top;
        }
        /// <summary>
        /// Metoda sprawdza czy obiekt jest pomiędzy współrzędnymi pionowymi platformy
        /// </summary>
        /// <param name="interactiveObject">Interaktywny Obiekt</param>
        /// <param name="platform">Platforma</param>
        /// <returns>Zwraca true gdy obiekt jest pod platformą</returns>
        public static bool IsInLine(this Platform interactiveObject, Platform platform)
        {
            return interactiveObject.Bottom >= platform.Top && interactiveObject.Bottom <= platform.Bottom;
        }
    }
}