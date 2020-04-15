using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame.Models
{
    public interface IBattle
    {
        int SkillLevel { get; set; }
        Weapon CurrentWeapon { get; set; }
        BattleModeName BattleMode { get; set; }

        //methods to return hit point values for each battle mode
        int Attack();
        int Defend();
        int Retreat();
    }
}
