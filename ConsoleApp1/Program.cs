﻿using DAL.Factory;
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
using Services.DAL;
using Observador;
using Microsoft.Extensions.Logging;
using Services.Domain;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            new BitacoraService().Write("Prueba", LogLevel.Information);
            Services.Domain.LogEntry log = new Services.Domain.LogEntry();
            log.Descripcion = "Probando bitácora con más datos";
            new BitacoraService().Write(log);

            List<LogEntry> entries = new BitacoraService().GetByFilter(DateTime.Now, DateTime.Now, LogLevel.Information);

            foreach (var item in entries)
            {
                Console.WriteLine(item.Descripcion);
            }

            Stack<string> pila = new Stack<string>();
            pila.Push("Elemento 1");
            pila.Push("Elemento 2");

            string peekElement = pila.Peek();

            Console.WriteLine($"último elemento ingresado sin quitarlo: {peekElement}");

            string quitadoElement = pila.Pop();

            Console.WriteLine($"último elemento ingresado quitado: {quitadoElement}");

            quitadoElement = pila.Pop();

            Console.WriteLine($"último elemento ingresado quitado: {quitadoElement}");


            //Patrón observer
            IBM ibm = new IBM("IBM", 120.00);
            ibm.Attach(new Investor("Sorros"));
            ibm.Attach(new Investor("Berkshire"));
            // Fluctuating prices will notify investors
            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 121.00;
            ibm.Price = 121.00;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;
            // Wait for user
            Console.ReadKey();


           /* Services.DAL.Interfaces.IGenericRepository<Patente> repoPatente = Services.DAL.Factory.FactoryDAL.Current.GetPatenteRepository();
            foreach (var item in repoPatente.GetAll())
            {
                Console.WriteLine(item.FormName);
            }

            Patente patenteOne = repoPatente.GetById(Guid.Parse("5bd7188d-1269-4621-9a16-d9051779ff5c"));

            Console.WriteLine(patenteOne.FormName);

            Console.WriteLine(Thread.CurrentThread.CurrentUICulture);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");

            String demo = "Bienvenidos".Traducir();


            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            demo = "Bienvenidos".Traducir();

            //String otraPalabra = "Otra".Traducir();

            List<CultureInfo> idiomas = IdiomaRepository.Current.GetIdiomasDisponibles();

            foreach (var item in idiomas)
            {
                Console.WriteLine($"Nombre idioma: {item.Name}, displayName: {item.DisplayName}");
            }

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

            */





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
            LanguageService obj1 = LanguageService.GetInstance();
            LanguageService obj2 = LanguageService.GetInstance();

            Console.WriteLine(obj1 == obj2);

            LanguageService.GetInstance().WriteMessage("Bienvenidos al singleton");

            LanguageService.GetInstance().WriteMessage("Segundo mensaje...");
        }
    }
}
