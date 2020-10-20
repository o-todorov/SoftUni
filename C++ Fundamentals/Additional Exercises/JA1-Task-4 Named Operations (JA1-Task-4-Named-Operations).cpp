#include <iostream>
#include <algorithm>
#include <vector>
#include <map>
#include <string>
#include <sstream>

using namespace std;

enum class OperType { sum, ave, min, max };

class Operations {
    OperType operation=OperType::sum;
    vector<int> numbers;
    int start=0, end=0;
public:
    void set_operation(OperType operation,int start,int end)  { 
        this->operation = operation;
        this->start = start;
        this->end = end;
    }
    void set_array(vector<int> arr)         { this->numbers = arr; }

    int get_result() {
        vector<int> arr;
        arr.resize(end-start);
        copy(numbers.begin()+start, numbers.begin()+end, arr.begin());
        int res = 0;

        switch ( operation ) {
        case OperType::sum:
            for ( int i : arr ) res += i;
            break;
        case OperType::ave:
            for ( int i : arr ) res += i;
            res = res / (int)arr.size();
            break;
        case OperType::min:
            res = arr[0];
            for ( int i : arr ) if(i<res) res=i;
            break;
        case OperType::max:
            for ( int i : arr ) if ( i > res ) res = i;
            break;
        default:
            break;
        }
        return res;
    }


};

istringstream line_to_stream() {
    string in;
    cin.ignore();
    getline(cin, in);
    return istringstream (in);
}

vector<int> line_to_vec_int() {
    string in;
    getline(cin, in);
    istringstream instream(in);
    int n;
    vector<int>ret;
    while ( instream >> n )
        ret.push_back(n);
    return ret;
}


int main() {
    Operations oper;
    vector<int>input = line_to_vec_int();
    oper.set_array(input);

    map<string, int> opers;
    int P;  string s; int n;
    cin >> P;
    while ( P-- ) {
        cin >> s >> n;
        opers[s]=n;
    }

    int count = 0;
    ostringstream out;
    int start, end;
    string action;
    cin >> action;
    while ( action!="end" ) {
        count++;
        cin >> start >> end;
        oper.set_operation((OperType) opers[action], start, end);
        out << action << "(" << start << "," << end << ")=" << oper.get_result(); 
        cin >> action;
        if ( action == "end" ) {
             out << "}";
             break;
        }
        else  out<< ',';
    }
    
    cout << "[" << count << "]{" << out.str();

    return 0;
}
