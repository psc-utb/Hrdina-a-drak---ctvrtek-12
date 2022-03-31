using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak___ctvrtek_12
{
    public class Hrdina : Postava
    {
        
        public Mec Mec { get; set; }

        public Hrdina(string jmeno, double zdravi, double zdraviMax, double poskozeniMax, double zbrojMax, Mec mec) : base(jmeno, zdravi, zdraviMax, poskozeniMax, zbrojMax)
        {
            Mec = mec;
        }

        public override double Utok(IZasazitelny oponent)
        {
            if (Mec != null)
            {
                return Utok(oponent, Mec.PoskozeniMax);
            }
            else
            {
                //return Utok(oponent, PoskozeniMax);
                return base.Utok(oponent);
            }
        }

        public Hrdina Clone()
        {
            //Hrdina klon = new Hrdina(Jmeno, Zdravi, ZdraviMax, PoskozeniMax, ZbrojMax, Mec.Clone());
            //klon.Utekl = Utekl;
            Hrdina klon = this.MemberwiseClone() as Hrdina;
            klon.Mec = this.Mec.Clone();
            return klon;
        }

        public override string ToString()
        {
            return $"{Jmeno}, Zdravi: {Zdravi}, ZdraviMax: {ZdraviMax}, PoskozeniMax: {PoskozeniMax}, ZbrojMax: {ZbrojMax}, Utekl: {Utekl}, Mec-poskozeniMax: {Mec.PoskozeniMax}, Hodnoceni postavy: {HodnoceniPostavy()}";
        }

        public override bool KontrolaOponenta(Postava oponent)
        {
            return true;
        }
    }
}
