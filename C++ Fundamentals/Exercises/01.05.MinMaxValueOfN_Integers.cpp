

#include <iostream>
using namespace std;

int main()
{
    int N; //Number of the Integers to be read
    cin >> N;

    int currVal;
    cin >> currVal;

    int minVal=currVal;
    int maxVal=currVal;
       
   for (int i = 2; i <=N; i++)
    {
       cin >> currVal;
       if (currVal < minVal)
           minVal = currVal;
       else if (currVal > maxVal)
           maxVal = currVal;
    }
 
   cout << minVal << " " << maxVal << endl;

    return 0;


}
