using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceOOProgramPractice {
    class Electronics {
        // Challenge - create this class, then create radio new and tv new to inherit from this class

        public bool IsOn { get; set; }
        public string Brand { get; set; }

        public Electronics(bool isOn, string brand) {
            this.IsOn = isOn;
            this.Brand = brand;
        }
        public void SwitchOn() {
            IsOn = true;
        }
        public void SwitchOff() {
            IsOn = false;
        }
        public void PlayDevice() {
            if (IsOn) {
                Console.WriteLine($"Listening/Watching the {this.GetType().Name}.");
            } else {
                Console.WriteLine($"The {this.GetType().Name} is not on. Please turn it on first to listen/watch it.");
            }
        }
    }
}
