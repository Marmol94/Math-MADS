using System.Windows.Forms;


namespace Math_MADS
{
    partial class Main
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
        /// Metoda Inicjalizacji timerów oraz samego programu
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.levelOneTimer = new System.Windows.Forms.Timer(this.components);
            this.levelTwoTimer = new System.Windows.Forms.Timer(this.components);
          
            this.levelThreeTimer = new System.Windows.Forms.Timer(this.components);
            this.levelFourTimer = new System.Windows.Forms.Timer(this.components);
            this.levelFiveTimer = new System.Windows.Forms.Timer(this.components);
            
            // 
            // levelOneTimer
            // 
            this.levelOneTimer.Enabled = true;
            this.levelOneTimer.Interval = 10;
            this.levelOneTimer.Tick += new System.EventHandler(this.LevelOneTick);
            // 
            // levelTwoTimer
            // 
            this.levelTwoTimer.Enabled = true;
            this.levelTwoTimer.Interval = 1;
            this.levelTwoTimer.Tick += new System.EventHandler(this.LevelTwoTick);
   
           
            // 
            // levelThreeTimer
            // 
            this.levelThreeTimer.Interval = 1;
            this.levelThreeTimer.Tick += new System.EventHandler(this.LevelThreeTick);
            // 
            // levelFourTimer
            // 
            this.levelFourTimer.Interval = 1;
            this.levelFourTimer.Tick += new System.EventHandler(this.LevelFourTick);
            // 
            // levelFiveTimer
            // 
            this.levelFiveTimer.Interval = 1;
            this.levelFiveTimer.Tick += new System.EventHandler(this.LevelFiveTick);
            // 
            // Znak
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(754, 586);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Coral;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Text = "Math MADS";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Gra_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Gra_KeyUp);
            
        }

        #endregion
        private System.Windows.Forms.Timer levelOneTimer;
        private System.Windows.Forms.Timer levelTwoTimer;
        
        private Timer levelThreeTimer;
        private Timer levelFourTimer;
        private Timer levelFiveTimer;
    }
}

