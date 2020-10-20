#include <iostream>
#include<sstream>
#include <stack>
#include<string>

using namespace std;

void fill_int_stack(stack<int>*mystack) {
    string line; int j;
    
    getline(cin, line);
    istringstream in(line);
    while (in >> j) mystack->push(j);
}


int main()
{
    string input;
    getline(cin, input);
    istringstream in(input);

    //   Brackets   {} = 3
    //   Brackets   [] = 2
    //   Brackets   () = 1

    stack <int> br;
    char curr;
    bool valid = true;

    while (in>>curr && valid)
    {

        switch (curr)
        {
        case '{':
            if ( br.empty()|| br.top() == 3)
                br.push(3);
            else  valid = false;
                break;

        case '[':
            if ( br.empty()||br.top() >=2 )
                br.push(2);
            else  
                valid = false;  
            break;

        case '(':
            br.push(1); 
            break;

       case '}':
            if (br.top() == 3 )
                br.pop();
            else 
                valid = false; 
            break;

        case ']':
            if (br.top() == 2)
                br.pop();
            else  
                valid = false;  
            break;

        case ')':
            if (br.top() == 1)
                br.pop();
            else  
                valid = false;  
            break;

        default:
            break;
        }
    }
    
    if (br.size() > 0) valid = false;

    cout << (valid ? "valid" : "invalid") << endl;


    return 0;
}


