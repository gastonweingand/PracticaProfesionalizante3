using Microsoft.Extensions.Logging;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Interfaces
{
    public interface IBitacora
    {
        void Write(String mensaje, LogLevel level);

        void Write(LogEntry log);

        List<LogEntry> GetAll();

        List<LogEntry> GetByFilter(DateTime from, DateTime to);

        List<LogEntry> GetByFilter(DateTime from, DateTime to, LogLevel level);

        List<LogEntry> GetByFilter(DateTime from, DateTime to, String usuario);

        List<LogEntry> GetByFilter(DateTime from, DateTime to, String mensaje, LogLevel level);

    }
}
