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
    /// Klasa gracza
    /// </summary>
    public partial class Player : Math_MADS.InteractiveObject
    {
        /// <summary>
        /// Metoda odpowiedzialna za ruch poziomy
        /// Sprawdza czy gracz znajduje się w granicach poziomu oraz czy jest dostępny ruch w prawo lub lewo i zmienia współrzędne gracza
        /// W zależności od kierunku zmienia obrazek gracza
        /// </summary>
        /// <param name="main">program</param>
        /// <param name="level">poziom</param>
        /// <param name="collision">kolizja</param>
        public void PlayerMovement(Main main, Level level, Collision collision)
        {
            if (main.isRightMovementAvailable && this.Right <= level.Width - 3 && main.isRightKeyPressed)
            {
                this.Left += 5;
                this.Image = Math_MADS.Properties.Resources.prawo;
            }
            else if (main.isLeftMovementAvailable && this.Left >= 0 && main.isLeftKeyPressed)
            {
                this.Left -= 5;
                this.Image = Math_MADS.Properties.Resources.lewo;
            }
            else
            {
                this.Image = Math_MADS.Properties.Resources.przod;
            }
        }
  
/// <summary>
/// Metoda inicjalizacji gracza na poziomie
/// Metoda wykonuje metodę InitializeObject z domyślnymi parametrami gracza
/// </summary>
/// <param name="level"></param>
        public void InitializePlayer(Level level)
        {
           
            InitializeObject(10, 450, Properties.Resources.przod, 28, 63, level,1);
        }
        /// <summary>
        /// Metoda sprawdzania kolizji gracza z platforma oraz umożliwiająca ruch pionowy
        /// Gdy zostanie wykryta kolizja z górną częścią platformy to pozycja gracza zostanie ustawiona na platformie
        /// Gdy force>0 (możliwość poruszania się w pionie) sprawdza czy gracz nie koliduje z dolną częścią platformy, jeśli nie, wznosi się on dopóki force nie będzie mniejszy od 0
        /// Sprawdza też kolizje poziomą, gdy ją wykryje uniemożliwia dalsze poruszanie się w odpowiednim kierunku
        /// </summary>
        /// <param name="collision">kolizja</param>
        /// <param name="platform">platforma</param>
        /// <param name="main">program</param>
        public void CheckCollision(Collision collision, Platform platform, Main main)
        {

            if (collision.Top(platform, this))
            {
                this.Top = platform.Top - this.Height-7;
                main.isJumping = false;

            }

            if (main.force > 0)
            {
                if (collision.Bot(platform, this))
                {
                    main.force = 0;
                    main.isJumping = false;

                }
                else
                {
                    main.force--;
                    this.Top -=6;
                }
            }
            else
            {
               // main.isJumping = false;
            }

            // collision.SideCollisionMovementEnabler(platform,this,main);

            if (collision.RightCollisionCheck(platform, this, main))
            {
                main.isRightMovementAvailable = false;
            }

            if (collision.LeftCollisionCheck(platform, this, main))
            {
                main.isLeftMovementAvailable = false;
            }
           
        }
    }
}