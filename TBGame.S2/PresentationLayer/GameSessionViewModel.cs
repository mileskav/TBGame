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

        #endregion

    }

}
