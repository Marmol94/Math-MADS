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
    public partial class Main : Form
    {
        Platform podloga = new Platform();
        Platform lvlOneFirstPlatform = new Platform();
        Platform lvlOneSecondPlatform = new Platform();
        Player gracz1 = new Player();
        Level levelOne = new Level();
        MenuControl optionChooser = new MenuControl();
        MenuControl optionStart = new MenuControl();
        MenuControl optionClose = new MenuControl();
        MenuControl selectLevel1 = new MenuControl();
        MenuControl selectLevel2 = new MenuControl();
        MenuControl optionSelectLevel = new MenuControl();
        MenuControl optionHelp = new MenuControl();
        MenuControl helpPage = new MenuControl();
        List<MenuControl> LevelSelectList = new List<MenuControl>();
        Menu levelSelect = new Menu();
        Menu Help = new Menu();
        MenuControl levelSelector = new MenuControl();
        public bool isRightMovementAvailable, isLeftMovementAvailable, isJumping, wcis, obok1, obok2, obok3;
        public bool control, podnies1, podnies2, podnies3;
        public int force;
        int i = 0;
        public const int G = 25;
        public int mforce;
        Collision kolizja = new Collision();
        bool menushow, levelSelectShow, helpShow;
        bool lvl1en;
        Menu menutest = new Menu();

        public Main()
        {
            for (int k = 0; k <= 16; k++) LevelSelectList.Add(new MenuControl());

            InitializeComponent();
            menu.Hide();
            mforce = 0;
            force = G;
            menutest.Show();
            levelOne.Hide();
            Help.Hide();
            levelSelect.Hide();
            menushow = true;
            lvl1en = false;
            menutest.InitializeMenu(this);
            Help.InitializeMenu(this);
            gracz1.InitializePlayer(x: 200, y: 10, level: levelOne);
            levelOne.InitializeLevel(this);
            podloga.InitializePlatform(platformX: 10, platformY: 721, platformWidth: 0, platformHeight: 0,
                isFloor: true, level: levelOne);
            lvlOneFirstPlatform.InitializePlatform(platformX: 200, platformY: 300, platformWidth: 50,
                platformHeight: 799, isFloor: false, level: levelOne);
            lvlOneSecondPlatform.InitializePlatform(platformX: 100, platformY: 150, platformWidth: 150,
                platformHeight: 50, isFloor: false, level: levelOne);

            optionChooser.InitializeChooser(menutest);
            optionStart.InitializeOption(250, 100, menutest, Properties.Resources.start);
            optionClose.InitializeOption(250, 400, menutest, Properties.Resources.koniec);
            levelSelector.InitializeOption(100, 0, levelSelect, Properties.Resources.select);
            optionSelectLevel.InitializeOption(250, 200, menutest, Properties.Resources.poziom);
            optionHelp.InitializeOption(250, 300, menutest, Properties.Resources.pomoc);
            helpPage.InitializeOption(0, 0, Help, Properties.Resources.Help);
            helpPage.Size = new System.Drawing.Size(1005, 729);
            levelSelect.InitializeMenu(this);
            for (int j = 0; j < 4; j++)
            {
                for (int f = 0; f <= 4; f++)
                    if (j != 4 && f != 4)
                        LevelSelectList[4 * j + f].InitializeOption(100 + 100 * f, 100 * j, levelSelect,
                            Properties.Resources.lvl1);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            gracz1.CheckCollision(kolizja, lvlOneFirstPlatform, this, levelOne);
            gracz1.CheckCollision(kolizja, lvlOneSecondPlatform, this, levelOne);
            gracz1.FloorCollision(this, kolizja, podloga);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gracz1.PlayerMovement(this);
        }

        private void Gra_KeyDown(object sender, KeyEventArgs e)
        {
//           
            if (e.KeyCode == Keys.Right)
            {
                if (!menushow) isRightMovementAvailable = true;
                if (levelSelectShow) levelSelector.ChangeControlPositionRight();
            }

            if (e.KeyCode == Keys.Left)
            {
                if (!menushow) isLeftMovementAvailable = true;
                if (levelSelectShow) levelSelector.ChangeControlPositionLeft();
            }

            if (e.KeyCode == Keys.Escape)
            {
                if (menushow && !levelSelectShow & !helpShow) this.Close();
                else if (levelSelectShow)
                {
                    levelSelect.Hide();
                    menutest.Show();
                    levelSelectShow = false;
                    optionChooser.InitializeChooser(menutest);
                    i = 0;
                }
                else if (helpShow)
                {
                    Help.Hide();
                    menutest.Show();
                    helpShow = false;
                    optionChooser.InitializeChooser(menutest);

                    i = 0;
                }
                else
                {
                    menutest.Show();
                    lvl1en = false;
                    optionChooser.InitializeChooser(menutest);

                    levelOne.Hide();
                    foreach (Control ctrl in levelOne.Controls)
                    {
                        ctrl.Enabled = false;
                    }

                    foreach (Control ctrl in menutest.Controls)
                    {
                        ctrl.Enabled = true;
                    }

                    menushow = true;
                }
            }

            if (!isJumping)
            {
                if (e.KeyCode == Keys.Space)
                {
                    isJumping = true;
                    wcis = true;
                }
            }

            if (menushow)
            {
                if (e.KeyCode == Keys.Up && i >= 1 && i <= 3)
                {
                    optionChooser.ChangeControlPositionUp();
                    if (levelSelectShow) levelSelector.ChangeControlPositionUp();

                    i--;
                }

                if (e.KeyCode == Keys.Down && i <= 2 && i >= 0)
                {
                    i++;
                    optionChooser.ChangeControlPositionDown();
                    if (levelSelectShow) levelSelector.ChangeControlPositionDown();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                switch (i)
                {
                    case 0:
                        levelOne.Show();
                        gracz1.InitializePlayer(x: 0, y: 200, level: levelOne);
                        levelOne.InitializeLevel(this);
                        menushow = false;
                        menutest.Hide();
                        foreach (Control ctrl in levelOne.Controls)
                        {
                            ctrl.Enabled = true;
                        }

                        foreach (Control ctrl in menutest.Controls)
                        {
                            ctrl.Enabled = false;
                        }

                        lvl1en = true;
                        menu.Hide();
                        break;
                    case 1:
                        menutest.Hide();
                        levelSelect.Show();


                        i = 0;
                        levelSelectShow = true;
                        break;
                    case 2:
                        Help.Show();
                        helpShow = true;
                        menutest.Hide();
                        break;
                    case 3:
                        this.Close();
                        break;
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
                wcis = false;
            }
        }
    }
}