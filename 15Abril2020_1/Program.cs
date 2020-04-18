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
            //prueba_Dict1();
            //prueba_List1();
            prueba_OperadoresEvaluadoresDeNULL();
        }

        public static void prueba_OperadoresEvaluadoresDeNULL() {
            Cliente c = null;

            Console.WriteLine(c?.razonSocial ?? "cliente es null");

            // if(c!=null)
            //     Console.WriteLine(c.razonSocial);
            // else
            //     Console.WriteLine("cliente es null");
        }

        public static void prueba_Dict1() {
            Dictionary<int,Cliente> clientes = new Dictionary<int, Cliente>() {
                {1,new Cliente(100,"pedrito")},
                {2,new Cliente(200,"juanito")},
                {3,new Cliente(300,"maria")},
                {4,new Cliente(400,"jose")}
            };
            clientes.Where(x => x.Value.razonSocial.StartsWith('j'))
                    .Select(x => { x.Value.razonSocial = "hermanos de dict"; return x; }).ToList();
            foreach(KeyValuePair<int,Cliente> i in clientes) {
                Console.WriteLine(i.Value);
            }
        }

        public static void prueba_List1() {
            List<Cliente> clientes = new List<Cliente>{
                new Cliente(100,"pedrito"),
                new Cliente(200,"juanito"),
                new Cliente(300,"maria"),
                new Cliente(400,"jose")
            };
            //obtener n
            //Linq: un paquete que provee un mecanismo de trabajo funcional con expresion lambda
            List<Cliente> otrosClientes = clientes
                                            .Where(x => x.razonSocial.StartsWith('j'))
                                            .Select(x => { x.razonSocial = "hermanos"; return x; })                                            
                                            .ToList();
            otrosClientes.ForEach(Console.WriteLine);
            
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
            // foreach(Cliente i in clientes.ToList()) {
            //         if(i.codigo==100) {
            //             clientes.Remove(i);
            //         }
            // }
            // foreach(Cliente i in clientes) {
            //     Console.WriteLine(i);
            // }
        }
    }
}
