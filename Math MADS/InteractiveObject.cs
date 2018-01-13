using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_MADS
{
    public class InteractiveObject : Platform
    {
        public int value;

        public int ObjectValue()
        {
            return value;
        }
        
        public bool IsPlayerNextToObject(Player player)
        {
            return (player.Right >= this.Left - 5 && player.Left <= this.Right) &&
            (player.Bottom <= this.Bottom + 15 && player.Bottom >= this.Bottom - 15);
        }

        public void PickUp(Player player, bool pickedUp)
        {
            if (IsPlayerNextToObject(player)&&pickedUp )
            {
                this.Left = player.Right;
                this.Top = player.Bottom-30;
            }
        }

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


        public void InitializeObject(int posX, int posY, System.Drawing.Image image, int sizeX, int sizeY, Level level,
            int objectValue)
        {
            Image = image;
            Size = new Size(sizeX, sizeY);
            SizeMode = PictureBoxSizeMode.Zoom;
            Location = new Point(posX, posY);
            level.Controls.Add(this);
            value = objectValue;
        }
    }
}