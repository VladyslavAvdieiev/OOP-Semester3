using System;
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
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void EntitiesTypes_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            entities_Border.BorderBrush = Brushes.White;
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem comboBoxItem = (ComboBoxItem)comboBox.SelectedItem;
            if (comboBoxItem.Content.ToString() == "- not selected -") {
                objects_DataGrid.ItemsSource = null;
                objects_DataGrid.Columns.Clear();
            }
        }

        private void SerializationTypes_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            serialization_Border.BorderBrush = Brushes.White;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e) {
            if (CheckSelection())
                switch (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString()) {
                    case "Student":
                        //TODO
                        break;
                    case "Teacher":
                        //TODO
                        break;
                }
        }

        private bool CheckSelection() {
            if (entitiesTypes_ComboBox.SelectedIndex == 0)
                entities_Border.BorderBrush = Brushes.Red;
            if (serializationTypes_ComboBox.SelectedIndex == 0)
                serialization_Border.BorderBrush = Brushes.Red;
            return !(entitiesTypes_ComboBox.SelectedIndex == 0 || serializationTypes_ComboBox.SelectedIndex == 0);
        }

        private void Read_Button_Click(object sender, RoutedEventArgs e) {
            if (CheckSelection()) {
                //TODO 
                switch (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString()) {
                    case "Student":
                        //TODO
                        break;
                    case "Teacher":
                        //TODO
                        break;
                }
            }
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e) {
            if (objects_DataGrid.SelectedIndex == -1) {
                error_TextBox.Text = "Choose any row.";
                return;
            }
            switch (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString()) {
                case "Student":
                    //TODO
                    break;
                case "Teacher":
                    //TODO
                    break;
            }
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e) {
            if (CheckSelection()) {
                //TODO
                switch (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString()) {
                    case "Student":
                        //TODO
                        break;
                    case "Teacher":
                        //TODO
                        break;
                }
            }
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
    }
}
