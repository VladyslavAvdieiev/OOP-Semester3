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
using System.Windows.Shapes;
using System.IO;

namespace PresentationLayer.GraphicalUserInterface
{
    /// <summary>
    /// Interaction logic for IngredientsDesigner.xaml
    /// </summary>
    public partial class IngredientsDesigner : Window {
        private bool read;
        private List<Ingredient> ingredientSource;
        private DataAccessService<List<Ingredient>> ingredientDataAccessService;

        /// <summary>
        /// Default constructor
        /// </summary>
        public IngredientsDesigner() {
            InitializeComponent();
            if (LoadIngredientsFromDB(Properties.Settings.Default.Ingredients_Path))
                LoadIngredientItems();
        }

        /// <summary>
        /// Read ingredients from xml file
        /// </summary>
        private bool LoadIngredientsFromDB(string path) {
            try {
                ingredientDataAccessService = new XmlSerializerService<List<Ingredient>>(path);                             // DEBUG use BAL
                ingredientSource = ingredientDataAccessService.Read();                                                      // DEBUG use BAL
                return read = true;
            } catch (FileNotFoundException e) {
                MessageBox.Show($"Error:\n{e.Message}\n\nSet path to file in Settings - Edit File Paths",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return read = false;
            }
        }

        /// <summary>
        /// Add ingredients from source to window
        /// </summary>
        private void LoadIngredientItems() {
            ingredients_DataGrid.ItemsSource = Converter.ToIngredientTemplateItem(ingredientSource);
        }

        /// <summary>
        /// CanExecute event
        /// </summary>
        private void Add_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = read;
        }

        /// <summary>
        /// Add new item to window
        /// </summary>
        private void Add_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            List<IngredientTemplateItem> items = (List<IngredientTemplateItem>)ingredients_DataGrid.ItemsSource;
            items.Add(new IngredientTemplateItem());
            ingredients_DataGrid.ItemsSource = null;
            ingredients_DataGrid.ItemsSource = items;
        }

        /// <summary>
        /// CanExecute event
        /// </summary>
        private void Delete_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = (ingredients_DataGrid.SelectedIndex != -1) && (ingredients_DataGrid.SelectedIndex < ingredients_DataGrid.Items.Count - 1) && read;
        }

        /// <summary>
        /// Delete selected item from window
        /// </summary>
        private void Delete_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            MessageBoxResult result = MessageBox.Show("Do you want to remove this item?", "Deletion",
                                                  MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes) {
                List<IngredientTemplateItem> items = (List<IngredientTemplateItem>)ingredients_DataGrid.ItemsSource;
                items.RemoveAt(ingredients_DataGrid.SelectedIndex);
                ingredients_DataGrid.ItemsSource = null;
                ingredients_DataGrid.ItemsSource = items;
            }
        }

        /// <summary>
        /// CanExecute event
        /// </summary>
        private void Save_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = read;
        }

        /// <summary>
        /// Write down data to xml file
        /// </summary>
        private void Save_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            ingredientDataAccessService.Write(
                Converter.ToIngredients((List<IngredientTemplateItem>)ingredients_DataGrid.ItemsSource));                   // DEBUG using BAL
            MessageBox.Show("Data were written down successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
