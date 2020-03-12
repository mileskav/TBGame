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
    }
}
