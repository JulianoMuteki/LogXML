using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LogXML
{
    public class Repositorio
    {
        public void SalvarLogXML(IList<Log> listaLogs,string urlFileName)
        {
            LogSerialization logS = new LogSerialization(listaLogs);

            if (!File.Exists(urlFileName))
            {
                SerializeToXml<LogSerialization>(logS, urlFileName);
            }
            else
            {
                var logAntigo = DeserializeFromXml<LogSerialization>(urlFileName);
                logS.Logs.AddRange(logAntigo.Logs);
                File.Delete(urlFileName);
                SerializeToXml<LogSerialization>(logS, urlFileName);
            }
        }

        public IList<Log> RetornarLogs(string urlFileName)
        {
            var logXML = DeserializeFromXml<LogSerialization>(urlFileName);
            return logXML.Logs;
        }

        private static void SerializeToXml<T>(T obj, string fileName)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (StreamReader reader = new StreamReader(memoryStream))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(memoryStream, obj);
                    memoryStream.Position = 0;
                    string xml = reader.ReadToEnd();
                    reader.Close();
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.LoadXml(xml);
                    xdoc.Save(fileName);
                }
                memoryStream.Close();
            }
        }

        private static T DeserializeFromXml<T>(string xml)
        {
            T result;
            XmlReader reader = new XmlTextReader(xml);

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            result = (T)serializer.Deserialize(reader);
            reader.Close();
            return result;
        }
    }

}
