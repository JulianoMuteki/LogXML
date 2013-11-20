using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace LogXML
{

    [XmlRoot("LogXML")]
    public class LogSerialization
    {
       // [XmlArray("LogArray")]
        [XmlArrayItem("Log", typeof(Log))]
        public List<Log> Logs = new List<Log>();
        public LogSerialization(IList<Log> logs)
        {
            this.Logs = logs.ToList();
        }

        public LogSerialization()
        {

        }

    }
}
