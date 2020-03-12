using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame.Models
{
    class Consumable : GameItem
    {
        #region ENUMS
        public enum ConsumableType
        {
            Beverage,
            Food
        }
        #endregion

        #region PROPERTIES
        public int EnergyChange { get; set; }
        #endregion

        #region CONSTRUCTORS
        public Consumable(int id, string name, int value, string description, int energyChange, string useMessage) 
            : base(id, name, value, description)
        {
            EnergyChange = energyChange;
        }
        #endregion

        #region METHODS
        public override string InformationString()
        {
            if (EnergyChange != 0)
            {
                return $"{Name}: {Description}\n Energy: {EnergyChange}";
            }
            else
            {
                return $"{Name}: {Description}";
            }
        }
        #endregion
    }
}
