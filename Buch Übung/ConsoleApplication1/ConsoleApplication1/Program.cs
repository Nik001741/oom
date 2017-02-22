using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Buch
    {
        public static double Mwst = 0.1;

        private string title;
        private double price;

        public Buch(string derTitel, double derPreis)
        {
            if (derTitel == null || derTitel.Length == 0)
                throw new Exception("Leerer Titel");
            title = derTitel;

            Preis = derPreis;

        }

        public string GetTitle() => title;
        public double Preis
        {
            get
            {
                return price;
            }

            set
            {
                if (value < 0.0) throw new Exception("Negativer Preis");
                price = value;

            }

        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Buch.Mwst = 123123;

            try
            {
                Buch a = new Buch("Testbuch", 123.5);
                a.Preis = -100;

                Console.WriteLine($"Buch: {a.GetTitle()} {a.Preis}");

            }
            catch (Exception e)
            {
                Console.WriteLine($"Es ist schon wieder was passiert! ({e.Message})");
                return;
            }
            
        }
    }
}
