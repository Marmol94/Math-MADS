using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_MADS
{
    public partial class Player : Math_MADS.InteractiveObject
    {
        public void PlayerMovement(Main prog, Level level, Collision collision)
        {
            if (prog.isRightMovementAvailable && this.Right <= level.Width - 3 && prog.isRightKeyPressed)
            {
                this.Left += 5;
                this.Image = Math_MADS.Properties.Resources.prawo;
            }
            else if (prog.isLeftMovementAvailable && this.Left >= 0 && prog.isLeftKeyPressed)
            {
                this.Left -= 5;
                this.Image = Math_MADS.Properties.Resources.lewo;
            }
            else
            {
                this.Image = Math_MADS.Properties.Resources.przod;
            }
        }

        public void Falling(Collision collision, Platform platform, Main main, Level level)
        {
            if (!main.isJumping && this.Location.Y +
                this.Height < level.Height - 2 && !collision.Top(platform, this))
            {
                this.Top += 6;
            }
        }

        public void InitializePlayer(Level level)
        {
           
            InitializeObject(10, 450, Properties.Resources.przod, 28, 63, level,1);
        }

        public void CheckCollision(Collision collision, Platform platform, Main main)
        {

            if (collision.Top(platform, this))
            {
                this.Top = platform.Top - this.Height-7;
               // main.CanJump = true;
            }

            else if (main.force > 0)
            {
                if (collision.Bot(platform, this))
                {
                    main.force = 0;
                }
                else
                {
                    main.force--;
                    this.Top -=6;
                }
            }
            else
            {
                main.isJumping = false;
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