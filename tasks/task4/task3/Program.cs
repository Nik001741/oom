﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace task3
{
    //interface
    interface Computer
    {
        double MwstPreis();
        double N_Preis { get; }
        string Seriennum { get; }
        string Modell { get; }
        void Garantie(double preis);

    }

    public class Workstation : Computer
    {

        private const double Mwst = 0.2;

        [JsonConstructor]
        public Workstation(string modell, double n_Preis, string seriennum)
        {
           /* if (newmodellname == null || newmodellname.Length == 0)
                throw new Exception("Leerer Modellname");

            if (newseriennum == null || newseriennum.Length == 0)
                throw new Exception("Leerer Seriennummer");

            if (newpreis < 0.0)
                throw new Exception("Negativer Preis");
*/
            Modell = modell;
            N_Preis = n_Preis;
            Seriennum = seriennum;

        }

        public double MwstPreis()
        {
            double hilf = Mwst * N_Preis;
            return hilf + N_Preis;
        }
        public double N_Preis { get; }
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
        public double N_Preis
        {
            get;
        }

        // Constructor

        [JsonConstructor]
        public Notebooks(string modell, double n_Preis, string seriennum)
        {
    /*        if (newmodellname == null || newmodellname.Length == 0)
                throw new Exception("Leerer Modellname");

            if (newseriennum == null || newseriennum.Length == 0)
                throw new Exception("Leerer Seriennummer");

            if (newpreis < 0.0)
                throw new Exception("Negativer Preis");
*/
            Modell = modell;
            N_Preis = n_Preis;
            Seriennum = seriennum;

        }

        // Methode
        public double MwstPreis()
        {
            double hilf = Mwst * N_Preis;
            return hilf + N_Preis;
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

            var data = new Computer[] {
                new Notebooks("E571",300,"YSL234"),
                new Notebooks("E751",800,"YSL234"),
                new Workstation("P550",1300,"YLS234") };


            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented };
            var json = JsonConvert.SerializeObject(data, settings);
            var directory = Directory.GetCurrentDirectory();
            var filename = Path.Combine(directory, "computer.json");
            File.WriteAllText(filename, json);


            var jsonfile = File.ReadAllText(filename);
            var newdata = JsonConvert.DeserializeObject<Computer[]>(jsonfile, settings);

            foreach (var i in newdata)
            {
                Console.WriteLine("{0}, {1}, {2}", i.Modell, i.N_Preis, i.Seriennum);
            }


        }

    }
}

