using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceOOProgramPractice {
    class Dog : Animal {
        public bool IsHappy { get; private set; }
        public Dog(string name, int age): base(name, age) {
            IsHappy = true;
        }

        public override void MakeSound() {
            base.MakeSound();
            Console.WriteLine("wuuf");
        }

        public override void Play() {
            if (IsHappy) {
                base.Play();
            }
            
        }
    }
}
