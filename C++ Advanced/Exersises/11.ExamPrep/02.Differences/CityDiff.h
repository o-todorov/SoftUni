#pragma once
#ifndef CITY_DIFF_H
#define CITY_DIFF_H

class CityDiff {
	std::string diff;
public:
	CityDiff(const std::string& diff):diff(diff) {}

	void print(std::ostream& out) { out << diff ; }

	~CityDiff() {}
};



#endif // !CITY_DIFF_H
