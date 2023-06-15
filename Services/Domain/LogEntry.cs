using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class LogEntry
    {
        public DateTime Fecha { get; set; }

        public String Descripcion { get; set; }

        public LogLevel Level { get; set; }

        public String Usuario { get; set; }

    }
}
