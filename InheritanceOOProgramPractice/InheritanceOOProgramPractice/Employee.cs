using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceOOProgramPractice {
    class Employee {
        public string Name { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }

        public Employee(string name, string lastName, double salary) {
            this.Name = name;
            this.LastName = lastName;
            this.Salary = salary;
        }

        public virtual void Work() {
            Console.WriteLine("I work 40 hrs a week as an employee.");
        }
        public void Pause() {
            Console.WriteLine("i'm on break here!");
        }
    }
}
