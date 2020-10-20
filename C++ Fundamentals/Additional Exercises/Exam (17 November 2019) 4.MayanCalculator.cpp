#include <iostream>
#include<algorithm>
#include<string>
#include<vector>

using namespace std;

int main() {
    
    int var;
    cin >> var;
    cin.ignore();

    vector<vector<string> >alfabets;

    while ( var-- ) {
        string input;
        getline(cin, input);
        int n = input.size() / 10;

        alfabets.push_back(vector<string>(10));

        for ( int i = 0; i < 10; i++ )
            alfabets.back()[i] = input.substr(i * n, n);
    }

    string number;
    cin >> number;

    for ( auto v : alfabets ) {

        for ( size_t i = 0; i < number.size(); i++)    cout<<v[number[i] - '0'];
        
        cout <<  endl;
    }

    return 0;
}
