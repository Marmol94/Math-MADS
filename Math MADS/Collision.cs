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


        public bool Bot(PictureBox platform, PictureBox player)
        {
            return PlayerExtensions.IsInLine(player, platform) &&
                   player.Right <= platform.Right + player.Width/4 && player.Left >= platform.Left - player.Width/4;
        }

        public bool Top(PictureBox platform, PictureBox player)
        {
            return PlayerExtensions.IsInLine(player, platform) &&
                   player.Right >= platform.Left + player.Width / 4 && player.Left + player.Width / 4 <= platform.Right;
        }

       

        public void SideCollisionMovementEnabler(PictureBox platform, PictureBox player, Prog prog)
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