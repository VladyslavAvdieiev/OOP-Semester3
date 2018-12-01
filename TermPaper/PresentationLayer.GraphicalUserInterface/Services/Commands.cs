using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationLayer.GraphicalUserInterface
{
    public static class Commands {
        public static RoutedCommand Add { get; set; }
        public static RoutedCommand Delete { get; set; }
        public static RoutedCommand Save { get; set; }
        public static RoutedCommand Esc { get; set; }

        static Commands() {
            Add = new RoutedCommand("Add", typeof(MainWindow));
            Delete = new RoutedCommand("Delete", typeof(MainWindow));
            Save = new RoutedCommand("Save", typeof(MainWindow));
            Esc = new RoutedCommand("Esc", typeof(MainWindow));
        }
    }
}
