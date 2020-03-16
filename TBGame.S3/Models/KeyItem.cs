using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame.Models
{
    public class KeyItem : GameItem
    {
        #region ENUMS
        public enum UseActionType
        {
            OPENLOCATION,
            GIVENPC,
            DAMAGE
        }
        #endregion

        #region PROPERTIES
        public UseActionType UseAction { get; set; }
        #endregion

        #region CONSTRUCTORS
        public KeyItem(int id, string name, int value, string description, int experiencePoints, string useMessage, UseActionType useAction)
            : base(id, name, value, description, experiencePoints)
        {
            UseAction = useAction;
        }
        #endregion

        #region METHODS
        public override string InformationString()
        {
            return $"{Name}\nValue: {Value}";
        }
        #endregion
    }
}
