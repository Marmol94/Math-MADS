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
        public bool Bot(Platform platform, Platform interactiveObject)
        {
            Platform temp1 = new Platform();
            temp1.Bounds = platform.Bounds;
            temp1.SetBounds(temp1.Location.X, temp1.Location.Y + temp1.Height, temp1.Width, 1);
            return interactiveObject.Bounds.IntersectsWith(temp1.Bounds);
        }

        public bool Top(Platform platform, Platform interactiveObject)
        {
  




            return interactiveObject.IsInLine(platform) &&
                   interactiveObject.Right >= platform.Left +interactiveObject.Width/4 &&
                   interactiveObject.Left /*+ interactiveObject.Width / 4*/ <= platform.Right;
        }


        public bool RightCollisionCheck(Platform platform, Platform interactiveObject, Main prog)
        {
            var isSharingVerticalSpace = interactiveObject.IsBelow(platform) && interactiveObject.IsAbove(platform);


            return interactiveObject.Right+4 >= platform.Left && interactiveObject.Right <= platform.Right  &&
                   isSharingVerticalSpace;
        }

        public bool LeftCollisionCheck(Platform platform, Platform interactiveObject, Main prog)
        {
            var isSharingVerticalSpace = interactiveObject.IsBelow(platform) && interactiveObject.IsAbove(platform);

            return interactiveObject.Left-4 <= platform.Right && interactiveObject.Left >= platform.Left &&
                   isSharingVerticalSpace;
        }
        public void SideCollisionMovementEnabler(Platform platform, Platform interactiveObject, Main prog)
        {
            var isSharingVerticalSpace = interactiveObject.IsBelow(platform) && interactiveObject.IsAbove(platform);
            if ((interactiveObject.Left <= platform.Right && interactiveObject.Left >= platform.Left && isSharingVerticalSpace))
            {
                prog.isLeftMovementAvailable = false;
            }

            if (platform.Left <= interactiveObject.Right && interactiveObject.Right <= platform.Right && isSharingVerticalSpace)
            {
                prog.isRightMovementAvailable = false;
            }
        }
    }
}