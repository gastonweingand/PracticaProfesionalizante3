using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations.Memory
{
    public class ClienteMemoryRepository : IGenericRepository<Cliente>
    {
        private List<Cliente> clientes = new List<Cliente>();
        public ClienteMemoryRepository()
        {
            clientes.Add(new Cliente() { CUIT = "1", Id = Guid.NewGuid(), Nombre = "Pepe" });
            clientes.Add(new Cliente() { CUIT = "2", Id = Guid.NewGuid(), Nombre = "Jorge" });
            clientes.Add(new Cliente() { CUIT = "3", Id = Guid.NewGuid(), Nombre = "Juan" });
        }
        public void Add(Cliente obj)
        {
            clientes.Add(obj);
        }

        public void Delete(Guid id)
        {
            Cliente cliente= clientes.Single(o => o.Id == id);
            clientes.Remove(cliente);
        }

        public List<Cliente> GetAll()
        {
            return clientes;
        }

        public Cliente GetById(Guid id)
        {
            return clientes.Single(o => o.Id == id);
        }

        public void Update(Cliente obj)
        {
            Cliente cliente = clientes.Single(o => o.Id == obj.Id);
            cliente.Nombre = obj.Nombre;
            cliente.CUIT = obj.CUIT;
        }
    }
}
