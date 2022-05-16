using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceOOProgramPractice {
    class TV : Electronics{
        public TV(bool isOn, string brand) : base(isOn, brand) {

        }
    }
}
