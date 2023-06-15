using Microsoft.Extensions.Logging;
using Services.DAL.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.PlainText
{
    internal class BitacoraRepository : IBitacora
    {
        private String pathFile;
        public BitacoraRepository()
        {
            pathFile = ConfigurationManager.AppSettings["PathFile"] + DateTime.Now.ToString("ddMMyyyy") + ".log";
        }
        public List<LogEntry> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<LogEntry> GetByFilter(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public List<LogEntry> GetByFilter(DateTime from, DateTime to, LogLevel level)
        {
            throw new NotImplementedException();
        }

        public List<LogEntry> GetByFilter(DateTime from, DateTime to, string usuario)
        {
            throw new NotImplementedException();
        }

        public List<LogEntry> GetByFilter(DateTime from, DateTime to, string mensaje, LogLevel level)
        {
            throw new NotImplementedException();
        }

        public void Write(string mensaje, LogLevel level)
        {
            using (StreamWriter str = new StreamWriter(pathFile, true))
            {
                string formattedMessage = $"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} [{level.ToString()}]: {mensaje}";
                str.WriteLine(formattedMessage);
            }            
        }

        public void Write(LogEntry log)
        {            
            throw new NotImplementedException();
        }
    }
}
