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
        string studentPath;
        string teacherPath;

        public MainWindow() {
            InitializeComponent();
            students = new List<Student>();
            teachers = new List<Teacher>();
            studentPath = "students.txt";
            teacherPath = "teachers.txt";
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
            if (CheckSelection()) {
                    List<Student> buffer = new List<Student>();
                    foreach (Student student in students)
                        buffer.Add(student);
                    buffer.Add(new Student("Default",  "Default","Default", "01.01.2000", "AA000000", 1));
                    objects_DataGrid.ItemsSource = students = buffer;
                }
                else if (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString() == "Teacher") {
                    List<Teacher> buffer = new List<Teacher>();
                    foreach (Teacher teacher in teachers)
                        buffer.Add(teacher);
                    buffer.Add(new Teacher("Default", "Default", "Default"));
                    objects_DataGrid.ItemsSource = teachers = buffer;
                }
            condition_TextBox.Foreground = Brushes.Green;
            condition_TextBox.Text = "Object has added.";
        }

        private bool CheckSelection() {
            if (entitiesTypes_ComboBox.SelectedIndex == 0)
                entities_Border.BorderBrush = Brushes.Red;
            if (serializationTypes_ComboBox.SelectedIndex == 0)
                serialization_Border.BorderBrush = Brushes.Red;
            if (formats_ComboBox.SelectedIndex == 0)
                formats_Border.BorderBrush = Brushes.Red;
            return !(entitiesTypes_ComboBox.SelectedIndex == 0
                    || serializationTypes_ComboBox.SelectedIndex == 0
                    || formats_ComboBox.SelectedIndex == 0);
        }

        private void Read_Button_Click(object sender, RoutedEventArgs e) {
            if (CheckSelection())
                if (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString() == "Student") {
                    IDataAccessService service = new StudentDataAccessService(studentPath);
                    Person[] people = service.Read(new DefaultFormatParser());
                    List<Student> buffer = new List<Student>();
                    foreach (Person person in people)
                        if (person is Student student)
                            buffer.Add(student);
                    objects_DataGrid.ItemsSource = students = buffer;
                }
                else if (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString() == "Teacher") {
                    IDataAccessService service = new TeacherDataAccessService(teacherPath);
                    Person[] people = service.Read(new DefaultFormatParser());
                    List<Teacher> buffer = new List<Teacher>();
                    foreach (Person person in people)
                        if (person is Teacher teacher)
                            buffer.Add(teacher);
                    objects_DataGrid.ItemsSource = teachers = buffer;
                }
            condition_TextBox.Foreground = Brushes.Green;
            condition_TextBox.Text = "Data have read.";
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e) {
            if (objects_DataGrid.SelectedIndex == -1) {
                condition_TextBox.Text = "Choose any row.";
                return;
            }
            if (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString() == "Student") {
                List<Student> buffer = new List<Student>();
                foreach (Student student in students)
                    buffer.Add(student);
                buffer.Remove((Student)objects_DataGrid.SelectedItem);
                objects_DataGrid.ItemsSource = students = buffer;
            }
            else if (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString() == "Teacher") {
                List<Teacher> buffer = new List<Teacher>();
                foreach (Teacher teacher in teachers)
                    buffer.Add(teacher);
                buffer.Remove((Teacher)objects_DataGrid.SelectedItem);
                objects_DataGrid.ItemsSource = teachers = buffer;
            }
            condition_TextBox.Foreground = Brushes.Green;
            condition_TextBox.Text = "Object has removed.";
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e) {
            if (CheckSelection())if (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString() == "Student") {
                    IDataAccessService service = new StudentDataAccessService(studentPath);
                    if (objects_DataGrid.ItemsSource != null) {
                        service.Clear();
                        List<Student> buffer = (List<Student>)objects_DataGrid.ItemsSource;
                        foreach (Student student in buffer)
                            service.Write(student, new DefaultFormatParser());
                        condition_TextBox.Foreground = Brushes.Green;
                        condition_TextBox.Text = "Data have saved.";
                    }
                    else {
                        condition_TextBox.Foreground = Brushes.Red;
                        condition_TextBox.Text = "Data have not saved.";
                    }
                }
                else if (((ComboBoxItem)entitiesTypes_ComboBox.SelectedItem).Content.ToString() == "Teacher") {
                    IDataAccessService service = new TeacherDataAccessService(teacherPath);
                    if (objects_DataGrid.ItemsSource != null) {
                        service.Clear();
                        List<Teacher> buffer = (List<Teacher>)objects_DataGrid.ItemsSource;
                        foreach (Teacher teacher in buffer)
                            service.Write(teacher, new DefaultFormatParser());
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
