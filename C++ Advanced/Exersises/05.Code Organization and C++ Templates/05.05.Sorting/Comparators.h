#pragma once
#ifndef COMPARATORS_H
#define COMPARATORS_H


template<typename T>
struct LessThan {
	bool  operator ()(const T& l, const T& r) const {
		return l < r;
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
