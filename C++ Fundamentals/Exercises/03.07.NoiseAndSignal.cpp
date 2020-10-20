
#include <iostream>
#include<string>
#include<sstream>
#include<vector>

using namespace std;


string getnoise(string s)
{
    string res = "";
    for (unsigned i = 0; i < s.size(); i++)
        if (s[i] < 48 || s[i] > 57)
            res.push_back(s[i]);

    return res;
}

int main() {


    string input;
    getline(cin, input);
    istringstream in(input);

    vector<string>arr;

    string St;

    while (in >> St)  arr.push_back(St);

    int max = 0;
    vector<string> result;

    for (string S : arr)
    {
        string n = getnoise(S);
        int k = n.size();

        if (k > max)
        {
            max = k;
            result.clear();
            result.push_back(n);
        }
        else if (k > 0 && k == max)
            result.push_back(n);
    }

    if (result.size() == 0)
        cout << "no noise" << endl;
    else if (result.size() == 1)
        cout << result[0] << endl;
    else
    {
        string res = result[0];
        for (unsigned i = 1; i < result.size(); i++)
        {
            if (result[i] < res)
                res = result[i];
        }
        cout << res << endl;
    }

    return 0;
}