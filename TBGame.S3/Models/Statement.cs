using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame.Models
{
    public class Statement : GameItem
    {
        public bool OpensLocation { get; set; }

        public Statement(int id, string name, int value, string description, int experiencePoints, string useMessage, bool opensLocation)
            : base(id, name, value, description, experiencePoints, useMessage)
        {
            OpensLocation = opensLocation;
        }

        public override string InformationString()
        {
            return $"{Name}: {Description}";
        }
    }
}
