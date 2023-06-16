﻿using Microsoft.Extensions.Logging;
using Services.DAL.Factory;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BaseService
{
    public class BitacoraService
    {
        public void Write(String mensaje, LogLevel level)
        {
            FactoryDAL.Current.GetBitacoraRepository().Write(mensaje, level);
        }

        public void Write(LogEntry log)
        {

        }

        public List<LogEntry> GetAll()
        {
            return null;
        }

        public List<LogEntry> GetByFilter(DateTime from, DateTime to)
        {
            return null;
        }

        public List<LogEntry> GetByFilter(DateTime from, DateTime to, LogLevel level)
        {
            return FactoryDAL.Current.GetBitacoraRepository().GetByFilter(from, to, level);
        }

        public List<LogEntry> GetByFilter(DateTime from, DateTime to, String usuario)
        {
            return null;
        }

        public List<LogEntry> GetByFilter(DateTime from, DateTime to, String mensaje, LogLevel level)
        {
            return null;
        }

    }
}
