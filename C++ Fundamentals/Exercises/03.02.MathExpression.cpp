
#include <iostream>
#include<sstream>

using namespace std;


int main() {

    string Input;
    getline(cin, Input);

    const char LeftBr = '(';
    const char RightBr = ')';

    int balance = 0;
    bool correct = true;
    int itmp = 0;

    for (int i = 0; i < Input.length(); i++)
    {
        char ch = Input[i];

        switch (ch)
        {
        case (LeftBr):
            balance += 1;
            itmp = i;
            break;

        case(RightBr):
            balance -= 1;
            if ((i - itmp) == 1 || balance == -1)
                correct = false;
            break;

        default:
            break;
        }
        if (!correct) break;
    }

    if (!correct || balance != 0)
        cout << "incorrect" << endl;
    else
        cout << "correct" << endl;

    return 0;
}