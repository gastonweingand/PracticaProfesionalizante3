using Services.DAL.Interfaces;
using Services.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.SqlServer.Adapters
{

    internal sealed class PatenteAdapter : IGenericAdapter<Patente>
    {
        #region Singleton
        private readonly static PatenteAdapter _instance = new PatenteAdapter();

        public static PatenteAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private PatenteAdapter()
        {
            //Implement here the initialization code
        }


        #endregion

        public Patente Adapt(object[] obj)
        {
            return new Patente()
            {
                Id = Guid.Parse(obj[0].ToString()),
                MenuName = obj[1].ToString(),
                FormName = obj[2].ToString()
            };
        }
    }
}
