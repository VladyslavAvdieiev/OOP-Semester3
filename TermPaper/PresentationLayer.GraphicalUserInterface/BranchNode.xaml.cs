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
        private List<Ingredient> ingredientSource;
        private DataAccessService<List<Ingredient>> ingredientDataAccessService;
        private List<Dish> dishSource;
        private DataAccessService<List<Dish>> dishDataAccessService;

        /// <summary>
        /// Chosen ingredient
        /// </summary>
        public Ingredient ChosenIngredient { get; set; }

        /// <summary>
        /// Cpnstructor with parameter
        /// </summary>
        public BranchNode(string obj) {
            InitializeComponent();
            if (obj == "Ingredients") {
                if (LoadIngredientsFromDB(Properties.Settings.Default.Ingredients_Path))
                    LoadIngreditntItems();
            }
            else if (obj == "Dishes") {
                if (LoadDishesFromDB(Properties.Settings.Default.Dishes_Path))
                    LoadDishItems();
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
        private void LoadIngreditntItems() {
            items_ListBox.Items.Clear();
            foreach (Ingredient ingredient in ingredientSource)
                items_ListBox.Items.Add($"{ingredient.Name} - {ingredient.Cost}uah - {ingredient.Weight}gram");
        }

        /// <summary>
        /// Load desired window to edit or choose
        /// </summary>
        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            int index = -1;
            string content = ((ListBoxItem)sender).Content.ToString();
            while (++index < items_ListBox.Items.Count && content != (string)items_ListBox.Items[index]) ;
            if (dishDataAccessService != null)
                DishEdit(index);
            else if (ingredientDataAccessService != null)
                IngredientEdit(index);
        }

        /// <summary>
        /// Find index of clicked item and open DishesDesigner window
        /// </summary>
        private void DishEdit(int index) {
            DishesDesigner dishesDesigner = new DishesDesigner(dishSource[index]);
            dishesDesigner.Show();
            Hide();
            dishesDesigner.Closed += (s, e) => { LoadDishItems(); Show(); };
        }

        /// <summary>
        /// Find index of clicked item and open window to choose ingredient
        /// </summary>
        private void IngredientEdit(int index) {
            ChosenIngredient = ingredientSource[index];
            Close();
        }

        /// <summary>
        /// CanExecute event
        /// </summary>
        private void Add_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = read && (dishDataAccessService != null);
        }

        /// <summary>
        /// Add new item to window
        /// </summary>
        private void Add_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            dishSource.Add(new Dish());
            DishEdit(dishSource.Count - 1);
        }

        /// <summary>
        /// CanExecute event
        /// </summary>
        private void Delete_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = (items_ListBox.SelectedIndex != -1) && read;
        }

        /// <summary>
        /// Delete selected item from window
        /// </summary>
        private void Delete_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            MessageBoxResult result = MessageBox.Show("Do you want to remove this item?", "Deletion",
                                                  MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
                items_ListBox.Items.RemoveAt(items_ListBox.SelectedIndex);
        }

        /// <summary>
        /// CanExecute event
        /// </summary>
        private void Save_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = read && (dishDataAccessService != null);
        }

        /// <summary>
        /// Write down data to xml file
        /// </summary>
        private void Save_Command_Executed(object sender, ExecutedRoutedEventArgs e) {
            dishDataAccessService.Write(dishSource);                                                                        // DEBUG using BAL
            MessageBox.Show("Data were written down successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
