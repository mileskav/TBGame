using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace TBGame.Models
{
    /// <summary>
    /// player class
    /// </summary>
    public class Player : Character
    {
        #region FIELDS

        private int _memories;
        private List<Location> _locationsVisited;
        private ObservableCollection<GameItemQuantity> _inventory;
        private ObservableCollection<GameItemQuantity> _consumables;
        private ObservableCollection<GameItemQuantity> _keyItems;
        private int _wealth;

        #endregion

        #region PROPERTIES

        public int Memories
        {
            get { return _memories; }
            set
            {
                _memories = value;
                OnPropertyChanged(nameof(Memories));
            }
        }

        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }
        
        public ObservableCollection<GameItemQuantity> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        public ObservableCollection<GameItemQuantity> Consumables
        {
            get { return _consumables; }
            set { _consumables = value; }
        }
        public ObservableCollection<GameItemQuantity> KeyItems
        {
            get { return _keyItems; }
            set { _keyItems = value; }
        }
        public int Wealth
        {
            get { return _wealth; }
            set
            {
                _wealth = value;
                OnPropertyChanged(nameof(Wealth));
            }
        }
        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _locationsVisited = new List<Location>();
            _consumables = new ObservableCollection<GameItemQuantity>();
            _keyItems = new ObservableCollection<GameItemQuantity>();
        }

        #endregion

        #region METHODS

        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }

        public override string Greeting()
        {
            return $"Hi, my name is {Name} and I am feeling {EnergyLevel}.";
        }
        public override bool IsRemembered()
        {
            return false;
        }
        public void UpdateInventoryCategories()
        {
            KeyItems.Clear();
            Consumables.Clear();

            foreach (var gameItemQuantity in _inventory)
            {
                if (gameItemQuantity.GameItem is KeyItem) KeyItems.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Consumable) Consumables.Add(gameItemQuantity);
            }
        }
        public void CalculateWealth()
        {
            Wealth = _inventory.Sum(i => i.GameItem.Value);
        }
        public void AddGameItemQuantityToInventory(GameItemQuantity selectedGameItemQuantity)
        {
            // locate selected item in inventory
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _inventory.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }

            UpdateInventoryCategories();
        }
        public void RemoveGameItemQuantityFromInventory(GameItemQuantity selectedGameItemQuantity)
        {
            // locate selected item in inventory
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    _inventory.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateInventoryCategories();
        }
        #endregion

    }
}
