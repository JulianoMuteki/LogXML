using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace LogXML
{
    [XmlType("Log")]
    public class Log
    {
        [XmlElement("Usuario")]
        public string Usuario { get; set; }

        [XmlElement("Idade", DataType = "int")]
        public int Idade { get; set; }

        [XmlElement("Email")]
        public string Email { get; set; }

        [XmlElement("DataHora", DataType = "dateTime")]
        public DateTime DataHora { get; set; }

        public Log()
        {
        }
    }
}
