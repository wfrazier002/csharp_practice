using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceOOProgramPractice {
    class TV_old {
        public bool IsOn { get; set; }
        public string Brand { get; set; }

        public TV_old(bool isOn, string brand) {
            this.IsOn = isOn;
            this.Brand = brand;
        }

        public void SwitchOn() {
            IsOn = true;
        }
        public void SwitchOff() {
            IsOn = false;
        }

        public void WatchTV() {
            if (IsOn) {
                Console.WriteLine("Watching Tv.");
            } else {
                Console.WriteLine("Can't watch tv until it is turned on. Please turn it on first.");
            }
        }
    }
}
