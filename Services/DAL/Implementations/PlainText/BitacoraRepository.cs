using Microsoft.Extensions.Logging;
using Services.DAL.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.PlainText
{
    public class BitacoraRepository : IBitacora
    {
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
            throw new NotImplementedException();
        }

        public void Write(LogEntry log)
        {
            throw new NotImplementedException();
        }
    }
}
