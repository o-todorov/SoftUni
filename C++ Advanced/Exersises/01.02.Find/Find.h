#ifndef FIND_H
#define FIND_H

#include "Company.h"
#include <vector>

Company* find(std::vector <Company*> companies, int searchId) {
	for ( auto ptr : companies ) {
		if ( (*ptr).getId() == searchId ) {
			return ptr;
			break;
		}
	}



	return NULL;
}



#endif // !FIND_H