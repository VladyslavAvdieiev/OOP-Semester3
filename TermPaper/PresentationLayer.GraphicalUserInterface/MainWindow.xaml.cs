using System;
using BusinessAccessLayer.Entities;
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

namespace PresentationLayer.GraphicalUserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"C:\Users\Avd\source\repos\OOP-Semester3\TermPaper\PresentationLayer.GraphicalUserInterface\Icons\Food\apple.png");
            bitmap.EndInit();

            List<Template> dishes = new List<Template>();
            dishes.Add(new Template("Bitch lasagna",
                "If you're a vegetarian, leave out the meat and make your lasagna with fat-free" +
                " ricotta cheese, which adds a whopping 40 grams of protein per half-cup.",
                450,
                20,
                new List<Ingredient>() {
                    new Ingredient("Cheese",20,100),
                    new Ingredient("Meet", 120, 80)},
                bitmap,
                new SolidColorBrush(Colors.Orange)));

            dishes_ListBox.ItemsSource = dishes;
        }

        private void NewOrder_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            dishes_ListBox.ItemsSource = null;
        }

        
    }
    class Template
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public double Time { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public BitmapImage Icon { get; set; }
        public SolidColorBrush Background { get; set; }

        public Template(string name, string description, double cost, double time, List<Ingredient> ingredients, BitmapImage icon, SolidColorBrush background)
        {
            Name = name;
            Description = description;
            Cost = cost;
            Time = time;
            Ingredients = ingredients;
            Icon = icon;
            Background = background;
        }
    }
}
