#ifndef ORDERED_INSERTER_H 
#define ORDERED_INSERTER_H

#include "Company.h"
#include <vector>

class OrderedInserter {
private:
	std::vector<const Company*>* companies;
public:
	OrderedInserter(std::vector<const Company*>& companies):
		companies(& companies)
	{

	}

void insert( const Company* companyPtr) {

	int id = companyPtr->getId();
	int pos = 0;

	for ( size_t i = 0; i < (*companies).size(); i++ ) {

		if ( id < (*companies)[i]->getId() ) {
			pos = i;
			break;
		}
		pos = (*companies).size();
	}

	(*companies).insert((*companies).begin() + pos, companyPtr);

	}
};


#endif // !ORDERED_INSERTER_H
