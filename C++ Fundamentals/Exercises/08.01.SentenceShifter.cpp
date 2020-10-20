#include<iostream>
#include<vector>
#include<string>
#include<sstream>
#include<math.h>

using namespace std;

class ShiftSentence {
private:
    vector <string> sentence;
    int shift_positions=0;
public:
    ShiftSentence(string &str_input) {  //Class constructor with string argument
        setSentence(str_input);
    }

    void setSentence(string &str_input) {   // Sets the sentence with a function
        string word;
        istringstream input(str_input);
        sentence.clear();
        while ( input >> word )
            sentence.push_back(word);
    }

    void set_shift_positions(int shift_pos){    // Sets the shift parameter with a function
        this->shift_positions = shift_pos;
    }

    string getShiftedSentence() {      // Gets a resulting string depend on the shift value
        if ( sentence.size() == 0 ) return "";

        unsigned start = 0;
        string ret="";

        if ( shift_positions > 0 ) {    // set start position if shift is positiv
                                        // works even shift value is bigger than vectors size
            start = sentence.size() - shift_positions % sentence.size();
        }
        else if ( shift_positions == 0 ) start = 0; //Keep the sentence same if shift=0
        else    start = (abs(shift_positions)) % sentence.size();
                                        // set start position if shift is positiv
                                        // works even shift value is bigger than vectors size

        for ( unsigned i = start; i < sentence.size(); i++ ) ret += sentence[i] + " ";
        for ( unsigned i = 0; i < start; i++ ) ret += sentence[i] + " ";

        return ret;

    }
};

int main() {

    string input;
    getline(cin, input);

    int shift_pos;
    cin >> shift_pos;

    ShiftSentence shift(input);
    shift.set_shift_positions(shift_pos);
    input = shift.getShiftedSentence();

    istringstream shifted(input);
    string word;

    while ( shifted >> word )  cout << word << endl;

    return 0;
}