#pragma once
#ifndef STREAM_ITERATOR_H
#define STREAM_ITERATOR_H

#include <sstream>


class StreamInputIterator {
	std::istream& in;
	std::string endString;
	int currVal;
public:
	StreamInputIterator(std::istream& in):
		in(in) {
		in >> currVal;
	}

	StreamInputIterator(std::istream& in, const std::string& endString):
		in(in),
		endString(endString),
		currVal(0) {
	}

	static StreamInputIterator begin(std::istream& in) {
		return StreamInputIterator(in);
	}

	static StreamInputIterator  end(std::istream& in, const std::string& endString) {
		return StreamInputIterator(in, endString);
	}

	StreamInputIterator operator++() {
		in >> endString;
		std::istringstream iss(endString);
		iss >> currVal;

		return *this;
	}

	int operator*() {
		return currVal;
	}

	bool operator==(const StreamInputIterator& other) const {
		return &this->in == &other.in && this->endString == other.endString;
	}
	bool operator!=(const StreamInputIterator& other)const {
		return !(this->operator==(other));
	}


};


#endif // !STREAM_ITERATOR_H
