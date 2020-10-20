

#include <iostream>
using namespace std;

int main()
{
    int a,b;
    cin >> a >> b;

    int smallN, bigN;
    if (a < b)
    {
        smallN = a;
        bigN = b;
    }
    else
    {
        smallN = b;
        bigN = a;
    }
       
   for (int i = smallN; i >=1; i--)
    {
       if (((bigN % i) == 0) && ((smallN % i) == 0))
       {
           cout << i << endl;
           break;
       }
    }
 

    return 0;


}
