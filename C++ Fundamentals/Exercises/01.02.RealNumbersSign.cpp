

#include <iostream>
using namespace std;

int main()
{
    double a, b, c;
    bool negativ_;

    cin >> a >> b >> c;

    if (a == 0 || b == 0 || c == 0)
    {
        cout << "+" << endl;
        return 0;
    }

    negativ_ = a < 0;
    if (b < 0) negativ_ = !negativ_;
    if (c < 0) negativ_ = !negativ_;
    if (negativ_)
        cout << "-" << endl;
    else
        cout << "+" << endl;
    return 0;


}
