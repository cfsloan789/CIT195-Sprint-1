﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReachingIntoTheVague
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum RaceType
        {
            None,
            Human,
            Leafkind,
            Mutant,
            Mechano,
            Halfman
        }

        #endregion

        #region FIELDS

        private string _name;
        private int _playerLocationID;
        private int _age;
        private RaceType _race;


        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int playerLocationID
        {
            get { return _playerLocationID; }
            set { _playerLocationID = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }
        

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, RaceType race, int playerLocationID)
        {
            _name = name;
            _race = race;
            _playerLocationID = playerLocationID;

        }

        #endregion

        #region METHODS



        #endregion
    }
}
