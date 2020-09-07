#pragma once
#ifndef MAGIC_KINGDOM_H
#define MAGIC_KINGDOM_H

#include <vector>
#include <set>
#include <algorithm>
#include <iostream>
#include "Struct.h"


class MagicKingdom {
	std::vector<Villager>commoner;
	std::vector<Villager>magicians;
	std::vector<Villager>antiMags;

public:

	void printAll();

	friend MagicKingdom& operator<<(MagicKingdom& kingdom, const Villager& v);
};

bool operator<(const Villager& l, const Villager& r) {
	return l.power < r.power;
}

struct greater {
	bool operator()(Villager const& l, Villager const& r) {
		return l.power > r.power;
	}
};

std::ostream& operator<<(std::ostream& out, const std::vector<Villager>& v) {
	for ( auto p : v )
		out << p.name << " - " << p.magicItem << std::endl;

	return out;
}

MagicKingdom& operator<<(MagicKingdom& kingdom, const Villager& v) {
	if ( v.power >= 100 )kingdom.magicians.push_back(v);
	else if ( v.power >= 0 && v.power <= 99 )kingdom.commoner.push_back(v);
	else  if ( v.power < 0 )kingdom.antiMags.push_back(v);

	return kingdom;
}

void print(std::vector<Villager>& v,std::string message, bool asc=true) {
	asc ? std::sort(v.begin(), v.end()) : std::sort(v.begin(), v.end(), greater());

	std::cout << message << std::endl << v;
}

void MagicKingdom::printAll() {
	print(antiMags, "Anti-Mages:");
	print(commoner, "Commoners:",false);
	print(magicians, "Mages:",false);
}


#endif // !MAGIC_KINGDOM_H
