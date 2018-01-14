using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Math_MADS.Properties;


namespace Math_MADS
{
    /// <summary>
    /// Główna klasa programu
    /// </summary>
    public partial class Main : Form
    {
        #region variables

        /// <summary>
        /// Zmienne Platform
        /// </summary>
        Platform floor = new Platform();

        Platform firstPlatform = new Platform();
        Platform secondPlatform = new Platform();
        Platform thirdPlatform = new Platform();

        /// <summary>
        /// Zmienne sprawdzania działania
        /// </summary>
        InteractiveObject leftEquationChecker = new InteractiveObject();

        InteractiveObject rightEquationChecker = new InteractiveObject();
        InteractiveObject middleLeftEquationChecker = new InteractiveObject();
        InteractiveObject middleRightEquationChecker = new InteractiveObject();

        /// <summary>
        /// Zmienna gracza
        /// </summary>
        Player gracz1 = new Player();

        /// <summary>
        /// Zmienne poziomów
        /// </summary>
        Level levelOne = new Level();

        Level levelTwo = new Level();
        Level levelThree = new Level();
        Level levelFour = new Level();
        Level levelFive = new Level();

        /// <summary>
        /// Zmienne kontrolek menu
        /// </summary>
        MenuControl optionChooser = new MenuControl();

        MenuControl optionStart = new MenuControl();
        MenuControl optionClose = new MenuControl();
        MenuControl levelSelector = new MenuControl();

        MenuControl optionSelectLevel = new MenuControl();
        MenuControl optionHelp = new MenuControl();
        MenuControl helpPage = new MenuControl();
        List<MenuControl> LevelSelectList = new List<MenuControl>();

        /// <summary>
        /// Zmienne Menu
        /// </summary>
        Menu levelSelect = new Menu();

        Menu menu = new Menu();
        Menu Help = new Menu();

        /// <summary>
        /// Zmienne wyników działania
        /// </summary>
        InteractiveObject finalSolution = new InteractiveObject();

        InteractiveObject firstSolution = new InteractiveObject();
        InteractiveObject secondSolution = new InteractiveObject();

        /// <summary>
        /// Zmienne skrzynek
        /// </summary>
        InteractiveObject boxOne = new InteractiveObject();

        InteractiveObject boxTwo = new InteractiveObject();
        InteractiveObject boxThree = new InteractiveObject();
        InteractiveObject boxFour = new InteractiveObject();
        InteractiveObject boxFive = new InteractiveObject();

        /// <summary>
        /// Zmienna drzwi
        /// </summary>
        InteractiveObject door = new InteractiveObject();

        /// <summary>
        /// Zmienne Znaków działania
        /// </summary>
        InteractiveObject firstOperator = new InteractiveObject();

        InteractiveObject secondOperator = new InteractiveObject();
        InteractiveObject thirdOperator = new InteractiveObject();

        /// <summary>
        /// Zmienne kontrolne  menu oraz poziomów
        /// </summary>
        private int menuSelectorPosition;

        private int levelNumber = 1;
        private int levelSelectorPosition;

        /// <summary>
        /// Zmienna działania
        /// </summary>
        Equation equation = new Equation();

        /// <summary>
        /// Zmienne odzpowiedzialne za ruch
        /// </summary>
        public bool isRightMovementAvailable,
            isLeftMovementAvailable,
            isJumping,
            isLeftKeyPressed,
            isJumpKeyPressed,
            isRightKeyPressed;

        public int force;
        Collision kolizja = new Collision();

        /// <summary>
        /// Zmienne kontrolne podnoszenia skrzynek
        /// </summary>
        private bool isBoxOnePickedUp,
            isBoxTwoPickedUp,
            isBoxThreePickedUp,
            isBoxFourPickedUp,
            isBoxFivePickedUp;

        /// <summary>
        /// Zmienne kontrolne pozycji menu
        /// </summary>
        bool menuShow, levelSelectShow, helpShow;



        List<Bitmap> levelSelectBitmaps=new List<Bitmap>();
        #endregion variables

        /// <summary>
        /// Wstępna inicjalizacja parametrów
        /// </summary>
        public Main()
        {

            levelSelectBitmaps.Add(Properties.Resources.lvl1);
            levelSelectBitmaps.Add(Properties.Resources.lvl2);
            levelSelectBitmaps.Add(Properties.Resources.lvl3);
            levelSelectBitmaps.Add(Properties.Resources.lvl4);
            levelSelectBitmaps.Add(Properties.Resources.lvl5);
            InitializeComponent();
            levelSelectorPosition = 0;

            for (int k = 0; k <= 16; k++) LevelSelectList.Add(new MenuControl());
            levelOneTimer.Enabled = false;
            levelTwoTimer.Enabled = false;
            levelThreeTimer.Enabled = false;
            levelFourTimer.Enabled = false;
            levelFiveTimer.Enabled = false;
            levelNumber = 1;
            isRightMovementAvailable = true;
            isLeftMovementAvailable = true;
            menu.Show();
            levelOne.Hide();
            Help.Hide();
            levelSelect.Hide();
            menuShow = true;
            menu.InitializeMenu(this);
            Help.InitializeMenu(this);
            gracz1.InitializePlayer(level: levelOne);
            optionChooser.InitializeChooser(menu);
            optionClose.InitializeOption(250, 370, menu, Properties.Resources.koniec);
            levelSelector.InitializeOption(100, 210, levelSelect, Properties.Resources.select);
            optionSelectLevel.InitializeOption(250, 170, menu, Properties.Resources.poziom);
            optionHelp.InitializeOption(250, 270, menu, Properties.Resources.pomoc);
            helpPage.InitializeOption(0, 0, Help, Properties.Resources.Help);
            helpPage.Size = new System.Drawing.Size(1005, 729);
            levelSelect.InitializeMenu(this);


            for (int f = 0; f <= 4; f++)

            {
                LevelSelectList[f].InitializeOption(20 + 140 * f, 210, levelSelect,
                    levelSelectBitmaps[f]);
            }
        }

