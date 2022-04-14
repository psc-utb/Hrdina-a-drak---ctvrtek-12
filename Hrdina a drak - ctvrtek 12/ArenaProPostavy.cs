using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak___ctvrtek_12
{
    public class ArenaProPostavy
    {
        public List<Postava> Postavy { get; set; }

        public ArenaProPostavy(Postava[] postavy)
        {
            Postavy = postavy.ToList();
            PropojEventAMetodu();
        }

        public ArenaProPostavy(List<Postava> postavy)
        {
            Postavy = postavy;
            PropojEventAMetodu();
        }

        void PropojEventAMetodu()
        {
            foreach(var postava in Postavy)
            {
                postava.VyberNovehoOponenta += VypisInfaPoUdalosti;
            }
        }


        public void Boj()
        {
            Bedna bedna = new Bedna(50, 2);
            while (MuzeSeBojovat())
            {
                for (int i = 0; i < Postavy.Count; ++i)
                {
                    Postava utocnik = Postavy[i];
                    if (utocnik.MuzeBojovat())
                    {
                        Postava oponent = utocnik.VyberOponenta(Postavy);
                        if (oponent != null)
                        {
                            double utok;
                            if (bedna.NeniRozbita())
                            {
                                utok = utocnik.Utok(bedna);
                                Console.WriteLine($"{utocnik.Jmeno} rozbijí bednu hodnotou {utok}. Bedna má {bedna.Zdravi} životů.");

                                if (bedna.NeniRozbita() == false)
                                    utocnik.Zdravi += 0.3 * utocnik.ZdraviMax;
                            }

                            utok = utocnik.Utok(oponent);
                            Console.WriteLine($"{utocnik.Jmeno} zaútočil hodnotou {utok}. {oponent.Jmeno} má {oponent.Zdravi} životů.");
                            if (oponent.MuzeBojovat())
                            {
                                utok = oponent.Utok(utocnik);
                                Console.WriteLine($"{oponent.Jmeno} oplatil útokem hodnotou {utok}. {utocnik.Jmeno} má {utocnik.Zdravi} životů.");
                            }
                        }
                    }
                }
                Console.WriteLine(String.Empty);
            }
        }

        public bool MuzeSeBojovat()
        {
            int pocetBojujicichPostav = PocetBojujicichPostav();

            if (pocetBojujicichPostav > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int PocetBojujicichPostav()
        {
            int pocetBojujicichPostav = 0;
            foreach (var postava in Postavy)
            {
                if (postava.MuzeBojovat() && postava.MuzeSiVybratOponenta(Postavy))
                {
                    ++pocetBojujicichPostav;
                }
            }
            return pocetBojujicichPostav;
        }

        void VypisInfaPoUdalosti(Postava utocnik, Postava oponent)
        {
            Console.WriteLine($"Postava: {utocnik.Jmeno} si vybrala nového oponenta: {oponent.Jmeno}");
        }

    }
}
