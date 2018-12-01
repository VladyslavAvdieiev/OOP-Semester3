using Microsoft.Win32;
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

namespace PresentationLayer.GraphicalUserInterface
{
    /// <summary>
    /// Interaction logic for PathsSettings.xaml
    /// </summary>
    public partial class PathsSettings : Window {

        /// <summary>
        /// Default constructor. Set paths from config to window
        /// </summary>
        public PathsSettings() {
            InitializeComponent();

            ingredientsPath_TextBox.Text = Properties.Settings.Default.Ingredients_Path;
            dishesPath_TextBox.Text = Properties.Settings.Default.Dishes_Path;
            menusPath_TextBox.Text = Properties.Settings.Default.Menus_Path;
            ordersPath_TextBox.Text = Properties.Settings.Default.Orders_Path;
        }

        /// <summary>
        /// Write down path from window to config
        /// </summary>
        private void SaveIngredientsPath_Button_Click(object sender, RoutedEventArgs e) {
            Properties.Settings.Default.Ingredients_Path = ingredientsPath_TextBox.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Settings were written down successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Write down path from window to config
        /// </summary>
        private void SaveDishesPath_Button_Click(object sender, RoutedEventArgs e) {
            Properties.Settings.Default.Dishes_Path = dishesPath_TextBox.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Settings were written down successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Write down path from window to config
        /// </summary>
        private void SaveMenusPath_Button_Click(object sender, RoutedEventArgs e) {
            Properties.Settings.Default.Menus_Path = menusPath_TextBox.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Settings were written down successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Write down path from window to config
        /// </summary>
        private void SaveOrdersPath_Button_Click(object sender, RoutedEventArgs e) {
            Properties.Settings.Default.Orders_Path = ordersPath_TextBox.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Settings were written down successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Open file dialog to choose xml file
        /// </summary>
        private void SearchIngredientsPath_Button_Click(object sender, RoutedEventArgs e) {
            ingredientsPath_TextBox.Text = OpenFile();
        }

        /// <summary>
        /// Open file dialog to choose xml file
        /// </summary>
        private void SearchDishesPath_Button_Click(object sender, RoutedEventArgs e) {
            dishesPath_TextBox.Text = OpenFile();
        }

        /// <summary>
        /// Open file dialog to choose xml file
        /// </summary>
        private void SearchMenusPath_Button_Click(object sender, RoutedEventArgs e) {
            menusPath_TextBox.Text = OpenFile();
        }

        /// <summary>
        /// Open file dialog to choose xml file
        /// </summary>
        private void SearchOrdersPath_Button_Click(object sender, RoutedEventArgs e) {
            ordersPath_TextBox.Text = OpenFile();
        }

        /// <summary>
        /// Open file dialog
        /// </summary>
        private string OpenFile() {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files(*.*)| *.*";
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == true)
                return dialog.FileName;
            return string.Empty;
        }

        /// <summary>
        /// Save all changes to config
        /// </summary>
        private void Save_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            Properties.Settings.Default.Ingredients_Path = ingredientsPath_TextBox.Text;
            Properties.Settings.Default.Dishes_Path = dishesPath_TextBox.Text;
            Properties.Settings.Default.Menus_Path = menusPath_TextBox.Text;
            Properties.Settings.Default.Orders_Path = ordersPath_TextBox.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Settings were written down successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
