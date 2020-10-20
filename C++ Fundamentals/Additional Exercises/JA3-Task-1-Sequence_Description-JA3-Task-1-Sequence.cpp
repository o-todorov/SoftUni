#include <iostream>
#include <string>
#include <stack>
#include<vector>
#include<algorithm>

using namespace std;

int main() {
    int count;
    cin >> count;

    vector<int>arr(count);

    for ( int i = 0; i < count; i++ )     cin >> arr[i];

    int maxseq = 1, seq = 1;

    for ( int i = 0; i < count - 1; i++ )
        if ( arr[i + 1] > arr[i] ) {
            seq++;
            if ( seq > maxseq )  maxseq = seq;
        }
        else {
            seq = 1;
        }
    cout << maxseq;


    return 0;
}
