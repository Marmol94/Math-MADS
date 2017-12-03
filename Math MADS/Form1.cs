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
        
        public bool prawo, lewo, skok, wcis;
        bool spadanie;
        public int force;
        const int G = 35;
        public int mforce;
        Collision kolizja = new Collision();
        

        public Gra()
        {
            InitializeComponent();
            mforce = 0;
            force = G;
              

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            

            if (skok && spadanie)
            {
                Gracz.Top -= force;
                if (wcis && mforce < force) force += 1;
            }

            if (Gracz.Top + Gracz.Height >= screen.Height - 5)
            {
                Gracz.Top = screen.Height - Gracz.Height - 5;
                skok = false;
                spadanie = false;
                mforce = 15;
                force = G;

            }
            else if (kolizja.Top(Platform2, Gracz))
            {
                skok = false;
                spadanie = false;
                mforce = 15;
                force = G;
                if (!wcis) Gracz.Top = Platform2.Top - Gracz.Height;
            }
            else if (kolizja.Top(Platform, Gracz))
            {
                skok = false;
                spadanie = false;
                mforce = 15;
                force = G
                    ;
                if (!wcis) Gracz.Top = Platform.Top - Gracz.Height;
            }
            else if (kolizja.Bot(Platform, Gracz))
            {
                force = 0;
                Gracz.Top += mforce;
            }
            else if(!kolizja.Top(Platform, Gracz))
            {
                Gracz.Top += mforce;
                mforce = mforce + 2;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (prawo == true)
            {
                if (Gracz.Right < screen.Right && kolizja.Right(Platform2, Gracz)) Gracz.Left += 2;
                Gracz.Image = Math_MADS.Properties.Resources.prawo;
            }
            else if (lewo == true)
            {
                if(Gracz.Left> screen.Left && kolizja.Left(Platform2, Gracz)) Gracz.Left -= 2;
                Gracz.Image = Math_MADS.Properties.Resources.lewo;
            }
            else
            {
                Gracz.Image = Math_MADS.Properties.Resources.przod;

            }
            label1.Text = Convert.ToString(skok);
            label2.Text = Convert.ToString(force);
            label3.Text = Convert.ToString(mforce);
            label4.Text = Convert.ToString(spadanie);
            label9.Text = Convert.ToString(Gracz.SizeMode);
            label13.Text = Convert.ToString(Gracz.Left);
            label12.Text = Convert.ToString(Gracz.Top);

        }

        public void Side(PictureBox P, PictureBox G)
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
                G.BackColor = Color.Red;
                lewo = false;

            }

            if (x3 >= x2 && x3 <= x1 && (y3 <= y1 + h1 + 5 && y3 + h2 >= y1 + 5))
            {

                prawo = false;

            }


        }
        private void Gra_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Right)
            {
                prawo = true;

    
            }
            if (e.KeyCode == Keys.Left)
            {
                lewo = true;

    

            }
            if (e.KeyCode == Keys.Escape) { this.Close(); }
            if (!skok)
            {

                if (e.KeyCode == Keys.Space)
                {

                    spadanie = true;
                    skok = true;
                    //force = G;
                    wcis = true;


                }
            }
        }

        private void Gra_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Right)
            {
                prawo = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                lewo = false;

            }
            if (e.KeyCode == Keys.Space)
            {
                //skok = false;
                wcis = false;
            }

        }
    }
}
