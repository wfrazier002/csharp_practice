using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsApp_Linq_Demo_2 {
    class UniversityManager {
        public List<University> universities;
        public List<Student> students;

        public UniversityManager() {
            universities = new List<University>();
            students = new List<Student>();

            universities.Add(new University { Id = 1, Name = "FF University"});
            universities.Add(new University { Id = 2, Name = "Disgaea University" });
            universities.Add(new University { Id = 3, Name = "Isekai University" });

            students.Add(new Student { Name = "Bahamut", Id = 1, Age = 599, Gender = "female", UniversityId = 1 });
            students.Add(new Student { Name = "Shiva", Id = 2, Age = 399, Gender = "female", UniversityId = 1 });
            students.Add(new Student { Name = "Ifrit", Id = 3, Age = 499, Gender = "male", UniversityId = 1 });
            students.Add(new Student { Name = "Killia", Id = 4, Age = 799, Gender = "male", UniversityId = 2 });
            students.Add(new Student { Name = "Seraphina", Id = 5, Age = 599, Gender = "female", UniversityId = 2 });
            students.Add(new Student { Name = "Dark", Id = 9999, Age = 999, Gender = "male", UniversityId = 3 });
        }

        public void MaleStudents() {
            IEnumerable<Student> maleStudents = from student in students where student.Gender == "male" select student;

            Console.WriteLine("The following students are male: ");
            foreach (Student student in maleStudents) {
                IEnumerable<University> universityX = from university in universities where university.Id == student.UniversityId select university;
                Console.WriteLine("Student {0}, age {1}, goes to {2}", student.Name, student.Age, universityX.First<University>().Name);
            }
        }

        public void FemaleStudents() {
            IEnumerable<Student> femaleStudents = from student in students where student.Gender == "female" select student;

            Console.WriteLine("The following students are female: ");
            foreach (Student student in femaleStudents) {
                IEnumerable<University> universityX = from university in universities where university.Id == student.UniversityId select university;
                Console.WriteLine("Student {0}, age {1}, goes to {2}", student.Name, student.Age, universityX.First<University>().Name);
            }
        }

        public void SortStudentsByAge() {
            var sortedStudents = from student in students orderby student.Age select student;
            Console.WriteLine("students sorted by age:");
            //Console.WriteLine(sortedStudents);
            foreach (Student aStudent in sortedStudents) {
                Console.WriteLine("Student {0} is {1} yrs old", aStudent.Name, aStudent.Age);
            }
        }

        public void SortStudentByUniversity() {
            var sortedStudents = from student in students orderby student.UniversityId select student;
            Console.WriteLine("students sorted by university:");
            foreach (Student aStudent in sortedStudents) {
                var universityX = from university in universities where university.Id == aStudent.UniversityId select university;
                Console.WriteLine("University: {0}, Student {1}", universityX.First<University>().Name, aStudent.Name);
            }
        }

        public void StudentsByUniversityName(string universityChoice) {
            if (!string.IsNullOrEmpty(universityChoice)) {
                var universityX = from university in universities where university.Name.ToLower() == universityChoice.ToLower() select university;
                if (universityX.Any()) {
                    var studentsInSelectUni = from student in students where student.UniversityId == universityX.First<University>().Id select student;
                    foreach (Student aStudent in studentsInSelectUni) {
                        Console.WriteLine("Student {0} is in university {1}", aStudent.Name, universityChoice);
                    }
                } else {
                    Console.WriteLine("Sorry, there is no University w/ the name of {0}.", universityChoice);
                }
            } else {
                Console.WriteLine("Please don't enter an empty value for the university your looking for.");
            }
        }

        // create a new collection that only contains student names and university names - which will be combined from 2 other collections
        public void StudentAndUniversityNameCollection() {
            var newCollection = from student in students
                                join university in universities
                                //where student.UniversityId == university.Id
                                on student.UniversityId equals university.Id
                                orderby student.Name
                                select new { studentName = student.Name, universityName = university.Name};
            Console.WriteLine("the student university collection is:");
            foreach (var item in newCollection) {
                Console.WriteLine("student {0} is in {1}", item.studentName, item.universityName);
            }
        }
    }
}
