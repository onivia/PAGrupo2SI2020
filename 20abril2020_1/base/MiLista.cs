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
    
        public void Actualizar(int nuevoDato, int posi) {
            //validar q la lista NO este vacia
            //posi>=0 y posi<tamano
            //posicionar a un nodoAux en el nodo en la posicion 'posi'.
            //nodoAux arranca desde 'p'
            //Recorrer la lista con nodoAux, nodoAux = nodoAux.sgte;
            Nodo nodoAux = null;
            int i = 0;

            if(!estaVacia() && posi>=0 && posi<tamano) {
                nodoAux = p;
                i = 0;
                while(i < tamano) {
                    if(i==posi) { //encontramos el nodo a actualizar
                        nodoAux.dato = nuevoDato;
                        break;
                    }
                    nodoAux = nodoAux.sgte;
                    i += 1; //i++
                }
            } else {
                throw new Exception($"posi: {posi} no valido para el tamano: {tamano}");
            }
        }

        public void Ordernar(bool esAsc = true) { //true-ascendente, false-descendente
            Nodo nodoAux = null;
            bool huboAlMenosUnIntercambio = false;
            int aux = 0;

            for(int j=0;j<tamano;j++) { //determina las corridas
                nodoAux = p;
                huboAlMenosUnIntercambio = false;
                for(int i=0;i<(tamano-1);i++) { //se hacen las comparaciones nodo a nodo
                    if(esAsc) { //esAsc==true //caso x Asc
                        if(nodoAux.dato > nodoAux.sgte.dato) { //intercambio
                            aux = nodoAux.sgte.dato; //protegimos el 3
                            nodoAux.sgte.dato = nodoAux.dato; //5 para donde esta el 3
                            nodoAux.dato = aux; //3 para donde esta el 5
                            huboAlMenosUnIntercambio = true;
                        }
                    }
                    else { //caso x Desc
                        if(nodoAux.dato < nodoAux.sgte.dato) { //intercambio
                            aux = nodoAux.sgte.dato; //protegimos el 3
                            nodoAux.sgte.dato = nodoAux.dato; //5 para donde esta el 3
                            nodoAux.dato = aux; //3 para donde esta el 5
                            huboAlMenosUnIntercambio = true;
                        }                        
                    }
                    nodoAux = nodoAux.sgte;
                }
                if(!huboAlMenosUnIntercambio)
                    break;
            }
        }
    }
}
