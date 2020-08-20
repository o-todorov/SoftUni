#pragma once
#ifndef FILTER_FACTORY_H
#define FILTER_FACTORY_H

class FilterFactory:public Filter {
	std::string filterDefinition;

	bool shouldFilterOut(char symbol) const override {
		char start = filterDefinition[0];
		char end = filterDefinition[2];
		return symbol >= start && symbol <= end;
	}

public:
	FilterFactory() {}
	FilterFactory(std::string filterDefinition):
		filterDefinition(filterDefinition) {
	}

	Filter* buildFilter(const std::string& filterDefinition)const {
		return new FilterFactory(filterDefinition);
	}

	~FilterFactory() {}


};





#endif // !FILTER_FACTORY_H
