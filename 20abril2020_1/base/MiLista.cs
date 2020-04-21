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

        public void RemoverPriemro() {

        }

        public Nodo ObteneryRemoverPrimero() {

        }

        public void InsertarNodoxPOsicion(Nodo nodo, int posi) {

        }
    }
}
