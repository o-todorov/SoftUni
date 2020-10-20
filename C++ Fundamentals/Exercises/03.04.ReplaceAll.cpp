
#include <iostream>
#include<string>
#include<sstream>
#include<iomanip>

using namespace std;


int main() {


    string input;
    cin.sync_with_stdio(false);
    getline(cin, input);
    int size = input.size();

    string find;
    getline(cin, find);
    int findSize = find.size();

    string replace;
    getline(cin, replace);
    int replaceSize = replace.size();

    ostringstream out;

    char ch;
    bool word = false;

    int findPos;
    findPos = input.find(find);

    while (findPos != -1)

    {
        input.replace(findPos, findSize, replace);
        findPos = input.find(find, findPos + replaceSize);
    }

    out << input;

    cout.sync_with_stdio(false);
    cout << out.str() << endl;

    return 0;
}