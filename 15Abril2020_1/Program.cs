using System.Xml.Linq;
using System.Linq;
using System;
using System.Collections.Generic;

namespace _15Abril2020_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            prueba_List1();
        }

        public static void prueba_List1() {
            List<Cliente> clientes = new List<Cliente>{ new Cliente(100,"pedrito"),
            new Cliente(200,"juanito") };
            
            clientes.Add(new Cliente(300,"maria"));
            
            //Buscar
            // Cliente cliente = new Cliente(200,"juanito");
            // bool existeCliente = clientes.Contains(cliente);
            //Console.WriteLine($"Existe?: {existeCliente}");

            //Obtener
            //Cliente cliente = clientes.Where(x => x.codigo==300).First();
            //Console.WriteLine(cliente);

            //Actualizar
            //Cliente cliente = clientes.Where(x => x.codigo==100).First();
            //cliente.razonSocial = "jose";
            //clientes.Where(x => x.codigo==100).First().razonSocial = "jose";
            // foreach(Cliente i in clientes) {
            //     if(i.codigo==100) {
            //         i.razonSocial = "jose";
            //     }
            // }
            // foreach(Cliente i in clientes) {
            //     Console.WriteLine(i);
            // }

            //Remover
            //clientes.Remove(clientes.Where(x => x.codigo==100).First());
            foreach(Cliente i in clientes.ToList()) {
                    if(i.codigo==100) {
                        clientes.Remove(i);
                    }
            }
            foreach(Cliente i in clientes) {
                Console.WriteLine(i);
            }
        }
    }
}
