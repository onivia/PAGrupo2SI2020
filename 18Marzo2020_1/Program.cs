using System;
using _18Marzo2020_1.DocElectronico;
using _18Marzo2020_1.DocSoporte;

namespace _18Marzo2020_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
        }

        public static void probarDocElectronico() {
            DocumentoElectronico docElec = null;
            
            docElec = DocumentoElectronico.crearDocumentoElectronico(3);
            docElec.calcularTotal();

            IOperacionDocSoporte doc = null;
            doc = new OrdenCompra();
            obtenerFormaPago(doc);

            //MALA PRACTICA (sin polimorfismo)
            FacturaVentaNacional fvn = null;
            fvn = new FacturaVentaNacional();
            fvn.calcularTotal();
            //
            NotaCredito nc = null;
            nc = new NotaCredito();
            nc.calcularTotal();
            //
            //para ND        
        }

        public static void obtenerFormaPago(IOperacionDocSoporte doc) {
            doc.obtenerFormaPago();
        }
    }
}
