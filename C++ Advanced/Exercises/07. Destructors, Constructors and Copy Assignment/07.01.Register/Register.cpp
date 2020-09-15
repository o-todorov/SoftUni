#include "Company.h"
#include "Register.h"

Register::Register(size_t numCompanies):
	numAdded(0) {
	this->companiesArray = new Company[numCompanies];
}

void Register::add(const Company& c) {
	this->companiesArray[numAdded++] = c;
}

Company Register::get(int companyId) const {
	std::string name;
	for ( size_t i = 0; i < this->numAdded; i++ ) {
		if ( this->companiesArray[i].getId() == companyId ) {
			return this->companiesArray[i];
		}
	}
	return Company();
}

Register::~Register() {
	delete[] this->companiesArray;
}
