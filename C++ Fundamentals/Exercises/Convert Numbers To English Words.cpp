#include <iostream>
#include <vector>
#include <queue>
#include<sstream>

using namespace std;
string convert(int num) {

    string first[] = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eightteen", "nineteen"};
    string tens[] = {"zero","ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventeen", "eighty", "ninety"};

    queue <string>res;
    if ( num < 0 ) return "Negative value!";
    if ( num == 0 ) return "zero";

    if ( num > 1000000000 ) return "Number is above function range";

    if ( num >= 1000000 ) {
        res.push(convert(num / 1000000));
        res.push("million");
        if ( num % 1000000 )res.push(convert(num % 1000000));
    }
    else if ( num >= 1000 ) {
        res.push(convert(num / 1000));
        res.push("thousand");
        if ( num % 1000 )res.push(convert(num % 1000));
    }
    else if ( num >= 100 ) {
        res.push(first[num / 100]);
        res.push("hundred");
        if ( num % 100 )res.push(convert(num % 100));
    }
    else if ( num >= 20 ) {
        res.push(tens[num / 10]);
        if ( num % 10 > 0 )res.push(convert(num % 10));
    }
    else     res.push(first[num]);

    string ret = "";

    while ( !res.empty() ) {
        if(res.front()!="")ret.append(res.front() + " ");
        res.pop();
    }

    ret.pop_back();
    return ret;
}

int main() {
    vector<int>v;
    v = {0, 999999999,19,11,20,29,260,1000,100,10, 1500,155000,1000000,65235148};
    for ( int i : v )
        cout << i << " ";
    cout << endl << endl;

    for ( int i:v ) {
        cout << i << endl;
        cout << convert(i)<<endl;
    }
    return 0;
}