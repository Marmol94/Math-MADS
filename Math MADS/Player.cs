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


        public void PlayerMovement(Main prog)
        {
            if (prog.isRightMovementAvailable )
            {
                this.Left += 3;
                this.Image = Math_MADS.Properties.Resources.prawo;
            }
            else if (prog.isLeftMovementAvailable)
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
            if (main.isJumping)
            {
                this.Top -= main.force;
                if (main.wcis && main.mforce < main.force) main.force += 1;
            }

            if (this.Top + this.Height - 5 >= level.Height)
            {
                this.Top = level.Top - 5 - this.Height;
                main.isJumping = false;
                main.mforce = 15;
                main.force = Main.G;
            }
           
            else if (collision.Top(platform, this))
            {
                main.isJumping = false;
                main.mforce = 0;
                main.force = 20;
                if (!main.wcis) this.Top = platform.Top - this.Height;
            }
            else if (collision.Top(platform, this))
            {
                main.isJumping = false;
                main.mforce = 15;
                main.force = Main.G
                    ;
                if (!main.wcis) this.Top = platform.Top - this.Height;
            }
            else if (collision.Bot(platform, this))
            {
                main.force = 0;
                this.Top += main.mforce;
            }
            else if (!collision.Top(platform, this))
            {
                this.Top += main.mforce;
                if (main.mforce < main.force)
                {
                    main.mforce = main.mforce + 2;
                    main.control = true;
                }
                else if (main.control)
                {
                    main.mforce = 0;
                    main.force = 0;
                    main.mforce = main.mforce + 1;
                    main.control = false;
                }
                else
                {
                    main.mforce = main.mforce + 1;
                }
            }
            collision.SideCollisionMovementEnabler(platform, this, main);

        }

        public void FloorCollision(Main main, Collision collision, Platform platform)
        {
            if (collision.Top(platform, this))
            {
            

            main.isJumping = false;
            main.mforce = 15;
            main.force = Main.G;
            if (!main.wcis) this.Top = platform.Top - this.Height;
        }
    }
    }
}