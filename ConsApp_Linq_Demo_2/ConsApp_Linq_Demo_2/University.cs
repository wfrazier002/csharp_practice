using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsApp_Linq_Demo_2 {
    class University {
        public int Id { get; set; }
        public string Name { get; set; }

        public void ShowInfo() {
            Console.WriteLine("University {0} w/ id {1}", Name, Id);
        }
    }
}
