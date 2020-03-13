using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame.Models
{
    public class Consumable : GameItem
    {
        public enum ConsumableType
        {
            Beverage,
            Food
        }

        public int HealthChange { get; set; }

        public Consumable(int id, string name, int value, string description, int healthChange,  int experiencePoints, string useMessage)
            : base(id, name, value, description, experiencePoints)
        {
            UseMessage = useMessage;
            HealthChange = healthChange;
        }

        public override string InformationString()
        {
            if (HealthChange != 0)
            {
                return $"{Name}: {Description}\nHealth: {HealthChange}";
            }
            else
            {
                return $"{Name}: {Description}";
            }
        }

    }
}
