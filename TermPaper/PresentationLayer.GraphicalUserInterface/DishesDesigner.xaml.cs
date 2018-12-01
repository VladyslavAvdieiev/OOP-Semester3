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
    /// Interaction logic for DishesDesigner.xaml
    /// </summary>
    public partial class DishesDesigner : Window {
        private Dish dishSource;

        /// <summary>
        /// Constructor with parameter
        /// </summary>
        public DishesDesigner(Dish dish) {
            InitializeComponent();
            dishSource = dish;
            LoadDishItems();
        }
        
        /// <summary>
        /// Adding dishes info to window
        /// </summary>
        private void LoadDishItems() {
            name_TextBox.Text = dishSource.Name;
            description_TextBox.Text = dishSource.Description;
            image_TextBox.Text = dishSource.ImageSource;
            weight_Label.Content = dishSource.Weight;
            cost_TextBox.Text = dishSource.Cost.ToString();
            time_TextBox.Text = dishSource.Time.ToString();
            ingredients_ListBox.ItemsSource = Converter.ToTemplateItem(dishSource.Ingredients);
        }

        /// <summary>
        /// Load image by path from image_TextBox
        /// </summary>
        private void Image_TextBox_TextChanged(object sender, TextChangedEventArgs e) {
            try {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + image_TextBox.Text);
                image.EndInit();
                image_Image.Source = image;
            } catch (Exception) {
                image_Image.Source = (BitmapImage)TryFindResource("404_Image");
            }
        }

        /// <summary>
        /// Open BranchNode window to choose ingredient. Add this ingredient to window
        /// </summary>
        private void Add_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            BranchNode branchNode = new BranchNode("Ingredients");
            branchNode.Show();
            branchNode.Closed += (ss, ee) => {
                if ((branchNode?.ChosenIngredient ?? new Ingredient()) == branchNode.ChosenIngredient) {
                    List<TemplateItem> items = (List<TemplateItem>)ingredients_ListBox.ItemsSource;
                    items.Add(Converter.ToTemplateItem(branchNode.ChosenIngredient));
                    ingredients_ListBox.ItemsSource = null;
                    ingredients_ListBox.ItemsSource = items;
                }
            };
        }

        /// <summary>
        /// CanExecute event
        /// </summary>
        private void Delete_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = (ingredients_ListBox.SelectedIndex != -1);
        }

        /// <summary>
        /// Delete selected item from window
        /// </summary>
        private void Delete_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            MessageBoxResult result = MessageBox.Show("Do you want to remove this item?", "Deletion",
                                                  MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes) {
                List<TemplateItem> items = (List<TemplateItem>)ingredients_ListBox.ItemsSource;
                items.RemoveAt(ingredients_ListBox.SelectedIndex);
                ingredients_ListBox.ItemsSource = null;
                ingredients_ListBox.ItemsSource = items;
            }
        }

        /// <summary>
        /// Override values in dish, which came by parameter in constructor
        /// </summary>
        private void Save_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            dishSource.Name = name_TextBox.Text;
            dishSource.Description = description_TextBox.Text;
            dishSource.ImageSource = image_TextBox.Text;
            dishSource.Cost = Convert.ToDouble(cost_TextBox.Text);
            dishSource.Time = Convert.ToDouble(time_TextBox.Text);
            dishSource.Ingredients = Converter.ToIngredients((List<TemplateItem>)ingredients_ListBox.ItemsSource);
            MessageBox.Show("Data were written down successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
