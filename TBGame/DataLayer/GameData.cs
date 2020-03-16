using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBGame.Models;

namespace TBGame.DataLayer
{
    class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Nathan",
                ControllingEntity = Character.Entity.Stranger,
                Health = 100,
                ExperiencePoints = 0,
                LocationId = 0
            };
        }
        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "You've been hired at the Magnus Institute as an Archival Assistant. You're still not sure what " +
                "inspired you to apply, you've never been too interested in records, or the paranormal for that matter.",
            };
        }
    }
}
