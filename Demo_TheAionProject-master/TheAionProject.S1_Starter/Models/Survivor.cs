using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReachingIntoTheVague
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Survivor : Character
    {
        #region ENUMERABLES


        #endregion

        #region FIELDS

        private bool _isCool;
        private int _iq;
        private string _catchPhrase;

        #endregion
        
        #region PROPERTIES
        
        public bool IsCool
        {
            get { return _isCool; }
            set { _isCool = value; }
        }

        public int IQ
        {
            get { return _iq; }
            set { _iq = value; }
        }
        
        public string CatchPhrase
        {
            get { return _catchPhrase; }
            set { _catchPhrase = value; }
        }

        #endregion


        #region CONSTRUCTORS

        public Survivor()
        {

        }

        public Survivor(string name, RaceType race, int playerLocationID, bool isCool, int iq, string catchPhrase) : base(name, race, playerLocationID)
        {

            _isCool = isCool;
            _iq = IQ;
            _catchPhrase = CatchPhrase;

        }

        #endregion


        #region METHODS
        

        #endregion
    }
}
