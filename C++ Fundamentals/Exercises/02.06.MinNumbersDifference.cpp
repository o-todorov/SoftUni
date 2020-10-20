#include <iostream>
#include<vector>
using namespace std;

int main()
{
    int N, min_Distance;
    cin >> N;
    vector<int>inArr;

    for (int i = 0; i < N; i++) // Loading Numbers From The Console
    {
        int curr;
        cin >> curr;
        inArr.push_back(curr);
    }

    if (N == 1)
    {
        min_Distance = 0;
        cout << 0 << endl;
        return 0;
    }

    min_Distance = abs(inArr[0] - inArr[1]);



    for (int i = 0;i < N;i++)
    {
        int a = inArr[i];

        for (int j = 0;j < N;j++)
        {
            if (i != j)
            {
                int b = inArr[j];
                if (abs(a - b) < min_Distance)
                    min_Distance = abs(a - b);
            }
        }
    }

    cout << min_Distance << endl;

    return 0;
}