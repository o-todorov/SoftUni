
#include <iostream>
#include <vector>
//#include<math.h>

using namespace std;

int hexToDec(char arr[5])
{
    int result = 0;
    for (int i = 0; i < 5; i++)
    {
        char chTmp = arr[5 - 1 - i];
        int tmp;

        if (chTmp >= '0' && chTmp <= '9') tmp = 48;
        // else if (chTmp >= 'A' && chTmp <= 'F') tmp = 55;
        else if (chTmp >= 'a' && chTmp <= 'f') tmp = 87;
        else;

        result += (chTmp - tmp) * pow(16, i);
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
    size_t DNA=0;

    char endLine = '.';

    bool end = false;
    char ar[5];

    while (!end) 
    {
        short n = 0;
        char ch;
        cin.sync_with_stdio(false);
        cin >> ch;

        if (ch == endLine)
        {
            end = true;
            break;
        }

        ar[0] = ch;
        cin >> ar[1] >> ar[2] >> ar[ 3] >> ar[ 4];

        DNA^=hexToDec(ar);

    }


    vector <char> Output = DecToHex(DNA);
    for (char ch : Output)
        cout << ch;
    cout << endl;


    return 0;
}


