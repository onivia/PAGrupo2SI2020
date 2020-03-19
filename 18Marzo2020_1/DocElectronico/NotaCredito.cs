using System;

namespace _18Marzo2020_1.DocElectronico
{
    public class NotaCredito : DocumentoElectronico
    {
        public NotaCredito()
        {            
        }

        public override void anularDocumento()
        {
            Console.WriteLine("llamo al metodo NC.anularDocumento");
        }

        public void calcularCUDE() {
            Console.WriteLine("llamo al metodo NC.calcularCUDE");
        }
    }
}