using System;
using System.Collections.Generic;

namespace _13Abril2020_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Prueba_List();
            //Prueba_Dictionary();
        }

        //Tips, uso de List:
        /*
            multiples elementos
            no se tiene un identificador unico de cada elemento
            no importa si hay repetidos
            no importa el tiempo de respuesta de las busquedas
        */
        public static void Prueba_List() {
            List<string> nombres = new List<string>() {"oskr", "pedrito", "maria"};
            nombres.Add("juan");
            nombres.Add("jose");
            nombres.Add("maria");

            nombres[5] = "manuel";
            nombres.Remove("manuel");

            foreach(string i in nombres) {
                Console.WriteLine($"{i}");
            }
        }

        //Tips, uso de Dictionary:
        /*
            multiples elementos
            se tiene un identificador unico de cada elemento
            cuando no hay repetidos por su key
            se necesitan atender rapidamente busquedas
        */
        public static void Prueba_Dictionary() {
            Dictionary<int,string> nombres = new Dictionary<int, string>(){
                {100,"oskr"},
                {200,"pedrito"},
                {300,"maria"}
            };
            nombres.Add(500,"juan");
            nombres.Add(400,"jose");

            nombres[300] = "luz";
            nombres.Remove(500);

            foreach(KeyValuePair<int,string> i in nombres) {
                Console.WriteLine($"Key: {i.Key}-value: {i.Value}");
            }
        }
    }
}
