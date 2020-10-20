
#include <iostream>
#include<string>
#include<sstream>

using namespace std;

//typedef vector<vector<int> > matrix;

bool are_equal(int(m1)[10][10], int(m2)[10][10], int r, int c) {
    bool res = true;
    for (int i = 0;i < r;i++)
        for (int j = 0;j < c;j++)
            if ((*m1)[i][j] != (*m2)[i][j]) {
                res = false;
                break;
            }

    return res;
}

void fill_matrix(int m[10][10], int& r, int& c) {
    string line; int j;
    cin >> r; cin.ignore();

    for (int i = 0;i < r;i++) {
        c = 0;
        getline(cin, line);
        istringstream in(line);
        while (in >> j) {
            m[i][c] = j;
            c++;
        }
    }
}

int main()
{
    int m1[10][10];
    int m2[10][10];
    int r1 = 0, c1 = 0;
    int r2 = 0, c2 = 0;

    fill_matrix(m1, r1, c1);
    fill_matrix(m2, r2, c2);

    bool res = true;
    if (r1 != r2 || r1 == 0)    res = false;
    else if (c1 != c2 || c1 == 0)   res = false;
    else res = are_equal(m1, m2, r1, c1);

    cout << (res ? "equal" : "not equal") << endl;

    return 0;
}


