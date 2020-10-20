#include <iostream>
#include<string>

using namespace std;

int main() {
    int odd_sum = 0;
    int matr_size;
    cin >> matr_size;

    for ( int i = 0; i < matr_size; i++ )           // Read the matrix and checks at same time
        for ( int j = 0; j < matr_size; j++ ) {
            int item;
            cin >> item;
            // Diagonal coordinates and odd check
            if ( i != j && matr_size - 1 - i != j && item % 2 > 0 ) 
                odd_sum += item;
        }

    cout << "The sum is: " << odd_sum << endl;

    return 0;
}
