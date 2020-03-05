using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBGame.Models;

namespace TBGame.Models
{
    public abstract class Character
    {
        #region ENUMS 
        public enum Energy
        {
            Energized,
            Average,
            Tired,
            Exhausted
        }
        #endregion

        #region FIELDS
        protected int _id;
        protected string _name;
        protected int _locationId;
        protected Energy _energy;
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

        public Energy EnergyLevel
        {
            get { return _energy; }
            set { _energy = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public Character()
        {

        }

        public Character(string name, int id, int locationId, Energy energy)
        {
            _name = name;
            _id = id;
            _locationId = locationId;
            _energy = energy;
        }
        #endregion

        #region METHODS

        public virtual string Greeting()
        {
            return $"How's it going? You remember me, right?";
        }
        public abstract bool isRemembered();
        #endregion
    }
}
