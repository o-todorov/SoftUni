#ifndef COMPANYMEMORYUTILS_H
#define COMPANYMEMORYUTILS_H

#include <string>
#include <vector>

#include "Company.h"

typedef unsigned char byte;

std::vector<Company> readCompaniesFromMemory (byte* memory, int numCompanies) {

	std::vector<Company> companies;

	while ( numCompanies-- ) {

		int id = *memory;

		memory++;

		std::string name = "";

		char currchar ;

		while ( (currchar = *memory++) != '\0' ){

			name.push_back(currchar);
		}


		int empcount = *memory++;


		std::vector<std::pair<char, char> > employees;

		for ( int i = 0; i < empcount; i++ ) {
			char name1 = *memory++;
			char name2 = *memory++;			
			employees.push_back(std::pair<char, char>(name1, name2));

		}

		Company c(id, name, employees);

		companies.push_back(c);

	}

	return companies;
}

#endif // !COMPANYMEMORYUTILS_H