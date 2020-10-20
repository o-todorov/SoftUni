#include <iostream>
#include<vector>
#include<string>
#include<sstream>

using namespace std;

//typedef vector<vector<int> > matrix;

bool are_equal(vector<vector<int> >& m1, vector<vector<int> >& m2) {
    bool res = true;
    if (m1.size() != m2.size() || m1.size() == 0)                    res = false;
    else if (m1[0].size() != m2[0].size() || m1[0].size() == 0)     res = false;
    else {
        for (size_t i = 0;i < m1.size();i++)
            for (size_t j = 0;j < m1[0].size();j++)
                if (m1[i][j] != m2[i][j]) {
                    res = false;
                    break;
                }
    }

    return res;

}


int main()
{
    vector<vector<int> > m[2];

    for (int i = 0;i < 2;i++) {       // Fill two matrix
        string line; int j;
        int rows;  cin >> rows; cin.ignore();

        while (rows--) {
            getline(cin, line);
            istringstream in(line);
            vector <int> row;
            while (in >> j) row.push_back(j);
            m[i].push_back(row);
        }
    }

    cout << (are_equal(m[0], m[1]) ? "equal" : "not equal") << endl;

    return 0;
}


