using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBGame.Models
{
    /// <summary>
    /// player class
    /// </summary>
    public class Player : Character, IBattle
    {
        private const int DEFENDER_DAMAGE_ADJUSTMENT = 10;
        private const int MAXIMUM_RETREAT_DAMAGE = 10;

        #region FIELDS
        private int _health;
        private int _experiencePoints;
        private int _skillLevel;
        private int _wealth;
        private Weapon _currentWeapon;
        private BattleModeName _battleMode;
        private List<Location> _locationsVisited;
        private List<NPC> _npcsEngaged;

        private ObservableCollection<GameItemQuantity> _inventory;
        private ObservableCollection<GameItemQuantity> _consumables;
        private ObservableCollection<GameItemQuantity> _keyItems;
        private ObservableCollection<GameItemQuantity> _weapons;
        private ObservableCollection<GameItemQuantity> _statements;
        private ObservableCollection<Mission> _missions;
        #endregion

        #region PROPERTIES
        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;

                if (_health > 100)
                {
                    _health = 100;
                }
                else if (_health <= 0)
                {
                    _health = 100;
                }

                OnPropertyChanged(nameof(Health));
            }
        }
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            }
        }
        public int SkillLevel
        {
            get { return _skillLevel; }
            set { _skillLevel = value; }
        }
        public Weapon CurrentWeapon
        {
            get { return _currentWeapon; }
            set { _currentWeapon = value; }
        }
        public BattleModeName BattleMode
        {
            get { return _battleMode; }
            set { _battleMode = value; }
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
        public ObservableCollection<GameItemQuantity> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
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
        public ObservableCollection<GameItemQuantity> Statements
        {
            get { return _statements; }
            set { _statements = value; }
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
        public List<NPC> NPCsEngaged
        {
            get { return _npcsEngaged; }
            set { _npcsEngaged = value; }
        }
        public ObservableCollection<Mission> Missions
        {
            get { return _missions; }
            set { _missions = value; }
        }
        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _locationsVisited = new List<Location>();
            _inventory = new ObservableCollection<GameItemQuantity>();
            _weapons = new ObservableCollection<GameItemQuantity>();
            _keyItems = new ObservableCollection<GameItemQuantity>();
            _consumables = new ObservableCollection<GameItemQuantity>();
            _statements = new ObservableCollection<GameItemQuantity>();
            _npcsEngaged = new List<NPC>();
            _missions = new ObservableCollection<Mission>();
        }

        #endregion

        #region METHODS

        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }

        public override string Greeting()
        {
            return $"Hi, my name is {Name} and I am an avatar of the {ControllingEntity}.";
        }
        public override bool HasStatement()
        {
            return false;
        }
        public void CalculateWealth()
        {
            Wealth = _inventory.Sum(i => i.GameItem.Value * i.Quantity);
        }
        public void UpdateInventoryCategories()
        {
            Consumables.Clear();
            Weapons.Clear();
            KeyItems.Clear();
            Statements.Clear();

            foreach (var gameItemQuantity in _inventory)
            {
                if (gameItemQuantity.GameItem is Consumable) Consumables.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Weapon) Weapons.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is KeyItem) KeyItems.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Statement) Statements.Add(gameItemQuantity);
            }
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
            //
            // locate selected item in inventory
            //
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
        public int Attack()
        {
            int hitPoints = random.Next(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage) * _skillLevel;

            if (hitPoints <= 100)
            {
                return hitPoints;
            }
            else
            {
                return 100;
            }
        }
        public int Defend()
        {
            int hitPoints = (random.Next(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage) * _skillLevel)
                - DEFENDER_DAMAGE_ADJUSTMENT;

            if (hitPoints >= 0 && hitPoints <= 100)
            {
                return hitPoints;
            }
            else
            {
                return 0;
            }
        }
        public int Retreat()
        {
            int hitPoints = _skillLevel * MAXIMUM_RETREAT_DAMAGE;

            if (hitPoints <= 100)
            {
                return hitPoints;
            }
            else
            {
                return 100;
            }
        }

        public void UpdateMissionStatus()
        {
            // only loop through assigned missions and cast mission to proper child class
            foreach (Mission mission in _missions.Where(m => m.Status == Mission.MissionStatus.Incomplete))
            {
                if (mission is MissionTravel)
                {
                    if (((MissionTravel)mission).LocationsNotCompleted(_locationsVisited).Count == 0)
                    {
                        mission.Status = Mission.MissionStatus.Complete;
                        ExperiencePoints += mission.ExperiencePoints;
                    }
                }
                else if (mission is MissionGather)
                {
                    if (((MissionGather)mission).GameItemQuantitiesNotCompleted(_inventory.ToList()).Count == 0)
                    {
                        mission.Status = Mission.MissionStatus.Complete;
                        ExperiencePoints += mission.ExperiencePoints;
                    }
                }
                else if (mission is MissionEngage)
                {
                    if (((MissionEngage)mission).NPCsNotCompleted(_npcsEngaged).Count == 0)
                    {
                        mission.Status = Mission.MissionStatus.Complete;
                        ExperiencePoints += mission.ExperiencePoints;
                    }
                }
                else
                {
                    throw new Exception("Unknown Mission child class.");
                }
            }
        }
        #endregion

    }
}
