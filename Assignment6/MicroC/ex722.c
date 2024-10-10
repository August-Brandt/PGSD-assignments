void squares(int n, int arr[]) {
    while (n > 0) {
        n = n - 1;
        arr[n] = n * n;
    }
    
}

void arrsum(int n, int arr[], int *sump) {
    while (n > 0) {
        *sump = *sump + arr[n - 1];
        n = n - 1;
    }
}

void main(int n) {
    int arr[20];

    squares(n, arr);

    int sump;
    sump = 0;
    
    arrsum(n, arr, &sump);

    print sump;
    println;
}