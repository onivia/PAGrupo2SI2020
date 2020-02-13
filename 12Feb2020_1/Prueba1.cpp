#include <iostream>
using namespace std;

void f1(int a) {
    a += 1;
}

void f2(int arr[]) {
    arr[0] += 1;
}

int main() {
    int a = 10;
    int arr[] = {20};

    f1(a);
    cout<<"a: "<<a<<endl;

    f2(arr);
    cout<<"arr: "<<arr[0]<<endl;

    return 0;
}