using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsApp_Linq_Demo_1 {
    class Program {
        static void Main(string[] args) {
            int[] numArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 99, 999, 9999, 99999999 };
            OddNumbers(numArray);
        }

        static void OddNumbers(int[] numArray) {
            Console.WriteLine("Odd Numbers from the array of #s:");
            // filling a collection/array using linq expression
            // basically like a select stmt, but the select part is at the end
            // another way to think of it is that the from part is a foreach loop, the where is a filter, and the select grabs each that correctly filters and puts into the left side variable
            IEnumerable<int> oddNums = from number in numArray where number % 2 != 0 select number;
            foreach (int num in oddNums) {
                Console.Write("{0}, ", num);
            }
                
        }
    }
}
