#include <iostream>
using namespace std;

void f1(int a[]) {
    cout<<a[0]<<endl;    
}

int main() {
    int a[2] = {10,20};
    //f1(a);    
}

int main2() {
    int i = 0;
    char cadena[10] = "";
        
    cout<<"Entre valor:"<<endl;
    cin>>i;
    cout<<"El valor entrado fue: "<<i<<endl;
    cin.ignore();
    cout<<"Entre cadena1:"<<endl;
    cin.getline(cadena,10);
    //cin>>cadena;
    cout<<"La cadena entrada fue: "<<cadena<<endl;
    cout<<"Entre cadena2:"<<endl;
    cin.getline(cadena,10);
    //cin>>cadena;
    cout<<"La cadena entrada fue: "<<cadena<<endl;

 return 0;
}
