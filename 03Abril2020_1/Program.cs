using System;
using System.Linq;
using _03Abril2020_1.Modelos;

namespace _03Abril2020_1
{
    public class Program
    {
        //Prueba CRUD
        public static void Main(string[] args)
        {
            prueba_Delete();            
        }

        public static void prueba_Delete() {
            Customers cust = null;
            using(NorthwindContext contexto = new NorthwindContext()) {
                cust = contexto.Customers.Where(x => x.CustomerId.Equals("WICKK")).First();
                contexto.Remove<Customers>(cust);
                contexto.SaveChanges();
            }
        }
        public static void prueba_Update() {
            Customers cust = null;
            using(NorthwindContext contexto = new NorthwindContext()) {
                cust = contexto.Customers.Where(x => x.CustomerId.Equals("WICKK")).First();
                cust.City = "Medellin";
                contexto.Update<Customers>(cust);
                contexto.SaveChanges();
            }
            Console.WriteLine("Se actualizo el registro OK!");
        }
        public static void prueba_Insert() {
            Customers cust = null;
            cust = new Customers();
            cust.CustomerId = "WICKK";
            cust.ContactName = "Oskr Nivia";
            cust.CompanyName = "Panaderia 123";
            using(NorthwindContext contexto = new NorthwindContext()) {
                contexto.Add<Customers>(cust);
                contexto.SaveChanges();               
            }
            Console.WriteLine("se creo registro OK!");
        }
        public static void prueba_Select() {
            Customers cust = null;
            using(NorthwindContext contexto = new NorthwindContext()) {
               cust = contexto.Customers.Where(x => x.CustomerId.Equals("BLAUS")).First();
            }
            Console.WriteLine($"Ciudad: {cust.City}");
        }
    }
}
