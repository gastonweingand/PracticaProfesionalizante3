using Services.Domain.BusinessExceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.DAL
{

    public sealed class IdiomaDal
    {
        #region Singleton
        private readonly static IdiomaDal _instance = new IdiomaDal();

        public static IdiomaDal Current
        {
            get
            {
                return _instance;
            }
        }

        private IdiomaDal()
        {
            //Implement here the initialization code
        }
        #endregion

        private String path = ConfigurationManager.AppSettings["IdiomaPath"];

        /// <summary>
        /// Retorna la palabra traducida...
        /// </summary>
        /// <param name="key"></param>
        /// <param name="idiomaDestino"></param>
        /// <returns>o se puede lanzar una PalabraNoEncontradaExcepcion...</returns>
        public String Traducir(String key)
        {
            String destinationPath = path + Thread.CurrentThread.CurrentUICulture.Name;

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
    }

}
