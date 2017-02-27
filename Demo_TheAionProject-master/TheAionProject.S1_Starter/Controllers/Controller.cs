using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReachingIntoTheVague
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Survivor _gameSurvivor;
        private bool _playingGame;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gameSurvivor = new Survivor();
            _gameConsoleView = new ConsoleView(_gameSurvivor);
            _playingGame = true;

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            SurvivorAction SurvivorActionChoice = SurvivorAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Journey Intro", Text.SurvivalIntro(), ActionMenu.SurvivalIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the survivor
            // 
            InitializeMission();

            //
            // game loop
            //
            while (_playingGame)
            {
                _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(), ActionMenu.MainMenu, "");
                SurvivorActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);

                //
                // choose an action based on the user's menu choice
                //
                switch (SurvivorActionChoice)
                {
                    case SurvivorAction.None:
                        break;

                    case SurvivorAction.SurvivorInfo:
                        _gameConsoleView.DisplaySurvivorInfo();
                        break;

                    case SurvivorAction.SurvivorPhrase:
                        _gameConsoleView.DisplayGamePlayScreen("Survivor Update - Catch Phrase", 
                        "What do you yell toward the heavens when something goes your way?\n" +
                        " \n" +
                        "Please tell us what your catch phrase is.", 
                        ActionMenu.SurvivalIntro, "");
                        _gameConsoleView.DisplayInputBoxPrompt($"What is your new catch phrase?: ");
                        _gameSurvivor.CatchPhrase = _gameConsoleView.GetString();

                        break;

                    case SurvivorAction.Exit:
                        _playingGame = false;
                        break;

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }


        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializeMission()
        {
            Survivor survivor = _gameConsoleView.GetInitialSurvivorInfo();

            _gameSurvivor.Name = survivor.Name;
            _gameSurvivor.Age = survivor.Age;
            _gameSurvivor.Race = survivor.Race;
            _gameSurvivor.CatchPhrase = survivor.CatchPhrase;
            _gameSurvivor.IQ = survivor.IQ;
            _gameSurvivor.IsCool = survivor.IsCool;
        }

        //
        //This is the old initilaization of the character
        //
        //private void InitializeSurvival()
        //{
        //    //
        //    // intro
        //    //
        //    _gameConsoleView.DisplayGamePlayScreen("Survival Initialization", Text.InitializeSurvivalIntro(), ActionMenu.SurvivalIntro, "");
        //    _gameConsoleView.GetContinueKey();

        //    //
        //    // get traveler's name
        //    //
        //    _gameConsoleView.DisplayGamePlayScreen("Survival Initialization - Name", Text.InitializeSurvivalGetSurvivorName(), ActionMenu.SurvivalIntro, "");
        //    _gameConsoleView.DisplayInputBoxPrompt("Enter your name: ");
        //    _gameSurvivor.Name = _gameConsoleView.GetString();

        //    //
        //    // get traveler's age
        //    //
        //    _gameConsoleView.DisplayGamePlayScreen("Survival Initialization - Age", Text.InitializeSurvivalGetSurvivorAge(_gameSurvivor), ActionMenu.SurvivalIntro, "");
        //    _gameConsoleView.DisplayInputBoxPrompt($"Enter your age {_gameSurvivor.Name}: ");
        //    _gameSurvivor.Age = _gameConsoleView.GetInteger();

        //    //
        //    // get traveler's race
        //    //
        //    _gameConsoleView.DisplayGamePlayScreen("Survival Initialization - Race", Text.InitializeSurvivalGetTravelerRace(_gameSurvivor), ActionMenu.SurvivalIntro, "");
        //    _gameConsoleView.DisplayInputBoxPrompt($"Enter your race {_gameSurvivor.Name}: ");
        //    _gameSurvivor.Race = _gameConsoleView.GetRace();

        //    //
        //    // get traveler's coolness
        //    //
        //    _gameConsoleView.DisplayGamePlayScreen("Survival Initialization - Are You Cool?", Text.InitializeSurvivalGetSurvivorCool(_gameSurvivor), ActionMenu.SurvivalIntro, "");
        //    _gameConsoleView.DisplayInputBoxPrompt($"{_gameSurvivor.Name}, are you cool?: ");
        //    _gameSurvivor.IsCool = _gameConsoleView.GetCool();

        //    //
        //    // get traveler's coolness
        //    //
        //    _gameConsoleView.DisplayGamePlayScreen("Survival Initialization - IQ", Text.InitializeSurvivalGetSurvivorIQ(_gameSurvivor), ActionMenu.SurvivalIntro, "");
        //    _gameConsoleView.DisplayInputBoxPrompt($"Enter your IQ {_gameSurvivor.Name}:");
        //    _gameSurvivor.IQ = _gameConsoleView.GetInteger();

        //    //
        //    // get traveler's name
        //    //
        //    _gameConsoleView.DisplayGamePlayScreen("Survival Initialization - Name", Text.InitializeSurvivalGetSurvivorCatchPhrase(_gameSurvivor), ActionMenu.SurvivalIntro, "");
        //    _gameConsoleView.DisplayInputBoxPrompt("Enter your catch phrase: ");
        //    _gameSurvivor.CatchPhrase = _gameConsoleView.GetString();

        //    //
        //    // echo the traveler's info
        //    //
        //    _gameConsoleView.DisplayGamePlayScreen("Survival Initialization - Complete", Text.InitializeSurvivorEchoSurvivorInfo(_gameSurvivor), ActionMenu.SurvivalIntro, "");
        //    _gameConsoleView.GetContinueKey();
        //}

        #endregion
    }
}
