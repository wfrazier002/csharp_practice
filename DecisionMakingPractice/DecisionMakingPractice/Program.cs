using System;

namespace DecisionMakingPractice {
    class Program {
        // global vars
        // challenge 3
        static int highscore;
        static string highscorePlayer;

        static void Main(string[] args) {
            // challenge 1
            /*int temperature = 25;

            try {
                Console.WriteLine("please enter the temperature outside in F: ");
                //temperature = int.Parse(Console.ReadLine());//<-- instead of this, it is better to use tryparse in case they didn't use an int
                string input = Console.ReadLine();
                int temp;
                if (int.TryParse(input, out temp)) {
                    temperature = temp;
                } else {
                    temperature = -1;
                }
                if (temperature == -1) {
                    Console.WriteLine("the temp you inputted was not a number");
                } else if (temperature < 60) {
                    Console.WriteLine("please wear a jacket or light coat as it's {0} F outside", temperature);
                } else if (temperature == 60) {
                    Console.WriteLine("it's {0} F out. a little cool, but still nice out", temperature);
                } else if (temperature > 60 && temperature < 80) {
                    Console.WriteLine("it's {0} F out. what a nice day today", temperature);
                } else {
                    Console.WriteLine("Man it's hot out today, since it's {0} F out", temperature);
                }
            } catch (Exception exception) {
                Console.WriteLine(exception);
            } */

            //Challenge2();

            //Challenge3();

            // shortcut of if stmt:
            // ternary operator
            // condition ? yes/true : no/false
            // condition ? first expression : second expression

            // exs:
            // celcius
            /*int temperature = -5;
            string stateOfMatter;
            // normal if/else
            if (temperature < 0) {
                stateOfMatter = "solid";
            } else {
                stateOfMatter = "liquid";
            }*/
            // ternary version
            // wrong way
            //temperature < 0 ? stateOfMatter = "solid" : stateOfMatter = "liquid";
            // right way
            // is temp < 0? yes, stateOfMatter = solid; no, stateOfMatter = liquid
            //stateOfMatter = temperature < 0 ? "solid" : "liquid";

            // also possible to have more than 2 choices (so a if/elseif/else)
            // this particular one is if/else (if/else) ==v
            /* if(cond1)
             *   yes
             * else
             *   if(cond2)
             *     yes
             *   else
             *     no
             */
            // is temp < 0? yes, som = solid; no: is temp > 100? yes, som = gas; no, som = liquid
            //stateOfMatter = temperature < 0 ? "solid" : temperature > 100 ? "gas" : "liquid";

            Challenge4();
        }

        private static void Challenge2() {
            /*
             * Challenge - If Statements
                Create a user Login System, where the user can first register and then Login in. The Program should check if the user has entered the correct username and password, wenn login in (so the same ones that he used when registering).
                As we haven't covered storing data yet, just create the program in a way, that registering and logging in, happen in the same execution of it.
                User If statements and User Input and Methods to solve the challenge.
             */
            bool isRegistered = false;
            bool isLoggedIn = false;
            string registeredName;
            string userName;
            string registeredPassword;

            (isRegistered, registeredName, registeredPassword) = Register();
            if (isRegistered) {
                (isLoggedIn, userName) = Login(registeredName, registeredPassword);
                if (isLoggedIn) {
                    Console.WriteLine("hello, you are now logged in as {0}", userName);
                }
            }  
        }

        private static (bool, string, string) Register() {
            string username, password;
            try {
                Console.WriteLine("Hello, please type in a username and password to register:");
                Console.WriteLine("username to use:");
                username = Console.ReadLine();
                Console.WriteLine("password to use:");
                password = Console.ReadLine();
                if (String.IsNullOrEmpty(username) == false && String.IsNullOrEmpty(password) == false) {
                    return (true, username, password);
                }
            } catch (Exception exception) {
                Console.WriteLine("there was an error: {0}", exception);
            }
            return (false, "", "");          
        }

