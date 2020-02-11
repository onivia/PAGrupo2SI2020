#include <iostream>
#include <ctime>
#include <cstdlib>
using namespace std;

int obtenerAleatorioEnRango(int numeroInferior, int numeroSuperior) {
    int diferencia = 0, a1 = 0, a = 0;
    //3.1
    diferencia = numeroSuperior - numeroInferior;
    //3.2
    a1 = rand() % (diferencia + 1);
    //3.3
    a = numeroInferior + a1;

    return a;    
}

/*
onivia - 10-feb2020
Objetivo: obtener un numero aleatorio dado un rango.
Pasos:
    1. Garantizar randomize --> srand(time(NULL))
    2. Defino a numeroInferior y numeroSuperior.
    3. llamar a la funcion que halla el numero aleatorio.
        3.1 hallar la diferencia entre numeroSuperior y numeroInferior y lo denominare 'diferencia':
        3.2 hallo un mumero aleatorio 'a1' con base a:
            a1 = rand() % (diferencia + 1)
        3.3 hallo el numero aleatorio en rango 'a', con base a:
            a = numeroInferior + a1
    4. mostrar numero aleatorio obtenido.
*/
int main() {
    int numeroInferior = 0, numeroSuperior = 0;
    int aleatorio = 0;
    //1.
    srand(time(NULL));
    //2.
    numeroInferior = 1;
    numeroSuperior = 2;
    //3.
    aleatorio = obtenerAleatorioEnRango(numeroInferior, numeroSuperior);

    //4.
    cout<<"El numero aleatorio es: "<<aleatorio<<endl;    

    return 0;
}
