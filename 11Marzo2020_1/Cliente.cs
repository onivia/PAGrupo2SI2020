using System;

namespace _11Marzo2020_1
{
    public class Cliente
    {
        private string nit;
        //private string nombre;
        public string nombre { get; set; }

        public string Nit {
            get {
                return nit;
            }
            set {
                //Validar el Nit en SARFLAT
                //
                nit = value;
            }
        }

        //Cosntructor por Default
        public Cliente() {

        }
    }
}