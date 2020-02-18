#include <iostream>
using namespace std;

int main() {
    int a = 0;
    int *p11 = NULL;
    int **p22 = NULL;

    p22 = &p11;
    
    **p22 = 20;

    return 0;
}

