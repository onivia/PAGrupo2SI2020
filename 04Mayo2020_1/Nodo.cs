using System;

namespace _04Mayo2020_1
{
    public class Nodo<T> where T : class
    {
        public T dato;
        public Nodo<T> sgte;


        public Nodo(T dato)
        {
            this.dato = dato;
            this.sgte = null;            
        }
    }
}
