
#include <iostream>
#include<vector>
#include<sstream>

using namespace std;

vector<int> readArr()
{
    vector <int>v;
    string s;
    getline(cin, s);
    istringstream instr(s);
    int i;
    while (instr >> i)
        v.push_back(i);
    return v;
}

int main() {
    vector<int>v1, v2;

    v1 = readArr();
    v2 = readArr();

    bool eq = false;
    if (v1.size() == v2.size())

        for (int i = 0; i < v1.size(); i++)
        {
            eq = true;
            if (v1[i] != v2[i])
            {
                eq = false;
                break;
            }

        }
    if (eq)
        cout << "equal" << endl;
    else
        cout << "not equal" << endl;




}