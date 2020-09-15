#pragma once
#ifndef QUOTES_EXTRACTOR_H
#define QUOTES_EXTRACTOR_H

class QuotesExtractor:public BufferedExtractor {
public:
	static  bool bufferOn;

	QuotesExtractor(std::istream& stream): BufferedExtractor(stream) {}

	virtual bool shouldBuffer(char symbol) {
		if ( symbol == '"' && bufferOn ) {
			return bufferOn = false;
		}
		else if ( symbol == '"' && !bufferOn ) {
			bufferOn = true;
			return false;
		}
		else
			return bufferOn;
	}

	~QuotesExtractor() {}

};

bool QuotesExtractor::bufferOn = false;

#endif // !QUOTES_EXTRACTOR_H