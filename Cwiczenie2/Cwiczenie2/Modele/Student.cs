using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cwiczenie2
{
    public class Student
    {

        //prop + tabx2 
        //ObservableCollestion<T>
        //MVVM


        [XmlElement(elementName:"fname")]
        public string Imie { get; set; }

        [XmlElement(elementName: "lname")]
        public string Nazwisko { get; set; }

        [XmlAttribute(attributeName: "indexNumber")]
        public string numer_indexu { get; set; }

        public string Kierunek { get; set; }

        [XmlElement(elementName: "birthdate")]
        public string data_urodzenia { get; set; }

        [XmlAttribute(attributeName: "email")]
        public string Email { get; set; }

        [XmlElement(elementName: "mothersName")]
        public string imie_matki { get; set; }

        [XmlElement(elementName: "fathersName")]
        public string imie_ojca { get; set; }


        







    }
}
