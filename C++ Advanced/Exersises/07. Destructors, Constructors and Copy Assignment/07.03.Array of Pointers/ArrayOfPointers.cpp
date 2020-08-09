#include "ArrayOfPointers.h"



ArrayOfPointers::ArrayOfPointers():
	companies (std::vector<Company*>()){
}

void ArrayOfPointers::add( Company* company)  {
	this->companies.push_back(company);
}

size_t ArrayOfPointers::getSize() const {
	return this->companies.size();
}

Company* ArrayOfPointers::get(const size_t& index) const {
	return this->companies[index];
}

ArrayOfPointers::~ArrayOfPointers() {
	while ( !companies.empty() ) {
		delete companies[0];
		companies.erase(companies.begin());
	}
}

