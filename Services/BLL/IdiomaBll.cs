using Services.DAL;
using Services.Domain.BusinessExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL
{

    public sealed class IdiomaBll
    {
        #region Singleton
        private readonly static IdiomaBll _instance = new IdiomaBll();

        public static IdiomaBll Current
        {
            get
            {
                return _instance;
            }
        }

        private IdiomaBll()
        {
            //Implement here the initialization code
        }
        #endregion

        public String Traducir(String key)
        {
            try
            {
                return IdiomaRepository.Current.Traducir(key);
            }
            catch (PalabraNoEncontradaExcepcion ex)
            {
                throw ex;
            }            
        }
    }

}
