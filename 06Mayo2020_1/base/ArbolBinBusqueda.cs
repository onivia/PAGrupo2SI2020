using System;

namespace _06Mayo2020_1
{
    public class ArbolBinBusqueda
    {
        private Nodo raiz;

        public ArbolBinBusqueda()
        {
            this.raiz = null;            
        }

        public bool estaVacio() {
            return (raiz==null);
        }

        public void Insertar(int llave, string dato) {
            Nodo nodo = null;
            Nodo nodoAux = null;

            nodo = new Nodo(llave, dato);

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

        public string ObtenerDato(int llave) {
            //usar y posicionar a nodoAux (desde raiz)
            //en un while:
            //  mover a nodoAux por izq(llave < nodoAux.llave) o por der(llave > nodoAux.llave)
            //  si llave == nodoAux.llave, lo encontre, por ende retornare su daot(nodAux.dato)
            // cuando no pueda mover mas nodoAux(llegue a un nodo que no tiene hijos), en este caso la llave NO se encuentra en el arbol, y se levantara una excepcion.
            Nodo nodoAux = null;
            string dato = string.Empty; //es quivalente a ""

            if(estaVacio()) {
                throw new Exception("El arbol esta vacio!.");
            }
            else {
                nodoAux = raiz;
                //TODO: terminar de implementar este metodo

            }

            return dato;
        }
    }
}
