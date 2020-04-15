using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame.Models
{
    public class MissionEngage : Mission
    {
        private int _id;
        private string _name;
        private string _description;
        private MissionStatus _status;
        private string _statusDetail;
        private int _experiencePoints;
        private List<NPC> _requiredNPCs;

        public List<NPC> RequiredNPCs
        {
            get { return _requiredNPCs; }
            set { _requiredNPCs = value; }
        }

        public MissionEngage()
        {

        }

        public MissionEngage(int id, string name, MissionStatus status, List<NPC> requiredNPCs)
            : base(id, name, status)
        {
            _id = id;
            _name = name;
            _status = status;
            _requiredNPCs = requiredNPCs;
        }

        public List<NPC> NPCsNotCompleted(List<NPC> NPCsEngaged)
        {
            List<NPC> NPCsToComplete = new List<NPC>();

            foreach (var requiredNPC in _requiredNPCs)
            {
                if (!NPCsEngaged.Any(l => l.Id == requiredNPC.Id))
                {
                    NPCsToComplete.Add(requiredNPC);
                }
            }

            return NPCsToComplete;
        }
    }
}
