#pragma once
#ifndef PARSE_H
#define PARSE_H

#include <iostream>
#include <sstream>


template<typename T> class Parser {
public:
	Parser(std::istream& is, const std::string& stopline);

	bool readNext(T& n);

private:
	std::istream* is;
	std::string stopline;
};

template<typename T> Parser<T>::Parser(std::istream& is, const std::string& stopline):
	is(&is),
	stopline(stopline) {}

template <typename T> bool Parser<T>::readNext(T& n) {
	std::string line;
	std::getline(*is, line);
	if ( line != stopline ) {
		std::istringstream in(line);
		in >> n;
		return true;
	}
	else return false;
}


#endif // !PARSE_H
