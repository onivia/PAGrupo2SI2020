using System;

namespace _04Mayo2020_1
{
    public class Cliente
    {
        public string Nit { get; set; }
        public string RazonSocial { get; set; }

        public Cliente(string nit, string razonSocial)
        {
            this.Nit = nit;
            this.RazonSocial = razonSocial;            
        }

        public override string ToString() {
            return $@"nit: {Nit}, razonSocial: {RazonSocial}";
        }
    }
}
