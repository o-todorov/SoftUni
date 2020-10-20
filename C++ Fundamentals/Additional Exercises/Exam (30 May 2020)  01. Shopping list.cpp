#include <iostream>
#include <string>
#include <vector>

using namespace std;

int main() {


    double  total = 0;
    string  itemname;
    double  itemprice;
    int     itemcount;

    int count;
    cin >> count;

    while ( count-- ) {
        cin.ignore();
        getline(cin, itemname);
        cin >> itemprice >> itemcount;

        double final = itemprice * itemcount;
        total += final;

        int pos = 0; // Insert position

        for ( int j = items.size() - 1; j >= 0; j-- ) { // Sort at the entrance - back to front
            if ( final > items[j].second ) {            // If same price - puts the item after previous
                pos = j + 1;                            // Sets position for insert
                break;
            }
        }
        items.insert(items.begin() + pos, pair<string, double>(itemname, final)); // Actual insert
   }

    cout << "The total sum is: " << total << " lv." << endl; // Print the total price

    for ( int i = items.size() - 1; i >= 0;i-- )          // Print in descending order
        cout << items[i].first << " " << items[i].second << endl;


    return 0;
}
