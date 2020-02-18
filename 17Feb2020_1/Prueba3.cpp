#include <iostream>
#include <cstring>
using namespace std;

void concat2(char **p22) {
    strcat(*p22," y juicioso");
}
void concat1(char *p11) {
    strcat(p11," pilo");

    concat2(&p11);
}

int main() {
    char c[50]="hola";

    concat1(c);
    cout<<c<<endl;

    return 0;
}