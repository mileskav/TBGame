using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame.Models
{
    /// <summary>
    /// class for the game map locations
    /// </summary>
    public class Location
    {
        #region FIELDS

        private int _id;
        private string _name;
        private string _description;
        private bool _accessible;
        private int _requiredExperience;
        private int _modifyExperience;
        private string _message;
        private int _modifyHealth;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool Accessible
        {
            get { return _accessible; }
            set { _accessible = value; }
        }

        public int ModifyExperience
        {
            get { return _modifyExperience; }
            set { _modifyExperience = value; }
        }
        public int RequiredExperience
        {
            get { return _requiredExperience; }
            set { _requiredExperience = value; }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public int ModifyHealth
        {
            get { return _modifyHealth; }
            set { _modifyHealth = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Location()
        {

        }

        #endregion

        #region METHODS

        public override string ToString()
        {
            return _name;
        }

        #endregion
    }
}