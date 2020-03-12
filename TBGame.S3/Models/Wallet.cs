using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame.Models
{
    public class Wallet : GameItem
    {

        public Wallet(int id, string name, int value, string description, string useMessage)
            : base(id, name, value, description)
        {
            
        }
    }
}
