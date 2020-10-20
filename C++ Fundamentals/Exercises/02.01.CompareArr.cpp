

#include <iostream>
using namespace std;
bool areEqual(int arr1[], int length1, int arr2[], int length2);

int main()
{
    int length1, length2;

    cin >> length1;
    int arr1[100];
    for (int i = 0; i < length1; i++)
        cin >> arr1[i];

    cin >> length2;
    int arr2[100];
    for (int i = 0; i < length2; i++)
        cin >> arr2[i];

    if (areEqual(arr1, length1, arr2, length2))
        cout << "equal" << endl;
    else
        cout << "not equal" << endl;

    return 0;


}
bool areEqual(int arr1[], int length1, int arr2[], int length2)
{
    if (length1!=length2 )
        return  false;
    else
    {
        bool equ = true;
        for (int i = 0; i < length1; i++)
        {
            if (arr1[i] != arr2[i])
            {
                equ = false;
                break;
            }
        }
        return equ;
    }
}