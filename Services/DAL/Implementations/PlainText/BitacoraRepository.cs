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
            //?

            //Pensar un método que busque los archivos que cumplen la condición from/to
            List<FileInfo> archivosBitacora = new List<FileInfo>();

            archivosBitacora.Add(new FileInfo(pathFile));

            List<LogEntry> entries = new List<LogEntry>();

            foreach (var item in archivosBitacora)
            {
                using (StreamReader streamReader = new StreamReader(item.FullName))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string line = streamReader.ReadLine();

                        if(line.Contains($"[{level.ToString()}]"))
                        {
                            //Mapper
                            string[] cabecera = line.Split('[');
                            string[] mensaje = line.Split(new string[] { "]: " }, StringSplitOptions.RemoveEmptyEntries);

                            LogEntry log = new LogEntry();
                            log.Fecha = DateTime.Parse(cabecera[0].Trim());
                            log.Level = level;
                            log.Descripcion = mensaje[1].Substring(0, mensaje[1].IndexOf(',') );
                            log.Usuario = line.Split(new string[] { ", usuario:" }, StringSplitOptions.None)[1].Trim();
                            entries.Add(log);
                        }
                    }

                }
            }

            return entries;
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
            //FileInfo fileInfo = new FileInfo(pathFile);
            //fileInfo.Length

            using (StreamWriter str = new StreamWriter(pathFile, true))
            {
                string formattedMessage = $"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} [{level.ToString()}]: {mensaje}, usuario:";
                str.WriteLine(formattedMessage);
            }            
        }

        public void Write(LogEntry log)
        {   
            throw new NotImplementedException();
        }
    }
}
