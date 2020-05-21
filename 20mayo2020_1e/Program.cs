using System;
using System.Collections.Generic;
using System.Linq;

namespace _20mayo2020_1e
{
    public class Program
    {
        public delegate int Operacion(int num1, int num2); //define el tipo delegate y la firma a la que un apuntador de este tipo puede apuntar.
        public delegate void Mostrar(string s); //define el tipo delegate y la firma a la que un apuntador de este tipo puede apuntar.

        public static void Main(string[] args)
        {
            // Prueba1_Delegate();
            // Prueba2_Delegate();
            // Prueba3_Delegate();
            // Prueba4_Delegate();
            // Prueba5_Delegate();
            // Prueba6_Delegate();
            // Prueba7_Delegate();
            // Prueba8_Delegate();
        }

        public static void Prueba1_Delegate() {
            //Muestra como se crea un tipo delegate y referencia a funcion
            Operacion oper = null;

            oper = sumar; //se apunta a la funcion que cumpla con la firma definida por el delegate.
            int r = oper(200,50);
            Console.WriteLine($"Resultado de la Operacion: {r}");
        }

        public static void Prueba2_Delegate() {
            //Muestra como se crea un tipo delegate y referencia a funcion
            Mostrar mostrar = null;

            mostrar = mostrarMsj; //se apunta a la funcion que cumpla con la firma definida por el delegate.
            mostrarMsj("llamado desde un delegate");            
        }

        public static void Prueba3_Delegate() {
            //Muestra como se pasa un delegate a una funcion
            Operacion oper = null;

            oper = restar; //se apunta a la funcion que cumpla con la firma definida por el delegate.
            plantilla(oper,500,100);
        }

        public static void Prueba4_Delegate() {
            //Muestra como se puede referenciar una funcion anonima y pasarsela a otra funcion
            Operacion oper = null;

            oper = delegate(int x, int y) {
                return (x+y+10);                
            };
            plantilla(oper,10,60);
        }

        public static void Prueba5_Delegate() {
            //Muestra como se puede referenciar una funcion anonima expresada como una fucnion Lambda y pasarsela a otra funcion
            //Muestra como se puede pasar directamente una fucncion Lambda como parametro
            Operacion oper = null;

            oper = (x,y) => x+y+10;
            
            plantilla(oper,10,60);
            plantilla((x,y) => x+y+10,10,60);
        }

        public static void Prueba6_Delegate() {
            //Muestra como se puede referenciar una funcion anonima expresada como una fucnion Lambda y pasarsela a otra funcion
            //Muestra como se puede pasar directamente una fucncion Lambda como parametro
            Operacion oper = null;

            oper = (x,y) => x+y+10;
            
            plantilla(oper,10,60);
            plantilla((x,y) => x+y+10,10,60);
        }

        public static void Prueba7_Delegate() {
            //Muestra como usan las expresiones Lambda con Listas (Linq)

            List<string> nombres = new List<string>{"pedro", "juan", "pablo"};
            List<string> nombresFiltrados = nombres.Where(x => x.StartsWith('p')).ToList(); //uso funcional
            nombresFiltrados.ForEach(Console.WriteLine); //uso funcional, muestra cada item de la lista
        }

        public static void Prueba8_Delegate() {
            //Muestra como usan las expresiones Lambda con Listas custom

            MiLista<string> nombres = new MiLista<string>{"pedro", "juan", "pablo"};
            List<string> nombresFiltrados = nombres.Filtrar(x => x.StartsWith('p')).ToList(); //uso funcional
            nombresFiltrados.ForEach(Console.WriteLine); //uso funcional, muestra cada item de la lista
        }

        //funcion que recibe un string y lo muestra
        public static void mostrarMsj(string s) {
            Console.WriteLine($"{s}");            
        }

        //funcion que recibe otra funcion como parametro, por medio de un delegate
        public static void plantilla(Operacion p, int num1, int num2) { //wrapper func
            Console.WriteLine($"el resultado es: {p(num1, num2)}");
        }

        public static int sumar(int n1, int n2) {
            return (n1 +n2);
        }

        public static int restar(int n1, int n2) {
            return (n1 - n2);
        }
    }
}
