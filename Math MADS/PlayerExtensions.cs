using System.Windows.Forms;

namespace Math_MADS
{
    public static class PlayerExtensions
    {
        public static bool IsBelow(this Player player, PictureBox platform)
        {
            return player.Top <= platform.Top + platform.Height;
        }

        public static bool IsAbove(this Player player, PictureBox platform)
        {
            return player.Top + player.Height >= platform.Top+5;
        }

        public static bool IsInLine(Player player, PictureBox platform)
        {
            return player.Bottom >= platform.Top && player.Bottom <= platform.Bottom;
        }
    }
}