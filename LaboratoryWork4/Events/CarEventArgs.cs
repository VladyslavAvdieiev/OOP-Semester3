using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class CarEventArgs : EventArgs {
        public string Message { get; }
        public double CurrentFuel { get; }
        public CarEventArgs(string message, double currentFuel) {
            Message = message;
            CurrentFuel = currentFuel;
        }
    }
}
