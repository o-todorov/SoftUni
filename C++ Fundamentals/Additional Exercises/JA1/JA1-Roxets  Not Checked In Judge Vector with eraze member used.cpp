
#include <iostream>
#include <vector>
#include<math.h>
#include<iomanip>

    using namespace std;

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
        int D;

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
        cin.sync_with_stdio(false);
        cout.sync_with_stdio(false);

        char endLine = '.';
        const int arrSizeMin = 5000;

        vector <int> DNA;
        vector<int>::iterator iDNA;

        bool end = false;
        //DNA.push_back(0);

        char arr[arrSizeMin];
        char ar[5];

        while (!end) // Loop for filling the array[5000]
        {
            short n = 0;
            char ch;
            short lastArrPos = arrSizeMin;
            while (n < arrSizeMin && !end) //Fill the array[5000] once
            {
                cin >> ch;

                if (ch == endLine)
                {
                    end = true;
                    lastArrPos = n;
                    break;
                }

                arr[n] = ch;
                cin >> arr[n + 1] >> arr[n + 2] >> arr[n + 3] >> arr[n + 4];
                n += 5;
            }

            for (int j = 0; j < lastArrPos; j += 5) // Convert the HEX to DEC and add in DNA if they are missing
            {
                char ar[] = { arr[j],arr[j + 1],arr[j + 2],arr[j + 3],arr[j + 4] };
                int t = hexToDec(ar);

                bool needToAdd = true;

                for (iDNA=DNA.begin(); iDNA != DNA.end(); iDNA++)
                {
                    if (t == *iDNA)
                    {
                        DNA.erase(iDNA);
                        needToAdd = false;
                        break;
                    }

                }

                if (needToAdd) 
                    DNA.push_back(t);
            }

        }

        cout << hex <<setw(5)<<setfill('0')<< DNA[0] << endl;

        /* same act:
        vector <char> Output = DecToHex(DNA[0]);

        for (char ch : Output) cout << ch;
            
        cout << endl;
        */

        return 0;
    }


