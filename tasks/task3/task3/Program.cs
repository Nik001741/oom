using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    //interface
    interface Computer
    {
        double MwstPreis();
        double n_Preis { get; }
        string Seriennum { get; }
        string Modell { get; }
        void Garantie(double preis);

    }

    public class Workstation : Computer
    {

        private const double Mwst = 0.2;

        public Workstation(string newmodellname, double newpreis, string newseriennum)
        {
            if (newmodellname == null || newmodellname.Length == 0)
                throw new Exception("Leerer Modellname");

            if (newseriennum == null || newseriennum.Length == 0)
                throw new Exception("Leerer Seriennummer");

            if (newpreis < 0.0)
                throw new Exception("Negativer Preis");

            Modell = newmodellname;
            n_Preis = newpreis;
            Seriennum = newseriennum;

        }

        public double MwstPreis()
        {
            double hilf = Mwst * n_Preis;
            return hilf + n_Preis;
        }
        public double n_Preis { get; }
        public string Seriennum { get; }
        public string Modell { get; }

        public void Garantie(double preis)
        {
            if (preis >= 1000) Console.WriteLine("5 Jahre Garantie");
            else Console.WriteLine("Keine Garantie");

        }

    }

    // class
    public class Notebooks : Computer
    {
        private const double Mwst = 0.2;

        // Fields


        // Properties
        public string Modell
        {
            get;
        }
        public string Seriennum
        {
            get;
        }
        public double n_Preis
        {
            get;
        }

        // Constructor
        public Notebooks(string newmodellname, double newpreis, string newseriennum)
        {
            if (newmodellname == null || newmodellname.Length == 0)
                throw new Exception("Leerer Modellname");

            if (newseriennum == null || newseriennum.Length == 0)
                throw new Exception("Leerer Seriennummer");

            if (newpreis < 0.0)
                throw new Exception("Negativer Preis");

            Modell = newmodellname;
            n_Preis = newpreis;
            Seriennum = newseriennum;

        }

        // Methode
        public double MwstPreis()
        {
            double hilf = Mwst * n_Preis;
            return hilf + n_Preis;
        }

        public void Garantie(double preis)
        {
            Console.WriteLine("Auf Notebooks gibt es keine Garantie");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var data = new Computer[] {
                new Notebooks("E571",300,"YSL234"),
                new Notebooks("E751",800,"YSL234"),
                new Workstation("P550",1500,"LSY456"),
                new Workstation("P900",2200,"AKS795")
            };
                double neuerpreis;

                foreach (var i in data)
                {
                    Console.WriteLine("Modellname: {0} ", i.Modell);
                    Console.WriteLine("Preis: {0} ", i.n_Preis);
                    Console.WriteLine("Seriennummer: {0} ", i.Seriennum);
                    neuerpreis = i.MwstPreis();
                    Console.WriteLine("Preis + Mwst = {0}", neuerpreis);
                    i.Garantie(neuerpreis);
                }




            }

            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                return;
            }



        }
    }
}
