using System;
using System.Collections.Generic;
using System.Linq;
using _15Mayo2020._base.nodos;

namespace _15Mayo2020._base
{
    public class Grafo
    {
        private NodoGrafo inicio;
        //private int cantidadNodos;

        public Grafo()
        {
            this.inicio = null;
            //this.cantidadNodos = 0;            
        }

        public bool estaVacio() {
            return (inicio==null);
        }

        public void InsertarRelacionarNodo(string labelPredecesor, string labelNodo, int peso) {
            NodoGrafo nodo = null;
            NodoGrafo nodoPredecesor = null;

            nodo = new NodoGrafo(labelNodo);
            if(labelPredecesor==null && estaVacio()) {
                inicio = nodo;
            }
            else if(!estaVacio() && existeNodo(labelPredecesor)) {                
                Console.WriteLine($"\t{labelPredecesor} - {labelNodo}({peso})");
                if(existeNodo(labelNodo))
                    nodo = ObtenerNodo(labelNodo);
                nodoPredecesor = ObtenerNodo(labelPredecesor);
                relacionarNodo(nodoPredecesor, nodo, peso);
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
                    foreach(Arco a in nodoAux.arcos ?? Enumerable.Empty<Arco>()) {
                        if(!nodosPendientes.Any(x => x.label.ToUpper().Equals(a.nodo.label.ToUpper()))) //No permite encolar ya encolados, asi se evita mostrar nodos–predecesores ya mostrados
                            nodosPendientes.Enqueue(a.nodo);
                    }
                }
            }
        }

        public void MostrarNodos() {
        }

        public void MostrarRutas(bool esCritica = true) {
            /*
                1. Definir 4 Estructuras:
                    Lista para rutaActual
                    Pila de listas para rutasPendientes
                    Lista de Listas para rutasFinales
                    Arco
                    **Las anteriores estructuras apuntaran a los nodos directamente, NO a copias.
                    **Los pesos finales de cada ruta–final se calcularan al mostrarse ada ruta
                2. Mientras haya ruta–pendiente:
                    3. desapile la ruta pendiente, y sera tratada como la ruta–actual
                    4. obtenga el primer arco con el q se relaciona el ultimo nodo de la ruta–actual
                    5. SI, el anterior arco es != null
                        5.1 adicione el nodo del arco a la ruta–actual
                        5.2 adicione los demas nodos de los demas arcos sobre la ruta–actual, cada nueva ruta obtenida quedara pendiente
                        5.3 adicione la nueva ruta–actual (la q ahora añadio al nodod el 1er arco) como pendiente
                    6. si el ultimo nodo de la ruta–actual no tiene arcos, adicionela como ruta final
                3. Muestra las Rutas Finales, calcule y muestre sus respectivos pesos
            */
            List<NodoGrafo> rutaActual = new List<NodoGrafo>();
            Stack<List<NodoGrafo>> rutasPendientes = new Stack<List<NodoGrafo>>(); 
            List<List<NodoGrafo>> rutasFinales = new List<List<NodoGrafo>>();
            Arco primerArco = null;

            rutaActual.Add(inicio);
            rutasPendientes.Push(rutaActual);
            while(rutasPendientes.Any()) {
                rutaActual = rutasPendientes.Pop();
                primerArco = ObtienePrimerArco(rutaActual.Last());
                if(primerArco!=null) {
                    rutaActual.Add(primerArco.nodo); 
                    AdicionaRutaPendientes(ref rutaActual, ref rutasPendientes);                                       
                    rutasPendientes.Push(rutaActual);
                }
                AdicionaRutaFinal(ref rutaActual, ref rutasFinales);
            }
            MostrarRutas(rutasFinales, esCritica);
        }

        private Arco ObtienePrimerArco(NodoGrafo nodo) {
            Arco arco = null;
            
            if(nodo.arcos!=null && nodo.arcos.Count>0) {                
                arco = nodo.arcos.First();
            }

            return arco;
        }

        private void AdicionaRutaPendientes(ref List<NodoGrafo> rutaActual, ref Stack<List<NodoGrafo>> rutasPendientes) {
            List<NodoGrafo> rutaActualAux = null;          
            NodoGrafo nodoAux = null;

            rutaActualAux = new List<NodoGrafo>(rutaActual.GetRange(0,rutaActual.Count - 1).ToList());
            nodoAux = rutaActualAux.Last();
            if(nodoAux.arcos!=null && nodoAux.arcos.Count>1) {
                foreach(Arco a in nodoAux.arcos.GetRange(1,nodoAux.arcos.Count - 1).ToList()) {
                    rutaActualAux = new List<NodoGrafo>(rutaActual.GetRange(0,rutaActual.Count - 1).ToList());
                    rutaActualAux.Add(a.nodo);
                    rutasPendientes.Push(rutaActualAux);
                }
            }
        }

