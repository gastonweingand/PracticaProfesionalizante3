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
using Services.Domain.Composite;
using Services.Extensions;
using System.Threading;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.CurrentUICulture);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");

            String demo = "Bienvenidos".Traducir();


            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            demo = "Bienvenidos".Traducir();

            String otraPalabra = "Otra".Traducir();

            //String palabra = Service.GetInstance().Traducir("Bienvenidos", "en-US");
            //String palabra2 = Service.GetInstance().Traducir("Bienvenidos", "es-AR");
            //Console.WriteLine(palabra);
            //Console.WriteLine(palabra2);

            Patente patenteVentas = new Patente();
            patenteVentas.FormName = "frmVentas";
            patenteVentas.MenuName = "mnuCrearVenta";
            patenteVentas.Id = Guid.NewGuid();

            Patente patenteCompras = new Patente();
            patenteCompras.FormName = "frmCompras";
            patenteCompras.MenuName = "mnuCrearCompra";
            patenteCompras.Id = Guid.NewGuid();

            Patente patenteReporte = new Patente();
            patenteReporte.FormName = "frmReporte";
            patenteReporte.MenuName = "mnuVerReportes";
            patenteReporte.Id = Guid.NewGuid();

            Familia jefe = new Familia();
            jefe.NombrePerfil = "Jefe";
            jefe.Add(patenteCompras);
            jefe.Add(patenteVentas);

            Familia administrador = new Familia();
            administrador.NombrePerfil = "Admin";
            administrador.Add(jefe);
            administrador.Add(patenteReporte);

            User usuario = new User();
            usuario.Permisos.Add(jefe);
            usuario.Permisos.Add(administrador);
            usuario.Permisos.Add(patenteCompras);

            List<Patente> patentes = usuario.GetPatentes();

            foreach (var item in patentes)
            {
                Console.WriteLine($"Patente: {item.FormName}, {item.MenuName}");
            }







            //Singleton();

            //RepositoryPattern();
        }

        private static void RepositoryPattern()
        {
            Cliente cli = new Cliente() { Id = Guid.NewGuid(), CUIT = "8", Nombre = "Thomas" };

            IGenericRepository<Cliente> clientesRepo = FactoryDAL.Current.GetClientesRepository();

            foreach (Cliente cliente in clientesRepo.GetAll())
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

        private static void Singleton()
        {
            Service obj1 = Service.GetInstance();
            Service obj2 = Service.GetInstance();

            Console.WriteLine(obj1 == obj2);

            Service.GetInstance().WriteMessage("Bienvenidos al singleton");

            Service.GetInstance().WriteMessage("Segundo mensaje...");
        }
    }
}
