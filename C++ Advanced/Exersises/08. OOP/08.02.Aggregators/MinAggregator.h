#ifndef MIN_AGGREGATOR
#define MIN_AGGREGATOR

#include <sstream>

#include "Aggregator.h"

class MinAggregator: public StreamAggregator {
public:
	MinAggregator(std::istringstream& income):
		StreamAggregator(income) {
		int a;
		this->aggregationResult = INT_MAX;

		while ( income >> a )
			if ( a < this->aggregationResult )this->aggregationResult = a;

	}

};


#endif // !MIN_AGGREGATOR
