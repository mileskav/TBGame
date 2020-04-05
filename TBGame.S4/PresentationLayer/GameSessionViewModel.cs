using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBGame.Models;
using TBGame;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using TBGame.DataLayer;
using System.Windows;

namespace TBGame.PresentationLayer
{
    /// <summary>
    /// view model for the game session view
    /// </summary>
    public class GameSessionViewModel : ObservableObject
    {
        #region FIELDS
        private Player _player;
        private Map _gameMap;
        private Location _currentLocation;
        private ObservableCollection<Location> _accessibleLocations;
        private string _currentLocationName;
        private string _currentLocationInformation;
        private GameItemQuantity _currentGameItem;
        private Random random = new Random();
        private NPC _currentNPC;
        #endregion

        #region PROPERTIES
        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }
        public string MessageDisplay
        {
            get { return _currentLocation.Message; }
        }
        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                _currentLocationInformation = MessageDisplay;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }
        public ObservableCollection<Location> AccessibleLocations
        {
            get
            {
                return _accessibleLocations;
            }
            set
            {
                _accessibleLocations = value;
                OnPropertyChanged(nameof(AccessibleLocations));
            }
        }
        public string CurrentLocationName
        {
            get { return _currentLocationName; }
            set
            {
                _currentLocationName = value;
                OnPlayerMove();
                OnPropertyChanged("CurrentLocation");
            }
        }
        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }
        public GameItemQuantity CurrentGameItem
        {
            get { return _currentGameItem; }
            set 
            { 
                _currentGameItem = value;
                OnPropertyChanged(nameof(CurrentGameItem));
                if (_currentGameItem.GameItem is Weapon)
                {
                    _player.CurrentWeapon = _currentGameItem.GameItem as Weapon;
                }
            }
        }
        public NPC CurrentNPC
        {
            get { return _currentNPC; }
            set
            {
                _currentNPC = value;
                OnPropertyChanged(nameof(CurrentNPC));
            }
        }
        #endregion

        #region CONSTRUCTORS

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(
            Player player,
            Map gameMap)
        {
            _player = player;
            _gameMap = gameMap;

            _currentLocation = _gameMap.CurrentLocation;
            _accessibleLocations = new ObservableCollection<Location>();

            InitializeView();
        }

        #endregion

        #region METHODS

        private void InitializeView()
        {
            UpdateAccessibleLocations();
            _player.UpdateInventoryCategories();
            _player.CalculateWealth();
        }

        private void OnPlayerMove()
        {
            // set new current location
            foreach (Location location in AccessibleLocations)
            {
                if (location.Name == _currentLocationName)
                {
                    _currentLocation = location;
                }

            }

            // update stats if player has not visited the location
            if (!_player.HasVisited(_currentLocation))
            {
                // update list of visited locations
                _player.LocationsVisited.Add(_currentLocation);

                // update player experience points
                _player.ExperiencePoints += _currentLocation.ModifyExperience;

                // update player health
                if (_currentLocation.ModifyHealth != 0)
                {
                    _player.Health += _currentLocation.ModifyHealth;
                    if (_player.Health > 100)
                    {
                        _player.Health = 100;
                    }
                }
            }

            // display a new message if available
            OnPropertyChanged(nameof(MessageDisplay));

            // update the list of locations
            UpdateAccessibleLocations();
        }
        private void UpdateAccessibleLocations()
        {
            // reset accessible locations list
            _accessibleLocations.Clear();

            // add all accessible locations to list
            foreach (Location location in _gameMap.Locations)
            {
                if (location.Accessible == true )
                    //|| _player.ExperiencePoints > location.RequiredExperience)
                {
                    _accessibleLocations.Add(location);
                }
            }

            // remove current location
            _accessibleLocations.Remove(_accessibleLocations.FirstOrDefault(l => l == _currentLocation));

            // notify list box in view to update
            OnPropertyChanged(nameof(AccessibleLocations));
        }
        public void AddItemToInventory()
        {
            // confirm a game item selected and is in current location
            // subtract from location and add to inventory
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                // cast selected game item 
                GameItemQuantity selectedGameItemQuantity = _currentGameItem as GameItemQuantity;

                _currentLocation.RemoveGameItemQuantityFromLocation(selectedGameItemQuantity);
                _player.AddGameItemQuantityToInventory(selectedGameItemQuantity);

                OnPlayerPickUp(selectedGameItemQuantity);
            }
        }
        public void RemoveItemFromInventory()
        {
            // confirm a game item selected and is in inventory
            // subtract from inventory and add to location
            if (_currentGameItem != null)
            {
                // cast selected game item 
                GameItemQuantity selectedGameItemQuantity = _currentGameItem as GameItemQuantity;

                _currentLocation.AddGameItemQuantityToLocation(selectedGameItemQuantity);
                _player.RemoveGameItemQuantityFromInventory(selectedGameItemQuantity);

                OnPlayerPutDown(selectedGameItemQuantity);
            }
        }
        private void OnPlayerPickUp(GameItemQuantity gameItemQuantity)
        {
            _player.ExperiencePoints += gameItemQuantity.GameItem.ExperiencePoints;
            _player.Wealth += gameItemQuantity.GameItem.Value;
        }
        private void OnPlayerPutDown(GameItemQuantity gameItemQuantity)
        {
            _player.Wealth -= gameItemQuantity.GameItem.Value;
        }
        public void OnUseGameItem()
        {
            switch (_currentGameItem.GameItem)
            {
                case Consumable consumable:
                    ProcessConsumableUse(consumable);
                    break;
                case KeyItem keyItem:
                    ProcessKeyItemUse(keyItem);
                    break;
                case Statement statement:
                    ProcessStatementUse(statement);
                    break;
                default:
                    break;
            }
        }
        private void ProcessStatementUse(Statement statement)
        {
            string message;
            switch (statement.UseAction)
            {
                case Statement.UseActionType.OPENLOCATION:
                    message = _gameMap.OpenLocationsByItem(statement.Id);
                    CurrentLocationInformation = statement.UseMessage;
                    break;
                default:
                    break;
            }
        }
        private void ProcessKeyItemUse(KeyItem keyItem)
        {
            string message;

            switch (keyItem.UseAction)
            {
                case KeyItem.UseActionType.OPENLOCATION:
                    message = _gameMap.OpenLocationsByItem(keyItem.Id);
                    CurrentLocationInformation = keyItem.UseMessage;
                    break;
                case KeyItem.UseActionType.DAMAGE:
                    OnPlayerDies(keyItem.UseMessage);
                    break;
                case KeyItem.UseActionType.GIVENPC:
                    // todo - update
                    break;
                default:
                    break;
            }
        }
        private void ProcessConsumableUse(Consumable consumable)
        {
            string message;
            _player.Health += consumable.HealthChange;
            CurrentLocationInformation = consumable.UseMessage;
            _player.RemoveGameItemQuantityFromInventory(_currentGameItem);
        }
        private void OnPlayerDies(string message)
        {
            string messagetext = message + "\n\nWould you like to play again?";

            string titleText = "Death";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(messagetext, titleText, button);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    ResetPlayer();
                    break;
                case MessageBoxResult.No:
                    QuitApplication();
                    break;
            }
        }
        public void OnPlayerTalkTo()
        {
            if(CurrentNPC != null && CurrentNPC is ISpeak)
            {
                ISpeak speakingNPC = CurrentNPC as ISpeak;
                CurrentLocationInformation = speakingNPC.Speak();
            }
        }
        private BattleModeName NPCBattleResponse()
        {
            BattleModeName npcBattleResponse = BattleModeName.RETREAT;

            switch (DieRoll(3))
            {
                case 1:
                    npcBattleResponse = BattleModeName.ATTACK;
                    break;
                case 2:
                    npcBattleResponse = BattleModeName.DEFEND;
                    break;
                case 3:
                    npcBattleResponse = BattleModeName.RETREAT;
                    break;
            }
            return npcBattleResponse;
        }
        private int CalculatePlayerHitPoints()
        {
            int playerHitPoints = 0;

            switch (_player.BattleMode)
            {
                case BattleModeName.ATTACK:
                    playerHitPoints = _player.Attack();
                    break;
                case BattleModeName.DEFEND:
                    playerHitPoints = _player.Defend();
                    break;
                case BattleModeName.RETREAT:
                    playerHitPoints = _player.Retreat();
                    break;
            }
            return playerHitPoints;
        }
        private int CalculateNPCHitPoints(IBattle battleNPC)
        {
            int battleNPCHitPoints = 0;
            switch (NPCBattleResponse())
            {
                case BattleModeName.ATTACK:
                    battleNPCHitPoints = battleNPC.Attack();
                    break;
                case BattleModeName.DEFEND:
                    battleNPCHitPoints = battleNPC.Defend();
                    break;
                case BattleModeName.RETREAT:
                    battleNPCHitPoints = battleNPC.Retreat();
                    break;
            }
            return battleNPCHitPoints;
        }
        private void Battle()
        {
            // check if an NPC can battle
            if(_currentNPC is IBattle)
            {
                IBattle battleNPC = _currentNPC as IBattle;
                int playerHitPoints = 0;
                int battleNPCHitPoints = 0;
                string battleInformation = "";

                // calculate hit points if the player and NPC have weapons
                if(_player.CurrentWeapon != null)
                {
                    playerHitPoints = CalculatePlayerHitPoints();
                }
                else
                {
                    battleInformation = "It appears you're entering into battle without a weapon.";
                }

                if(battleNPC.CurrentWeapon != null)
                {
                    battleNPCHitPoints = CalculateNPCHitPoints(battleNPC);
                }
                else
                {
                    battleInformation = $"It appears you're entering into battle with {_currentNPC.Name} who has no weapon.";
                }

                // build out text for current location information
                battleInformation +=
                    $"Player: {_player.BattleMode}  Hit Points: {playerHitPoints}" + Environment.NewLine +
                    $"NPC: {battleNPC.BattleMode}   Hit Points: {battleNPCHitPoints}" + Environment.NewLine;

                // determine results of battle
                if (playerHitPoints >= battleNPCHitPoints)
                {
                    battleInformation += $"You've defeated {_currentNPC.Name}.";
                    _currentLocation.NPCs.Remove(_currentNPC);
                }

                CurrentLocationInformation = battleInformation;
                if (_player.Health <= 0) OnPlayerDies($"You have been defeated by {_currentNPC.Name}.");
            }
            else
            {
                CurrentLocationInformation = "The NPC isn't ready to fight. -10 experience.";
                _player.ExperiencePoints -= 10;
            }
        }
        public void OnPlayerAttack()
        {
            _player.BattleMode = BattleModeName.ATTACK;
            Battle();
        }
        public void OnPlayerDefend()
        {
            _player.BattleMode = BattleModeName.DEFEND;
            Battle();
        }
        public void OnPlayerRetreat()
        {
            _player.BattleMode = BattleModeName.RETREAT;
            Battle();
        }
        private void QuitApplication()
        {
            Environment.Exit(0);
        }
        private void ResetPlayer()
        {
            Environment.Exit(0);
        }
        #endregion

        #region HELPER METHODS
        private int DieRoll(int sides)
        {
            return random.Next(1, sides + 1);
        }
        #endregion
    }

}
