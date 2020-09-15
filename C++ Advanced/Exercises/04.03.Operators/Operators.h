#ifndef OPERATORS_H
#define OPERATORS_H

#include <ostream>
#include <vector>
#include <string>
#include <sstream>

std::vector<std::string>& operator<<(std::vector<std::string>& out, const std::string& toadd) {

	out.push_back(toadd);

	return out;
}

std::ostream& operator<<(std::ostream& out, const std::vector<std::string>& toprint) {

	for ( auto s : toprint ) 		out << s << std::endl;
	
	return out;
}

std::string& operator+(std::string& base, const int& toappend) {
	std::ostringstream out;
	out << toappend;
	base.append(out.str());

	return base;
}





#endif // !OPERATORS_H