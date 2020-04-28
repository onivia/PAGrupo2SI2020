using System;

namespace _20abril2020_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Prueba_MiLista();            
        }

        public static void Prueba_MiLista() {
            MiLista lista = new MiLista();
            lista.Adicionar(20); //0
            lista.Adicionar(30); //1
            lista.Adicionar(10); //2
            lista.Adicionar(40); //3

            //lista.InsertarNodoxPosicion(new Nodo(220),0);
            //lista.RemoverPrimero();
            //Nodo nodo = lista.ObteneryRemoverPrimero();
            //Console.WriteLine($"Se obtuvo el dato: {nodo.dato}");
            //lista.Actualizar(50,1);
            lista.Ordernar(false);

            lista.Mostar();
        }
    }
}
