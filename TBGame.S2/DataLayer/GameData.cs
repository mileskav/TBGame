using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBGame.Models;

namespace TBGame.DataLayer
{
    /// <summary>
    /// static class to store the game data set
    /// </summary>
    public static class GameData
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

        //todo - change locations
        public static Map GameMap()
        {
            Map gameMap = new Map();

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 1,
                    Name = "The Magnus Institute",
                    //todo - description
                    Description = "a",
                    Accessible = true,
                    //todo - message
                    Message = "",
                    ModifyExperience = 10
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 2,
                    Name = "Archives",
                    //todo - description
                    Description = "a",
                    Accessible = true,
                    ModifyExperience = 10
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 3,
                    Name = "The Tunnels",
                    //todo - description
                    Description = "a",
                    Accessible = false,
                    ModifyExperience = 30
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 4,
                    Name = "Library",
                    //todo - description
                    Description = "a",
                    Accessible = false,
                    ModifyExperience = 10
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 5,
                    Name = "Old Fishmarket Close",
                    //todo - description
                    Description = "a",
                    Accessible = false,
                    ModifyExperience = 15
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 6,
                    Name = "Stockwell Butcher Shop",
                    //todo - description
                    Description = "a",
                    Accessible = false,
                    ModifyExperience = 20
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 7,
                    //todo - look up name
                    Name = "Jazz Club",
                    //todo - description
                    Description = "a",
                    Accessible = false,
                    ModifyExperience = 10
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 8,
                    Name = "Jane Prentiss' Apartment",
                    //todo - description
                    Description = "a",
                    Accessible = false,
                    ModifyExperience = 20
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 9,
                    Name = "Dalston Meat Plant",
                    //todo - description
                    Description = "a",
                    Accessible = false,
                    ModifyExperience = 25
                }
                );
            // set the initial location for the player
            gameMap.CurrentLocation = gameMap.Locations.FirstOrDefault(l => l.Id == 1);

            return gameMap;
        }
    }
}
