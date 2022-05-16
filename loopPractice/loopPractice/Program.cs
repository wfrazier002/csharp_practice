using System;

namespace loopPractice {
    class Program {
        static void Main(string[] args) {

            //Challenge1();
            //Challenge2();
            Challenge3();
        }

        private static void Challenge1() {
            /*
             * in this challenge, create a loop that prints out the odd numbers from 0 - 20
             */
            for (int counter = 0; counter < 20; counter++) {
                if (counter%2 != 0) {
                    Console.WriteLine("this number is odd: {0}", counter);
                }
            }
        }
        private static void Challenge2() {
            /*
             * create a loop where the user presses enter (nothing there; empty string), it 
             * increments a counter and prints it out;
             * put a note at beginning to say type stop to close/end program
             */
            Console.WriteLine("Hello, this program will count the number of ppl by clicking enter.");
            Console.WriteLine("if you want it to stop, just type something in before hitting enter");
            int pplCounter = 0;
            string input = "";
            while (input == "") {
                Console.WriteLine("do you want to increment the counter? if yes, click enter:");
                input = Console.ReadLine();
                if(input == "") {
                    pplCounter++;
                    Console.WriteLine("number of ppl so far is: {0}", pplCounter);
                }  
            }
            Console.WriteLine("the total number of ppl counted is {0}", pplCounter);
        }

        private static void Challenge3() {
            /*
         * Challenge - Loops 1 - Average
            Imagine you are a developer and get a job in which you need to create a program for a teacher. He needs a program written in c# that calculates the average score of his students. So he wants to be able to enter each score individually and then get the final average score once he enters -1.
            So the tool should check if the entry is a number and should add that to the sum. Finally once he is done entering scores, the program should write onto the console what the average score is.
            The numbers entered should only be between 0 and 20. Make sure the program doesn't crash if the teacher enters an incorrect value.
            Test your program thoroughly.
         */
            string userInput = "";
            int average = 0, sum = 0, number = 0, countNumberGrades = 0;
            Console.WriteLine("Hello, welcome to the program used to average grades.");
            while (userInput != "-1") {
                Console.WriteLine("Please enter a number for the grade, or -1 if you are done entering in the numbers:");
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out number)) {
                    if (number >= 0 && number <= 20) {
                        sum += number;
                        countNumberGrades++;
                    } else if (number == -1) {
                        break;
                    } else {
                        Console.WriteLine("the number you entered was either too large or too small. please enter a number between 0 and 20");
                    }
                } else {
                    Console.WriteLine("You did not enter a number, please try again");
                }
            }
            if (countNumberGrades > 0) {
                average = sum / countNumberGrades;
            }
            
            Console.WriteLine("the average grade for what you entered is: {0}", average);
        }
        
    }
}
