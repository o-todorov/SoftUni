#pragma once
#ifndef STATISTICS_H
#define STATISTICS_H

#include "Structs.h"
#include <sstream>
#include <vector>

class Statistics{
public:
	Statistics() {}

	void printStatistics();
	friend Statistics& operator<<(Statistics& stat, const PersonInfo& p);

	~Statistics() {}

private:
	std::vector<PersonInfo>minors;
	std::vector<PersonInfo>adults;
	std::vector<PersonInfo>elders;

};




#endif // !STATISTICS_H
