﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReachingIntoTheVague
{
    public static class ActionMenu
    {
        public static Menu MissionIntro = new Menu()
        {
            MenuName = "MissionIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, TravelerAction>()
                    {
                        { ' ', TravelerAction.None }
                    }
        };

        public static Menu InitializeMission = new Menu()
        {
            MenuName = "InitializeMission",
            MenuTitle = "Initialize Mission",
            MenuChoices = new Dictionary<char, TravelerAction>()
                {
                    { '1', TravelerAction.Exit }
                }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, TravelerAction>()
                {
                    { '1', TravelerAction.TravelerInfo },
                    { '2', TravelerAction.Exit }
                }
        };

        //public static Menu ManageTraveler = new Menu()
        //{
        //    MenuName = "ManageTraveler",
        //    MenuTitle = "Manage Traveler",
        //    MenuChoices = new Dictionary<char, TravelerAction>()
        //            {
        //                TravelerAction.MissionSetup,
        //                TravelerAction.TravelerInfo,
        //                TravelerAction.Exit
        //            }
        //};
    }
}
