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
        private int _health;
        private int _experiencePoints;
        #endregion

        #region PROPERTIES
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }
        #endregion

        #region METHODS

        public override string Greeting()
        {
            return $"Hi, my name is {Name} and I am an avatar of the {ControllingEntity}.";
        }
        public override bool HasStatement()
        {
            return false;
        }
        #endregion
    }
}