        /// <summary>
        /// Metoda zegara poziomu pierwszego
        /// Metoda ta sprawdza kolizję obiektów na poziomie pierwszym oraz jest odpowiedzialna za ruch gracza na poziomie pierwszym
        /// poziom sie kończy gdy skrzynki z numerami znajda się w odpowiednim miejscu i dadzą rządany wynik działania
        /// W przypadku nie spełnienia tych warunków program resetuje wartości działań dopóki nie będą one poprawne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LevelOneTick(object sender, EventArgs e)
        {
            gracz1.CheckCollision(kolizja, floor, this);
            gracz1.CheckCollision(kolizja, door, this);
            gracz1.CheckCollision(kolizja, secondPlatform, this);
            boxOne.PickUp(gracz1, isBoxOnePickedUp);
            boxTwo.PickUp(gracz1, isBoxTwoPickedUp);
            boxThree.PickUp(gracz1, isBoxThreePickedUp);


            gracz1.CheckCollision(kolizja, firstPlatform, this);
            gracz1.FallingObject(kolizja, secondPlatform, levelOne);
            gracz1.FallingObject(kolizja, floor, levelOne);
            gracz1.FallingObject(kolizja, firstPlatform, levelOne);
            boxOne.FallingObject(kolizja, secondPlatform, levelOne);
            boxOne.FallingObject(kolizja, firstPlatform, levelOne);
            boxOne.FallingObject(kolizja, floor, levelOne);
            boxTwo.FallingObject(kolizja, secondPlatform, levelOne);
            boxTwo.FallingObject(kolizja, firstPlatform, levelOne);
            boxTwo.FallingObject(kolizja, floor, levelOne);
            boxThree.FallingObject(kolizja, secondPlatform, levelOne);
            boxThree.FallingObject(kolizja, firstPlatform, levelOne);
            boxThree.FallingObject(kolizja, floor, levelOne);

            gracz1.PlayerMovement(this, levelOne, kolizja);


            CheckValue(finalSolution, boxTwo, boxOne, firstOperator, leftEquationChecker,
                rightEquationChecker);
            CheckValue(finalSolution, boxTwo, boxThree, firstOperator, leftEquationChecker,
                rightEquationChecker);
            CheckValue(finalSolution, boxThree, boxOne, firstOperator, leftEquationChecker,
                rightEquationChecker);


            if (finalSolution.value == door.value)
            {
                if (door.Top >= 220)
                    door.Top -= 5;
            }
            else
            {
                firstSolution.value = -2000;
                finalSolution.value = -2000;
            }

            if (gracz1.Right >= door.Right - 5)
            {
                levelOne.Hide();
                levelOneTimer.Enabled = false;
                LevelTwoInit();
                levelNumber++;
            }
        }

        /// <summary>
        /// Metoda zegara poziomu piątego
        /// Analaogicznie do poziomu pierwszego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LevelTwoTick(object sender, EventArgs e)
        {
            gracz1.CheckCollision(kolizja, floor, this);
            gracz1.CheckCollision(kolizja, door, this);
            gracz1.CheckCollision(kolizja, secondPlatform, this);
            boxOne.PickUp(gracz1, isBoxOnePickedUp);
            boxTwo.PickUp(gracz1, isBoxTwoPickedUp);
            boxThree.PickUp(gracz1, isBoxThreePickedUp);
            boxFive.PickUp(gracz1, isBoxFivePickedUp);
            boxFour.PickUp(gracz1, isBoxFourPickedUp);


            gracz1.CheckCollision(kolizja, firstPlatform, this);
            gracz1.FallingObject(kolizja, secondPlatform, levelTwo);
            gracz1.FallingObject(kolizja, floor, levelTwo);
            gracz1.FallingObject(kolizja, firstPlatform, levelTwo);
            boxOne.FallingObject(kolizja, secondPlatform, levelTwo);
            boxOne.FallingObject(kolizja, firstPlatform, levelTwo);
            boxOne.FallingObject(kolizja, floor, levelTwo);
            boxTwo.FallingObject(kolizja, secondPlatform, levelTwo);
            boxTwo.FallingObject(kolizja, firstPlatform, levelTwo);
            boxTwo.FallingObject(kolizja, floor, levelTwo);
            boxThree.FallingObject(kolizja, secondPlatform, levelTwo);
            boxThree.FallingObject(kolizja, firstPlatform, levelTwo);
            boxThree.FallingObject(kolizja, floor, levelTwo);
            boxFour.FallingObject(kolizja, secondPlatform, levelTwo);
            boxFour.FallingObject(kolizja, firstPlatform, levelTwo);
            boxFour.FallingObject(kolizja, floor, levelTwo);
            boxFive.FallingObject(kolizja, secondPlatform, levelTwo);
            boxFive.FallingObject(kolizja, firstPlatform, levelTwo);
            boxFive.FallingObject(kolizja, floor, levelTwo);

            gracz1.PlayerMovement(this, levelTwo, kolizja);


            CheckValue(firstSolution, boxOne, boxTwo, firstOperator, leftEquationChecker, middleLeftEquationChecker);
            CheckValue(firstSolution, boxThree, boxTwo, firstOperator, leftEquationChecker, middleLeftEquationChecker);
            CheckValue(firstSolution, boxOne, boxThree, firstOperator, leftEquationChecker, middleLeftEquationChecker);

            firstSolution.Top = middleLeftEquationChecker.Top - middleLeftEquationChecker.Height;
            firstSolution.Left = middleLeftEquationChecker.Left;
            firstSolution.Size = middleLeftEquationChecker.Size;

            CheckValue(finalSolution, firstSolution, boxOne, secondOperator, middleLeftEquationChecker,
                rightEquationChecker);
            CheckValue(finalSolution, firstSolution, boxTwo, secondOperator, middleLeftEquationChecker,
                rightEquationChecker);

            CheckValue(finalSolution, firstSolution, boxThree, secondOperator, middleLeftEquationChecker,
                rightEquationChecker);
            if (finalSolution.value == door.value)
            {
                if (door.Top >= 220)
                    door.Top -= 5;
            }
            else
            {
                firstSolution.value = -2000;
                finalSolution.value = -2000;
            }

            if (gracz1.Right >= door.Right - 5)
            {
                levelTwo.Hide();
                LevelThreeInit();
                levelTwoTimer.Enabled = false;

                levelNumber++;
            }
        }

