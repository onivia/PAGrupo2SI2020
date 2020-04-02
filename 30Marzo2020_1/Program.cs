using System.Linq;
using System;

namespace _30Marzo2020_1
{
    public class A : IComparable, ICloneable { //mutable

        public A(){ }

        public A(A a)
        {
            this.i1 = a.i1;
            this.s1 = a.s1;            
        }

        public A(int i1, string s1)
        {
            this.i1 = i1;
            this.s1 = s1;
        }

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

        public override string ToString() {
            return $"i1: {this.i1}, s1: {this.s1}"; 
        }

        public int CompareTo(object obj)
        {
            A objComparado = null;
            if(obj.GetType() == typeof(A)) {
                objComparado = (A)obj;
                
                if(this.i1 < objComparado.i1)
                    return -1; //this es menor, por i1
                else if(this.i1 > objComparado.i1)
                    return 1; //this es mayor, por i1
                else {
                    return 0; //ambos objetos son iguales
                }
            }
            throw new Exception("el objeto obj NO es de tipo 'A'");
        }

        public object Clone()
        {
            // A nuevoObjCopia = new A();
            // nuevoObjCopia.i1 = this.i1;
            // nuevoObjCopia.s1 = this.s1;

            return new A(this);
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
            A a1 = new A(200, "segundo");
            A a2 = new A(100,"primero");
            //A a4 = a2;//Clone
            A a4 = (A)a2.Clone();
            
            //Console.WriteLine($"Son Iguales?: {a4.Equals(a2)}");
            A[] arreglo1 = {a1,a2};

            foreach(A a in arreglo1) {
                Console.WriteLine(a);                
            }
            
            //Array.Sort(arreglo1);
            //Array.ForEach(arreglo1,Console.WriteLine);
            //Console.WriteLine(a1);
            
            #region 30Marzo2020
            //Console.WriteLine($"hashcode a1: {a1.GetHashCode()}");
            //Console.WriteLine($"hashcode a2: {a2.GetHashCode()}");

            // if(a1.Equals(a2)) {
            //     Console.WriteLine("a1 y a2 son iguales");
            // }

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
            #endregion
        }
    }
}
