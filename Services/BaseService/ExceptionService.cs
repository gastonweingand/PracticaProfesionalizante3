using Services.Domain.ServicesExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BaseService
{

    public sealed class ExceptionService
    {
        #region Singleton
        private readonly static ExceptionService _instance = new ExceptionService();

        public static ExceptionService Current
        {
            get
            {
                return _instance;
            }
        }

        private ExceptionService()
        {
            //Implement here the initialization code
        }
        #endregion

        //public void HandleException(Exception ex)
        //{


        //}

        public void HandleException(DALException ex)
        {
            //Bitacora
            //Ver bitácora... Severidad, format
            Console.WriteLine(ex.InnerException.Message + ex.StackTrace);
            throw ex;
        }

        public void HandleException(BLLException ex)
        {
            //Política en BLL pero de exceptions desde la DAL
            if(ex.InnerException is DALException)
            {
                //Aplicar política de envoltura....
                throw ex;
            }

            //Política de reglas propias del negocio
            if(ex.IsBusinessException)
            {
                //Política de exceptions propias de mi negocio
                //ClienteNoExisteException...
                //Bitacora
                //Ver bitácora... Severidad, format
                Console.WriteLine(ex.InnerException.Message + ex.StackTrace);
                throw ex;
            }

            //? Estoy en un punto donde no tengo ni Exception de Acceso a datos y tampoco tengo una regla de negocio aplicada....
            // Bug?

        }
        public void HandleException(UIException ex)
        {

        }
    }

}
