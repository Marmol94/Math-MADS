using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_MADS
{
    public partial class Player : System.Windows.Forms.PictureBox
    {

        public void InitializePlayer(int x, int y, Level level)
        {
            Image = global::Math_MADS.Properties.Resources.przod;
            Size = new System.Drawing.Size(28, 63);
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Location = new System.Drawing.Point(x, y);
            level.Controls.Add(this);
        }


        public void PlayerMovement(Main prog, Level level, Collision collision)
        {
            if (prog.isRightMovementAvailable && this.Right <= level.Width - 3)
            {
                this.Left += 3;
                this.Image = Math_MADS.Properties.Resources.prawo;
            }
            else if (prog.isLeftMovementAvailable && this.Left >= 0)
            {
                this.Left -= 3;
                this.Image = Math_MADS.Properties.Resources.lewo;
            }
            else
            {
                this.Image = Math_MADS.Properties.Resources.przod;
            }
        }

        public void CheckCollision(Collision collision, Platform platform, Main main, Level level)
        {
            if (collision.Top(platform, this))
            {
                this.Top = platform.Top - this.Height;
                main.wcis = false;
            }

            else if (main.force > 0)
            {
                if (collision.Bot(platform, this))
                {
                    main.force = 0;
                    main.wcis = false;
                }
                else
                {
                    main.force--;
                    this.Top -= 4;
                }
            }
            else
            {
                main.isJumping = false;
            }

           


            collision.SideCollisionMovementEnabler(platform, this, main);
        }

        public void Falling(Collision collision, Platform platform, Main main, Level level)
        {
            if (!main.isJumping && this.Location.Y +
                this.Height < level.Height - 2 && !collision.Top(platform, this))
            {
                this.Top += 4;
            }
        }
        
    }
}