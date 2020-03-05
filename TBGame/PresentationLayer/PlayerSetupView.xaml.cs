using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TBGame.Models;

namespace TBGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for PlayerSetupView.xaml
    /// </summary>
    public partial class PlayerSetupView : Window
    {
        private Player _player;
        public PlayerSetupView(Player player)
        {
            _player = player;

            InitializeComponent();

            SetupWindow();
        }

        private void SetupWindow()
        {
            // generate lists for enum to use in combo boxes
            List<string> energy = Enum.GetNames(typeof(Player.Energy)).ToList();

            // removes null item value
            EnergyComboBox.SelectedIndex = 0;
            EnergyComboBox.ItemsSource = energy;

            // hide error message box initially
            ErrorMessageTextBlock.Visibility = Visibility.Hidden;
        }

        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";

            if(NameTextBox.Text == "")
            {
                errorMessage += "Player Name is required. \n";
            }
            else
            {
                _player.Name = NameTextBox.Text;
            }

            return errorMessage == "" ? true : false;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage;

            if (IsValidInput(out errorMessage))
            {
                // get values from combo boxes
                Enum.TryParse(EnergyComboBox.SelectionBoxItem.ToString(), out Player.Energy energy);
                // set player properties
                _player.EnergyLevel = energy;

                Visibility = Visibility.Hidden;
            }
            else
            {
                // display error messages
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
                ErrorMessageTextBlock.Text = errorMessage;
            }
        }
    }
}
