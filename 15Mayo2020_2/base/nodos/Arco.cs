using System.Collections.Generic;

namespace _15Mayo2020._base.nodos
{
    public class Arco
    {
        public int peso;
        public NodoGrafo nodo;

        public Arco(int peso, NodoGrafo nodo)
        {
            this.peso = peso;
            this.nodo = nodo;            
        }
    }
}
