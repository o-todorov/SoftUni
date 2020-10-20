#include<iostream>
#include<iomanip>
#include<math.h>

using namespace std;

class Point {
public:
    double x;
    double y;
public:
    Point() { x = 0; y = 0; }
    Point(double new_x, double new_y):x(new_x), y(new_y) {}

    double euclidian_distance_to(Point B) {
        double sum = pow(x - B.x, 2) + pow(y - B.y, 2);
        return sqrt(sum);
    }
};

int main() {

    Point A, B;

    cin >> A.x >> A.y >> B.x >> B.y;

    cout << fixed << setprecision(3) << A.euclidian_distance_to(B);

    return 0;
}