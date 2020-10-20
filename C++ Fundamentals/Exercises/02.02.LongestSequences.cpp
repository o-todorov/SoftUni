

#include <iostream>
using namespace std;

int main()
{
    int ArrLength;

    cin >> ArrLength;
    int arr[100];
    for (int i = 0; i < ArrLength; i++)
        cin >> arr[i];

    int lastValue = arr[0], longestLength = 1,currLength = 1, num=lastValue;

    for (int i = 1; i < ArrLength; i++)
    {
        int currValue = arr[i];

        if (currValue == lastValue)
            currLength++;
        else
        {
            lastValue = currValue;
            currLength = 1;
        }

        if (currLength >= longestLength)
        {
            longestLength = currLength;
            num = currValue;
        }
    }
    for (int i = 0; i < (longestLength-1); i++)
    {
        cout << num << " ";
    }
        cout << num<<endl;



    return 0;


}
