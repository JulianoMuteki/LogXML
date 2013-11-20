using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogXML
{
    class Program
    {
        static void Main(string[] args)
        {

            string urlFileName = System.IO.Path.Combine(@"E:\Estudos", string.Format("Log_{0}.xml", DateTime.Now.Date.Ticks));

            IList<Log> logs = new List<Log>();
            logs.Add( new Log(){ Usuario = "Juliano", Email = "juliano.pestili@outlook.com", Idade = 27, DataHora = DateTime.Now});
            logs.Add( new Log(){ Usuario = "Thiago", Email = "thiago@XXX.com", Idade = 35, DataHora = DateTime.Now});
            logs.Add( new Log(){ Usuario = "João", Email = "joao@xxxx.com", Idade = 20, DataHora = DateTime.Now});

            Repositorio repositorio = new Repositorio();
            repositorio.SalvarLogXML(logs, urlFileName);

            logs.Clear();
            logs.Add(new Log() { Usuario = "Ricardo", Email = "Ricardo@XXX.com", Idade = 40, DataHora = DateTime.Now });
            logs.Add(new Log() { Usuario = "Marcelo", Email = "Marcelo@xxxx.com", Idade = 23, DataHora = DateTime.Now });

            repositorio.SalvarLogXML(logs, urlFileName);

            var oldLogs = repositorio.RetornarLogs(urlFileName);

        }
    }
}
