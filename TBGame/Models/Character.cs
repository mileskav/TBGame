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
        public enum Entity
        {
            Buried,
            Corruption,
            Dark,
            Desolation,
            End,
            Eye,
            Flesh,
            Hunt,
            Lonely,
            Slaughter,
            Spiral,
            Stranger,
            Vast,
            Web
        }
        #endregion

        #region FIELDS
        protected int _id;
        protected string _name;
        protected int _locationId;
        protected Entity _entity;
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

        public Entity ControllingEntity
        {
            get { return _entity; }
            set { _entity = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public Character()
        {

        }

        public Character(string name, int id, int locationId, Entity entity)
        {
            _name = name;
            _id = id;
            _locationId = locationId;
            _entity = entity;
        }
        #endregion

        #region METHODS

        public virtual string Greeting()
        {
            return $"Oh. You're from the institute, aren't you?";
        }
        
        public abstract bool HasStatement();
        #endregion
    }
}
