using System;
using System.IO;

namespace _06Marzo2020_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ejercicio8B();
        }

        public static void ejercicio8B() {
            /*
                OBJETIVO: Este metodo va a mostrar línea a línea el contenido de un archivo
                          texto.
                PASOS:
                    1. Definir variables:
                        string nombreArchivo, asignar el path absoluto al nombre del archivo.
                        string linea, para asignar en ella cada linea del archivo.
                    2. Abrir un flujo de lectura hacia el archivo, a traves de 'StreamReader'.
                    3. Mientras haya linea:
                        * se la asigno a 'linea'.
                        * Muestra a 'linea'.
                    4. cerrar el flujo.
            */
            //1.
            string nombreArchivo = "archivo";
            string linea = "";
            
            //2.
            StreamReader archivo = null;
            nombreArchivo = @"C:\Tmp\Universidad\RepositorioProyectosGit\PAGrupo2SI2020\06Marzo2020_1\archivo1.txt";

            archivo = new StreamReader(nombreArchivo);

            //3.
            while((linea = archivo.ReadLine()) != null) {
                Console.WriteLine(linea);
            }

            //4.
            archivo.Close();
        }
    }
}
