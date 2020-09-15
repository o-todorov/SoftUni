#pragma once
#ifndef SPLIT_H
#define SPLIT_H

#include <string>
#include <vector>
#include <sstream>

template<typename T>
std::vector<T> split(const std::string& line, const char& separator) {

	std::vector<T> retvec;
	T item;

	std::istringstream in(line);
	std::string str_item;

	while ( std::getline(in, str_item, separator) ) {
		std::istringstream is(str_item);
		is >> item;
		retvec.push_back(item);

	}

	return retvec;
}


#endif // !SPLIT_H





