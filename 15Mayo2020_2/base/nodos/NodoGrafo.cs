using System.Collections.Generic;
using _15Mayo2020._base.nodos;

namespace _15Mayo2020._base
{
    public class NodoGrafo
    {
        public string label;
        public int pesoAcumulado;
        public List<Arco> arcos;

        public NodoGrafo(string label)
        {
            this.label = label.ToUpper();
            this.pesoAcumulado = 0;
            this.arcos = null;            
        }

        public NodoGrafo(string label, int pesoAcumulado)
        {
            this.label = label.ToUpper();
            this.pesoAcumulado = pesoAcumulado;
            this.arcos = null;            
        }
    }
}
