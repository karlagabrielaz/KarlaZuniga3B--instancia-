using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSTANCIATAREA
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> listacliente = new List<Cliente>()
            {
                new Cliente(){Id=1, Nombre="Karla"},
                new Cliente(){Id=2, Nombre="Helen"},
                new Cliente(){Id=3, Nombre="Diego"},
                new Cliente(){Id=4, Nombre="Melissa"},
                new Cliente(){Id=5, Nombre="Sebastian"},
                new Cliente(){Id=6, Nombre="Mathias"},
                new Cliente(){Id=7, Nombre="Dayana"},
                new Cliente(){Id=8, Nombre="Nicole"},
                new Cliente(){Id=9, Nombre="Yuleidy"},
                new Cliente(){Id=10, Nombre="Emma"},
            };

            List<Factura> listafactura = new List<Factura>()
            {
             new Factura() {Observacion = "Problema numero 1", Idcliente=1, Fecha= new DateTime(2019,05,11), Total= 18.50 },
             new Factura() {Observacion = "Ninguna", Idcliente=2, Fecha= new DateTime(2018,03,12), Total= 3 },
             new Factura() {Observacion = "Factura con datos", Idcliente=3, Fecha= new DateTime(2008,08,11), Total= 20 },
             new Factura() {Observacion = "Consumidor Final", Idcliente=4, Fecha= new DateTime (2017,12,31), Total= 6.45 },
             new Factura() {Observacion = "Ninguna", Idcliente=5, Fecha= new DateTime(2019,07,14), Total= 2.50 },
             new Factura() {Observacion = "Problema numero 2", Idcliente=6, Fecha= new DateTime(2010,01,12), Total= 15.65 },
             new Factura() {Observacion = "Ninguna", Idcliente=7, Fecha= new DateTime(2004,08,03), Total= 13.25 },
             new Factura() {Observacion = "Consumidor Final", Idcliente=8, Fecha= new DateTime(2019,04,28), Total= 10.40 },
             new Factura() {Observacion = "Factura con datos", Idcliente=9, Fecha= new DateTime( 2016,06,24), Total= 5.75 },
             new Factura() {Observacion = "Probablemente problema numero 3", Idcliente=10, Fecha= new DateTime(2018/07/18), Total= 9.80 },
            };

            Console.WriteLine("CLIENTES ORDENADOS POR NOMBRE");
            var resultado = from i in listacliente orderby i.Nombre
                            //   join t in listafactura on i.Id equals t.Idcliente
                            select new
                            {
                                Nombre = i.Nombre,
                                //        Factura= t.Total
                            };
            foreach (var item in resultado)
            {
                Console.WriteLine("{0}\t", item.Nombre);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("VENTAS ORDENADAS POR FECHA");
            var resultado2 = from i in listafactura orderby i.Fecha
                             select new
                             {
                                 Fecha = i.Fecha,
                             };
            foreach (var item in resultado2)
            {
                Console.WriteLine("{0}\t", item.Fecha);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("3 CLIENTES CON MÁS MONTO DE VENTAS");
            var masmonto = from i in listafactura where i.Total > 15
                             join t in listacliente on i.Idcliente equals t.Id
                             select new
                             {
                                 TotalFactura = i.Total,
                                 Nombre = t.Nombre
                             };
            foreach (var item in masmonto)
                {
                    Console.WriteLine("{0}\t ${1}", item.Nombre, item.TotalFactura);
                }

            /////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("3 CLIENTES CON MENOS MONTO DE VENTAS");
            var menosmonto = from i in listafactura where i.Total < 6
                             join t in listacliente on i.Idcliente equals t.Id
                             select new
                             {
                                 TotalFactura = i.Total,
                                 Nombre = t.Nombre
                             };
            foreach (var item in menosmonto)
                {
                    Console.WriteLine("{0}\t ${1}", item.Nombre, item.TotalFactura);
                }
            /////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("CLIENTE MAS VENTAS REALIZADAS");
            var clientemasventas = from i in listafactura where i.Total > 19
                             join t in listacliente on i.Idcliente equals t.Id
                             select new
                             {
                                 TotalFactura = i.Total,
                                 Nombre = t.Nombre
                             };
            foreach (var item in clientemasventas)
            {
                Console.WriteLine(item.Nombre);
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("CLIENTE Y CANTIDAD DE VENTAS REALIZADAS");
            var clienteycantidadventas = from i in listafactura 
                                   join t in listacliente on i.Idcliente equals t.Id
                                   select new
                                   {
                                       TotalFactura = i.Total,
                                       Nombre = t.Nombre
                                   };

            
            foreach (var item in clienteycantidadventas)
            {
                    Console.WriteLine("{0}\t {1}", item.Nombre, item.TotalFactura);
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Ventas realizadas hace menos de un año");
            var resultado11 = from i in listafactura where i.Fecha > new DateTime(2018, 03, 12)
                              select new
                              {
                                  Fecha = i.Fecha,
                              };
            foreach (var item in resultado11)
            {
                Console.WriteLine(item.Fecha);
            }

            ///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Venta más antigua");
            var resultado10= from i in listafactura where i.Fecha <= new DateTime(2004, 08, 03)
                             select new
                             {
                                 Fecha = i.Fecha,
                             };
            foreach (var item in resultado10)
            {
                Console.WriteLine(item.Fecha);
            }
            //////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Última venta realizada");
            var resultado9 = from i in listafactura where i.Fecha > new DateTime(2019, 05, 11) 
                             select new
                             {
                                 Fecha = i.Fecha,
                             };
            foreach (var item in resultado9)
            {
                Console.WriteLine(item.Fecha);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("CLIENTES QUE TENGAN VENTAS CUYA OBSERVACIÓN EMPIEZE CON PROB");
            var resultado8 = from i in listafactura
                             where i.Observacion.StartsWith("Prob")
                             join t in listacliente on i.Idcliente equals t.Id
                             select new
                             {
                                 Observacion = i.Observacion,
                                 Nombre = t.Nombre,
                             };


            foreach (var item in resultado8)
            {
                Console.WriteLine("Cliente: {0}", item.Nombre);
            }
            
            Console.ReadKey();
        }
    }
}

//termima EndsWith

