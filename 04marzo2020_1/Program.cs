using System;

namespace _04marzo2020_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] a1 = {10,20};

            a1[0] = 50;
            Console.WriteLine(string.Join("\n",a1));

            //string cadena = "";
            //Console.WriteLine("Entre cadena: "); //cout
            //cadena = Console.ReadLine(); //cin
            //Console.WriteLine($"La cadena entrada fue: {cadena}");
        }
    }
}
