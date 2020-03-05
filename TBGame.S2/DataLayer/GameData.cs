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
                Name = "Alex",
                Age = 22,
                EnergyLevel = Character.Energy.Average,
                Memories = 0,
                LocationId = 0
            };
        }

        public static Map GameMap()
        {
            Map gameMap = new Map();

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 1,
                    Name = "Your Apartment",
                    Description = "Your studio apartment, usually clean, is currently a complete mess. Dishes are piled up " +
                    "on the kitchen counter, and the pale blue vase that used to hold a few small sunflowers now holds only " +
                    "wilted stems. Books of all kinds are scattered on your bedside table, as well as on your bed - each one an " +
                    "attempt at forcing yourself back into sleep. The only thing that remains organized is your clothing rack " +
                    "in the corner, as you haven't touched more than two outfits in the last week.",
                    Accessible = true,
                    Message = "It is 2 AM. You find yourself awake in your apartment, alerted by the traffic outside."
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 2,
                    Name = "Recurring Dream",
                    Description = "A familiar sensation hits you as you find yourself in the same dream you've been having " +
                    "on and off for a while. A thick fog causes this area to feel empty except for yourself and two mahogany " +
                    "arm chairs. As you wonder who the second chair could be for, you notice a note on the ground that reads " +
                    "\"THE ANSWER\" in messy handwriting - it's not yours. Suddenly, the fog dissipates slightly to reveal a " +
                    "set of glass doors in front of you.",
                    Accessible = true,
                    ModifyMemoryCount = 1
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 3,
                    Name = "Sunflower Field",
                    Description = "You open your eyes to sunflowers taller than you are. While many face toward the sun, " +
                    "you notice the closest two facing up at you instead. You find yourself staring at them for a while before " +
                    "snapping your head back up upon hearing someone shout, \"Hello? Is someone there?\", followed by plants " +
                    "rustling. It sounds as if the voice is coming from a farmhouse just barely out of sight over the flowers. ",
                    Accessible = false,
                    ModifyMemoryCount = 1,
                    RequiredMemoryCount = 1
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 4,
                    Name = "Old Farmhouse",
                    Description = "You make your way out of the sunflower field and find yourself in front of the farmhouse. A cup " +
                    "of coffee sits on a table by the front door, as a haze in the shape of a person stands at the porch steps. " +
                    "\"You must've been the one I heard in the fields, huh?\", they say with a slight drawl. The house looks as if it " +
                    "hasn't been well maintained, as paint flakes off of the house and the wooden planks of the porch creak when the " +
                    "figure shifts their weight from one leg to the other.",
                    Accessible = false,
                    ModifyMemoryCount = 1,
                    RequiredMemoryCount = 2
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 5,
                    Name = "Matilda's Palette - Front",
                    Description = "Matilda's Palette is Hillview's sole art store as well as your place of employment, with walls " +
                    "lined with shelves of canvas rolls, fabrics, and various paints and drawing tools. You recognize your most " +
                    "frequented section of the store when you're not working: the watercolor kits. A less materialized version of " +
                    "Matilda, the store's owner, greets you as you step inside before asking you to stock some of the back " +
                    "shelves that have been cleared by today's sale.",
                    Accessible = false,
                    ModifyMemoryCount = 1,
                    RequiredMemoryCount = 1
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 6,
                    Name = "Matilda's Palette - Back",
                    Description = "You walk further through the store, passing by canvas frames and wooden easels. You notice different " +
                    "looms and craft threads, knitting needles and balls of yarn. Along the back wall is a large cart piled with " +
                    "store inventory that hasn't yet been put out. You also notice the locked back door alongside the stock cart, where " +
                    "deliveries are often made from.",
                    Accessible = false,
                    ModifyMemoryCount = 1,
                    RequiredMemoryCount = 2
                }
                );
            gameMap.Locations.Add
                (new Location()
                {
                    Id = 7,
                    Name = "Alley",
                    Description = "You unlock the back door to Matilda's and find yourself in the alley behind the art store. " +
                    "Empty trash cans line the wall and a small notebook has been placed atop one of the trash can lids. Some " +
                    "children across the street are drawing on the sidewalk with chalk, having already 'conquered' the back alley" +
                    "with drawings of smiley faces and different animals.",
                    Accessible = false,
                    ModifyMemoryCount = 1,
                    RequiredMemoryCount = 3
                });
            gameMap.Locations.Add
                (new Location()
                {
                    Id = 8,
                    Name = "Parking Lot",
                    Description = "Softly lit by street lamps and the sunset, the parking lot is nearly empty. It's closing " +
                    "time at Matilda's Palette as a few remaining customers walk out of the store back to their cars. Your " +
                    "dark blue car is parked along the right side of the parking lot, near the back.",
                    Accessible = false,
                    ModifyMemoryCount = 1,
                    RequiredMemoryCount = 3
                });
            gameMap.Locations.Add
                (new Location()
                {
                    Id = 9,
                    Name = "Charlie's Apartment",
                    Description = "You walk into your friend Charlie's apartment. While bigger than your own, their apartment " +
                    "is also much more organized. Charlie - your memory of them much clearer than of most people - leans on the " +
                    "arm of their couch as they brush a wig pinned to a styrofoam mannequin head. Their television quietly " +
                    "plays reruns of a reality show you hadn't heard of. ",
                    Accessible = false,
                    ModifyMemoryCount = 1,
                    RequiredMemoryCount = 1
                });
            gameMap.Locations.Add
                (new Location()
                {
                    Id = 10,
                    Name = "Silvercoast Park",
                    Description = "Silvercoast Park, a block from Charlie's apartment, is lined with oak and maple trees " +
                    "towering above park benches. A few people sitting at a nearby picnic table are nearly invisible with the " +
                    "exception of a soft fog surrounding them. You wouldn't even think they were there if not for them eating " +
                    "sandwiches at the table and chatting amongst each other. Further from the picnic area is a playground with " +
                    "bright yellow slides, rock climbing walls, and a swingset.",
                    Accessible = false,
                    ModifyMemoryCount = 1,
                    RequiredMemoryCount = 2
                });
            gameMap.Locations.Add
                (new Location()
                {
                    Id = 11,
                    Name = "Hillview High School Hallway",
                    Description = "You open a set of navy blue double doors to the hallway of your old high school. Some " +
                    "classrooms have posters for various events taped to their doors - final sporting events, prom themes, " +
                    "and schedules for summer programs. You find yourself most drawn to a poster for your theatre class: " +
                    "'A Midsummer Night's Dream'. You remember having only been a stagehand for that production.",
                    Accessible = false,
                    ModifyMemoryCount = 1,
                    RequiredMemoryCount = 1
                });
            gameMap.Locations.Add
                (new Location()
                {
                    Id = 12,
                    Name = "Hillview High School Hallway",
                    Description = "You keep walking down the hallway. Science projects are hung above the lockers lining the " +
                    "hallway. While most classes are in session, you notice one classroom's door is open - your Senior year " +
                    "English classroom.",
                    Accessible = false,
                    ModifyMemoryCount = 1,
                    RequiredMemoryCount = 2
                });
            gameMap.Locations.Add
                (new Location()
                {
                    Id = 13,
                    Name = "English 12 Classroom",
                    Description = "The English classroom is void of students, but the whiteboard still reads the list of " +
                    "assignments for today. A backpack still hangs on the chair of a student's desk near the front of the " +
                    "classroom. Grammar posters hang from the walls as student projects are on display on the classroom's " +
                    "bulletin board. Baskets of assignments, both unassigned and complete, lay on the teacher's desk, along " +
                    "with a 3-ring binder labeled 'Answer Keys'.",
                    Accessible = false,
                    ModifyMemoryCount = 1,
                    RequiredMemoryCount = 3
                });
            gameMap.Locations.Add
                (new Location()
                {
                    Id = 14,
                    Name = "Sidewalk",
                    Description = "You exit the school through another pair of double doors that leads to the sidewalk. " +
                    "Carefully groomed hedges are grown along the right of the sidewalk, with the exception of one that looks " +
                    "as if someone had either been pushed through the bushes or had crawled through them recently. Up ahead is " +
                    "the town's greenhouse, open all year round. ",
                    Accessible = false,
                    ModifyMemoryCount = 1,
                    RequiredMemoryCount = 3
                });
            gameMap.Locations.Add
                (new Location()
                {
                    Id = 15,
                    Name = "Greenhouse",
                    Description = "From floor to ceiling, the greenhouse is full of plants of all kinds. A wave of nostalgia hits you as " +
                    "you see a small table in the left corner. It holds a box of seed packets and a small spade shovel, as well as a tray " +
                    "of starter plants - a small tomato tag hangs off the side of the tray. You notice something shiny in the strawberry " +
                    "bushes near the center of the greenhouse, next to your old jacket resting on a shelf of potting soil bags.",
                    Accessible = false,
                    ModifyMemoryCount = 1,
                    RequiredMemoryCount = 1
                });

            // set the initial location for the player
            gameMap.CurrentLocation = gameMap.Locations.FirstOrDefault(l => l.Id == 1);

            return gameMap;
        }
    }
}
