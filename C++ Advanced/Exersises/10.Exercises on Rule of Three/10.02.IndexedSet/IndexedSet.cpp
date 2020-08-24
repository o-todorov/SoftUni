#include "IndexedSet.h"
#include <algorithm>

 IndexedSet::IndexedSet():
	valuesArray(nullptr) {
}

IndexedSet::IndexedSet(const IndexedSet& other) :
	valuesSet(other.valuesSet),
	valuesArray(nullptr) {
}

void IndexedSet::add(const Value& v) {
	this->valuesSet.insert(v);
	clearIndex();
}

size_t IndexedSet::size() const {
	return this->valuesSet.size();
}

const Value& IndexedSet::operator[](size_t index) {
	if ( !this->valuesArray ) buildIndex();
	return this->valuesArray[index];
}

IndexedSet& IndexedSet::operator=(const IndexedSet& other) {
	if ( this != &other ) {
		clearIndex();
		this->valuesSet = other.valuesSet;
	}
	return *this;
}

IndexedSet::~IndexedSet() {
	this->clearIndex();
}

inline void IndexedSet::buildIndex() {
	clearIndex();
	this->valuesArray = new Value[this->size()];

	std::copy(this->valuesSet.begin(), this->valuesSet.end(), this->valuesArray);
}

inline void IndexedSet::clearIndex() {
	if ( this->valuesArray != nullptr ) {
		delete[]this->valuesArray;
		this->valuesArray = nullptr;
	}
}
