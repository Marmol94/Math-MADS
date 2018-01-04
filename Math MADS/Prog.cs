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
        Player Gracz1 = new Player();
        public bool isRightMovementAvailable, isLeftMovementAvailable, skok, wcis, obok1, obok2, obok3;
        bool spadanie, control, podnies1, podnies2, podnies3;
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
            Gracz1.InitializePlayer();
            //Test.Init(100, 100, 20, 40, "Platforma");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (skok && spadanie)
            {
                Gracz1.Top -= force;
                if (wcis && mforce < force) force += 1;
            }

            if (Gracz1.Top + Gracz1.Height - 5 >= Level1.Height)
            {
                Gracz1.Top = Level1.Top - 5 - Gracz1.Height;
                skok = false;
                spadanie = false;
                mforce = 15;
                force = G;
            }
            else if (kolizja.Top(Podloga, Gracz1))
            {
                skok = false;
                spadanie = false;
                mforce = 15;
                force = G;
                if (!wcis) Gracz1.Top = Podloga.Top - Gracz1.Height;
            }
            else if (kolizja.Top(Platform2, Gracz1))
            {
                skok = false;
                spadanie = false;
                mforce = 0;
                force = 20;
                if (!wcis) Gracz1.Top = Platform2.Top - Gracz1.Height;
            }
            else if (kolizja.Top(Platform, Gracz1))
            {
                skok = false;
                spadanie = false;
                mforce = 15;
                force = G
                    ;
                if (!wcis) Gracz1.Top = Platform.Top - Gracz1.Height;
            }
            else if (kolizja.Bot(Platform, Gracz1))
            {
                force = 0;
                Gracz1.Top += mforce;
            }
            else if (!kolizja.Top(Platform, Gracz1))
            {
                Gracz1.Top += mforce;
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
            kolizja.SideCollisionMovementEnabler(Platform, Gracz1, this);
            kolizja.SideCollisionMovementEnabler(Platform2, Gracz1, this);
            //SideCollisionMovementEnabler(Skrzynka1, Gracz1);
            //kolizja.SideCollisionMovementEnabler(Skrzynka1, Skrzynka2, this);
            // kolizja.SideCollisionMovementEnabler(Skrzynka1, Skrzynka3, this);
            // kolizja.SideCollisionMovementEnabler(Skrzynka2, Skrzynka3, this);
            if ((Gracz1.Right >= Skrzynka1.Left && Gracz1.Left <= Skrzynka1.Right) &&
                (Gracz1.Bottom >= Skrzynka1.Bottom || Gracz1.Bottom <= Skrzynka1.Bottom + 26))
            {
                obok1 = true;
            }
            else obok1 = false;

            if ((Gracz1.Right >= Skrzynka2.Left && Gracz1.Left <= Skrzynka2.Right) &&
                (Gracz1.Bottom >= Skrzynka2.Bottom || Gracz1.Bottom <= Skrzynka2.Bottom + 26))
            {
                obok2 = true;
            }
            else obok2 = false;

            if ((Gracz1.Right >= Skrzynka3.Left && Gracz1.Left <= Skrzynka3.Right) &&
                (Gracz1.Bottom >= Skrzynka3.Bottom || Gracz1.Bottom <= Skrzynka3.Bottom + 26))
            {
                obok3 = true;
            }
            else obok3 = false;

            if (podnies1 && obok1)
            {
                Skrzynka1.Left = Gracz1.Right;
                Skrzynka1.Top = Gracz1.Bottom - 26;
            }

            if (podnies2 && obok2)
            {
                Skrzynka2.Left = Gracz1.Right;
                Skrzynka2.Top = Gracz1.Bottom - 26;
            }

            if (podnies3 && obok3)
            {
                Skrzynka3.Left = Gracz1.Right;
                Skrzynka3.Top = Gracz1.Bottom - 26;
            }

            if (isRightMovementAvailable && lvl1en)
            {
                Gracz1.Left += 3;
                Gracz1.Image = Math_MADS.Properties.Resources.prawo;
            }
            else if (isLeftMovementAvailable && lvl1en)
            {
                Gracz1.Left -= 3;
                Gracz1.Image = Math_MADS.Properties.Resources.lewo;
            }
            else
            {
                Gracz1.Image = Math_MADS.Properties.Resources.przod;
            }

            label1.Text = Convert.ToString(podnies1);
            label2.Text = Convert.ToString(obok1);
            label3.Text = Convert.ToString(mforce);
            label4.Text = Convert.ToString(spadanie);
            label9.Text = Convert.ToString(Gracz1.SizeMode);
            label13.Text = Convert.ToString(Gracz1.Left);
            label12.Text = Convert.ToString(Gracz1.Top);
            if ((Dod1.Top == Skrzynka1.Bottom && Skrzynka1.Left >= Dod1.Left && Skrzynka1.Right <= Dod1.Right) ||
                (Dod2.Top == Skrzynka1.Bottom && Skrzynka1.Left >= Dod2.Left && Skrzynka1.Right <= Dod2.Right))
            {
                if ((Dod1.Top == Skrzynka3.Bottom && Skrzynka3.Left >= Dod1.Left && Skrzynka3.Right <= Dod1.Right) ||
                    (Dod2.Top == Skrzynka3.Bottom && Skrzynka1.Left >= Dod2.Left && Skrzynka3.Right <= Dod2.Right))

                    Drzwi.Enabled = false;
            }
        }

        private void Gra_KeyDown(object sender, KeyEventArgs e)
        {
//            if(e.KeyCode==Keys.E)
//            {
//                if (!podnies1 && obok1) podnies1 = true;
//                else podnies1 = false;
//                if (!podnies2 && obok2) podnies2 = true;
//                else podnies2 = false;
//                if (!podnies3 && obok3) podnies3 = true;
//                else podnies3 = false;
//            }
            if (e.KeyCode == Keys.Right)
            {
                isRightMovementAvailable = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                isLeftMovementAvailable = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
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

                    menushow = true;
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

            if (menushow)
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    if (i != 0 && menushow)
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

            if (e.KeyCode == Keys.Enter)
            {
                if (i == 0 && menushow)
                {
                    Level1.Show();
                    Gracz1.InitializePlayer();
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
                else if (menushow)
                {
                    this.Close();
                }
            }
        }


        private void Gra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                isRightMovementAvailable = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                isLeftMovementAvailable = false;
            }

            if (e.KeyCode == Keys.Space)
            {
                //skok = false;
                wcis = false;
            }
        }
    }
}