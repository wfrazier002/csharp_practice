using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Practice_Linq_Sql {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        // using instead of sql connection
        LinqToSqlDataClassesDataContext dataContext;

        public MainWindow() {
            InitializeComponent();
            // connection string for the db
            string connectionString = ConfigurationManager.ConnectionStrings["Wpf_Practice_Linq_Sql.Properties.Settings.WPFTESTSQL_MDFConnectionString"].ConnectionString;
            dataContext = new LinqToSqlDataClassesDataContext(connectionString);

            //InsertUniversities();
            //InsertStudents();
            //InsertLectures();
            //InsertStudentsIntoLectures();
            ////GetUniversityOfStudentX("X");
            //GetUniversityOfStudentX("Dark");
            ////GetUniversityOfStudentX("Killia");
            //GetAllLecturesForStudentX("Dark");
            //GetAllStudentsOfUniversityX("FF");
            //GetAllUniversitiesWithMales();
            //// TODO: give a list of info for updating a student
            //// also finish the update func
            //// change bmut to bahamut
            //// change female to male
            //// change age to another #
            //string studentToUpdate = "Bmut";
            //List<KeyValuePair<string, object>> listOfUpdatesForAStudent = new List<KeyValuePair<string, object>>();
            //listOfUpdatesForAStudent.Add(new KeyValuePair<string, object>(
            //    "Name", "Bahamut"));
            //listOfUpdatesForAStudent.Add(new KeyValuePair<string, object>(
            //    "Gender", "Male"));
            //listOfUpdatesForAStudent.Add(new KeyValuePair<string, object>(
            //    "Age", 958));
            //UpdateStudent(studentToUpdate, listOfUpdatesForAStudent);
            //DeleteStudent("Bmut");
        }

        public void InsertUniversities() {
            try {
                // this class was created by opening the .dbml file, then dragging University from server explorer into it
                University ffUni = new University();
                ffUni.Name = "FF";
                if (!dataContext.Universities.Any(uname => uname.Name == ffUni.Name)) {
                    dataContext.Universities.InsertOnSubmit(ffUni);
                }
                University disgaeaUni = new University();
                disgaeaUni.Name = "Disgaea";
                if (!dataContext.Universities.Any(uname => uname.Name == disgaeaUni.Name)) {
                    dataContext.Universities.InsertOnSubmit(disgaeaUni);
                }
                University isekaiUni = new University();
                isekaiUni.Name = "Isekai";
                if (!dataContext.Universities.Any(uname => uname.Name == isekaiUni.Name)) {
                    dataContext.Universities.InsertOnSubmit(isekaiUni);
                }
                dataContext.SubmitChanges();
                // this shows the data from the university table in the data grid named maindatagrid
                MainDataGrid.ItemsSource = dataContext.Universities;
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            
        }

        public void InsertStudents() {
            try {
                //dataContext.ExecuteCommand("delete from Student");
                //dataContext.ExecuteCommand("DBCC CHECKIDENT ('Student', RESEED, 1)");
                // this class was created by opening the .dbml file, then dragging University from server explorer into it
                Student stud1 = new Student();
                stud1.Name = "Killia";
                stud1.Age = 987;
                stud1.Gender = "male";
                University aUni1 = dataContext.Universities.First(uni => uni.Name == "Disgaea");
                stud1.UniversityId = aUni1.Id;
                //if (!dataContext.Students.Where(student1 => student1.Name == stud1.Name && student1.Age == stud1.Age && student1.Gender == stud1.Gender && student1.Id == stud1.UniversityId).Any()) {
                if (!dataContext.Students.Where(student1 => student1.Name == stud1.Name).Any()) {
                    dataContext.Students.InsertOnSubmit(stud1);
                }
                Student stud2 = new Student();
                stud2.Name = "Shiva";
                stud2.Age = 587;
                stud2.Gender = "female";
                University aUni2 = dataContext.Universities.First(uni2 => uni2.Name == "FF");
                stud2.UniversityId = aUni2.Id;
                //if (!dataContext.Students.Where(student2 => student2.Name == stud2.Name && student2.Age == stud2.Age && student2.Gender == stud2.Gender && student2.Id == stud2.UniversityId).Any()) {
                if (!dataContext.Students.Where(student2 => student2.Name == stud2.Name).Any()) {
                    dataContext.Students.InsertOnSubmit(stud2);
                }
                Student stud3 = new Student();
                stud3.Name = "Dark";
                stud3.Age = 9999;
                stud3.Gender = "male";
                University aUni3 = dataContext.Universities.First(uni3 => uni3.Name == "Isekai");
                stud3.UniversityId = aUni3.Id;
                // doesn't work w/ multiple values for some reason
                //if (!dataContext.Students.Where(student3 => student3.Name == stud3.Name && student3.Age == stud3.Age && student3.Gender == stud3.Gender && student3.Id == stud3.UniversityId).Any()) {
                if (!dataContext.Students.Any(student3 => student3.Name == stud3.Name)) {
                    dataContext.Students.InsertOnSubmit(stud3);
                }
                Student stud4 = new Student();
                stud4.Name = "Bmut";
                stud4.Age = 9999;
                stud4.Gender = "male";
                University aUni4 = dataContext.Universities.First(uni4 => uni4.Name == "Isekai");
                stud4.UniversityId = aUni4.Id;
                // doesn't work w/ multiple values for some reason
                //if (!dataContext.Students.Where(student3 => student3.Name == stud3.Name && student3.Age == stud3.Age && student3.Gender == stud3.Gender && student3.Id == stud3.UniversityId).Any()) {
                if (!dataContext.Students.Any(student4 => student4.Name == stud4.Name)) {
                    dataContext.Students.InsertOnSubmit(stud4);
                }

                dataContext.SubmitChanges();
                MainDataGrid.ItemsSource = dataContext.Students;
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }

        }

        public void InsertLectures() {
            try {
                List<Lecture> lectures = new List<Lecture>();
                List<Lecture> lecturesToInsert = new List<Lecture>();
                lectures.Add(new Lecture { Name = "Math 101" });
                lectures.Add(new Lecture { Name = "Science 101" });
                lectures.Add(new Lecture { Name = "History 101" });
                lectures.Add(new Lecture { Name = "Computer Programming 101" });
                lectures.Add(new Lecture { Name = "Drawing 101" });
                lectures.Add(new Lecture { Name = "Martial arts 101" });
                lectures.Add(new Lecture { Name = "Magic 101" });
                lectures.Add(new Lecture { Name = "Physics 101" });
                lectures.Add(new Lecture { Name = "Cooking 101" });
                lectures.Add(new Lecture { Name = "Engineering 101" });
                lectures.Add(new Lecture { Name = "Smithing 101" });
                foreach (Lecture lecture in lectures) {
                    // check to make sure each lecture isn't already in there so you don't insert duplicates
                    if (!dataContext.Lectures.Any(lect => lect.Name == lecture.Name)) {
                        lecturesToInsert.Add(lecture);
                    }
                }
                dataContext.Lectures.InsertAllOnSubmit(lecturesToInsert);
                dataContext.SubmitChanges();
                MainDataGrid.ItemsSource = dataContext.Lectures;

            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        public void InsertStudentsIntoLectures() {
            //Killia, Shiva, Dark
            try {
                Student student1 = dataContext.Students.First(stud => stud.Name == "Killia");
                Student student2 = dataContext.Students.First(stud => stud.Name == "Shiva");
                Student student3 = dataContext.Students.First(stud => stud.Name == "Dark");
                List<StudentLecture> studlectures = new List<StudentLecture>();
                List<StudentLecture> studlecturesToInsert = new List<StudentLecture>();
                studlectures.Add(new StudentLecture { StudentId = student1.Id, LectureId = dataContext.Lectures.First(lect => lect.Name.Contains("Math")).Id});
                studlectures.Add(new StudentLecture { StudentId = student1.Id, LectureId = dataContext.Lectures.First(lect => lect.Name.Contains("History")).Id });
                studlectures.Add(new StudentLecture { StudentId = student1.Id, LectureId = dataContext.Lectures.First(lect => lect.Name.Contains("Cooking")).Id });
                studlectures.Add(new StudentLecture { StudentId = student1.Id, LectureId = dataContext.Lectures.First(lect => lect.Name.Contains("Martial arts")).Id });
                studlectures.Add(new StudentLecture { StudentId = student2.Id, LectureId = dataContext.Lectures.First(lect => lect.Name.Contains("Math")).Id });
                studlectures.Add(new StudentLecture { StudentId = student2.Id, LectureId = dataContext.Lectures.First(lect => lect.Name.Contains("Science")).Id });
                studlectures.Add(new StudentLecture { StudentId = student2.Id, LectureId = dataContext.Lectures.First(lect => lect.Name.Contains("Engineering")).Id });
                studlectures.Add(new StudentLecture { StudentId = student3.Id, LectureId = dataContext.Lectures.First(lect => lect.Name.Contains("Computer Programming")).Id });
                studlectures.Add(new StudentLecture { StudentId = student3.Id, LectureId = dataContext.Lectures.First(lect => lect.Name.Contains("Magic")).Id });
                studlectures.Add(new StudentLecture { StudentId = student3.Id, LectureId = dataContext.Lectures.First(lect => lect.Name.Contains("Engineering")).Id });
                studlectures.Add(new StudentLecture { StudentId = student3.Id, LectureId = dataContext.Lectures.First(lect => lect.Name.Contains("Science")).Id });
                studlectures.Add(new StudentLecture { StudentId = student3.Id, LectureId = dataContext.Lectures.First(lect => lect.Name.Contains("Math")).Id });
                studlectures.Add(new StudentLecture { StudentId = student3.Id, LectureId = dataContext.Lectures.First(lect => lect.Name.Contains("Cooking")).Id });
                studlectures.Add(new StudentLecture { StudentId = student3.Id, LectureId = dataContext.Lectures.First(lect => lect.Name.Contains("Smithing")).Id });
                foreach (StudentLecture slecture in studlectures) {
                    // check to make sure each lecture isn't already in there so you don't insert duplicates
                    if (!dataContext.StudentLectures.Where(slect => slect.LectureId == slecture.LectureId && slect.StudentId == slecture.StudentId).Any()) {
                        studlecturesToInsert.Add(slecture);
                    }
                }
                dataContext.StudentLectures.InsertAllOnSubmit(studlecturesToInsert);
                dataContext.SubmitChanges();
                MainDataGrid.ItemsSource = dataContext.StudentLectures;

            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        // create a method to get the university of a specific student
        public void GetUniversityOfStudentX(string studentXName) {
            // does the student exist?
            try {
                if (dataContext.Students.Any(studx => studx.Name == studentXName) ) {
                    Student studentX = dataContext.Students.First(studx => studx.Name == studentXName);
                    University universityX = dataContext.Universities.First(unix => unix.Id == studentX.UniversityId);
                    MessageBox.Show($"student {studentX.Name} goes to {universityX.Name} university");
                } else {
                    MessageBox.Show("the student {0} doesn't exist", studentXName);
                }
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        public void GetAllLecturesForStudentX(string studentXName) {
            try {
                if (dataContext.Students.Any(studx => studx.Name == studentXName)) {
                    var query = from astudent in dataContext.Students
                        join astudentLecture in dataContext.StudentLectures on astudent.Id equals astudentLecture.StudentId
                        join alecture in dataContext.Lectures on astudentLecture.LectureId equals alecture.Id
                        where astudent.Name == studentXName
                        select new {
                            studentName = astudent.Name,
                            alecture.Name
                        };
                    MainDataGrid.ItemsSource = query;
                } else {
                    MessageBox.Show("the student {0} doesn't exist", studentXName);
                }
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        public void GetAllStudentsOfUniversityX(string universityName) {
            try {
                if (dataContext.Universities.Any(unix => unix.Name == universityName)) {
                    //University universityX = dataContext.Universities.First(unix => unix.Name == universityName);
                    var studentListQuery = from studx in dataContext.Students
                                           join unix in dataContext.Universities on studx.UniversityId equals unix.Id
                                           where unix.Name == universityName
                                      select new {
                                          universityName = unix.Name,
                                          studentName = studx.Name
                                      };
                    MainDataGrid.ItemsSource = studentListQuery;
                } else {
                    MessageBox.Show("the student {0} doesn't exist", universityName);
                }
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        public void GetAllUniversitiesWithMales() {
            try {
                var query = from unix in dataContext.Universities
                            join studx in dataContext.Students on unix.Id equals studx.UniversityId
                            where studx.Gender == "male"
                            select new {
                                uniName = unix.Name,
                                studName = studx.Name,
                                gender = studx.Gender
                            };
                MainDataGrid.ItemsSource = query;
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        public void UpdateStudent(string studentName, List<KeyValuePair<string, object>> listOfUpdates) {
            Student aStudent = dataContext.Students.FirstOrDefault(stud => stud.Name == studentName);
            if (aStudent != null) { 
                string updateName = "", updateGender = "";
                int updateAge = 0;
                bool isAnUpdate = false;
                if (listOfUpdates.Any()) {
                    foreach (KeyValuePair<string, object> objUpdate in listOfUpdates) {
                        switch (objUpdate.Key) {
                            case "Name":
                                //MessageBox.Show(objUpdate.Value.ToString());
                                updateName = objUpdate.Value.ToString();
                                break;
                            case "Gender":
                                //MessageBox.Show(objUpdate.Value.ToString());
                                updateGender = objUpdate.Value.ToString();
                                break;
                            case "Age":
                                //MessageBox.Show(objUpdate.Value.ToString());
                                updateAge = (int)objUpdate.Value;
                                break;
                        }
                    }
                    Student aStudent2 = dataContext.Students.FirstOrDefault(stud => stud.Name == updateName);
                    if (aStudent2 == null) { 
                        if (!String.IsNullOrEmpty(updateName)) {
                            aStudent.Name = updateName;
                            isAnUpdate = true;
                        }
                        if (!String.IsNullOrEmpty(updateGender)) {
                            aStudent.Gender = updateGender;
                            isAnUpdate = true;
                        }
                        if (updateAge != 0) {
                            aStudent.Age = updateAge;
                            isAnUpdate = true;
                        }
                        if (isAnUpdate) {
                            dataContext.SubmitChanges();
                            MainDataGrid.ItemsSource = dataContext.Students;
                        }
                    } else {
                        MessageBox.Show("there was a student w/ the name {0} already in the university records", updateName);
                    }
                }
            } else {
                MessageBox.Show("there was no student w/ the name {0}", studentName);
            }
        }

        public void DeleteStudent(string studentName) {
            if(studentName != null) {
                Student aStudent = dataContext.Students.FirstOrDefault(stud => stud.Name == studentName);
                if (aStudent != null) {
                    dataContext.Students.DeleteOnSubmit(aStudent);
                    dataContext.SubmitChanges();
                    MainDataGrid.ItemsSource = dataContext.Students;
                } else {
                    MessageBox.Show("there was no student w/ the name {0}", studentName);
                }
            } else {
                MessageBox.Show("Please enter a value for a student to be deleted.");
            }
        }
    }
}
