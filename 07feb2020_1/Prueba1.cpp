#include <iostream>
using namespace std;

void f1(int a[]) {
    cout<<"valor de la 1° posi: "<<a[0]<<endl;
    cout<<"valor de la 2° posi: "<<a[1]<<endl;
}


int main() {
    int a = 20;
    int nums[] = {10,20};

    f1(nums);

    return 0;
}