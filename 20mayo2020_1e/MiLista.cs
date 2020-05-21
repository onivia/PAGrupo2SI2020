using System;
using System.Collections.Generic;
using System.Linq;

namespace _20mayo2020_1e
{
    public class MiLista<T>: List<T>
    {
        public MiLista(): base()
        {            
        }

        //# Tipos mas comunes de delegates en C#
        //Action<T>, recibe 1... parametro T y no retorna.
        //Func<T,R>, recibe 1... parametro T y tiene retorno R.
        //bool Predicate<T>, recibe 1... parametro T y retorna bool.
        public IEnumerable<T> Filtrar(Func<T,bool> funcion) {
            List<T> resultados = new List<T>();

            foreach(T t in this) {
                if(funcion(t)) {
                    resultados.Add(t);
                }                                
            }

            return resultados;
        }
    }
}
