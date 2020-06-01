using System;
using System.Collections.Generic;
using System.Linq;

namespace _29mayo2020_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Ejemplo_DivideyVenceras();                        
            //Ejemplo_Voraz();
        }

        public static void Ejemplo_Voraz() {
            List<Moneda> monedas = new List<Moneda>{new Moneda(1,0), new Moneda(2,0), new Moneda(5,0), new Moneda(10,0), new Moneda(20,0)};
            List<Moneda> monedasVueltas = obtieneVueltas(monedas,36); //null-no se pueden dar vueltas con esas denominaciones
            //Console.WriteLine($"Vueltas: ");
            Console.Write($"Vueltas(monedas): {(monedasVueltas!=null ? string.Join(",",monedasVueltas) : "NO-HUBO")}");
        }

        private static List<Moneda> obtieneVueltas(List<Moneda> monedasCaja, int monto) {
            List<Moneda> r = new List<Moneda>();
            
            Moneda monedaMayorDenominacion = monedasCaja.Where(x => x.denominacion <= monto).Max(); //Se obtiene la moneda de mayor denominacion no mayor que monto
            if(monedaMayorDenominacion!=null) { //Hubo una moneda no mayor que monto con la que pude dar vueltas
                r = obtieneVueltas(monedasCaja,monto-monedaMayorDenominacion.denominacion); //Como es posible que aun quede un saldo por dar vueltas me llamo a mi mismo
                r?.Add(monedaMayorDenominacion); //Cuando se desapilan los llamados recursivos, voy acumulando las vueltas obtenidas y retornandolas
            }
            else if(monedaMayorDenominacion==null && monto!=0) //no hubo moneda con la que podia dar vueltas, y si aun tengo un monto pendiente por atender, siginifica que existe manera alguna para seguir acumlando vueltas con el monto que quedo y las monedas que tengo
                return null; //anulo cualquier acumulacion posible que se vio truncada en el camino por no poder tener monedas con las que atender el monto restante
            
            return r; // retorno las vueltas acumuladas
        }

        public static void Ejemplo_DivideyVenceras() {
            int[] nums = { 10, 20, 30, 40, 50 };
            int numeroBuscado = 70;
            bool r = existeNumero(nums, numeroBuscado);
            Console.Write($"{string.Join(",",nums)}");
            Console.WriteLine($"\nExiste numero buscado ({numeroBuscado})?: {r}");
        }

        public static bool existeNumero(int[] nums, int numeroBuscado) {
            int posiMedia = 0;
            bool existe = false;

            posiMedia = nums.Length / 2;

            if(numeroBuscado==nums[posiMedia])
                return true;

            if(posiMedia==0 || (numeroBuscado>nums[posiMedia] && (posiMedia+1==nums.Length)))
                return false;

            if(numeroBuscado>nums[posiMedia]) {
                existe = existeNumero(subArray(nums,posiMedia+1,nums.Length-1), numeroBuscado);
            }
            else if(numeroBuscado<nums[posiMedia])
                existe = existeNumero(subArray(nums,0,posiMedia-1), numeroBuscado);

            return existe;
        }

        private static int[] subArray(int[] nums, int posiDesde, int posiHasta) {
            posiHasta = posiHasta-posiDesde + 1;
            return nums.ToList().GetRange(posiDesde, posiHasta).ToArray();
        }
    }
}
