#ifndef MIN_BY_H
#define MIN_BY_H

#include <iostream>
#include <string>

using namespace std;



string minBy(vector<string> values, bool (*minmax)(const string& , const string& )) {

	string retstring = "";

	retstring = values[0];

	for ( size_t i = 1; i < values.size(); i++ ) {

		if ( (*minmax)(values[i], retstring) ) {
			retstring = values[i];
		}
	}
	return retstring;

}




#endif // !MIN_BY_H