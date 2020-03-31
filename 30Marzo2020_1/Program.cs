using System;

namespace _30Marzo2020_1
{
    public class A { //mutable
        public A(string s1)
        {            
            this.s1 = s1;
        }
        public int i1 { get; set; }
        public string s1 { get; set; }

        public override int GetHashCode() { //sobreescribir su comportamiento
            int resultado = 0;
            int primo = 31;

            resultado = primo + s1.GetHashCode(); //obtiene un numero int a partir de su ASCII
            resultado = (primo * resultado) + i1.GetHashCode();

            return Math.Abs(resultado);
        }

        public override bool Equals(object objComparado) {
            bool sonIguales = false;

            if(objComparado!=null && this.GetHashCode() == objComparado.GetHashCode()) {
                sonIguales = true;
            }

            return sonIguales;
        }
    }

    public class AInmutable { //Inmutable
        public AInmutable(string s1) //Inicializa el valor de s1
        {
            this.s1 = s1;            
        }
        public string s1 { get; private set; }

        public void asignarValor(string s1) {
            this.s1 = new string(s1);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            A a1 = new A("100");
            A a2 = new A("100");
            
            //Console.WriteLine($"hashcode a1: {a1.GetHashCode()}");
            //Console.WriteLine($"hashcode a2: {a2.GetHashCode()}");

            if(a1.Equals(a2)) {
                Console.WriteLine("a1 y a2 son iguales");
            }

            // if(a1 == a2) {
            //     Console.WriteLine("a1 y a2 son iguales");
            // }


            //Inmutable
            //1. private los set de las propiedades, solamente quedaran public los get.
            //2. la unica manera que existira para cambiarle un valor a un objeto es haciendo un nuevo 'new'.
            AInmutable a3 = new AInmutable("hola");
            //...
            a3 = new AInmutable("mundo2");
            a3.asignarValor("mundo2");
            //a3.s1 = "";
        }
    }
}
