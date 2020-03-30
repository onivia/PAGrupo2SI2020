using System;

namespace _30Marzo2020_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Inmutabilidad
            string s1 = "100";
            string s2 = s1;
            s1 = "200";
            Console.WriteLine($"s1: {s1}");
            Console.WriteLine($"s2: {s2}");
        }
    }
}
