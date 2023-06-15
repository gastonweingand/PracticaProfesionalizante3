using Services.DAL.Implementations.PlainText;
using Services.DAL.Implementations.SqlServer;
using Services.DAL.Interfaces;
using Services.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Factory
{
    internal sealed class FactoryDAL
    {   
        #region Singleton
        private readonly static FactoryDAL _instance = new FactoryDAL();

        public static FactoryDAL Current
        {
            get
            {
                return _instance;
            }
        }

        private FactoryDAL()
        {
            //Implement here the initialization code
        }
        #endregion

        private String backend = ConfigurationManager.AppSettings["BackendSL"];

        public IGenericRepository<Patente> GetPatenteRepository()
        {
            switch (backend)
            {
                case "SqlServer":
                    return PatenteRepository.Current;
                default:
                    return null;
            }
        }

        public IBitacora GetBitacoraRepository()
        {
            return new BitacoraRepository();
        }
    }


}
