using System;
using System.Text.RegularExpressions;

namespace AdvancedCsharpPractice {
    class Program {
        static void Main(string[] args) {
            // access modifiers - for granting/preventing access
            // private
            // can't use it anywhere else outside that class
            // public
            // can be accessed everywhere in the project
            // protected
            // accessible in that class and all child classes

            // rule of thumb - when creating a new class, initially go with the most restrictive
            // modifier, and if need be, change to a lesser restrictive as time goes on if required

            // after setting up the struct, you can now make an instance like you would a class, but you have to fill in the values in order to use it:
            //Game game1;
            //game1.developer = "Nintendo";
            //game1.name = "pokemon gold";
            //game1.rating = 4.5; //out of 5
            //game1.releaseDate = "11/15/2005";
            //// can access the properties in there (if their public)
            ///*Console.WriteLine("game name: {0}", game1.name);
            //Console.WriteLine("game dev: {0}", game1.developer);
            //Console.WriteLine("game rating: {0}", game1.rating);
            //Console.WriteLine("game release date: {0}", game1.releaseDate); */
            //// structs can have methods as well:
            //game1.DisplayInfo();
            // you can't create a general constructor for the struct 
            // however, you can create a defined constructor
            // structs can also have modifiers before them

            // to get more info on structs vs classes, go to this site:
            // https://stackoverflow.com/questions/13049/whats-the-difference-between-struct-and-class-in-net#:~:text=Difference%20between%20Structs%20and%20Classes,to%20an%20object%20in%20memory.

            // enums
            // basically, it's a set of constants
            // they are indexed, so you can call them by their value
            //DayOfWeek friday = DayOfWeek.Fri;
            //DayOfWeek sunday = DayOfWeek.Sun;

            //Console.WriteLine("day is {0}, {1}, or num version: {2} {3}", friday, sunday, (int)friday, (int)sunday);
            //// you can reassign the index values in the enum as well, like instead of mon = 0 like it does by default, you could say mon = 20 and everything after will count after 20
            //Console.WriteLine("new indexes are: {0} {1}", (int)DayOfWeekDiffIndex.Mon, (int)DayOfWeekDiffIndex.Sat);

            //// Math class - there are a lot of functions in Math you can use
            //int ipie = (int)Math.PI;
            //float fpie = (float)Math.PI;
            //double dpie = (double)Math.PI;
            //long lpie = (long)Math.PI;
            //Console.WriteLine("different versions of pi: {0}, {1}, {2}, {3}", ipie, fpie, dpie, lpie);

            // random class - randomize a number btw a range you specify: can have no inputs, in which it does a positive number btw 0 and the max value of an int32, which is 2147483647; 1 input, which is the max the number can be, so then the range is from 0 to the number you give; or 2 inputs, which gives the range you want the number to be in (from the min to the max)

            // Challenge:
            //Challenge1();

            // regular expressions
            // Challenge:
            // find link using reg expression:
            /*
             * 
             * links:
             *   https://www.tutorials.eu
             *   https://tutorials.eu
             *   http://www.tutorials.eu
             *   http://tutorials.eu
             * 
             * 1: find both http and https link w/ www in it
             * type this in find: http(s)?://www.tutorials.eu
             * 
             * 2: find both https links w/ and w/o www
             * type this in find: https://(www.)?tutorials.eu
             */
            // Challenge:
            // find the group of numbers
            /*
             * numbers to find:
             *   0175/12345678
             *   +49165/12312347
             *   0049165/12312347
             * 
             * type this in find: (\d)*(\d\d\d\d)(/)?\d\d\d\d\d\d\d\d
             * 
             * Challenge:
             * using the above numbs, highlight them as a german phone #
             * (starts w/ 0, +49, or 0049, then has 1, then either 7 or 6, then any number, then a \, then 8 numbers
             * 
             * type this in find: [\+]?(0|49|0049)[1][6|7]\d[/]\d\d\d\d\d\d\d\d
             *           or this: [\+]?(0|49|0049)[1][6|7]\d[/]\d{8}
             */
            // to use regex in C#, you have to import it w/ a using stmt
            // using System.Text.RegularExpressions;
            // then make a variable of type Regex
            // using a pattern you want to use in regular expression
            //string pattern = @"\d";
            //Regex regex = new Regex(pattern);

            //string testString = ";2345;lhj098uf23kl34";

            //MatchCollection matchCollection = regex.Matches(testString);
            //Console.WriteLine("here are all the nums from the test string: {0}", testString);
            //Console.WriteLine("number of matches: {0}", matchCollection.Count);
            //Console.WriteLine("here is a match found:");
            //foreach (Match aMatch in matchCollection) {
            //    Console.Write(" {0}", aMatch.Value);
            //}

            // datetime
            // Challenge:
            // which day of the week is it? find out w/ datetime
            //DateTime nDateTime = DateTime.Now;
            //Console.WriteLine("today's date is: {0}", nDateTime);
            //Console.WriteLine("the day of teh week for today is: {0}", nDateTime.DayOfWeek);

            //// Challenge:
            //// display 1700 w/ 33 min and 15 sec onto the console
            ////DateTime aTime = DateTime.Now.Add(new TimeSpan(17, 33, 15)); -- didn't work
            //DateTime aTime = DateTime.Parse("17:33:15");// gives now for date, but changes time to what is input
            //Console.WriteLine("the time is: {0}", aTime);

            // Nullables
            // variables that 'can have a value' or don't have a value
            // nullables are variables of multiple types w/ a ? after the type declaration

            // ex:
            //int? aIntNullable = null;
            ////int aInt = null;  <-- this won't work as there is no ? after type declaration
            //string? aStringNullable = null;
            //string aString = null; // an exception to the rule is that strings can be null
            //double? aDoubleNullable = null;
            ////double aDouble = null; <-- this won't work as there is no ? after type declaration
            //// can also add values to nullables:
            //int? aIntNullable2 = 3;
            //double? aDoubleNullable2 = Math.PI;

            // garbage collector
            // .net framework provides automatic functions for resource mgmnt, so you don't have to invoke the garbage collector manually

            // Main method args
            // 2 ways to provide it: either in the options part of VS, or user input

        }

