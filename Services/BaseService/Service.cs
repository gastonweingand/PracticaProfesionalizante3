using Services.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BaseService
{ 
    public class Service
    {
        #region Singleton
        private Service()
        {

        }
        //Mi propia instancia
        private static Service service;
        private static object objetoBloqueo = new object();
        public static Service GetInstance()
            //Solución Thread Safe del patrón singleton
        {
            if (service == null)
            {
                lock (objetoBloqueo)
                {
                    if (service == null)
                    {
                        service = new Service();
                    }
                }
            }
              
            return service;
        }
        #endregion

        private String path = ConfigurationManager.AppSettings["PathFile"];
        public void WriteMessage(String msg)
        {
            using (StreamWriter str = new StreamWriter(path, true))
            {
                str.WriteLine(msg);
            }
        }

        public String Traducir(String key)
        {
            try
            {
                return IdiomaBll.Current.Traducir(key);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public List<String> GetIdiomasDisponibles()
        {
            return null;
        }
    }
}
