#include<iostream>
#include <vector>
#include<queue>

using namespace std;

void print_matrix(vector <vector<char> >(*m)) {
    for (int r = 0; r < (*m).size(); r++) {
        for (int c = 0; c < (*m)[0].size(); c++)
            cout << (*m)[r][c];
        cout << endl;
    }
}

int main_1() {
    int R, C;
    cin >> R >> C;
    cin.ignore();
    vector <vector<char> >m;// matrix

    char t;

    vector<char>vv;
    vv.resize(C);

    for (int r = 0; r < R; r++) {
        for (int c = 0; c < C; c++) {
            cin >> t;
            vv[c] = t;
        }
        m.push_back(vv);

    }


    char fillchar;
    cin >> fillchar;
    cin.ignore();
    int startrow, startcol;
    cin >> startrow >> startcol;
    char startchar = m[startrow][startcol];

    queue <pair<int, int>> changed;
    changed.push(std::pair<int, int>(startrow, startcol));
    m[startrow][startcol] = fillchar;

    while (!changed.empty()) {
        int r = changed.front().first;
        int c = changed.front().second;
        if (r >= 1 && m[r - 1][c] == startchar) {
            m[r - 1][c] = fillchar; cout << r - 1 << ", " << c << " --> " << fillchar << endl;
            changed.push(std::pair<int, int>(r - 1, c));
        }
        if (r < R - 1 && m[r + 1][c] == startchar) {
            m[r + 1][c] = fillchar; cout << r + 1 << ", " << c << " --> " << fillchar << endl;
            changed.push(std::pair<int, int>(r + 1, c));
        }
        if (c >= 1 && m[r][c - 1] == startchar) {
            m[r][c - 1] = fillchar; cout << r << ", " << c - 1 << " --> " << fillchar << endl;
            changed.push(std::pair<int, int>(r, c - 1));
        }
        if (c < C - 1 && m[r][1 + c] == startchar) {
            m[r][1 + c] = fillchar; cout << r << ", " << c + 1 << " --> " << fillchar << endl;
            changed.push(std::pair<int, int>(r, c + 1));
        }
        changed.pop();
        cout << endl;
        print_matrix(&m);

    }
    cout << endl << "Final Matrix:" << endl;
    print_matrix(&m);


    return 0;
}