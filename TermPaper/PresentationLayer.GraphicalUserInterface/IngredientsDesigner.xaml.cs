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

        public IngredientsDesigner() {
            InitializeComponent();
            if (LoadIngredientsFromDB(Properties.Settings.Default.Ingredients_Path))
                LoadIngredientItems();
        }

        /// <summary>
        /// Reading ingredients from xml file
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
        /// Adding ingredients from xml file to window
        /// </summary>
        private void LoadIngredientItems() {
            ingredients_DataGrid.ItemsSource = Converter.ToIngredientTemplateItem(ingredientSource);
        }

        private void Add_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = read;
        }

        private void Add_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            List<IngredientTemplateItem> items = (List<IngredientTemplateItem>)ingredients_DataGrid.ItemsSource;
            items.Add(new IngredientTemplateItem());
            ingredients_DataGrid.ItemsSource = null;
            ingredients_DataGrid.ItemsSource = items;
        }

        private void Delete_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = (ingredients_DataGrid.SelectedIndex != -1) && read;
        }

        private void Delete_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            List<IngredientTemplateItem> items = (List<IngredientTemplateItem>)ingredients_DataGrid.ItemsSource;
            items.RemoveAt(ingredients_DataGrid.SelectedIndex);
            ingredients_DataGrid.ItemsSource = null;
            ingredients_DataGrid.ItemsSource = items;
        }

        private void Save_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = read;
        }

        private void Save_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            ingredientDataAccessService.Write(
                Converter.ToIngredients((List<IngredientTemplateItem>)ingredients_DataGrid.ItemsSource));                   // DEBUG using BAL
            MessageBox.Show("Data were written down successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
