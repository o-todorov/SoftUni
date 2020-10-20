
#include <iostream>
#include<string>
#include<sstream>
#include<vector>
#include<fstream>
#include<math.h>

using namespace std;

bool operation(int a, int b, char op)
{
    {
        bool res = true;

        switch (op)
        {
        case '-':
            cout << a - b << endl;
            break;
        case '+':
            cout << a + b << endl;
            break;
        case '*':
            cout << a * b << endl;
            break;
        case '/':
            cout << a / b << endl;
            break;
        default:
            res = false;
            cout << "try again" << endl;
            break;
        }

        return res;
    }
}

int hexToDec(char arr[5])
{
    int result = 0;
    int tmp;

    for (int i = 0; i < 5; i++)
    {
        char chTmp = arr[i];

        if (chTmp >= 'a') {
            tmp = 10 + (chTmp - 'a');
        }
        else {
            tmp = chTmp - '0';
        }

        result = result << 4; // this is equivalent to value *= 16;, but works faster than multiplication
        result += tmp;
    }

    return result;
}


vector<char> DecToHex(int DecNum)
{
    vector<char> result;
    char HexChars[] = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
    int D, tmp;

    while (DecNum > 0)
    {
        D = DecNum % 16;
        result.push_back(HexChars[D]);
        DecNum /= 16;
    }

    while (result.size() < 5) result.push_back('0');
    int J = result.size();

    for (int i = 0; i < 2; i++)
    {
        char t = result[i];
        result[i] = result[J - 1 - i];
        result[J - 1 - i] = t;
    }


    return result;
}

int main()
{

    cout.sync_with_stdio(false);

    size_t DNA = 0;

    char endLine = '.';
    bool end = false;
    char ar[5];

    string fname = "test.010.in.txt";
    ifstream inFStream;
    inFStream.open(fname);

    char ch;
    while (!end)
    {
        inFStream.get(ch);

        if (ch == endLine)
        {
            end = true;
            break;
        }

        ar[0] = ch;

        for (int i = 1; i < 5; i++)
            inFStream.get(ar[i]);

        DNA ^= hexToDec(ar);

    }
    cout << hex << DNA << endl;

    return 0;
}