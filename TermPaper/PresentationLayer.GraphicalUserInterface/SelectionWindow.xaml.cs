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
    /// Interaction logic for SelectionWindow.xaml
    /// </summary>
    public partial class SelectionWindow : Window {
        private Item currentItem;
        private List<Ingredient> ingredientSource;
        private DataAccessService<List<Ingredient>> ingredientDataAccessService;
        private List<Dish> dishSource;
        private DataAccessService<List<Dish>> dishDataAccessService;

        public enum Item { Ingredients, Dishes };
        /// <summary>
        /// Chosen ingredient
        /// </summary>
        public Ingredient ChosenIngredient { get; set; }
        /// <summary>
        /// Chosen dish
        /// </summary>
        public Dish ChosenDish { get; set; }

        /// <summary>
        /// Constructor with parameter
        /// </summary>
        public SelectionWindow(Item item) {
            InitializeComponent();
            currentItem = item;
            if (item == Item.Ingredients) {
                if (LoadIngredientsFromDB(Properties.Settings.Default.Ingredients_Path))
                    LoadIngreditntItems();
            }
            else if (item == Item.Dishes) {
                if (LoadDishesFromDB(Properties.Settings.Default.Dishes_Path))
                    LoadDishItems();
            }
        }

        /// <summary>
        /// Read ingredients from xml file
        /// </summary>
        private bool LoadIngredientsFromDB(string path) {
            try {
                ingredientDataAccessService = new XmlSerializerService<List<Ingredient>>(path);                             // DEBUG use BAL
                ingredientSource = ingredientDataAccessService.Read();                                                      // DEBUG use BAL
                return true;
            } catch (FileNotFoundException e) {
                MessageBox.Show($"Error:\n{e.Message}\n\nSet path to file in Settings - Edit File Paths",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
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
        /// Read dishes from xml file
        /// </summary>
        private bool LoadDishesFromDB(string path) {
            try {
                dishDataAccessService = new XmlSerializerService<List<Dish>>(path);                                         // DEBUG use BAL
                dishSource = dishDataAccessService.Read();                                                                  // DEBUG use BAL
                return  true;
            } catch (FileNotFoundException e) {
                MessageBox.Show($"Error:\n{e.Message}\n\nSet path to file in Settings - Edit File Paths",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return  false;
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
        /// Load desired window to edit or choose
        /// </summary>
        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            int index = -1;
            string content = ((ListBoxItem)sender).Content.ToString();
            while (++index < items_ListBox.Items.Count && content != (string)items_ListBox.Items[index]) ;
            if (currentItem == Item.Ingredients)
                SetIngredient(index);
            else if (currentItem == Item.Dishes)
                SetDish(index);
        }

        /// <summary>
        /// Find index of clicked item and set chosen ingredient
        /// </summary>
        private void SetIngredient(int index) {
            ChosenIngredient = ingredientSource[index];
            Close();
        }

         /// <summary>
        /// Find index of clicked item and set chosen dish
        /// </summary>
        private void SetDish(int index) {
            ChosenDish = dishSource[index];
            Close();
        }
    }
}
