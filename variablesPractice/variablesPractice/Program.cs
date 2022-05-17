using System;

namespace variablesPractice {
    class Program {
        static void Main(string[] args) {

            // declaring vars
            int num1;

            // assigning value to var
            num1 = 9999;

            Console.WriteLine("var is: {0}", num1);

            // declare and initialize at same time
            int num2 = 9999;

            Console.WriteLine("var1: {0} * var2: {1} = {2}", num1, num2, num2 * num1);

            int result = num1 * num2;

            Console.WriteLine("num1: " + num1 + " * num2: " + num2 + " = " + result);

            double dnum1 = Math.PI;
            double dnum2 = 999999.999916513218;
            double ddivresult1 = dnum1 / dnum2;
            double ddivresult2 = dnum2 / dnum1;
            Console.WriteLine("doubles:");
            Console.WriteLine("dnum1: {0} / dnum2: {1} = {2}", dnum1, dnum2, ddivresult1);
            Console.WriteLine("dnum2: {0} / dnum1: {1} = {2}", dnum2, dnum1, ddivresult2);

            float fnum1 = (float)Math.PI;
            float fnum2 = 999999.999916513218f;
            float fdivresult1 = fnum1 / fnum2;
            float fdivresult2 = fnum2 / fnum1;
            Console.WriteLine("floats:");
            Console.WriteLine("fnum1: {0} / fnum2: {1} = {2}", fnum1, fnum2, fdivresult1);
            Console.WriteLine("fnum2: {0} / fnum1: {1} = {2}", fnum2, fnum1, fdivresult2);

            double didivresult1 = dnum2 / num1;
            Console.WriteLine("double and int w/ double result:");
            Console.WriteLine("dnum1: {0} / num1: {1} = {2}", dnum2, num1, didivresult1);

            int didivintresult1 = (int)(dnum2 / num1);
            Console.WriteLine("double and int w/ int result (must use explicit cast):");
            Console.WriteLine("dnum1: {0} / num1: {1} = {2}", dnum2, num1, didivintresult1);

            string myname = "dark";
            Console.WriteLine("my name is: " + myname);
            Console.WriteLine("my name is {0}", myname);

            string msg = "my name is: ";

            Console.WriteLine("as you can see below, you need to have the affected string in a var to save the effect. it won't print out otherwise.");

            Console.WriteLine("not saved to var before printing");
            msg.ToUpper();
            Console.WriteLine(msg + myname);

            Console.WriteLine("saved to var and then that var is printed");
            string msgUC = msg.ToUpper();
            Console.WriteLine(msgUC + myname);

            // changing console colors
            string colorConsoleStr = "the colors duke, the colors!";
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(colorConsoleStr);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(colorConsoleStr);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(colorConsoleStr);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(colorConsoleStr);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(colorConsoleStr);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(colorConsoleStr);

            // exercise 1:
            /*
             * Challenge 1 – String and its methods

                Now you know the use of various string functions so let’s create a small Console application to practice this.

                Declare a string variable and don’t assign any value to it.

                Print on the console “Please enter your name and press enter”. You can then enter your name or any other valid string like “tutorials.eu”.

                Assign that entered string to the string variable which you have declared initially.

                The program should write on the console that string in Uppercase in the first line, then the same string in Lowercase in the second line. In the third line, it writes on the console the string with no trailing or preceding white space like if string entered as “ tutorials.eu ” it should be written on the console as “tutorials.eu”. And in the last line, it should write the Substring of the entered string on the console.

                These kinds of features are e.g. used when creating a login screen, where the system will cut out trailing or preceding white space or, doesn’t care about the casing of the entered username.
             */

            string ex1String;

            Console.WriteLine("Please enter your name and press enter:");
            ex1String = Console.ReadLine();
            // next 3 lines assume there is at least 1 char there, otherwise will fail
            Console.WriteLine(ex1String.ToUpper());
            Console.WriteLine(ex1String.ToLower());
            Console.WriteLine(ex1String.Trim());
            // next line assumes the string is gte 2 chars, will fail if not
            Console.WriteLine(ex1String.Substring(ex1String.Trim().Length - 2, 2));

            // exersice 2:
            /*
             * Challenge String and its methods 2
            Let’s create another console application for more practice.

            This application asks the user to input a string in the first line like “Enter a string here: ”.

            In the Second Line, it should ask for the character to search in the string which you have entered in the first line like “Enter the character to search: ”

            On the third line, it should write the index of the first occurrence of the searched character from the string.

            Now on concatenation...

            It should then ask to enter the first name and once the name is written and the enter button is pressed, it should ask to enter the last name.

            It should then show your full name printed in a single line like in my case the output will be "Denis Panjuta". Output can be different in your case. Try to store the full name in a variable, before displaying it.
             */
            string ex2String;
            string searchChar;
            string fullName;

            Console.WriteLine("Please enter a string here and press enter:");
            ex2String = Console.ReadLine();
            // read line below assumes they only enter 1 char, otherwise will not find or will find wrong thing
            Console.WriteLine("Enter the character to search and press enter:");
            searchChar = Console.ReadLine();

            Console.WriteLine("the index of the character you searched if in the string is (will be -1 if it doesn't exist in the string): {0}", ex2String.IndexOf(searchChar));

            Console.WriteLine("Please enter your first name and press enter:");
            fullName = Console.ReadLine();
            Console.WriteLine("Please enter your second name and press enter:");
            fullName = fullName + " " + Console.ReadLine();

            Console.WriteLine("your fullname is: {0}", fullName);

            // challenge exercise 1
            /*
             * Challenge - Datatypes And Variables
                Now that you know how to declare and initialize Variables, please go ahead and create a variable for each of the primitive datatypes (you can find the list here). Leave the Object datatype out.
                And also please initialize each variable with a working value.
                Then create two values of type string. 
                The first one should say "I control text"

                The second one should be a whole number. Then use the Parse method in order to convert that string to an integer.

                Add each an output for each of the variables and write it onto the console. (WriteLine)
                Feel free to name your variables as you like, but keep in mind, that my result's variable names will differ to yours.
                Have fun :)
             */
            // unassigned int
            byte byte1 = 255;
            // assigned int
            sbyte sByte1 = -128;
            // signed int 32 bit
            int integer1 = 2099999999;
            // unsigned int 32 bit
            uint uInteger1 = 4199999999;
            // signed int 16 bit
            short sInteger1 = -32768;
            // unsigned int 16 bit
            ushort usInteger1 = 65535;
            // signed int 64 bit long
            long lInteger1 = 9223372036854775807;
            // unsigned int 64 bit long
            ulong ulInteger1 = 18446744073709551615;
            // floating pt signed number decimal w/ up to 38 dec places; needs f at end
            float fNumber1 = 3.402823e38f;
            // floating pt signed number decimal w/ up to 308 dec places; no f needed at end
            double dNumber1 = 1.79769313486231e308;
            // single character unicode (alphabet, num, special char, all in string format but one one value allowed)
            char charVal = 'z';
            // true false logical value 
            bool boolValTrue = true;
            bool boolValFalse = false;
            // can be any object
            object object1 = false;
            object object2 = 9999;
            object object3 = "this is a test";
            // any number of chars 
            string string1 = "this is a string variable";
            // floating point number that only goes to 29 decimal points; needs m to work
            decimal decimal1 = .79228162514264337593543950335m;
            decimal decimal2 = 9.99m;

            string text1 = "I control text";
            string text2 = "9999";
            int integerFromString = int.Parse(text2);

            Console.WriteLine("here is all the variables created:");
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16} {17} {18} {19} {20} {21}", byte1, sByte1, integer1, uInteger1, sInteger1, usInteger1, lInteger1, ulInteger1, fNumber1, dNumber1, charVal, boolValTrue, boolValFalse, object1, object2, object3, string1, decimal1, decimal2, text1, text2, integerFromString);

            // constant variable = will stay the same no matter what once created
            const double pie = Math.PI;
            // const imaginary bd as string
            const string birthdayStringConstant = "01/01/9999";
        }
    }
}
