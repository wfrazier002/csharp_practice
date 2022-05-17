using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismOOP {
    class CarIDInfo {
        // every car should have an id
        public int IDNum { get; set; } = 0;
        // every car should have an owner
        public string Owner { get; set; } = "no owner";
    }
}
