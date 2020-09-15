#pragma once


#ifndef CITY_UTILS_H
#define CITY_UTILS_H

#include <map>
#include <vector>
#include "City.h"

std::map<int,const City*> groupByPopulation(const std::vector<const City*>&cities,  size_t & totalPopulation) {
	totalPopulation = 0;
	std::map<int,const  City*> m;
	for ( const City* c : cities ) {
		m[c->getPopulation()] = c;
		totalPopulation += c->getPopulation();
	}
		return m;

}

City* initCity(const std::string& name, const size_t population) {
	City* c = new City(name, population);
	return c; 
}

#endif // !CITY_UTILS_H
