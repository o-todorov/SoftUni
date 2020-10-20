#include <iostream>
#include<string>

using namespace std;

int main() {

	int charsCount;
	cin >> charsCount;
	string one(charsCount,' '), two(charsCount, ' ');

	for ( int i = 0; i < charsCount; i++ )	cin >> one[i];
	for ( int i = 0; i < charsCount; i++ )	cin >> two[i];

	int diffCount = 0;
	int sum = 0;
	char a, b;

	for ( int i = 0; i < charsCount; i++ ) {
		a = one[i];
		b = two[i];

		if ( a >= '0' && a <= '9' ) sum += a - '0';
		if ( b >= '0' && b <= '9' ) sum += b - '0';	

		if ( a == b )	continue;

		if ( a >= 'A' && a <= 'Z' && a == b + ('A' - 'a') ) continue;

		else if ( a >= 'a' && a <= 'z'&& a + ('A' - 'a') == b ) one[i] = b;

		else  {
			diffCount++;
			one[i] = '#';
		}


	}
	cout << one << endl;
	cout << diffCount << endl;
	cout << charsCount - diffCount << endl;
	cout << sum << endl;	return 0;
}


