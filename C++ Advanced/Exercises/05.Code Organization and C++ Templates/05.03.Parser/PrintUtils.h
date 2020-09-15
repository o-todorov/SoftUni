#pragma once
#ifndef PRINT_UTILS_H
#define PRINT_UTILS_H


template<typename T>
void printVector(std::vector<T>& arr) {
	for ( T& t : arr )		std::cout << t << " ";
}



#endif // !PRINT_UTILS_H
