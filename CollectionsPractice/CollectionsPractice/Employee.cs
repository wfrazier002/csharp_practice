using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsPractice {
    class Employee {
        public string Role { get; set; }
        public string Name { get; set; }
        private int Age { get; set; }
        private float Rate { get; set; }

        public float Salary {
            get {
                return Rate * 8 * 5 * 4 * 12; // 8hrs day/ 5 days/wk / 4 wks/month / 12 months/yr
            }
        }
        public Employee (string role, string name, int age, float rate) {
            this.Role = role;
            this.Name = name;
            this.Age = age;
            this.Rate = rate;
        }
    }
}
