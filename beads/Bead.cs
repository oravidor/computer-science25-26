using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beads
{
    public class Bead
    {
        private string color;
        private Bead nextBead;

        // קונסטרוקטורים
        public Bead(string color) { this.color = color; this.nextBead = null; }
        public Bead(string color, Bead nextBead) { this.color = color; this.nextBead = nextBead; }

        // מתודות Getters
        public string GetColor() { return color; }
        public Bead GetNextBead() { return nextBead; }

        // מתודת Setter
        public void SetNextBead(Bead nextBead) { this.nextBead = nextBead; }

        // מתודת ToString
        public override string ToString() { return color; }

    }
}
