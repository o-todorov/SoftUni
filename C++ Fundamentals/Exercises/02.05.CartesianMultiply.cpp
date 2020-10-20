#include <iostream>
#include<vector>
using namespace std;

int main()
{
    int N;
    cin >> N;
    vector<int>inArr, outArr;

    for (int i = 0; i < N; i++) // Loading Numbers From The Console
    {
        int curr;
        cin >> curr;
        inArr.push_back (curr);
    }

    for (int a:inArr)
    {
        for (int b:inArr)
        {
            outArr.push_back(a * b);
        }
    }

    for (int a:outArr)
    {
        cout << a << " ";
    }
    cout << endl;

    return 0;
}