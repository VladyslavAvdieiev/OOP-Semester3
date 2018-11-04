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
        public event CarStateHandler StopedMoving;
        public event CarStateHandler FuelIsOver;

        public double Fuel {
            get => _fuel;
            private set {
                _fuel = value;
                if (_fuel <= 0) {
                    FuelIsOver?.Invoke(this, new CarEventArgs("Fuel is over", 0));
                    StopMoving();
                }
            }
        }

        public double FuelConsumption { get; }

        public Car(double fuel = 20000, double fuelConsumption = 100) {
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
        }

        public void StartMoving() {
            canMove = true;
            StartedMoving?.Invoke(this, new CarEventArgs("Car started moving", Fuel));
            Move();
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
            StopedMoving?.Invoke(this, new CarEventArgs("Car stopped moving", Fuel));
        }

        public void Refuel(double fuel) {
            Fuel += fuel;
        }
    }
}