        private void AdicionaRutaFinal(ref List<NodoGrafo> rutaActual, ref List<List<NodoGrafo>> rutasFinales) {
            NodoGrafo nodoAux = null;

            nodoAux = rutaActual.Last();
            if(nodoAux.arcos==null && !existeRutaFinal(rutaActual, ref rutasFinales)) { //Es el nodo de fin
                rutasFinales.Add(rutaActual);
                
            }
            // else if(nodoAux.arcos!=null && nodoAux.arcos.Count>0) {
            //     rutasPendientes.Push(rutaActual);
            // }
        }

        private bool existeRutaFinal(List<NodoGrafo> ruta, ref List<List<NodoGrafo>> rutasFinales) {
            
            foreach(List<NodoGrafo> r in rutasFinales) {
                if(r==ruta)
                    return true;         
            }
            return false;
        }

        private void MostrarRutas(List<List<NodoGrafo>> rutasFinales, bool esCritica = true) {
            List<List<NodoGrafo>> rutasFinalesAux = null;
            int i = 0;

            rutasFinalesAux = new List<List<NodoGrafo>>(rutasFinales);
            rutasFinalesAux.ForEach(x => x.Add(new NodoGrafo("FINAL",obtenerPesoRuta(x))));
            rutasFinalesAux = rutasFinales.OrderBy(x => x[x.Count-1].pesoAcumulado).ToList();            
            if(!esCritica)
                rutasFinalesAux = rutasFinales.OrderByDescending(x => x[x.Count-1].pesoAcumulado).ToList();
            Console.WriteLine($"\nRutas:");
            foreach(List<NodoGrafo> ruta in rutasFinalesAux) {                
                Console.Write($"\t {ruta[0].label}(0)");
                i = 1;
                while(i < ruta.Count-1) {
                    Console.Write($"\t {ruta[i].label}({obtenerPesoArco(ruta[i-1], ruta[i])})");
                    i++;
                }
                Console.Write($"\t = {ruta[i].pesoAcumulado}");
                Console.WriteLine($"");
            }
        }

        private int obtenerPesoRuta(List<NodoGrafo> ruta) {
            int pesoAcumulado = 0;
            int i = 0;

            while(i < ruta.Count-1) {
                pesoAcumulado += obtenerPesoArco(ruta[i], ruta[i+1]);
                i++;
            }

            return pesoAcumulado;
        }

        private int obtenerPesoArco(NodoGrafo nodoPredecesor, NodoGrafo nodo) {
            return (nodoPredecesor.arcos.Where(x => x.nodo==nodo).First().peso);
        }

        private void mostrarNodoRelaciones(NodoGrafo nodo, bool hayPendientes) {
            if(nodo!=null && nodo.arcos!=null && nodo.arcos.Count>0) {
                Console.WriteLine($@"[{nodo.label}] se relaciona con:");
                foreach(Arco a in nodo.arcos) {
                    Console.WriteLine($"\t––> [{a.nodo.label}]({a.peso})");
                }                
            }
            else if(nodo!=null && nodo.arcos==null && !hayPendientes) {
                Console.WriteLine($@"[{nodo.label}].");
            }
        }

        private void relacionarNodo(NodoGrafo nodoPredecesor, NodoGrafo nodo, int peso) {
            List<Arco> arcos = null;

            arcos = new List<Arco>();
            if(nodoPredecesor.arcos!=null && nodoPredecesor.arcos.Count>0) {
                nodoPredecesor.arcos.Add(new Arco(peso, nodo));
            }
            else if(nodoPredecesor.arcos==null) {
                arcos.Add(new Arco(peso, nodo));
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
                        if(nodoAux.label.ToUpper().Equals(label.ToUpper())) {//Se encontro el nodo
                            if(label.ToUpper().Equals("B")) {
                                // Console.WriteLine($"hashcode: {nodoAux.GetHashCode()}");
                                // Console.WriteLine($"count: {((nodoAux.arcos!=null) ? nodoAux.arcos.Count.ToString() : "nulo")}");
                                // Console.WriteLine($"l2: {nodoAux.l2}");
                            }
                            break;
                        }
                        else if(nodoAux.arcos!=null && nodoAux.arcos.Count>0) {                            
                            foreach(Arco a in nodoAux.arcos) {
                                nodosPendientes.Push(a.nodo);
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
