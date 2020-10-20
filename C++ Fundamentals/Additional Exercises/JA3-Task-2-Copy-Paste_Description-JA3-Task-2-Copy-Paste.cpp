#include <iostream>
#include <string>
#include <stack>
#include<math.h>
#include<algorithm>

using namespace std;

int main() {
    string input;
    getline(cin, input);

    stack<string>clipboard;
    int start, end, paste;
    string copied;

    string comm;
    cin >> comm;
    while ( comm != "end" ) {
        if (comm == "copy"){
            cin >> start >> end;

            int f = input.rfind(' ', start);
            start = max(0, f+1);
            end = input.find(' ', end);
            if ( end == -1 )end = input.size();

            copied = input.substr(start, end - start);
            clipboard.push(copied);
        }
        else {
            cin >>paste;
            if ( !clipboard.empty() ) {
                string l = input.substr(0, paste);
                string r= input.substr(paste, input.size() - paste);
                copied = clipboard.top();
                clipboard.pop();

                if ( input[paste] == ' ' ) l.append(" ");
                input = l +copied+ r;
                //cout << input<<endl;
            }
        }
        cin >> comm;
    }
    cout << input;

    return 0;
}
