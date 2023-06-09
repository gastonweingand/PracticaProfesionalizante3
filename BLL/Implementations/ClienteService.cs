using BLL.Interfaces;
using Domain;
using Services.Domain.ServicesExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.BaseService;
using BLL.BusinessExceptions;
using DAL.Factory;

namespace BLL.Implementations
{
    //Armar singleton...
    public class ClienteService : IGenericBusinessRule<Cliente>
    {
        public void Add(Cliente obj)
        {
            try
            {
                int a = 0;
                int b = 8;

                if (a < b)
                    throw new ClienteNoExisteException();
            }
            catch(ClienteNoExisteException ex)
            {
                ExceptionService.Current.HandleException(ex);
            }
            catch (Exception ex)
            {
                ExceptionService.Current.HandleException(new BLLException(ex));
                throw;
            }
        }

        public List<Cliente> GetAll()
        {
            return FactoryDAL.Current.GetClientesRepository().GetAll();
        }

        public void Update(Cliente obj)
        {
            throw new NotImplementedException();
        }
    }
}
