using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsPractice {
    // test class to show off how hashtables work
    class Student {
        public int Id { get; set; }
        public string Name { get; set; }
        public float GPA { get; set; }

        public Student (int id, string name, float gpa) {
            this.Id = id;
            this.Name = name;
            this.GPA = gpa;
        }
    }
}
