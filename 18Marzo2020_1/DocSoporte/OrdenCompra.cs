using System;

namespace _18Marzo2020_1.DocSoporte
{
    public class OrdenCompra : DocSoporte, IOperacionDocSoporte
    {
        public OrdenCompra()
        {            
        }

        public void obtenerFormaPago()
        {
            Console.WriteLine("llamo al metodo OC.obtenerFormaPago");
        }
    }
}
