using System;
using BusinessAccessLayer.Entities;
using BusinessAccessLayer.Services;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for DishesDesigner.xaml
    /// </summary>
    public partial class DishesDesigner : Window {
        private bool read;
        private List<Dish> dishSource;
        private DataAccessService<List<Dish>> dishDataAccessService;

        public DishesDesigner(int index) {
            InitializeComponent();
            if (LoadDishesFromDB(Properties.Settings.Default.Dishes_Path))
                LoadDishItems(index);
        }

        /// <summary>
        /// Reading dishes from xml file
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
        /// Adding didhes from xml file to MenuItem
        /// </summary>
        private void LoadDishItems(int index) {
            name_TextBox.Text = dishSource[index].Name;
            description_TextBox.Text = dishSource[index].Description;
            image_TextBox.Text = dishSource[index].ImageSource;
            weight_Label.Content = dishSource[index].Weight;
            cost_TextBox.Text = dishSource[index].Cost.ToString();
            time_TextBox.Text = dishSource[index].Time.ToString();
            ingredients_ListBox.ItemsSource = Converter.ToTemplateItem(dishSource[index].Ingredients);
        }

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

        private void Add_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = read;
        }

        private void Add_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            //List<IngredientTemplateItem> items = (List<IngredientTemplateItem>)ingredients_DataGrid.ItemsSource;
            //items.Add(new IngredientTemplateItem());
            //ingredients_DataGrid.ItemsSource = null;
            //ingredients_DataGrid.ItemsSource = items;
        }

        private void Delete_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = (ingredients_ListBox.SelectedIndex != -1) && read;
        }

        private void Delete_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            List<TemplateItem> items = (List<TemplateItem>)ingredients_ListBox.ItemsSource;
            items.RemoveAt(ingredients_ListBox.SelectedIndex);
            ingredients_ListBox.ItemsSource = null;
            ingredients_ListBox.ItemsSource = items;
        }

        private void Save_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = read;
        }

        private void Save_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            //ingredientDataAccessService.Write(
            //    Converter.ToIngredients((List<IngredientTemplateItem>)ingredients_DataGrid.ItemsSource));                   // DEBUG using BAL
            //MessageBox.Show("Data were written down successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
