
#include <iostream>
#include<string>
#include<sstream>
#include<iomanip>

using namespace std;


int main() {


    string Input;
    cin.sync_with_stdio(false);
    getline(cin, Input);


    ostringstream out;

    char ch;
    bool word = false;

    for (unsigned i = 0; i < Input.size(); i++)
    {
        ch = Input[i];
        if (ch >= 97 and ch <= 122)
        {
            if (!word)
            {
                out << char(ch - 97 + 65);
                word = true;
            }
            else
                out << ch;
        }
        else if (ch >= 65 and ch <= 90)
        {
            word = true;
            out << ch;
        }
        else
        {
            word = false;
            out << ch;
        }
    }

    cout.sync_with_stdio(false);
    cout << out.str() << endl;

    return 0;
}