#pragma once
#ifndef JOIN_H
#define JOIN_H

#include <string>
#include <vector>
#include <sstream>

template<typename T>
std::string join(const std::vector<T>& container, const std::string& joinStr);


#endif // !JOIN_H

template<typename T>
inline std::string join(const std::vector<T>& container, const std::string& joinStr) {
	std::ostringstream out;

	for ( T item : container ) out << item << joinStr; 
	
	return out.str().substr(0, out.str().length()- joinStr.length());
}
