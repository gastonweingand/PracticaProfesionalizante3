using Services.Domain.BusinessExceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.DAL
{

    internal sealed class IdiomaRepository : IIdiomaRepository
    {
        #region Singleton
        private readonly static IdiomaRepository _instance = new IdiomaRepository();

        public static IdiomaRepository Current
        {
            get
            {
                return _instance;
            }
        }

        private IdiomaRepository()
        {
            //Implement here the initialization code
        }
        #endregion

        private String path = ConfigurationManager.AppSettings["IdiomaPathName"];
        private String folderLang = ConfigurationManager.AppSettings["FolderIdiomaPath"];

        /// <summary>
        /// Retorna la palabra traducida...
        /// </summary>
        /// <param name="key"></param>
        /// <param name="idiomaDestino"></param>
        /// <returns>o se puede lanzar una PalabraNoEncontradaExcepcion...</returns>
        public String Traducir(String key)
        {
            String destinationPath = folderLang + "/" + path + Thread.CurrentThread.CurrentUICulture.Name;

            using (StreamReader sr = new StreamReader(destinationPath))
            {
                while (!sr.EndOfStream)
                {
                    String linea = sr.ReadLine();
                    String destinationKey = linea.Split('=')[0];

                    if (destinationKey == key)
                        return linea.Split('=')[1];
                }
            }

            //Qué pasa si estoy acá?
            throw new PalabraNoEncontradaExcepcion();
        }

        public List<CultureInfo> GetIdiomasDisponibles()
        {
            List<CultureInfo> idiomas = new List<CultureInfo>();

            foreach (var item in new DirectoryInfo(folderLang).GetFiles())
            {
                idiomas.Add(new CultureInfo(item.Extension.Substring(1)));
            }

            return idiomas;
        }
    }



}
