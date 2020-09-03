#include "StringConcatenator.h"

StringConcatenator::StringConcatenator() {
}

StringConcatenator::~StringConcatenator() {
}

std::string getLchar(const std::string& from, int size, bool& end ) {
	static int pos = 0;
	if ( pos < size ) return from.substr(pos++,1);
	end = true;
	return "";
}
std::string getRchar(const std::string& from, int size, bool& end ) {
	static int pos = 0;
	if ( pos < size ) return from.substr(pos++,1);
	end = true;
	return "";
}

std::string StringConcatenator::concatenate(const ConcatenateStrategy strategy, const char* left, const size_t leftSize, const char* right, const size_t rightSize) const {
	std::string ret = "";
	if ( leftSize == 0 )return right;
	else if ( rightSize == 0 )return left;
	else {
		int left_step = 1, right_step = 1;
		if ( strategy == ConcatenateStrategy::LEFT_1_RIGHT_2 )right_step = 2;
		else if ( strategy == ConcatenateStrategy::LEFT_2_RIGHT_1 )left_step = 2;
		bool lfail=false, rfail=false;
		do {
			if ( !lfail ) {
				ret.append(getLchar(left, leftSize, lfail));
				if ( !lfail && left_step == 2 ) ret.append(getLchar(left, leftSize, lfail));
			}

			if ( !rfail ) {
				ret.append(getRchar(right, rightSize, rfail));
				if ( !rfail && right_step == 2 ) ret.append(getRchar(right, rightSize, rfail));
			}


		} while ( !lfail || !rfail );

	}

	return ret;
}
