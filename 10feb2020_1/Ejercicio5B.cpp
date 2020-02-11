#include <iostream>
#include <fstream>
using namespace std;

/*
onivia - 10-feb2020
Objetivo: Escribir adicionando en un archivo texto una linea.
Pasos:
    1. crear un objeto a partir ofstream.
    2. a partir de ese objeto abro el archivo, destacando la flag 'app'.
    3. escribo una salida sobre el objeto.
    4. cierro el archivo.
*/
int main() {
    //1.
    ofstream warchivo;
    char linea[] = "hola esta es la 2 prueba!"; 
    //2.
    warchivo.open("C:\\Tmp\\Universidad\\RepositorioProyectosGit\\PAGrupo2SI2020\\10feb2020_1\\Salida.txt", ios::app);
    //3.
    warchivo<<linea<<endl;
    //4.
    warchivo.close();

    return 0;
}
