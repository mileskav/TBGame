using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBGame.Models;

namespace TBGame.PresentationLayer
{
    public class GameSessionViewModel
    {
        #region FIELDS
        private Player _player;
        private List<string> _messages;
        #endregion

        #region PROPERTIES
        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        // return list of strings converted to single string with new lines between each message
        public string MessageDisplay
        {
            get { return string.Join("\n\n", _messages); }
        }

        #endregion

        #region CONSTRUCTORS
        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(
            Player player,
            List<string> initialMessages)
        {
            _player = player;
            _messages = initialMessages;
        }

        #endregion
    }
}
