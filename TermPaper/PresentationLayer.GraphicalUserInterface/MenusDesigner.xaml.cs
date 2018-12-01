using BusinessAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PresentationLayer.GraphicalUserInterface
{
    /// <summary>
    /// Interaction logic for MenusDesigner.xaml
    /// </summary>
    public partial class MenusDesigner : Window {
        private BusinessAccessLayer.Entities.Menu menuSource;

        /// <summary>
        /// Constructor with parameter
        /// </summary>
        public MenusDesigner(BusinessAccessLayer.Entities.Menu menu) {
            InitializeComponent();
            menuSource = menu;
            LoadMenuItems();
        }
        
        /// <summary>
        /// Adding menu info to window
        /// </summary>
        private void LoadMenuItems() {
            name_TextBox.Text = menuSource.Name;
            description_TextBox.Text = menuSource.Description;
            dishes_ListBox.ItemsSource = Converter.ToTemplateItem(menuSource.Dishes);
        }

        /// <summary>
        /// Open BranchNode window to choose dish. Add this dish to window
        /// </summary>
        private void Add_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            SelectionWindow selectionWindow = new SelectionWindow(SelectionWindow.Item.Dishes);
            selectionWindow.Show();
            selectionWindow.Closed += (ss, ee) => {
                if ((selectionWindow?.ChosenDish ?? new Dish()) == selectionWindow.ChosenDish) {
                    List<TemplateItem> items = (List<TemplateItem>)dishes_ListBox.ItemsSource;
                    items.Add(Converter.ToTemplateItem(selectionWindow.ChosenDish));
                    dishes_ListBox.ItemsSource = null;
                    dishes_ListBox.ItemsSource = items;
                }
            };
        }

        /// <summary>
        /// CanExecute event
        /// </summary>
        private void Delete_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = (dishes_ListBox.SelectedIndex != -1);
        }

        /// <summary>
        /// Delete selected item from window
        /// </summary>
        private void Delete_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            MessageBoxResult result = MessageBox.Show("Do you want to remove this item?", "Deletion",
                                                  MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes) {
                List<TemplateItem> items = (List<TemplateItem>)dishes_ListBox.ItemsSource;
                items.RemoveAt(dishes_ListBox.SelectedIndex);
                dishes_ListBox.ItemsSource = null;
                dishes_ListBox.ItemsSource = items;
            }
        }

        /// <summary>
        /// Override values in menu, which came by parameter in constructor
        /// </summary>
        private void Save_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            menuSource.Name = name_TextBox.Text;
            menuSource.Description = description_TextBox.Text;
            menuSource.Dishes = Converter.ToDishes((List<TemplateItem>)dishes_ListBox.ItemsSource);
            MessageBox.Show("Data were written down successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
