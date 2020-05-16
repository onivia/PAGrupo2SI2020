using System;
using System.Collections.Generic;
using System.Linq;

namespace _15Mayo2020._base
{
    public class Grafo
    {
        private NodoGrafo inicio;
        private int cantidadNodos;

        public Grafo()
        {
            this.inicio = null;
            this.cantidadNodos = 0;            
        }

        public bool estaVacio() {
            return (inicio==null);
        }

        public void InsertarRelacionarNodo(string labelPredecesor, string labelNodo, int peso) {
            NodoGrafo nodo = null;
            NodoGrafo nodoPredecesor = null;

            nodo = new NodoGrafo(labelNodo, peso);
            if(labelPredecesor==null && estaVacio()) {
                inicio = nodo;
            }
            else if(!estaVacio() && existeNodo(labelPredecesor)) {
                nodoPredecesor = ObtenerNodo(labelPredecesor);
                relacionarNodo(nodoPredecesor, nodo);
            }
        }

        public void MostrarGrafo() {
            NodoGrafo nodoAux = null;
            Queue<NodoGrafo> nodosPendientes = null;

            if(!estaVacio()) {
                nodosPendientes = new Queue<NodoGrafo>();
                nodosPendientes.Enqueue(inicio);
                while(nodosPendientes.Any()) {
                    nodoAux = nodosPendientes.Dequeue();
                    mostrarNodoRelaciones(nodoAux, nodosPendientes.Any());
                    foreach(NodoGrafo n in nodoAux.arcos ?? Enumerable.Empty<NodoGrafo>()) {
                        if(!nodosPendientes.Any(x => x.label.ToUpper().Equals(n.label.ToUpper()))) //No permite encolar ya encolados, asi se evita mostrar nodos–predecesores ya mostrados
                            nodosPendientes.Enqueue(n);
                    }
                }
            }
        }

        public void MostrarNodos() {

        }

        public void MostrarRuta(bool esCritica = true) {
                        
        }

        private void mostrarNodoRelaciones(NodoGrafo nodo, bool hayPendientes) {
            if(nodo!=null && nodo.arcos!=null && nodo.arcos.Count>0) {
                Console.WriteLine($@"[{nodo.label}] se relaciona con:");
                foreach(NodoGrafo n in nodo.arcos) {
                    Console.WriteLine($"\t––> [{n.label}]({n.peso})");
                }                
            }
            else if(nodo!=null && nodo.arcos==null && !hayPendientes) {
                Console.WriteLine($@"[{nodo.label}].");
            }
        }

        private void relacionarNodo(NodoGrafo nodoPredecesor, NodoGrafo nodo) {
            List<NodoGrafo> arcos = null;

            arcos = new List<NodoGrafo>();
            if(nodoPredecesor.arcos!=null && nodoPredecesor.arcos.Count>0) {
                nodoPredecesor.arcos.Add(nodo);
            }
            else if(nodoPredecesor.arcos==null) {
                arcos.Add(nodo);
                nodoPredecesor.arcos = arcos;
            }
        }

        private bool existeNodo(string label) {
            return (ObtenerNodo(label)!=null);
        }

        private NodoGrafo ObtenerNodo(string label) {
            NodoGrafo nodoAux = null;
            Stack<NodoGrafo> nodosPendientes = null;

            if(!estaVacio()) {
                nodosPendientes = new Stack<NodoGrafo>();
                nodosPendientes.Push(inicio);
                while(true) {
                    if(nodosPendientes.Any()) {
                        nodoAux = nodosPendientes.Pop();
                        if(nodoAux.label.ToUpper().Equals(label.ToUpper())) //Se encontro el nodo
                            break;
                        else if(nodoAux.arcos!=null && nodoAux.arcos.Count>0) {                            
                            foreach(NodoGrafo n in nodoAux.arcos) {
                                nodosPendientes.Push(n);
                            }
                        }
                    }
                    else {//Termino de recorrer el grafo y no se encontro
                        nodoAux = null;
                        break;
                    }
                }
            }
            
            return nodoAux;
        }
    }
}
