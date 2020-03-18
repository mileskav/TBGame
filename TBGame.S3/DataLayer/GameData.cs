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
                LocationId = 0,
                Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(201), 1)
                }
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
        public static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }
        public static Map GameMap()
        {
            Map gameMap = new Map();

            gameMap.StandardGameItems = StandardGameItems();

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 1,
                    Name = "The Magnus Institute",
                    Description = "The Magnus Institute is just a normal building. It’s a bit small for something that’s " +
                    "supposed to be an institute, but considering it’s for the paranormal that kind of makes sense. It’s " +
                    "been here since before you were born and something about it unsettles you, though you’re not quite " +
                    "sure what.",
                    Accessible = true,
                    Message = "You've been hired at the Magnus Institute as an Archival Assistant. You're still not sure what " +
                    "inspired you to apply, you've never been too interested in records, or the paranormal for that matter.",
                    ModifyExperience = 10,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(203), 1),
                        new GameItemQuantity(GameItemById(003), 1)
                    }
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
                    ModifyExperience = 10,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(304), 1),
                        new GameItemQuantity(GameItemById(202), 1),
                        new GameItemQuantity(GameItemById(001), 2)
                    }
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
                    ModifyExperience = 30,
                    RequiredItemId = 102,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(005), 1),
                        new GameItemQuantity(GameItemById(006), 1)
                    }
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
                    RequiredExperience = 50,
                    RequiredItemId = 103,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(004), 1)
                    }
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
                    ModifyExperience = 15,
                    RequiredItemId = 201,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(106), 1),
                        new GameItemQuantity(GameItemById(206), 1)
                    }
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
                    RequiredItemId = 202
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
                    ModifyExperience = 10,
                    RequiredItemId = 203
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
                    ModifyExperience = 20,
                    RequiredItemId = 204,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(103), 1),
                        new GameItemQuantity(GameItemById(002), 1)
                    }
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
                    RequiredItemId = 106,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(105), 1)
                    }
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 10,
                    Name = "Dalston Meat Plant",
                    Description = "Unfortunately, this slaughter house seems to go on forever. The hallways wind together " +
                    "and lead you to places you’re sure you’ve seen before. Oh, and don’t forget about the meat room. I’m " +
                    "sure there’s not any humans in there.",
                    Accessible = false,
                    ModifyExperience = 25,
                    RequiredItemId = 205
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
                    ModifyExperience = 25,
                    RequiredItemId = 206,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(101), 1)
                    }
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
                    RequiredItemId = 207,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(205), 1)
                    }
                }
                );
            // set the initial location for the player
            gameMap.CurrentLocation = gameMap.Locations.FirstOrDefault(l => l.Id == 1);

            return gameMap;
        }
        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Consumable(001, "Coffee", 10, "A medium cup of lukewarm coffee.", 10, 5, "You drink the cup of coffee. +10 Health."),
                new Consumable(002, "Apple", 5, "A large apple of the red delicious variety.", -10, 5, "You start to eat the apple until- Hey! There's teeth in there! -10 Health."),
                new Consumable(003, "Apple", 5, "A smaller reddish honeycrisp apple.", 5, 5, "You eat the honeycrisp apple. +5 Health."),
                new Consumable(004, "Unfortunate Leftovers", 2, "It's trash food! Mysteriously fresh.", +2, -5, "You eat the discarded food. You're disgusting. +2 Health."),
                new Consumable(005, "Aged Notes", 1, "More trash. It reads \"He lingers. He looks. You won't see him coming.\"", -1, -5, "You eat the paper. It's dry and leaves you feeling like a lecture hall. -1 Health."),
                new Consumable(006, "Food Wrapper", 1, "A plastic wrapper that used to contain food of a sort.", -2, -5, "You eat the wrapper. Tastes like plastic! -2 Health"),
                new KeyItem(101, "Pack of Cigarettes", 10, "A half-empty box of Marlboro Red cigarettes.", 10, "You pull out a cigarette and hand it to the stranger.", KeyItem.UseActionType.GIVENPC),
                new KeyItem(102, "Tunnels Key", 0, "A key to the Magnus Archive Tunnels.", 10, "You unlock the trap door to the tunnels.", KeyItem.UseActionType.OPENLOCATION),
                new KeyItem(103, "Flashlight", 5, "A basic flashlight. It looks at least a few years old.", 5, "You turn on the flashlight.", KeyItem.UseActionType.OPENLOCATION),
                new KeyItem(104, "Airpods", 30, "A pair of wireless earbuds given to you by Elias. They feel cheap.", 20, "You wear the airpods.", KeyItem.UseActionType.OPENLOCATION),
                new KeyItem(105, "Wasp's Nest", 5, "Why did you take this? There's no honey in it, it's just a wasp's nest.", 15, "You stick your hand in the wasp's nest. The wasps swarm your hand and start stinging, killing you instantly.", KeyItem.UseActionType.DAMAGE),
                new KeyItem(106, "Attic Key", 5, "Jane Prentiss' attic key. Should you really be poking around up there?", 10, "You unlock the attic.", KeyItem.UseActionType.OPENLOCATION),
                new Statement(201, "Statement #0122204", 0, "Statement regarding an encounter on Old Fishmarket Close.", 5, "You read the statement. Old Fishmarket Close is now available.", Statement.UseActionType.OPENLOCATION),
                new Statement(202, "Statement #0081103", 0, "Statement regarding investigations during the summer of 2007.", 5, "You read the statement. Stockwell Butcher Shop is now available.", Statement.UseActionType.OPENLOCATION),
                new Statement(203, "Statement #0131103", 0, "Statement regarding a live musical performance in Soho, London.", 5, "You read the statement. The Jazz Club is now available.", Statement.UseActionType.OPENLOCATION),
                new Statement(204, "Statement #0142302", 0, "Statement regarding a wasp’s nest in their attic.", 5, "You read the statement. Jane Prentiss' Apartment is now available.", Statement.UseActionType.OPENLOCATION),
                new Statement(205, "Statement #0130111", 0, "Statement regarding their time working at an industrial abattoir.", 5, "You read the statement. Dalston Meat Plant is now available.", Statement.UseActionType.OPENLOCATION),
                new Statement(206, "Statement #0110201", 0, "Statement regarding their work on a container ship.", 5, "You read the statement. The Tundra is now available.", Statement.UseActionType.OPENLOCATION),
                new Statement(207, "Statement #0092010", 0, "Statement regarding explorations of an abandoned kebab shop.", 5, "You read the statement. Waltham Express Grill is now available.", Statement.UseActionType.OPENLOCATION),
                new Weapon(301, "Metal Pipe", 10, 10, 30, "A metal pipe with a slight bend to it. You hope that the stains are just rust.", 15),
                new Weapon(302, "Bolt Cutters", 10, 5, 15, "A pair of bolt cutters found in Waltham. Looking at them brings you memories of phantom pain.", 15),
                new Weapon(303, "Martin's Poetry", 10, 10, 15, "A notebook of poetry written by Martin. Aggressively mediocre!", 15),
                new Weapon(304, "Throwing Axe", 10, 15, 30, "It was \"remarkably easy to buy in central London.\" For you, it was remarkably easy to find in the institute.", 15)

            };
        }

    }
}
