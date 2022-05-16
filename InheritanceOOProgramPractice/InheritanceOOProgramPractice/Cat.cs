using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceOOProgramPractice {
    class Cat : Animal {
        public bool InTheMood { get; set; }
        public Cat(string name, int age) : base(name, age) {
            InTheMood = true;
        }

        public override void MakeSound() {
            base.MakeSound();
            Console.WriteLine("meoow");
        }

        public override void Play() {
            if (InTheMood) {
                base.Play();
            }
        }
    }
}
