#pragma once
#ifndef TYPED_STREAM_H
#define TYPED_STREAM_H

#include <iostream>
#include <vector>
#include<sstream>

template<typename T>

class TypedStream {
protected:
	std::istringstream stream;
public:
	TypedStream(const std::string& str):stream(str) {
	}

	virtual  TypedStream <T>& operator>>(T& t) = 0;

	std::string readToEnd() {
		std::ostringstream out;
		std::vector<T> v;
		T t;
		while ( true ) {
			*this >> t;
			if ( stream.fail() )break;
			v.push_back(t);
		}
		out << v;
		return out.str();
	}

private:

};





#endif // !TYPED_STREAM_H
