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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menu = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Wybor2 = new System.Windows.Forms.PictureBox();
            this.Wybor1 = new System.Windows.Forms.PictureBox();
            this.Level1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.Gracz = new System.Windows.Forms.PictureBox();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Wybor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wybor1)).BeginInit();
            this.Level1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Platform2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Platform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gracz)).BeginInit();
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
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.Controls.Add(this.label15);
            this.menu.Controls.Add(this.label14);
            this.menu.Controls.Add(this.Wybor2);
            this.menu.Controls.Add(this.Wybor1);
            this.menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu.ForeColor = System.Drawing.Color.Black;
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1006, 721);
            this.menu.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Ravie", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(411, 319);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(164, 44);
            this.label15.TabIndex = 5;
            this.label15.Text = "Koniec";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Ravie", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(411, 157);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(152, 44);
            this.label14.TabIndex = 4;
            this.label14.Text = "Start";
            // 
            // Wybor2
            // 
            this.Wybor2.Image = global::Math_MADS.Properties.Resources.arrow_hi;
            this.Wybor2.Location = new System.Drawing.Point(301, 319);
            this.Wybor2.Name = "Wybor2";
            this.Wybor2.Size = new System.Drawing.Size(46, 50);
            this.Wybor2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Wybor2.TabIndex = 3;
            this.Wybor2.TabStop = false;
            this.Wybor2.Visible = false;
            // 
            // Wybor1
            // 
            this.Wybor1.Image = global::Math_MADS.Properties.Resources.arrow_hi;
            this.Wybor1.Location = new System.Drawing.Point(301, 157);
            this.Wybor1.Name = "Wybor1";
            this.Wybor1.Size = new System.Drawing.Size(46, 50);
            this.Wybor1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Wybor1.TabIndex = 2;
            this.Wybor1.TabStop = false;
            // 
            // Level1
            // 
            this.Level1.BackColor = System.Drawing.Color.DimGray;
            this.Level1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Level1.Controls.Add(this.pictureBox1);
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
            this.Level1.Controls.Add(this.Gracz);
            this.Level1.ForeColor = System.Drawing.Color.Transparent;
            this.Level1.Location = new System.Drawing.Point(3, 0);
            this.Level1.Name = "Level1";
            this.Level1.Size = new System.Drawing.Size(1006, 721);
            this.Level1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(-21, 711);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1024, 10);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // Platform2
            // 
            this.Platform2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Platform2.Location = new System.Drawing.Point(411, 496);
            this.Platform2.Name = "Platform2";
            this.Platform2.Size = new System.Drawing.Size(118, 225);
            this.Platform2.TabIndex = 15;
            this.Platform2.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(778, 319);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 17);
            this.label13.TabIndex = 14;
            this.label13.Text = "label13";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(778, 369);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 17);
            this.label12.TabIndex = 13;
            this.label12.Text = "label12";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(687, 369);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 17);
            this.label11.TabIndex = 12;
            this.label11.Text = "Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(687, 319);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 17);
            this.label10.TabIndex = 11;
            this.label10.Text = "X";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(687, 624);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(647, 587);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "mforce";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(647, 542);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "force";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(643, 476);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "spadanie";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(647, 409);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Skok";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(715, 476);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(715, 587);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
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
            this.Platform.Location = new System.Drawing.Point(190, 556);
            this.Platform.Name = "Platform";
            this.Platform.Size = new System.Drawing.Size(123, 48);
            this.Platform.TabIndex = 1;
            this.Platform.TabStop = false;
            // 
            // Gracz
            // 
            this.Gracz.BackColor = System.Drawing.Color.Transparent;
            this.Gracz.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Gracz.Image = global::Math_MADS.Properties.Resources.przod;
            this.Gracz.Location = new System.Drawing.Point(280, 437);
            this.Gracz.Name = "Gracz";
            this.Gracz.Size = new System.Drawing.Size(37, 77);
            this.Gracz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Gracz.TabIndex = 0;
            this.Gracz.TabStop = false;
            // 
            // Prog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.Level1);
            this.Controls.Add(this.menu);
            this.DoubleBuffered = true;
            this.Name = "Prog";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Gra_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Gra_KeyUp);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Wybor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wybor1)).EndInit();
            this.Level1.ResumeLayout(false);
            this.Level1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Platform2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Platform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gracz)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        //private Panel mainmenu;
        private PictureBox Gracz;
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
        private PictureBox pictureBox1;
        private Panel Level1;
        private Panel menu;
        private PictureBox Wybor2;
        private PictureBox Wybor1;
        private Label label15;
        private Label label14;
    }
}

