#include "UnitPtr.h"
#include <iostream>


std::map < T*, int> UnitPtr::refCount;


UnitPtr::UnitPtr(T* rawPointer) {
	this->pointer = rawPointer;
	refCount[this->pointer] = 1;
}

UnitPtr::UnitPtr():
	pointer(nullptr) {
}

UnitPtr UnitPtr::from(T* rawPointer) {
	return UnitPtr(rawPointer);
}

UnitPtr::UnitPtr(const UnitPtr& other) {
	this->pointer = other.pointer;
	refCount[this->pointer]++;
}

T& UnitPtr::operator*() {
	return *(this->pointer);
}

T* UnitPtr::operator->() const {
	return this->pointer;
}

UnitPtr& UnitPtr::operator=(const UnitPtr& other) {
	if ( this != &other ) {
		if(this->pointer!=nullptr) refCount[this->pointer]--;
		this->pointer = other.pointer;
		refCount[this->pointer]++;
	}
	return *this;
}

UnitPtr::~UnitPtr() {
	if ( this->pointer != nullptr ) {
		if ( refCount.find(this->pointer) == refCount.end() )
			std::cout << "Error: Nothing in the map" << std::endl;

		refCount[this->pointer]--;

		if ( refCount[this->pointer] <= 0 ) {
			delete this->pointer;
			refCount.erase(this->pointer);
		}
	}
}