        /// <summary>
        /// Metoda zegara poziomu drugiego
        /// Analaogicznie do poziomu pierwszego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LevelThreeTick(object sender, EventArgs e)
        {
            gracz1.CheckCollision(kolizja, floor, this);
            gracz1.CheckCollision(kolizja, door, this);
            gracz1.CheckCollision(kolizja, secondPlatform, this);
            gracz1.CheckCollision(kolizja, thirdPlatform, this);

            boxOne.PickUp(gracz1, isBoxOnePickedUp);
            boxTwo.PickUp(gracz1, isBoxTwoPickedUp);
            boxThree.PickUp(gracz1, isBoxThreePickedUp);
            boxFive.PickUp(gracz1, isBoxFivePickedUp);
            boxFour.PickUp(gracz1, isBoxFourPickedUp);


            gracz1.CheckCollision(kolizja, firstPlatform, this);
            gracz1.FallingObject(kolizja, secondPlatform, levelThree);
            gracz1.FallingObject(kolizja, floor, levelThree);
            gracz1.FallingObject(kolizja, firstPlatform, levelThree);
            gracz1.FallingObject(kolizja, thirdPlatform, levelThree);


            boxOne.FallingObject(kolizja, secondPlatform, levelThree);
            boxOne.FallingObject(kolizja, firstPlatform, levelThree);
            boxOne.FallingObject(kolizja, thirdPlatform, levelThree);
            boxOne.FallingObject(kolizja, floor, levelThree);

            boxTwo.FallingObject(kolizja, secondPlatform, levelThree);
            boxTwo.FallingObject(kolizja, firstPlatform, levelThree);
            boxTwo.FallingObject(kolizja, thirdPlatform, levelThree);
            boxTwo.FallingObject(kolizja, floor, levelThree)
                ;
            boxThree.FallingObject(kolizja, secondPlatform, levelThree);
            boxThree.FallingObject(kolizja, firstPlatform, levelThree);
            boxThree.FallingObject(kolizja, thirdPlatform, levelThree);
            boxThree.FallingObject(kolizja, floor, levelThree);

            boxFour.FallingObject(kolizja, secondPlatform, levelThree);
            boxFour.FallingObject(kolizja, firstPlatform, levelThree);
            boxFour.FallingObject(kolizja, thirdPlatform, levelThree);
            boxFour.FallingObject(kolizja, floor, levelThree);


            boxFive.FallingObject(kolizja, secondPlatform, levelThree);
            boxFive.FallingObject(kolizja, firstPlatform, levelThree);
            boxFive.FallingObject(kolizja, thirdPlatform, levelThree);
            boxFive.FallingObject(kolizja, floor, levelThree);

            gracz1.PlayerMovement(this, levelThree, kolizja);

            CheckValue(firstSolution, boxOne, boxTwo, firstOperator, leftEquationChecker, middleLeftEquationChecker);
            CheckValue(firstSolution, boxThree, boxTwo, firstOperator, leftEquationChecker, middleLeftEquationChecker);
            CheckValue(firstSolution, boxOne, boxThree, firstOperator, leftEquationChecker, middleLeftEquationChecker);
            firstSolution.Top = middleLeftEquationChecker.Top - middleLeftEquationChecker.Height;
            firstSolution.Left = middleLeftEquationChecker.Left;
            firstSolution.Size = middleLeftEquationChecker.Size;

            CheckValue(finalSolution, firstSolution, boxOne, secondOperator, middleLeftEquationChecker,
                rightEquationChecker);
            CheckValue(finalSolution, firstSolution, boxTwo, secondOperator, middleLeftEquationChecker,
                rightEquationChecker);

            CheckValue(finalSolution, firstSolution, boxThree, secondOperator, middleLeftEquationChecker,
                rightEquationChecker);

            if (finalSolution.value == door.value)
            {
                if (door.Top >= 220)
                    door.Top -= 5;
            }
            else
            {
                firstSolution.value = -2000;
                finalSolution.value = -2000;
            }

            if (gracz1.Right >= door.Right - 5)
            {
                levelThree.Hide();
                LevelFourInit();
                levelNumber++;
                levelThreeTimer.Enabled = false;
            }
        }

