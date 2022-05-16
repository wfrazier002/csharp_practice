using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceOOProgramPractice {
    class Animal {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsHungry { get; set; }

        public Animal(string name, int age) {
            this.Age = age;
            // set hungry to default true
            this.IsHungry = true;
            this.Name = name;
        }
        // making it virtual makes it where other classes have to override it when they inherit it
        // you can have something inside a virtual method you will override
        public virtual void MakeSound() {
            Console.Write($"the animal: {this.GetType().Name} named {Name} makes this sound: ");
        }

        public void Eat() {
            if (IsHungry) {
                Console.WriteLine("the animal: {0} named {1} is eating", this.GetType().Name, Name);
            } else {
                Console.WriteLine("the animal: {0} named {1} is not hungry yet", this.GetType().Name, Name);
            }
        }
        // making it virtual makes it where other classes have to override it when they inherit it
        public virtual void Play() {
            Console.WriteLine("the animal {0} named {1} is playing even at age {2}", this.GetType().Name, Name, Age);
        }
    }
}
