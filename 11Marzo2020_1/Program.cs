using System;

namespace _11Marzo2020_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Cliente cliente = new Cliente();
            cliente.Nit = "123";
            Console.WriteLine($"Nit: {cliente.nit}");
        }
    }
}
