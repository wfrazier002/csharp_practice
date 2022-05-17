using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismOOP {
    class BMW : Car {
        public string Model { get; set; }
        private string brand = "BMW";

        public BMW(int hp, string color, string model) : base(hp, color) {
            this.Model = model;
        }

        public override void ShowDetails() {
            Console.WriteLine("the hp for this car is: {0}, the color is: {1}, it's brand is: {2}, and it's model is: {3}", HP, Color, brand, Model);
        }

        public override void Repair() {
            Console.WriteLine("The {0} model Car was repaired!", Model);
        }

    }
}