        private static (bool, string) Login(string username, string password) {
            Console.WriteLine("welcome user, please enter your username and password to login");
            try {
                string inputUsername;
                string inputPassword;

                Console.WriteLine("username:");
                inputUsername = Console.ReadLine();

                Console.WriteLine("password:");
                inputPassword = Console.ReadLine();

                if (String.IsNullOrEmpty(username) == false && String.IsNullOrEmpty(password) == false && String.IsNullOrEmpty(inputUsername) == false && String.IsNullOrEmpty(inputPassword) == false) {
                    if (username == inputUsername && password == inputPassword) {
                        return (true, inputUsername);
                    } else {
                        Console.WriteLine("Sorry, that username and password do not match a registered user.");
                        return (false, "");
                    } 
                }

                } catch (Exception exception) {
                Console.WriteLine("there was an error with the login: {0}", exception);
            }
            return (false, "");
        }

        // challenge 3
        private static void Challenge3() {
            /*
             * Challenge - If Statements 2
                Create an application with a score, highscore and a highscorePlayer.
                Create a method which has two parameters, one for the score and one for the playerName.
                When ever that method is called, it should be checked if the score of the player is higher than the highscore, if so, "New highscore is + " score" and in another line "New highscore holder is " + playerName - should be written onto the console, if not "The old highscore of " + highscore + " could not be broken and is still held by " + highscorePlayer.
                Consider which variables are required globally and which ones locally.
             */
            int score;
            string playerName;
            // initalize highscore and player
            highscore = 0;
            highscorePlayer = "noGameNoLife";
            score = 9999;
            playerName = "bahamut";
            CheckHighScore(score, playerName);
            // test not a high score
            score = 500;
            playerName = "mathis";
            CheckHighScore(score, playerName);
            // test new high score but same player
            score = 15999;
            playerName = "bahamut";
            CheckHighScore(score, playerName);
            // test new high score w/ new player
            score = 99999;
            playerName = "shiva";
            CheckHighScore(score, playerName);
        }

        // method should check if score is greater than high score
        //  - if yes, is it the same player?
        //      - if yes, print 'new high score for the current record holder {0}!
        //      - if no, print 'new high score for our new record holder {0}!
        //  - if no, print 'The old highscore of " + highscore + " could not be broken and is still held by " + highscorePlayer.'
        private static void CheckHighScore(int score, string playerName) {
            if (score <= 0) {
                Console.WriteLine("Sorry, there was no score to check! Please try again");
            } else {
                if (score > highscore) {
                    if (playerName == highscorePlayer) {
                        Console.WriteLine("New highscore is {0} \nCongratz {1} on a new highscore while holding your win!", score, playerName);
                        highscore = score;
                    } else {
                        Console.WriteLine("New highscore is {0} \nNew highscore holder is {1}", score, playerName);
                        highscore = score;
                        highscorePlayer = playerName;
                    }
                } else {
                    Console.WriteLine("The old highscore of {0} could not be broken and is still held by {1}", highscore, highscorePlayer);
                }
            }
        }

        // challenge 4
        private static void Challenge4() {
            /*
             * Enhanced If Statements - Ternary Operator - Challenge
                We have studied ternary operators and their usage so here is a small challenge for you. Let's create a small application that takes a temperature value as input and checks if the input is an integer or not.

                If the input value is not an integer value, it should print to the console "Not a valid Temperature".

                And if the input value is the valid integer then it should work as mentioned below.

                If input temperature value is <=15 it should write "it is too cold here" to the console.

                If input temperature value is >= 16 and is <=28 it should write "it is ok" to the console.

                If the input temperature value is > 28 it should write "it is hot here" to the console.

                Make sure to use ternary operators and not if statements to check for the three conditions, however you can use if statement for the other conditions like to check if the entered value is a valid integer or not.
             */
            Console.WriteLine("please input the current temp outside:");
            string sTemperature = Console.ReadLine();
            int temperature;
            // is input int? yes, (is input <= 15? yes, print out it is too cold here: no, (is input >= 16 && input <= 28? yes, print out it is ok : no, print out it is hot here)) : no, print out Not a valid Temperature
            /*cant do it this way: (using bool; instead, have to have a variable to fill)
             * bool isInt = int.TryParse(sTemperature, out temperature) ? (temperature >= 16 && temperature <= 28 ? Console.WriteLine("it is ok outside") : Console.WriteLine("it is hot here")) : Console.WriteLine("sorry, Not a valid Temperature"); */
            string msg = int.TryParse(sTemperature, out temperature) ? (temperature <= 15? "it is too cold here" : (temperature >= 16 && temperature <= 28 ? "it is ok outside" : "it is hot here")) : "sorry, Not a valid Temperature";
            Console.WriteLine(msg);
            
        }

    }
}
