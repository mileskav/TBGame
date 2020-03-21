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
        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "You've been hired at the Magnus Institute as an Archival Assistant. You're still not sure what " +
                "inspired you to apply, you've never been too interested in records, or the paranormal for that matter.",
            };
        }
        public static Map GameMap()
        {
            Map gameMap = new Map();

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 1,
                    Name = "The Magnus Institute",
                    Description = "The Magnus Institute is just a normal building. It’s a bit small for something that’s " +
                    "supposed to be an institute, but considering it’s for the paranormal that kind of makes sense. It’s " +
                    "been there since before you were born and something about it unsettles you, though you’re not quite " +
                    "sure what.",
                    Accessible = true,
                    Message = "You've been hired at the Magnus Institute as an Archival Assistant. You're still not sure what " +
                    "inspired you to apply, you've never been too interested in records, or the paranormal for that matter.",
                    ModifyExperience = 10
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 2,
                    Name = "Archives",
                    Description = "A subsection of the Magnus Institute located in the basement. This is where all " +
                    "statements are processed and looked into. There’s nothing about it that should scare you, but it’s " +
                    "even more unsettling than the building itself. At least the people here are nice.",
                    Accessible = true,
                    ModifyExperience = 10
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 3,
                    Name = "The Tunnels",
                    Description = "A series of tunnels built by Robert Smirke which connect the Magnus Institute to the " +
                    "remnants of the Millbank Prison. The tunnels twist and turn in different directions to a point where " +
                    "you’re almost constantly lost. There’s faded chalk on some of the walls. It almost reminds you of the " +
                    "movie Labyrinth.  ",
                    Accessible = false,
                    ModifyExperience = 30
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 4,
                    Name = "The Deeper Tunnels",
                    Description = "The tunnels become even more desolate as you move farther inside. It becomes darker " +
                    "and darker and the chalk lines on the walls become more preserved. There are stairs going down to an " +
                    "even lower level and as the chalk lines come to an abrupt stop you start to wonder if the person who " +
                    "left the chalk got out of here alive. ",
                    Accessible = false,
                    ModifyExperience = 30,
                    RequiredExperience = 60
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 5,
                    Name = "Old Fishmarket Close",
                    Description = "A long narrow road with a few different shops on it. It seems completely innocent during " +
                    "the day, but at night it fills you with the fear that something could come out of the dark at any time.",
                    Accessible = false,
                    ModifyExperience = 15
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 6,
                    Name = "Stockwell Butcher Shop",
                    Description = "The front looks like a normal butcher’s shop with meats dangling in the front window. " +
                    "However, once you enter the building it looks almost abandoned. That is, until you enter the back room " +
                    "which has a suspiciously placed table and a few lockers. You have a feeling that the table isn’t only " +
                    "used for animals. ",
                    Accessible = false,
                    ModifyExperience = 20,
                    RequiredExperience = 30
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 7,
                    Name = "Jazz Club",
                    Description = "Do you like jazz? Of course you do! It’s a perfectly normal jazz club! Of course, maybe " +
                    "you should bring some ear plugs for later. Things get a bit rowdy after a while. ",
                    Accessible = false,
                    ModifyExperience = 10
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 8,
                    Name = "Jane Prentiss' Apartment",
                    Description = "It’s just a regular apartment from what you can tell. It’s got doors, windows, and " +
                    "hallways just like any other apartment complex. But what’s that buzzing coming from above you?",
                    Accessible = false,
                    ModifyExperience = 20
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 9,
                    Name = "Jane Prentiss' Attic",
                    Description = "Oh, that’s where the buzzing was coming from. You can see a large black blob in the " +
                    "corner and it appears that the buzzing is coming from there. It doesn’t fill you with any sort of " +
                    "joy, but it does fill you with a morbid sense of curiosity. It’s almost as if it’s speaking to you. ",
                    Accessible = false,
                    ModifyExperience = 20,
                    RequiredExperience = 50
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 10,
                    Name = "Dalston Meat Plant",
                    Description = "Unfortunately, this slaughter house seems to go on forever. The hallways wind together " +
                    "and lead you to places you’re sure you’ve seen before. Oh, and don’t forget about the meat room. I’m " +
                    "sure there’s not any humans in there. ",
                    Accessible = false,
                    ModifyExperience = 25
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 11,
                    Name = "The Tundra",
                    Description = "Boats are fun, aren’t they? This one’s constantly surrounded by fog, though, so that’s " +
                    "a bit of a bummer. Also, its owner, Peter Lukas, isn’t the biggest fan of sea shanties. Be careful " +
                    "not to say anything that could get you in trouble. Actually, it’s best to say nothing at all. ",
                    Accessible = false,
                    ModifyExperience = 25
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 12,
                    Name = "Waltham Express Grill",
                    Description = "Known for its meats and meat by-products, this fun little restaurant was shut down due " +
                    "to an unfortunate cannibalistic event. It still seems like there’s someone - something, more likely - " +
                    "walking around inside of it. Conveniently, there’s an opened window on the side. You would probably " +
                    "prefer not to be eaten. ",
                    Accessible = false,
                    ModifyExperience = 25,
                    RequiredExperience = 30
                }
                );
            // set the initial location for the player
            gameMap.CurrentLocation = gameMap.Locations.FirstOrDefault(l => l.Id == 1);

            return gameMap;
        }
    }
}
