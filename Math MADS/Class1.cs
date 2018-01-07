using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_MADS
{
    class Class1
    {
    }
}
/*public void Gravity(Player player, Platform platform, Collision collision, Level level)
{
if (player.Top + player.Height - 5 >= level.Height)
{
player.Top = level.Top - 5 - player.Height;
isJumping = false;
mforce = 15;
force = G;
}
else if (collision.Top(podloga, player))
{
isJumping = false;
mforce = 15;
force = G;
if (!wcis) player.Top = podloga.Top - player.Height;
}
else if (collision.Top(platform, player))
{
isJumping = false;
mforce = 0;
force = 20;
if (!wcis) player.Top = platform.Top - player.Height;
}
else if (collision.Top(platform, player))
{
isJumping = false;
mforce = 15;
force = G
    ;
if (!wcis) player.Top = Platform.Top - player.Height;
}
else if (collision.Bot(platform, player))
{
force = 0;
player.Top += mforce;
}
else if (!collision.Top(platform, player))
{
player.Top += mforce;
if (mforce < force)
{
    mforce = mforce + 2;
    control = true;
}
else if (control)
{
    mforce = 0;
    force = 0;
    mforce = mforce + 1;
    control = false;
}
else
{
    mforce = mforce + 1;
}
}
}*/