#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main() {
    int rows, cols;
    cin >> rows >> cols;

    vector<int>result;

    vector<vector<int> > mx(rows, vector<int>(cols));

    for ( int r = 0; r < rows; r++ ) 
        for ( int c = 0; c < cols; c++ ) 
            cin >> mx[r][c];

    int square_side, min_sum;
    cin >> square_side >> min_sum;
    int colcount = cols - square_side;
    int rowcount = rows - square_side;
    int sum=0;

    for ( int r = 0; r <= rowcount; r++ ) {
        for ( int c = 0; c <= colcount; c++ ) {
            for ( int i = r; i < r + square_side; i++ )
                for ( int j = c; j < c + square_side; j++ )
                    sum += mx[i][j];
            if ( sum >= min_sum ) result.push_back(sum / (square_side * square_side));
            sum = 0;
        }
    }
    sort(result.begin(), result.end());

    vector<int>::iterator it= result.begin();
    for ( vector<int>::iterator it = result.begin(); it != result.end();it++ ) cout << *it<<" ";
    cout << endl;


    return 0;
}
