#pragma once
#ifndef VECTOR_COMPARISONS_H
#define VECTOR_COMPARISONS_H

#include "Vector.h"

struct VectorLengthComparer {
	;
	bool operator()(const Vector& a, const Vector& b) const{

		return a.getLength() < b.getLength();

	}
};
template<typename T, typename Comp>
struct ReverseComparer {
	bool operator()(const Vector& a, const Vector& b) const{
		Comp comp;
		return comp(b, a);

	}
};



#endif // !VECTOR_COMPARISONS_H
