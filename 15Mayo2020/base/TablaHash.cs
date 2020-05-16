using System;
using System.Collections.Generic;
using System.Linq;
using _15Mayo2020._base.hash;

namespace _15Mayo2020._base
{
    public class TablaHash
    {
        DatoHash[] tablaHash;
        int tamano;

        public TablaHash(int tamano)
        {
            this.tablaHash = new DatoHash[tamano];
            this.tamano = tamano;
        }

        public void Insertar(string dato) {
            //1. usar la funcion que me obtiene 'I', siendo 'I' la posicion en el arreglo donde se insertara el dato.
            //**validar que 'I': >0 y <=Tamano-1
            //2. Validar si hubo colision en la posicion 'I'.
                //Si-si: añadimos a dato en la lista de colisiones de la posicion 'I'.
                //Si-no: asignamos a dato en la posicion 'I'.
            int i = 0;

            if(!existeDato(dato)) {
                //1.
                i = ObtenerIndice(dato, tamano-1);

                //2.            
                if(tablaHash[i]!=null) { //hubo colision
                    tablaHash[i].colisiones.Add(dato);
                    tablaHash[i].tuvoColision = true;
                    Console.WriteLine($"({dato} insertado en la posicion {i}, hubo colision.)");
                }
                else { //no hubo colision
                    tablaHash[i] = new DatoHash(dato);
                    Console.WriteLine($"({dato} insertado en la posicion {i}, NO hubo colision.)");
                }
            }
            else { //ya exite el dato
                Console.WriteLine($"no se pudo insertar, ya existe el dato.");
            }
        }

        private bool existeDato(string dato) {
            int i = 0;
            
            i = ObtenerIndice(dato, tamano-1);
            if(tablaHash[i]==null) {
                return false;
            }
            else {
                if(tablaHash[i].dato.Equals(dato)) {
                    return true;
                }
                else if(tablaHash[i].tuvoColision) {
                    foreach(string d in tablaHash[i].colisiones) {
                        if(d.Equals(dato)) {
                            return true;
                        }
                    }                    
                }
                return false;
            }            
        }

        public void MostrarDato(string dato) {
            int i = 0;            
            
            i = ObtenerIndice(dato, tamano-1);
            if(tablaHash[i]==null) {
                Console.WriteLine($"NO existe el dato: {dato} en la posicion: {i}");
            }
            else {
                if(tablaHash[i].dato.Equals(dato)) {
                    Console.WriteLine($"dato: {dato}, posicion: {i}");                    
                }
                else if(tablaHash[i].tuvoColision) {
                    foreach(string d in tablaHash[i].colisiones) {
                        if(d.Equals(dato)) {
                            Console.WriteLine($"dato: {dato}, posicion: {i}, esta en la lista de colisiones");
                            return;
                        }
                    }
                    Console.WriteLine($"NO existe el dato: {dato} en la posicion: {i}");                   
                }
            }
        }

        private int ObtenerIndice(string dato, int maxLlave) {
            //1. obtenemos el HashCode del dato.
            //2. con modulo obtenems 'I'.
            int hashCode = 0;
            int i = 0;

            hashCode = Math.Abs(dato.ToLower().GetHashCode());
            i = hashCode % (maxLlave + 1);
            
            return i;
        }
    }
}
