using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismOOP {
    class Car {
        public int HP { get; set; }
        public string Color { get; set; }

        // Car 'has a' caridinfo
        protected CarIDInfo carIDInfo = new CarIDInfo();

        // method to set the has a prop
        public void SetCarIDInfo(int idNum, string owner) {
            carIDInfo.IDNum = idNum;
            carIDInfo.Owner = owner;
        }
        // method to get teh info from the prop
        public void GetCarIDInfo() {
            Console.WriteLine("the car has an id of {0} and {1} is the owner", carIDInfo.IDNum, carIDInfo.Owner);
        }

        public Car(int hp, string color) {
            this.HP = hp;
            this.Color = color;
        }
        public virtual void ShowDetails() {
            Console.WriteLine("the hp for this car is: {0}, and the color is: {1}", HP, Color);
        }
        public virtual void Repair() {
            Console.WriteLine("Car was repaired!");
        }
    }
}
