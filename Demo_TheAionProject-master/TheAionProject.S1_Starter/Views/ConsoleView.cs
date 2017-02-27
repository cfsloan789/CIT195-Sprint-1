using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReachingIntoTheVague
{
    public class ConsoleView
    {
        #region FIELDS

        //
        // declare a Survivor object for the ConsoleView object to use
        //
        Survivor _gameSurvivor;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Survivor gameSurvivor)
        {
            _gameSurvivor = gameSurvivor;

            InitializeDisplay();
        }

        #endregion

        #region METHODS

        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public SurvivorAction GetActionMenuChoice(Menu menu)
        {
            SurvivorAction choosenAction = SurvivorAction.None;

            ConsoleKeyInfo keyPressedInfo = Console.ReadKey();
            char keyPressed = keyPressedInfo.KeyChar;
            choosenAction = menu.MenuChoices[keyPressed];

            return choosenAction;
        }


        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }
        
        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>


        public bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                    {
                        validResponse = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                        DisplayInputBoxPrompt(prompt);
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            return true;
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        /// //I can't get this to validate correctly but it works still so I'm confused
        /// 
        public Character.RaceType GetRace()
        {
            Character.RaceType raceTypeTemp = Character.RaceType.None;
            Character.RaceType raceType = Character.RaceType.Human;
            string raceInput = Console.ReadLine();
            if(Enum.IsDefined(typeof(Character.RaceType), raceInput))
            {
                raceTypeTemp = (Character.RaceType)Enum.Parse(typeof(Character.RaceType), raceInput);
                if (raceTypeTemp == Character.RaceType.None)
                {
                    return raceType;
                }
                else if (raceTypeTemp != Character.RaceType.None)
                {
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage($"You must enter \"Human\", \"Leafkind\", \"Mutant\", \"Mechano\", or \"Halfman\". Please try again.");
                        DisplayInputBoxPrompt("");
                    }
                }
            }

            //Enum.TryParse<Character.RaceType>(Console.ReadLine(), out raceType);

            return raceType;
        }

        public bool GetCool()
        {
            bool coolio = false;
            int keyCheck = 0;
            
            while (keyCheck < 1)
            {
                ConsoleKeyInfo temp1;
                temp1 = Console.ReadKey();
                if (temp1.Key == ConsoleKey.Y)
                {
                    coolio = true;
                    return coolio;

                    keyCheck++;
                }
                else if (temp1.Key == ConsoleKey.N)
                {
                    coolio = false;
                    return coolio;

                    keyCheck++;
                }
                else {
                    Console.WriteLine("\t>>That wasn't cool, please press a valid key.");
                }
            }

            return coolio;
        }


        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySpashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 35);
            //Console.WriteLine(tabSpace + @" _____ _              ___  _               ______          _           _   ");
            //Console.WriteLine(tabSpace + @"|_   _| |            / _ \(_)              | ___ \        (_)         | |  ");
            //Console.WriteLine(tabSpace + @"  | | | |__   ___   / /_\ \_  ___  _ __    | |_/ _ __ ___  _  ___  ___| |_ ");
            //Console.WriteLine(tabSpace + @"  | | | '_ \ / _ \  |  _  | |/ _ \| '_ \   |  __| '__/ _ \| |/ _ \/ __| __|");
            //Console.WriteLine(tabSpace + @"  | | | | | |  __/  | | | | | (_) | | | |  | |  | | | (_) | |  __| (__| |_ ");
            //Console.WriteLine(tabSpace + @"  \_/ |_| |_|\___|  \_| |_|_|\___/|_| |_|  \_|  |_|  \___/| |\___|\___|\__|");
            //Console.WriteLine(tabSpace + @"                                                         _/ |              ");
            //Console.WriteLine(tabSpace + @"                                                        |__/               ");

            //Console.WriteLine(tabSpace + @"  _______  __   __  _______        __   __  _______  _______  __   __  _______ ");
            //Console.WriteLine(tabSpace + @" |       ||  | |  ||       |      |  | |  ||   _   ||       ||  | |  ||       |");
            //Console.WriteLine(tabSpace + @" |_     _||  |_|  ||    ___|      |  | |  ||  |_|  ||    ___||  | |  ||    ___|");
            //Console.WriteLine(tabSpace + @"   |   |  |       ||   |___       |   V   ||       ||   | __ |  |_|  ||   |___ ");
            //Console.WriteLine(tabSpace + @"   |   |  |       ||    ___|      |       ||       ||   ||  ||       ||    ___|");
            //Console.WriteLine(tabSpace + @"   |   |  |   _   ||   |___        |     | |   _   ||   |_| ||       ||   |___ ");
            //Console.WriteLine(tabSpace + @"   |___|  |__| |__||_______|        |___|  |__| |__||_______||_______||_______|");

            Console.WriteLine(tabSpace + @"    ____                  __    _                _       __           __  __            _    __                     ");
            Console.WriteLine(tabSpace + @"   / __ \___  ____ ______/ /_  (_)___  ____ _   (_)___  / /_____     / /_/ /_  ___     | |  / /___ _____ ___  _____ ");
            Console.WriteLine(tabSpace + @"  / /_/ / _ \/ __ `/ ___/ __ \/ / __ \/ __ `/  / / __ \/ __/ __ \   / __/ __ \/ _ \    | | / / __ `/ __ `/ / / / _ \");
            Console.WriteLine(tabSpace + @" / _, _/  __/ /_/ / /__/ / / / / / / / /_/ /  / / / / / /_/ /_/ /  / /_/ / / /  __/    | |/ / /_/ / /_/ / /_/ /  __/");
            Console.WriteLine(tabSpace + @"/_/ |_|\___/\__,_/\___/_/ /_/_/_/ /_/\__, /  /_/_/ /_/\__/\____/   \__/_/ /_/\___/     |___/\__,_/\__, /\__,_/\___/ ");
            Console.WriteLine(tabSpace + @"                                    /____/                                                       /____/             ");


            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "The Vague";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, SurvivorAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != SurvivorAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }


        public void DisplaySurvivorInfo()
        {
            DisplayGamePlayScreen("Survivor Information", Text.InitializeSurvivorEchoSurvivorInfo(_gameSurvivor), ActionMenu.SurvivalIntro, "");
            GetContinueKey();
        }

        public Survivor GetInitialSurvivorInfo()
        {
            Survivor survivor = new Survivor();

            //
            // intro
            //
            DisplayGamePlayScreen("Survivor Creation", Text.InitializeSurvivalIntro(), ActionMenu.SurvivalIntro, "");
            GetContinueKey();

            //
            // get survivor's name
            //
            DisplayGamePlayScreen("Survivor Creation - Name", Text.InitializeSurvivalGetSurvivorName(), ActionMenu.SurvivalIntro, "");
            DisplayInputBoxPrompt("Enter your name: ");
            survivor.Name = GetString();

            //
            // get survivor's age
            //
            DisplayGamePlayScreen("Survivor Creation - Age", Text.InitializeSurvivalGetSurvivorAge(survivor), ActionMenu.SurvivalIntro, "");
            int gameSurvivorAge;

            GetInteger($"Enter your age {survivor.Name}: ", 0, 1000000, out gameSurvivorAge);
            survivor.Age = gameSurvivorAge;

            //
            // get survivor's race
            //
            DisplayGamePlayScreen("Survivor Creation - Race", Text.InitializeSurvivalGetTravelerRace(survivor), ActionMenu.SurvivalIntro, "");
            DisplayInputBoxPrompt($"Enter your race {survivor.Name}: ");
            survivor.Race = GetRace();

            //
            // get survivor's Cool
            //
            DisplayGamePlayScreen("Survivor Creation - Cool", Text.InitializeSurvivalGetSurvivorCool(survivor), ActionMenu.SurvivalIntro, "");
            DisplayInputBoxPrompt($"Is your Survivor cool, {survivor.Name}?: ");
            survivor.IsCool = GetCool();

            //
            // get survivor's IQ
            //
            DisplayGamePlayScreen("Survivor Creation - IQ", Text.InitializeSurvivalGetSurvivorIQ(survivor), ActionMenu.SurvivalIntro, "");
            int gameSurvivorIQ;
            GetInteger($"Enter your IQ {survivor.Name}: ", 0, 250, out gameSurvivorIQ);
            survivor.IQ = gameSurvivorIQ;

            //
            // get survivor's Catch Phrase
            //
            DisplayGamePlayScreen("Survivor Creation - Catch Phrase", Text.InitializeSurvivalGetSurvivorCatchPhrase(survivor), ActionMenu.SurvivalIntro, "");
            DisplayInputBoxPrompt($"What is your catch phrase, {survivor.Name}?: ");
            survivor.CatchPhrase = GetString();

            //
            // echo the survivor's info
            //
            DisplayGamePlayScreen("Survivor Creation - Complete", Text.InitializeSurvivorEchoSurvivorInfo(survivor), ActionMenu.SurvivalIntro, "");
            GetContinueKey();

            return survivor;
        }

        #endregion
    }
}
