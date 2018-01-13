using System.Windows.Forms;

namespace Math_MADS
{
    public static class InteractiveObjectExtensions
    {
        public static bool IsBelow(this Platform interactiveObject, PictureBox platform)
        {
            return interactiveObject.Top <= platform.Top + platform.Height;
        }

        public static bool IsAbove(this Platform interactiveObject, PictureBox platform)
        {
            return interactiveObject.Top + interactiveObject.Height >= platform.Top;
        }

        public static bool IsInLine(this Platform interactiveObject, PictureBox platform)
        {
            return interactiveObject.Bottom >= platform.Top && interactiveObject.Bottom <= platform.Bottom;
        }
    }
}