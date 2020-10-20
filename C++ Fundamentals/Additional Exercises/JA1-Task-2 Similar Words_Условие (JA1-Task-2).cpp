#include<iostream>
#include <string>
#include<sstream>
#include<set>
using namespace std;



char validated_char(char tovalidate) {
	static set <char>punctuations({'.', ',', ';', '!', '?', ' '});

	if ( punctuations.find(tovalidate) != punctuations.end() )
		return ' ';
	else
		return tovalidate;
}

int main() {
	string input, texttocheck;
	getline(cin, input);


	for ( char ch : input ) {
		texttocheck.push_back(validated_char(ch));
	}
	istringstream in(texttocheck);

	string compare;
	int percent;
	cin >> compare >> percent;

	string word;
	int similar_words = 0;

	while ( in >> word ) {
		if ( word.size() != compare.size() || word.front() != compare.front() )
			continue;

		int sameletters = 1;

		for ( int i = 1; i < word.size(); i++ )
			if ( word[i] == compare[i] )	sameletters++;

		if ( double(sameletters) / word.size() * 100 >= percent )	similar_words++;
	}
	cout << similar_words << endl;

	return 0;
}