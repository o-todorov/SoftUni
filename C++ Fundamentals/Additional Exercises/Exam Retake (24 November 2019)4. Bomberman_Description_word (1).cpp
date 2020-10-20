#include <iostream>
#include <string>
#include<queue>
#include<vector>
#include<sstream>

using namespace std;

void bomb(vector<vector<int> >& mx, int power, int r, int c, int& score) {
    score = mx[r][c];
    mx[r][c] = 0;
    for ( int i = 1; i <= power; i++ ) {
        if ( r - i >= 0 ) { 
            score += mx[r - i][c];  mx[r - i][c] = 0; }
        if ( r + i < mx.size() ) {
            score += mx[r + i][c];  mx[r + i][c] = 0; }
        if ( c - i >= 0 ) {
            score += mx[r][c - i];  mx[r][c - i] = 0; }
        if ( c + i < mx[0].size() ) { 
            score += mx[r][c + i];  mx[r][c + i] = 0; }
    }
}

int main() {
    vector<vector<int> > mx;
    int rows, cols;
    cin >> rows >> cols;
    cin.ignore();

    for ( int r = 0; r < rows; r++ ) {
        mx.push_back(vector<int>(cols));
        char ch;
        for ( int c = 0; c < cols; c++ ) {
            cin >> ch;

            if ( ch < '1' || ch>'9' )   mx[r][c] = 0;
            else                        mx[r][c] = ch-'0';
        }
    }
    int comnum;
    cin >> comnum;
    cin.ignore();
    int power=0;
    int bombrow, bombcol, score;

    while(comnum--){
        string comm;
        getline(cin, comm);
        istringstream in(comm);
        in >> comm;

        if ( comm == "power" ) {
            string p;       in >> p;

            if ( p == "up" ) {
                power++;    cout << "Increased bomb power to " << power << endl;
            }
            else  if ( power > 0 ) {
                power--;    cout << "Decreased bomb power to " << power << endl;
            }
        }
        else {
            in >> bombrow>> bombcol;
            bomb(mx, power, bombrow, bombcol, score);
            cout << score << " points" << endl;
        }
            
    }

    

    return 0;
}
