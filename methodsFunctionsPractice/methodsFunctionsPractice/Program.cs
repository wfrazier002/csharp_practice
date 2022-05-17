using System;

namespace methodsFunctionsPractice {
    class Program {
        static void Main(string[] args) {

            // this method won't work as you can't call a non static method from a static method
            //ConsolePrintSomething(); //<--- gives an error b/c it's not static and main is
            // this method can be called in main b/c it is static like main is
            ConsolePrintSomethingStatic();
            //method w/ input variable
            ConsolePrintSomethingSpecific("this is an input string from another method going into a print method that takes in a string param");
            // method w/ 2 input vals and a return val; inputs must be int for this func
            string result = AddTwoIntegers(99990, 99991).ToString();
            Console.WriteLine("this is the result of adding two integers: 99990 and 99991 = {0}", result);
            /*
             * Challenge - Methods
                In this challenge you will deepen your understanding for methods.
                Please go ahead and create three variables with names of your friends.
                Then create a Method "GreetFriend" which writes something like: "Hi Frank, my friend!" onto the console, once it is called.
                Where "Frank" should be replaced with the Name behind the argument given to the Method when it's called. So the method will need a parameter (decide which DataType will be best). 

                Greet all your three friends.
             */
            string friend1 = "bahamut zero";
            string friend2 = "sloth";
            string friend3 = "shiva";
            Greetings(friend1);
            Greetings(friend2);
            Greetings(friend3);

            // challenge 2 - try to divide by 0 and do it w/n a try/catch to print out the error so it fails gracefully
            try {
                int numerator = 1;
                int denominator = 0;
                // this division should fail
                int total = numerator / denominator;
                Console.WriteLine(total);
                
            } catch (DivideByZeroException exceptionVar) {
                Console.WriteLine(exceptionVar);
                Console.WriteLine(exceptionVar.Message);
                Console.WriteLine(exceptionVar.TargetSite  + " " + exceptionVar.StackTrace);
            }
        }
        // practice void method
        public void ConsolePrintSomething() {
            Console.WriteLine("this is called/printed to console from a void method!");
        }
        // static version
        public static void ConsolePrintSomethingStatic() {
            Console.WriteLine("this is called/printed to console from a void static method!");
        }

        // practice method w/ input params
        public static void ConsolePrintSomethingSpecific(string inputText) {
            Console.WriteLine("this is from a void static method and has an input: {0}!", inputText);
        }

        // practice method w/ input params and a return type
        public static int AddTwoIntegers(int inputInteger1, int inputInteger2) {
            return inputInteger1 + inputInteger2;
        }

        // challenge method
        public static void Greetings(string friendName) {
            Console.WriteLine("Sup {0}! How's it going?", friendName);
        }

    }
}
