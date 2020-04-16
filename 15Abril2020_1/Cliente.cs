using System;

namespace _15Abril2020_1
{
    public class Cliente
    {
        public int codigo { get; set; }
        public string razonSocial { get; set; }

        public Cliente(int codigo, string razonSocial) {
            this.codigo = codigo;
            this.razonSocial = razonSocial;
        }

        public override int GetHashCode() {
            int resultado = 0;
            int primo = 31;

            resultado = primo + razonSocial.GetHashCode();
            resultado = (primo * resultado) + codigo.GetHashCode();

            return resultado;
        }

        public override bool Equals(object objComparado) {
            bool sonIguales = false;

            if(objComparado!=null&& this.GetHashCode() == objComparado.GetHashCode()) {
                sonIguales = true;
            }

            return sonIguales;
        }

        public override string ToString() {
            return $"codigo: {codigo}, razonSocial: {razonSocial}";
        }
    }
}
