using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame.Models
{
    public abstract class NPC : Character
    {
        public string Description { get; set; }
        public string Information
        {
            get
            {
                return InformationText();
            }
            set
            {

            }
        }

        public NPC()
        {

        }

        public NPC(int id, string name, Entity entity, string description) : base(name, entity, id)
        {
            Id = id;
            Name = name;
            ControllingEntity = entity;
            Description = description;
        }

        protected abstract string InformationText();
        public override bool HasStatement() { return true; }
    }
}
