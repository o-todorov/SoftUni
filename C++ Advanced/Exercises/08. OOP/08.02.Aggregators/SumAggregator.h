#ifndef SUM_AGGREGATOR
#define SUM_AGGREGATOR

#include <sstream>

#include "Aggregator.h"

class SumAggregator: public StreamAggregator {
private:
	std::istringstream stream;

public:

	SumAggregator(std::istringstream& income): StreamAggregator(income) {
		this->aggregationResult = 0;
		int a;
		while ( income >> a ) 	this->aggregationResult += a;
			}

};



#endif // !SUM_AGGREGATOR
