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
        #region variables

        Platform levelOneFloor = new Platform();
        Platform levelOneSecondPlatform = new Platform();
        Platform levelOneFirstPlatform = new Platform();
        Platform levelTwoFloor = new Platform();
        Platform levelTwoSecondPlatform = new Platform();
        Platform levelTwoFirstPlatform = new Platform();


        InteractiveObject levelOneLeftEquationChecker = new InteractiveObject();
        InteractiveObject levelOneRightEquationChecker = new InteractiveObject();
        InteractiveObject levelTwoLeftEquationChecker = new InteractiveObject();
        InteractiveObject levelTwoRightEquationChecker = new InteractiveObject();
        InteractiveObject levelTwoMiddleEquationChecker = new InteractiveObject();


        Player gracz1 = new Player();
        IList<Platform> PlatformList;
        Level levelOne = new Level();
        Level levelTwo = new Level();

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


        InteractiveObject levelOneSolution=new InteractiveObject();
        InteractiveObject levelTwoFirstSolution=new InteractiveObject();
        InteractiveObject levelTwoFinalSolution=new InteractiveObject();
        private int levelNumber = 1;

        MenuControl levelSelector = new MenuControl();


        InteractiveObject boxOne = new InteractiveObject();
        InteractiveObject boxTwo = new InteractiveObject();
        InteractiveObject boxThree = new InteractiveObject();
        InteractiveObject boxFour = new InteractiveObject();
        InteractiveObject boxFive = new InteractiveObject();
        InteractiveObject boSix = new InteractiveObject();
        InteractiveObject boxSeven = new InteractiveObject();
        InteractiveObject boxEight = new InteractiveObject();
        InteractiveObject boxNine = new InteractiveObject();

        InteractiveObject levelOneOperator = new InteractiveObject();
        InteractiveObject levelOneDoor = new InteractiveObject();
        InteractiveObject levelTwoFirstOperator = new InteractiveObject();
        InteractiveObject levelTwoSecondOperator = new InteractiveObject();

        InteractiveObject levelTwoDoor = new InteractiveObject();
        private int i;
        Equation equation = new Equation();
        public bool isRightKeyPressed;
        public bool isRightMovementAvailable, isLeftMovementAvailable, isJumping, isLeftKeyPressed, isJumpKeyPressed;

        List<bool> boxPickUp = new List<bool>();

        private bool isBoxOnePickedUp,
            isBoxTwoPickedUp,
            isBoxThreePickedUp,
            isBoxFourPickedUp,
            isBoxFivePickedUp,
            isBoxSixPickedUp,
            isBoxSevenPickedUp,
            isBoxEightPickedUp,
            isBoxNinePickedUp;

        public int force;
        Collision kolizja = new Collision();
        bool menuShow, levelSelectShow, helpShow;

       

        bool lvl1en;
        Menu menu = new Menu();

        private int test;
        private bool f;

        #endregion variables


        public Main()
        {
            InitializeComponent();


            for (int k = 0; k <= 16; k++) LevelSelectList.Add(new MenuControl());
            levelOneTimer.Enabled = false;
            levelTwoTimer.Enabled = false;
            //levelOneSolution = -1;
            isRightMovementAvailable = true;
            isLeftMovementAvailable = true;
            PlatformList = new List<Platform>();
            OldMenu.Hide();
            menu.Show();
            levelOne.Hide();
            Help.Hide();
            levelSelect.Hide();
            menuShow = true;
            lvl1en = false;
            menu.InitializeMenu(this);
            Help.InitializeMenu(this);
            gracz1.InitializePlayer(level: levelOne);
            optionChooser.InitializeChooser(menu);
            optionStart.InitializeOption(250, 100, menu, Properties.Resources.start);
            optionClose.InitializeOption(250, 400, menu, Properties.Resources.koniec);
            levelSelector.InitializeOption(100, 210, levelSelect, Properties.Resources.select);
            optionSelectLevel.InitializeOption(250, 200, menu, Properties.Resources.poziom);
            optionHelp.InitializeOption(250, 300, menu, Properties.Resources.pomoc);
            helpPage.InitializeOption(0, 0, Help, Properties.Resources.Help);
            helpPage.Size = new System.Drawing.Size(1005, 729);
            levelSelect.InitializeMenu(this);


            for (int f = 0; f <= 4; f++)

            {
                LevelSelectList[f].InitializeOption(100 + 100 * f, 210, levelSelect,
                    Properties.Resources.lvl1);
            }
        }

        private void LevelOneTick(object sender, EventArgs e)
        {
            gracz1.CheckCollision(kolizja, levelOneFloor, this);
            gracz1.CheckCollision(kolizja, levelOneDoor, this);
            gracz1.CheckCollision(kolizja, levelOneSecondPlatform, this);
            boxOne.PickUp(gracz1, isBoxOnePickedUp);
            boxTwo.PickUp(gracz1, isBoxTwoPickedUp);
            boxThree.PickUp(gracz1, isBoxThreePickedUp);


            gracz1.CheckCollision(kolizja, levelOneFirstPlatform, this);
            gracz1.FallingObject(kolizja, levelOneSecondPlatform, levelOne);
            gracz1.FallingObject(kolizja, levelOneFloor, levelOne);
            gracz1.FallingObject(kolizja, levelOneFirstPlatform, levelOne);
            boxOne.FallingObject(kolizja, levelOneSecondPlatform, levelOne);
            boxOne.FallingObject(kolizja, levelOneFirstPlatform, levelOne);
            boxOne.FallingObject(kolizja, levelOneFloor, levelOne);
            boxTwo.FallingObject(kolizja, levelOneSecondPlatform, levelOne);
            boxTwo.FallingObject(kolizja, levelOneFirstPlatform, levelOne);
            boxTwo.FallingObject(kolizja, levelOneFloor, levelOne);
            boxThree.FallingObject(kolizja, levelOneSecondPlatform, levelOne);
            boxThree.FallingObject(kolizja, levelOneFirstPlatform, levelOne);
            boxThree.FallingObject(kolizja, levelOneFloor, levelOne);

            gracz1.PlayerMovement(this, levelOne, kolizja);
           
            levelOneSolution.value = equation.EquationSolve(boxOne, boxThree, levelOneOperator, levelOneLeftEquationChecker,
                levelOneRightEquationChecker);
       
            if (levelOneSolution.value == levelOneDoor.value)
            {
                if (levelOneDoor.Top >= 220)
                    levelOneDoor.Top -= 5;
            }

            if (gracz1.Right >= levelOneDoor.Right - 5)
            {
                levelOne.Hide();
                levelOneTimer.Enabled = false;
                LevelTwoInit();
                levelNumber++;
            }
        }

        private void LevelTwoTick(object sender, EventArgs e)
        {
            gracz1.CheckCollision(kolizja, levelTwoFloor, this);
            gracz1.CheckCollision(kolizja, levelTwoDoor, this);
            gracz1.CheckCollision(kolizja, levelTwoSecondPlatform, this);
            boxOne.PickUp(gracz1, isBoxOnePickedUp);
            boxTwo.PickUp(gracz1, isBoxTwoPickedUp);
            boxThree.PickUp(gracz1, isBoxThreePickedUp);


            gracz1.CheckCollision(kolizja, levelTwoFirstPlatform, this);
            gracz1.FallingObject(kolizja, levelTwoSecondPlatform, levelTwo);
            gracz1.FallingObject(kolizja, levelTwoFloor, levelTwo);
            gracz1.FallingObject(kolizja, levelTwoFirstPlatform, levelTwo);
            boxOne.FallingObject(kolizja, levelTwoSecondPlatform, levelTwo);
            boxOne.FallingObject(kolizja, levelTwoFirstPlatform, levelTwo);
            boxOne.FallingObject(kolizja, levelTwoFloor, levelTwo);
            boxTwo.FallingObject(kolizja, levelTwoSecondPlatform, levelTwo);
            boxTwo.FallingObject(kolizja, levelTwoFirstPlatform, levelTwo);
            boxTwo.FallingObject(kolizja, levelTwoFloor, levelTwo);
            boxThree.FallingObject(kolizja, levelTwoSecondPlatform, levelTwo);
            boxThree.FallingObject(kolizja, levelTwoFirstPlatform, levelTwo);
            boxThree.FallingObject(kolizja, levelTwoFloor, levelTwo);

            gracz1.PlayerMovement(this, levelTwo, kolizja);


            test = boxOne.Bottom;
            test = boxTwo.Bottom;
            test = levelTwoMiddleEquationChecker.Top;
            levelTwoFirstSolution.value = equation.EquationSolve(boxOne, boxTwo, levelTwoFirstOperator, levelTwoLeftEquationChecker,
                levelTwoMiddleEquationChecker);
           
            levelTwoFirstSolution.Top = levelTwoMiddleEquationChecker.Top-levelTwoMiddleEquationChecker.Height;
            levelTwoFirstSolution.Left = levelTwoMiddleEquationChecker.Left;
            levelTwoFirstSolution.Size = levelTwoMiddleEquationChecker.Size;
            levelTwoFinalSolution.value = equation.EquationSolve(levelTwoFirstSolution, boxThree,
                levelTwoSecondOperator, levelTwoMiddleEquationChecker, levelTwoRightEquationChecker);

            if (levelTwoFinalSolution.value == levelTwoDoor.value)
            {
                if (levelTwoDoor.Top >= 220)
                    levelTwoDoor.Top -= 5;
            }

            if (gracz1.Right >= levelTwoDoor.Right - 5)
            {
                levelTwo.Hide();
                LevelTwoInit();
                levelNumber++;
            }
        }

        private void LevelThreeTick(object sender, EventArgs e)
        {

        }

        private void LevelFourTick(object sender, EventArgs e)
        {

        }

        private void LevelFiveTick(object sender, EventArgs e)
        {

        }

        private void Gra_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                {
                    if (!menuShow)
                    {
                        isRightKeyPressed = true;
                       isRightMovementAvailable = true;
                    }
                }

                    if (levelSelectShow) levelSelector.ChangeControlPositionRight();
                    break;

                case Keys.Left:

                    if (!menuShow)
                    {
                        isLeftKeyPressed = true;
                        isLeftMovementAvailable = true;
                    }

                    if (levelSelectShow) levelSelector.ChangeControlPositionLeft();
                    break;

                case Keys.Escape:

                    if (menuShow && !levelSelectShow & !helpShow) this.Close();
                    else if (levelSelectShow)
                    {
                        levelTwoTimer.Enabled = false;
                        levelSelect.Hide();
                        menu.Show();
                        levelSelectShow = false;
                        optionChooser.InitializeChooser(menu);
                        i = 0;
                    }
                    else if (helpShow)
                    {
                        Help.Hide();
                        menu.Show();
                        helpShow = false;
                        optionChooser.InitializeChooser(menu);

                        i = 0;
                    }
                    else
                    {
                        menu.Show();
                        lvl1en = false;
                        optionChooser.InitializeChooser(menu);

                        levelOne.Hide();
                        foreach (Control ctrl in levelOne.Controls)
                        {
                            ctrl.Enabled = false;
                        }

                        foreach (Control ctrl in menu.Controls)
                        {
                            ctrl.Enabled = true;
                        }

                        menuShow = true;
                    }

                    break;


                case Keys.Space:
                {
                    if (!isJumping && !isJumpKeyPressed)
                    {
                        isJumping = true;
                        isJumpKeyPressed = true;
                        force = 60;
                    }
                }
                    break;
                case Keys.Up:
                    if (menuShow)
                    {
                        if (i >= 1 && i <= 3)
                        {
                            optionChooser.ChangeControlPositionUp();


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
                        }
                    }

                    break;

                case Keys.Enter:

                    switch (i)
                    {
                        case 0:
                            switch (levelNumber)
                            {
                                case 1:
                                    LevelOneInit();
                                    break;
                                case 2:
                                    LevelTwoInit();
                                    break;
                            }

                            menuShow = false;
                            menu.Hide();


                            lvl1en = true;
                            OldMenu.Hide();
                            break;
                        case 1:
                            menu.Hide();
                            levelSelect.Show();
                            i = 0;
                            levelSelectShow = true;
                            break;
                        case 2:
                            Help.Show();
                            helpShow = true;
                            menu.Hide();
                            break;
                        case 3:
                            if (!levelSelectShow && !helpShow) this.Close();
                            break;
                    }

                    break;
                case Keys.E:
                    f = isBoxOnePickedUp;
                    f = isBoxTwoPickedUp;
                    f = isBoxThreePickedUp;

                    if (boxOne.IsPlayerNextToObject(gracz1))
                    {
                        if (!isBoxOnePickedUp && !isBoxThreePickedUp && !isBoxTwoPickedUp && !isBoxFourPickedUp && !isBoxFivePickedUp)
                        {
                            isBoxOnePickedUp = true;

                        }
                        else
                        {
                            isBoxOnePickedUp = false;
                        }
                    }
                    else if (boxTwo.IsPlayerNextToObject(gracz1))
                    {
                        if (!isBoxOnePickedUp && !isBoxThreePickedUp && !isBoxTwoPickedUp && !isBoxFourPickedUp && !isBoxFivePickedUp)
                        {
                            isBoxTwoPickedUp = true;
                        }
                        else isBoxTwoPickedUp = false;
                    }
                    else if (boxThree.IsPlayerNextToObject(gracz1))
                    {
                        if (!isBoxOnePickedUp && !isBoxThreePickedUp && !isBoxTwoPickedUp && !isBoxFourPickedUp && !isBoxFivePickedUp)
                        {
                            isBoxThreePickedUp = true;

                        }
                        else isBoxThreePickedUp = false;

                    }
                    else if (boxFour.IsPlayerNextToObject(gracz1))
                    {
                        if (!isBoxOnePickedUp && !isBoxThreePickedUp && !isBoxTwoPickedUp && !isBoxFourPickedUp && !isBoxFivePickedUp)
                        {
                            isBoxFourPickedUp = true;
                        }
                        else isBoxFourPickedUp = false;
                    }
                    else if (boxFive.IsPlayerNextToObject(gracz1))
                    {
                        if (!isBoxOnePickedUp && !isBoxThreePickedUp && !isBoxTwoPickedUp && !isBoxFourPickedUp && !isBoxFivePickedUp)
                        {
                            isBoxFivePickedUp = true;

                        }
                        else isBoxFivePickedUp = false;

                    }
                    f = isBoxOnePickedUp;
                    f = isBoxTwoPickedUp;
                    f = isBoxThreePickedUp;

                    break;
            }
        }



        private void Gra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                isRightKeyPressed = false;

                 isRightMovementAvailable = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                isLeftKeyPressed = false;
                isLeftMovementAvailable = false;
            }

            if (e.KeyCode == Keys.Space)
            {
                isJumpKeyPressed = false;
            }
        }

        private void LevelOneInit()
        {
            levelOne.Show();

            levelOneTimer.Enabled = true;

            gracz1.InitializePlayer(level: levelOne);

            levelOne.InitializeLevel(this);

            boxOne.InitializeObject(315, 100, Properties.Resources.Box1, 25, 25, levelOne, 1);
            boxTwo.InitializeObject(200, 100, Properties.Resources.Box2, 25, 25, levelOne, 2);
            boxThree.InitializeObject(435, 100, Properties.Resources.Box3, 25, 25, levelOne,3);

            levelOneDoor.InitializeObject(720, 370, Properties.Resources.Drzwi4, 36, 180, levelOne, 4);
            levelOneOperator.InitializeObject(595, 480, Properties.Resources.Znak_plus, 40, 70, levelOne, 0);

            levelOneFirstPlatform.InitializePlatform(platformX: 300, platformY: 450, platformWidth: 150,
                platformHeight: 10, isFloor: false, level: levelOne);
            levelOneFloor.InitializePlatform(platformX: 10, platformY: 721, platformWidth: 0,
                platformHeight: 0,
                isFloor: true, level: levelOne);
            levelOneSecondPlatform.InitializePlatform(platformX: 100, platformY: 450,
                platformWidth: 150, platformHeight: 70, isFloor: false, level: levelOne);

            levelOneLeftEquationChecker.InitializePlatform(565, 545, 30, 10, false, levelOne);
            levelOneRightEquationChecker.InitializePlatform(635, 545, 30, 10, false, levelOne);
            levelOneLeftEquationChecker.BackgroundImage = null;
            levelOneRightEquationChecker.BackgroundImage = null;
            levelOneLeftEquationChecker.BackColor = Color.DarkOrange;
            levelOneRightEquationChecker.BackColor = Color.DarkOrange;
            levelOneLeftEquationChecker.BringToFront();
            levelOneRightEquationChecker.BringToFront();
            levelOneRightEquationChecker.Image = null;

        }

        private void LevelTwoInit()
        {
           
            levelTwo.Show();

            levelTwoTimer.Enabled = true;

            gracz1.InitializePlayer(level: levelTwo);

            levelTwo.InitializeLevel(this);

            boxOne.InitializeObject(420, 100, Properties.Resources.Box7, 25, 25, levelTwo, 7);
            boxTwo.InitializeObject(90, 400, Properties.Resources.Box3, 25, 25, levelTwo, 3);
            boxThree.InitializeObject(440, 300, Properties.Resources.Box5, 25, 25, levelTwo, 5);

            levelTwoDoor.InitializeObject(720, 370, Properties.Resources.Drzwi9, 36, 180, levelTwo, 9);
            levelTwoFirstOperator.InitializeObject(135, 270, Properties.Resources.Znak_minus, 40, 70, levelTwo, 1);
            levelTwoSecondOperator.InitializeObject(205, 270, Properties.Resources.Znak_plus, 40, 70, levelTwo, 0);


            levelTwoFirstPlatform.InitializePlatform(platformX: 50, platformY: 340, platformWidth: 250,
                platformHeight: 20, isFloor: false, level: levelTwo);
            levelTwoFloor.InitializePlatform(platformX: 10, platformY: 721, platformWidth: 0,
                platformHeight: 0,
                isFloor: true, level: levelTwo);
            levelTwoSecondPlatform.InitializePlatform(platformX: 390, platformY: 450,
                platformWidth: 150, platformHeight: 20, isFloor: false, level: levelTwo);


            levelTwoLeftEquationChecker.InitializePlatform(100, 339, 30, 10, false, levelTwo);
            levelTwoMiddleEquationChecker.InitializePlatform(170, 339, 30, 10, false, levelTwo);
            levelTwoRightEquationChecker.InitializePlatform(240, 339, 30, 10, false, levelTwo);

            levelTwoLeftEquationChecker.BackgroundImage = null;
            levelTwoMiddleEquationChecker.BackgroundImage = null;
            levelTwoRightEquationChecker.BackgroundImage = null;

            levelTwoLeftEquationChecker.BackColor = Color.DarkOrange;
            levelTwoMiddleEquationChecker.BackColor = Color.DarkOrange;
            levelTwoRightEquationChecker.BackColor = Color.DarkOrange;

            levelTwoLeftEquationChecker.BringToFront();
            levelTwoMiddleEquationChecker.BringToFront();
            levelTwoRightEquationChecker.BringToFront();


        }
    }
}