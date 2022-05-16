using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceOOProgramPractice {
    class Ticket : IEquatable<Ticket> {
        public int DurationInHours { get; set; }

          public Ticket(int durationInHours) {
            this.DurationInHours = durationInHours;
        }

        /*bool IEquatable<Ticket>.Equals(Ticket other) {
            throw new NotImplementedException();
        } */
        public bool Equals(Ticket otherTicket) {
            // for this project, assume if hrs == then they are the same
            return this.DurationInHours == otherTicket.DurationInHours;
        }
    }
}
