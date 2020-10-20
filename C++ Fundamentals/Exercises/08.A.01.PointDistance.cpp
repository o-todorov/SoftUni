#include<iostream>
#include <math.h>
using namespace std;

int main(){
    double x1,y1,x2,y2;
    cin>>x1>>y1>>x2>>y2;
    double sum;
    sum=pow(x1-x2,2)+pow(y1-y2,2);   
    cout << sqrt(sum) << endl;
    
    return 0;
}