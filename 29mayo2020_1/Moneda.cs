using System;
using System.Linq;

namespace _29mayo2020_1
{
    public class Moneda: IComparable
    {
        public int denominacion;
        public int cantidad;

        public Moneda(int denominacion)
        {
            this.denominacion = denominacion;
            this.cantidad = 0;
        }

        public Moneda(int denominacion, int cantidad)
        {
            this.denominacion = denominacion;
            this.cantidad = cantidad;           
        }

        public int CompareTo(object obj)
        {
            Moneda moneda = null;
            if(obj.GetType()==typeof(Moneda)) {
                moneda = (Moneda)obj;

                if(this.denominacion<moneda.denominacion)
                    return -1;
                else if(this.denominacion>moneda.denominacion)
                    return 1;
                else
                    return 0;
            }
            return -1;          
        }

        public override string ToString() {
            return $"{this.denominacion}";
        }
    }
}
