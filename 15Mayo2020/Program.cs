using System;
using _15Mayo2020._base;

namespace _15Mayo2020
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Prueba_Grafo();
            //Prueba_RecorrerArbolAmplitud();
            //Prueba_TablaHash();
        }

        public static void Prueba_RecorrerArbolAmplitud() {
            //TODO:
            //1. Convertir la estructura 'Arbol' para que el 'dato' sea Generic (la llave siempre debera ser int), Ejs: Arbol<Cliente>, Arbol<string>, etc...
            //2. Permitir que una instancia tipo 'Arbol' sea iterada dentro de un foreach con un recorrido por Amplitud.
            Arbol datos = new Arbol();
            datos.Insertar(10,"diez");
            datos.Insertar(5,"cinco");
            datos.Insertar(15,"quince");
            datos.Insertar(1,"uno");
            datos.Insertar(20,"veinte");

            datos.Recorrer_Amplitud();
        }

        public static void Prueba_Grafo() {
            //TODO:
            //1. Implementar y probar el metodo MostrarNodos().
            //2. Cuando se llame al metodo InsertarRelacionarNodo, ajustarlo para que se incremente el contador 'cantidadNodos'. Realizar la prueba.
            //3. Implemetar y probar el metodo MostrarRuta.
            Grafo grafo = new Grafo();

            grafo.InsertarRelacionarNodo(null,"A", 0); //'A' es el nodo de Inicio            
            grafo.InsertarRelacionarNodo("A","B", 2);
            grafo.InsertarRelacionarNodo("B","C", 5);
            grafo.InsertarRelacionarNodo("B","D", 4);
            grafo.InsertarRelacionarNodo("C","D", 1);
            grafo.InsertarRelacionarNodo("D","E", 1);
            grafo.InsertarRelacionarNodo("C","E", 3);

            grafo.MostrarGrafo();
        }

        public static void Prueba_TablaHash() {
            //TODO:
            //1. Implementar y probar el uso propio de una TablaHash para strings.
            //Insercion
            //Busqueda
            TablaHash tabla = new TablaHash(5);
            tabla.Insertar("maria");
            //tabla.Insertar("Maria");

            //tabla.MostrarDato("MARIA");
        }
    }
}
