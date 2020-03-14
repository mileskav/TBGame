using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBGame.Models
{
    /// <summary>
    /// game map class
    /// </summary>
    public class Map
    {
        #region FIELDS

        private List<Location> _locations;
        private Location _currentLocation;
        private ObservableCollection<Location> _accessibleLocations;
        private List<GameItem> _standardGameItems;

        #endregion

        #region PROPERTIES

        public List<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }
        }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }
        public ObservableCollection<Location> AccessibleLocations
        {
            get { return _accessibleLocations; }
            set { _accessibleLocations = value; }
        }
        public List<GameItem> StandardGameItems
        {
            get { return _standardGameItems; }
            set { _standardGameItems = value; }
        }
        #endregion

        #region CONSTRUCTORS

        public Map()
        {
            _locations = new List<Location>();
        }

        #endregion

        #region METHODS

        public void Move(Location location)
        {
            _currentLocation = location;
        }

        public bool CanMove(Location location)
        {
            return location.Accessible;
        }
        public string OpenLocationsByKeyItem(int keyItemId)
        {
            string message = "The item did nothing.";
            Location mapLocation = new Location();

            if (mapLocation != null && mapLocation.RequiredItemId == keyItemId)
            {
                mapLocation.Accessible = true;
                message = $"{mapLocation.Name} is now accessible.";
            }

            return message;
        }

        #endregion
    }
}
