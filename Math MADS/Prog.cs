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

    public partial class Prog : Form
    {
        Platformy Test = new Platformy();
      
        public bool prawo, lewo, skok, wcis;
        bool spadanie, control, podnies;
        public int force;
        int i = 0;
        const int G = 35;
        public int mforce;
        Collision kolizja = new Collision();
        bool menushow;
        bool lvl1en;
        public Prog()
        {
            InitializeComponent();
            mforce = 0;
            force = G;
            menu.Show();
            Level1.Hide();
            menushow = true;
            lvl1en = false;
            //Test.Init(100, 100, 20, 40, "Platforma");
            
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {


            if (skok && spadanie)
            {
                Gracz.Top -= force;
                if (wcis && mforce < force) force += 1;
            }

            if (Gracz.Top + Gracz.Height -5>=Level1.Height)
            {
                Gracz.Top = Level1.Top -5- Gracz.Height;
                skok = false;
                spadanie = false;
                mforce = 15;
                force = G;

            }
            else if (kolizja.Top(Podloga, Gracz))
            {
                skok = false;
                spadanie = false;
                mforce = 15;
                force = G;
                if (!wcis) Gracz.Top = Podloga.Top - Gracz.Height;
            }
            else if (kolizja.Top(Platform2, Gracz))
            {
                skok = false;
                spadanie = false;
                mforce = 0;
                force = 20;
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
            else if (!kolizja.Top(Platform, Gracz))
            {
                Gracz.Top += mforce;
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
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Side(Platform, Gracz);
            Side(Platform2, Gracz);
            Side(Skrzynka1, Gracz);

            if (podnies && ((Gracz.Left <=Skrzynka1.Right-40&&Gracz.Left>=Skrzynka1.Right)||(Gracz.Right>=Skrzynka1.Left+35&& Gracz.Right <= Skrzynka1.Left))&&Gracz.Top>=Skrzynka1.Top&&Gracz.Top<=Skrzynka1.Bottom)
            {
                if((Gracz.Right == Skrzynka1.Left - 35))
                {
                    Skrzynka1.Left = Gracz.Right;
                }
            }
                if (prawo && lvl1en)
            {
                Gracz.Left += 3;
                Gracz.Image = Math_MADS.Properties.Resources.prawo;
            }
            else if (lewo && lvl1en)
            {
                Gracz.Left -= 3;
                Gracz.Image = Math_MADS.Properties.Resources.lewo;
            }
            else
            {
                Gracz.Image = Math_MADS.Properties.Resources.przod;

            }
            label1.Text = Convert.ToString(podnies);
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
                lewo = false;

            }

            if (x3 >= x2 && x3 <= x1 && (y3 <= y1 + h1 + 5 && y3 + h2 >= y1 + 5))
            {

                prawo = false;

            }


        }
        private void Gra_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.E)
            {
                if (!podnies) podnies = true;
                else podnies = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                prawo = true;


            }
            if (e.KeyCode == Keys.Left)
            {
                lewo = true;
                             
            }
            if (e.KeyCode == Keys.Escape) {

                if (menushow) this.Close(); 
                 
                else
                {
                    menu.Show();
                    lvl1en = false;
                    Level1.Hide();
                    foreach (Control ctrl in Level1.Controls)
                    {
                        ctrl.Enabled = false;
                    }
                    foreach (Control ctrl in menu.Controls)
                    {
                        ctrl.Enabled = true;
                    }
                    menushow=true;
                }
            }
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
            if(menushow)
            {
                if(e.KeyCode==Keys.Up || e.KeyCode==Keys.Down)
                {
                    if(i!=0&&menushow)
                    {
                        i = 0;
                        Wybor1.Visible = true;
                        Wybor2.Visible = false;
                    }
                    else
                    {
                        i++;
                        Wybor1.Visible = false;
                        Wybor2.Visible = true;
                    }
                }
            }
            if(e.KeyCode==Keys.Enter)
            {
                if(i==0&&menushow)
                {
                    Level1.Show();
                    menushow = false;
                    foreach (Control ctrl in Level1.Controls)
                    {
                        ctrl.Enabled = true;

                    }
                    foreach (Control ctrl in menu.Controls)
                    {
                        ctrl.Enabled = false;

                    }
                    lvl1en = true;
                    menu.Hide();
                }
                else if(menushow)
                {
                    this.Close(); }
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
