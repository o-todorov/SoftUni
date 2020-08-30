#include "Range.h"

Range::Range():
	rangeFirst(0),
	rangeLength(0),
	valueCounts(nullptr) {
}

void Range::add(T value) {
	if ( this->empty() ) {
		this->valueCounts = new size_t[1];
		this->valueCounts[0] = 1;
		this->rangeFirst = value;
		this->rangeLength = 1;
	}
	else if ( value<this->rangeFirst ||
			 value>this->rangeFirst + this->rangeLength - 1 ) {

		T first = std::min(value, this->rangeFirst);
		T last = std::max(value, this->rangeFirst + this->rangeLength - 1);

		resize(first, last);
		this->valueCounts[value - this->rangeFirst] = 1;
	}
	else
		this->valueCounts[value - this->rangeFirst] += 1;
}

size_t Range::getCount(T value) const {
	size_t index = getIndex(value);
	if ( index >= this->rangeLength ) return 0;
	return this->valueCounts[index];
}

void Range::clear() {
	if ( this->valueCounts ) {
		delete[]this->valueCounts;
		this->valueCounts = nullptr;
	}
	this->rangeFirst = 0;
	this->rangeLength = 0;

}

void Range::resize(T first, T last) {
	size_t newLength = last - first + 1;
	size_t* temp = new size_t[newLength] {0};
	int step = this->rangeFirst - first;

	for ( int i = 0; i < this->rangeLength; i++ )
		temp[i + step] = this->valueCounts[i];


	this->clear();
	this->valueCounts = temp;
	temp = nullptr;
	this->rangeFirst = first;
	this->rangeLength = newLength;
}

bool Range::empty() const {
	if ( !this->valueCounts ) return true;
	else return false;
}

Range::Range(const Range& other):
	rangeFirst(other.rangeFirst),
	rangeLength(other.rangeLength),
	valueCounts(nullptr) {

	if ( other.valueCounts )
		this->valueCounts = this->copyValues(other);
}

Range& Range::operator=(const Range& other) {
	if ( this != &other ) {

		this->clear();

		if ( other.valueCounts ) {
			this->valueCounts = this->copyValues(other);
			this->rangeFirst = other.rangeFirst;
			this->rangeLength = other.rangeLength;
		}
	}
	return *this;
}

Range::~Range() {
	if ( this->valueCounts ) {
		delete[]this->valueCounts;
		this->valueCounts = nullptr;
	}
}

size_t Range::getIndex(T value) const {
	//size_t index = value - this->rangeFirst;
	//if ( index < 0 || index >= this->rangeLength ) index = -1;
	return value - this->rangeFirst;
}
