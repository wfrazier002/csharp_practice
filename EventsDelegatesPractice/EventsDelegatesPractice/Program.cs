using System;
using System.Collections.Generic;

namespace EventsDelegatesPractice {
    class Program {
        // define a custom delegate here to be used in main/methods in this class
        public delegate bool FilterDelegate(Person aPerson);

        static void Main(string[] args) {
            // list of names 
            //List<string> namesList = new List<string>() {
            //    "Bahamut",
            //    "Shiva",
            //    "Diablo",
            //    "Ifrit",
            //    "Rahmu",
            //    "Sylph"
            //};

            //Console.WriteLine("before removeall w/ filter:");
            //foreach(string name in namesList) {
            //    Console.Write($"{name}, ");
            //}

            //Console.WriteLine("\n after removeall w/ filter:");
            //// the list is given to removeall, and removall checks each entry w/ the filter to see if it will remove it.
            //namesList.RemoveAll(Filter);

            //foreach(string name in namesList) {
            //    Console.Write($"{name}, ");
            //}

            // creating your own delegate

            // first, lets make a few 'people' from the person class and put them into a list
            //Person person1 = new Person() { Name = "Bahamut", Age = 1999 };
            //Person person2 = new Person() { Name = "Shiva", Age = 999 };
            //Person person3 = new Person() { Name = "Diablo", Age = 5999 };
            //Person person4 = new Person() { Name = "Sylph", Age = 799 };
            //Person person5 = new Person() { Name = "Carbuncle", Age = 9 };
            //Person person6 = new Person() { Name = "Chocobo", Age = 19 };
            //Person person7 = new Person() { Name = "Ixion", Age = 22 };

            //List<Person> peopleList = new List<Person>() { person1, person2, person3, person4, person5, person6, person7 };

            //// now call the method using the custom delegates
            //DisplayPeople("kids", peopleList, IsMinor);
            //DisplayPeople("adults", peopleList, IsAdult);
            //DisplayPeople("seniors", peopleList, IsSenior);
            //DisplayPeople("teenager/pre-adult", peopleList, IsTeenager);
            //// anonymous methods
            //// create a new filter delegate (this is an anonymous func btw)
            //// the way this anonymous func works is/behavies like a method
            //FilterDelegate filter = delegate (Person person) {
            //    return person.Age >= 20 && person.Age <= 30;
            //};

            //DisplayPeople("younge adult", peopleList, filter);

            //// can also pass an anonymous method like a parameter
            //DisplayPeople("everyone/all:", peopleList, delegate (Person person) {
            //    return person.Age >= 0;
            //});

            //// lambda expression
            //string searchKeyword = "A";
            //DisplayPeople("this will search for ppl > 20 and have a keyword/letter in their name: " + searchKeyword, peopleList, (param) => { 
            //    if(param.Name.Contains(searchKeyword.ToLower()) && param.Age > 20) {
            //        return true;
            //    } else {
            //        return false;
            //    }
            //});

            //// can also do the lambda w/ an easy expression as well
            //DisplayPeople("exactly 799:", peopleList, param => param.Age == 799);

            // multicast delegates and events
            // for this, do a 'game' example to show different ways to do the events
            AudioSystem audioSystem = new AudioSystem();
            RenderingEngine renderingEngine = new RenderingEngine();
            Player playerOne = new Player("Bahamut");
            Player playerTwo = new Player("Shiva");

            // this was the orignial way to do it
            // 'start' the game
            //renderingEngine.StartGame();
            //audioSystem.StartGame();
            //// 'pull in the player data'
            //playerOne.StartGame();
            //playerTwo.StartGame();

            //Console.WriteLine("game has started. press anything to end it....");
            //Console.ReadLine();

            //// 'end game' remove players first
            //playerTwo.EndGame();
            //playerOne.EndGame();
            //// shut down system
            //audioSystem.EndGame();
            //renderingEngine.EndGame();

            // now, we'll create a class that will activate the events w/n it, so set the other classes to have private methods now
            // Challenge: w/ the way things were changes by making gameeventmanager, change renderingengine to match audiosystem
            // have been treating delagates as events, but there is an event keyword
            GameEventManager.TriggerGameStart();
            Console.WriteLine("game is playing. press anything to end it....");
            Console.ReadLine();
            GameEventManager.TriggerGameEnd();
            // if you add the event keyword, then you make that delagate similar to read only: you can add to it: like a = 5; a += 5 (a = a + 5), but you can't override it: like a = 5; a = 10
            // you also can't directly call the event in a class now either (you can only call the event in a class where it's created)

            /*
             * events are forced to behave like lists (w/ the += or -=, but no reassigning w/ = byitself)
             * delagates on the otherhand can directly reassign x = 1; x = 2
             * events can't be triggered from outside the class that defines them - except main
             */
        }

        // create a method to use that will be used to filter out what you want removed w/ remove all and what you don't want removed; this filter will then be fed to the removeall as a predicate
        static bool Filter(string aString) {
            // for example, say we only want strings w/ i in it to be removed:
            return aString.Contains("i");
        }

        // here is a method to display people that pass the filter condition
        // it will have as input: 
        //  - string title
        //  - list of people
        //  - filter delegate (which we will create)
        static void DisplayPeople(string title, List<Person> peopleList, FilterDelegate filter) {
            Console.WriteLine("here is the title of the people to print: {0}", title);

            foreach (Person person in peopleList) {
                if (filter(person)) {
                    Console.WriteLine("Name: {0}, Age: {1}", person.Name, person.Age);
                }
            }
        }

        // custom filters for the people class/displaying
        static bool IsMinor(Person person) {
            return person.Age < 18;
        }

        static bool IsAdult(Person person) {
            return person.Age > 20;
        }

        static bool IsSenior(Person person) {
            return person.Age > 65;
        }

        static bool IsTeenager(Person person) {
            return person.Age >= 13 && person.Age <= 20;
        }
    }
}
