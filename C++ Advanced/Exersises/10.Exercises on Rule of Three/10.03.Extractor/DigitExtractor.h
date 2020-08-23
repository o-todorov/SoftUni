#pragma once
#ifndef DIGIT_EXTRACTOR_H
#define DIGIT_EXTRACTOR_H

class DigitsExtractor:public BufferedExtractor {
public:
	DigitsExtractor(std::istream& stream): BufferedExtractor(stream) {}

	virtual bool shouldBuffer(char symbol) {
		if ( isdigit(symbol) ) this->buffer << symbol;

		return false;
	}

	~DigitsExtractor() {}

};


#endif // !DIGIT_EXTRACTOR_H
