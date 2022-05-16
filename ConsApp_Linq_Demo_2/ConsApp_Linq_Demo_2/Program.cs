using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsApp_Linq_Demo_2 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            // create 3 classes- university, student, and a class to manage universities
            UniversityManager universityManager = new UniversityManager();
            universityManager.MaleStudents();
            universityManager.FemaleStudents();
            universityManager.SortStudentsByAge();
            universityManager.SortStudentByUniversity();
            try {
                Console.WriteLine("Please type in a university you would like to see the students of:");
                string universityChoice = Console.ReadLine();
                universityManager.StudentsByUniversityName(universityChoice);
            } catch (Exception exception) {
                Console.WriteLine(exception);
            }

            // order and reverse order:
            int[] intList = {1, 5, 2, 99, 999, 9999, -5 };
            IEnumerable<int> orderedList = from anInt in intList orderby anInt select anInt;
            IEnumerable<int> reverseOrderedList = (from anInt in intList orderby anInt select anInt).Reverse();
            // you can also do it by putting descending right after orderby anInt
            // so it would look like this:
            // IEnumerable<int> reverseOrderedList = from anInt in intList orderby anInt descending select anInt;
            Console.WriteLine("ordered list of ints: ");
            foreach (int anInt in orderedList) {
                Console.Write("{0}, ", anInt);
            }
            Console.WriteLine("\nreverse ordered list of ints: ");
            foreach (int anInt in reverseOrderedList) {
                Console.Write("{0}, ", anInt);
            }

            try {
                universityManager.StudentAndUniversityNameCollection();
            } catch (Exception exception) {
                Console.WriteLine(exception);
            }
        }
    }
}
