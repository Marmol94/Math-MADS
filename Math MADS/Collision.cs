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
    public partial class Collision
    {
        const int Grav = 35;


        public bool Bot(Platform platform, Player player)
        {
           Platform temp1 = new Platform();
            temp1.Bounds = platform.Bounds;
            temp1.SetBounds(temp1.Location.X, temp1.Location.Y + temp1.Height, temp1.Width, 1);
            return player.Bounds.IntersectsWith(temp1.Bounds);
        }

        public bool Top(Platform platform, Player player)
        {

            return player.IsInLine(platform) &&
                   player.Right >= platform.Left + player.Width / 4 && player.Left + player.Width / 4 <= platform.Right;
        }

       

        public void SideCollisionMovementEnabler(Platform platform, Player player, Main prog)
        {
            var isSharingVerticalSpace = player.IsBelow(platform) && player.IsAbove(platform);
            if ((player.Left <= platform.Right && player.Left >= platform.Left && isSharingVerticalSpace))
            {
                prog.isLeftMovementAvailable = false;
            }

            if (platform.Left <= player.Right && player.Right <= platform.Right && isSharingVerticalSpace)
            {
                prog.isRightMovementAvailable = false;
            }
        }
       
    }
}