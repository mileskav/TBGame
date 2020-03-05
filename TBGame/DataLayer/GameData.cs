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
                Name = "Alex",
                EnergyLevel = Character.Energy.Average,
                Memories = 0,
                CurrentMem = 0,
                LocationId = 0
            };
        }

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "It is 2 AM. You find yourself awake in your apartment, alerted by the traffic outside." +
                "You haven't felt a refreshing night of sleep in months and even the state of your apartment is starting to suffer." +
                "Despite your best efforts to fall asleep again, you find yourself staring at the faded white ceiling above your bed."
            };
        }
    }
}
