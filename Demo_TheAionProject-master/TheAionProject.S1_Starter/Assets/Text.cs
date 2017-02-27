using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReachingIntoTheVague
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { " \"Reaching Into The Vague\"" };
        public static List<string> FooterText = new List<string>() { "Robotic Soul, 2017" };

        public static string SurvivalIntro()
        {
            string messageBoxText =
            //"You have been hired by the Norlon Corporation to participate " +
            //"in its latest endeavor, the Aion Project. Your mission is to " +
            //"test the limits of the new Aion Engine and report back to " +
            //"the Norlon Corporation.\n" +
            "You are descended from a survivor of the last 'Great Light', a cataclysm that " +
            "befell the world after its inhabitants became too powerful for their own good. " +
            "Many who survived were exposed to strange energies and unknown pathogens. " +
            "Some were changed then, others weren't affected until their offspring matured. " +
            "You may or may not have extraordinary traits and weaknesses. Your goal is to survive. \n" +
            " \n" +
            "\tYour struggle begins now.\n" +
            " \n" +
            "\t\t>> Press the Esc key to exit the game at any point.\n" +
            " \n" +
            "\t\t>> Your first task will be to establish your background.\n" +
            " \n" +
            "\t\t>> Press any key to begin the process.\n";

            return messageBoxText;
        }

        public static string CurrentLocationInfo()
        {
            string messageBoxText =
            "You regain conciousness on the outskirts of you now-smouldering village." +
            "You gather what few belongings you can manage and pay your respects to " +
            "those you could recognize, and mourn for those you find no trace of. \n" +
            " \n" +
            "\t>> Choose from the menu options to proceed.\n";

            return messageBoxText;
        }

        #region Initialize Survival Text

        public static string InitializeSurvivalIntro()
        {
            string messageBoxText =
                ">> Before you are thrust into the harsh world, let's establish your base data.\n" +
                " \n" +
                ">> You will be prompted for the required information. Please enter the information below.\n" +
                " \n" +
                "\t>> Press any key to begin.";

            return messageBoxText;
        }

        public static string InitializeSurvivalGetSurvivorName()
        {
            string messageBoxText =
                "Enter your name survivor.\n" +
                " \n" +
                "Please tell us what name others use to get your attention.";

            return messageBoxText;
        }

        public static string InitializeSurvivalGetSurvivorAge(Survivor gameSurvivor)
        {
            string messageBoxText =
                $"Very good then, we will call you {gameSurvivor.Name} on this journey.\n" +
                " \n" +
                "Enter your age below.\n" +
                " \n" +
                "Please use the standard Earth year as your reference.";

            return messageBoxText;
        }

        public static string InitializeSurvivalGetTravelerRace(Survivor gameSurvivor)
        {
            string messageBoxText =
                $"{gameSurvivor.Name}, it will be important for us to know your race on this journey.\n" +
                " \n" +
                "Enter your race below.\n" +
                " \n" +
                "Please use the universal race classifications below." +
                " \n";

            string raceList = null;

            foreach (Character.RaceType race in Enum.GetValues(typeof(Character.RaceType)))
            {
                if (race != Character.RaceType.None)
                {
                    raceList += $"\t{race}\n";
                }
            }

            messageBoxText += raceList;

            return messageBoxText;
        }

        public static string InitializeSurvivalGetSurvivorCool(Survivor gameSurvivor)
        {
            string messageBoxText =
                "How do other sentient beings perceive you? Would they consider you 'cool?'.\n" +
                " \n" +
                "Please press either Y or N.";

            return messageBoxText;
        }

        public static string InitializeSurvivalGetSurvivorIQ(Survivor gameSurvivor)
        {
            string messageBoxText =
                $"Very good then, {gameSurvivor.Name} how smart would you say you are?\n" +
                " \n" +
                "Enter your IQ below.\n" +
                " \n" +
                "Please use the standard scale as your reference.";

            return messageBoxText;
        }

        public static string InitializeSurvivalGetSurvivorCatchPhrase(Survivor gameSurvivor)
        {
            string messageBoxText =
                "What do you yell toward the heavens when something goes your way?\n" +
                " \n" +
                "Please tell us what your catch phrase is.";

            return messageBoxText;
        }

        public static string InitializeSurvivorEchoSurvivorInfo(Survivor gameSurvivor)
        {
            string messageBoxText =
                $"Very good then {gameSurvivor.Name}.\n" +
                " \n" +
                "It appears we have all the necessary data to begin your journey. You will find it" +
                " listed below.\n" +
                " \n" +
                $"\tTraveler Name: {gameSurvivor.Name}\n" +
                $"\tTraveler Age: {gameSurvivor.Age}\n" +
                $"\tTraveler Race: {gameSurvivor.Race}\n" +
                $"\tTraveler is Cool: {gameSurvivor.IsCool}\n" +
                $"\tTraveler IQ: {gameSurvivor.IQ}\n" +
                $"\tTraveler Catch Phrase: \"{gameSurvivor.CatchPhrase}\"\n" +
                " \n" +
                "Press any key to begin your journey.";

            return messageBoxText;
        }

        #endregion
    }
}
