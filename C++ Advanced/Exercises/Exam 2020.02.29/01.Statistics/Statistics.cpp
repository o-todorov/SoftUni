#include "Statistics.h"
#include <iostream>

void addAsc(std::vector<PersonInfo>& v, const PersonInfo& p) {
	for ( size_t i = 0; i < v.size(); i++ )
		if ( p.age < v[i].age ) {
			v.insert(v.begin() + i, p);
			return;
		}
	v.push_back(p);
}
void addDesc(std::vector<PersonInfo>& v, const PersonInfo& p) {
	for ( size_t i = 0; i < v.size(); i++ )
		if ( p.age > v[i].age ) {
			v.insert(v.begin() + i, p);
			return;
		}
	v.push_back(p);
}

Statistics& operator<<(Statistics& stat, const PersonInfo& p) {
	if ( p.age <= 18 )addAsc(stat.minors, p);
	else if  (p.age >18 && p.age <=62)addAsc( stat.adults,p);
	else  addDesc(stat.elders, p);
	return stat;
}

std::ostream& operator<<(std::ostream& out, const std::vector<PersonInfo>& v) {
	for ( auto p : v )
		out << p.firstName << " " << p.lastName << " " << p.height << std::endl;
	return out;
}


void Statistics::printStatistics() {
	std::cout << "Elders data:" << "\n" << elders ;
	std::cout << "Adults data:" << "\n" << adults ;
	std::cout << "Minors data:" << "\n" << minors ;
}

