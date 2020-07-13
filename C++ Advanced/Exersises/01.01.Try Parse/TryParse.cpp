
#include "TryParse.h"

#include <string>



 bool tryParse(std::string& input, int& a) {

	 try {
		 a = stoi(input);

	 }
	 catch ( const std::exception& ) {
		 return false;
		 a = NULL;
	 }

	 return true;

}