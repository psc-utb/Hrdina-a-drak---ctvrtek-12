using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak___ctvrtek_12
{
    public class Mec
    {
        public double PoskozeniMax { get; set; }

        public Mec(double poskozeniMax)
        {
            PoskozeniMax = poskozeniMax;
        }

        public Mec Clone()
        {
            //return new Mec(PoskozeniMax);
            return this.MemberwiseClone() as Mec;
        }
    }
}
