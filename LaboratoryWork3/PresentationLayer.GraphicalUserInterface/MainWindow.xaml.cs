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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer.GraphicalUserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        List<Student> students;
        List<Teacher> teachers;

        public MainWindow() {
            InitializeComponent();
            students = new List<Student>();
            teachers = new List<Teacher>();
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
                if (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString() == "Student") {
                    students.Add(new Student(new Name("Default", "Default", "Default"),
                        new DateTime(2000, 1, 1), "AA000000", Courses.NotAStudent, Groups.NotAStudent));
                    objects_DataGrid.ItemsSource = null;
                    objects_DataGrid.ItemsSource = students;
                }
                else if (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString() == "Teacher") {
                    teachers.Add(new Teacher(new Name("Default", "Default", "Default")));
                    objects_DataGrid.ItemsSource = null;
                    objects_DataGrid.ItemsSource = teachers;
                }
            condition_TextBox.Foreground = Brushes.Green;
            condition_TextBox.Text = "Object has added.";
        }

        private bool CheckSelection() {
            if (entitiesTypes_ComboBox.SelectedIndex == 0)
                entities_Border.BorderBrush = Brushes.Red;
            if (serializationTypes_ComboBox.SelectedIndex == 0)
                serialization_Border.BorderBrush = Brushes.Red;
            return !(entitiesTypes_ComboBox.SelectedIndex == 0 || serializationTypes_ComboBox.SelectedIndex == 0);
        }

        private void Read_Button_Click(object sender, RoutedEventArgs e) {
            if (CheckSelection())
                if (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString() == "Student") {
                    DataAccessService<List<Student>> service = null;
                    if (serializationTypes_ComboBox.SelectedIndex == 1)
                        service = new BINARYSerializerService<List<Student>>();
                    else if (serializationTypes_ComboBox.SelectedIndex == 2)
                        service = new JSONSerializerService<List<Student>>();
                    else if (serializationTypes_ComboBox.SelectedIndex == 3)
                        service = new SOAPSerializerService<List<Student>>();
                    else if (serializationTypes_ComboBox.SelectedIndex == 4)
                        service = new XMLSerializerService<List<Student>>();
                    try {
                        objects_DataGrid.ItemsSource = students = service.Read();
                        condition_TextBox.Foreground = Brushes.Green;
                        condition_TextBox.Text = "Data have read.";
                    } catch (System.IO.FileNotFoundException ex) {
                        condition_TextBox.Foreground = Brushes.Red;
                        condition_TextBox.Text = ex.Message;
                    }
                }
                else if (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString() == "Teacher") {
                    DataAccessService<List<Teacher>> service = null;
                    if (serializationTypes_ComboBox.SelectedIndex == 1)
                        service = new BINARYSerializerService<List<Teacher>>();
                    else if (serializationTypes_ComboBox.SelectedIndex == 2)
                        service = new JSONSerializerService<List<Teacher>>();
                    else if (serializationTypes_ComboBox.SelectedIndex == 3)
                        service = new SOAPSerializerService<List<Teacher>>();
                    else if (serializationTypes_ComboBox.SelectedIndex == 4)
                        service = new XMLSerializerService<List<Teacher>>();
                    try {
                        objects_DataGrid.ItemsSource = teachers = service.Read();
                        condition_TextBox.Foreground = Brushes.Green;
                        condition_TextBox.Text = "Data have read.";
                    } catch (System.IO.FileNotFoundException ex) {
                        condition_TextBox.Foreground = Brushes.Red;
                        condition_TextBox.Text = ex.Message;
                    }
                }
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e) {
            if (objects_DataGrid.SelectedIndex == -1) {
                condition_TextBox.Text = "Choose any row.";
                return;
            }
            if (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString() == "Student") {
                students.Remove((Student)objects_DataGrid.SelectedItem);
                objects_DataGrid.ItemsSource = null;
                objects_DataGrid.ItemsSource = students;
            }
            else if (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString() == "Teacher") {
                teachers.Remove((Teacher)objects_DataGrid.SelectedItem);
                objects_DataGrid.ItemsSource = null;
                objects_DataGrid.ItemsSource = teachers;
            }
            condition_TextBox.Foreground = Brushes.Green;
            condition_TextBox.Text = "Object has removed.";
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e) {
            if (CheckSelection())
                if (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString() == "Student") {
                    DataAccessService<List<Student>> service = null;
                    if (serializationTypes_ComboBox.SelectedIndex == 1)
                        service = new BINARYSerializerService<List<Student>>();
                    else if (serializationTypes_ComboBox.SelectedIndex == 2)
                        service = new JSONSerializerService<List<Student>>();
                    else if (serializationTypes_ComboBox.SelectedIndex == 3)
                        service = new SOAPSerializerService<List<Student>>();
                    else if (serializationTypes_ComboBox.SelectedIndex == 4)
                        service = new XMLSerializerService<List<Student>>();
                    if (objects_DataGrid.ItemsSource != null) {
                        service.Write((List<Student>)objects_DataGrid.ItemsSource);
                        condition_TextBox.Foreground = Brushes.Green;
                        condition_TextBox.Text = "Data have saved.";
                    }
                    else {
                        condition_TextBox.Foreground = Brushes.Red;
                        condition_TextBox.Text = "Data have not saved.";
                    }
                }
                else if (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString() == "Teacher") {
                    DataAccessService<List<Teacher>> service = null;
                    if (serializationTypes_ComboBox.SelectedIndex == 1)
                        service = new BINARYSerializerService<List<Teacher>>();
                    else if (serializationTypes_ComboBox.SelectedIndex == 2)
                        service = new JSONSerializerService<List<Teacher>>();
                    else if (serializationTypes_ComboBox.SelectedIndex == 3)
                        service = new SOAPSerializerService<List<Teacher>>();
                    else if (serializationTypes_ComboBox.SelectedIndex == 4)
                        service = new XMLSerializerService<List<Teacher>>();
                    if (objects_DataGrid.ItemsSource != null) {
                        service.Write((List<Teacher>)objects_DataGrid.ItemsSource);
                        condition_TextBox.Foreground = Brushes.Green;
                        condition_TextBox.Text = "Data have saved.";
                    }
                    else {
                        condition_TextBox.Foreground = Brushes.Red;
                        condition_TextBox.Text = "Data have not saved.";
                    }
                }
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
    }
}
