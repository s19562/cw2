﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Cwiczenie2
{
    public class CzytajLinie
    {

        static List<Student> list = new List<Student>();
        static Dictionary<string, int> studKU = new Dictionary<string, int>();
        public static List<Student> czytaj(string plikWejscie)
        {




            //LETS GETET STARTET YEE


            //string file = @"Data/dane.csv";


            try
            {
                if (!File.Exists(plikWejscie))
                    throw
                        new FileNotFoundException("Plik nie istnieje");

                /*var regex = new Regex(@"[A-Z,a-z]\/[A-Z,a-z]\.csv");
                var name = plikWejscie.Substring(0, plikWejscie.LastIndexOf('v'));
                if (!regex.IsMatch(name))
                    throw
                        new ArgumentException("Podana ścieżka jest niepoprawna");

nwm czemu mi to nie dziala próbowalam to naprawic godzine
ale zakladam ze jak sciezka bedzie zla to wywali FileNotFoE
                       */ 
                        
                        

                //XLM
               
               

                
                //Wczytywaie pliku 


                FileInfo f = new FileInfo(plikWejscie);

                


          

                using (StreamReader stream = new StreamReader(f.OpenRead()))
                {

                    string line = "";

                    while ((line = stream.ReadLine()) != null)
                    {
                        string[] studentWiersz = line.Split(',');



                        for (int i = 0; i < studentWiersz.Length; i += 9)
                        {
                            bool jakTam1 = sprawdzamStudenta(studentWiersz, line);
                            if (jakTam1)
                            {
                                Studies s = new Studies
                                {
                                    name = studentWiersz[2],
                                    mode = studentWiersz[3],
                                };


                                var st = new Student
                                {
                                    Imie = studentWiersz[i],
                                    Nazwisko = studentWiersz[i + 1],
                                    numer_indexu = "s" + studentWiersz[i + 4],
                                    data_urodzenia = studentWiersz[i + 5],
                                    Email = studentWiersz[i + 6],
                                    imie_matki = studentWiersz[i + 7],
                                    imie_ojca = studentWiersz[i + 8],
                                    studies = new Studies { name = studentWiersz[i + 2], mode = studentWiersz[i + 3] },
                                    studKU = s
                                    
                                };
                        list.Add(st);

                                if (studKU.ContainsKey(s.name))
                                {
                                    studKU[s.name]++;

                                }
                                else
                                {
                                    studKU.Add(s.name, 1);
                                }
                            }

                            //kierynek 2,3
                            //index4
                            //uro5
                            //mail6
                            //mama7
                            //mode3

                           
                            // stream.Dispose(); //.... IDisposible

                        }

                        // ... 
                        

                    }

                    ActiveStudies active = new ActiveStudies()
                                {
                                    ACl = new List<AC>()
                                };

                                foreach (KeyValuePair<string, int> entry in studKU)
                                {
                                    AC a = new AC
                                    {
                                        name = entry.Key,
                                        number = entry.Value
                                    };
                                    active.ACl.Add(a);
                                }
                    Uczelnia uczelnia = new Uczelnia
                                {
                                    studenci = list,
                                    autor = "Patrycja Dankowska",
                                    czas = System.DateTime.Now.ToString(),
                                    activeStudies = active
                                };
                  
                    FileStream writer = new FileStream(@"data.xml", FileMode.Create);
                     XmlSerializer serializer = new XmlSerializer(typeof(Uczelnia),
                                           new XmlRootAttribute("uczelnia"));

                    serializer.Serialize(writer, uczelnia);
                    Console.WriteLine(line + "zakonczenie robienia xml i log ,nacisnij enter i sprawdz bin");
                }

                
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
                //throw;
            }
            catch(ArgumentException e1)
            {
                Console.WriteLine(e1);
            }

            return list;

        }



        public static bool sprawdzamStudenta(String[] student, String line)
        {
            bool jakTam = true;

            if (student.Length < 9)
            {
                PiszBledy.piszLog(line + " --> za mało danych");

                jakTam = false;
            }
            else
            {
                for (int i = 0; i < student.Length; i++) {
                    if (student[i].Equals(""))
                    {
                        PiszBledy.piszLog(line + " --> puste pole");
                        jakTam = false;
                    }
                }

            }

            foreach(var uczen in list)
            {
                if(uczen.Imie.Equals(student[0]) && uczen.Nazwisko.Equals(student[1])
                    && uczen.numer_indexu.Equals("s" + student[4]))
                {
                    PiszBledy.piszLog(line + " --> student juz istnieje");

                    jakTam = false;
                }
            }



            return jakTam;
        }










    }
}

