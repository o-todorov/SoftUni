#include "Register.h"

Register::Register(size_t numCompanies):
	numAdded(0) {
	this->companiesArray = new Company[numCompanies];
}

void Register::add(const Company& c) {
	this->companiesArray[numAdded] = c;
	this->numAdded++;
}

Company Register::get(int companyId) const {

	for ( size_t i = 0; i < this->numAdded; i++ ) {
		if ( this->companiesArray[i].getId() == companyId ) {
			return this->companiesArray[i];
		}
	}
	return Company();
}

Register::Register(const Register& other):
	numAdded(other.numAdded),
	companiesArray(other.companiesArray) {
}

Register& Register::operator=(const Register& other) {
	this->numAdded = other.numAdded;
	delete[]this->companiesArray;
	this->companiesArray = new Company[this->numAdded];
	for ( size_t i = 0; i < this->numAdded; i++ ) {
		this->companiesArray[i] = other.companiesArray[i];
	}
	return *this;
}

Register::~Register() {
	delete[] this->companiesArray;
}

