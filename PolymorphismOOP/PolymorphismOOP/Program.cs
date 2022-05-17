using System;
using System.Collections.Generic;
using System.IO;

namespace PolymorphismOOP {
    class Program {
        static void Main(string[] args) {
            // Challenge: 
            /*
             * create a base class Car 
             * -contains 2 props: hp, and color
             * -make the constructor set those 2 props
             * -make a method called showdetails which will show the hp and the color of the car on the console
             * -make a method called repair that writes 'the car has been repaired' to the console
             * 
             * create 2 classes based on car: bmw and audi
             * - contains an additional prop: model, and a private prop called brand
             * 
             */

            /*var carsList = new List<Car> {
                new Audi(200, "blue", "A4"),
                new BMW(250, "black", "V6")
            };

            foreach (var aCar in carsList) {
                aCar.Repair();
            }
            // if you put sealed right after public in a method, then it will make it where no other derived class can override that method
            // you can only seal override methods; virtual methods can't be sealed
            // sealed can also be done to classes; for example, say we didn't want BMW to be inherited by M3 anymore, then you could put sealed in front of class BMW to stop it from being sealed by any more children

            // BMW and Audi have a 'is a' relationship: BMW is a Car; Audi is a Car
            // every car has car id info, so every class derived from (child of) Car 'has a' CarIDInfo

            // properties in a class can have getters and setters, adn then also a default value
            // you can set the default by having the prop = x;
            // ex: public int IDNum { get; set; } = 0; makes 0 default if they don't add a num on class instance creation

            Car car1 = new BMW(200, "black", "23");
            Car car2 = new Audi(250, "dark red", "v6");
            car1.ShowDetails();
            car2.ShowDetails();
            car1.SetCarIDInfo(1234, "bahamut");
            car2.SetCarIDInfo(9876, "shiva");
            car1.GetCarIDInfo();
            car2.GetCarIDInfo(); */

            // next up, abstract classes:
            // first, make an abstract class Shape - other classes will inherit from shape
            // by being abstract, you can't create instance objects of that class, but you can
            // use it's props, methods, etc. in other classes

            // you can make abstract methods in the abstract class, and those will have to be defined/overritten inside the child classes
            /*Cube aCube = new Cube(5);
            aCube.GetInfo();

            Sphere aSphere = new Sphere(5);
            aSphere.GetInfo();

            // the as keyword trys to convert something into something else, and returns null if it can't rather than having an error and crashing.
            //ex:

            Shape[] shapes = { aCube, aSphere};

            foreach (Shape aShape in shapes) {
                aShape.GetInfo();

                Cube aCubeTry = aShape as Cube;

                if (aCubeTry == null) {
                    Console.WriteLine("the shape was not a cube");
                } else {
                    Console.WriteLine("the shape was a cube");
                }
            } */

            // abstract vs interface
            // similarities:
            // both can't be instantiated (can't make an instance of one like interface aInterface = new interface() )
            // both support polymorphism
            // differences:
            // interface 
            //  - not implemented at all
            //  - can't have constructor
            //  - contains only method declaration
            //  - can't have fields
            //  - classes can implement/extend/inherit more than one interface 
            //  - classes must implement all it's members
            // abstract
            //  - either partially implemented or not implemented at all
            //  - can have constructor
            //  - may contain definitions, fields, methods
            //  - classes can extend/inherit only one class
            //  - classes must implement abstract members only (other ones can be implemented if virtual/override, but not required)


            // reading from a file
            /*string textFromFile = File.ReadAllText(@"C:\Users\william.frazier\OneDrive - West Point\Documents\c_sharp_practice\PolymorphismOOP\PolymorphismOOP\Assets\textFile.txt");
            Console.WriteLine("the text file contains the following text: {0}", textFromFile);

            // second way to read from file:
            string[] lines = File.ReadAllLines(@"C:\Users\william.frazier\OneDrive - West Point\Documents\c_sharp_practice\PolymorphismOOP\PolymorphismOOP\Assets\textFile.txt");

            foreach (string line in lines) {
                Console.WriteLine("here is one line from the text file: {0}", line);
            } */

            // next, we have writing to a file:
            // 2 ways to write to a file as well, here is the first:
            // careful, this way overrites anything that was in the file before, as you didn't say to print after stuff already in there or to keep that stuff.
            string[] fileLines = { "first line", "second line", "third line" };
            File.WriteAllLines(@"C:\Users\william.frazier\OneDrive - West Point\Documents\c_sharp_practice\PolymorphismOOP\PolymorphismOOP\Assets\textFile2.txt", fileLines);
            // print it out to see if wrote properly
            string textFromFile = File.ReadAllText(@"C:\Users\william.frazier\OneDrive - West Point\Documents\c_sharp_practice\PolymorphismOOP\PolymorphismOOP\Assets\textFile2.txt");
            Console.WriteLine("the text file contains the following text: {0}", textFromFile);
            
            // Challenge: write 3 high scores of users into a file from an array
            string[] highScores = { "kyle - 150", "shiva - 350", "bahamut - 750" };
            File.WriteAllLines(@"C:\Users\william.frazier\OneDrive - West Point\Documents\c_sharp_practice\PolymorphismOOP\PolymorphismOOP\Assets\highScores.txt", highScores);
            string fileHighScores = File.ReadAllText(@"C:\Users\william.frazier\OneDrive - West Point\Documents\c_sharp_practice\PolymorphismOOP\PolymorphismOOP\Assets\highScores.txt");
            Console.WriteLine("here is the high scores from the file: {0}", fileHighScores);
            
            // here is the second way to write to the file
            Console.WriteLine("please input some text to go into a file: ");
            string input = Console.ReadLine();
            File.WriteAllText(@"C:\Users\william.frazier\OneDrive - West Point\Documents\c_sharp_practice\PolymorphismOOP\PolymorphismOOP\Assets\inputFromConsole.txt", input);
            string fileInput = File.ReadAllText(@"C:\Users\william.frazier\OneDrive - West Point\Documents\c_sharp_practice\PolymorphismOOP\PolymorphismOOP\Assets\inputFromConsole.txt");
            Console.WriteLine("here is the high scores from the file: {0}", fileInput);

            // there is a third method to write to a file as well:
            // this method uses a stream writer
            using (StreamWriter file = new StreamWriter(@"C:\Users\william.frazier\OneDrive - West Point\Documents\c_sharp_practice\PolymorphismOOP\PolymorphismOOP\Assets\inputFromStreamWriter.txt")) {
                foreach (string line in fileLines) {
                    if (line.Contains("third")) {
                        file.WriteLine(line);
                    }
                }
            }
            string fileInput2 = File.ReadAllText(@"C:\Users\william.frazier\OneDrive - West Point\Documents\c_sharp_practice\PolymorphismOOP\PolymorphismOOP\Assets\inputFromStreamWriter.txt");
            Console.WriteLine("here is the stream input file: {0}", fileInput2);

            // add to a file that already has info: if you don't put anything after the filepath, it defaults to false; if it's true, it appends to end of file - otherwise it overrites it
            using (StreamWriter file = new StreamWriter(@"C:\Users\william.frazier\OneDrive - West Point\Documents\c_sharp_practice\PolymorphismOOP\PolymorphismOOP\Assets\inputFromStreamWriter.txt", true)) {
                file.WriteLine("additional line appended to end of file w/o deleting file hopefully");
            }
            string fileInput3 = File.ReadAllText(@"C:\Users\william.frazier\OneDrive - West Point\Documents\c_sharp_practice\PolymorphismOOP\PolymorphismOOP\Assets\inputFromStreamWriter.txt");
            Console.WriteLine("here is the stream input file: {0}", fileInput3);
        }
    }
}
