using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceOOProgramPractice {
    class Boss : Employee {
        public string CompanyCar { get; set; }

        public Boss(string name, string lastName, double salary, string companyCar) : base(name, lastName, salary) {
            this.CompanyCar = companyCar;
        }

        public void Lead() {
            Console.WriteLine("as a boss, i lead the team and do all the manager work.");
        }
    }
}
