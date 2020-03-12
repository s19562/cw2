using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Cwiczenie2
{
    public class Program
    {


        

        public static void Main(string[] args)
        {
            //LEKCJA 
            //ArrayList 
            var l = new List<string>();
            //Set 
            var s = new HashSet<string>();
            //Map
            var m = new Dictionary<string, int>();

            //PROGRAM
            string plikWejscie = @"Data/dane.csv";

            

            List<Student> studenci = CzytajLinie.czytaj(plikWejscie);


            
        }
    }
}
