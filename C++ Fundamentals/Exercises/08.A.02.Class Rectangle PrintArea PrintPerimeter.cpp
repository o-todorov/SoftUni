#include<iostream>
#include <vector>
#include<queue>

using namespace std;

class Rectangle {
private:
    double width;
    double height;
public:
    Rectangle() {
        width = 0;
        height = 0;
    }
    Rectangle(double new_width, double new_height) :width(new_width), height(new_height) {}

    void print_area() {
        cout << width * height << endl;
    }
    void print_perimeter() {
        cout << (width + height) * 2 << endl;
    }


};

int main() {

    double width, height;
    cin >> width >> height;

    Rectangle r(width, height);
    r.print_area();
    r.print_perimeter();

    return 0;
}