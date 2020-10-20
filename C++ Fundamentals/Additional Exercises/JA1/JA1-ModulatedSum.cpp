
#include <iostream>
#include <vector>
#include<math.h>

using namespace std;

vector <int> readVector(int numCount)
{
    vector<int> result;
    for (int i = 0; i < numCount; i++)
    {
        int j;
        cin >> j;
        result.push_back(j);
    }
    return result;
}

void printVector(vector<int> vectorToPrint, int numCount)
{
    for (auto i : vectorToPrint)
        cout << i << " ";
    cout << endl;
}

void modulatedSum()
{
    int arrCount, numCount;
    cin >> arrCount >> numCount;

    vector<vector <int>> numbers;

    for (int i = 0; i < arrCount; i++)
        numbers.push_back(readVector(numCount)); //Reading each single array

    int mod; cin >> mod;

    vector <int> modulated; // The resulting array
    modulated.resize(numCount);

    for (int i = 0; i < numCount; i++)
    {
        int sum = 0;

        for (int j = 0; j < arrCount; j++)
        {
            sum += numbers[j][i];
        }
        modulated[i] = abs(sum) % mod;
    }
    printVector(modulated, numCount);
}


int main()
{
    modulatedSum();

    return 0;
}