        /// <summary>
        /// Metoda zegara poziomu trzeciego
        /// Analaogicznie do poziomu pierwszego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LevelFourTick(object sender, EventArgs e)
        {
            gracz1.CheckCollision(kolizja, floor, this);
            gracz1.CheckCollision(kolizja, door, this);
            gracz1.CheckCollision(kolizja, secondPlatform, this);
            gracz1.CheckCollision(kolizja, thirdPlatform, this);

            boxOne.PickUp(gracz1, isBoxOnePickedUp);
            boxTwo.PickUp(gracz1, isBoxTwoPickedUp);
            boxThree.PickUp(gracz1, isBoxThreePickedUp);
            boxFive.PickUp(gracz1, isBoxFivePickedUp);
            boxFour.PickUp(gracz1, isBoxFourPickedUp);


            gracz1.CheckCollision(kolizja, firstPlatform, this);
            gracz1.FallingObject(kolizja, secondPlatform, levelThree);
            gracz1.FallingObject(kolizja, floor, levelFour);
            gracz1.FallingObject(kolizja, firstPlatform, levelFour);
            gracz1.FallingObject(kolizja, thirdPlatform, levelFour);


            boxOne.FallingObject(kolizja, secondPlatform, levelFour);
            boxOne.FallingObject(kolizja, firstPlatform, levelFour);
            boxOne.FallingObject(kolizja, thirdPlatform, levelFour);
            boxOne.FallingObject(kolizja, floor, levelFour);

            boxTwo.FallingObject(kolizja, secondPlatform, levelFour);
            boxTwo.FallingObject(kolizja, firstPlatform, levelFour);
            boxTwo.FallingObject(kolizja, thirdPlatform, levelFour);
            boxTwo.FallingObject(kolizja, floor, levelFour)
                ;
            boxThree.FallingObject(kolizja, secondPlatform, levelFour);
            boxThree.FallingObject(kolizja, firstPlatform, levelFour);
            boxThree.FallingObject(kolizja, thirdPlatform, levelFour);
            boxThree.FallingObject(kolizja, floor, levelFour);

            boxFour.FallingObject(kolizja, secondPlatform, levelFour);
            boxFour.FallingObject(kolizja, firstPlatform, levelFour);
            boxFour.FallingObject(kolizja, thirdPlatform, levelFour);
            boxFour.FallingObject(kolizja, floor, levelFour);


            boxFive.FallingObject(kolizja, secondPlatform, levelFour);
            boxFive.FallingObject(kolizja, firstPlatform, levelFour);
            boxFive.FallingObject(kolizja, thirdPlatform, levelFour);
            boxFive.FallingObject(kolizja, floor, levelFour);

            gracz1.PlayerMovement(this, levelFour, kolizja);

            CheckValue(firstSolution, boxOne, boxTwo, firstOperator, leftEquationChecker, middleLeftEquationChecker);
            CheckValue(firstSolution, boxThree, boxTwo, firstOperator, leftEquationChecker, middleLeftEquationChecker);
            CheckValue(firstSolution, boxOne, boxThree, firstOperator, leftEquationChecker, middleLeftEquationChecker);

            firstSolution.Top = middleLeftEquationChecker.Top - middleLeftEquationChecker.Height;
            firstSolution.Left = middleLeftEquationChecker.Left;
            firstSolution.Size = middleLeftEquationChecker.Size;

            CheckValue(finalSolution, firstSolution, boxOne, secondOperator, middleLeftEquationChecker,
                rightEquationChecker);
            CheckValue(finalSolution, firstSolution, boxTwo, secondOperator, middleLeftEquationChecker,
                rightEquationChecker);

            CheckValue(finalSolution, firstSolution, boxThree, secondOperator, middleLeftEquationChecker,
                rightEquationChecker);

            if (finalSolution.value == door.value)
            {
                if (door.Top >= 220)
                    door.Top -= 5;
            }
            else
            {
                firstSolution.value = -2000;
                finalSolution.value = -2000;
            }

            if (gracz1.Right >= door.Right - 5)
            {
                levelFour.Hide();
                LevelFiveInit();
                levelNumber++;
                levelFourTimer.Enabled = false;
            }
        }

        /// <summary>
        /// Metoda zegara poziomu czwartego
        /// Analaogicznie do poziomu pierwszego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LevelFiveTick(object sender, EventArgs e)
        {
            gracz1.CheckCollision(kolizja, floor, this);
            gracz1.CheckCollision(kolizja, door, this);
            gracz1.CheckCollision(kolizja, secondPlatform, this);
            gracz1.CheckCollision(kolizja, thirdPlatform, this);

            boxOne.PickUp(gracz1, isBoxOnePickedUp);
            boxTwo.PickUp(gracz1, isBoxTwoPickedUp);
            boxThree.PickUp(gracz1, isBoxThreePickedUp);
            boxFive.PickUp(gracz1, isBoxFivePickedUp);
            boxFour.PickUp(gracz1, isBoxFourPickedUp);


            gracz1.CheckCollision(kolizja, firstPlatform, this);
            gracz1.FallingObject(kolizja, secondPlatform, levelFive);
            gracz1.FallingObject(kolizja, floor, levelFive);
            gracz1.FallingObject(kolizja, firstPlatform, levelFive);
            gracz1.FallingObject(kolizja, thirdPlatform, levelFive);


            boxOne.FallingObject(kolizja, secondPlatform, levelFive);
            boxOne.FallingObject(kolizja, firstPlatform, levelFive);
            boxOne.FallingObject(kolizja, thirdPlatform, levelFive);
            boxOne.FallingObject(kolizja, floor, levelFive);

            boxTwo.FallingObject(kolizja, secondPlatform, levelFive);
            boxTwo.FallingObject(kolizja, firstPlatform, levelFive);
            boxTwo.FallingObject(kolizja, thirdPlatform, levelFive);
            boxTwo.FallingObject(kolizja, floor, levelFive)
                ;
            boxThree.FallingObject(kolizja, secondPlatform, levelFive);
            boxThree.FallingObject(kolizja, firstPlatform, levelFive);
            boxThree.FallingObject(kolizja, thirdPlatform, levelFive);
            boxThree.FallingObject(kolizja, floor, levelFive);

            boxFour.FallingObject(kolizja, secondPlatform, levelFive);
            boxFour.FallingObject(kolizja, firstPlatform, levelFive);
            boxFour.FallingObject(kolizja, thirdPlatform, levelFive);
            boxFour.FallingObject(kolizja, floor, levelFive);


            boxFive.FallingObject(kolizja, secondPlatform, levelFive);
            boxFive.FallingObject(kolizja, firstPlatform, levelFive);
            boxFive.FallingObject(kolizja, thirdPlatform, levelFive);
            boxFive.FallingObject(kolizja, floor, levelFive);

            gracz1.PlayerMovement(this, levelFive, kolizja);

            CheckValue(firstSolution, boxOne, boxTwo, firstOperator, leftEquationChecker, middleLeftEquationChecker);
            CheckValue(firstSolution, boxThree, boxTwo, firstOperator, leftEquationChecker, middleLeftEquationChecker);
            CheckValue(firstSolution, boxOne, boxThree, firstOperator, leftEquationChecker, middleLeftEquationChecker);
            CheckValue(firstSolution, boxOne, boxFour, firstOperator, leftEquationChecker, middleLeftEquationChecker);
            CheckValue(firstSolution, boxFour, boxTwo, firstOperator, leftEquationChecker, middleLeftEquationChecker);
            CheckValue(firstSolution, boxThree, boxFour, firstOperator, leftEquationChecker, middleLeftEquationChecker);
            CheckValue(secondSolution, boxOne, boxTwo, secondOperator, middleRightEquationChecker,
                rightEquationChecker);
            CheckValue(secondSolution, boxThree, boxTwo, secondOperator, middleRightEquationChecker,
                rightEquationChecker);
            CheckValue(secondSolution, boxOne, boxThree, secondOperator, middleRightEquationChecker,
                rightEquationChecker);
            CheckValue(secondSolution, boxOne, boxFour, secondOperator, middleRightEquationChecker,
                rightEquationChecker);
            CheckValue(secondSolution, boxFour, boxTwo, secondOperator, middleRightEquationChecker,
                rightEquationChecker);
            CheckValue(secondSolution, boxThree, boxFour, secondOperator, middleRightEquationChecker,
                rightEquationChecker);


            firstSolution.Top = middleLeftEquationChecker.Top - middleLeftEquationChecker.Height;
            firstSolution.Left = middleLeftEquationChecker.Left;
            firstSolution.Size = middleLeftEquationChecker.Size;
            secondSolution.Top = middleRightEquationChecker.Top - middleRightEquationChecker.Height;
            secondSolution.Left = middleRightEquationChecker.Left;
            secondSolution.Size = middleRightEquationChecker.Size;
            CheckValue(finalSolution, firstSolution, secondSolution, thirdOperator, middleLeftEquationChecker,
                middleRightEquationChecker);

            if (finalSolution.value == door.value)
            {
                if (door.Top >= 220)
                    door.Top -= 5;
            }
            else
            {
                firstSolution.value = -2000;
                finalSolution.value = -2000;
                secondSolution.value = -2000;
            }

            if (gracz1.Right >= door.Right - 5)
            {
                DisableTimers();
                levelFive.Hide();
                menu.Show();
                menuShow = true;
                menuSelectorPosition = 0;
            }
        }

