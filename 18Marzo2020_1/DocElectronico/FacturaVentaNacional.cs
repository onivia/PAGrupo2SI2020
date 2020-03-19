using System;
using _18Marzo2020_1.DocSoporte;

namespace _18Marzo2020_1.DocElectronico
{
    public class FacturaVentaNacional : DocumentoElectronico, IOperacionDocSoporte
    {
        public FacturaVentaNacional()
        {            
        }

        public override void anularDocumento()
        {
            Console.WriteLine("llamo al metodo FVN.anularDocumento");
        }

        public void obtenerFormaPago() {
            Console.WriteLine("llamo al metodo FVN.obtenerFormaPago");
        }
    }
}