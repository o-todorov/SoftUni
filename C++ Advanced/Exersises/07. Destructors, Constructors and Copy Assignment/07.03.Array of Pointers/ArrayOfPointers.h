#pragma once
#ifndef ARRAY_OF_POINTERS_H
#define ARRAY_OF_POINTERS_H

#include "Company.h"
#include <vector>


class ArrayOfPointers {
public:
	ArrayOfPointers();
	~ArrayOfPointers();
	void add( Company* company);
	size_t getSize()const;
	Company* get(const size_t& index)const;

private:
	std::vector<Company*> companies;
};





#endif // !ARRAY_OF_POINTERS_H
