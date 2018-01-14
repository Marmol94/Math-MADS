using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_MADS
{
    /// <summary>
    /// Klasa kontrolna wykrycia kolizji
    /// </summary>
    public partial class Collision
    {
        /// <summary>
        /// Metoda kolizji dolnej
        /// </summary>
        /// <param name="platform">platforma</param>
        /// <param name="interactiveObject">obiekt Interaktywny</param>
        /// <returns>Zwraca true gdy obiekt koliduje z granicami wirtualnego obiektu temp1(Lewa granica taka sama jak dla platformy,Górna granica równa dolnej platformy, szerokość ta sama, wysokość 1 piksel)</returns>
        public bool Bot(Platform platform, Platform interactiveObject)
        {
            Platform temp1 = new Platform();
            temp1.Bounds = platform.Bounds;
            temp1.SetBounds(temp1.Left, temp1.Top + temp1.Height, temp1.Width, 1);
            return interactiveObject.Bounds.IntersectsWith(temp1.Bounds);
        }
        /// <summary>
        /// Metoda kolizji górnej
        ///
        /// </summary>
        /// <param name="platform">platforma</param>
        /// <param name="interactiveObject">obiekt interaktywny</param>
        /// <returns>zwraca true gdy gracz koliduje z górną częścią platformy</returns>
        public bool Top(Platform platform, Platform interactiveObject)
        {
            return interactiveObject.IsInLine(platform) &&
                   interactiveObject.Right >= platform.Left + interactiveObject.Width / 4 &&
                   interactiveObject.Left + interactiveObject.Width / 4 <= platform.Right;
        }

        /// <summary>
        /// Metoda prawej kolizji
        /// </summary>
        /// <param name="platform">platforma</param>
        /// <param name="interactiveObject">Obiekt interaktywny</param>
        /// <param name="main">Program</param>
        /// <returns>Zwraca true gdy prawa strona obiektu koliduje z lewą stroną platformy </returns>
        public bool RightCollisionCheck(Platform platform, Platform interactiveObject, Main main)
        {
            var isSharingVerticalSpace = interactiveObject.IsBelow(platform) && interactiveObject.IsAbove(platform);


            return interactiveObject.Right + 4 >= platform.Left && interactiveObject.Right <= platform.Right &&
                   isSharingVerticalSpace;
        }
        /// <summary>
        /// Metoda lewej kolizji
        /// </summary>
        /// <param name="platform">platforma</param>
        /// <param name="interactiveObject">obiekt interaktywny</param>
        /// <param name="main">program</param>
        /// <returns>Zwraca true gdy lewa strona obiektu koliduje z prawą stroną platformy </returns>
        public bool LeftCollisionCheck(Platform platform, Platform interactiveObject, Main main)
        {
            var isSharingVerticalSpace = interactiveObject.IsBelow(platform) && interactiveObject.IsAbove(platform);

            return interactiveObject.Left - 4 <= platform.Right && interactiveObject.Left >= platform.Left &&
                   isSharingVerticalSpace;
        }

        
    }
}