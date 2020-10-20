#include <iostream>
#include <string>
#include <vector>

using namespace std;

void insert(vector<int> &v, int i, bool atfront) {
    if ( atfront ) 
        v.insert( v.begin(),i);
    else 
        v.insert(v.end(), i);
}


int main() {
    vector<int>glass;
    vector<int>metal;
    vector<int>plastic;
    int queries;
    cin >> queries; cin.ignore();

    string garb, place;
    bool atfront;
    int number = 0;

    while ( queries-- ) {
        number++;
        cin >> garb >> place;
        atfront = place == "front";
        if ( garb == "metal" ) insert(metal, number, atfront);
        else if ( garb == "glass" ) insert(glass, number, atfront);
        else if ( garb == "plastic" )insert(plastic, number, atfront);
        else number--;
    }
    if ( glass.size() > 0 ) {
        cout << "glass - ";
        for ( int i : glass ) cout << i << " ";
        cout << endl;
    }
    if ( metal.size() > 0 ) {
        cout << "metal - ";
        for ( int i : metal ) cout << i << " ";
        cout << endl;
    }
    if ( plastic.size() > 0 ) {
        cout << "plastic - ";
        for ( int i : plastic ) cout << i << " ";
        cout << endl;
    }

    return 0;
}
