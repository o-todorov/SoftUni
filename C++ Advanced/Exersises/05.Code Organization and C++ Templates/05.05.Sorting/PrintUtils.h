#pragma once
#ifndef PRINT_UTILS_H
#define PRINT_UTILS_H

#include "Comparators.h"
#include <set>



template <class T, class U = typename std::iterator_traits<T>::value_type>

void printContainer(U  begin, U end) {
	for ( begin; begin != end; begin++ )		std::cout << (*begin) << " ";
}



#endif // !PRINT_UTILS_H
