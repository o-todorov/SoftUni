#include <iostream>
#include<vector>
#include<sstream>

using namespace std;

//typedef vector<vector<int> > matrix;


void fill_vec_matrix(vector<vector<int> >(* m), int& rows, int& cols) {
    string line; int j;
    cin >> rows>>cols; cin.ignore();

    for (int i = 0;i < rows;i++) {
        getline(cin, line);
        istringstream in(line);
        vector <int> row;
        for (int k = 0;k < cols;k++) {
            in >> j;
            row.push_back(j);
        }

        (*m).push_back(row);
    }
}


int main()
{
    vector<vector<int> > m; // Declare the matrix
    int mrows, mcols;
    
    fill_vec_matrix(&m, mrows, mcols);  // Fill the matrix using cin

    int q; cin >> q;  // Read Querry
    bool found = false;

    for (int i = 0;i < mrows;i++)
        for (int j = 0;j < mcols;j++)
            if (m[i][j] == q) {
                cout << i << " " << j << endl;
                found = true;
            }
    if (!found)cout << "not found"<< endl;

    return 0;
}


