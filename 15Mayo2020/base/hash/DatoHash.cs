using System;
using System.Collections.Generic;
using System.Linq;

namespace _15Mayo2020._base.hash
{
    public class DatoHash
    {
        public string dato;
        public bool tuvoColision;

        public List<string> colisiones;

        public DatoHash(string dato)
        {
            this.dato = dato;
            this.tuvoColision = false;            
            this.colisiones = new List<string>();
        }
    }
}