        /// <summary>
        /// Metoda odpowiedzialna za wciśnięcie klawisza
        /// W switchu klawisza Enter znajduje się sterowanie menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                    if (levelSelectShow && levelSelectorPosition < 4 && levelSelectorPosition >= 0)
                    {
                        levelSelector.ChangeControlPositionRight();
                        levelSelectorPosition++;
                    }
                }

                    break;

                case Keys.Left:

                    if (!menuShow)
                    {
                        isLeftKeyPressed = true;
                        isLeftMovementAvailable = true;
                    }

                    if (levelSelectShow && levelSelectorPosition < 5 && levelSelectorPosition >= 1)
                    {
                        levelSelectorPosition--;
                        levelSelector.ChangeControlPositionLeft();
                    }

                    break;

                case Keys.Escape:

                    if (menuShow && !levelSelectShow & !helpShow) this.Close();
                    else if (levelSelectShow)
                    {
                        levelSelect.Hide();
                        menu.Show();
                        levelSelectShow = false;
                        optionChooser.InitializeChooser(menu);
                        menuSelectorPosition = 0;
                        menuShow = true;
                    }
                    else if (helpShow)
                    {
                        Help.Hide();
                        menu.Show();
                        helpShow = false;
                        optionChooser.InitializeChooser(menu);
                        menuShow = true;

                        menuSelectorPosition = 0;
                    }
                    else
                    {
                        menu.Show();
                        optionChooser.InitializeChooser(menu);
                        menuShow = true;

                        levelOne.Hide();
                        levelTwo.Hide();
                        levelThree.Hide();
                        levelFour.Hide();
                        levelFive.Hide();
                       DisableTimers();

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
                        if (menuSelectorPosition >= 1 && menuSelectorPosition <=2)
                        {
                            optionChooser.ChangeControlPositionUp();


                            menuSelectorPosition--;
                        }
                    }

                    break;

                case Keys.Down:
                    if (menuShow)
                    {
                        if (menuSelectorPosition <= 1 && menuSelectorPosition >= 0)
                        {
                            menuSelectorPosition++;
                            optionChooser.ChangeControlPositionDown();
                        }
                    }

                    break;

                case Keys.Enter:

                    switch (menuSelectorPosition)
                    {
                        case 0:

                            menu.Hide();
                            menuShow = false;
                            levelSelect.Show();
                            menuSelectorPosition = 3;
                            levelSelectShow = true;
                            levelSelector.InitializeOption(LocX: 20, LocY: 110, menu: levelSelect, image: Properties.Resources.przod);
                            levelSelector.BringToFront();
                            levelSelectorPosition = 0;
                            break;
                        case 1:
                            Help.Show();
                            helpShow = true;
                            menu.Hide();
                            break;
                        case 2:
                            if (!levelSelectShow && !helpShow) this.Close();
                            break;
                        case 3:
                            if (levelSelectShow)
                            {
                                levelSelect.Show();
                                switch (levelSelectorPosition)
                                {
                                    case 0:
                                        ShowOneLevel(levelOne);
                                        DisableTimers();
                                        LevelOneInit();
                                        menu.Hide();
                                        break;
                                    case 1:
                                        ShowOneLevel(levelTwo);

                                        DisableTimers();

                                        LevelTwoInit();
                                        menu.Hide();
                                        break;
                                    case 2:
                                        ShowOneLevel(levelThree);
                                        DisableTimers();


                                        LevelThreeInit();
                                        menu.Hide();
                                        break;
                                    case 3:
                                        ShowOneLevel(levelFour);
                                        DisableTimers();

                                        LevelFourInit();
                                        menu.Hide();

                                        break;
                                    case 4:
                                        ShowOneLevel(levelFive);
                                        DisableTimers();

                                        LevelFiveInit();
                                        menu.Hide();
                                        break;
                                }
                            }

                            menuShow = false;
                            menu.Hide();


                            break;
                    }

                    break;
                case Keys.E:


