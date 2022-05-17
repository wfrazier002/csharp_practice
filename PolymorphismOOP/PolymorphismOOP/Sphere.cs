using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismOOP {
    class Sphere : Shape {
        public double Radius { get; set; }

        public Sphere(double radius) {
            this.Radius = radius;
            Name = "Sphere";
        }

        public override double Volume() {
            // volumn in this case will be 4/3 pie r^3
            return (4 * Math.PI * Math.Pow(Radius, 3)) / 3;
        }

        public override void GetInfo() {
            base.GetInfo();
            Console.WriteLine("The {0} has a length of {1}, and a volume of {2}", Name, Radius, Volume());
        }
    }
}
