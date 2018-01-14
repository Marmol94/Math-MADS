using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_MADS
{
    /// <summary>
    /// Klasa obiektów interaktywnych
    /// value-wartość danego obiektu wykorzystywana w działaniach
    /// </summary>
    public class InteractiveObject : Platform
    {
        public int value;
       
        /// <summary>
        /// Metoda sprawdzająca czy gracz jest obok obiektu
        /// Sprawdzenie czy współrzędne gracza znajdują się w okolicy współrzędnych obiektu 
        /// </summary>
        /// <param name="player">Gracz</param>
        /// <returns></returns>
        public bool IsPlayerNextToObject(Player player)
        {
            return (player.Right >= this.Left - 5 && player.Left <= this.Right+5) &&
            (player.Bottom <= this.Bottom + 50 && player.Bottom >= this.Bottom - 50);
        }
        /// <summary>
        /// Metoda odpowiedzialna za podnoszenie obiektu przez gracza
        /// Gdy gracz podniesie obiekt, to prawa strona tego obiektu będzie miała wartość lewej strony gracza, a góra obiektu będzie się znajdowała 30 piks nad dolną stroną gracza 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="pickedUp"></param>
        public void PickUp(Player player, bool pickedUp)
        {
            if (IsPlayerNextToObject(player)&&pickedUp )
            {
                this.Left = player.Right;
                this.Top = player.Bottom-30;
            }
        }
        /// <summary>
        /// Metoda odpowiadająca za spadek obiektu do czasu kolizji z platforma
        /// </summary>
        /// <param name="collision">Kolizja</param>
        /// <param name="platform">Platforma</param>
        /// <param name="level">Poziom</param>
        public void FallingObject(Collision collision, Platform platform, Level level)
        {
            if (collision.Top(platform, this))
            {
                this.Top = platform.Top - this.Height - 7;
            }

            if (this.Location.Y +
                this.Height < level.Height - 2 && !collision.Top(platform, this))
            {
                this.Top += 3;
            }
        }
        /// <summary>
        /// Metoda Inicjalizacji obiektu
        /// </summary>
        /// <param name="posX">Współrzędna lewej strony obiektu</param>
        /// <param name="posY">Współrzędna górnej strony obiektu</param>
        /// <param name="image">Obraz reprezentujący obiekt</param>
        /// <param name="sizeX">szerokość</param>
        /// <param name="sizeY">wysokość</param>
        /// <param name="level">poziom do którego ma zostać przypisany obiekt</param>
        /// <param name="objectValue">wartość obiektu wykorzystywana w działaniach</param>

        public void InitializeObject(int posX, int posY, System.Drawing.Image image, int sizeX, int sizeY, Level level,
            int objectValue)
        {
            new InteractiveObject();
            Image = image;
            Size = new Size(sizeX, sizeY);
            SizeMode = PictureBoxSizeMode.Zoom;
            Location = new Point(posX, posY);
            level.Controls.Add(this);
            value = objectValue;
        }
    }
}