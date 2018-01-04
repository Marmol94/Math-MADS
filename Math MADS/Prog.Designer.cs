using System.Windows.Forms;


namespace Math_MADS
{
    partial class Prog
    {

        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prog));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menu = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Wybor2 = new System.Windows.Forms.PictureBox();
            this.Wybor1 = new System.Windows.Forms.PictureBox();
            this.Level1 = new System.Windows.Forms.Panel();
            this.Znak = new System.Windows.Forms.PictureBox();
            this.Dod2 = new System.Windows.Forms.PictureBox();
            this.Dod1 = new System.Windows.Forms.PictureBox();
            this.Drzwi = new System.Windows.Forms.PictureBox();
            this.Skrzynka3 = new System.Windows.Forms.PictureBox();
            this.Skrzynka2 = new System.Windows.Forms.PictureBox();
            this.Sciana = new System.Windows.Forms.PictureBox();
            this.Skrzynka1 = new System.Windows.Forms.PictureBox();
            this.Podloga = new System.Windows.Forms.PictureBox();
            this.Platform2 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Platform = new System.Windows.Forms.PictureBox();
            this.Gracz1 = new Math_MADS.Player();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wybor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wybor1)).BeginInit();
            this.Level1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Znak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dod2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dod1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Drzwi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Skrzynka3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Skrzynka2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sciana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Skrzynka1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Podloga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Platform2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Platform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gracz1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 12;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // menu
            // 
            this.menu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.menu.Controls.Add(this.pictureBox3);
            this.menu.Controls.Add(this.pictureBox2);
            this.menu.Controls.Add(this.Wybor2);
            this.menu.Controls.Add(this.Wybor1);
            this.menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu.ForeColor = System.Drawing.Color.Black;
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1005, 721);
            this.menu.TabIndex = 17;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Math_MADS.Properties.Resources.koniec1;
            this.pictureBox3.InitialImage = global::Math_MADS.Properties.Resources.koniec1;
            this.pictureBox3.Location = new System.Drawing.Point(403, 319);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(189, 80);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Math_MADS.Properties.Resources.start2;
            this.pictureBox2.InitialImage = global::Math_MADS.Properties.Resources.start2;
            this.pictureBox2.Location = new System.Drawing.Point(403, 158);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(189, 79);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // Wybor2
            // 
            this.Wybor2.Image = global::Math_MADS.Properties.Resources.przod;
            this.Wybor2.Location = new System.Drawing.Point(301, 336);
            this.Wybor2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Wybor2.Name = "Wybor2";
            this.Wybor2.Size = new System.Drawing.Size(45, 50);
            this.Wybor2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Wybor2.TabIndex = 3;
            this.Wybor2.TabStop = false;
            this.Wybor2.Visible = false;
            // 
            // Wybor1
            // 
            this.Wybor1.Image = global::Math_MADS.Properties.Resources.przod;
            this.Wybor1.Location = new System.Drawing.Point(301, 186);
            this.Wybor1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Wybor1.Name = "Wybor1";
            this.Wybor1.Size = new System.Drawing.Size(45, 50);
            this.Wybor1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Wybor1.TabIndex = 2;
            this.Wybor1.TabStop = false;
            // 
            // Level1
            // 
            this.Level1.BackColor = System.Drawing.Color.Transparent;
            this.Level1.BackgroundImage = global::Math_MADS.Properties.Resources.Galaxy1;
            this.Level1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Level1.Controls.Add(this.Gracz1);
            this.Level1.Controls.Add(this.Znak);
            this.Level1.Controls.Add(this.Dod2);
            this.Level1.Controls.Add(this.Dod1);
            this.Level1.Controls.Add(this.Drzwi);
            this.Level1.Controls.Add(this.Skrzynka3);
            this.Level1.Controls.Add(this.Skrzynka2);
            this.Level1.Controls.Add(this.Sciana);
            this.Level1.Controls.Add(this.Skrzynka1);
            this.Level1.Controls.Add(this.Podloga);
            this.Level1.Controls.Add(this.Platform2);
            this.Level1.Controls.Add(this.label13);
            this.Level1.Controls.Add(this.label12);
            this.Level1.Controls.Add(this.label11);
            this.Level1.Controls.Add(this.label10);
            this.Level1.Controls.Add(this.label9);
            this.Level1.Controls.Add(this.label8);
            this.Level1.Controls.Add(this.label7);
            this.Level1.Controls.Add(this.label6);
            this.Level1.Controls.Add(this.label5);
            this.Level1.Controls.Add(this.label4);
            this.Level1.Controls.Add(this.label3);
            this.Level1.Controls.Add(this.label2);
            this.Level1.Controls.Add(this.label1);
            this.Level1.Controls.Add(this.Platform);
            this.Level1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Level1.ForeColor = System.Drawing.Color.Transparent;
            this.Level1.Location = new System.Drawing.Point(0, 0);
            this.Level1.Margin = new System.Windows.Forms.Padding(0);
            this.Level1.Name = "Level1";
            this.Level1.Size = new System.Drawing.Size(1005, 721);
            this.Level1.TabIndex = 0;
            // 
            // Znak
            // 
            this.Znak.Image = global::Math_MADS.Properties.Resources.Znak_plus;
            this.Znak.Location = new System.Drawing.Point(813, 615);
            this.Znak.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Znak.Name = "Znak";
            this.Znak.Size = new System.Drawing.Size(40, 70);
            this.Znak.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Znak.TabIndex = 24;
            this.Znak.TabStop = false;
            // 
            // Dod2
            // 
            this.Dod2.BackColor = System.Drawing.Color.Silver;
            this.Dod2.Location = new System.Drawing.Point(859, 684);
            this.Dod2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dod2.Name = "Dod2";
            this.Dod2.Size = new System.Drawing.Size(51, 14);
            this.Dod2.TabIndex = 0;
            this.Dod2.TabStop = false;
            // 
            // Dod1
            // 
            this.Dod1.BackColor = System.Drawing.Color.Silver;
            this.Dod1.Location = new System.Drawing.Point(757, 684);
            this.Dod1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dod1.Name = "Dod1";
            this.Dod1.Size = new System.Drawing.Size(51, 14);
            this.Dod1.TabIndex = 22;
            this.Dod1.TabStop = false;
            // 
            // Drzwi
            // 
            this.Drzwi.Image = global::Math_MADS.Properties.Resources.Drzwi4;
            this.Drzwi.Location = new System.Drawing.Point(968, 505);
            this.Drzwi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Drzwi.Name = "Drzwi";
            this.Drzwi.Size = new System.Drawing.Size(37, 181);
            this.Drzwi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Drzwi.TabIndex = 21;
            this.Drzwi.TabStop = false;
            // 
            // Skrzynka3
            // 
            this.Skrzynka3.Image = global::Math_MADS.Properties.Resources.Box3;
            this.Skrzynka3.Location = new System.Drawing.Point(127, 476);
            this.Skrzynka3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Skrzynka3.Name = "Skrzynka3";
            this.Skrzynka3.Size = new System.Drawing.Size(35, 32);
            this.Skrzynka3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Skrzynka3.TabIndex = 20;
            this.Skrzynka3.TabStop = false;
            // 
            // Skrzynka2
            // 
            this.Skrzynka2.Image = global::Math_MADS.Properties.Resources.Box2;
            this.Skrzynka2.Location = new System.Drawing.Point(403, 418);
            this.Skrzynka2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Skrzynka2.Name = "Skrzynka2";
            this.Skrzynka2.Size = new System.Drawing.Size(35, 32);
            this.Skrzynka2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Skrzynka2.TabIndex = 19;
            this.Skrzynka2.TabStop = false;
            // 
            // Sciana
            // 
            this.Sciana.BackgroundImage = global::Math_MADS.Properties.Resources.text1;
            this.Sciana.Location = new System.Drawing.Point(968, 0);
            this.Sciana.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Sciana.Name = "Sciana";
            this.Sciana.Size = new System.Drawing.Size(37, 505);
            this.Sciana.TabIndex = 18;
            this.Sciana.TabStop = false;
            // 
            // Skrzynka1
            // 
            this.Skrzynka1.Image = global::Math_MADS.Properties.Resources.Box1;
            this.Skrzynka1.Location = new System.Drawing.Point(485, 418);
            this.Skrzynka1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Skrzynka1.Name = "Skrzynka1";
            this.Skrzynka1.Size = new System.Drawing.Size(35, 32);
            this.Skrzynka1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Skrzynka1.TabIndex = 17;
            this.Skrzynka1.TabStop = false;
            // 
            // Podloga
            // 
            this.Podloga.BackColor = System.Drawing.Color.Transparent;
            this.Podloga.BackgroundImage = global::Math_MADS.Properties.Resources.text1;
            this.Podloga.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Podloga.Location = new System.Drawing.Point(0, 684);
            this.Podloga.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Podloga.Name = "Podloga";
            this.Podloga.Size = new System.Drawing.Size(1005, 37);
            this.Podloga.TabIndex = 16;
            this.Podloga.TabStop = false;
            // 
            // Platform2
            // 
            this.Platform2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Platform2.BackgroundImage = global::Math_MADS.Properties.Resources.text1;
            this.Platform2.Location = new System.Drawing.Point(403, 460);
            this.Platform2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Platform2.Name = "Platform2";
            this.Platform2.Size = new System.Drawing.Size(117, 33);
            this.Platform2.TabIndex = 15;
            this.Platform2.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(779, 319);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 17);
            this.label13.TabIndex = 14;
            this.label13.Text = "label13";
            this.label13.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(779, 369);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 17);
            this.label12.TabIndex = 13;
            this.label12.Text = "label12";
            this.label12.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(687, 369);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 17);
            this.label11.TabIndex = 12;
            this.label11.Text = "Y";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(687, 319);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 17);
            this.label10.TabIndex = 11;
            this.label10.Text = "X";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(687, 624);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "label9";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(647, 587);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "mforce";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(647, 542);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "force";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(643, 476);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "spadanie";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(647, 409);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Skok";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(715, 476);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(715, 587);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(715, 542);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(715, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Platform
            // 
            this.Platform.BackColor = System.Drawing.Color.Maroon;
            this.Platform.BackgroundImage = global::Math_MADS.Properties.Resources.text1;
            this.Platform.Location = new System.Drawing.Point(116, 511);
            this.Platform.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Platform.Name = "Platform";
            this.Platform.Size = new System.Drawing.Size(127, 155);
            this.Platform.TabIndex = 1;
            this.Platform.TabStop = false;
            // 
            // Gracz1
            // 
            this.Gracz1.Image = ((System.Drawing.Image)(resources.GetObject("Gracz1.Image")));
            this.Gracz1.Location = new System.Drawing.Point(0, 588);
            this.Gracz1.Margin = new System.Windows.Forms.Padding(4);
            this.Gracz1.Name = "Gracz1";
            this.Gracz1.Size = new System.Drawing.Size(37, 78);
            this.Gracz1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Gracz1.TabIndex = 0;
            this.Gracz1.TabStop = false;
            // 
            // Prog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1005, 721);
            this.Controls.Add(this.Level1);
            this.Controls.Add(this.menu);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Prog";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Gra_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Gra_KeyUp);
            this.menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wybor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wybor1)).EndInit();
            this.Level1.ResumeLayout(false);
            this.Level1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Znak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dod2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dod1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Drzwi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Skrzynka3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Skrzynka2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sciana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Skrzynka1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Podloga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Platform2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Platform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gracz1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        //private Panel mainmenu;
        private PictureBox Znak;
        private PictureBox Platform;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private PictureBox Platform2;
        private PictureBox Podloga;
        private Panel Level1;
        private Panel menu;
        private PictureBox Wybor2;
        private PictureBox Wybor1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox Skrzynka1;
        private PictureBox Drzwi;
        private PictureBox Skrzynka3;
        private PictureBox Skrzynka2;
        private PictureBox Sciana;
        private PictureBox Dod2;
        private PictureBox Dod1;
    }
}

