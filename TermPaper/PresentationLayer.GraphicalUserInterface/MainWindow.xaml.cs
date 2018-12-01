using System;
using BusinessAccessLayer.Entities;
using BusinessAccessLayer.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace PresentationLayer.GraphicalUserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private List<BusinessAccessLayer.Entities.Menu> menuSource;
        private DataAccessService<List<BusinessAccessLayer.Entities.Menu>> menuDataAccessService;

        public MainWindow() {
            InitializeComponent();
            if (LoadMenusFromDB(Properties.Settings.Default.Menus_Path))
                LoadMenuItems();
        }

        /// <summary>
        /// Reading menus from xml file
        /// </summary>
        private bool LoadMenusFromDB(string path) {
            try {
                menuDataAccessService = new XmlSerializerService<List<BusinessAccessLayer.Entities.Menu>>(path);            // DEBUG use BAL
                menuSource = menuDataAccessService.Read();                                                                  // DEBUG use BAL
                return true;
            } catch (FileNotFoundException e) {
                MessageBox.Show($"Error:\n{e.Message}\n\nSet path to file in Settings - Edit File Paths",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Adding menu headers from xml file to MenuItem
        /// </summary>
        private void LoadMenuItems() {
            menus_MenuItem.Items.Clear();
            foreach (BusinessAccessLayer.Entities.Menu menu in menuSource)
                menus_MenuItem.Items.Add(new MenuItem() { Header = menu.Name });
        }

        /// <summary>
        /// Handling of menu' items click event
        /// </summary>
        private void Menus_MenuItem_Click(object sender, RoutedEventArgs e) {
            int index = -1;
            string header = ((MenuItem)sender).Header.ToString();

            while (header != menuSource[++index].Name);

            foreach (MenuItem item in menus_MenuItem.Items)
                item.IsChecked = false;

            ((MenuItem)sender).IsChecked = true;

            dishes_ListBox.ItemsSource = null;
            dishes_ListBox.ItemsSource = Converter.ToTemplateItem(menuSource[index].Dishes);
        }

        /// <summary>
        /// _______________
        /// </summary>
        private void Dishes_ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            MessageBox.Show(sender.ToString(), "");
        }

        /// <summary>
        /// Opening PathsSettings window
        /// </summary>
        private void PathSettings_MenuItem_Click(object sender, RoutedEventArgs e) {
            PathsSettings pathsSettings = new PathsSettings();
            pathsSettings.Show();
        }

        /// <summary>
        /// Opening IngredientsDesigner window
        /// </summary>
        private void IngredientSettings_MenuItem_Click(object sender, RoutedEventArgs e) {
            IngredientsDesigner ingredientsDesigner = new IngredientsDesigner();
            ingredientsDesigner.Show();
        }

        /// <summary>
        /// Opening DishesDesigner window
        /// </summary>
        private void DishSettings_MenuItem_Click(object sender, RoutedEventArgs e) {
            DishesDesigner dishesDesigner = new DishesDesigner(0);
            dishesDesigner.Show();
        }

        /// <summary>
        /// Opening ________ window
        /// </summary>
        private void MenuSettings_MenuItem_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show(sender.ToString(), "");
        }
    }
}
