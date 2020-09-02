#include "FixedArray.h"
#include <iostream>
#include <string>

//void FixedArray::print(std::string message="") {
//	if ( message != "" ) std::cout << message << ":\n";
//	for ( int i = 0; i < this->getSize(); i++ )
//		std::cout << this->_array[i] << " ";
//	std::cout << std::endl<< std::endl;
//}

//void FixedArray::print(std::string message="") const{
//	if ( message != "" ) std::cout << message << ":\n";
//	for ( int i = 0; i < this->getSize(); i++ )
//		std::cout << this->_array[i] << " ";
//	std::cout << std::endl<< std::endl;
//}

int* copyArray(int* arr, int size);

FixedArray::FixedArray(const int arraySize):
	BrokenArray(arraySize) {
	//print( "After Constructor:");
}

FixedArray::~FixedArray() {
	if ( this->_array ) {
		//print( "Before Destructor:");
		delete[]this->_array;
		this->_array = nullptr;
	}
}

FixedArray::FixedArray(const FixedArray& other):BrokenArray(other) {
	this->_array = copyArray(other._array, this->getSize());
	//print(  "After CopyConstructor:");
}

FixedArray& FixedArray::operator=(const FixedArray& other) {
	BrokenArray::operator=(other);
	//print(  "Before AssignConstructor:");
	if ( this != &other ) {
		if ( this->_array ) {
			delete[]this->_array;
			this->_array = nullptr;
		}

		this->_array = copyArray(other._array, other.getSize());
	}
	//print(  "After AssignConstructor:");

	return *this;
}

void FixedArray::addValueToMemory(const int value) {
	BrokenArray::addValueToMemory(value);
	//print(  "After IncrValues:");
}

int FixedArray::getMemorySumValue() const {
	return BrokenArray::getMemorySumValue();
}

int* copyArray(int* arr, int size) {
	if ( size <= 0 ) return nullptr;

	int* _arr = new int[size];

	for ( int i = 0; i < size; i++ )
		_arr[i] = arr[i];

	return _arr;
}

