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
        private List<Order> orderSource;
        private DataAccessService<List<Order>> orderDataAccessService;

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow() {
            InitializeComponent();
            if (LoadMenusFromDB(Properties.Settings.Default.Menus_Path))
                LoadMenuItems();
            if (LoadOrdersFromDB(Properties.Settings.Default.Orders_Path))
                LoadOrderItems();
        }

        /// <summary>
        /// Read menus from xml file
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
        /// Add menu headers from xml file to MenuItem
        /// </summary>
        private void LoadMenuItems() {
            menus_MenuItem.Items.Clear();
            foreach (BusinessAccessLayer.Entities.Menu menu in menuSource)
                menus_MenuItem.Items.Add(new MenuItem() { Header = menu.Name });
        }

        /// <summary>
        /// Read orders from xml file
        /// </summary>
        private bool LoadOrdersFromDB(string path) {
            try {
                orderDataAccessService = new XmlSerializerService<List<Order>>(Properties.Settings.Default.Orders_Path);    // DEBUG use BAL
                orderSource = orderDataAccessService.Read();                                                                // DEBUG use BAL
                return true;
            } catch (FileNotFoundException e) {
                MessageBox.Show($"Error:\n{e.Message}\n\nSet path to file in Settings - Edit File Paths",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Add order headers from xml file to MenuItem
        /// </summary>
        private void LoadOrderItems() {
            orders_MenuItem.Items.Clear();
            foreach (Order order in orderSource)
                orders_MenuItem.Items.Add(new MenuItem() { Header = order.Date });
        }

        /// <summary>
        /// Refresh order list
        /// </summary>
        private void NewOrder_MenuItem_Click(object sender, RoutedEventArgs e) {
            foreach (MenuItem item in orders_MenuItem.Items)
                item.IsChecked = false;
            createOrder_Button.IsEnabled = true;
            RefreshOrder();
        }

        /// <summary>
        /// View chosen order
        /// </summary>
        private void Orders_MenuItem_Click(object sender, RoutedEventArgs e) {
            int index = -1;
            string header = ((MenuItem)sender).Header.ToString();

            while (header != orderSource[++index].Date.ToString());

            foreach (MenuItem item in orders_MenuItem.Items)
                item.IsChecked = false;

            orders_ListBox.Items.Clear();
            ((MenuItem)sender).IsChecked = true;
            foreach (Dish dish in orderSource[index].Dishes)
                orders_ListBox.Items.Add(Converter.ToTemplateItem(dish));
            remark_TextBox.Text = orderSource[index].Remark;
            table_ComboBox.SelectedIndex = orderSource[index].TableNumber - 1;

            createOrder_Button.IsEnabled = false;
        }

        /// <summary>
        /// Add clicked dish to order
        /// </summary>
        private void Dishes_ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            orders_ListBox.Items.Add(((ListBoxItem)sender).DataContext);
            Orders_ListBox_CountTotalCost();
        }

        /// <summary>
        /// Remove clicked item from order
        /// </summary>
        private void Orders_ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            try { orders_ListBox.Items.RemoveAt(orders_ListBox.SelectedIndex); }  catch (Exception) { };
            Orders_ListBox_CountTotalCost();
        }

        /// <summary>
        /// Count total cost
        /// </summary>
        private void Orders_ListBox_CountTotalCost() {
            double cost = 0.0;
            foreach (TemplateItem item in orders_ListBox.Items)
                cost += item.Cost;
            totalCost_TextBlock.Text = cost.ToString();
        }

        /// <summary>
        /// Refresh order
        /// </summary>
        private void RefreshOrder() {
            orders_ListBox.Items.Clear();
            remark_TextBox.Text = "Remark: ";
            totalCost_TextBlock.Text = "0";
            table_ComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Load dishes of clicked menu in window
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
        /// Open PathsSettings window
        /// </summary>
        private void PathSettings_MenuItem_Click(object sender, RoutedEventArgs e) {
            PathsSettings pathsSettings = new PathsSettings();
            pathsSettings.Show();
        }

        /// <summary>
        /// Open IngredientsDesigner window
        /// </summary>
        private void IngredientSettings_MenuItem_Click(object sender, RoutedEventArgs e) {
            IngredientsDesigner ingredientsDesigner = new IngredientsDesigner();
            ingredientsDesigner.Show();
        }

        /// <summary>
        /// Open BranchNode window for Dishes
        /// </summary>
        private void DishSettings_MenuItem_Click(object sender, RoutedEventArgs e) {
            BranchNode branchNode = new BranchNode(BranchNode.Item.Dishes);
            branchNode.Show();
        }

        /// <summary>
        /// Open BranchNode window for Menus
        /// </summary>
        private void MenuSettings_MenuItem_Click(object sender, RoutedEventArgs e) {
            BranchNode branchNode = new BranchNode(BranchNode.Item.Menus);
            branchNode.Show();
            branchNode.Closed += (ss, ee) => {
                LoadMenusFromDB(Properties.Settings.Default.Menus_Path);
                LoadMenuItems();
            };
        }

        /// <summary>
        /// Create and save new order to xml file
        /// </summary>
        private void CreateOrder_Button_Click(object sender, RoutedEventArgs e) {
            if (orders_ListBox.Items.Count == 0) {
                MessageBox.Show($"There is no dishes to write down.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            List<Dish> dishes = new List<Dish>();
            foreach (TemplateItem item in orders_ListBox.Items)
                dishes.Add(Converter.ToDishes(item));

            orderSource.Add(new Order(table_ComboBox.SelectedIndex + 1, Convert.ToDouble(totalCost_TextBlock.Text),
                                      dishes, DateTime.Now) { Remark = remark_TextBox.Text });

            orderDataAccessService.Clear();
            orderDataAccessService.Write(orderSource);
            LoadOrderItems();
            RefreshOrder();
            MessageBox.Show("Data were written down successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
