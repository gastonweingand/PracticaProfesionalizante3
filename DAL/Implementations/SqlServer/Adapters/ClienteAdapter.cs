using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations.SqlServer.Adapters
{

    public sealed class ClienteAdapter : IGenericAdapter<Cliente>
    {
        #region Singleton
        private readonly static ClienteAdapter _instance = new ClienteAdapter();
            
        public static ClienteAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private ClienteAdapter()
        {
            //Implement here the initialization code
        }


        #endregion

        public Cliente Adapt(object[] obj)
        {
            return new Cliente()
            {
                Id = Guid.Parse(obj[(int)CLIENTECOLUMNA.id].ToString()),
                CUIT = obj[1].ToString(),
                Nombre = obj[2].ToString()
            };
        }

        public enum CLIENTECOLUMNA
        {
            id,
            cuit,
            nombre
        }
    }

}
