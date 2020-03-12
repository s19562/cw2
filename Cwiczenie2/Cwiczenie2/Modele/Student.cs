using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Cwiczenie2;

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

        [XmlElement(elementName: "birthdate")]
        public string data_urodzenia { get; set; }

        [XmlAttribute(attributeName: "indexNumber")]
        public string numer_indexu { get; set; }

        [XmlElement(elementName: "email")]
        public string Email { get; set; }

        [XmlElement(elementName: "mothersName")]
        public string imie_matki { get; set; }

        [XmlElement(elementName: "fathersName")]
        public string imie_ojca { get; set; }

        public Studies studies { get; set; }
    }

    
    
    public class Studies
    {

        public string name { get; set; }
        public string mode { get; set; }
    }


}


public class Uczelnia
{
    [XmlAttribute(attributeName: "createdAt")]
    public string czas { get; set; }
    [XmlAttribute(attributeName: "author")]
    public string autor { get; set; }

    public List<Student> studenci { get; set; }

}