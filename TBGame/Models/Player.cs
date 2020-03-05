using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame.Models
{
    public class Player : Character
    {
        #region FIELDS
        private int _memories;
        private int _currentMem;
        #endregion

        #region PROPERTIES
        public int Memories
        {
            get { return _memories; }
            set { _memories = value; }
        }
        public int CurrentMem
        {
            get { return _currentMem; }
            set { _currentMem = value; }
        }

        #endregion

        #region METHODS

        public override string Greeting()
        {
            return $"Hi, my name is {Name} and I am feeling {EnergyLevel}.";
        }
        public override bool isRemembered()
        {
            return false;
        }
        #endregion
    }
}
