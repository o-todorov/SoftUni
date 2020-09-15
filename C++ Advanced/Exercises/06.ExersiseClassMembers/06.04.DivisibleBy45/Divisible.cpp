#include "BigInt.h"

#include <algorithm>
#include<iostream>

int getLastDigit(const BigInt& bi) {
	std::string s = bi.getDigits();
	return s[s.length() - 1]-'0';
}

int getSumOfDigits(const BigInt& bi) {
	std::string s = bi.getDigits();
	int retsum = 0;
	for (char ch:s)
		retsum += ch-'0';

	return retsum;
}
bool divisibleBy45(const BigInt& bi) {
	int i = getLastDigit(bi);
	return  (i == 0 || i == 5) && getSumOfDigits(bi) % 9 == 0;
}

int main() {


	std::string start, end;
	std::cin >> start >> end;
	BigInt biStart(start);
	BigInt biEnd(end);

	int step = 1;

	for ( ; biStart < biEnd; biStart += step ) {
		if ( divisibleBy45(biStart)) {
			std::cout << biStart << std::endl;
			step = 45;
		}
	}


	return 0;
}