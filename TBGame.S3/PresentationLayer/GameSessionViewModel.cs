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
        private GameItemQuantity _currentGameItem;
        private string _currentLocationInformation;
        #endregion

        #region PROPERTIES
        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }
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
                OnPropertyChanged(nameof(CurrentLocation));
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

        public GameItemQuantity CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
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

        /// <summary>
        /// initial setup of the game session view
        /// </summary>
        private void InitializeView()
        {
            UpdateAccessibleLocations();
            _player.UpdateInventoryCategories();
            _player.CalculateWealth();
        }

        /// <summary>
        /// player move event handler
        /// </summary>
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
            //_currentLocation = AccessibleLocations.FirstOrDefault(l => l.Name == _currentLocationName);

            // update stats if player has not visited the location
            if (!_player.HasVisited(_currentLocation))
            {
                // update list of visited locations
                _player.LocationsVisited.Add(_currentLocation);

                // update player experience points
                _player.Memories += _currentLocation.ModifyMemoryCount;

            }

            // display a new message if available
            OnPropertyChanged(nameof(MessageDisplay));

            // update the list of locations
            UpdateAccessibleLocations();
        }

        /// <summary>
        /// update the accessible locations for the list box
        /// </summary>
        private void UpdateAccessibleLocations()
        {
            // reset accessible locations list
            _accessibleLocations.Clear();

            // add all accessible locations to list
            foreach (Location location in _gameMap.Locations)
            {
                if (
                    location.Accessible == true ||
                    _player.Memories >= location.RequiredMemoryCount)
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
            // confirm a game item is selected and in current location
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
            // confirm game item is selected and is in inventory
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
                default:
                    break;
            }
        }

        private void ProcessKeyItemUse(KeyItem keyItem)
        {
            string message;

            switch (keyItem.UseAction)
            {
                case KeyItem.UseActionType.COMBINE:
                    //todo - add to this
                    break;
                case KeyItem.UseActionType.OPENLOCATION:
                    message = _gameMap.OpenLocationsByKeyItem(keyItem.Id);
                    CurrentLocationInformation = keyItem.UseMessage;
                    break;
                case KeyItem.UseActionType.GIVENPC:
                    //todo - add to this
                    break;
                default:
                    break;
            }
        }

        private void ProcessConsumableUse(Consumable consumable)
        {
            _player.EnergyLevel += consumable.EnergyChange;
            _player.RemoveGameItemQuantityFromInventory(_currentGameItem);
        }
        #endregion

    }

}
