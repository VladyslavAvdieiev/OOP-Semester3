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

        static Commands() {
            Add = new RoutedCommand("Add", typeof(IngredientsDesigner));
            Delete = new RoutedCommand("Delete", typeof(IngredientsDesigner));
            Save = new RoutedCommand("Save", typeof(IngredientsDesigner));
        }
    }
}
