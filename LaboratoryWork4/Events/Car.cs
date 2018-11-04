using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Events
{
    public delegate void CarStateHandler(object sender, CarEventArgs e);

    public class Car {
        private bool canMove;
        private double _fuel;
        public event CarStateHandler StartedMoving;
        public event CarStateHandler StoppedMoving;
        public event CarStateHandler RanOutOfFuel;
        public event CarStateHandler Refueled;

        public double FuelConsumption { get; }

        public double Fuel {
            get => _fuel;
            private set {
                if (value <= 0) {
                    _fuel = 0;
                    RanOutOfFuel?.Invoke(this, new CarEventArgs("Ran out of fuel.", Fuel));
                    StopMoving();
                }
                else
                    _fuel = value;
            }
        }

        public Car(double fuel = 20000, double fuelConsumption = 100) {
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
        }

        public void StartMoving() {
            canMove = true;
            if (Fuel > 0) {
                StartedMoving?.Invoke(this, new CarEventArgs("Car started moving.", Fuel));
                Task.Run(() => Move());
            }
            else
                StartedMoving?.Invoke(this, new CarEventArgs("Car did not start moving. There is no fuel.", Fuel));
        }

        private void Move() {
            while (canMove) {
                Thread.Sleep(1000);
                Fuel -= FuelConsumption;
                // Console.WriteLine(Fuel);
            }
        }

        public void StopMoving() {
            canMove = false;
            StoppedMoving?.Invoke(this, new CarEventArgs("Car stopped moving.", Fuel));
        }

        public void Refuel(double fuel) {
            Fuel += fuel;
            Refueled?.Invoke(this, new CarEventArgs("Car was refueled.", Fuel));
        }
    }
}
