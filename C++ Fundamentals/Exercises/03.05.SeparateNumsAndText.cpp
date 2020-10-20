
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


int main() {


    string input;
    getline(cin, input);
    istringstream in(input);

    vector<string>arr;

    string St;

    while (in >> St)  arr.push_back(St);

    St = "";

    int sum = 0;

    for (string S : arr)
    {

        if ((S[0] >= 48 && S[0] <= 57) || (S[0] == '-'))
            sum += strtoint(S);
        else
            St.append(" " + S);
    }
    St.replace(0, 1, "");

    ostringstream out;
    out << sum << endl << St;
    cout << out.str() << endl;

    return 0;
}