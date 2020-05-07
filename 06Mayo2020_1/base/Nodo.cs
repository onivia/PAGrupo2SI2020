using System;

namespace _06Mayo2020_1
{
    public class Nodo
    {
        public Nodo izq;
        public Nodo der;
        public int llave;
        public string dato;

        public Nodo(int llave, string dato)
        {
            this.llave = llave;
            this.dato = dato;
            this.izq = null;
            this.der = null;
        }
    }
}
