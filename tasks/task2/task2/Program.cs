using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    // class
    public class Notebooks
    {
        private const double Mwst = 0.2;

        // Fields
        private string modellname;
        private double preis;
        private string seriennummer;

        // Properties
        public string Modell
        {
            get
            {
                return modellname;
            }

            set
            {
                if (value == null || value.Length == 0)
                    throw new Exception("Leerer Modellname");

                modellname = value;
            }
        }
        public string Seriennum
        {
            get
            {
                return seriennummer;
            }

            set
            {
                if (value == null || value.Length == 0)
                    throw new Exception("Leerer Seriennummer");

                seriennummer = value;
            }
        }
        public double n_Preis
        {
            get
            {
                return preis;
            }

            set
            {
                if (value < 0.0)
                    throw new Exception("Negativer Preis");

                preis = value;
            }
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

            modellname = newmodellname;
            preis = newpreis;
            seriennummer = newseriennum;

        }

        // Methode
        public double MwstPreis()
        {
            double hilf = Mwst * preis;
            return hilf + preis;
        }



    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Notebooks a = new Notebooks("E571", 300, "YSL234");
                Console.WriteLine("Modellname: {0} ", a.Modell);
                Console.WriteLine("Preis: {0} ", a.n_Preis);
                Console.WriteLine("Seriennummer: {0} ", a.Seriennum);

                double neuerpreis = a.MwstPreis();

                Console.WriteLine("Preis + Mwst = {0}", neuerpreis);
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                return;
            }



        }
    }
}