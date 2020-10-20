#include <iostream>
#include <string>
#include <map>
#include<sstream>

using namespace std;

int main() {
    string input;
    getline(cin, input);
    istringstream in(input);
    map<string, int>words;

    string word;
    while ( in >> word && word != "." ) {
        if ( words.find(word) != words.end() )
            words[word]++;
        else
            words[word] = 1;
    }
    int queries;
    cin >> queries;

    while ( queries-- ) {
        int occurrence, index, counter = 0;
        cin >> occurrence >> index;
        map<string, int>::iterator it;
        bool found = false;

        for ( it = words.begin(); it != words.end(); it++ )
            if ( it->second == occurrence ) {
                if ( counter == index ) {
                    cout << it->first << endl;
                    counter = 0;
                    found = true;
                    break;
                }
                else
                    counter++;
            }
        if ( !found )cout << "." << endl;
    }
    return 0;
}
