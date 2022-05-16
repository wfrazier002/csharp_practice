using System;

namespace InheritanceOOProgramPractice {
    class Program {
        static void Main(string[] args) {
            // originally, radio and tv have a lot of props/methods that are similar or the same
            // meaning they were copied over and used multiple times

            // one way to deal w/ this is to create another class that has generic versions of those props/methods, then inhert them in the 2 classes. if there is something that needs to be different, then you can overrite it to match that particular class

            // challenge! create the third class that has the props and methods, then refactor the 2 classes (actually, rename them old classes and then remake them based on the challenge class)
            /*Radio radio = new Radio(true, "fm");
            TV tV = new TV(true, "cartoon network");

            radio.PlayDevice();
            tV.PlayDevice(); */

            // Challenge 2: create a class called animal and give it the following properties:
            // -name, age, isHungry, constructor, method called make sound, method called eat, method called play
            /*Dog aDog = new Dog("bartholomu", 5);
            aDog.Play();
            aDog.MakeSound();
            aDog.Eat();
            Cat aCat = new Cat("cait sith", 5);
            aCat.Play();
            aCat.MakeSound();
            aCat.Eat(); */

            // protected means it can only be used by that class and any class that inherts from that class
            // this is the default constructor
            /*Post myPost = new Post();
            // this one uses the other constructor
            Post myPost2 = new Post("my first post!", false, "D. B.");

            Console.WriteLine(myPost.ToString());
            Console.WriteLine(myPost2.ToString());
            Post myPost3 = new Post("testing id value", false, "D. B.");
            Console.WriteLine(myPost3.ToString());

            // this is the default constructor
            ImagePost myImagePost = new ImagePost();
            // this one uses the other constructor
            ImagePost myImagePost2 = new ImagePost("my first image post!", false, "D. B.", "https://www.google.com/images/games");
            // Challenge: overrite the tostring method from post and add in the url that imagepost contains
            Console.WriteLine(myImagePost.ToString());
            Console.WriteLine(myImagePost2.ToString()); */

            // Challenge: create a VideoPost class - also derived from Post class, w/ a VideoURL prop and a length prop
            // change the toString to match this new class
            // add in Timer and Callback methods here (will need to google them)
            // create any fields they require
            // add another method called Play which writes the current duration of the video
            // and a Stop method which stops the timer and writes stopped at __ s 
            // Play the video after the class is created, and  have it pause when the user presses a button
            /*VideoPost aVideoPost = new VideoPost("my first video post!", false, "D. B.", "https://www.youtube.com/videos/gamesReview",10);
            Console.WriteLine(aVideoPost.ToString());
            aVideoPost.Play();
            Console.WriteLine("press any key to stop the video...");
            Console.ReadKey();
            aVideoPost.Stop();
            Console.ReadLine(); */

            // Challenge 
            /*
             * Create a main class with the Main Method, then a base class Employee with the properties Name, FirstName, Salary, and the methods Work() and Pause().

                Create a deriving class boss with the property CompanyCar and the method Lead().  Create another deriving class of employees - trainees with the properties WorkingHours and SchoolHours and a method Learn().

                Override the methods Work() of the trainee class so that it indicates the working hours of the trainee.

                Don’t forget to create constructors.

                Create an object of each of the three classes (with arbitrary values)

                and call the methods, Lead() of Boss and Work() of Trainee.

                Just print out the respective text, what the respective employees do.
                E.g. Lead() should print out something like. I'm leading. It is up to you what you print out.
             */
            /*Boss aBoss = new Boss("Bahamut Zero", "Zero", 250000, "tesla");
            Trainee aTrainee = new Trainee("dark wtf", "wtf", 20000,15,40);
            aBoss.Lead();
            aTrainee.Work(); */

            // interfaces - don't have the implementations in it, just have the definitions/layout/"plan" for what you want for a class/classes; any class implementing it must define/use every method/prop used in it.
            // test this out by making a class ticket and have it implement an interface IEquatable
            Ticket ticket1 = new Ticket(10);
            Ticket ticket2 = new Ticket(10);
            Console.WriteLine("{0} compared to {1} => {2}", ticket1.DurationInHours, ticket2.DurationInHours, ticket1.Equals(ticket2));
        }
    }
}
