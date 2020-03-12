using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame.Models
{
    /// <summary>
    /// player class
    /// </summary>
    public class Player : Character
    {
        #region FIELDS
        private int _health;
        private int _experiencePoints;
        private List<Location> _locationsVisited;

        #endregion

        #region PROPERTIES
        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;

                if (_health > 100)
                {
                    _health = 100;
                }
                else if (_health <= 0)
                {
                    _health = 100;
                }

                OnPropertyChanged(nameof(Health));
            }
        }
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            }
        }
        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _locationsVisited = new List<Location>();
        }

        #endregion

        #region METHODS

        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }

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
