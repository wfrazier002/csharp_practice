using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceOOProgramPractice {
    class Radio_old {
        public bool IsOn { get; set; }
        public string Brand { get; set; }
        public Radio_old(bool isOn, string brand) {
            this.Brand = brand;
            this.IsOn = isOn;
        }

        public void SwitchOn() {
            IsOn = true;
        }
        public void SwitchOff() {
            IsOn = false;
        }
        public void ListenToRadio() {
            if (IsOn) {
                Console.WriteLine("Listening to the radio.");
            } else {
                Console.WriteLine("The radio is not on. Please turn it on first to listen to it.");
            }
        }
    }
}
