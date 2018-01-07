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
        InteractiveObject boxOne = new InteractiveObject();
        InteractiveObject boxTwo = new InteractiveObject();
        InteractiveObject boxThree = new InteractiveObject();
        public bool isRightMovementAvailable, isLeftMovementAvailable, isJumping, wcis, obok1, obok2, obok3;
        public bool control;
        public List<bool> pickupControl = new List<bool>();
        public bool podnies1;
        public bool podnies2;
        public bool podnies3;
        List<InteractiveObject> InObLst = new List<InteractiveObject>();
        public int force;
        int i = 0;
        int l = 0;
        public const int G = 35;
        public int mforce;
        Collision kolizja = new Collision();
        bool menuShow, levelSelectShow, helpShow;
        bool lvl1en;
        Menu menutest = new Menu();

        public Main()
        {
            for (int k = 0; k <= 16; k++) LevelSelectList.Add(new MenuControl());

            pickupControl.Add(podnies1);
            pickupControl.Add(podnies2);
            pickupControl.Add(podnies3);


            InitializeComponent();
            menu.Hide();
            mforce = 0;
            force = G;
            menutest.Show();
            levelOne.Hide();
            Help.Hide();
            levelSelect.Hide();
            menuShow = true;
            lvl1en = false;
            menutest.InitializeMenu(this);
            Help.InitializeMenu(this);
            gracz1.InitializePlayer(x: 200, y: 10, level: levelOne);
            levelOne.InitializeLevel(this);
            podloga.InitializePlatform(platformX: 10, platformY: 721, platformWidth: 0, platformHeight: 0,
                isFloor: true, level: levelOne);
            lvlOneFirstPlatform.InitializePlatform(platformX: 200, platformY: 500, platformWidth: 150,
                platformHeight: 50, isFloor: false, level: levelOne);
            lvlOneSecondPlatform.InitializePlatform(platformX: 100, platformY: 450, platformWidth: 150,
                platformHeight: 30, isFloor: false, level: levelOne);
            boxOne.InitializeObject(110, 100, levelOne, Properties.Resources.Box1, 25, 25);
            boxTwo.InitializeObject(310, 100, levelOne, Properties.Resources.Box2, 25, 25);
            boxThree.InitializeObject(210, 100, levelOne, Properties.Resources.Box3, 25, 25);
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
            gracz1.CheckCollision(kolizja, podloga, this, levelOne);
            gracz1.Falling(kolizja, lvlOneSecondPlatform, this, levelOne);
            gracz1.Falling(kolizja, lvlOneFirstPlatform, this, levelOne);
            boxOne.FallingObject(kolizja, lvlOneSecondPlatform, this, levelOne);
            boxOne.FallingObject(kolizja, lvlOneFirstPlatform, this, levelOne);
            boxOne.FallingObject(kolizja, podloga, this, levelOne);
            boxOne.PickUp(gracz1, podnies1);
            boxTwo.FallingObject(kolizja, lvlOneSecondPlatform, this, levelOne);
            boxTwo.FallingObject(kolizja, lvlOneFirstPlatform, this, levelOne);
            boxTwo.FallingObject(kolizja, podloga, this, levelOne);
            boxTwo.PickUp(gracz1, podnies2);
            boxThree.FallingObject(kolizja, lvlOneSecondPlatform, this, levelOne);
            boxThree.FallingObject(kolizja, lvlOneFirstPlatform, this, levelOne);
            boxThree.FallingObject(kolizja, podloga, this, levelOne);
            boxThree.PickUp(gracz1, podnies3);
               }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gracz1.PlayerMovement(this, levelOne, kolizja);
        }

        private void Gra_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:

                    if (!menuShow) isRightMovementAvailable = true;
                    if (levelSelectShow) levelSelector.ChangeControlPositionRight();
                    break;

                case Keys.Left:

                    if (!menuShow) isLeftMovementAvailable = true;
                    if (levelSelectShow) levelSelector.ChangeControlPositionLeft();
                    break;

                case Keys.Escape:

                    if (menuShow && !levelSelectShow & !helpShow) this.Close();
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

                        menuShow = true;
                    }

                    break;


                case Keys.Space:
                {
                    if (!isJumping && !wcis)
                    {
                        isJumping = true;
                        wcis = true;
                        force = G;
                    }
                }
                    break;
                case Keys.Up:
                    if (menuShow)
                    {
                        if (i >= 1 && i <= 3)
                        {
                            optionChooser.ChangeControlPositionUp();
                            if (levelSelectShow) levelSelector.ChangeControlPositionUp();

                            i--;
                        }
                    }

                    break;

                case Keys.Down:
                    if (menuShow)
                    {
                        if (i <= 2 && i >= 0)
                        {
                            i++;
                            optionChooser.ChangeControlPositionDown();
                            if (levelSelectShow) levelSelector.ChangeControlPositionDown();
                        }
                    }

                    break;

                case Keys.Enter:

                    switch (i)
                    {
                        case 0:
                            levelOne.Show();
                            gracz1.InitializePlayer(x: 0, y: 200, level: levelOne);
                            levelOne.InitializeLevel(this);
                            menuShow = false;
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
                            if (!levelSelectShow && !helpShow) this.Close();
                            break;
                    }

                    break;
                case Keys.E:
                    if (podnies1 && podnies2 && podnies3)
                    {
                        podnies1 = false;
                        if (!podnies1)
                        {
                            podnies1 = true;
                        }
                    }
                  

                    break;
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
            }
        }
    }
}