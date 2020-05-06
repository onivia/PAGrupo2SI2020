using System;

namespace _04Mayo2020_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Probar_MiLista();
        }

        public static void Probar_MiLista() {
            MiLista<Cliente> clientes = new MiLista<Cliente>();

            clientes.Adicionar(new Cliente("123","panaderia"));
            clientes.Adicionar(new Cliente("456","la tienda de lili"));

            //clientes.Mostrar();
            foreach(Cliente c in clientes) {
                Console.WriteLine(c);
            }
        }
    }
}
