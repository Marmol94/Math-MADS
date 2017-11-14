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
  
    public partial class Gra : Form
    {
        bool prawo, lewo, skok, spadek ;
        bool spadanie=true;
        int force;
        int G =30;
        int mforce;

        public void collision(PictureBox P, PictureBox G, bool s)
        {
            int x1, x2, x3, x4, y1, y2, y3, y4, w, h1, h2;
            x1 = P.Right;
            x2 = P.Left;
            y1 = P.Top;
            //y2 = P.Bottom;

            x3 = G.Right;
            x4 = G.Left;
            y3 = G.Top;
            //y4 = G.Bottom;

            //w = P.Width;
            h1 = P.Height;
            h2 = G.Height;
            if (x4 <= x1 && x4>=x2 && (y3 <= y1+h1 && y3+h2 >= y1))
            {

                lewo = false;
                if(y3-h2<=y1)
                {
                    s = true;
                    y3 = y1-h2;
                }
            }

            if (x3 >= x2 && x3<=x1 && (y3 <= y1+h1 && y3+h2 >= y1))
                prawo = false;

            //while (x1 <= x3 + w / 2 && x1 >= x3 + w / 2)
              //  lewo = false;

          //  while (x1 <= x3 + w / 2 && x1 >= x3 + w / 2)
            //    lewo = false;
        }
    
        public Gra()
        {
            InitializeComponent();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            collision(Platform, Gracz, spadek);

            if (skok  && spadanie )
            {

                
                    Gracz.Top -= force;
                
                force +=1;
 
                 
                }
            
            if (Gracz.Top + Gracz.Height >= screen.Height&&!spadek)
            {
                Gracz.Top = screen.Height - Gracz.Height;
                skok = false;
                spadanie = false;

            }
            else if(!spadek)
            {
                Gracz.Top += mforce;
                mforce = mforce+3;

            }

      
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            collision(Platform, Gracz, spadek);

            if (prawo == true) { Gracz.Left += 1; }
            if (lewo == true) { Gracz.Left -= 1; }

            

        }


        private void Gra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) {
                prawo = true;
                collision(Platform, Gracz, spadek);
                 
            }
            if (e.KeyCode == Keys.Left) {
                lewo = true;
                collision(Platform, Gracz, spadek);
                 
            }
            if (e.KeyCode == Keys.Escape) { this.Close(); }
            if (!skok )
            {

                if ((e.KeyCode == Keys.Space && (!spadanie == true))) 
                {
                    //collision(Platform, Gracz);

                    spadanie = true;
                    skok = true;
                    force = G;
                      
                    mforce = 1;

                }
            }
        }

        private void Gra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) {
                prawo = false;
                collision(Platform, Gracz,spadek);
                 
            }
            if (e.KeyCode == Keys.Left) {
                lewo = false;
                collision(Platform, Gracz, spadek);
                
            }
            if (e.KeyCode == Keys.Space) {
                skok = false; mforce = 1;
                collision(Platform, Gracz,spadek);
            }

        }
    }
}
