

#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    double a, b, c;
    double root1, root2;
    double discr;

    cin >> a >> b >> c;

    discr = ((b * b) - (4 * a * c));

    if (discr < 0)
        cout << "no roots" << endl;
    else if (discr == 0)
    {
        root1 = (-b) / 2 / a;
        cout << root1 << endl;
    }
    else
    {
        double D = sqrt(discr);
        root1 = (-b + D) / 2 / a;
        root2 = (-b - D) / 2 / a;
        cout << root1 << " " << root2 << endl;
    }



    return 0;


}
