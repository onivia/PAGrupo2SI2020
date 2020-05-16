using System.Collections.Generic;

namespace _15Mayo2020._base
{
    public class NodoGrafo
    {
        public string label;
        public int peso;
        public int pesoAcumulado;
        public List<NodoGrafo> arcos;

        public NodoGrafo(string label, int peso)
        {
            this.label = label.ToUpper();
            this.peso = peso;
            this.pesoAcumulado = 0;
            this.arcos = null;            
        }
    }
}
