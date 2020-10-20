#include <iostream>
#include<vector>
using namespace std;
const int arrLength = 10;

int main()
{
    int arr[arrLength][2]; /* Създаване на помощен двумерен масив.
                           По просто е с едномерен но ми е по прегледно
                           да има двойки /елемент-брой/ повторения.
                           Условието за цифри от 0 до 9 ни улеснява много като
                           позволява да използваме тези цифри като индекси на
                           елементите на масива*/

    for (int i = 0; i < arrLength; i++)
    {
        arr[i][0] = i;
        arr[i][1] = 0;
    }

    int N, maxValue = 0;
    cin >> N;  //Прочита броя числа

    for (int i = 0; i < N; i++)
    {
        int j;
        cin >> j;    //прочита всяко число и увеличава броя във втория елемент на масива
        arr[j][1] += 1;
    }

    for (auto row : arr)
        if (row[1] > maxValue) maxValue = row[1]; // Намира макс брой повторения

    for (auto row : arr)
        if (row[1] == maxValue)  /* Проверка на броя повторения на всеки елемент
                                 и ако е равен на максималния го отпечатва*/
            cout << row[0] << " ";

    cout << endl;

    return 0;
}