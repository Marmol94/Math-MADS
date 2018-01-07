using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_MADS
{
    public class InteractiveObject:Math_MADS.Player
    {
        public void InitializeObject(int posX, int posY, Level level, System.Drawing.Image image, int sizeX, int sizeY)
        {
            InitializePlayer(posX, posY, level);
            Image = image;
            Size= new Size(sizeX,sizeY);
            Location=new Point(posX,posY);
        }

        public int ObjectValue(int value)
        {
            return value;
        }

        public void PickUp(Player player, bool pickedUp)
        {
           
           if(((player.Right >= this.Left-5 && player.Left <= this.Right) &&
               (player.Bottom >= this.Bottom || player.Bottom <= this.Bottom + 26))&&!pickedUp)
           {
               this.Left = player.Right;
               this.Top = player.Bottom - 30;
               pickedUp = true;

           }
        }
        public void FallingObject(Collision collision, Platform platform, Main main, Level level)
        {
            if (collision.Top(platform, this))
            {
                this.Top = platform.Top - this.Height-7;
                main.wcis = false;
            }

            if (this.Location.Y +
                this.Height < level.Height - 2 && !collision.Top(platform, this))
            {
                this.Top += 4;
            }

        }

        
    }
}
