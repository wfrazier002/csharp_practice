using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismOOP {
    abstract class Shape {
        public string Name { get; set; }

        public virtual void GetInfo() {
            Console.WriteLine("this is a {0}", Name);
        }

        public abstract double Volume();
    }
}
