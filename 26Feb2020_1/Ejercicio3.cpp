#include <iostream>
using namespace std;

struct OrdenCompra {
    int numeroOC;
    char fechaOC[15];
    double total;
};

struct Proveedor {
    int nit;
    char razonSocial[20];
    int cantidadOC;
    OrdenCompra *ordenes;
};

int main() {
    int cantidadProveedores = 0, cantidadOC = 0;
    Proveedor *proveedores = NULL;
    OrdenCompra *ordenesOC = NULL;

    cout<<"Entra cantidad de Proveedores: "<<endl;
    cin>>cantidadProveedores;
    proveedores = (Proveedor *)calloc(cantidadProveedores,sizeof(Proveedor));
    for(int i=0;i<cantidadProveedores;i++) {
        cout<<"Entre nit: "<<endl;
        cin>>proveedores[i].nit;
        cout<<"Entra cantidad de OCs: "<<endl;
        cin>>cantidadOC;
        ordenesOC = (OrdenCompra *)calloc(cantidadOC,sizeof(OrdenCompra));
        for(int j=0;j<cantidadOC;j++) {
            cout<<"Entre numeroOC: "<<endl;
            cin>>ordenesOC[j].numeroOC;
        }
    }   

    return 0;
}