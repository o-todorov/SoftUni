#pragma once
#ifndef  INCLUDES_H
#define INCLUDES_H

#include <vector>
#include <iostream>
#include <sstream>
#include "City.h"
#include "CityDiff.h"

std::istream& operator>>(std::istream& in, City& c) {
	std::string name;
	unsigned int censusYear;
	size_t population;

	in >> name >> population >> censusYear;
	c = City(censusYear, name, population);

	return in;
}

CityDiff operator-(const City& a, const City& b) {
	std::ostringstream out;

		//   "New York (1900 vs. 2013)"
		// "Washington (2011) vs. New York (2013)"
	out << a.getName() << " (" << a.getCensusYear();
	out << (a.getName() == b.getName() ? " vs. " : ") vs. " + b.getName().append(" ("));
	out << b.getCensusYear() << ")" << std::endl << "population: ";
		//population: +708409
	int population =(int) a.getPopulation() -(int) b.getPopulation();
	out << (population < 0 ? "-" : "+") << std::abs(population) << std::endl;

	return CityDiff(out.str());
}

std::ostream& operator <<(std::ostream& out,  CityDiff& cdiff) {
	cdiff.print(out);
	return out;
}

#endif // ! INCLUDES_H

