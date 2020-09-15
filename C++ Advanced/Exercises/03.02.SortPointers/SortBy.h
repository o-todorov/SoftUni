#ifndef SORT_BY_H
#define SORT_BY_H

#include<algorithm>


bool(*p)(const Company& a, const Company& b);

bool intsort(Company *start, Company *end) {

	return p(*start,* end);
}

void sortBy(Company** startptr, Company** endptr, bool(* sortfunc)(const Company&a , const Company&b)) {

	p = sortfunc;

	std::sort(startptr, endptr, intsort);




}








#endif // !SORT_BY_H