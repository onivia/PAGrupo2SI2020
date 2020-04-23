using System;

namespace _20abril2020_1
{
    public class MiLista
    {
        public Nodo p { get; set; }
        public Nodo u { get; set; }
        public int tamano { get; set; }

        public MiLista()
        {
            this.p = null;
            this.u = null;            
            this.tamano = 0;
        }

        public bool estaVacia() {
            //bool resultado = false;
            // if(p==null && u==null)
            //     resultado = true;
            // if(tamano == 0)
            //     resultado = true;

            return (p==null && u==null);
        }

        public void Adicionar(int dato){
            Nodo nodo = new Nodo(dato);

            if(estaVacia()) {
                p = nodo;
                u =nodo;
            } else {
                u.sgte = nodo;
                u = nodo;
            }
            tamano += 1; //tamano++;
        }

        public void Mostar() {
            Nodo nodoAux = null;
            int i = 0;

            nodoAux = p;
            while(i < tamano) {
                Console.WriteLine(nodoAux.dato);
                nodoAux = nodoAux.sgte;
                i++;
            }
        }

        public void RemoverPrimero() {
            //no tiene q estar vacia.
            //Caso1: la lista tiene un nodo.
            //Caso2: la lista tiene 2 o mas nodos.
            Nodo nodoAux = null;
            
            if(!estaVacia()) {
                if(tamano==1) {
                    p = null;
                    u = null;                    
                    tamano = 0;
                } else {
                    nodoAux = p;
                    p = p.sgte;
                    nodoAux.sgte = null;
                    nodoAux = null;                    
                    tamano -= 1; //tamano--;
                }                
            }
        }

        public Nodo ObteneryRemoverPrimero() {
            Nodo nodoCopia = null;

            if(!estaVacia()) {
                nodoCopia = new Nodo(p.dato);
                RemoverPrimero();
            }

            return nodoCopia;
        }

        public void InsertarNodoxPosicion(Nodo nodo, int posi) {
            Nodo nodoAux = null;
            int i = 0;

            if(nodo==null)
                throw new Exception("nodo NO puede ser null");
            if((posi<0 || posi > tamano) || (estaVacia() && posi!=0))
                throw new Exception("posi no es valida");
            
            if(estaVacia() && posi==0) { //insertar el nuevo 1° nodo
                Adicionar(nodo.dato);
            } else if(!estaVacia()) { //casos para una lista NO vacia
                if(posi==0) { //insertar el nuevo 1° nodo
                    nodo.sgte = p;
                    p = nodo;
                } else if(posi == tamano) { //insertar nuevo ultimo
                    u.sgte = nodo;
                    u = nodo;
                } else  { //insertar en una posicion intermedia
                    nodoAux = p;
                    i = 0;
                    while(i < (posi-1)) {
                        nodoAux = nodoAux.sgte; //movemos a nodoAux al siguiente nodo
                        i++;                        
                    }
                    nodo.sgte = nodoAux.sgte;
                    nodoAux.sgte = nodo;
                }
            }
            tamano += 1; //tamano++
        }
    }
}
