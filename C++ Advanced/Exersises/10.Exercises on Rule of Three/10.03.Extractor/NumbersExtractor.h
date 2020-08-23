#pragma once
#ifndef NUMBERS_EXTRACTOR_H
#define NUMBERS_EXTRACTOR_H

class NumbersExtractor:public BufferedExtractor {

public:
	NumbersExtractor(std::istream& stream): BufferedExtractor(stream) {}

	virtual bool shouldBuffer(char symbol) {
		return isdigit(symbol);

	}

	~NumbersExtractor() {}

};



#endif // !NUMBERS_EXTRACTOR_H