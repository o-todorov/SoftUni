
#include <iostream>
#include<string>
#include<sstream>
#include<vector>
#include<math.h>

using namespace std;

int strtoint(string s)
{
    int minus = 1;
    if (s[0] == '-')
    {
        s.replace(0, 1, "");
        minus = -1;
    }

    int k = s.size();
    int Num = 0;

    for (int i = 0; i < k; i++)
    {
        char ch = s[i];
        Num = Num + (ch - 48) * pow(10, k - i - 1);
    }
    return Num * minus;
}

int getnumber(string s)
{
    string res = "";
    for (unsigned i = 0; i < s.size(); i++)
        if (s[i] >= 48 && s[i] <= 57)
            res += s[i];

    return strtoint(res);
}

int main() {


    string input;
    getline(cin, input);
    istringstream in(input);

    vector<string>arr;

    string St;

    while (in >> St)  arr.push_back(St);

    St = "";

    int max = 0;

    for (string S : arr)
    {
        int k = getnumber(S);
        if (k > max)
            max = k;
    }

    cout << max << endl;

    return 0;
}