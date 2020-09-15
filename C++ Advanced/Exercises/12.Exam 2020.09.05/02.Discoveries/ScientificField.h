#pragma once
#ifndef _H
#define _H

#include <set>
#include <vector>
#include <map>


class ScientificField {
	std::vector<std::vector<Discovery> > groups;
	std::map<int, std::string> groupnames = {{0, "Philosophy:"},
											 {1, "Linguistics:"},
											 {2, "Physics:"},
											 {3, "Chemistry:"}};
	std::vector<int>print_indexes {2, 1, 0, 3};
public:
	ScientificField() {
		for ( int i = 0; i < 4; i++ )	groups.emplace_back(std::vector<Discovery>());
	}

	void print() {
		for ( int i : print_indexes ) {
			std::cout << groupnames[i] << std::endl;

			for ( Discovery d : groups[i] )
				std::cout << d.name << " " << d.year << " - " << d.scientistName << std::endl;
		}
	}
	friend ScientificField& operator<<(ScientificField& sf, const Discovery& d);

private:

};

bool operator<(const Discovery& l, const Discovery& r) {
	return l.year < r.year;
}

ScientificField& operator<<(ScientificField& sf, const Discovery& d) {
	auto group = sf.groups[d.fieldType - 1];

	for ( int i = 0; i < group.size(); i++ ) {
		if ( d.year < group[i].year ) {
			group.insert(group.begin() + i, d);
			return sf;
		}
	}

	sf.groups[d.fieldType - 1].push_back(d);

	return sf;
}


#endif // !_H