                    if (boxOne.IsPlayerNextToObject(gracz1))
                    {
                        if (!isBoxOnePickedUp && !isBoxThreePickedUp && !isBoxTwoPickedUp && !isBoxFourPickedUp &&
                            !isBoxFivePickedUp)
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
                        if (!isBoxOnePickedUp && !isBoxThreePickedUp && !isBoxTwoPickedUp && !isBoxFourPickedUp &&
                            !isBoxFivePickedUp)
                        {
                            isBoxTwoPickedUp = true;
                        }
                        else isBoxTwoPickedUp = false;
                    }
                    else if (boxThree.IsPlayerNextToObject(gracz1))
                    {
                        if (!isBoxOnePickedUp && !isBoxThreePickedUp && !isBoxTwoPickedUp && !isBoxFourPickedUp &&
                            !isBoxFivePickedUp)
                        {
                            isBoxThreePickedUp = true;
                        }
                        else isBoxThreePickedUp = false;
                    }
                    else if (boxFour.IsPlayerNextToObject(gracz1))
                    {
                        if (!isBoxOnePickedUp && !isBoxThreePickedUp && !isBoxTwoPickedUp && !isBoxFourPickedUp &&
                            !isBoxFivePickedUp)
                        {
                            isBoxFourPickedUp = true;
                        }
                        else isBoxFourPickedUp = false;
                    }
                    else if (boxFive.IsPlayerNextToObject(gracz1))
                    {
                        if (!isBoxOnePickedUp && !isBoxThreePickedUp && !isBoxTwoPickedUp && !isBoxFourPickedUp &&
                            !isBoxFivePickedUp)
                        {
                            isBoxFivePickedUp = true;
                        }
                        else isBoxFivePickedUp = false;
                    }


