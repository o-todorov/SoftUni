#include <iostream>
#include<vector>

using namespace std;
void PrintAboveAverage(vector<int> NumToPrint);

int main()
{
    int arrLength, arrSum=0;
    cin >> arrLength;
    vector<int> arr;
    double arrAverage;
    
    for (int i = 0; i < arrLength; i++)
    {
        int Curr;
        cin >> Curr;
        arr.push_back (Curr);
        arrSum += Curr;
    }

    arrAverage = arrSum / arrLength;

    vector <int> NumToPrint;

    for (int num:arr)
        if (num>=arrAverage)    NumToPrint.push_back(num);

    PrintAboveAverage(NumToPrint);

    return 0;
}

void PrintAboveAverage(vector<int> NumToPrint)
{
    for (int Num:NumToPrint)
    {
        cout << Num << " ";
    }
    cout << endl;
}