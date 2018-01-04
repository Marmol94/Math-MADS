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

        int x1, x2, x3, x4, y1, y2, y3, y4, w, h1, h2;
        public bool Bot(PictureBox P, PictureBox G)
        {

            x1 = P.Right;
            x2 = P.Left;
            y1 = P.Top;
            y2 = P.Bottom;

            x3 = G.Right;
            x4 = G.Left;
            y3 = G.Top;
            y4 = G.Bottom;

            w = G.Width;
            h1 = P.Height;
            h2 = G.Height;
            if (y2 >= y3 && y1<=y4 && x3 <= x1+w && x4 >= x2-w)
            {
                return (true);
            }
            else return (false);
            
        }
        
        public bool Top(PictureBox P, PictureBox G)
        {

            x1 = P.Right;
            x2 = P.Left;
            y1 = P.Top;
            y2 = P.Bottom;

            x3 = G.Right;
            x4 = G.Left;
            y3 = G.Top;
            y4 = G.Bottom;

            w = G.Width;
            h1 = P.Height;
            h2 = G.Height;

            if (y4 >= y1 && y4 <= y2 && x3 >= x2 + w / 4 && x4 + w / 4 <= x1)
            {

                return (true);


            }

            else
            {
                return (false);
            }
        }

        public void SideCollision(PictureBox P, PictureBox G, Prog prog)
        {
            int x1, x2, x3, x4, y1, y2, y3, y4, w, h1, h2;

            x1 = P.Right;
            x2 = P.Left;
            y1 = P.Top;
            //y2 = P.Bottom;

            x3 = G.Right;
            x4 = G.Left;
            y3 = G.Top;
            y4 = G.Bottom;

            //w = P.Width;
            h1 = P.Height;
            h2 = G.Height;
            if ((x4 <= x1 && x4 >= x2 && (y3 <= y1 + h1 + 5 && y3 + h2 >= y1 + 5)))
            {
                prog.lewo = false;

            }

            if (x3 >= x2 && x3 <= x1 && (y3 <= y1 + h1 + 5 && y3 + h2 >= y1 + 5))
            {
                prog.prawo = false;

            }


        }
    }

    
}
