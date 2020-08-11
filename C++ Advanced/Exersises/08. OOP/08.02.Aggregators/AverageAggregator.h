#ifndef AVERAGE_AGREGATOR
#define AVERAGE_AGREGATOR

#include "Aggregator.h"

class AverageAggregator: public StreamAggregator {
public:
	AverageAggregator(std::istringstream& income): StreamAggregator(income) {
		int a, sum = 0, count = 0;

		while ( income >> a ) {
			sum += a;
			count++;
		}

		this->aggregationResult = sum / count;

	}
};


#endif // !AVERAGE_AGREGATOR
