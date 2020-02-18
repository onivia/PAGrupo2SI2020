#include <iostream>
using namespace std;

int main2() {
    int *n = NULL;

    //n = (int *)calloc(2,sizeof(int));
    n = (int *)malloc(2*sizeof(int));
    n[0] = 100;
    n[1] = 200;

    cout<<n[0]<<endl;
    cout<<n[1]<<endl;

    free(n);
    n = NULL;

    return 0;
}