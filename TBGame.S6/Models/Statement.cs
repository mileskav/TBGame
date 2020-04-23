using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame.Models
{
    public class Statement : GameItem
    {
        public enum UseActionType
        {
            OPENLOCATION
        }
        public UseActionType UseAction { get; set; }
        public Statement(int id, string name, int value, string description, int experiencePoints, string useMessage, UseActionType useAction)
            : base(id, name, value, description, experiencePoints, useMessage)
        {
        }

        public override string InformationString()
        {
            return $"{Name}: {Description}";
        }
    }
}
