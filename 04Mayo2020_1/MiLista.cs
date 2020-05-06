using System;
using System.Collections;
using System.Collections.Generic;

namespace _04Mayo2020_1
{
    public class MiLista<T> : IEnumerable<T> where T : class
    {
        private Nodo<T> p;
        private Nodo<T> u;
        int tamano;

        public MiLista()
        {
            this.p = null;
            this.u = null;
            this.tamano = 0;            
        }

        public bool estaVacia() {
            return (p==null && u==null);
        }

        public void Adicionar(T dato) {
            Nodo<T> nodo = null;

            nodo = new Nodo<T>(dato);
            if(estaVacia()) {
                p = nodo;
                u = nodo;
            }
            else {
                u.sgte = nodo;
                nodo = null;
            }
            tamano += 1;
        }

        public void Mostrar() {
            Nodo<T> nodoAux = null;

            nodoAux = p;
            while(nodoAux!=null) {
                Console.WriteLine(nodoAux.dato);
                nodoAux = nodoAux.sgte;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Nodo<T> nodoAux = null;

            nodoAux = p;
            while(nodoAux!=null) {
                yield return nodoAux.dato;
                nodoAux = nodoAux.sgte;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
