using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceOOProgramPractice {
    class Trainee : Employee {
        public int WorkHours { get; set; }
        public int SchoolHours { get; set; }
        public Trainee(string name, string lastName, double salary, int workHours, int schoolHours) : base(name, lastName, salary) {
            this.WorkHours = workHours;
            this.SchoolHours = schoolHours;
        }

        public void Learn() {

        }

        public override void Work() {
            Console.WriteLine("as a trainee:");
            Console.WriteLine("I only work {0} hrs a week", WorkHours);
            Console.WriteLine("since i have {0} hrs of schoolwork a week", SchoolHours);
        }
    }
}
