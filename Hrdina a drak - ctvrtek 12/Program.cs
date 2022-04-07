using System;
using System.Collections.Generic;

namespace Hrdina_a_drak___ctvrtek_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Mec mec = new Mec(20);
            Hrdina hrdina = new Hrdina("Geralt", 100, 100, 10, 10, mec);
            Drak drak = new Drak("Alduin", 100, 100, 11, 10);
            Drak drak2 = new Drak("Šmak", 100, 100, 11, 10);
            Vlk vlk = new Vlk("Wolf", 50, 50, 5, 5 );

            Hrdina klonHrdiny = hrdina.Clone();
            klonHrdiny.Jmeno += " (klon)";
            klonHrdiny.Zdravi = 150;
            klonHrdiny.Utekl = true;
            klonHrdiny.Mec.PoskozeniMax = 50;
            Console.WriteLine(hrdina.ToString());
            Console.WriteLine(klonHrdiny.ToString() + Environment.NewLine);

            /*
            Arena arena = new Arena(hrdina, drak);
            arena.Boj();*/

            List<Postava> postavy = new List<Postava> { hrdina, drak, drak2, vlk };

            //Array.Sort(postavy);
            //Array.Reverse(postavy);
            //postavy.Sort();
            //postavy.Reverse();
            postavy.Add(new Hrdina("hrdina 5", 50, 50, 5, 5, new Mec(5)));
            //postavy.Remove(drak2);
            //postavy.RemoveAt(1);
            foreach(var postava in postavy)
            {
                Console.WriteLine(postava);
            }
            Console.WriteLine(String.Empty);

            ArenaProPostavy arenaProPostavy = new ArenaProPostavy(postavy);
            arenaProPostavy.Boj();
        }
    }
}
