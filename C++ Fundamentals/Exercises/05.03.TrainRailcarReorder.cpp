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
    stack <int>A,B;
    fill_int_stack(&A);
    fill_int_stack(&B);

    stack<int> train_result;
    string order;

    while (!A.empty()&&!B.empty())
    {
        if (A.top() < B.top()) {
            train_result.push(A.top());
            A.pop();  order += "A";
        }
        else {
            train_result.push(B.top());
            B.pop();  order += "B";
        }
    }

    if (A.empty()) {
        while (!B.empty()) {
            train_result.push(B.top());
            B.pop();  order += "B";
        }
    }
    else
    {
        while (!A.empty()) {
            train_result.push(A.top());
            A.pop();  order += "A";
        }

    }
    

   cout << order << endl;
   size_t j = train_result.size();
   for (int i = 0;i < j;i++) {
       cout << train_result.top() << " ";
       train_result.pop();
   }


    return 0;
}


