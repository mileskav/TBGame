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

        private int _memories;
        private List<Location> _locationsVisited;

        #endregion

        #region PROPERTIES

        public int Memories
        {
            get { return _memories; }
            set
            {
                _memories = value;
                OnPropertyChanged(nameof(Memories));
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
            return $"Hi, my name is {Name} and I am feeling {EnergyLevel}.";
        }
        public override bool IsRemembered()
        {
            return false;
        }

        #endregion

    }
}
