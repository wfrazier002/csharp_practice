using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsPractice {
    class Program {
        static void Main(string[] args) {

            // C# when you pass an array into a method, you are passing the addr of the array,
            // meaning you can directly alter that array from another method. i'd still try to 
            // make a copy of it rather than alter the main one itself if possible

            //Challenge1();

            //MultiDimensionArrays();

            //NestedLoopsDimensionalArrays();

            //Challenge3();

            // jagged arrays = array w/n an array
            // ex of jagged array
            /*int[][] jaggedArray = new int[4][];

            jaggedArray[0] = new int[] {1,2,3,4,5};
            jaggedArray[1] = new int[] { 1, 2 };
            jaggedArray[2] = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            jaggedArray[3] = new int[] { 1 };
            //alternatively, create and initialize at same time
            int[][] jaggedArray2 = new int[][] {
                new int[] {1,2,3,4,5},
                new int[] { 1, 2 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new int[] { 1 }
            }; */

            // note: [,] is not the same as [][]
            // [,] is a 2d array, whereas [][] is a 1d array of arrays

            // challenge4
            //Challenge4(jaggedArray, jaggedArray2);

            //Challenge5();

            //Challenge6();

            // params keyword = means it will accept as many parameters as you can give it
            //ParamsExampleMethod1();
            //ParamsExampleMethod1("hello", "my friend");
            //ParamsExampleMethod1("can", "you", "see", "me", "anymore");
            //ParamsExampleMethod2(1, "2", 3.05);

            // math.min - getting min from multiple values, not just the 2 it takes
            //Math.Min() 
            //Min2(1, 2, 5, 0);
            //Min2(-1, 9999, -15, -9999);
            //Min2(1.65, 28.4, .84, .0005);

            //ArrayListMethodExample();

            //Challenge7();

            // hashtables
            // key - value pairs
            // each entry is a one to one relationship
            // ex: auto in german = car in english
            //HashTablesExample();

            //Challenge8();

            // dictionary is a generic vs of a hashtable
            //DictionaryExample();

            StacksAndQueuesExample();
        }

        private static void Challenge1() {
            /*
             * Foreach Loops and Switch Statement challenge
                Create an application that takes 2 input values.

                Any input value (1st input)

                Asks the data type of the input value. (2nd input)

                It will print to the console the options like below to take input for the 2nd input value:

                Press 1 for String

                Press 2 for integer

                Press 3 for Boolean

                If the input value for the 2nd input is 1 then the application should check that if the entered 1st input is a valid string or not. Hereby we even want to check, if it is a complete alphabetic entry (so no numbers accepted)

                If the input value for the 2nd input is 2 then the application should check if the entered 1st input is a valid integer or not.

                Based on the input the 1st value and the selection of data type using the 2nd input, the application should return whether the entered 1st value is of data type selected by the user or not.

                Please make sure to use a switch statement. To check the valid string you can write your custom logic.

                For example:

                Enter a value: {here you can enter any value}

                Select the Data type to validate the input you have entered.

                Press 1 for String

                Press 2 for Integer

                Press 3 for Boolean

                Here, if you enter 1 it should return below message

                You have entered a value: Denis Panjuta

                It is a valid: String

                Here, if you enter 2 it should return below message

                You have entered a value: Denis Panjuta

                It is an invalid: Integer


             */
            try {
                Console.WriteLine("hello. please enter a value here:");
                string userInput1 = Console.ReadLine();
                Console.WriteLine("please tell me what type of value you just entered: Press 1 for String," + " Press 2 for integer, Press 3 for Boolean");
                string userInput2 = Console.ReadLine();
                switch (userInput2) {
                    case "1":
                        bool isAlpha = false;
                        foreach (char letter in userInput1) {
                            if (Char.IsLetter(letter)) {
                                isAlpha = true;
                            } else {
                                isAlpha = false;
                            }
                        }
                        if (!isAlpha) {
                            Console.WriteLine("Sorry, you didn't enter only letters for your string.");
                            Console.WriteLine("you entered {0}, but it is not of type {1}", userInput1, "string (alphabet chars only)");
                        } else {
                            Console.WriteLine("you have entered a value: {0}", userInput1);
                            Console.WriteLine("this is a valid input of {0}", "string (alphabet chars only)");
                        }
                        break;
                    case "2":
                        bool isNumeric = false;
                        if (int.TryParse(userInput1, out int number)) {
                            isNumeric = true;
                        }
                        if (!isNumeric) {
                            Console.WriteLine("Sorry, you didn't enter an integer here.");
                            Console.WriteLine("you entered {0}, but it is not of type {1}", userInput1, "integer");
                        } else {
                            Console.WriteLine("you have entered a value: {0}", userInput1);
                            Console.WriteLine("this is a valid input of {0}", "integer");
                        }
                        break;
                    case "3":
                        if (userInput1 == "true" || userInput1 == "false") {
                            Console.WriteLine("you have entered a value: {0}", userInput1);
                            Console.WriteLine("this is a valid input of {0}", "boolean");
                        } else {
                            Console.WriteLine("Sorry, you didn't enter a valid boolean here.");
                            Console.WriteLine("you entered {0}, but it is not of type {1}", userInput1, "boolean");
                        }
                        break;
                    default:
                        Console.WriteLine("Sorry, you didn't enter a valid choice for input.");
                        break;
                }
            } catch (Exception exception) {
                Console.WriteLine("you had an error: {0}", exception);
            }
        }

        private static void MultiDimensionArrays() {
                // 1D array (normal array)
                int[] numbers1d;

                // 2D array (like a matrix from math)
                int[,] numbers2d;

                // 3D array
                int[,,] numbers3d;

                //ex of 2d array:
                // positions are: 0,0; 0,1; 0,2; 1,0; 1,1; 1,2; 2,0; 2,1; 2,2
                int[,] twoDArray = new int[,] {
                    {1,2,3},
                    {4,5,6},
                    {7,8,9}
                };
                // challenge: print out 7 from 2D array
                Console.WriteLine("the value {0} is from row 2, col 0", twoDArray[2, 0]);

                //ex of 3d array:
                string[,,] array3D = new string[,,] 
                // 1st dimension; depth
                {
                    // 2nd dimension; height
                    {
                        //3rd dimension; length
                        {"000", "001"}, // row 00
                        {"010", "011"}, // row 01
                        {"hello there!", "hows it going?" } // row 02
                    },
                    {
                        {"100", "101"}, // row 10
                        {"110", "111"}, // row 11
                        {"this is a test", "you need the same # of rows and cols for the 3d array"} // row 12
                    }
                };
                // note: if you make the 3rd dimension of the 0th row of 2nd dimension have a certain number, then all other 2nd dimension values must have that same number of entries

                // challenge: access hello there
                Console.WriteLine("entry {0} is position 020", array3D[0, 2, 0]);

                // can also specify dimensions earlier on
                string[,] string2D = new string[3, 2] { //says you want a 2d array w/ 3 rows, 2 cols eachrow
                    {"zero", "one"},
                    {"two", "three"},
                    {"four", "five"}
                };
                // challenge: change three to beef
                string2D[1, 1] = "beef";
                Console.WriteLine("entry 1,1 is: {0}", string2D[1, 1]);

                // to see the dimensions of an array, use array.rank
                int dimensions2Dstring = string2D.Rank;
                int dimensions3Darray = array3D.Rank;
                Console.WriteLine("the dimensions of 2d array is: {0} and the 3d array is: {1}", dimensions2Dstring, dimensions3Darray);

                // don't have to put new array[,...] on the right side, can define it directly w/ values:
                int[,] array2Dints = { { 0, 1 }, { 2, 3 } };
        }

        private static void NestedLoopsDimensionalArrays() {
            // can make a foreach loop by typing foreach then tab tab
            int[,] matrix2D = {
                {0,1,2},
                {3,4,5},
                {6,7,8},
                {9,10,11}
            };
            // a foreach loop can iterate thru a multi dimension array, however, can't edit while in there
            /*foreach (int element in matrix2D) {
                Console.WriteLine("element is: {0}", element);
            }

            // next, lets try a nested for loop
            for (int rowCounter = 0; rowCounter < matrix2D.GetLength(0); rowCounter++) { //getlength(0) should get the number of rows in this case
                Console.WriteLine("row number is: {0}", rowCounter);
                for (int colCounter = 0; colCounter < matrix2D.GetLength(1); colCounter++) {//getlength(1) should get the cols in this case
                    Console.WriteLine("col number is: {0}",colCounter);
                    Console.WriteLine("value at this row/col is: {0}", matrix2D[rowCounter,colCounter]);
                }
            } */
            // the advantage of the nested for loop is that you can directly edit the values at each row and/or col, whereas in the foreach you can't
            Challenge2(matrix2D);
        }

        private static void Challenge2(int[,] matrix2D) {
            // challenge: adjust the nested for loop so that it prints out the even cols (0,2) which is actually the odd numbers since the counter starts at 0 ;) 
            for (int rowCounter = 0; rowCounter < matrix2D.GetLength(0); rowCounter++) { //getlength(0) should get the number of rows in this case
                Console.WriteLine("row number is: {0}", rowCounter);
                for (int colCounter = 0; colCounter < matrix2D.GetLength(1); colCounter++) {//getlength(1) should get the cols in this case
                    Console.WriteLine("col number is: {0}", colCounter);
                    if (colCounter % 2 == 0) {
                        Console.WriteLine("value at row {0} col {1} is: {2}", rowCounter, colCounter, matrix2D[rowCounter, colCounter]);
                    }
                    // optionally, print out the even values:
                    if (matrix2D[rowCounter,colCounter] % 2 == 0) {
                        Console.WriteLine("even value at this row/col is: {0}", matrix2D[rowCounter, colCounter]);
                    }
                }
            }
        }

        private static void Challenge3() {
            // create a tic tak toe game w/ console
            string[,] tiktakToeBoard = new string[,] {
                {"1","2","3"},
                {"4","5","6"},
                {"7","8","9"}
            };
            string userInputPlayer1 = "";
            string userInputPlayer2 = "";
            int[,] choicePlacement = new int[,] {
                //1
                {0,0},
                //2
                {0,1},
                //3
                {0,2},
                //4
                {1,0},
                //5
                {1,1},
                //6
                {1,2},
                //7
                {2,0},
                //8
                {2,1},
                //9
                {2,2}
            };
            while (userInputPlayer1 != "stop" || userInputPlayer2 != "stop") {
                string[,] boardAnswers = tiktakToeBoard.Clone() as string[,];
                bool isGameOver = false;
                string playerWins = "neither";
                int moveCounter = 0;
                Console.WriteLine("welcome to the tictaktoe game");
                Console.WriteLine("here is the game board:");
                //PrintBoard(tiktakToeBoard);
                while (!isGameOver) {
                    PrintBoard(boardAnswers);
                    Console.WriteLine("\nplayer one: choose which number you want the X in.");
                    userInputPlayer1 = Console.ReadLine();
                    (boardAnswers, isGameOver, playerWins) = CheckInputAndMove(userInputPlayer1, choicePlacement, boardAnswers, "X", moveCounter);  
                    if (isGameOver) {
                        if (playerWins == "stop") {
                            return;
                        } else if (playerWins != "tie") {
                            Console.WriteLine("congratz, {0} has won.", playerWins);
                        }
                        break;
                    }
                    moveCounter++;
                    if (moveCounter == 9) {
                        Console.WriteLine("sorry, it was a tie.");
                        break;
                    }
                    PrintBoard(boardAnswers);
                    Console.WriteLine("\nplayer two: choose which number you want the O in.");
                    userInputPlayer2 = Console.ReadLine();
                    (boardAnswers, isGameOver, playerWins) = CheckInputAndMove(userInputPlayer2, choicePlacement, boardAnswers, "O", moveCounter);
                    if (isGameOver) {
                        if (playerWins == "stop") {
                            return;
                        } else if (playerWins != "tie") {
                            Console.WriteLine("congratz, {0} has won.", playerWins);
                        }
                        break;
                    }
                    moveCounter++;
                    if (moveCounter == 9) {
                        Console.WriteLine("sorry, it was a tie.");
                        break;
                    }
                }
            }

            
        }

        private static void PrintBoard(string[,] tiktakToeBoard) {
            for (int rowCounter = 0; rowCounter < tiktakToeBoard.GetLength(0); rowCounter++) {
                Console.WriteLine();
                for (int colCounter = 0; colCounter < tiktakToeBoard.GetLength(1); colCounter++) {
                    Console.Write(" {0} ", tiktakToeBoard[rowCounter, colCounter]);
                    Console.Write("|");
                }
                if (rowCounter == 0 || rowCounter == 1) {
                    Console.WriteLine("\n____________");
                }
            }
        }

        private static (string[,], bool, string) CheckInputAndMove(string userInputPlayer, int[,] choicePlacement, string[,] boardAnswers, string choice, int moveCounter) {
            int row = -1;
            int col = -1;
            bool choiceGood = false;
            if (userInputPlayer == "stop") {
                return (boardAnswers, true, "stop");
            } else {
                while (!choiceGood) {
                    while (!int.TryParse(userInputPlayer, out int number) || (number < 1 || number > 9)) {
                        Console.WriteLine("Please enter a number between 1 and 9.");
                        userInputPlayer = Console.ReadLine(); 
                    }
                    row = choicePlacement[int.Parse(userInputPlayer)- 1, 0];
                    col = choicePlacement[int.Parse(userInputPlayer)- 1, 1];
                    if (boardAnswers[row,col].Contains('X') || boardAnswers[row,col].Contains('O')) {
                        Console.WriteLine("sorry, this place has been chosen already. please retry.");
                        userInputPlayer = Console.ReadLine();
                    } else {
                        choiceGood = true;
                    }
                }
                boardAnswers[row, col] = choice;
                (bool isGameOver, string playerWins) = CheckBoard(boardAnswers, row, choice, moveCounter);
                return (boardAnswers, isGameOver, playerWins);
            }  
        }


        private static (bool, string) CheckBoard(string[,] boardAnswers, int row, string choice, int moveCounter) {
            // can be 3 across, 3 down, or 3 diagonal
            string playerIs = "tie";
            // 0,0; 1,1; 2,2
            if (boardAnswers[0,0] == choice && boardAnswers[1, 1] == choice && boardAnswers[2, 2] == choice) {
                if (choice == "X") {
                    playerIs = "player 1";
                } else {
                    playerIs = "player 2";
                }
                return (true, playerIs);
            } else if (boardAnswers[0, 2] == choice && boardAnswers[1, 1] == choice && boardAnswers[2, 0] == choice) {// 0,2; 1,1; 2,0
                if (choice == "X") {
                    playerIs = "player 1";
                } else {
                    playerIs = "player 2";
                }
                return (true, playerIs);
            } else if (boardAnswers[0, 0] == choice && boardAnswers[0, 1] == choice && boardAnswers[0, 2] == choice) {// 0,0; 0,1; 0,2
                if (choice == "X") {
                    playerIs = "player 1";
                } else {
                    playerIs = "player 2";
                }
                return (true, playerIs);
            } else if (boardAnswers[1, 0] == choice && boardAnswers[1, 1] == choice && boardAnswers[1, 2] == choice) {// 1,0; 1,1; 1,2
                if (choice == "X") {
                    playerIs = "player 1";
                } else {
                    playerIs = "player 2";
                }
                return (true, playerIs);
            } else if (boardAnswers[2, 0] == choice && boardAnswers[2, 1] == choice && boardAnswers[2, 2] == choice) {// 2,0; 2,1; 2,2
                if (choice == "X") {
                    playerIs = "player 1";
                } else {
                    playerIs = "player 2";
                }
                return (true, playerIs);
            } else if (boardAnswers[0, 0] == choice && boardAnswers[1, 0] == choice && boardAnswers[2, 0] == choice) {// 0,0; 1,0; 2,0
                if (choice == "X") {
                    playerIs = "player 1";
                } else {
                    playerIs = "player 2";
                }
                return (true, playerIs);
            } else if (boardAnswers[0, 0] == choice && boardAnswers[1, 1] == choice && boardAnswers[2, 2] == choice) {// 0,1; 1,1; 2,1
                if (choice == "X") {
                    playerIs = "player 1";
                } else {
                    playerIs = "player 2";
                }
                return (true, playerIs);
            } else if (boardAnswers[0, 0] == choice && boardAnswers[1, 1] == choice && boardAnswers[2, 2] == choice) { // 0,2; 1,2; 2,2
                if (choice == "X") {
                    playerIs = "player 1";
                } else {
                    playerIs = "player 2";
                }
                return (true, playerIs);
            }
            return (false, playerIs);
        }

        private static void Challenge4(int[][] jaggedArray, int[][] jaggedArray2) {
            // try to get all the values w/n the jaggedArray printed out on the console.
            // add in your own part for the challenge: do this via loops, 
            // and via foreach
            // and also print a few using preciice index pts
            Console.WriteLine("jagged array printed using 2 for loops:");
            for (int counter = 0; counter < jaggedArray.Length; counter++) {
                for (int counterInner = 0; counterInner < jaggedArray[counter].Length; counterInner++) {
                    Console.WriteLine("jaggedArray 1: outer array index: {0}, inner array index: {1}, inner array value at that index: {2}", counter, counterInner, jaggedArray[counter][counterInner]);
                }
            }
            Console.WriteLine("jagged array 2 printed using foreach loop:");
            foreach (int[] innerArray in jaggedArray2) {
                foreach (int item in innerArray) {
                    Console.WriteLine("jagged array 2: inner array: {0}, inner array value at index: {1}", innerArray, item);
                }
            }
            Console.WriteLine("particular value of jagged array 1 at jaggedArray[0][3]: {0}", jaggedArray[0][3]);
            Console.WriteLine("particular value of jagged array 2 at jaggedArray2[2][5]", jaggedArray2[2][5]);
        }


        private static void Challenge5() {
            // create a jagged array, which contains 3 friend arrays, each of which contains at least 2 family members
            // introduce each family to the other in the console
            string[][] jaggedArray = new string[3][];
            jaggedArray[0] = new string[2] {"mother: Shana","father: Alfred"};
            jaggedArray[1] = new string[4] { "mother: Terri", "stepfather: Greg", "brother: Tristan", "sister: Anna"};
            jaggedArray[2] = new string[8] { "mother: Shiva", "father: Bahamut", "brother: Ifrit", "brother: Titan", "sister: Sylph", "uncle: diablo", "pet: chocobo", "pet: carbuncle"};
            int counter = 1;
            foreach (string[] friendArray in jaggedArray) {
                Console.WriteLine("friend {0}, please introduce your family:", counter);
                foreach(string familyMember in friendArray) {
                    Console.WriteLine("family member is: {0}", familyMember);
                }
                counter++;
            }
            

        }

        private static void Challenge6() {
            // create an array of "happyness" (so int?) and assign 5 values to it
            // create a method that has an array of ints as params
            // the method should increase the ints by 2
            int[] happyness = { 1, 2, 3, 6, 9 };
            happyness = upgradeHappyness(happyness);
            foreach (int happy in happyness) {
                Console.WriteLine("this is the happyness for this entry: {0}", happy);
            }
        }

        private static int[] upgradeHappyness(int[] happyness) {
            for (int counter = 0; counter < happyness.Length; counter++) {
                happyness[counter] += 2;
            }
            return happyness;
        }

        private static void ParamsExampleMethod1(params string[] values) {
            foreach (string value in values) {
                Console.WriteLine(value);
            }
        }

        private static void ParamsExampleMethod2(params object[] objArray) {
            foreach (object variable in objArray) {
                Console.WriteLine(variable + " is an object in the object array");
            }  
        }

        private static void Min2(params int[] numbers) {
            int minNumber = int.MaxValue;
            foreach (int number in numbers) {
                minNumber = Math.Min(number, minNumber);
            }
            Console.WriteLine("the minimum num is: {0}", minNumber);
        }

        // can override to do other number types as well
        private static void Min2(params double[] numbers) {
            double minNumber = double.MaxValue;
            foreach (double number in numbers) {
                minNumber = Math.Min(number, minNumber);
            }
            Console.WriteLine("the minimum num is: {0}", minNumber);
        }
        // can override to do other number types as well
        private static void Min2(params float[] numbers) {
            float minNumber = float.MaxValue;
            foreach (float number in numbers) {
                minNumber = Math.Min(number, minNumber);
            }
            Console.WriteLine("the minimum num is: {0}", minNumber);
        }

        private static void ArrayListMethodExample() {
            // arraylist - a class from system.collections
            ArrayList myArrayList = new ArrayList(); // don't know how many object will be in there
            ArrayList myArrayList2 = new ArrayList(100); // there will be 100 objects in there

            // arraylists don't need to contain strings only, or ints only, etc. they can contain any number of different object types
            //ex
            myArrayList.Add(9999); // int
            myArrayList.Add(13.99); // double
            myArrayList.Add("hello world"); // string
            myArrayList.Add('S'); // char
            myArrayList.Add(13);
            myArrayList.Add(13);

            // specify what to remove; only removes one instance of it
            myArrayList.Remove(13);

            // can also remove at a specific position
            // this example removes at the end of the list
            myArrayList.RemoveAt(myArrayList.Count - 1);
            double sum = 0;
            foreach (object obj in myArrayList) {
                if (obj is int) {
                    sum += Convert.ToDouble(obj);
                } else if (obj is double) {
                    sum += (double)obj;
                } else if (obj is string || obj is char) {
                    Console.WriteLine("the string or char at this pt in the arraylist is: {0}", obj);
                }
                Console.WriteLine("the sum so far is: {0}", sum);
            }
            Console.WriteLine("total sum after going thru the arraylist is: {0}", sum);
        }

        private static void Challenge7() {
            // create a list of ints that include all even nums from 100 to 170
            var intList = new List<int>();

            for (int counter = 100; counter <=170; counter+=2) {
                intList.Add(counter);
            }
            Console.WriteLine(intList.Count);
            foreach (int num in intList) {
                Console.Write("{0} ", num);
            }
        }

        private static void HashTablesExample() {
            Hashtable studentsTable = new Hashtable();

            Student student1 = new Student(1, "Shiva", 98);
            Student student2 = new Student(2, "Bahamut", 100);
            Student student3 = new Student(3, "Rahmu", 85);
            Student student4 = new Student(4, "Gilgamesh", 75);

            studentsTable.Add(student1.Id, student1);
            studentsTable.Add(student2.Id, student2);
            studentsTable.Add(student3.Id, student3);
            studentsTable.Add(student4.Id, student4);

            // in order to grab it from the hashtable, make sure to typecast it to type student in the variable
            // this case, get the student w/ id 1
            Student aStudent = (Student)studentsTable[1];
            Console.WriteLine("this student is: id {0}, name {1}, and gpa {2}", aStudent.Id, aStudent.Name, aStudent.GPA);
            // can also get it via the above student object using the id
            Student aStudent2 = (Student)studentsTable[student2.Id];
            Console.WriteLine("this student is: id {0}, name {1}, and gpa {2}", aStudent2.Id, aStudent2.Name, aStudent2.GPA);

            // an entry in the hashtable is of type dictionaryentry?
            // this loop will get all 'entries' in a table
            foreach (DictionaryEntry entry in studentsTable) {
                // if you try to get it directly from the foreach
                Console.WriteLine("if you try to get it directly from the foreach");
                Console.WriteLine("entry: key {0}, value {1}", entry.Key, entry.Value);
                // if you try to get it from the foreach after converting to student
                Console.WriteLine("if you try to get it from the foreach after converting to student");
                Student tempStudent = (Student)entry.Value;
                Console.WriteLine("entry: id {0}, name {1}, gpa {2}", tempStudent.Id, tempStudent.Name, tempStudent.GPA);
            }

            // can also directly go thru the values in a foreach:
            foreach (Student aStud in studentsTable.Values) {
                Console.WriteLine("entry: id {0}, name {1}, gpa {2}", aStud.Id, aStud.Name, aStud.GPA);
            }

        }

        private static void Challenge8() {
            // in this challenge, write something that will iterate thru of a students array
            // and insert them into a hashtable
            // if a student w/ the same id already exists, skip it and display an error saying:
            // 'Sorry, a student w/ that Id already exists'
            Student[] students = new Student[5];
            students[0] = new Student(1, "Denis", 88);
            students[1] = new Student(2, "Olaf", 97);
            students[2] = new Student(6, "Ragner", 65);
            students[3] = new Student(1, "Lewis", 73);
            students[4] = new Student(4, "Levi", 58);
            Hashtable studentHashTable = new Hashtable();

            foreach (Student aStudent in students) {
                if (studentHashTable.Contains(aStudent.Id)) {
                    Console.WriteLine("sorry, a student w/ that Id already exists in the table.");
                } else {
                    studentHashTable.Add(aStudent.Id, aStudent);
                }
            }
            Console.WriteLine("there are {0} students in the Hashtable", studentHashTable.Count);
            foreach (Student aStudent in studentHashTable.Values) {
                Console.WriteLine("student in hashtable: id {0}, name {1}, gpa {2}", aStudent.Id, aStudent.Name, aStudent.GPA);
            }
        }


        private static void DictionaryExample() {
            Employee[] employees = {
                new Employee("CEO", "Shiva",595, 200),
                new Employee("Vice CEO", "Bahamut",797, 150),
                new Employee("Manager", "Diablo",1095, 30),
                new Employee("HR", "Slyph",229, 20),
                new Employee("Lead Developer", "Carbuncle",55, 15),
                new Employee("Developer", "Dark",35, 13.95f),
                new Employee("intern", "Chocobo",25, 8.75f)
            };

            Dictionary<string, Employee> employeeDictionary = new Dictionary<string, Employee>();
            
            foreach (Employee employ in employees) {
                employeeDictionary.Add(employ.Role, employ);
            }

            // 2 ways to check if something is in the dictionary
            string key = "CEO";
            if (employeeDictionary.ContainsKey(key)) {
                Console.WriteLine("the person you are looking for is in the dictionary: role: {0}, name: {1}, salary: {2}", employeeDictionary[key].Role, employeeDictionary[key].Name, employeeDictionary[key].Salary);
            }
            // checking for the key is the first way, the second way is to try to get the value
            string key2 = "HR";
            if (employeeDictionary.TryGetValue(key2, out Employee result)) {
                Console.WriteLine("the person you are looking for is in the dictionary: role: {0}, name: {1}, salary: {2}", result.Role, result.Name, result.Salary);
            }

            // since this is a collection, you can also grab each entry in the dictionary using ElementAt(index)
            // the only thing you have to worry about is that the object returned is not a single entry in the dictionary, but rather a key-pair object --> KeyValuePair<key type, value type>
            // so ex:
            for (int counter = 0; counter < employeeDictionary.Count; counter++) {
                KeyValuePair<string, Employee> keyValuePair = employeeDictionary.ElementAt(counter);
                Console.WriteLine("the key for this pair is: {0}", keyValuePair.Key);
                Console.WriteLine("the value for this pair is: {0}", keyValuePair.Value);
                Console.WriteLine("the 3 items getable from the value are: name {0}, role {1}, and salary {2}", keyValuePair.Value.Name, keyValuePair.Value.Role, keyValuePair.Value.Salary);
            }
        }


        private static void StacksAndQueuesExample() {
            // stack
            // can define a stack like how you define any collection
            // stack.push(item to push to stack)
            // stack.pop()
            // stack.peek()
            // stack.count
            // lifo
          

            // ex - given an array, create another array w/ reverse order numbers
            /*int[] numbers = new int[] { 8, 2, 3, 4, 7, 6, 2 };
            ArrayList reverseNumbers = new ArrayList();
            Stack<int> myStack = new Stack<int>();

            foreach (int num in numbers) {
                Console.WriteLine("original int array order: {0}",num);
                myStack.Push(num);
            }
            foreach (int num in myStack) {
                reverseNumbers.Add(num);
            }
            foreach (int num in reverseNumbers) {
                Console.WriteLine("int at this loop iteration is {0}",num);
            } */

            // queue
            // fifo
            // define a queue just like how you define a stack (using queue keyword instead of stack)
            // queue.enqueue
            // queue.peek
            // queue.count
            // queue.dequeue

            //ex - have a set amt of orders received, and want to process them based on the order they came in
            Order[] orders = new Order[] {
                new Order(1,5),
                new Order(2,4),
                new Order(6,10)
            };
            Order[] orders2 = new Order[] {
                new Order(3,5),
                new Order(4,4),
                new Order(5,10)
            };

            Queue<Order> ordersQueue = new Queue<Order>();
            // for this example, the orders are processed in the order they enter the queue rather than the order number
            foreach (Order anOrder in orders) {
                ordersQueue.Enqueue(anOrder);
            }
            foreach (Order anOrder in orders2) {
                ordersQueue.Enqueue(anOrder);
            }

            while (ordersQueue.Count > 0) {
                Order anOrder = ordersQueue.Dequeue();
                anOrder.ProcessOrder();
            }
        }
    }
}
