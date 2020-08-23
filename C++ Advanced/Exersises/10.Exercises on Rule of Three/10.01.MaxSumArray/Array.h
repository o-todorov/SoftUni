#pragma once
#ifndef  ARRAY_H
#define ARRAY_H

#include <string>
#include <algorithm>

template<typename T>
class Array {
	int* arr;
	size_t size;
public:
	Array(size_t size):
		arr(new T[size]),
		size(size) {
	}
	Array(const Array& other):
		arr(new T[other.size]),
		size(other.size) {
		copy(other.begin(), other.end(), arr);
	}

	Array& operator= (const Array& other) {
		if ( this != &other ) {
			if ( this->size != other.size ) {
				delete[] this->arr;
				this->arr = nullptr;
				this->size = 0;
				this->size = other.size;
				this->arr = new T[this->size];
			}
			std::copy(other.begin(), other.end(), arr);
		}
		return *this;
	}


	size_t getSize() {
		return this->size;
	}

	T* begin() const {
		return arr;
	}

	T* end()const {
		return arr + this->size;
	}

	T& operator[](size_t index) const {
		return arr[index];
	}


	~Array() {
		delete[]arr;
		arr = nullptr;
	}

private:

};




#endif // ! ARRAY_H
