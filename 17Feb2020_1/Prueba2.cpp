#include <iostream>
using namespace std;

void f1() {
    static int a = 100;

    a += 1;
    cout<<a<<endl;
}

int main3() {
    f1();
    f1();    

    return 0;
}