using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsApp_Linq_Demo_2 {
    class Student {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        //foreign key
        public int UniversityId { get; set; }

        public void ShowInfo() {
            Console.WriteLine("Student {0} has an Age of {1}, is of {2} gender, their id is {3}, and the University they go to has an id of {4}", Name, Age, Gender, Id, UniversityId);
        }
    }
}
