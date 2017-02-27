using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReachingIntoTheVague
{
    public static class ActionMenu
    {
        public static Menu SurvivalIntro = new Menu()
        {
            MenuName = "SurvivalIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, SurvivorAction>()
                    {
                        { ' ', SurvivorAction.None }
                    }
        };

        public static Menu InitializeSurvival = new Menu()
        {
            MenuName = "InitializeSurvival",
            MenuTitle = "Initialize Survival",
            MenuChoices = new Dictionary<char, SurvivorAction>()
                {
                    { '1', SurvivorAction.Exit }
                }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, SurvivorAction>()
                {
                    { '1', SurvivorAction.SurvivorInfo },
                    { '2', SurvivorAction.Exit },
                    { '3', SurvivorAction.SurvivorPhrase }
                }
        };

        //public static Menu ManageTraveler = new Menu()
        //{
        //    MenuName = "ManageTraveler",
        //    MenuTitle = "Manage Survivor",
        //    MenuChoices = new Dictionary<char, SurvivorAction>()
        //            {
        //                SurvivorAction.JourneySetup,
        //                SurvivorAction.SurvivorInfo,
        //                SurvivorAction.Exit
        //            }
        //};
    }
}
