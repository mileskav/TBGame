﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBGame.PresentationLayer;
using TBGame.DataLayer;
using TBGame.Models;
using System.Collections.ObjectModel;

namespace TBGame.BusinessLayer
{
    /// <summary>
    /// business logic layer class
    /// manages windows and interacts with the data layer
    /// </summary>
    public class GameBusiness
    {
        bool _newPlayer = true;
        GameSessionViewModel _gameSessionViewModel;
        Player _player = new Player();
        PlayerSetupView _playerSetupView;
        Map _gameMap;
        List<string> _messages;

        public GameBusiness()
        {
            SetupPlayer();
            InitializeDataSet();
            InstantiateAndShowView();
        }

        /// <summary>
        /// setup new or existing player
        /// </summary>
        private void SetupPlayer()
        {
            if (_newPlayer)
            {
                _playerSetupView = new PlayerSetupView(_player);
                _playerSetupView.ShowDialog();

                // setup up game based player properties
                _player.Health = 100;
                _player.ExperiencePoints = 0;
                _player.Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameData.GameItemById(201), 1)
                };
            }
            else
            {
                _player = GameData.PlayerData();
            }
        }

        /// <summary>
        /// initialize data set
        /// </summary>
        private void InitializeDataSet()
        {
            _gameMap = GameData.GameMap();
        }

        /// <summary>
        /// create view model with data set
        /// </summary>
        private void InstantiateAndShowView()
        {
            // instantiate the view model and initialize the data set
            _gameSessionViewModel = new GameSessionViewModel(
                _player,
                _gameMap
                );
            GameSessionView gameSessionView = new GameSessionView(_gameSessionViewModel);

            gameSessionView.DataContext = _gameSessionViewModel;

            gameSessionView.Show();

            _playerSetupView.Close();
        }
    }
}
