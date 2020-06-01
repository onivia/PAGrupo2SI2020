using System;
using System.Collections.Generic;

namespace _15Mayo2020._base
{
    public class Arbol
    {
        private NodoArbol raiz;
        private Queue<NodoArbol> nodosPendientes;

        public Arbol() {
            this.raiz = null;
            this.nodosPendientes = new Queue<NodoArbol>();
        }

        public bool estaVacio() {
            return (raiz==null);
        }

        public void Insertar(int llave, string dato) {
            NodoArbol nodo = null;
            NodoArbol nodoAux = null;

            nodo = new NodoArbol(llave, dato);

            if(estaVacio()) {
                raiz = nodo;
            }
            else {
                nodoAux = raiz;
                while(true) {
                    if(nodo.llave < nodoAux.llave) {
                        if(nodoAux.izq!=null) {
                            nodoAux = nodoAux.izq;
                        }
                        else {
                            nodoAux.izq = nodo;
                            break;
                        }                        
                    }
                    else if(nodo.llave > nodoAux.llave) {
                        if(nodoAux.der!=null) {
                            nodoAux = nodoAux.der;
                        }
                        else {
                            nodoAux.der = nodo;
                            break;
                        }
                    }
                    else { //la llave ya existe
                        throw new Exception($"la llave ya existe {llave}, NO se permiten llaves duplicadas.");
                    }
                }
            }
        }
    
        public void Recorrer_Amplitud() {
            NodoArbol nodoAux = null;

            if(!estaVacio()) {
                nodosPendientes.Enqueue(raiz);

                while(hayEnCola()) {
                    nodoAux = desencolar();
                    mostrarDato(nodoAux);
                    encolarHijosNodo(nodoAux);                    
                }                
            }
        }

        private void mostrarDato(NodoArbol nodo) {
            Console.WriteLine($@"{nodo.llave}");
            //Console.WriteLine($@"{nodo.dato}");
        }

        private void encolarHijosNodo(NodoArbol nodo) {
            if(nodo!=null) {
                if(nodo.izq!=null)
                    nodosPendientes.Enqueue(nodo.izq);
                if(nodo.der!=null)
                    nodosPendientes.Enqueue(nodo.der);
            }
        }

        private NodoArbol desencolar() {
            return nodosPendientes.Dequeue();
        }

        private bool hayEnCola() {
            return (nodosPendientes.Count>0);
        }
    }    
}
