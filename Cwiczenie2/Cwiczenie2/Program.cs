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

            //Wczytywaie pliku 
            string file = "dane.csv";

            FileInfo f = new FileInfo(file);

            using (StreamReader stream = new StreamReader(f.OpenRead()))
            {

                string line = "";

                while ((line = stream.ReadLine()) != null)
                {
                    string[] studentWiersz = line.Split(',');
                    Console.WriteLine(line);

                }

            } // stream.Dispose(); //.... IDisposible

            //XLM 
            FileStream writer = new FileStream(@"data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                                       new XmlRootAttribute("uczelnia"));

            var list = new List<Student>();
            var st = new Student
            {
                Imie="Jan",
                Nazwisko="Kowalski",
                Email = "kowalski@wp.pl"
            };
            list.Add(st);
            // ... 
            serializer.Serialize(writer, list);

        }
    }
}
