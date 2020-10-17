#pragma once
#ifndef COMPARATORS_H
#define COMPARATORS_H

#include "Song.h"


template<typename T>
struct LessThan {
	bool  operator ()(const T& l, const T& r) const {
		return l < r;
	}

};
template<>
struct LessThan <Song>{
	bool  operator ()(const Song& l, const Song& r) const {
		if ( l < r || (l.getLengthSeconds() == r.getLengthSeconds() &&
					   l.getName() < r.getName()) )  return true;
		else return false;
	}
};

template<typename T, typename Comp>
struct Reverse {
	Comp comparer;
	bool  operator ()(const T& l, const T& r)const {
		return comparer(r,l);
	}
};


#endif // !COMPARATORS_H
