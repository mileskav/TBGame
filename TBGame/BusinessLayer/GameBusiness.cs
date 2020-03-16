using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBGame.Models;
using TBGame.DataLayer;
using TBGame.PresentationLayer;

namespace TBGame.BusinessLayer
{
    class GameBusiness
    {
        GameSessionViewModel _gameSessionViewModel;
        Player _player = new Player();
        List<string> _messages;
        bool _newPlayer = true;
        PlayerSetupView _playerSetupView;
        public GameBusiness()
        {
            SetupPlayer();
            InitializeDataSet();
            InstantiateAndShowView();
        }

        /// <summary>
        /// initialize data set
        /// </summary>
        private void InitializeDataSet()
        {
            _player = GameData.PlayerData();
            _messages = GameData.InitialMessages();
        }

        /// <summary>
        /// create view model with data set
        /// </summary>
        private void InstantiateAndShowView()
        {
            // instatiate the view model and initialize the data set
            _gameSessionViewModel = new GameSessionViewModel(_player, _messages);
            GameSessionView gameSessionView = new GameSessionView(_gameSessionViewModel);

            gameSessionView.DataContext = _gameSessionViewModel;

            gameSessionView.Show();

            _playerSetupView.Close();
        }

        private void SetupPlayer()
        {
            if (_newPlayer)
            {
                _playerSetupView = new PlayerSetupView(_player);
                _playerSetupView.ShowDialog();

                // setup game based player properties
                _player.Health = 100;
                _player.ExperiencePoints = 0;
            }
            else
            {
                _player = GameData.PlayerData();
            }
        }
    }
}
