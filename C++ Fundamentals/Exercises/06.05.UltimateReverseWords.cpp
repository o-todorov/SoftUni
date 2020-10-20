//Write a program that reads lines of space separated words from the standard 
//    input(until “end” word is met), reverse the order* of all given words
//    (with the same size) and outputs the result to the standard output.
//NOTE: the reverse of words follows a special procedure :
//    -Only words with the same character count are swapped;
//    -The first word containing 1 letter should be swapped with the last(Nth) word 
//        containing 1 letter.The second word with 1 letter should be swapped with the 
//        one before the last(Nth - 1) word container 1 letter.
//    - The same goes for 2 letter words, 3 letters words … N letter words;
//    -Punctuation should remain in the same place. (commas, dots, question marks, etc …);
//    -After the reverse all sentences should again start with capital letters.
//        All other letters should be lowercase;


#include <iostream>
#include <string>
#include<sstream>
#include<vector>

using namespace std;

bool isletter(char c) {     // Check if the char is not a punctuation mark
    string exclude = { ' ','.',',',':',';','"','*','-','!','?','/','(',')','[',']','{','}','@' };
    exclude.find(c)==-1? return true: return false;
}

int main(){
    string input,t;
    getline(cin, input);

        // Decapitalise the first / leter if need /
    if (input[0] >= 65 and input[0] <= 90)
        input[0] = input[0] + 32;

    istringstream in(input);
        // Create 3 synchronised vectors: words; start inex for each word in the input; length of the word
    vector<string> words;
    vector<int>pos;
    vector<int>len;

    string word;
    char c;
    int i = 0;  // Store the current index

        // Read the words from input
    while (!in.eof()) {
        c = in.get();
        if (isletter(c))                    // check the next char is valid and create word
            word += c;
        
            
        else if(word!=""){                  // when a word is completed:
            if (word=="end")  break;        // if "end" word is reached ends the While loop
            words.push_back(word);          // keep each word
            pos.push_back(i-word.size());   // keep same word start index in the input string
            len.push_back(word.size());     // keep same word length
            word = "";                      // clear the variable for the next word
        }
        i++;
    }
    
    for (size_t i=0;  i<words.size() ;  i++)
    {
            // Backward search in the length vector for each word.
            // If there is same length word and if find - reverse them and 
            //updaet all three vectors erasing already replaced words at the back
        unsigned l =len[i];
        unsigned j = len.size() - 1;

        while ( j>i)
        {
            if (len[j] == l) {
                input.replace(pos[i], l, words[j]);
                input.replace(pos[j], l, words[i]);
                words.erase(words.begin()+j);
                len.erase(len.begin()+j);
                pos.erase(pos.begin()+j);
                break;
            }

            j--;
        }
    }

        // Capitalise the first letter
    if (input[0] >= 97 and input[0] <= 122) input[0] = input[0] - 32;
    cout << input << endl;

    return 0;
}

