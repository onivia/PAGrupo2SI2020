using System;
using _18Marzo2020_1.DocElectronico;
using _18Marzo2020_1.DocSoporte;

namespace _18Marzo2020_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            probarDocElectronico();
        }

        public static void probarDocElectronico() {
            DocumentoElectronico docElec = null;
            
            docElec = DocumentoElectronico.crearDocumentoElectronico(2);
            //docElec.calcularTotal();
            anaularDocumento(docElec);

            IOperacionDocSoporte doc = null;
            doc = new FacturaVentaNacional();
            //obtenerFormaPago(doc);

            //MALA PRACTICA (sin polimorfismo)
            FacturaVentaNacional fvn = null;
            fvn = new FacturaVentaNacional();
            //fvn.calcularTotal();
            //
            NotaCredito nc = null;
            nc = new NotaCredito();
            //nc.calcularTotal();
            //
            //para ND
        }

        public static void obtenerFormaPago(IOperacionDocSoporte doc) {
            doc.obtenerFormaPago();
            if(doc.GetType() == typeof(OrdenCompra)) {
                Console.WriteLine("el objeto doc es de tipo: OrdenCompra");
            } else if(doc.GetType() == typeof(FacturaVentaNacional)) {
                Console.WriteLine("el objeto doc es de tipo: FacturaVentaNacional");
            }
        }
    
        public static void anaularDocumento(DocumentoElectronico docElec) {
            //los metodos, tiene ser tratamiento COMUN
            docElec.anularDocumento();
        }
    }
}
