using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismOOP {
    class Cube : Shape {

        public double Length { get; set; }

        public Cube(double length) {
            this.Length = length;
            Name = "Cube";
        }

        public override double Volume() {
            // volumn in this case will be length * length * length
            // can implement either return length * length * length
            // or return Math.pow(length, 3) < = = > length * length * length
            return Math.Pow(Length, 3);
        }

        public override void GetInfo() {
            base.GetInfo();
            Console.WriteLine("The {0} has a length of {1}, and a volume of {2}", Name, Length, Volume());
        }
    }
}
