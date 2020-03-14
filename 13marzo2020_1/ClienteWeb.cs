using System;

namespace _13marzo2020_1
{
    public class ClienteWeb : Cliente 
    {
        public ClienteWeb() {
            base.nit = "";
            base.razonSocial = "";

            //mala practica
            nit = "";
        }

        public void inactivarClienteWeb() {
            
        }
    }
}
