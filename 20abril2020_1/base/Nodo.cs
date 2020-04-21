using System;

namespace _20abril2020_1
{
    public class Nodo
    {
        public int dato { get; set; }
        public Nodo sgte { get; set; }

        public Nodo(int dato)
        {
            this.dato = dato;
            this.sgte = null;                        
        }
    }
}