        private static void Challenge1() {

            // for this challenge, create a program that takes input in from a user, then
            // responds w/ yes, no, maybe - have the yes = 1, no = 3, and maybe = 2, then have 
            // the program choose between those 3 using random
            string uInput = "";
            Random dice = new Random();
            int number = 0;
            string fortune = "";
            while (uInput.ToLower() != "stop") {
                Console.WriteLine("Please enter a question for our fortune teller!");
                uInput = Console.ReadLine();

                if (uInput.ToLower() != "stop" && uInput != "") {
                    number = dice.Next(1, 4);
                    switch (number) {
                        case 1:
                            fortune = "Yes!";
                            break;
                        case 2:
                            fortune = "Maybe!";
                            break;
                        case 3:
                            fortune = "No!";
                            break;
                    }
                    if (fortune != "") {
                        Console.WriteLine(fortune);
                    }
                }
            }
        }
    }
    // classes are reference types, while structs are value types
    // you can create an empty class, but a struct has to have a value in it
    // struct is defined outside a class
    // ex:
    struct Game {
        public string developer;
        public string name;
        public double rating;
        public string releaseDate;

        public void DisplayInfo() {
            Console.WriteLine("game name: {0}", name);
            Console.WriteLine("game dev: {0}", developer);
            Console.WriteLine("game rating: {0}", rating);
            Console.WriteLine("game release date: {0}", releaseDate);
        }
    }

    // enum example: days of the week and weekdays
    enum DayOfWeek { Mon, Tues, Wed, Thurs, Fri, Sat, Sun};
    enum WorkDays { Mon, Tues, Wed, Thurs, Fri};
    enum DayOfWeekDiffIndex { Mon=20, Tues, Wed, Thurs, Fri, Sat, Sun };
}