                    break;
            }
        }

        /// <summary>
        /// Metoda odpowiedzialna za puszczenie klawisza
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Metoda inicjalizacji pierwszego poziomu
        /// Metoda ta inicjalizuje parametry obiektów znajdujących się na poziomie(skrzynki, gracz, platformy, znaki działania, drzwi, podloga, strony działania) i dodaje je do niego
        /// </summary>
        private void LevelOneInit()
        {
            levelOne.Show();
            firstSolution.value = -2000;
            finalSolution.value = -2000;
            levelOneTimer.Enabled = true;

            gracz1.InitializePlayer(level: levelOne);

            levelOne.InitializeLevel(this);

            boxOne.InitializeObject(315, 100, Properties.Resources.Box1, 25, 25, levelOne, 1);
            boxTwo.InitializeObject(200, 100, Properties.Resources.Box2, 25, 25, levelOne, 2);
            boxThree.InitializeObject(435, 100, Properties.Resources.Box3, 25, 25, levelOne, 3);

            door.InitializeObject(720, 370, Properties.Resources.Drzwi4, 36, 180, levelOne, 4);
            firstOperator.InitializeObject(595, 480, Properties.Resources.Znak_plus, 40, 70, levelOne, 0);

            firstPlatform.InitializePlatform(platformX: 300, platformY: 450, platformWidth: 150,
                platformHeight: 10, isFloor: false, level: levelOne);
            floor.InitializePlatform(platformX: 10, platformY: 721, platformWidth: 0,
                platformHeight: 0,
                isFloor: true, level: levelOne);
            secondPlatform.InitializePlatform(platformX: 100, platformY: 450,
                platformWidth: 150, platformHeight: 70, isFloor: false, level: levelOne);

            leftEquationChecker.InitializePlatform(565, 545, 30, 10, false, levelOne);
            rightEquationChecker.InitializePlatform(635, 545, 30, 10, false, levelOne);
            leftEquationChecker.BackgroundImage = null;
            rightEquationChecker.BackgroundImage = null;
            leftEquationChecker.BackColor = Color.DarkOrange;
            rightEquationChecker.BackColor = Color.DarkOrange;
            leftEquationChecker.BringToFront();
            rightEquationChecker.BringToFront();
            rightEquationChecker.Image = null;
        }

        /// <summary>
        /// Metoda Inicjalizacji drugiego poziomu
        /// Analogicznie do inicjalizacji pierwszego poziomu
        /// </summary>
        private void LevelTwoInit()
        {
            levelTwo.Show();
            firstSolution.value = -2000;
            finalSolution.value = -2000;
            levelTwoTimer.Enabled = true;

            gracz1.InitializePlayer(level: levelTwo);

            levelTwo.InitializeLevel(this);

            boxOne.InitializeObject(620, 100, Properties.Resources.Box7, 25, 25, levelTwo, 7);
            boxTwo.InitializeObject(90, 400, Properties.Resources.Box3, 25, 25, levelTwo, 3);
            boxThree.InitializeObject(440, 300, Properties.Resources.Box5, 25, 25, levelTwo, 5);
            boxFour.InitializeObject(490, 300, Properties.Resources.Box4, 25, 25, levelTwo, 4);
            boxFive.InitializeObject(10, 300, Properties.Resources.Box9, 25, 25, levelTwo, 9);

            door.InitializeObject(720, 370, Properties.Resources.Drzwi9, 36, 180, levelTwo, 9);
            firstOperator.InitializeObject(135, 270, Properties.Resources.Znak_minus, 40, 70, levelTwo, 1);
            secondOperator.InitializeObject(205, 270, Properties.Resources.Znak_plus, 40, 70, levelTwo, 0);


            firstPlatform.InitializePlatform(platformX: 90, platformY: 340, platformWidth: 250,
                platformHeight: 20, isFloor: false, level: levelTwo);
            floor.InitializePlatform(platformX: 10, platformY: 721, platformWidth: 0,
                platformHeight: 0,
                isFloor: true, level: levelTwo);
            secondPlatform.InitializePlatform(platformX: 390, platformY: 450,
                platformWidth: 150, platformHeight: 20, isFloor: false, level: levelTwo);


            leftEquationChecker.InitializePlatform(100, 339, 30, 10, false, levelTwo);
            middleLeftEquationChecker.InitializePlatform(170, 339, 30, 10, false, levelTwo);
            rightEquationChecker.InitializePlatform(240, 339, 30, 10, false, levelTwo);


            leftEquationChecker.BackgroundImage = null;
            middleLeftEquationChecker.BackgroundImage = null;
            rightEquationChecker.BackgroundImage = null;
            middleRightEquationChecker.BackgroundImage = null;
            leftEquationChecker.BackColor = Color.DarkOrange;
            middleLeftEquationChecker.BackColor = Color.DarkOrange;
            rightEquationChecker.BackColor = Color.DarkOrange;
            middleRightEquationChecker.BackColor = Color.DarkOrange;

            leftEquationChecker.BringToFront();
            middleLeftEquationChecker.BringToFront();
            rightEquationChecker.BringToFront();
            middleRightEquationChecker.BringToFront();
        }

        /// <summary>
        /// Metoda Inicjalizacji trzeciego poziomu
        /// Analogicznie do inicjalizacji pierwszego poziomu
        /// </summary>
        private void LevelThreeInit()
        {
            levelThree.Show();
            firstSolution.value = -2000;
            finalSolution.value = -2000;

            levelThreeTimer.Enabled = true;

            gracz1.InitializePlayer(level: levelThree);

            levelThree.InitializeLevel(this);

            boxOne.InitializeObject(420, 100, Properties.Resources.Box4, 25, 25, levelThree, 4);
            boxTwo.InitializeObject(90, 400, Properties.Resources.Box5, 25, 25, levelThree, 5);
            boxThree.InitializeObject(440, 300, Properties.Resources.Box2, 25, 25, levelThree, 2);
            boxFour.InitializeObject(490, 300, Properties.Resources.Box1, 25, 25, levelThree, 1);
            boxFive.InitializeObject(10, 300, Properties.Resources.Box9, 25, 25, levelThree, 9);

            door.InitializeObject(720, 370, Properties.Resources.Drzwi18, 36, 180, levelThree, 18);
            firstOperator.InitializeObject(255, 230, Properties.Resources.Znak_mnoz, 40, 70, levelThree, 3);
            secondOperator.InitializeObject(325, 230, Properties.Resources.Znak_minus, 40, 70, levelThree, 1);


            firstPlatform.InitializePlatform(platformX: 550, platformY: 252, platformWidth: 190,
                platformHeight: 20, isFloor: false, level: levelThree);
            floor.InitializePlatform(platformX: 10, platformY: 721, platformWidth: 0,
                platformHeight: 0,
                isFloor: true, level: levelThree);
            secondPlatform.InitializePlatform(platformX: 60, platformY: 370,
                platformWidth: 60, platformHeight: 20, isFloor: false, level: levelThree);
            thirdPlatform.InitializePlatform(platformX: 200, platformY: 300,
                platformWidth: 300, platformHeight: 20, isFloor: false, level: levelThree);


            leftEquationChecker.InitializePlatform(220, 299, 30, 10, false, levelThree);
            middleLeftEquationChecker.InitializePlatform(290, 299, 30, 10, false, levelThree);
            rightEquationChecker.InitializePlatform(360, 299, 30, 10, false, levelThree);


            leftEquationChecker.BackgroundImage = null;
            middleLeftEquationChecker.BackgroundImage = null;
            rightEquationChecker.BackgroundImage = null;
            middleRightEquationChecker.BackgroundImage = null;
            leftEquationChecker.BackColor = Color.DarkOrange;
            middleLeftEquationChecker.BackColor = Color.DarkOrange;
            rightEquationChecker.BackColor = Color.DarkOrange;
            middleRightEquationChecker.BackColor = Color.DarkOrange;

            leftEquationChecker.BringToFront();
            middleLeftEquationChecker.BringToFront();
            rightEquationChecker.BringToFront();
            middleRightEquationChecker.BringToFront();
        }

        /// <summary>
        /// Metoda Inicjalizacji czwartego poziomu
        /// Analogicznie do inicjalizacji pierwszego poziomu
        /// </summary>
        private void LevelFourInit()
        {
            levelFour.Show();
            firstSolution.value = -2000;
            finalSolution.value = -2000;

            levelFourTimer.Enabled = true;

            gracz1.InitializePlayer(level: levelFour);

            levelFour.InitializeLevel(this);

            boxOne.InitializeObject(120, 380, Properties.Resources.Box6, 25, 25, levelFour, 6);
            boxTwo.InitializeObject(10, 380, Properties.Resources.Box2, 25, 25, levelFour, 2);
            boxThree.InitializeObject(240, 380, Properties.Resources.Box4, 25, 25, levelFour, 4);
            boxFour.InitializeObject(620, 380, Properties.Resources.Box8, 25, 25, levelFour, 8);
            boxFive.InitializeObject(600, 380, Properties.Resources.Box9, 25, 25, levelFour, 9);

            door.InitializeObject(720, 370, Properties.Resources.Drzwi7, 36, 180, levelFour, 7);
            firstOperator.InitializeObject(405, 410, Properties.Resources.Znak_dziel, 40, 70, levelFour, 2);
            secondOperator.InitializeObject(475, 410, Properties.Resources.Znak_plus, 40, 70, levelFour, 0);


            firstPlatform.InitializePlatform(platformX: 90, platformY: 390, platformWidth: 200,
                platformHeight: 20, isFloor: false, level: levelFour);
            floor.InitializePlatform(platformX: 10, platformY: 721, platformWidth: 0,
                platformHeight: 0, isFloor: true, level: levelFour);
            secondPlatform.InitializePlatform(platformX: 180, platformY: 90,
                platformWidth: 20, platformHeight: 300, isFloor: false, level: levelFour);
            thirdPlatform.InitializePlatform(platformX: 350, platformY: 480,
                platformWidth: 300, platformHeight: 20, isFloor: false, level: levelFour);


            leftEquationChecker.InitializePlatform(370, 479, 30, 10, false, levelFour);
            middleLeftEquationChecker.InitializePlatform(440, 479, 30, 10, false, levelFour);
            rightEquationChecker.InitializePlatform(510, 479, 30, 10, false, levelFour);


            leftEquationChecker.BackgroundImage = null;
            middleLeftEquationChecker.BackgroundImage = null;
            rightEquationChecker.BackgroundImage = null;
            middleRightEquationChecker.BackgroundImage = null;
            leftEquationChecker.BackColor = Color.DarkOrange;
            middleLeftEquationChecker.BackColor = Color.DarkOrange;
            rightEquationChecker.BackColor = Color.DarkOrange;
            middleRightEquationChecker.BackColor = Color.DarkOrange;

            leftEquationChecker.BringToFront();
            middleLeftEquationChecker.BringToFront();
            rightEquationChecker.BringToFront();
            middleRightEquationChecker.BringToFront();
        }

        /// <summary>
        /// Metoda Inicjalizacji piątego poziomu
        /// Analogicznie do inicjalizacji pierwszego poziomu
        /// </summary>
        private void LevelFiveInit()
        {
            levelFive.Show();
            firstSolution.value = -2000;
            finalSolution.value = -2000;

            levelFiveTimer.Enabled = true;

            gracz1.InitializePlayer(level: levelFive);

            levelFive.InitializeLevel(this);

            boxOne.InitializeObject(470, 100, Properties.Resources.Box6, 25, 25, levelFive, 6);
            boxTwo.InitializeObject(400, 100, Properties.Resources.Box3, 25, 25, levelFive, 3);
            boxThree.InitializeObject(260, 100, Properties.Resources.Box8, 25, 25, levelFive, 8);
            boxFour.InitializeObject(540, 100, Properties.Resources.Box4, 25, 25, levelFive, 4);
            boxFive.InitializeObject(190, 100, Properties.Resources.Box9, 25, 25, levelFive, 2);


            door.InitializeObject(720, 370, Properties.Resources.Drzwi20, 36, 180, levelFive, 20);
            firstOperator.InitializeObject(225, 330, Properties.Resources.Znak_mnoz, 40, 70, levelFive, 3);
            secondOperator.InitializeObject(505, 330, Properties.Resources.Znak_dziel, 40, 70, levelFive, 2);
            thirdOperator.InitializeObject(350, 280, Properties.Resources.Znak_plus, 40, 70, levelFive, 0);


            firstPlatform.InitializePlatform(platformX: 420, platformY: 400, platformWidth: 200,
                platformHeight: 20, isFloor: false, level: levelFive);
            floor.InitializePlatform(platformX: 10, platformY: 721, platformWidth: 0,
                platformHeight: 0,
                isFloor: true, level: levelFive);
            secondPlatform.InitializePlatform(platformX: 130, platformY: 400,
                platformWidth: 200, platformHeight: 20, isFloor: false, level: levelFive);
            thirdPlatform.InitializePlatform(platformX: 345, platformY: 350,
                platformWidth: 50, platformHeight: 20, isFloor: false, level: levelFive);


            leftEquationChecker.InitializePlatform(190, 405, 30, 10, false, levelFive);
            middleLeftEquationChecker.InitializePlatform(260, 405, 30, 10, false, levelFive);
            middleRightEquationChecker.InitializePlatform(470, 402, 30, 10, false, levelFive);
            rightEquationChecker.InitializePlatform(540, 402, 30, 10, false, levelFive);


            leftEquationChecker.BackgroundImage = null;
            middleLeftEquationChecker.BackgroundImage = null;
            rightEquationChecker.BackgroundImage = null;
            middleRightEquationChecker.BackgroundImage = null;
            leftEquationChecker.BackColor = Color.DarkOrange;
            middleLeftEquationChecker.BackColor = Color.DarkOrange;
            rightEquationChecker.BackColor = Color.DarkOrange;
            middleRightEquationChecker.BackColor = Color.DarkOrange;

            leftEquationChecker.BringToFront();
            middleLeftEquationChecker.BringToFront();
            rightEquationChecker.BringToFront();
            middleRightEquationChecker.BringToFront();
        }

        /// <summary>
        /// Metoda odpowiedzialna za sprawdzenie poprawności działania
        /// Domyślna wynik działania,gdy nie znajdują się na niej skrzynki wynosi -2000
        /// Wyniki są liczbami dodatnimi, dlatego gdy wynik jest poprawny warunek solution.value>0 jest niespełniony i działanie się nie wykonuje
        /// </summary>
        /// <param name="solution">Rozwiązanie</param>
        /// <param name="firstBox">Pierwsza Skrzynka</param>
        /// <param name="secondBox">Druga Skrzynka</param>
        /// <param name="sign">Znak Działania</param>
        /// <param name="leftChecker">Lewa Strona Równania</param>
        /// <param name="rightChecker">Prawa Strona Równania</param>
        private void CheckValue(InteractiveObject solution, InteractiveObject firstBox, InteractiveObject secondBox,
            InteractiveObject sign, InteractiveObject leftChecker, InteractiveObject rightChecker)
        {
            if (solution.value < 0)
            {
                solution.value = equation.EquationSolve(firstBox, secondBox, sign, leftChecker,
                    rightChecker);
            }
        }

        /// <summary>
        /// Metoda pokazująca tylko jeden poziom
        /// </summary>
        /// <param name="level">poziom do pokazania</param>
        private void ShowOneLevel(Level level)
        {
            levelSelect.Hide();
            levelOne.Hide();
            levelTwo.Hide();
            levelThree.Hide();
            levelFour.Hide();
            levelFive.Hide();
            level.Show();
            levelSelectShow = false;
        }
        /// <summary>
        /// Metoda wyłączająca timery
        /// </summary>
        private void DisableTimers()
        {
            levelOneTimer.Enabled = false;
            levelTwoTimer.Enabled = false;
            levelThreeTimer.Enabled = false;
            levelFourTimer.Enabled = false;
            levelFiveTimer.Enabled = false;
        }
    }
}