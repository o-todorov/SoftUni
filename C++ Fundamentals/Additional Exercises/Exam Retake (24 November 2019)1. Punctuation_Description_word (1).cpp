#include <iostream>
#include <string>
#include <vector>
#include<map>
#include<sstream>

using namespace std;

int main() {
    
    string punctuations = {'!','"','#','$','%','&','\'','(',')','*', '+',',','-','.',       '/',':',';','<','=','>','?','@','[',']','^','_','`','{','}','~'};
    string input;
    getline(cin, input);
    istringstream in(input);
    char ch;
    int punct_count = 0;
    map<int,int> res;

    while ( in >> ch ) {
        if ( ch == '|' ) {
            if ( res.find(punct_count) != res.end() ) {
                res[punct_count]++;
            }
            else
                res.insert(pair<int, int>(punct_count, 1));
            punct_count = 0;
        }
        
        else if ( punctuations.find(ch) != punctuations.npos )
            punct_count++;
    }
    for ( auto i : res )
        cout << i.first << " symbol sentences: " << i.second << endl;



    return 0;
}
