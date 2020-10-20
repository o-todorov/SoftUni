#include<iostream>
#include <vector>
#include<queue>

using namespace std;

void print_matrix(vector <vector<char> >& m, int o = 1) {
    for ( int r = o; r < m.size() - o; r++ ) {
        for ( int c = o; c < m[0].size() - o; c++ )
            cout << m[r][c];
        cout << endl;
    }
}

int main() {
    int R, C;
    cin >> R >> C;
    cin.ignore();
    int offset = 1;
    vector <vector<char> >m;// matrix
    m.push_back(vector<char>(offset * 2 + C, '!'));

    for ( int r = offset; r < offset + R; r++ ) {
        m.push_back(vector<char>(offset * 2 + C, '!'));
        for ( int c = offset; c < offset + C; c++ ) cin >> m[r][c];
    }

    m.push_back(vector<char>(offset * 2 + C, '!'));

    char fillchar;
    int startrow, startcol;
    cin >> fillchar >> startrow >> startcol;
    startrow += offset; startcol += offset;
    char startchar = m[startrow][startcol];
    m[startrow][startcol] = fillchar;
    cin.ignore();

    queue <pair<int, int>> changed;
    changed.push(std::pair<int, int>(startrow, startcol));

    while ( !changed.empty() ) {
        int r = changed.front().first;
        int c = changed.front().second;
        if ( m[r - 1][c] == startchar ) {
            m[r - 1][c] = fillchar;
            changed.push(std::pair<int, int>(r - 1, c));
        }
        if ( m[r + 1][c] == startchar ) {
            m[r + 1][c] = fillchar;
            changed.push(std::pair<int, int>(r + 1, c));
        }
        if ( m[r][c - 1] == startchar ) {
            m[r][c - 1] = fillchar;
            changed.push(std::pair<int, int>(r, c - 1));
        }
        if ( m[r][c + 1] == startchar ) {
            m[r][c + 1] = fillchar;
            changed.push(std::pair<int, int>(r, c + 1));
        }
        changed.pop();

    }
    print_matrix(m, offset);


    return 0;
}