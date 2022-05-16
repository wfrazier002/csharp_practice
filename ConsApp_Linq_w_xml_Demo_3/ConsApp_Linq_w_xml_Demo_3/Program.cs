using System;
using System.Linq;
using System.Xml.Linq;

namespace ConsApp_Linq_w_xml_Demo_3 {
    class Program {
        static void Main(string[] args) {
            // showing how linq can work w/ xml

            string studentsXML = @"<Students>
                                        <Student>
                                            <Name>Bahamut</Name>
                                            <Age>599</Age>
                                            <University>FF</University>
                                            <YearEntered>2025</YearEntered>
                                        </Student>
                                        <Student>
                                            <Name>Killia</Name>
                                            <Age>957</Age>
                                            <University>Disgaea</University>
                                            <YearEntered>2099</YearEntered>
                                        </Student>
                                        <Student>
                                            <Name>Dark</Name>
                                            <Age>XXXX9</Age>
                                            <University>Isekai</University>
                                            <YearEntered>xx99</YearEntered>
                                        </Student>
                                        <Student>
                                            <Name>Shiva</Name>
                                            <Age>697</Age>
                                            <University>Isekai</University>
                                            <YearEntered>xx99</YearEntered>
                                        </Student>
                                   </Students>";

            XDocument studentXDoc = new XDocument();
            // initialize the doc
            studentXDoc = XDocument.Parse(studentsXML);
            // Descendants = filters the doc to only have what you are looking for put into the variable
            var students = from student in studentXDoc.Descendants("Student")
                           select new {
                               sName = student.Element("Name").Value,
                               sAge = student.Element("Age").Value,
                               sUniversity = student.Element("University").Value
                           };
            Console.WriteLine("unsorted list of students:");
            foreach (var student in students) {
                Console.WriteLine("student {0} is {1} yrs old and goes to {2} university", student.sName, student.sAge, student.sUniversity);
            }
            // challenge: sort by age
            // sorting by age
            var sortedStudentsByAge = from student in students orderby student.sAge select student;
            Console.WriteLine("sorted list of students by their age:");
            foreach (var student in sortedStudentsByAge) {
                Console.WriteLine("student {0} is {1} yrs old and goes to {2} university", student.sName, student.sAge, student.sUniversity);
            }

            // challenge: add another piece of info into the xml, then add another student
            // added in the <YearEntered> tag
            var studentsWithYear = from student in studentXDoc.Descendants("Student")
                           select new {
                               sName = student.Element("Name").Value,
                               sAge = student.Element("Age").Value,
                               sUniversity = student.Element("University").Value,
                               sYear = student.Element("YearEntered").Value
                           };
            Console.WriteLine("students w/ their entry yr added:");
            foreach (var student in studentsWithYear) {
                Console.WriteLine("student {0} is {1} yrs old, goes to {2} university, and entered the university in the year {3}", student.sName, student.sAge, student.sUniversity, student.sYear);
            }
        }
    }
}
