using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingPractice {
    /*  Challenge: add 2 more vars to Human - age and eye color
     *  create a constructor that requires all 4 vars
     *  create 2 new objects of type human and initialize w/ all 4 vars
     */
    class Human {

        // constructors - how the class is initialized
        // can have more than one constructor for different ways  to initialize
        public Human() { }

        public Human(string firstname) {
            firstName = firstname;
        }

        public Human(string firstName, string lastName) {
            // if vars are the same, use this.varname to use the class's var instead
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Human(string firstName, string lastName, string eyeColor, int age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
            this.age = age;
        }

        // members = vars, methods, etc. that are part of a class

        //exs

        // member var
        private string firstName;
        private string lastName;
        private string eyeColor;
        private int age;

        public string getFirstName() {
            return firstName;
        }

        public void setFirstName(string fName) {
            firstName = fName;
        }

        /*public void IntroduceYourself() {
            Console.WriteLine("Hello, my name is {0}", firstName);
        } */
        public void IntroduceYourself() {
            Console.WriteLine("Hello, my name is {0} {1} {2} {3}", firstName, lastName, age, eyeColor);
        }
    }
}
