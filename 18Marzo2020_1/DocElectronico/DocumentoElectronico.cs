using System;

namespace _18Marzo2020_1.DocElectronico
{
    public abstract class DocumentoElectronico
    {
        public DocumentoElectronico() {            
        }

        public abstract void anularDocumento();

        public void calcularTotal() {
            Console.WriteLine("llamo al metodo calcularTotal");
        }

        public void generarAcuse() {
            Console.WriteLine("llamo al metodo generarAcuse");
        }

        public static DocumentoElectronico crearDocumentoElectronico(int opcion) {
            switch(opcion)
            {
                case 1:
                    return new FacturaVentaNacional();
                case 2:
                    return new NotaCredito();
                default:
                    return null;
            }
        }
    }
}
