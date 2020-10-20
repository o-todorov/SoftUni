#include <iostream>
#include <string>
#include<queue>

using namespace std;



int main() {
    queue <string> pepi;
    queue <string> mimi;
    int queries;
    cin >> queries; cin.ignore();

    string staff, cust;
    int minutes;

    while ( queries-- ) {
        cin >> staff >> cust >> minutes;
        if ( staff == "Pepi" )
            while ( minutes-- ) pepi.push(cust);
        else
            while ( minutes-- ) mimi.push(cust);
    }
    cin >> minutes;
    while ( minutes-- )    {
        if ( !pepi.empty() ) {
            cout << "Pepi processing " << pepi.front() << endl;
            pepi.pop();
        }
        else cout << "Pepi Idle " << endl;
        if ( !mimi.empty() ) {
            cout << "Mimi processing " << mimi.front() << endl;
            mimi.pop();
        }
        else cout << "Mimi Idle " << endl;
        

    }



    return 0;
}
