
#ifndef REMOVEDUPLICATES_H
#define REMOVEDUPLICATES_H

#include "Company.h"
#include <algorithm>
#include <list>
#include <string>


void removeDuplicates( std::list<Company*>& companies){

	std::list<std::string> unique;
		
	for (  std::list<Company*>::iterator it = companies.begin(); it != companies.end(); ) {

		if ( std::find(unique.begin(), unique.end(),(*it)->getName() ) == unique.end() ) {
			unique.push_back((**it).getName());
			it++;
		}

		else {
			it = companies.erase(it);
		}
	}


}














#endif // !REMOVEDUPLICATES_H