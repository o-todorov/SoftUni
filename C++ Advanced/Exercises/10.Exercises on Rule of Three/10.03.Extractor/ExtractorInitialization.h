#pragma once
#ifndef EXTRACTOR_INITIALIZATION_H
#define EXTRACTOR_INITIALIZATION_H

#include "BufferedExtractor.h"
#include "DigitExtractor.h"
#include "NumbersExtractor.h"
#include "QuotesExtractor.h"


std::shared_ptr<Extractor>getExtractor( std::string extractType, std::istringstream& lineIn) {

	if ( extractType == "digits" )
		return std::make_shared<DigitsExtractor>(lineIn);
	else if ( extractType == "numbers" )
		return std::make_shared<NumbersExtractor>(lineIn);
	else if ( extractType == "quotes" )
		return std::make_shared<QuotesExtractor>(lineIn);
	else
		throw "Invalit Extractor Type";
}


#endif // !EXTRACTOR_INITIALIZATION_H

