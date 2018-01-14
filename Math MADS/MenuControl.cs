using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_MADS
{
    /// <summary>
    /// Klasa kontrolek menu
    /// </summary>
    public class MenuControl:System.Windows.Forms.PictureBox
    {
        /// <summary>
        /// Inicjalizacja wskaźnika do wybierania opcji
        /// </summary>
        /// <param name="menu">menu</param>
        public void InitializeChooser(Menu menu)
        {

            Image = Properties.Resources.przod;
            Location = new System.Drawing.Point(180,180);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Size = new System.Drawing.Size(45, 50);
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            Visible = true;
            menu.Controls.Add(this);
            BackColor = Color.Transparent;
        }
        /// <summary>
        /// Inicjalizacja  opcji wyboru
        /// </summary>
        /// <param name="LocX">Współrzędna lewa</param>
        /// <param name="LocY">Współrzędna prawa</param>
        /// <param name="menu">menu</param>
        /// <param name="image">obrazek opcji</param>
        public void InitializeOption( int LocX,int LocY, Menu menu, System.Drawing.Image image)
        {

            Image = image;
            Location = new System.Drawing.Point(LocX, LocY);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Size = new System.Drawing.Size(180, 90);
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            Visible = true;
            menu.Controls.Add(this);
            BackColor = Color.Transparent;
        }

        /// <summary>
        /// Metoda zmiany pozycji kontrolki w górę
        /// </summary>
        public void ChangeControlPositionUp()
        {
            Location = new System.Drawing.Point(this.Left, this.Top - 100);

        }
        /// <summary>
        /// Metoda zmiany pozycji kontrolki w dół
        /// </summary>
        public void ChangeControlPositionDown()
        {
            Location = new System.Drawing.Point(this.Left, this.Top + 100);

        }
        /// <summary>
        /// Metoda zmiany pozycji kontrolki w lewo
        /// </summary>
        public void ChangeControlPositionLeft()
        {
            Location = new System.Drawing.Point(this.Left-140, this.Top);

        }
        /// <summary>
        /// Metoda zmiany pozycji kontrolki w prawo
        /// </summary>
        public void ChangeControlPositionRight()
        {
            Location = new System.Drawing.Point(this.Left+140, this.Top);

        }
    }
}
