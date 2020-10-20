// https://judge.softuni.bg/Contests/Practice/Index/878#3
// https://judge.softuni.bg/Contests/Practice/Index/502#2


#include<iostream>
#include <vector>
#include<queue>

using namespace std;

void print_matrix(vector <vector<char> >&m) {
    for ( int r = 0; r < m.size(); r++ ) {
        for ( int c = 0; c < m[0].size(); c++ )
            cout << m[r][c];
        cout << endl;
    }
}

int main() {
    int R, C;
    cin >> R >> C;
    cin.ignore();
    vector <vector<char> >m;// matrix

    vector<char>vv;
    vv.resize(C);

    for ( int r = 0; r < R; r++ ) {
        for ( int c = 0; c < C; c++ )     cin >> vv[c];
        m.push_back(vv);
    }

    char newchar;
    int startrow, startcol;
    cin >> newchar>> startrow >> startcol;
    char startchar = m[startrow][startcol];
    m[startrow][startcol] = newchar;
    cin.ignore();

    queue <pair<int, int>> changed;
    changed.push(std::pair<int, int>(startrow, startcol));

    while ( !changed.empty() ) {
        int r = changed.front().first;
        int c = changed.front().second;
        if ( r >0 && m[r - 1][c] == startchar ) {
            m[r - 1][c] = newchar;
            changed.push(std::pair<int, int>(r - 1, c));
        }
        if ( r < R - 1 && m[r + 1][c] == startchar ) {
            m[r + 1][c] = newchar;
            changed.push(std::pair<int, int>(r + 1, c));
        }
        if ( c > 0 && m[r][c - 1] == startchar ) {
            m[r][c - 1] = newchar;
            changed.push(std::pair<int, int>(r, c - 1));
        }
        if ( c < C - 1 && m[r][c + 1] == startchar ) {
            m[r][c + 1] = newchar;
            changed.push(std::pair<int, int>(r, c + 1));
        }
        changed.pop();

    }
    print_matrix(m);


    return 0;
}