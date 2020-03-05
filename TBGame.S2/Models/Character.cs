using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame.Models
{
    /// <summary>
    /// base class for all game characters
    /// </summary>
    public abstract class Character : ObservableObject
    {
        #region ENUMERABLES

        public enum Energy
        {
            Energized,
            Average,
            Tired,
            Exhausted
        }

        #endregion

        #region FIELDS

        protected int _id; // must be a unique value for each object
        protected string _name;
        protected int _locationId;
        protected int _age;
        protected Energy _energyLevel;

        #endregion

        #region PROPERTIES

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public Energy EnergyLevel
        {
            get { return _energyLevel; }
            set { _energyLevel = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, Energy energy, int locationId)
        {
            _name = name;
            _energyLevel = energy;
            _locationId = locationId;
        }

        #endregion

        #region METHODS

        public virtual string Greeting()
        {
            return "How's it going? You remember me, right?";
        }
        public abstract bool IsRemembered();

        #endregion
    }
}
