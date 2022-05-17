using System;

namespace ObjectOrientedProgrammingPractice {
    class Program {
        static void Main(string[] args) {
            // ex of created object of created class; also called an instance of that class
            /*Human denis = new Human();
            denis.setFirstName("Denis");
            denis.IntroduceYourself();
            Human micheal = new Human();
            micheal.IntroduceYourself();
            micheal.setFirstName("micheal");
            micheal.IntroduceYourself();
            Human sheena = new Human("sheena");
            sheena.IntroduceYourself(); */

            /*  Challenge: add 2 more vars to Human - age and eye color
             *  create a constructor that requires all 4 vars
             *  create 2 new objects of type human and initialize w/ all 4 vars
             */
            /*Human shiva = new Human("shiva", "dark", "blue", 3000);
            Human bahamut = new Human("bahamut", "dark", "red", 5009);
            shiva.IntroduceYourself();
            bahamut.IntroduceYourself(); */

            Box box = new Box();
            box.setHeight(10);
            box.setLength(10);
            box.setWidth(10);

            box.DisplayInfo();
        }
    }
}
