using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessAccessLayer.Entities;
using BusinessAccessLayer.Services;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace PresentationLayer.GraphicalUserInterface
{
    /// <summary>
    /// Interaction logic for BranchNode.xaml
    /// </summary>
    public partial class BranchNode : Window {
        private bool read;
        private Item currentItem;
        private List<Dish> dishSource;
        private DataAccessService<List<Dish>> dishDataAccessService;
        private List<BusinessAccessLayer.Entities.Menu> menuSource;
        private DataAccessService<List<BusinessAccessLayer.Entities.Menu>> menuDataAccessService;

        public enum Item { Dishes, Menus };

        /// <summary>
        /// Constructor with parameter
        /// </summary>
        public BranchNode(Item item) {
            InitializeComponent();
            currentItem = item;
            if (item == Item.Dishes) {
                if (LoadDishesFromDB(Properties.Settings.Default.Dishes_Path))
                    LoadDishItems();
            }
            else if (item == Item.Menus) {
                if (LoadMenusFromDB(Properties.Settings.Default.Menus_Path))
                    LoadMenuItems();
            }
        }

        /// <summary>
        /// Read dishes from xml file
        /// </summary>
        private bool LoadDishesFromDB(string path) {
            try {
                dishDataAccessService = new XmlSerializerService<List<Dish>>(path);                                         // DEBUG use BAL
                dishSource = dishDataAccessService.Read();                                                                  // DEBUG use BAL
                return read = true;
            } catch (FileNotFoundException e) {
                MessageBox.Show($"Error:\n{e.Message}\n\nSet path to file in Settings - Edit File Paths",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return read = false;
            }
        }

        /// <summary>
        /// Add dishes from source to window
        /// </summary>
        private void LoadDishItems() {
            items_ListBox.Items.Clear();
            foreach (Dish dish in dishSource)
                items_ListBox.Items.Add($"{dish.Name} - {dish.Cost}uah - {dish.Time}min");
        }

        /// <summary>
        /// Read menus from xml file
        /// </summary>
        private bool LoadMenusFromDB(string path) {
            try {
                menuDataAccessService = new XmlSerializerService<List<BusinessAccessLayer.Entities.Menu>>(path);            // DEBUG use BAL
                menuSource = menuDataAccessService.Read();                                                                  // DEBUG use BAL
                return read = true;
            } catch (FileNotFoundException e) {
                MessageBox.Show($"Error:\n{e.Message}\n\nSet path to file in Settings - Edit File Paths",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return read = false;
            }
        }

        /// <summary>
        /// Add menu headers from source to window
        /// </summary>
        private void LoadMenuItems() {
            items_ListBox.Items.Clear();
            foreach (BusinessAccessLayer.Entities.Menu menu in menuSource)
                items_ListBox.Items.Add(menu.Name);
        }

        /// <summary>
        /// Load desired window to edit or choose
        /// </summary>
        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            int index = -1;
            string content = ((ListBoxItem)sender).Content.ToString();
            while (++index < items_ListBox.Items.Count && content != (string)items_ListBox.Items[index]) ;
            if (currentItem == Item.Dishes)
                EditDish(index);
            else if (currentItem == Item.Menus)
                EditMenu(index);
        }

        /// <summary>
        /// Find index of clicked item and open DishesDesigner window
        /// </summary>
        private void EditDish(int index) {
            DishesDesigner dishesDesigner = new DishesDesigner(dishSource[index]);
            dishesDesigner.Show();
            Hide();
            dishesDesigner.Closed += (s, e) => { LoadDishItems(); Show(); };
        }

        /// <summary>
        /// Find index of clicked item and open window to choose ingredient
        /// </summary>
        private void EditMenu(int index) {
            MenusDesigner menusDesigner = new MenusDesigner(menuSource[index]);
            menusDesigner.Show();
            Hide();
            menusDesigner.Closed += (s, e) => { LoadMenuItems(); Show(); };
        }

        /// <summary>
        /// CanExecute event
        /// </summary>
        private void Add_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = read && ((menuDataAccessService != null) ||(dishDataAccessService != null));
        }

        /// <summary>
        /// Add new item to window
        /// </summary>
        private void Add_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            if (dishDataAccessService != null) {
                dishSource.Add(new Dish());
                EditDish(dishSource.Count - 1);
            }
            else if (menuDataAccessService != null) {
                menuSource.Add(new BusinessAccessLayer.Entities.Menu());
                EditMenu(menuSource.Count - 1);
            }
        }

        /// <summary>
        /// CanExecute event
        /// </summary>
        private void Delete_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = read && (items_ListBox.SelectedIndex != -1);
        }

        /// <summary>
        /// Delete selected item from window
        /// </summary>
        private void Delete_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            MessageBoxResult result = MessageBox.Show("Do you want to remove this item?", "Deletion",
                                                  MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes) {
                if (currentItem == Item.Dishes)
                    dishSource.RemoveAt(items_ListBox.SelectedIndex);
                else if (currentItem == Item.Menus)
                    menuSource.RemoveAt(items_ListBox.SelectedIndex);
                items_ListBox.Items.RemoveAt(items_ListBox.SelectedIndex);
            }
        }

        /// <summary>
        /// CanExecute event
        /// </summary>
        private void Save_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = read && ((menuDataAccessService != null) || (dishDataAccessService != null));
        }

        /// <summary>
        /// Write down data to xml file
        /// </summary>
        private void Save_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            if (currentItem == Item.Dishes) {
                dishDataAccessService.Clear();
                dishDataAccessService.Write(dishSource);                                                                    // DEBUG using BAL
            }
            else if (currentItem == Item.Menus) {
                menuDataAccessService.Clear();
                menuDataAccessService.Write(menuSource);                                                                    // DEBUG using BALL
            }
            MessageBox.Show("Data were written down successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
