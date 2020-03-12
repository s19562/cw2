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

            //ArrayList 
            var l = new List<string>();
            //Set 
            var s = new HashSet<string>();
            //Map
            var m = new Dictionary<string, int>();


            //XLM 
            FileStream writer = new FileStream(@"data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                                       new XmlRootAttribute("uczelnia"));

            //Wczytywaie pliku 
            string file = @"Data/dane.csv";

            FileInfo f = new FileInfo(file);

            var list = new List<Student>();

            using (StreamReader stream = new StreamReader(f.OpenRead()))
            {

                string line = "";

                while ((line = stream.ReadLine()) != null)
                {
                    string[] studentWiersz = line.Split(',');

                    for (int i = 0; i < studentWiersz.Length; i += 9)
                    {

                        var st = new Student
                        {
                            Imie = studentWiersz[i],
                            Nazwisko = studentWiersz[i + 1],
                            Kierunek = studentWiersz[i + 2],
                            numer_indexu = studentWiersz[i + 4],
                            data_urodzenia = studentWiersz[i + 5],
                            Email = studentWiersz[i + 6],
                            imie_matki = studentWiersz[i + 7],
                            imie_ojca = studentWiersz[i + 8],
                           
                        };

                        //kierynek 2
                        //index4
                        //uro5
                        //mail6
                        //mama7
                        //mode3

                        list.Add(st);
                        // stream.Dispose(); //.... IDisposible

                    }

                    // ... 
                    serializer.Serialize(writer, list);
                    Console.WriteLine(line);

                }
            }







            


        }
    }
}
