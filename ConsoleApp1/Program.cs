using DAL.Factory;
using DAL.Implementations.Memory;
using DAL.Interfaces;
using Domain;
using Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Service obj1 = Service.GetInstance();
            Service obj2 = Service.GetInstance();

            Console.WriteLine(obj1 == obj2);

            Service.GetInstance().WriteMessage("Bienvenidos al singleton");

            Service.GetInstance().WriteMessage("Segundo mensaje...");




            Cliente cli = new Cliente() { Id = Guid.NewGuid(), CUIT = "8", Nombre = "Thomas" };

            IGenericRepository<Cliente> clientesRepo = FactoryDAL.Current.GetClientesRepository();

            foreach(Cliente cliente in clientesRepo.GetAll())
            {
                Console.WriteLine($"CUIT: {cliente.CUIT}, Nombre: {cliente.Nombre}");
            }

            Cliente clienteById = FactoryDAL.Current.GetClientesRepository().GetById(Guid.Parse("3d96ec6e-f3cc-ed11-840d-e8d8d142d59b"));
            Console.WriteLine($"CUIT: {clienteById.CUIT}, Nombre: {clienteById.Nombre}");

            clientesRepo.Add(cli);

            foreach (var item in clientesRepo.GetAll())
            {
                Console.WriteLine($"Cliente CUIT: {item.CUIT}");
            }
        }
    }
}
