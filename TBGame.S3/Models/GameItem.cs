using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBGame.Models
{
    public class GameItem
    {
        #region PROPERTIES
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public string UseMessage { get; set; }
        public string Information
        {
            get
            {
                return InformationString();
            }
        }
        #endregion

        #region CONSTRUCTORS
        public GameItem(int id, string name, int value, string description, string useMessage = "")
        {
            Id = id;
            Name = name;
            Value = value;
            Description = description;
            UseMessage = useMessage;
        }
        #endregion

        #region METHODS
        public virtual string InformationString()
        {
            return $"{Name}: {Description}/nValue: {Value}";
        }
        #endregion
    }
}
