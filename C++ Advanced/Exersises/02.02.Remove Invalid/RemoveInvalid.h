#ifndef REMOVE_INVALID_H
#define REMOVE_INVALID_H

#include "Company.h"

using namespace std;

void removeInvalid(std::list<Company*> &companies) {


	for ( std::list<Company*>::iterator it = companies.begin() ; it != companies.end(); ){

		if ( (*it)->getId() < 0 ) {

			delete* it;

			it = companies.erase(it);

		}
		else
			it++;

	}


}



#endif // !REMOVE_INVALID_H